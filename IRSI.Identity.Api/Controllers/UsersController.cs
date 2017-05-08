using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IRSI.Identity.Api.Data;
using IRSI.Identity.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
            return await _context.Users.ToListAsync();
        }
    }
}
