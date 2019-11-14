using System;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SvcRef.ServiceClient client = new SvcRef.ServiceClient();
            var data = client.GetDataAsync(100);
            Console.WriteLine(data.Result);

            SvcRefOld.Service1Client clientOld = new SvcRefOld.Service1Client();
            var dataOld = clientOld.GetDataAsync(101);
            Console.WriteLine(dataOld.Result);
        }
    }
}
