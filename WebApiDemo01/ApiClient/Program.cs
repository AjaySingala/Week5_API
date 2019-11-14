using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApiClient
{
    class Program
    {
        private static string _url = "http://localhost:62838/";

        static void Main(string[] args)
        {
            GetCustomers();

            //var customer = GetCustomerJsonAsync().Result;
            //Console.WriteLine($"\t{customer.Id}: {customer.Firstname} {customer.Lastname}");

            var task = AddCustomerAsync();
            task.Wait();

            GetCustomersObject();

            Console.WriteLine("Press <ENTER> to continue...");
            Console.ReadLine();
        }

        private static void GetCustomers()
        {
            Console.WriteLine("Method GetCustomers()...");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var apiUrl = "api/customer";
            var stringTask = client.GetStringAsync(_url + apiUrl);
            var res = stringTask.Result;

            //var msg = await stringTask;
            Console.WriteLine($"\t{res}");
        }

        private static void GetCustomersObject()
        {
            Console.WriteLine("Method GetCustomersObject()...");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var apiUrl = "api/customer";
            var stringTask = client.GetStringAsync(_url + apiUrl);
            var res = stringTask.Result;
            var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(res);

            foreach(var customer in customers)
            {
                Console.WriteLine($"\t{customer.Id}: {customer.Firstname} {customer.Lastname}");
            }
        }

        private static async Task<Customer> GetCustomerJson()
        {
            Console.WriteLine("Method GetCustomerJson()...");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var apiUrl = "api/customer/101";

            //var ser = new DataContractJsonSerializer(typeof(Customer));
            //var streamTask = client.GetStreamAsync(_url + apiUrl);
            //var customer = ser.ReadObject(await streamTask) as Customer;

            var streamString = await client.GetStringAsync(_url + apiUrl);
            //var res = streamTask.Result;
            var customer = JsonConvert.DeserializeObject<Customer>(streamString);

            return customer;
        }      

        private async static Task AddCustomerAsync()
        {
            Console.WriteLine("Method AddCustomer()...");

            var cust = new Customer
            {
                Firstname = "ABC",
                Lastname = "XYZ"
            };

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var apiUrl = "api/customer";
            var data = JsonConvert.SerializeObject(cust);
            var jsonData = new StringContent(data, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(_url + apiUrl, jsonData);
            Console.WriteLine($"\tAPI URL for the new Customer is: {res.Headers.Location}");
        }
    }
}
