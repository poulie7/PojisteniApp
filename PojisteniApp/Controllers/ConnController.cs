using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PojisteniApp.Data;
using PojisteniApp.Models;

namespace PojisteniApp.Controllers
{
    public class ConnController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConnController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conn
        public async Task<IActionResult> Index()
        {

            //var seznamPojisteni = (from pojisteni in _context.Pojisteni
            //                       join pojisteniId in _context.Conn
            //                       on pojisteni.Id equals pojisteniId.PojisteniId

            //                       from pojistenec in _context.Pojistenec
            //                       join pi in _context.Conn
            //                       on pojistenec.Id equals pi.PojistenecId

            //                       select new PojisteniDetails
            //                       {
            //                           Type = pojisteni.Type,
            //                           Price = pojisteni.Price,
            //                           Name = pojistenec.Name,
            //                           Adress = pojistenec.Adress
            //                       }).ToList();
                
        
            return _context.Conn != null ?
                          View(await _context.Conn.ToListAsync()) :

                          Problem("Entity set 'ApplicationDbContext.Conn'  is null.");

        }

        // GET: Conn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conn == null)
            {
                return NotFound();
            }

            var conn = await _context.Conn
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conn == null)
            {
                return NotFound();
            }

            return View(conn);
        }

        // GET: Conn/Create
        public IActionResult Create()
        {
            ViewData["PojistenecId"] = new SelectList(_context.Pojistenec, "Id", "Name");
            ViewData["PojisteniId"] = new SelectList(_context.Pojisteni, "Id", "Type");

            return View();
        }

        // POST: Conn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PojistenecId,PojisteniId")] Conn conn)
        {

            ViewData["PojistenecId"] = new SelectList(_context.Pojistenec, "Id", "Name", conn.PojistenecId);
            ViewData["PojisteniId"] = new SelectList(_context.Pojisteni, "Id", "Type", conn.PojisteniId);

            if (!ModelState.IsValid)
            {
                _context.Add(conn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conn);
        }

        // GET: Conn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conn == null)
            {
                return NotFound();
            }

            var conn = await _context.Conn.FindAsync(id);
            if (conn == null)
            {
                return NotFound();
            }
            return View(conn);
        }

        // POST: Conn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PojistenecId,PojisteniId")] Conn conn)
        {
            if (id != conn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConnExists(conn.Id))
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
            return View(conn);
        }

        // GET: Conn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conn == null)
            {
                return NotFound();
            }

            var conn = await _context.Conn
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conn == null)
            {
                return NotFound();
            }

            return View(conn);
        }

        // POST: Conn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conn == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Conn'  is null.");
            }
            var conn = await _context.Conn.FindAsync(id);
            if (conn != null)
            {
                _context.Conn.Remove(conn);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConnExists(int id)
        {
          return (_context.Conn?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
