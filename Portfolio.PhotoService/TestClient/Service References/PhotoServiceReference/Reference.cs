﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestClient.PhotoServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PhotoServiceReference.IPhotoSrv")]
    public interface IPhotoSrv {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPhotoSrv/GetPhoto", ReplyAction="http://tempuri.org/IPhotoSrv/GetPhotoResponse")]
        System.IO.Stream GetPhoto(string photoId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPhotoSrv/GetPhoto", ReplyAction="http://tempuri.org/IPhotoSrv/GetPhotoResponse")]
        System.Threading.Tasks.Task<System.IO.Stream> GetPhotoAsync(string photoId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPhotoSrvChannel : TestClient.PhotoServiceReference.IPhotoSrv, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PhotoSrvClient : System.ServiceModel.ClientBase<TestClient.PhotoServiceReference.IPhotoSrv>, TestClient.PhotoServiceReference.IPhotoSrv {
        
        public PhotoSrvClient() {
        }
        
        public PhotoSrvClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PhotoSrvClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PhotoSrvClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PhotoSrvClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.IO.Stream GetPhoto(string photoId) {
            return base.Channel.GetPhoto(photoId);
        }
        
        public System.Threading.Tasks.Task<System.IO.Stream> GetPhotoAsync(string photoId) {
            return base.Channel.GetPhotoAsync(photoId);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PhotoServiceReference.IPutPhotoSrv")]
    public interface IPutPhotoSrv {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutPhotoSrv/SavePhoto", ReplyAction="http://tempuri.org/IPutPhotoSrv/SavePhotoResponse")]
        int SavePhoto(int productId, byte[] imageFile, string createdBy);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPutPhotoSrv/SavePhoto", ReplyAction="http://tempuri.org/IPutPhotoSrv/SavePhotoResponse")]
        System.Threading.Tasks.Task<int> SavePhotoAsync(int productId, byte[] imageFile, string createdBy);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPutPhotoSrvChannel : TestClient.PhotoServiceReference.IPutPhotoSrv, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PutPhotoSrvClient : System.ServiceModel.ClientBase<TestClient.PhotoServiceReference.IPutPhotoSrv>, TestClient.PhotoServiceReference.IPutPhotoSrv {
        
        public PutPhotoSrvClient() {
        }
        
        public PutPhotoSrvClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PutPhotoSrvClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PutPhotoSrvClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PutPhotoSrvClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int SavePhoto(int productId, byte[] imageFile, string createdBy) {
            return base.Channel.SavePhoto(productId, imageFile, createdBy);
        }
        
        public System.Threading.Tasks.Task<int> SavePhotoAsync(int productId, byte[] imageFile, string createdBy) {
            return base.Channel.SavePhotoAsync(productId, imageFile, createdBy);
        }
    }
}