using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PushStream
{
    class Program
    {

        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string url = "https://api.powerbi.com/beta/8ac76c91-e7f1-41ff-a89c-3553b2da2c17/datasets/18f95224-4134-468b-8f68-bd7d488ab948/rows?key=5FxgVG0gbPMhQEHKad%2FshjyONWIqrkcEGjAurbud8cy3DtdlOTv6Hq9xKEM3FT4JxXiLXfRm9hNxezRlKzq13w%3D%3D";
            Console.WriteLine("Pushing data to power BI");
            Random rnd = new Random();
            
            int i = 0;
            try
            {
                while (true)
                {
                    i++;
                    //Toll data = new Toll() { TollId = rnd.Next(), LicensePlate = new Random().Next().ToString(), EntryTime = DateTime.Now.AddDays(i), RegistrationId = new Random().Next() };
                    StockPrice data = new StockPrice() { stockrate = new Random().Next(),time=DateTime.Now };
                    var json = JsonConvert.SerializeObject(data);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    client.PostAsync(url, stringContent);
                    Thread.Sleep(2000);
                }
            }
            catch
            {
                Console.WriteLine("Stopped");
            }
        }
    }
    class Toll
    {
        public int TollId { get; set; }
        public string LicensePlate { get; set; }
        public DateTime EntryTime { get; set; }

        public int RegistrationId { get; set; }
    }

    class StockPrice
    {
        public int stockrate { get; set; }
        public DateTime time { get; set; }
    }
}
