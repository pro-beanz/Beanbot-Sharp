using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace BeanbotSharp.Commands
{
    public class Cuddle : GifAction
    {
        [
            Command("cuddle"),
            Cooldown(3, 5, CooldownBucketType.User),
            Description("Cuddle someone!"),
            RequireBotPermissions(DSharpPlus.Permissions.EmbedLinks)
        ]
        public async Task HugCommand(CommandContext ctx, [RemainingText, Description("who you want to cuddle")] DiscordUser target)
        {
            await PerformAction(ctx, "anime cuddle", "i dont think you can cuddle yourself?", "yay cuddles <3", "cuddles", target);
        }
    }
}
