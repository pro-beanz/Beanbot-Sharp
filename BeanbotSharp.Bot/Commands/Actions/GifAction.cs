using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using GiphyDotNet.Model.Parameters;
using System;
using System.Threading.Tasks;

namespace BeanbotSharp.Bot.Commands.Actions
{
    public class GifAction : BaseCommandModule
    {
        public async Task PerformAction(CommandContext ctx, string query, string selfResponse, string botResponse, string action, DiscordUser target)
        {
            await ctx.TriggerTypingAsync();
            var result = await Program.giphy.GifSearch(new SearchParameter() { Query = query });
            string gif = result.Data[new Random().Next(0, result.Data.Length)].Images.Original.Url;
            DiscordEmbedBuilder builder = new DiscordEmbedBuilder();

            if (target.Equals(ctx.User))
            {
                await ctx.RespondAsync(selfResponse);
                return;
            }
            
            if (target.Equals(ctx.Client.CurrentUser))
                builder.Title = botResponse;
            else
                builder.Title = $"{ctx.Member.Nickname} {action} {(await ctx.Guild.GetMemberAsync(target.Id)).Nickname}!";
            builder.ImageUrl = gif;
            await ctx.RespondAsync(builder);
        }
    }
}
