using System;
using Discord;
using Discord.Commands;
using System.Threading;

namespace DiscoBot
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        Random rand;

        string[] BDMM;

        public MyBot()
        {
            rand = new Random();

            BDMM = new string[]
            {
                "mem/xavier.jpg",
                "mem/xavier2.jpg",
                "mem/xavier4.png",
                "mem/xavier5.jpg",                
                "mem/jordao.jpg",
                "mem/jordao2.jpg",
                "mem/jordao3.jpg",
                "mem/jordao4.jpg",
                "mem/jordao5.jpg",
                "mem/jordao6.jpg",
                "mem/jordao7.jpg",
                "mem/jordao8.jpg",
                "mem/luan.jpg",
                "mem/luan2.jpg",
                "mem/nicolau.jpg",
                "mem/mujin.jpg"
            };

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            RegisterMemeCommand();

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("", TokenType.Bot);
            });
        }

        private void RegisterMemeCommand()
        {
            commands.CreateCommand("bdmm")
                .Do(async (e) =>
                {
                    int randomBDMMIndex = rand.Next(BDMM.Length);
                    string BDMMToPost = BDMM[randomBDMMIndex];
                    await e.Channel.SendFile(BDMMToPost);
                });

            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Olá");
                });

            commands.CreateCommand("help")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Comandos:")
                });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
