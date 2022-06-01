using Newtonsoft.Json;
using System.IO;
using ChatBot.Configs;
using ChatBot.Utils;
using ChatBot.Utils.IRC;
using ChatBot.Chat_Stuff;

namespace ChatBot {
    public class ChatBot {
        public static void Connect() {
            ConfigFileChecker.ConfigFileGenerater();
            ConfigFileChecker.Config_FileChecker();

            #region File Stuff
            string CurrentPath = Directory.GetCurrentDirectory();
            var Bot_res = JsonConvert.DeserializeObject<BotSettings>(File.ReadAllText(Path.Combine(CurrentPath, "Config", "BotSettings.json")));
            #endregion

            // Initialize and connect to Twitch chat
            IrcClient irc = new IrcClient("irc.twitch.tv", 6667, Bot_res.BotName, Bot_res.BotToken, Bot_res.ChannelName);

            // Ping to the server to make sure this bot stays connected to the chat
            // Server will respond back to this bot with a PONG (without quotes):
            // Example: ":tmi.twitch.tv PONG tmi.twitch.tv :irc.twitch.tv"
            PingSender ping = new PingSender(irc);
            ping.Start();

            // Listen to the chat until program exits
            while (true) {
                Determining_Inbound_Chat_Message.Inbound_Chat_Message(irc, Bot_res);
            }

        }
    }
}
