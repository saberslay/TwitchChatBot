using ChatBot.Configs;
using ChatBot.Utils.IRC;

namespace ChatBot.Chat_Stuff {
    static class Chat_Bot_Command {
        internal static void Bot_Command(string userName, string message, IrcClient irc, BotSettings bot_res) {
            if (userName == bot_res.ChannelName) {
                switch (message) {
                    case "reload":
                        irc.SendPublicChatMessage($"hi there {userName} and welcome to {bot_res.ChannelName} Channel");
                        break;

                    default:
                        break;
                }
            } else {
                irc.SendPublicChatMessage($"{userName} you are not the boss of me only {bot_res.ChannelName} can tell me what to do");
            }
        }
    }
}
