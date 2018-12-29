using System;
using System.Net.Sockets;

namespace ExampleWebServer
{
    class Program
    {   
        static void Main(string[] args)
        {
            string url = "";
                                    
            try
            {              
                if (url != null)
                {
                    //create server with given port
                    SimpleHTTPServer myServer = new SimpleHTTPServer(url, 8081);
                    Console.WriteLine("Server is running on this port: " + myServer.Port.ToString());
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
