using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Threading.Tasks;

namespace BeanbotSharp.Bot.Commands
{
    public class Ping : BaseCommandModule
    {
        [
            Command("ping"),
            Cooldown(3, 5, CooldownBucketType.User),
            Description("Displays the bot's current ping"),
            RequireBotPermissions(DSharpPlus.Permissions.SendMessages)
        ]
        public async Task PingCommand(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync(String.Format(":ping_pong: pong! my ping is {0}ms", ctx.Client.Ping));
        }
    }
}
