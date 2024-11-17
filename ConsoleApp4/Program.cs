using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HTTPConnection_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string s = MyHttpConnectionAsync("http://www.google.com/").Result;
            //Console.WriteLine("Response " + s);
            string s = MyHttpConnectionSync("http://www.google.com/");
            Console.WriteLine("Response" + s);
        }

        static async Task<string> MyHttpConnectionAsync(string url)
        {
            string response = "";
            HttpClient MyHttpClient = new HttpClient();
            MyHttpClient.BaseAddress = new Uri(url);
            var httpresponse = await MyHttpClient.GetAsync(MyHttpClient.BaseAddress);
            Console.WriteLine(httpresponse.Content);
            Console.WriteLine(httpresponse.StatusCode);
            Console.WriteLine(httpresponse.Headers);
            Console.WriteLine(httpresponse.EnsureSuccessStatusCode());
            response = httpresponse.Headers + " " + httpresponse.Content;
            return response;
        }

        static string MyHttpConnectionSync(string url)
        {
            String response = "";
            WebClient MyWebClient = new WebClient();
            response = new StreamReader(MyWebClient.OpenRead(url)).ReadToEnd();
            return response;
        }
    }
}

