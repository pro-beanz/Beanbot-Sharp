using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.CommandsNext.Entities;
using DSharpPlus.Entities;

namespace BeanbotSharp.Bot
{
    class CustomHelpFormatter : DefaultHelpFormatter
    {
        public CustomHelpFormatter(CommandContext ctx) : base(ctx)
        {
        }

        public override CommandHelpMessage Build()
        {
            EmbedBuilder.Color = DiscordColor.Purple;
            return base.Build();
        }
    }
}
