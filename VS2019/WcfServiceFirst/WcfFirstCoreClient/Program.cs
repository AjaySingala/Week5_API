using System;

namespace WcfFirstCoreClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SvcRef.ServiceClient client = new SvcRef.ServiceClient();
            var data = client.GetDataAsync(10);
            Console.WriteLine(data.Result);
        }
    }
}
