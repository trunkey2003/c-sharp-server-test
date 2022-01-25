using System.Net;
using System.Text;

namespace Server
{
    
    class Program
    {
        static async Task Main()
        {
           var server = new HttpServer("http://127.0.0.1:8080/");

           var connection = MySQL.SQL();
           
           connection.Open();
           Console.WriteLine(connection.State);
           connection.Close();

           await server.Start();
        }
    }
}