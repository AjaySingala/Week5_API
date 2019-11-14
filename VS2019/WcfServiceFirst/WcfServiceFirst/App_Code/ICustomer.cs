using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomer" in both code and config file together.
[ServiceContract]
public interface ICustomer
{
    [OperationContract]
    string GetAll();
    [OperationContract]
    CustomerEntity Get(int id);
}
