using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            PhotoServiceReference.PutPhotoSrvClient client = null;
            try
            {
                client = new PhotoServiceReference.PutPhotoSrvClient();

                int photoId = client.SavePhoto(1, File.ReadAllBytes(@"C:\Users\svona\Pictures\leanr fly.png"), "svona");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (client != null)
                    if (client.State == CommunicationState.Faulted)
                        client.Abort();
                    else
                        client.Close();
            }
        }
    }
}
