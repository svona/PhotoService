using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Portfolio.PhotoService
{
    public class PhotoSrv : IPhotoSrv
    {
        public Stream GetPhoto(string photoId)
        {
            throw new NotImplementedException();
        }
    }
}
