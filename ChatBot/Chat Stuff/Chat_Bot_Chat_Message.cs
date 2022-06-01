using ChatBot.Configs;
using ChatBot.Utils.IRC;

namespace ChatBot.Chat_Stuff {
    public static class Chat_Bot_Chat_Message {
        internal static void Bot_Chat_Message(string userName, string message, IrcClient irc, BotSettings bot_res) {
            switch (message)
            {
                case "hi":
                    irc.SendPublicChatMessage($"hi there {userName} and welcome to {bot_res.ChannelName} Channel");
                    break;

                default:
                    break;
            }
        }
    }
}
