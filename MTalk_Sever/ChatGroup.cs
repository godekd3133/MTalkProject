using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MTalk_Sever
{
    class ChatGroup
    {
        private LinkedList<ChatUser> users;

        public void Join(ChatUser newUser)
        {
            users.AddLast(newUser);
        }

        //유저를 받는다
        public async Task StartChatSever()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 7000);
            listener.Start();
            while (true)
            {
                // 비동기 Accept                
                TcpClient tc = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                var newUser = new ChatUser() { Client = tc, Name = "user" };
                Join(newUser);

                // 새 쓰레드에서 처리
                Task.Factory.StartNew(UserRecvProcess, newUser);
                Task.Factory.StartNew(UserSendProcess, newUser);
            }

        }
        private  void SendMessage(IEnumerable<ChatUser> users, string Message)
        {
            foreach(var each in users)
            {
                each.sendMessageTask.AddLast(Message);
            }
        }
        private void SendMessage(ChatUser user, string Message)
        {
            user.sendMessageTask.AddLast(Message);
        }


        private async void UserRecvProcess(object o)
        {
            ChatUser user = (ChatUser)o;
            TcpClient tc = user.Client;

            int MAX_SIZE = 1024;  // 가정
            NetworkStream stream = tc.GetStream();

            while (true)
            {
                // 비동기 수신            
                var buff = new byte[MAX_SIZE];
                var nbytes = await stream.ReadAsync(buff, 0, buff.Length).ConfigureAwait(false);

                if (nbytes > 0)
                {
                    string msg = Encoding.ASCII.GetString(buff, 0, nbytes);
                    //Console.WriteLine($"{msg} at {DateTime.Now}");
                }
                await Task.Delay(1);
            }
            stream.Close();
            tc.Close();
        }
        private async void UserSendProcess(object o)
        {
            ChatUser user = (ChatUser)o;
            TcpClient tc = user.Client;

            int MAX_SIZE = 1024;  // 가정
            NetworkStream stream = tc.GetStream();

            while (true)
            {
                // 비동기 수신            
                var buff = new byte[MAX_SIZE];
                if(user.sendMessageTask.Count>0)
                {
                    // 비동기 송신
                    Encoding.ASCII.GetBytes(user.sendMessageTask.First.Value);
                    await stream.WriteAsync(buff, 0, user.sendMessageTask.First.Value.Length).ConfigureAwait(false);
                    user.sendMessageTask.RemoveFirst();
                }


                await Task.Delay(1);
            }
            stream.Close();
            tc.Close();
        }

    }
}
