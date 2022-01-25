using System.Net;
using System.Text;

namespace Server
{
    class HttpServer{
        private HttpListener listener;
        private string Server;
        public HttpServer(string prifix){
            listener = new HttpListener();
            listener.Prefixes.Add(prifix);
            Server = prifix;
        }
        
        public async Task Start(){
            listener.Start();
            Console.WriteLine($"Server is running {Server}");
            do {
                var context = await listener.GetContextAsync();
                Console.WriteLine("Somebody connected to server at " + DateTime.Now.ToString());
                var response = context.Response;
                response.Headers.Add("content-type", "text/html");
                var outputStream = response.OutputStream;

                var html = "<h1>Hello World</h1>";
                var bytes = Encoding.UTF8.GetBytes(html);
                await outputStream.WriteAsync(bytes, 0, bytes.Length);

                outputStream.Close();
            } while(listener.IsListening);
        }
    }
}