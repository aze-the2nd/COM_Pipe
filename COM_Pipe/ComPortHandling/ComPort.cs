using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COM_Pipe.Configuration;
using System.IO.Ports;

namespace COM_Pipe.ComPortHandling
{
    public class ComPort(ComPortConfig configuration) : IComPort
    {   // holds implementation of the Comport via SerialPort
        private readonly SerialPort _port = new(
            configuration.Port[0].PortName, 
            configuration.Port[0].BaudRate,
            Enum.Parse<Parity>(configuration.Port[0].Parity),
            configuration.Port[0].DataBits, 
            Enum.Parse<StopBits>(configuration.Port[0].StopBits));

        public string PortName => _port.PortName;


        public event EventHandler<byte[]> DataReceived;

        private void OnDataReceived(object? sender, SerialDataReceivedEventArgs e)
        {
            int count = _port.BytesToRead;
            byte[] buffer = new byte[count];    
            _port.Read(buffer, 0, count);
            DataReceived?.Invoke(this, buffer);
        }

        public bool Open() 
        { 
            _port.DataReceived += OnDataReceived;
            _port.Open();

            return true;
        }

        public bool Close()
        {
            _port.Close();
            _port.DataReceived -= OnDataReceived;
            return true;
        }



        public bool Write(byte[] data, int offset, int count)
        {
            _port.Write(data, offset, count);
            return true;
        }
        public bool Read(byte[] data, int offset, int count)
        {
            _port.Write(data, offset, count);
            return false;
        }


        public void Dispose()
        {
            if (_port != null)
            {
                _port.DataReceived -= OnDataReceived;
                if (_port.IsOpen)
                {
                    _port.Close();
                }

                _port.Dispose();
            }
        }
    }
}
