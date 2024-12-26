// Controllers/RoomAvailabilitiesController.cs
using Microsoft.AspNetCore.Mvc;
using hotel.Models;
using hotel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hotel.Controllers
{
    public class RoomAvailabilitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomAvailabilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RoomAvailabilities
        public async Task<IActionResult> Index()
        {
            var roomAvailabilities = _context.RoomAvailabilities
                .Include(r => r.Room);
            return View(await roomAvailabilities.ToListAsync());
        }

        // GET: RoomAvailabilities/Create
        public IActionResult Create()
        {
            ViewBag.RoomId = new SelectList(_context.Rooms, "Id", "Name");
            return View();
        }

        // POST: RoomAvailabilities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,Date,IsAvailable")] RoomAvailability roomAvailability)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomAvailability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.RoomId = new SelectList(_context.Rooms, "Id", "Name", roomAvailability.RoomId);
            return View(roomAvailability);
        }

        // GET: RoomAvailabilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomAvailability = await _context.RoomAvailabilities.FindAsync(id);
            if (roomAvailability == null)
            {
                return NotFound();
            }
           ViewBag.roomid = new SelectList(_context.Rooms, "Id", "RoomNumber", roomAvailability.RoomId);
            return View(roomAvailability);
        }

        // POST: RoomAvailabilities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoomId,Date,IsAvailable")] RoomAvailability roomAvailability)
        {
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "RoomNumber", roomAvailability.RoomId);
            if (id != roomAvailability.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomAvailability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.RoomAvailabilities.Any(e => e.Id == roomAvailability.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name", roomAvailability.RoomId);
            return View(roomAvailability);
        }

        // GET: RoomAvailabilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomAvailability = await _context.RoomAvailabilities
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomAvailability == null)
            {
                return NotFound();
            }

            return View(roomAvailability);
        }

        // POST: RoomAvailabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomAvailability = await _context.RoomAvailabilities.FindAsync(id);
            _context.RoomAvailabilities.Remove(roomAvailability);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
