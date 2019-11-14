using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppOldClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SvcRefOld.Service1Client client = new SvcRefOld.Service1Client();
            Console.WriteLine(client.GetData(200));

            // New.
            SvcRefNew.ServiceClient clientNew = new SvcRefNew.ServiceClient();
            Console.WriteLine(client.GetData(202));
        }
    }
}
