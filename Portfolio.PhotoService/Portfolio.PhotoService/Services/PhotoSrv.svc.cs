using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace Portfolio.PhotoService
{
    public class PhotoSrv : IPhotoSrv, IPutPhotoSrv
    {
        #region IPhotoService Implementation
        public Stream GetPhoto(string photoId)
        {
            var result = new MemoryStream();
            string filePath = null, contentType = "image/jpeg";
            byte[] txContext = null;

            using (var connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["PhotosDB"].ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var cmd = new SqlCommand("GetPhoto", connection, transaction))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@photoId", SqlDbType.Int).Value = photoId;

                        using (var sdr = cmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                filePath = sdr.GetValue<string>("PathName", String.Empty);
                                contentType = sdr.GetValue<string>("ContentType", "image/jpeg");
                                txContext = (byte[])sdr["txContext"];
                            }
                        }
                    }

                    if (!String.IsNullOrWhiteSpace(filePath))
                    {
                        using (var sqlStream = new SqlFileStream(filePath, txContext, FileAccess.Read))
                        {
                            sqlStream.CopyTo(result);
                            result.Position = 0;
                        }
                    }

                    transaction.Commit();
                }
            }

            WebOperationContext.Current.OutgoingResponse.ContentType = contentType;
            return result;
        }
        #endregion

        #region IPutPhotoService Implementation
        public int SavePhoto(int productId, byte[] imageFile, string createdBy)
        {
            int photoId = 0;
            string filePath = null;
            byte[] txContext = null;
            int width, height;
            byte[] hash;

            using (var memStream = new MemoryStream(imageFile))
            {
                using (var b = new Bitmap(memStream))
                {
                    width = b.Width;
                    height = b.Height;
                }
            }

            using (var hashGenerator = MD5.Create())
            {
                hash = hashGenerator.ComputeHash(imageFile);
            }

            using (var connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["PhotosDB"].ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var cmd = new SqlCommand("SavePhoto", connection, transaction))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@productId", SqlDbType.Int).Value = productId;
                        cmd.Parameters.Add("@createdBy", SqlDbType.NVarChar, 50).Value = createdBy;

                        cmd.Parameters.Add("@widthInPixels", SqlDbType.Int).Value = width;
                        cmd.Parameters.Add("@heightInPixels", SqlDbType.Int).Value = height;
                        cmd.Parameters.Add("@lengthInBytes", SqlDbType.Int).Value = imageFile.Length;

                        cmd.Parameters.Add("@contentType", SqlDbType.VarChar, 255).Value = MimeType.GetMimeType(imageFile, null);
                        cmd.Parameters.Add("@md5Checksum", SqlDbType.VarBinary, 16).Value = hash;

                        using (var sdr = cmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                filePath = sdr.GetValue<string>("PathName", String.Empty);
                                photoId = sdr.GetValue<int>("Id");
                                txContext = (byte[])sdr["txContext"];
                            }
                        }
                    }

                    if (!String.IsNullOrWhiteSpace(filePath))
                    {
                        using (var sqlStream = new SqlFileStream(filePath, txContext, FileAccess.Write))
                        {
                            sqlStream.Write(imageFile, 0, imageFile.Length);
                        }
                    }

                    transaction.Commit();
                }
            }

            return photoId;
        }

        public List<PhotoMetaData> ListMetaData(int productId)
        {
            var result = new List<PhotoMetaData>();
            using (var connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["PhotosDB"].ConnectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand("ListProductImageMetaData", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@productId", SqlDbType.Int).Value = productId;
                    using (var sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            result.Add(new PhotoMetaData
                            {
                                Id = sdr.GetValue<int>("Id"),
                                ProductId = sdr.GetValue<int>("ProductId"),
                                CreatedBy = sdr.GetValue<string>("CreatedBy", String.Empty),
                                CreationDate = sdr.GetValue<DateTime>("CreationDate"),
                                LengthInBytes = sdr.GetValue<int>("LengthInBytes"),
                                WidthInPixels = sdr.GetValue<int>("WidthInPixels"),
                                HeightInPixels = sdr.GetValue<int>("HeightInPixels"),
                                ContentType = sdr.GetValue<string>("ContentType", String.Empty),
                                Md5Checksum = sdr.GetByteArray("MD5Checksum")
                            });
                        }
                    }
                }
            }

            return result;
        }
        #endregion
    }
}
