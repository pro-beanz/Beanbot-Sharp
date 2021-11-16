using BeanbotSharp.API.Models.ReactionRoles;
using Microsoft.EntityFrameworkCore;
using System;

namespace BeanbotSharp.API.Data
{
    public class RRDBContext : DbContext
    {
        public RRDBContext(DbContextOptions<RRDBContext> options) : base(options)
        {
        }

        public DbSet<ReactionRole> ReactionRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING_RR"));
    }
}
