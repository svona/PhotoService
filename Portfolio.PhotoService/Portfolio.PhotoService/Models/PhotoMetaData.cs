using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Portfolio.PhotoService
{
    [DataContract]
    public class PhotoMetaData
    {
        [DataMember]
        [Display(Name = "Id", ResourceType = typeof(Resources))]
        public int Id { get; set; }

        [DataMember]
        [Display(Name = "ProductId", ResourceType = typeof(Resources))]
        public int ProductId { get; set; }

        [DataMember]
        [Display(Name = "CreatedBy", ResourceType = typeof(Resources))]
        public string CreatedBy { get; set; }

        [DataMember]
        [Display(Name = "CreationDate", ResourceType = typeof(Resources))]
        public DateTime CreationDate { get; set; }

        [DataMember]
        [Display(Name = "LengthInBytes", ResourceType = typeof(Resources))]
        public int LengthInBytes { get; set; }

        [DataMember]
        [Display(Name = "WidthInPixels", ResourceType = typeof(Resources))]
        public int WidthInPixels { get; set; }

        [DataMember]
        [Display(Name = "HeightInPixels", ResourceType = typeof(Resources))]
        public int HeightInPixels { get; set; }

        [DataMember]
        [Display(Name = "ContentType", ResourceType = typeof(Resources))]
        public string ContentType { get; set; }

        [DataMember]
        [Display(Name = "Md5Checksum", ResourceType = typeof(Resources))]
        public byte[] Md5Checksum { get; set; }
    }
}