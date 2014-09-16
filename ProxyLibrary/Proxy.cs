using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProxyLibrary
{
    public class Proxy
    {
        private TcpListener _tcpListener = null;
        int _port = 9999;
        private IPAddress _localAddress = IPAddress.Parse("127.0.0.1");

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        public IPAddress IPAddress
        {
            get { return _localAddress }
            set { _localAddress = value; }
        }

        public Proxy()
        {
            _tcpListener = new TcpListener(_localAddress, _port);
        }

        public Proxy(int port, IPAddress address)
        {
            _port = port;
            _localAddress = address;
            _tcpListener = new TcpListener(_localAddress, _port);
        }

        public Proxy(int port)
        {
            _port = port;
            _tcpListener = new TcpListener(IPAddress.Any, port);
        }

        public void StartServer()
        {
            _tcpListener.Start();
        }

        public void AcceptConnection(Connection conn)
        {
            
        }

        public Socket GetSocket()
        {
            if (_tcpListener != null)
                return _tcpListener.AcceptSocket();
            return null;
        }

    }
}
