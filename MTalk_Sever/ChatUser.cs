using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MTalk_Sever
{
    class ChatUser
    {
        public string Name;
        public TcpClient Client;
        public LinkedList<string> sendMessageTask;
    }
}
