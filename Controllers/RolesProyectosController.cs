using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionProyectos.Models;

namespace GestionProyectos.Controllers
{
    public class RolesProyectosController : Controller
    {
        private readonly GestionProyectosContextDb _context;

        public RolesProyectosController(GestionProyectosContextDb context)
        {
            _context = context;
        }

        // GET: RolesProyectos
        public async Task<IActionResult> Index()
        {
            return View(await _context.RolesProyectos.ToListAsync());
        }

        // GET: RolesProyectos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesProyecto = await _context.RolesProyectos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rolesProyecto == null)
            {
                return NotFound();
            }

            return View(rolesProyecto);
        }

        // GET: RolesProyectos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RolesProyectos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreRolProyecto")] RolesProyecto rolesProyecto)
        {
            ModelState.Remove("Asignaciones");
            if (ModelState.IsValid)
            {
                _context.Add(rolesProyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rolesProyecto);
        }

        // GET: RolesProyectos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesProyecto = await _context.RolesProyectos.FindAsync(id);
            if (rolesProyecto == null)
            {
                return NotFound();
            }
            return View(rolesProyecto);
        }

        // POST: RolesProyectos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreRolProyecto")] RolesProyecto rolesProyecto)
        {
            ModelState.Remove("Asignaciones");
            if (id != rolesProyecto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolesProyecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesProyectoExists(rolesProyecto.Id))
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
            return View(rolesProyecto);
        }

        // GET: RolesProyectos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesProyecto = await _context.RolesProyectos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rolesProyecto == null)
            {
                return NotFound();
            }

            return View(rolesProyecto);
        }

        // POST: RolesProyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rolesProyecto = await _context.RolesProyectos.FindAsync(id);
            if (rolesProyecto != null)
            {
                _context.RolesProyectos.Remove(rolesProyecto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolesProyectoExists(int id)
        {
            return _context.RolesProyectos.Any(e => e.Id == id);
        }
    }
}
