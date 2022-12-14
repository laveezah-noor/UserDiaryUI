using System;
using System.Collections.Generic;
using System.Windows;
using utils;

namespace UserDiaryUI.Scripts
{
    public class ClientSend
    {
        private static void SendTCPData(Packet _packet)
        {
            _packet.WriteLength();
            Client.instance.tcp.SendData(_packet);
        }

        #region Packets
        public static void WelcomeReceived()
        {
            using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
            {
                Console.WriteLine($"My Id: {Client.instance.myId}");
                _packet.Write(Client.instance.myId);
                _packet.Write("HardCoded User");

                SendTCPData(_packet);
                MessageBox.Show("Welcome Received Packet Send!");
                Client.instance.tcp.requestFinished = true;
            }
        }
        #endregion

        public static void Login(Dictionary<string, string> req)
        {
            using (Packet _packet = new Packet((int)ClientPackets.login))
            {   
                _packet.Write(Client.instance.myId);

                utils.LoginRequest loginCredentials = new("noor", "noor");
                //utils.LoginRequest loginCredentials = new(req["username"], req["password"]);

                string data = JMessage.Serialize(JMessage.FromValue(loginCredentials));
MessageBox.Show(data);
                _packet.Write(data);

                SendTCPData(_packet);

                MessageBox.Show("Login Packet Send!");
            }
        }
        
        

        public static void Register(Dictionary<string, string> req)
        {
            using (Packet _packet = new Packet((int)ClientPackets.register))
            {
                _packet.Write(Client.instance.myId);
                utils.RegisterRequest registerCredentials = new("noor", "Noor", "noor", "", "");
                string data = JMessage.Serialize(JMessage.FromValue(registerCredentials));
                Console.WriteLine(data);
                _packet.Write(data);

                SendTCPData(_packet);
                Console.WriteLine("Register Packet Send!");
            }
        }
    }
}
