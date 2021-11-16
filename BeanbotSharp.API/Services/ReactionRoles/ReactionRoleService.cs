using BeanbotSharp.API.Data;
using BeanbotSharp.API.Models.ReactionRoles;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeanbotSharp.API.Services.ReactionRoles
{
    public class ReactionRoleService
    {
        private readonly RRDBContext _context;

        public ReactionRoleService(RRDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReactionRole>> GetAllAsync()
        {
            return await _context.ReactionRoles.ToListAsync();
        }

        public async Task<ReactionRole> GetAsync(long id)
        {
            return await _context.ReactionRoles.FindAsync(id);
        }

        public async Task<ReactionRole> UpdateAsync(long id, ReactionRoleAPI reactionRole)
        {
            var data = ApiToData(id, reactionRole);
            _context.Entry(data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReactionRoleExists(id)) return null;
                else throw;
            }

            return data;
        }

        public async Task<ReactionRole> CreateAsync(ReactionRoleAPI reactionRole)
        {
            var data = ApiToData(reactionRole);

            if ((await _context.ReactionRoles
                .Where(r => r.Equals(data))
                .ToListAsync()).Any())
                return null;

            _context.ReactionRoles.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var reactionRole = await _context.ReactionRoles.FindAsync(id);
            if (reactionRole == null) return false;

            _context.ReactionRoles.Remove(reactionRole);
            await _context.SaveChangesAsync();
            return true;
        }

        private static ReactionRole ApiToData(ReactionRoleAPI reactionRole)
        {
            return new ReactionRole
            {
                GuildId = reactionRole.GuildId,
                MessageId = reactionRole.MessageId,
                Type = reactionRole.Type,
                React = reactionRole.React,
                RoleId = reactionRole.RoleId
            };
        }

        private static ReactionRole ApiToData(long id, ReactionRoleAPI reactionRole)
        {
            return new ReactionRole
            {
                Id = id,
                GuildId = reactionRole.GuildId,
                MessageId = reactionRole.MessageId,
                Type = reactionRole.Type,
                React = reactionRole.React,
                RoleId = reactionRole.RoleId
            };
        }

        private bool ReactionRoleExists(long id)
        {
            return _context.ReactionRoles.Any(e => e.Id == id);
        }
    }
}