﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfClient.CustomerSvcRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CustomerSvcRef.ICustomerService")]
    public interface ICustomerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetName", ReplyAction="http://tempuri.org/ICustomerService/GetNameResponse")]
        string GetName();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetName", ReplyAction="http://tempuri.org/ICustomerService/GetNameResponse")]
        System.Threading.Tasks.Task<string> GetNameAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICustomerServiceChannel : WcfClient.CustomerSvcRef.ICustomerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CustomerServiceClient : System.ServiceModel.ClientBase<WcfClient.CustomerSvcRef.ICustomerService>, WcfClient.CustomerSvcRef.ICustomerService {
        
        public CustomerServiceClient() {
        }
        
        public CustomerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetName() {
            return base.Channel.GetName();
        }
        
        public System.Threading.Tasks.Task<string> GetNameAsync() {
            return base.Channel.GetNameAsync();
        }
    }
}
