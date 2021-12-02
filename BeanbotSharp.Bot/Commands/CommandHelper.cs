using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System.Threading.Tasks;

namespace BeanbotSharp.Bot.Commands
{
    class CommandHelper
    {
        public static async Task RespondAsync(InteractionContext ctx, string content)
        {
            await ctx.CreateResponseAsync(
                DSharpPlus.InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder()
                    .WithContent(content));
        }

        public static async Task RespondAsync(InteractionContext ctx, DiscordEmbedBuilder builder)
        {
            await ctx.CreateResponseAsync(
                DSharpPlus.InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder()
                    .AddEmbed(builder)
            );
        }
    }
}
