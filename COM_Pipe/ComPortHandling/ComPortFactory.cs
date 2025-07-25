using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COM_Pipe.Configuration;

namespace COM_Pipe.ComPortHandling
{
    public class ComPortFactory
    {
        //Factory for creating IComPort for DI or mocking flexibility

       
        public IComPort Create(ComPortConfig configuration, Type type)
        {
            if (!typeof(IComPort).IsAssignableFrom(type))
                throw new ArgumentException("Type must implement IComPort", nameof(type));

            var constructor = type.GetConstructor([typeof(ComPortConfig)]) 
                ?? throw new ArgumentException("Type must have a constructor with ComPortConfig parameter", nameof(type));

            return (IComPort)constructor.Invoke([configuration]);

        }

    }
}
