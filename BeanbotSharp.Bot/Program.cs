using DSharpPlus;
using DSharpPlus.SlashCommands;
using GiphyDotNet.Manager;
using System;
using System.Threading.Tasks;

namespace BeanbotSharp.Bot
{
    class Program
    {
        internal static readonly Giphy giphy = new Giphy(Environment.GetEnvironmentVariable("GIPHY_KEY"));

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            // Discord client
            var discord = new DiscordShardedClient(new DiscordConfiguration()
            {
                Token = Environment.GetEnvironmentVariable("DISCORD_TOKEN"),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });

            // Slash commands
            var slash = await discord.UseSlashCommandsAsync();

            // Register slash commands and help formatter
            foreach (var ext in slash.Values)
            {
                ext.RegisterCommands<Commands.Giphy>();
                ext.RegisterCommands<Commands.Utility>();
            }

            await discord.StartAsync();
            await Task.Delay(-1);
        }
    }
}
