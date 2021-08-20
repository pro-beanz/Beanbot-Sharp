using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using GiphyDotNet.Model.Parameters;
using System;
using System.Threading.Tasks;

namespace BeanbotSharp.Commands
{
    public class Giphy : BaseCommandModule
    {
        [
            Command("giphy"),
            Cooldown(3, 5, CooldownBucketType.User),
            Description("Displays a random gif from GIPHY."),
            RequireBotPermissions(DSharpPlus.Permissions.EmbedLinks)
        ]
        public async Task GiphyCommand(CommandContext ctx, [RemainingText, Description("search terms")] string query)
        {
            await ctx.TriggerTypingAsync();
            var giphy = Program.giphy;

            var result = await giphy.GifSearch(new SearchParameter()
            {
                Query = query
            });

            if (result.Data.Length == 0)
                await ctx.RespondAsync("no gifs found :(");
            else
                await ctx.RespondAsync(result.Data[new Random().Next(0, result.Data.Length)].EmbedUrl);
        }
    }
}
