using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Threading.Tasks;

namespace BeanbotSharp.Commands
{
    public class Ping : BaseCommandModule
    {
        [
            Command("ping"),
            Description("Displays the bot's current ping"),
            Cooldown(3, 5, CooldownBucketType.User),
            RequireBotPermissions(DSharpPlus.Permissions.SendMessages)
        ]
        public async Task PingCommand(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(String.Format(":ping_pong: pong! my ping is {0}ms", ctx.Client.Ping));
        }
    }
}
