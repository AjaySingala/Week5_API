using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFirstClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SvcRef.ServiceClient client = new SvcRef.ServiceClient();
            var result = client.GetData(985);
            Console.WriteLine(result);

            result = client.GetData(641);
            Console.WriteLine(result);

            result = client.FooBar();
            Console.WriteLine(result);

            CustomerSvcRef.CustomerClient custClient = new CustomerSvcRef.CustomerClient();
            var result2 = custClient.GetAll();
            Console.WriteLine(result2);

            //result2 = custClient.Get(22);
            //Console.WriteLine(result2);

            // Using DataContract.
            SvcRef.CompositeType ct = new SvcRef.CompositeType();
            ct.BoolValue = true;
            ct.StringValue = "My name is John";
            
            var newCT = client.GetDataUsingDataContract(ct);
            Console.WriteLine(ct.BoolValue);
            Console.WriteLine(ct.StringValue);

            Console.WriteLine(newCT.BoolValue);
            Console.WriteLine(newCT.StringValue);

            // Customer DataContract.
            var customerResult = custClient.Get(10);
            Console.WriteLine(string.Format("Id: {0}. Firstname: {1} Lastname: {2}",
                customerResult.Id, customerResult.Firstname, customerResult.Lastname));
        }
    }
}
