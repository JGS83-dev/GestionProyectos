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
    public class PuestoEmpleadosController : Controller
    {
        private readonly GestionProyectosContextDb _context;

        public PuestoEmpleadosController(GestionProyectosContextDb context)
        {
            _context = context;
        }

        // GET: PuestoEmpleados
        public async Task<IActionResult> Index()
        {
            return View(await _context.PuestoEmpleado.ToListAsync());
        }

        // GET: PuestoEmpleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestoEmpleado = await _context.PuestoEmpleado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestoEmpleado == null)
            {
                return NotFound();
            }

            return View(puestoEmpleado);
        }

        // GET: PuestoEmpleados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PuestoEmpleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombrePuestoEmpleado")] PuestoEmpleado puestoEmpleado)
        {
            ModelState.Remove("Empleados");
            if (ModelState.IsValid)
            {
                _context.Add(puestoEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puestoEmpleado);
        }

        // GET: PuestoEmpleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestoEmpleado = await _context.PuestoEmpleado.FindAsync(id);
            if (puestoEmpleado == null)
            {
                return NotFound();
            }
            return View(puestoEmpleado);
        }

        // POST: PuestoEmpleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombrePuestoEmpleado")] PuestoEmpleado puestoEmpleado)
        {
            ModelState.Remove("Empleados");
            if (id != puestoEmpleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puestoEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestoEmpleadoExists(puestoEmpleado.Id))
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
            return View(puestoEmpleado);
        }

        // GET: PuestoEmpleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestoEmpleado = await _context.PuestoEmpleado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestoEmpleado == null)
            {
                return NotFound();
            }

            return View(puestoEmpleado);
        }

        // POST: PuestoEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puestoEmpleado = await _context.PuestoEmpleado.FindAsync(id);
            if (puestoEmpleado != null)
            {
                _context.PuestoEmpleado.Remove(puestoEmpleado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuestoEmpleadoExists(int id)
        {
            return _context.PuestoEmpleado.Any(e => e.Id == id);
        }
    }
}
