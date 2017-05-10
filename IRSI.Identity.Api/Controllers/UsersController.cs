using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IRSI.Identity.Api.Data;
using IRSI.Identity.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IRSI.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    //	[Authorize]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ApplicationUser>> Get()
        {
            return await _context.Users.Include(t=>t.Roles).Include(t=>t.Claims).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ApplicationUser> Get(string id)
        {
            return await _context.Users.Include(t=>t.Roles).Include(t=>t.Claims).SingleOrDefaultAsync(u => u.Id == id);
        }

        [HttpGet("{id}/claims")]
        public async Task<List<IdentityUserClaim<string>>> GetClaims(string id) {
            var claims = _context.UserClaims.Where(u=>u.UserId == id);
            return await claims.ToListAsync();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Get(string id, [FromBody]ApplicationUser model)
        {
            if (!ModelState.IsValid)
            {
                //do the error thing
                return BadRequest();
            }
            //update the data
            return Ok();
        }
    }
}
