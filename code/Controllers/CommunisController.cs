using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Community.Data;
using Community.Models;

namespace Community.Controllers
{
    public class CommunisController : Controller
    {
        private readonly MvcCommuniContext _context;

        public CommunisController(MvcCommuniContext context)
        {
            _context = context;
        }

        // GET: Communis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Communis.ToListAsync());
        }

        // GET: Communis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var communi = await _context.Communis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (communi == null)
            {
                return NotFound();
            }

            return View(communi);
        }

        // GET: Communis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Communis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CName,Proprieter,PPhone,Star,CAcademy,Teacher,Remark")] Communi communi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(communi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(communi);
        }

        // GET: Communis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var communi = await _context.Communis.FindAsync(id);
            if (communi == null)
            {
                return NotFound();
            }
            return View(communi);
        }

        // POST: Communis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CName,Proprieter,PPhone,Star,CAcademy,Teacher,Remark")] Communi communi)
        {
            if (id != communi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(communi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommuniExists(communi.Id))
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
            return View(communi);
        }

        // GET: Communis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var communi = await _context.Communis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (communi == null)
            {
                return NotFound();
            }

            return View(communi);
        }

        // POST: Communis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var communi = await _context.Communis.FindAsync(id);
            _context.Communis.Remove(communi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommuniExists(int id)
        {
            return _context.Communis.Any(e => e.Id == id);
        }
    }
}
