using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            GreetSvc();
            GetCompositeData();
            GetCustomerName();

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            //Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        private static void GetCustomerName()
        {
            CustomerSvcRef.CustomerServiceClient client = new CustomerSvcRef.CustomerServiceClient();
            var retVal = client.GetName();
            Console.WriteLine($"Customer service returned: {retVal}");
        }

        private static void GreetSvc()
        {
            SvcRef.Service1Client client = new SvcRef.Service1Client();
            var retVal = client.GetData(10);
            var greet = client.Greet("Ajay Singala");

            Console.WriteLine($"{retVal} and {greet}");
        }

        private static void GetCompositeData()
        {
            SvcRef.Service1Client client = new SvcRef.Service1Client();
            SvcRef.CompositeType composite = new SvcRef.CompositeType();
            composite.BoolValue = true;
            composite.StringValue = "John Smith";

            var retVal = client.GetDataUsingDataContract(composite);
            Console.WriteLine($"{retVal.StringValue}");

        }
    }
}
