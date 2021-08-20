using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext.Exceptions;
using GiphyDotNet.Manager;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace BeanbotSharp
{
    class Program
    {
        internal static Giphy giphy = new Giphy(Environment.GetEnvironmentVariable("GIPHY_KEY"));

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

            // CommandsNext
            var commands = await discord.UseCommandsNextAsync(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "~" }
            });

            // Register commands
            commands.RegisterCommands(Assembly.GetExecutingAssembly());

            // Register command error handler
            foreach (CommandsNextExtension command in commands.Values)
            {
                command.CommandErrored += CmdErroredHandler;
            }

            // Register help formatter
            commands.SetHelpFormatter<CustomHelpFormatter>();

            await discord.StartAsync();
            await Task.Delay(-1);
        }

        private static async Task CmdErroredHandler(CommandsNextExtension _, CommandErrorEventArgs e)
        {
            var failedChecks = ((ChecksFailedException)e.Exception).FailedChecks;
            foreach (var failedCheck in failedChecks)
            {
                if (failedCheck is CooldownAttribute attribute)
                    await e.Context.RespondAsync($"you're executing this command too fast! please wait {Math.Ceiling(attribute.GetRemainingCooldown(e.Context).TotalSeconds)}s before trying again :/");
                else if (failedCheck is RequireBotPermissionsAttribute)
                    await e.Context.RespondAsync($"i dont have the proper permissions to do that >.<");
                else if (failedCheck is RequireUserPermissionsAttribute)
                    await e.Context.RespondAsync($"sorry, you arent allowed to do that :(");
            }
        }
    }
}
