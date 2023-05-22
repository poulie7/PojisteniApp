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
    public class PojistenecController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PojistenecController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pojistenec
        public async Task<IActionResult> Index()
        {
              return _context.Pojistenec != null ? 
                          View(await _context.Pojistenec.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Pojistenec'  is null.");
        }

        // GET: Pojistenec/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pojistenec == null)
            {
                return NotFound();
            }

            var pojistenec = await _context.Pojistenec
                .FirstOrDefaultAsync(m => m.Id == id);

            //var details = (from d in _context.Conn
            //              where d.PojistenecId == id
            //              select d.PojisteniId).ToList();

            //var matchingPojisteni = (from p in _context.Pojisteni
            //                        where details.Contains(p.Id) 
            //                        select p).ToList();

            var matchingPojisteni = await (from d in _context.Conn
                                     join p in _context.Pojisteni on d.PojisteniId equals p.Id
                                     where d.PojistenecId == id
                                     select p).ToListAsync();

            PojisteniDetails pojisteniDetails = new PojisteniDetails();
            pojisteniDetails.Pojisteni = matchingPojisteni;
            pojisteniDetails.Pojistenec = pojistenec;

            if (pojistenec == null)
            {
                return NotFound();
            }

            return View(pojisteniDetails);
        }

        // GET: Pojistenec/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pojistenec/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Adress,City,Email,Phone,PSC")] Pojistenec pojistenec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pojistenec);
                await _context.SaveChangesAsync();

            }
            Conn conn = new Conn();
            var pojistenecId = pojistenec.Id;
            conn.PojistenecId = pojistenecId;
            conn.PojisteniId = null;


            if (ModelState.IsValid)
            {
                _context.Add(conn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pojistenec);
        }

        // GET: Pojistenec/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pojistenec == null)
            {
                return NotFound();
            }

            var pojistenec = await _context.Pojistenec.FindAsync(id);
            if (pojistenec == null)
            {
                return NotFound();
            }
            return View(pojistenec);
        }

        // POST: Pojistenec/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Adress,City,Email,Phone,PSC")] Pojistenec pojistenec)
        {
            if (id != pojistenec.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pojistenec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PojistenecExists(pojistenec.Id))
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
            return View(pojistenec);
        }

        // GET: Pojistenec/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pojistenec == null)
            {
                return NotFound();
            }

            var pojistenec = await _context.Pojistenec
                .FirstOrDefaultAsync(m => m.Id == id);
         
            if (pojistenec == null)
            {
                return NotFound();
            }

            return View(pojistenec);
        }

        // POST: Pojistenec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pojistenec == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pojistenec'  is null.");
            }
            var pojistenec = await _context.Pojistenec.FindAsync(id);
            var conn = _context.Conn.SingleOrDefault(x => x.PojistenecId == id);


            if (pojistenec != null)
            {
                _context.Pojistenec.Remove(pojistenec);
                _context.Conn.Remove(conn);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PojistenecExists(int id)
        {
          return (_context.Pojistenec?.Any(e => e.Id == id)).GetValueOrDefault();
        }




        // GET: Conn/Create
        public IActionResult CreateNewPojisteni(int? id)
        {
          
          
            ViewData["PojisteniId"] = new SelectList(_context.Pojisteni, "Id", "Type");

            return View();
        }

        // POST: Conn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNewPojisteni([Bind("PojistenecId,PojisteniId")] Conn conn, int id)
        {

            conn.PojistenecId = id;
            ViewData["PojisteniId"] = new SelectList(_context.Pojisteni, "Id", "Type", conn.PojisteniId);

            if (!ModelState.IsValid)
            {
                _context.Add(conn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conn);
        }





        // GET: Conn/Delete/pridano mnou
        public async Task<IActionResult> DeletePojisteni(int? PojistenecId, int? PojisteniId)
        {
            if (PojistenecId == null || _context.Conn == null || PojisteniId == null) 
            {
                return NotFound();
            }


            var pojistenec = await _context.Pojistenec
                .FirstOrDefaultAsync(m => m.Id == PojistenecId);

            var pojisteni = await _context.Pojisteni
                .FirstOrDefaultAsync(m => m.Id == PojisteniId);

            PojisteniDetails pojisteniDetails = new PojisteniDetails();
            pojisteniDetails.Route = pojisteni;
            pojisteniDetails.Pojistenec = pojistenec;


        


            if (pojistenec == null || pojisteni == null)
            {
                return NotFound();
            }
     
            return View(pojisteniDetails);
        }


        // POST: Pojisteni/Delete/pridano mnou
        [HttpPost, ActionName("DeletePojisteniConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePojisteniConfirmed(int? PojistenecId, int? PojisteniId)
        {
            if (_context.Conn == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pojisteni'  is null.");
            }

            var conn = await _context.Conn
            .Where(row => row.PojisteniId == PojisteniId &&
                           row.PojistenecId == PojistenecId)
            .FirstOrDefaultAsync();



            if (conn != null)
            {
                _context.Conn.Remove(conn);

  
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }








        // GET: Pojisteni/Details/5
        public async Task<IActionResult> DetailPojisteni(int? id)
        {
            if (id == null || _context.Pojisteni == null)
            {
                return NotFound();
            }

            var pojisteni = await _context.Pojisteni
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pojisteni == null)
            {
                return NotFound();
            }
            PojisteniDetails pojisteniDetail = new PojisteniDetails();
            pojisteniDetail.Route = pojisteni;
            return View(pojisteniDetail);
        }

    }
}
