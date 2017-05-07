using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            NetworkComms.AppendGlobalIncomingPacketHandler<string>("Wiadomosc", writeMSG);
            Connection.StartListening(ConnectionType.TCP, new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0));

            //Wyswietlenie nasluchiwanych adresow
            Console.WriteLine("Nasluchiwane adresy:");
            foreach (System.Net.IPEndPoint localEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
            {
                Console.WriteLine("{0}:{1}", localEndPoint.Address, localEndPoint.Port);
                }
            Console.WriteLine("Nacisnij dowolny klawisz, aby wyjsc");
            Console.ReadKey(true);
            NetworkComms.Shutdown();
        }
        private static void writeMSG(PacketHeader header, Connection connection, string message)
        {
            Console.WriteLine(connection.ToString()+"Nowa wiadomosc: " + message );
        }
    }
}