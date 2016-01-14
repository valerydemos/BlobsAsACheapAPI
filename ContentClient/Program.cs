using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ContentClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            var client = new WebClient();

            int i = 0;
            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    var content = client.DownloadString("https://vjdemostorage.blob.core.windows.net/cheapapi/data.json");

                    Console.WriteLine(i.ToString() + "\t\t" + content.Length.ToString());

                    System.Threading.Thread.Sleep(5);
                    i++;
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

    }
}
