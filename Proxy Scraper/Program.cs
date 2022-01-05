using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Net;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string logo = @"
██████╗ ██████╗  ██████╗ ██╗  ██╗██╗   ██╗    ███████╗ ██████╗██████╗  █████╗ ██████╗ ███████╗██████╗ 
██╔══██╗██╔══██╗██╔═══██╗╚██╗██╔╝╚██╗ ██╔╝    ██╔════╝██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔══██╗
██████╔╝██████╔╝██║   ██║ ╚███╔╝  ╚████╔╝     ███████╗██║     ██████╔╝███████║██████╔╝█████╗  ██████╔╝
██╔═══╝ ██╔══██╗██║   ██║ ██╔██╗   ╚██╔╝      ╚════██║██║     ██╔══██╗██╔══██║██╔═══╝ ██╔══╝  ██╔══██╗
██║     ██║  ██║╚██████╔╝██╔╝ ██╗   ██║       ███████║╚██████╗██║  ██║██║  ██║██║     ███████╗██║  ██║
╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝       ╚══════╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚══════╝╚═╝  ╚═╝
                                                                                                                                                                                   
╔═══════════════════════════╗
║github.com/russianheavy1337║
╚═══════════════════════════╝
";

            Console.Title = "Proxy Scraper by github.com/russianheavy1337 ";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(logo);

            Console.Write("Set Protocol (http/socks4/socks5): ");
            var protocol = Console.ReadLine();


            Console.Write("Set Country (Do 'all' to not set one): ");
            var country = Console.ReadLine();

            Console.Write("Set MS (50-10000): ");
            var ms = Console.ReadLine();

            var url = $"https://api.proxyscrape.com/v2/?request=getproxies&protocol={protocol}&timeout={ms}&country={country}";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            Console.Clear();
            Console.WriteLine(data);
            StreamWriter proxytxt = new StreamWriter("proxies.txt");
            proxytxt.WriteLine(data);
            proxytxt.Close();
            Console.WriteLine("Created proxies.txt");
            Console.ReadKey();


        }
    }
}