using DemoWcf01.Client.SvcRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWcf01.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SvcRef.Service1Client();
            var retVal = client.GetData(10);
            Console.WriteLine($"Service returned {retVal}");

            var data = new CompositeType()
            {
                BoolValue = true,
                StringValue = "Hello there!"
            };
            var retVal2 = client.GetDataUsingDataContract(data);
            Console.WriteLine($"Service returned {retVal2.BoolValue} and {retVal2.StringValue}");

        }
    }
}
