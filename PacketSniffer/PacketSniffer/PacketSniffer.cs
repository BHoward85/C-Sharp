using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacketDotNet;
using System.Net;
using SharpPcap;
using System.IO;
using System.Windows.Forms;

namespace PacketSniffer
{
    class PacketSniffer : ISniff
    {
        private bool promiscuous;
        private bool writeToFile;
        private bool running;
        private StreamWriter outputFile;
        private List<String> filterList;
        private MainWindow MW;
        private ICaptureDevice device;
        private string[] list;
        private int n;

        public PacketSniffer(MainWindow Win, bool prom, bool wf, string file = "Null", params string[] args)
        {
            MW = Win;
            promiscuous = prom;
            writeToFile = wf;
            n = 1;

            if (writeToFile == true)
            {
                if (file != "Null" && !File.Exists(file))
                    outputFile = File.CreateText(file);
                else if (file != "Null" && File.Exists(file))
                    outputFile = File.AppendText(file);
                else
                    outputFile = File.CreateText("log.txt");
            }

            if (args.Length > 0)
                filterList = args.ToList<String>();
            else
                filterList = new List<string>();
        }

        public string[] List
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
            }
        }

        public bool State
        {
            get
            {
                return running;
            }
        }

        public void Run()
        {
            if (running == false)
            {
                running = true;
                Sniff();
            }
        }

        public void Stop()
        {
            if (running == true)
            {
                running = false;
                if(outputFile != null)
                    outputFile.Close();

                try
                {
                    device.StopCapture();
                    device.Close();
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                }
            }
        }

        /// <summary>
        /// Sniffs for Packets based on setting
        /// </summary>
        private void Sniff()
        {
            CaptureDeviceList devices = CaptureDeviceList.Instance;
            List<string> str = new List<string>();

            if (devices.Count < 1)
            {
                MessageBox.Show("No devices were found on this machine");
                running = false;
                return;
            }

            device = devices[0];

            if (promiscuous == true)
                device.Open(DeviceMode.Promiscuous);
            else
                device.Open(DeviceMode.Normal);

            if (writeToFile == true && outputFile != null)
            {
                //                          0 |                          1 |      2 |      3 |          4 |                                       5 |                                       6 |                                       7 |                                       8 |   9
                outputFile.WriteLine("No.     | Time                       | NetPtc | Tran P | App Portoc | Source IP                               | Source Port                             | Destation IP                            | Destation Port                          | Length");
                //                    nnnnnnn | yyyy:MM:dd - HH:mm:ss:ffff | AAAAAA | BBBBBB | CCCCCCCCCC | nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn | nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn | nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn | nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn | nnnnnn
            }

            device.OnPacketArrival += new SharpPcap.PacketArrivalEventHandler(device_OnPacketArrival);
            device.StartCapture();
        }

        private void device_OnPacketArrival(object sender, CaptureEventArgs p)
        {
            RawCapture pack = p.Packet;
            int z = 0;
            byte[] type = new byte[] { pack.Data[12], pack.Data[13] };

            z = pack.Data.Length;

            int packetType = (type[0] * 256) + type[1];
            FindPacketType(pack, packetType, z);
        }

        /// <summary>
        /// This finds the Network Layer Protocol Type
        /// </summary>
        /// <param name="pack"> Ethernet Packet that was captured </param>
        /// <param name="packetType"> Packet Type </param>
        /// <param name="z"> Length of the Packet in number of bytes </param>
        private void FindPacketType(RawCapture pack, int packetType, int z)
        {
            string type = "";

            switch(packetType)
            {
                case 24:
                    type = "CGMP";
                    break;
                case 50:
                    type = "STP";
                    break;
                case 457:
                    type = "CDP";
                    break;
                case 2048:
                    type = "IPv4";
                    break;
                case 2054:
                    type = "ARP";
                    break;
                case 34525:
                    type = "IPv6";
                    break;
                case 36864:
                    type = "ECTP";
                    break;
                default:
                    type = "#" + packetType.ToString();
                    break;
            }

            if (type == "IPv4")
                GetIPv4PacketInfo(pack, type, z);
            else if (type == "IPv6")
                GetIPv6PacketInfo(pack, type, z);
            else if (type == "ARP")
                GetARPPacketInfo(pack, type, z);
            else if (type == "ECTP")
                GetLoopPacketInfo(pack, type, z);
            else
                GetDefaultInfo(pack, type, z);
        }
        
        /// <summary>
        /// This gets the Loop pacekets
        /// </summary>
        /// <param name="pack"> the Packet </param>
        /// <param name="type"> protocol </param>
        /// <param name="z"> packet length </param>

        private void GetLoopPacketInfo(RawCapture pack, string type, int z)
        {
            string[] list;
            string protocol = type;
            string destMAC;
            string sourceMAC;

            destMAC = string.Format("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}", pack.Data[0], pack.Data[1], pack.Data[2], pack.Data[3], pack.Data[4], pack.Data[5]);
            sourceMAC = string.Format("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}", pack.Data[6], pack.Data[7], pack.Data[8], pack.Data[9], pack.Data[10], pack.Data[11]);

            list = new string[] { protocol, "Loop", "Loop", sourceMAC, "~", destMAC, "~", z.ToString() };

            MW.UpdataDataGrid(list);

            if (writeToFile == true)
            {
                outputFile.WriteLine("{0,7} | {1,24} | {2,6} | {3,6} | {4,10} | {5,39} | {6,39} | {7,39} | {8,39} | {9,6}"
                                    , n++, DateTime.Now.ToString("yyyy:MM:dd-HH:mm:ss.ffff"), list[0], list[1], list[2]
                                    , list[3], list[4], list[5], list[6], list[7]);

                outputFile.Flush();
            }
        }
        
        /// <summary>
        /// This gets IPv4 packet info
        /// </summary>
        /// <param name="pack"> the Packet </param>
        /// <param name="type"> protocol </param>
        /// <param name="z"> packet length </param>
        private void GetIPv4PacketInfo(RawCapture pack, string type, int z)
        {
            string[] list;
            string protocol;
            string subProtocol;
            string destIP;
            string sourceIP;
            string destPort;
            string sourcePort;
            byte protocolType = pack.Data[23];

            protocol = ProtocolIPv4(protocolType);

            destIP = new IPAddress(new byte[] {pack.Data[30], pack.Data[31], pack.Data[32], pack.Data[33]}).ToString();
            sourceIP = new IPAddress(new byte[] {pack.Data[26], pack.Data[27], pack.Data[28], pack.Data[29]}).ToString();
            destPort = string.Format("{0}", (pack.Data[36] * 256) + pack.Data[37]);
            sourcePort = string.Format("{0}", (pack.Data[34] * 256) + pack.Data[35]);

            subProtocol = GetActProtocol(protocol, sourcePort, destPort);

            list = new string[] { type, protocol, subProtocol, sourceIP, sourcePort, destIP, destPort, z.ToString() };

            if (filterList.Count == 0 || (filterList.Contains(type) == true || filterList.Contains(protocol) == true || filterList.Contains(subProtocol) == true))
            {
                MW.UpdataDataGrid(list);

                if(writeToFile == true)
                {
                    outputFile.WriteLine("{0,7} | {1,26} | {2,6} | {3,6} | {4,10} | {5,39} | {6,39} | {7,39} | {8,39} | {9,6}"
                                        , n++, DateTime.Now.ToString("yyyy:MM:dd - HH:mm:ss.ffff"), list[0], list[1], list[2]
                                        , list[3], list[4], list[5], list[6], list[7]);

                    outputFile.Flush();
                }
            }
        }

        /// <summary>
        /// This gets IPv6 packet info
        /// </summary>
        /// <param name="pack"> the Packet </param>
        /// <param name="type"> protocol </param>
        /// <param name="z"> packet length </param>
        private void GetIPv6PacketInfo(RawCapture pack, string type, int z)
        {
            string[] list;
            string protocol;
            string subProtocol;
            string destIP;
            string sourceIP;
            string destPort;
            string sourcePort;
            byte protocolType = pack.Data[20];

            protocol = ProtocolIPv6(protocolType);

            destIP = new IPAddress(new byte[] { pack.Data[38], pack.Data[39], pack.Data[40], pack.Data[41], pack.Data[42], pack.Data[43], pack.Data[44], pack.Data[45], pack.Data[46], pack.Data[47], pack.Data[48], pack.Data[49], pack.Data[50], pack.Data[51], pack.Data[52], pack.Data[53] }).ToString();
            sourceIP = new IPAddress(new byte[] { pack.Data[22], pack.Data[23], pack.Data[24], pack.Data[25], pack.Data[26], pack.Data[27], pack.Data[28], pack.Data[29], pack.Data[30], pack.Data[31], pack.Data[32], pack.Data[33], pack.Data[34], pack.Data[35], pack.Data[36], pack.Data[37] }).ToString();
            destPort = string.Format("{0}", (pack.Data[56] * 256) + pack.Data[57]);
            sourcePort = string.Format("{0}", (pack.Data[54] * 256) + pack.Data[55]);

            subProtocol = GetActProtocol(protocol, sourcePort, destPort);

            list = new string[] { type, protocol, subProtocol, sourceIP, sourcePort, destIP, destPort, z.ToString() };

            if (filterList.Count == 0 || (filterList.Contains(type) == true || filterList.Contains(protocol) == true || filterList.Contains(subProtocol) == true))
            {
                MW.UpdataDataGrid(list);

                if (writeToFile == true)
                {
                    outputFile.WriteLine("{0,7} | {1,24} | {2,6} | {3,6} | {4,10} | {5,39} | {6,39} | {7,39} | {8,39} | {9,6}"
                                        , n++, DateTime.Now.ToString("yyyy:MM:dd-HH:mm:ss.ffff"), list[0], list[1], list[2]
                                        , list[3], list[4], list[5], list[6], list[7]);

                    outputFile.Flush();
                }
            }
        }

        /// <summary>
        /// This gets ARP packet info
        /// </summary>
        /// <param name="pack"> the Packet </param>
        /// <param name="type"> protocol </param>
        /// <param name="z"> packet length </param>
        private void GetARPPacketInfo(RawCapture pack, string type, int z)
        {
            string[] list;
            string protocol = type;
            string destMAC;
            string sourceMAC;
            string destIP;
            string sourceIP;

            sourceMAC = string.Format("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}", pack.Data[22], pack.Data[23], pack.Data[24], pack.Data[25], pack.Data[26], pack.Data[27]);
            destMAC = string.Format("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}", pack.Data[32], pack.Data[33], pack.Data[34], pack.Data[35], pack.Data[36], pack.Data[37]);
            destIP = new IPAddress(new byte[] { pack.Data[38], pack.Data[39], pack.Data[40], pack.Data[41] }).ToString();
            sourceIP = new IPAddress(new byte[] { pack.Data[28], pack.Data[29], pack.Data[30], pack.Data[31] }).ToString();

            if (destMAC == "00:00:00:00:00:00")
            {
                destMAC = "Broadcast";
            }

            list = new string[] { type, protocol, protocol, sourceMAC, sourceIP, destMAC, destIP, z.ToString() };

            if (filterList.Count == 0 || (filterList.Contains(type) == true || filterList.Contains(protocol) == true))
            {
                MW.UpdataDataGrid(list);

                if (writeToFile == true)
                {
                    outputFile.WriteLine("{0,7} | {1,24} | {2,6} | {3,6} | {4,10} | {5,39} | {6,39} | {7,39} | {8,39} | {9,6}"
                                        , n++, DateTime.Now.ToString("yyyy:MM:dd-HH:mm:ss.ffff"), list[0], list[1], list[2]
                                        , list[3], list[4], list[5], list[6], list[7]);

                    outputFile.Flush();
                }
            }
        }

        private void GetDefaultInfo(RawCapture pack, string type, int z)
        {
            string[] list;
            string protocol = type;
            string destMAC;
            string sourceMAC;
            
            destMAC = string.Format("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}", pack.Data[0], pack.Data[1], pack.Data[2], pack.Data[3], pack.Data[4], pack.Data[5]);
            sourceMAC = string.Format("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}", pack.Data[6], pack.Data[7], pack.Data[8], pack.Data[9], pack.Data[10], pack.Data[11]);

            list = new string[] { protocol, protocol, protocol, sourceMAC, "~", destMAC, "~", z.ToString() };

            MW.UpdataDataGrid(list);
            
            if (writeToFile == true)
            {
                outputFile.WriteLine("{0,7} | {1,24} | {2,6} | {3,6} | {4,10} | {5,39} | {6,39} | {7,39} | {8,39} | {9,6}"
                                    , n++, DateTime.Now.ToString("yyyy:MM:dd-HH:mm:ss.ffff"), list[0], list[1], list[2]
                                    , list[3], list[4], list[5], list[6], list[7]);

                outputFile.Flush();
            }
        }

        /// <summary>
        /// This gets IPv4 protocol info
        /// </summary>
        /// <param name="protocolType"> protocol number </param>
        private string ProtocolIPv4(byte protocolType)
        {
            switch (protocolType)
            {
                case 1:
                    return "ICMP";
                case 2:
                    return "IGMP";
                case 6:
                    return "TCP";
                case 17:
                    return "UDP";
                case 41:
                    return "ENCAP";
                case 88:
                    return "EIGRP";
                case 89:
                    return "OSPF";
                case 103:
                    return "PIMv2";
                case 132:
                    return "SCTP";
                default:
                    return "#" + protocolType.ToString();
            }
        }

        /// <summary>
        /// This gets IPv6 protocol info
        /// </summary>
        /// <param name="protocolType"> protocol number </param>
        private string ProtocolIPv6(byte protocolType)
        {
            switch (protocolType)
            {
                case 0:
                    return "HOPOPT";
                case 2:
                    return "IGMP";
                case 6:
                    return "TCP";
                case 17:
                    return "UDP";
                case 41:
                    return "ENCAP";
                case 58:
                    return "ICMPv6";
                case 89:
                    return "OSPF";
                case 132:
                    return "SCTP";
                default:
                    return "#" + protocolType.ToString();
            }
        }

        /// <summary>
        /// This gets App protocol info
        /// </summary>
        /// <param name="orgProto"> the Tranfer Protocol </param>
        /// <param name="sourcePort"> source port number </param>
        /// <param name="destPort"> dest port number </param>
        /// <returns> App layer protocol </returns>
        private string GetActProtocol(string orgProto, string sourcePort, string destPort)
        {
            if (sourcePort == "20" || destPort == "20")
                return "FTP-DT";
            else if (sourcePort == "21" || destPort == "21")
                return "FTP-C";
            else if (sourcePort == "22" || destPort == "22")
                return "SSH";
            else if (sourcePort == "23" || destPort == "23")
                return "Telnet";
            else if (sourcePort == "25" || destPort == "25")
                return "SMTP";
            else if (sourcePort == "53" || destPort == "53")
                return "DNS";
            else if (sourcePort == "67" || destPort == "68" || sourcePort == "68" || destPort == "67")
                return "DHCP";
            else if (sourcePort == "80" || destPort == "80")
                return "HTTP";
            else if (sourcePort == "137" || destPort == "137")
                return "NBNS";
            else if (sourcePort == "138" || destPort == "138")
                return "BROWSER";
            else if (sourcePort == "179" || destPort == "179")
                return "BGP";
            else if (sourcePort == "443" || destPort == "443")
                return "Secure TCP";
            else if (sourcePort == "445" || destPort == "445")
                return "SMB";
            else if (sourcePort == "546" || destPort == "547" || sourcePort == "547" || destPort == "546")
                return "DHCPv6";
            else if (sourcePort == "554" || destPort == "554")
                return "RTSP";
            else if (sourcePort == "587" || destPort == "587")
                return "SMTP";
            else if (sourcePort == "1900" || destPort == "1900")
                return "SSDP";
            else if (sourcePort == "2083" || destPort == "2083")
                return "RADSEC";
            else if (sourcePort == "5004" || destPort == "5004")
                return "RTP";
            else if (sourcePort == "5005" || destPort == "5005")
                return "RTCP";
            else if (sourcePort == "5353" || destPort == "5353")
                return "mDNS";
            else if (sourcePort == "5355" || destPort == "5355")
                return "LLMNR";
            else
                return orgProto;
        }
    }
}