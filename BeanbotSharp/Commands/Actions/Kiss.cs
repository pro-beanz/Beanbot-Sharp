using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace BeanbotSharp.Commands.Actions
{
    public class Kiss : GifAction
    {
        [
            Command("kiss"),
            Cooldown(3, 5, CooldownBucketType.User),
            Description("Kiss someone!"),
            RequireBotPermissions(DSharpPlus.Permissions.EmbedLinks)
        ]
        public async Task HugCommand(CommandContext ctx, [RemainingText, Description("who you want to kiss")] DiscordUser target)
        {
            await PerformAction(ctx, "anime kiss", "how do you even go about kissing yourself what", "mwah <3", "kisses", target);
        }
    }
}
