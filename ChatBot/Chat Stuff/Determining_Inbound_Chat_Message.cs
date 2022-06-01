using ChatBot.Configs;
using ChatBot.Utils.IRC;

namespace ChatBot.Chat_Stuff {
    public static class Determining_Inbound_Chat_Message {
        internal static void Inbound_Chat_Message(IrcClient irc, BotSettings bot_res) {
            // Read any message from the chat room
            string message = irc.ReadMessage();

            if (message.Contains("PRIVMSG")) {
                // Messages from the users will look something like this (without quotes):
                // Format: ":[user]![user]@[user].tmi.twitch.tv PRIVMSG #[channel] :[message]"

                // Modify message to only retrieve user and message
                int intIndexParseSign = message.IndexOf('!');
                string userName = message.Substring(1, intIndexParseSign - 1); // parse username from specific section (without quotes)
                                                                               // Format: ":[user]!"
                                                                               // Get user's message
                intIndexParseSign = message.IndexOf(" :");
                message = message.Substring(intIndexParseSign + 2);

                if (message.Contains("!")) {
                    Chat_Bot_Command.Bot_Command(userName, message, irc, bot_res);
                } else {
                    Chat_Bot_Chat_Message.Bot_Chat_Message(userName, message, irc, bot_res);
                }
            }
        }
    }
}
