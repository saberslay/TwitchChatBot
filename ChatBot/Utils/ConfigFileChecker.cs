using ChatBot.Configs;
using Newtonsoft.Json;
using System.IO;
using Utils.Windows;

namespace ChatBot.Utils {
    public static class ConfigFileChecker {
        public static void ConfigFileGenerater() {
            string CurrentPath = Directory.GetCurrentDirectory();

            #region Bot Config
            BotSettings botSettings = new BotSettings() {
                BotName = "",
                BotToken = "https://twitchapps.com/tmi/",
                ChannelName = "The name of the channel",
            };
            string strResultJson = JsonConvert.SerializeObject(botSettings, Formatting.Indented);

            if (!Directory.Exists(Path.Combine(CurrentPath, "Config"))) {
                Directory.CreateDirectory(Path.Combine(CurrentPath, "Config"));
            }
            if (!File.Exists(Path.Combine(CurrentPath, "Config", "BotSettings.json"))) {
                File.WriteAllText(Path.Combine(CurrentPath, "Config", "BotSettings.json"), strResultJson);
                Forms.MessageBox_Error_OK("Twitch Chat Bot", "Please edit the BotSettings.json file");
            }
            #endregion



        }

        public static void Config_FileChecker() {
            string CurrentPath = Directory.GetCurrentDirectory();
            var _res = JsonConvert.DeserializeObject<BotSettings>(File.ReadAllText(Path.Combine(CurrentPath, "Config", "BotSettings.json")));

            if (_res.BotName == "") {
                Forms.MessageBox_Error_OK("Twitch Chat Bot Config Error", "Please enter a username for the bot");
            } else if (_res.BotToken == "" || !_res.BotToken.Contains("oauth:")) {
                Forms.MessageBox_Error_OK("Twitch Chat Bot Config Error", "Please enter the OAuth Token for the bot");
            } else if (_res.ChannelName == "") {
                Forms.MessageBox_Error_OK("Twitch Chat Bot Config Error", "Please enter a channel name for the bot");
            }
        }
    }
}
