using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace PacketSniffer
{
    class Sniffer : ISniff
    {
        private bool promiscuous;
        private bool writeToFile;
        private bool running;
        private StreamWriter outputFile;
        private List<String> filterList;
        private MainWindow MW;
        private Socket sock;

        public Sniffer(MainWindow Win, bool prom, bool wf, string file = "Null", params string[] args)
        {
            MW = Win;
            promiscuous = prom;
            writeToFile = wf;

            if (writeToFile == true)
            {
                if (file != "Null" && File.Exists(file))
                    outputFile = File.CreateText(args[0]);
                else
                    outputFile = File.CreateText("log.txt");
            }

            if (args.Length > 0)
            {
                filterList = args.ToList<String>();
            }
        }

        public bool State
        {
            get { return false; }
        }

        public string[] List
        {
            get { return null; }
            set {  }
        }

        public void Run()
        {
            var IPv4Addr = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(al => al.AddressFamily == AddressFamily.InterNetwork).AsEnumerable();

            running = true;

            foreach (IPAddress IPs in IPv4Addr)
            {
                Sniff(IPs);
            }
        }

        public void Stop()
        {
            running = false;
        }

        private void Sniff(IPAddress IPs)
        {
            byte[] bout = new byte[4] { 0, 0, 0, 0 };
            byte[] bin = new byte[4] { 1, 0, 0, 0 };

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Unspecified);
            sock.Bind(new IPEndPoint(IPs, 0));
            sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);
            sock.IOControl(IOControlCode.ReceiveAll, bin, bout);

            byte[] buffer = new byte[24];

            Action<IAsyncResult> OnReceive = null;

            OnReceive = (ar) =>
            {
                string[] list = new string[] {ToProtocolString(buffer.Skip(9).First())
                                                , new IPAddress(BitConverter.ToUInt32(buffer, 12)).ToString()
                                                , ((ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer, 20))).ToString()
                                                , new IPAddress(BitConverter.ToUInt32(buffer, 16)).ToString()
                                                , ((ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer, 22))).ToString()};

                if(running)
                    MW.UpdataDataGrid(list);

                buffer = new byte[24];
                sock.BeginReceive(buffer, 0, 24, SocketFlags.None, new AsyncCallback(OnReceive), null);
            };
            sock.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
        }

        public string ToProtocolString(byte b)
        {
            switch (b)
            {
                case 1: return "ICMP";
                case 6: return "TCP";
                case 17: return "UDP";
                default: return "#" + b.ToString();
            }
        }
    }
}
