using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using GiphyDotNet.Model.Parameters;
using System;
using System.Threading.Tasks;

namespace BeanbotSharp.Bot.Commands
{
    public class Giphy : SlashCommandModule
    {
        [SlashCommand("cuddle", "Cuddle someone!")]
        [SlashRequirePermissions(DSharpPlus.Permissions.EmbedLinks)]
        public async Task CuddleCommand(InteractionContext ctx,
            [Option("target", "Who you want to cuddle")] DiscordUser target)
        {
            await PerformAction(ctx,
                "anime cuddle",
                "i dont think you can cuddle yourself?",
                "yay cuddles <3",
                "cuddles",
                target
            );
        }

        [SlashCommand("hug", "Hug someone!")]
        [SlashRequirePermissions(DSharpPlus.Permissions.EmbedLinks)]
        public async Task HugCommand(InteractionContext ctx,
            [Option("target", "Who you want to hug")] DiscordUser target)
        {
            await PerformAction(ctx,
                "anime hug",
                "silly, you cant hug yourself",
                "wah! ive been hugged!",
                "hugs",
                target
            );
        }

        [SlashCommand("kiss", "Kiss someone!")]
        [SlashRequirePermissions(DSharpPlus.Permissions.EmbedLinks)]
        public async Task KissCommand(InteractionContext ctx,
            [Option("target", "Who you want to kiss")] DiscordUser target)
        {
            await PerformAction(ctx,
                "anime kiss",
                "how do you even go about kissing yourself what",
                "mwah <3",
                "kisses",
                target
            );
        }

        private async Task PerformAction(InteractionContext ctx, string query, string selfResponse, string botResponse, string action, DiscordUser target)
        {
            var result = await Program.giphy.GifSearch(new SearchParameter() { Query = query });
            string gif = result.Data[new Random().Next(0, result.Data.Length)].Images.Original.Url;
            var builder = new DiscordEmbedBuilder();

            if (target.Equals(ctx.User))
            {
                await CommandHelper.RespondAsync(ctx, selfResponse);
                return;
            }

            if (target.Equals(ctx.Client.CurrentUser))
                builder.Title = botResponse;
            else
                builder.Title = $"{ctx.Member.Nickname} {action} {(await ctx.Guild.GetMemberAsync(target.Id)).Nickname}!";
            builder.ImageUrl = gif;
            await CommandHelper.RespondAsync(ctx, builder);
        }
    }
}
