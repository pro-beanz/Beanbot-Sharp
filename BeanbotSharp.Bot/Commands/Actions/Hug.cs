using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace BeanbotSharp.Bot.Commands.Actions
{
    public class Hug : GifAction
    {
        [
            Command("hug"),
            Cooldown(3, 5, CooldownBucketType.User),
            Description("Hug someone!"),
            RequireBotPermissions(DSharpPlus.Permissions.EmbedLinks)
        ]
        public async Task HugCommand(CommandContext ctx, [RemainingText, Description("who you want to hug")] DiscordUser target)
        {
            await PerformAction(ctx, "anime hug", "silly, you cant hug yourself", "wah! ive been hugged!", "hugs", target);
        }
    }
}
