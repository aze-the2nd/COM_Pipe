using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM_Pipe.ComPortHandling
{
    internal interface IComPort
    {
        // abstraction of ComPort

        bool Write(byte[] buffer, int offset, int count);
        bool Read(byte[] buffer, int offset, int count);
        bool Open();
        bool Close();
    }
}
