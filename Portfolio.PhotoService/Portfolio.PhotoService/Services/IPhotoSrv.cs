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
    [ServiceContract]
    public interface IPhotoSrv
    {
        [WebInvoke(Method = "*", UriTemplate = "GetPhoto/{photoId}")]
        [OperationContract]
        Stream GetPhoto(string photoId);
    }
}
