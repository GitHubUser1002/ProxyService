using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ProxyLibrary
{
    public class Connection
    {
        private Socket _socket = null;
        
        public Connection(Socket socket)
        {
            _socket = socket;
        }


    }
}
