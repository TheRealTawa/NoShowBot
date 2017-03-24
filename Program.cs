using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;
using Discord;
using Discord.Commands;

namespace NoShowBot
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }

        private DiscordClient _client;

        public void Start()
        {
            _client = new DiscordClient(x =>
           {
               x.AppName = "NoShowBot";
               x.AppUrl = "twitch.tv/moonmoon_ow";
               x.LogLevel = LogSeverity.Debug;
               x.LogHandler = Log;
           });

            _client.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
                x.HelpMode = HelpMode.Public;
            });

            var token = "MjkwNTQ4OTIyOTQ5MTczMjU5.C6dD-A.sV7urSPLp5akyJB8_4PgUR86PbI";

            CreateCommands();
            _client.ExecuteAndWait(async () =>
            {
                await _client.Connect(token, TokenType.Bot);
            });
        }

        public void CreateCommands()
        {
            var cService = _client.GetService<CommandService>();

            cService.CreateCommand("ping")
                .Description("Makes the bot say pong. Wow.")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("pong");
                });
            cService.CreateCommand("nsfw")
               .Description("Posts a random picture from the NoShowLewdCollectionTM")
               .Do(async (e) =>
                {
                    Random rnd = new Random();
                    int rnd1 = rnd.Next(1, 1049); //Second value 1 higher than amount of pictures in the folder
                    var rndpng = "C:/Users/Tawa/Desktop/NoShowBot/Pictures/" + rnd1 + ".jpg";
                    await e.Channel.SendFile(rndpng);
                });
            cService.CreateCommand("hentai")
                .Description("Posts a random picture from the NoShowHentaiCollectionTM")
                .Do(async (e) =>
                {
                    Random rnd = new Random();
                    int rnd1 = rnd.Next(1, 50);
                    var rndpng = "C:/Users/Tawa/Desktop/NoShowBot/Hentai/" + rnd1 + ".jpg";
                    await e.Channel.SendFile(rndpng);
                });
            cService.CreateCommand("cosplay")
                .Description("Posts a random picture from the NoShowCosplayCollectionTM")
                .Do(async (e) =>
                {
                    Random rnd = new Random();
                    int rnd1 = rnd.Next(0, 45);
                    var rndpng = "C:/Users/Tawa/Desktop/NoShowBot/Cosplay/" + rnd1 + ".png";
                    await e.Channel.SendFile(rndpng);
                });

            cService.CreateCommand("picdump")
                .Description("DONT USE THIS YOU FUCKS")
                .Do(async (e) =>
                {
                    while (true)
                    {
                        Random rnd = new Random();
                        int rnd1 = rnd.Next(0, 1049);
                        int rnd2 = rnd.Next(0, 1049);
                        int rnd3 = rnd.Next(0, 1049);
                        int rnd4 = rnd.Next(0, 1049);
                        int rnd5 = rnd.Next(0, 1049);

                        while (rnd1 == rnd2 || rnd1 == rnd3 || rnd1 == rnd4 || rnd1 == rnd5)
                        {
                            rnd1 = rnd.Next(0, 1049);
                            rnd2 = rnd.Next(0, 1049);
                            rnd3 = rnd.Next(0, 1049);
                            rnd4 = rnd.Next(0, 1049);
                            rnd5 = rnd.Next(0, 1049);
                        }
                        //A while loop to keep the bot from posting the same picture twice in one go.
                        await e.Channel.SendMessage(rnd1 + "");
                        await e.Channel.SendFile("C:/Users/Tawa/Desktop/NoShowBot/Pictures/" + rnd1 + ".jpg");
                        Thread.Sleep(1000);
                        await e.Channel.SendMessage(rnd2 + "");
                        await e.Channel.SendFile("C:/Users/Tawa/Desktop/NoShowBot/Pictures/" + rnd2 + ".jpg");
                        Thread.Sleep(1000);
                        await e.Channel.SendMessage(rnd3 + "");
                        await e.Channel.SendFile("C:/Users/Tawa/Desktop/NoShowBot/Pictures/" + rnd3 + ".jpg");
                        Thread.Sleep(1000);
                        await e.Channel.SendMessage(rnd4 + "");
                        await e.Channel.SendFile("C:/Users/Tawa/Desktop/NoShowBot/Pictures/" + rnd4 + ".jpg");
                        Thread.Sleep(1000);
                        await e.Channel.SendMessage(rnd5 + "");
                        await e.Channel.SendFile("C:/Users/Tawa/Desktop/NoShowBot/Pictures/" + rnd5 + ".jpg");
                        Thread.Sleep(10800000);
                    }
                });
        }
        public void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine($"[{e.Severity}] [{e.Source}] {e.Message}");
        }
    }
}
