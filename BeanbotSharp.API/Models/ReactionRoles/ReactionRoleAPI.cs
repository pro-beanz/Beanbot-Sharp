namespace BeanbotSharp.API.Models.ReactionRoles
{
    public class ReactionRoleAPI
    {
        public long GuildId { get; set; }
        public long MessageId { get; set; }
        public bool Type { get; set; }
        public string React { get; set; }
        public long RoleId { get; set; }
    }
}