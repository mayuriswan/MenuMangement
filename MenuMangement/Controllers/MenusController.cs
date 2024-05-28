using MenuMangement.API.Data;
using MenuMangement.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MenuMangement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly MenuContext _context;

        public MenusController(MenuContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            return await _context.Menus.Include(m => m.Categories).ThenInclude(c => c.MenuItems).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await _context.Menus.Include(m=>m.Restaurant).Include(m => m.Categories).ThenInclude(c => c.MenuItems).FirstOrDefaultAsync(m => m.Id == id);

            if (menu == null)
            {
                return NotFound();
            }

            return menu;
        }

        // Add POST, PUT, DELETE methods as needed
    }

}
