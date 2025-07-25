using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace COM_Pipe.ComPortHandling
{
    public interface IComPort : IDisposable
    {
        // abstraction of ComPort-interaction
        string PortName { get; }
        //bool IsOpen { get; }
        bool Write(byte[] buffer, int offset, int count);
        bool Read(byte[] buffer, int offset, int count);
        event EventHandler<byte[]> DataReceived;
        bool Open();
        bool Close();
    }
}
