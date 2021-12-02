using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using System;
using System.Threading.Tasks;

namespace BeanbotSharp.Bot.Commands
{
    class Utility : SlashCommandModule
    {
        [SlashCommand("ping", "Displays the bot's current ping.")]
        [SlashRequirePermissions(DSharpPlus.Permissions.SendMessages)]
        public async Task PingCommand(InteractionContext ctx)
        {
            await CommandHelper.RespondAsync(ctx,
                String.Format(":ping_pong: pong! my ping is {0} ms", ctx.Client.Ping));
        }
    }
}