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
    public class EmpleadosController : Controller
    {
        private readonly GestionProyectosContextDb _context;

        public EmpleadosController(GestionProyectosContextDb context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var gestionProyectosContextDb = _context.Empleados.Include(e => e.PuestoEmpleado);
            return View(await gestionProyectosContextDb.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .Include(e => e.PuestoEmpleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["PuestoId"] = new SelectList(_context.PuestoEmpleado, "Id", "NombrePuestoEmpleado");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreEmpleado,ApellidoEmpleado,FechaContratacion,PuestoId")] Empleados empleados)
        {
            ModelState.Remove("Asignaciones");
            ModelState.Remove("PuestoEmpleado");
            if (ModelState.IsValid)
            {
                _context.Add(empleados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PuestoId"] = new SelectList(_context.PuestoEmpleado, "Id", "NombrePuestoEmpleado", empleados.PuestoId);
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }
            ViewData["PuestoId"] = new SelectList(_context.PuestoEmpleado, "Id", "NombrePuestoEmpleado", empleados.PuestoId);
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreEmpleado,ApellidoEmpleado,FechaContratacion,PuestoId")] Empleados empleados)
        {
            ModelState.Remove("Asignaciones");
            ModelState.Remove("PuestoEmpleado");
            if (id != empleados.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosExists(empleados.Id))
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
            ViewData["PuestoId"] = new SelectList(_context.PuestoEmpleado, "Id", "NombrePuestoEmpleado", empleados.PuestoId);
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .Include(e => e.PuestoEmpleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados != null)
            {
                _context.Empleados.Remove(empleados);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
