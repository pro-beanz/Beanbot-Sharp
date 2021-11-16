using BeanbotSharp.API.Models.ReactionRoles;
using BeanbotSharp.API.Services.ReactionRoles;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeanbotSharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionRolesController : ControllerBase
    {
        private readonly ReactionRoleService _reactionRoleService;

        public ReactionRolesController(ReactionRoleService reactionRoleService)
        {
            _reactionRoleService = reactionRoleService;
        }

        // GET: api/ReactionRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReactionRole>>> GetReactionRoles()
        {
            return Ok(await _reactionRoleService.GetAllAsync());
        }

        // GET: api/ReactionRoles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ReactionRole>> GetReactionRole(long id)
        {
            var reactionRole = await _reactionRoleService.GetAsync(id);
            return reactionRole == null ? NotFound() : Ok(reactionRole);
        }

        // PUT: api/ReactionRoles/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReactionRole(long id, ReactionRoleAPI reactionRole)
        {
            var data = await _reactionRoleService.UpdateAsync(id, reactionRole);
            return data == null ? NotFound() : Ok(data);
        }

        // POST: api/ReactionRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReactionRole>> PostReactionRole(ReactionRoleAPI reactionRole)
        {
            var data = await _reactionRoleService.CreateAsync(reactionRole);
            return data == null ? Conflict() : Ok(data);
        }

        // DELETE: api/ReactionRoles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReactionRole(long id)
        {
            return await _reactionRoleService.DeleteAsync(id) ? Ok() : NotFound();
        }
    }
}
