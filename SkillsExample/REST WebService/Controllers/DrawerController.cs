using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_WebService.Models;
using AppContext = REST_WebService.Models.AppContext;

namespace REST_WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawerController : ControllerBase
    {
        private readonly AppContext _context;

        public DrawerController(AppContext context)
        {
            _context = context;
        }

        // GET: api/Drawer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drawer>>> GetDrawers()
        {
            return await _context.Drawers.ToListAsync();
        }

        // GET: api/Drawer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drawer>> GetDrawer(int id)
        {
            var drawer = await _context.Drawers.FindAsync(id);

            if (drawer == null)
            {
                return NotFound();
            }

            return drawer;
        }

        // PUT: api/Drawer/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrawer(int id, Drawer drawer)
        {
            if (id != drawer.Id)
            {
                return BadRequest();
            }
            _context.Entry(drawer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrawerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Drawer
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Drawer>> PostDrawer(Drawer drawer)
        {
            _context.Drawers.Add(drawer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrawer", new { id = drawer.Id }, drawer);
        }

        // DELETE: api/Drawer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Drawer>> DeleteDrawer(int id)
        {
            var drawer = await _context.Drawers.FindAsync(id);
            if (drawer == null)
            {
                return NotFound();
            }

            _context.Drawers.Remove(drawer);
            await _context.SaveChangesAsync();

            return drawer;
        }

        private bool DrawerExists(int id)
        {
            return _context.Drawers.Any(e => e.Id == id);
        }
    }
}
