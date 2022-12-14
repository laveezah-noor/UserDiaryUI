using System;
using System.Collections.Generic;
using System.Windows;
using utils;

namespace UserDiaryUI.Scripts
{
    public class ClientHandle
    {
        public static dynamic Welcome(Packet _packet)
        {
            string response = _packet.ReadString();
            int _myId = _packet.ReadInt();

            MessageBox.Show($"Message from server: {response}, id: {_myId}");
            //MessageBox.Show($"Message from server: {response}");
            Client.instance.myId = _myId;
            //Add Client Type Packet Which you want to send now
            ClientSend.WelcomeReceived();
            return new Dictionary<string, object>
            {{"Status", 200},
                {"Response", response },
                {"RequestId", (int)ClientPackets.welcomeReceived } 
            };
        }
        public static Dictionary<string, object> LoginReceived(Packet _packet)
        {
            string response = _packet.ReadString();
            int _myId = _packet.ReadInt();

            JMessage jdata = JMessage.Deserialize(response);
            MessageBox.Show(jdata.Value.ToString());
            Dictionary<string, object> res = jdata.Value.ToObject<Dictionary<string, object>>();

            MessageBox.Show(res["Status"].ToString());
            MessageBox.Show(res["Response"].ToString());
            UserDiary.User user = jdata.Value["Response"].ToObject<UserDiary.User>();
            MessageBox.Show(user.display());
            Console.WriteLine($"Message from server: {response}, id: {_myId}");
            //MessageBox.Show($"Message from server: {response}");
            Client.instance.myId = _myId;
            //ClientSend.WelcomeReceived();
            Dictionary<string, object> result = new();
            result.Add("Status", Convert.ToInt64(res["Status"]));
            result.Add("Response", user);
            result.Add("RequestId", (int)ClientPackets.login);
            return result;
        }

        public static dynamic RegisteredReceived(Packet _packet)
        {
            string response = _packet.ReadString();
            int _myId = _packet.ReadInt();

            Console.WriteLine($"Message from server: {response}, id: {_myId}");
            //MessageBox.Show($"Message from server: {response}");
            Client.instance.myId = _myId;
            //ClientSend.WelcomeReceived();

            //res.Add("RequestId", (int)ClientPackets.login);
            return null;
        }
    }
}
