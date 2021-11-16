namespace BeanbotSharp.API.Models.ReactionRoles
{
    public class ReactionRole
    {
        public long Id { get; set; }
        public long GuildId { get; set; }
        public long MessageId { get; set; }
        public bool Type { get; set; }
        public string React { get; set; }
        public long RoleId { get; set; }

        public bool Equals(ReactionRole other)
        {
            return GuildId == other.GuildId
                && MessageId == other.MessageId
                && Type == other.Type
                && React == other.React
                && RoleId == other.RoleId;
        }
    }
}