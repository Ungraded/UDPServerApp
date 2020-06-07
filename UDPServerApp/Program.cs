using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        IPAddress broadcast = IPAddress.Parse("127.0.0.1");

        //byte[] sendbuf = Encoding.UTF8.GetBytes(args[0]);
        byte[] sendbuf = Encoding.Default.GetBytes(DateTime.Now.ToString());
        IPEndPoint ep = new IPEndPoint(broadcast, 11000);

        do
        {
            sendbuf = Encoding.Default.GetBytes(DateTime.Now.ToString());
            s.SendTo(sendbuf, ep);

            Console.WriteLine("Message sent to the broadcast address");

            int milliseconds = 5000;
            Thread.Sleep(milliseconds);
        } while (true);

    }
}