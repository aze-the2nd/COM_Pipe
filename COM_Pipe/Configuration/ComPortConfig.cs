using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Text.Json;

namespace COM_Pipe.Configuration
{
    // Configuration-Class that's holding connection-parameters
    public class ComPortConfig
    {
        /*
         private readonly ComPortConfig config = JsonSerializer.Deserialize<ComPortConfig>(File.ReadAllText("ComPortConfig.json"));
        */
       
        public Port[] Port { get; set; }
    }

    public class Port
    {
        public string PortName { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public string Parity { get; set; }
        public string StopBits { get; set; }
    }
}
