using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM_Pipe.Messaging
{
    internal interface IMessageParser
    {
        // Abstraction interface to map/parse data to actual value
    }
}
/*
 @startuml ClassDiagramExample
class App.AppConfig
class App.ComPortApp
class App.DependencyConfig

class ComPortHandling.ComPort
class ComPortHandling.ComPortFactory
class ComPortHandling.ComPortConfiguration
interface ComPortHandling.IComPort

interface Messaging.IMessageHandler
class Messaging.MessageHandler


 @enduml

 */