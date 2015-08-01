using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.PhotoService
{
    [ServiceContract]
    interface IPutPhotoSrv
    {
        [OperationContract]
        int SavePhoto(int productId, byte[] imageFile, string createdBy);
    }
}
