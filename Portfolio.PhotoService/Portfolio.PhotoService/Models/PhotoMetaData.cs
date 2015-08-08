using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Portfolio.PhotoService
{
    [DataContract]
    public class PhotoMetaData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public DateTime CreationDate { get; set; }

        [DataMember]
        public int LengthInBytes { get; set; }

        [DataMember]
        public int WidthInPixels { get; set; }

        [DataMember]
        public int HeightInPixels { get; set; }

        [DataMember]
        public string ContentType { get; set; }

        [DataMember]
        public byte[] Md5Checksum { get; set; }
    }
}