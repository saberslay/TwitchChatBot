using ChatBot.Configs;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ChatBot.Utils {
    public static class ConfigFileChecker {
        public static void ConfigFileGenerater()
        {
            string CurrentPath = Directory.GetCurrentDirectory();

            #region Bot Config
            BotSettings botSettings = new BotSettings()
            {
                BotName = "",
                BotToken = "https://twitchapps.com/tmi/",
                ChannelName = "The name of the channel",
                Debug = false,
                ChatterSpeek = false
            };
            string strResultJson = JsonConvert.SerializeObject(botSettings, Formatting.Indented);

            if (!Directory.Exists(Path.Combine(CurrentPath, "Config")))
            {
                Directory.CreateDirectory(Path.Combine(CurrentPath, "Config"));
            }
            if (!File.Exists(Path.Combine(CurrentPath, "Config", "BotSettings.json")))
            {
                File.WriteAllText(Path.Combine(CurrentPath, "Config", "BotSettings.json"), strResultJson);
                System.Windows.Forms.MessageBox.Show("Please edit the BotSettings.json file", "Twitch Chat Bot", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            #endregion


        }

        public static void Config_FileChecker()
        {
            string CurrentPath = Directory.GetCurrentDirectory();
            var _res = JsonConvert.DeserializeObject<BotSettings>(File.ReadAllText(Path.Combine(CurrentPath, "Config", "BotSettings.json")));

            if (_res.BotName == "")
            {
                System.Windows.Forms.MessageBox.Show("Please enter a username for the bot", "Twitch Chat Bot Config Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (_res.BotToken == "" || !_res.BotToken.Contains("oauth:"))
            {
                System.Windows.Forms.MessageBox.Show("Please enter the OAuth Token for the bot", "Twitch Chat Bot Config Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (_res.ChannelName == "")
            {
                System.Windows.Forms.MessageBox.Show("Please enter a channel name for the bot", "Twitch Chat Bot Config Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
    }
}
