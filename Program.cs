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
                    int rnd1 = rnd.Next(1, 1049);
                    var rndpng = "C:/Users/Tawa/Desktop/NoShowBot/Pictures/" + rnd1 + ".jpg";
                    await e.Channel.SendFile(rndpng);
                });
            cService.CreateCommand("cosplay")
                .Description("Posts a random picture from the NoShowLewdCollectionTM")
                .Do(async (e) =>
                {
                    Random rnd = new Random();
                    int rnd1 = rnd.Next(0, 45);
                    var rndpng = "C:/Users/Tawa/Desktop/NoShowBot/Cosplay/" + rnd1 + ".png";
                    await e.Channel.SendFile(rndpng);
                });
            cService.CreateCommand("gif")
                .Description("Posts a random picture from the NoShowLewdGifCollectionTM - Currently broken. You can try your luck, but dont spam.")
                .Do(async (e) =>
                {
                    Random rnd = new Random();
                    int rnd1 = rnd.Next(1, 53);
                    var rndgif = "C:/Users/Tawa/Desktop/NoShowBot/gifs/" + rnd1 + ".gif";
                    await e.Channel.SendFile(rndgif);
                });
            cService.CreateCommand("picdump")
                .Description("Only needs to be used when the bot was restarted. Starts the NSFW Picture Dumping Queue in the channel its used in.")
                .Do(async (e) =>
                {
                    while(true)
                    {
                        Random rnd = new Random();
                        int rnd1 = rnd.Next(1, 1049);
                        var rndjpg1 = "C:/Users/Tawa/Desktop/NoShowBot/Pictures/" + rnd1 + ".jpg";
                        await e.Channel.SendMessage(rnd1 + ".jpg");
                        await e.Channel.SendFile(rndjpg1);
                        int rnd2 = rnd.Next(1, 1049);
                        while (rnd2 == rnd1)
                        {
                            rnd2 = rnd.Next(1, 1049);
                        }
                        var rndjpg2 = "C:/Users/Tawa/Desktop/NoShowBot/Pictures/" + rnd2 + ".jpg";
                        await e.Channel.SendMessage(rnd2 + ".jpg");
                        await e.Channel.SendFile(rndjpg2);
                        int rnd3 = rnd.Next(1, 1049);
                        while (rnd3 == rnd1 || rnd3 == rnd2)
                        {
                            rnd3 = rnd.Next(1, 1049);
                        }
                        var rndjpg3 = "C:/Users/Tawa/Desktop/NoShowBot/Pictures/" + rnd3 + ".jpg";
                        await e.Channel.SendMessage(rnd3 + ".jpg");
                        await e.Channel.SendFile(rndjpg3);
                        int rnd4= rnd.Next(1, 1049);
                        while (rnd4 == rnd1 || rnd4 == rnd2 || rnd4 == rnd3)
                        {
                            rnd4 = rnd.Next(1, 1049);
                        }
                        var rndjpg4 = "C:/Users/Tawa/Desktop/NoShowBot/Pictures/" + rnd4 + ".jpg";
                        await e.Channel.SendMessage(rnd4 + ".jpg");
                        await e.Channel.SendFile(rndjpg4);
                        int rnd5 = rnd.Next(1, 1049);
                        while (rnd5 == rnd1 || rnd5 == rnd2 || rnd5 == rnd3 || rnd5 == rnd4)
                        {
                            rnd5 = rnd.Next(1, 1049);
                        }
                        var rndjpg5 = "C:/Users/Tawa/Desktop/NoShowBot/Pictures/" + rnd5 + ".jpg";
                        await e.Channel.SendMessage(rnd5 + ".jpg");
                        await e.Channel.SendFile(rndjpg5);
                        Console.WriteLine("[INFO] [SERVICE] Picture sent ------------------------------------");
                        Thread.Sleep(3600000);
                    }
                });
        }
        public void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine($"[{e.Severity}] [{e.Source}] {e.Message}");
        }
    }
}
