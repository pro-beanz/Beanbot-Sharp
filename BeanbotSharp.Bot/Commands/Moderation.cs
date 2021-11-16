using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Threading.Tasks;

namespace BeanbotSharp.Bot.Commands
{
    public class Moderation : BaseCommandModule
    {
        [
            Command("mute"),
            Description("Mute a user for a specified amount of time."),
            RequireBotPermissions(DSharpPlus.Permissions.ManageRoles),
            RequireUserPermissions(DSharpPlus.Permissions.ManageRoles)
        ]
        public async Task MuteCommand(CommandContext ctx, DiscordMember user, TimeSpan time)
        {
            await ctx.TriggerTypingAsync();
            
        }
    }
}
