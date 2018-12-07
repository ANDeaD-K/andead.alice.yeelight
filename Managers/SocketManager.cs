using System.Net;
using System.Net.Sockets;
using System.Text;

namespace andead.alice.yeelight.Managers
{
    public static class SocketManager
    {
        public static void SendData(string address, int port, string data)
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);

                data += "\r\n";
                byte[] rawData = Encoding.ASCII.GetBytes(data);
                socket.Send(rawData);

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch { }
        }
    }
}