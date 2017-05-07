using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkCommsDotNet;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {  
            Console.WriteLine("Wpisz ip w formacie 192.168.0.1:10000");
            string serverInfo = Console.ReadLine();
            string serverIP = serverInfo.Split(':').First();
            int serverPort = int.Parse(serverInfo.Split(':').Last());       
            while (true)
            {
               //wiadomosc
                string messageToSend = Console.ReadLine();
                Console.WriteLine("Wiadomosc:" + messageToSend);
                NetworkComms.SendObject("Wiadomosc", serverIP, serverPort, messageToSend);
                Console.WriteLine("q- zeby wyjsc, jakikolwiek inny nowa wiadomosc");
                if (Console.ReadKey(true).Key == ConsoleKey.Q) break;             
            }
            NetworkComms.Shutdown();
        }
    }
}