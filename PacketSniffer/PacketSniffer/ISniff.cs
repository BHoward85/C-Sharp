using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketSniffer
{
    interface ISniff
    {
        /// <summary>
        /// Runs the Packet Sniffer on the main eth0 port
        /// </summary>
        void Run();

        /// <summary>
        /// Stops the Sniffer
        /// </summary>
        void Stop();
        
        /// <summary>
        /// Gets the Fliter List
        /// </summary>
        string[] List { get; set; }
        
        /// <summary>
        /// Gets the Running State of the Sniffer
        /// </summary>        
        bool State { get; }
    }
}