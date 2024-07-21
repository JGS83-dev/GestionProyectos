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
    public class AsignacionesController : Controller
    {
        private readonly GestionProyectosContextDb _context;

        public AsignacionesController(GestionProyectosContextDb context)
        {
            _context = context;
        }

        // GET: Asignaciones
        public async Task<IActionResult> Index(string textoABuscar)
        {
            if (_context.Asignaciones == null)
            {
                return Problem("No se ha inicializado el contexto");
            }

            var asignaciones = from a in _context.Asignaciones.Include(a => a.Empleados).Include(a => a.Proyectos).Include(a => a.RolesProyecto) select a;


            if (!String.IsNullOrEmpty(textoABuscar))
            {
                asignaciones = asignaciones.Where(p => p.Proyectos.NombreProyecto.Contains(textoABuscar));
            }

            return View(await asignaciones.ToListAsync());
        }

        [HttpPost]
        public string Index(string textoABuscar, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + textoABuscar;
        }

        // GET: Asignaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaciones = await _context.Asignaciones
                .Include(a => a.Empleados)
                .Include(a => a.Proyectos)
                .Include(a => a.RolesProyecto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignaciones == null)
            {
                return NotFound();
            }

            return View(asignaciones);
        }

        // GET: Asignaciones/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "NombreEmpleado");
            ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "Id", "NombreProyecto");
            ViewData["RolProyectoId"] = new SelectList(_context.RolesProyectos, "Id", "NombreRolProyecto");
            return View();
        }

        // POST: Asignaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaAsignacion,ProyectoId,EmpleadoId,RolProyectoId")] Asignaciones asignaciones)
        {
            ModelState.Remove("Proyectos");
            ModelState.Remove("Empleados");
            ModelState.Remove("RolesProyecto");

            if (ModelState.IsValid)
            {
                _context.Add(asignaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "NombreEmpleado", asignaciones.EmpleadoId);
            ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "Id", "NombreProyecto", asignaciones.ProyectoId);
            ViewData["RolProyectoId"] = new SelectList(_context.RolesProyectos, "Id", "NombreRolProyecto", asignaciones.RolProyectoId);
            return View(asignaciones);
        }

        // GET: Asignaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaciones = await _context.Asignaciones.FindAsync(id);
            if (asignaciones == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "NombreEmpleado", asignaciones.EmpleadoId);
            ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "Id", "NombreProyecto", asignaciones.ProyectoId);
            ViewData["RolProyectoId"] = new SelectList(_context.RolesProyectos, "Id", "NombreRolProyecto", asignaciones.RolProyectoId);
            return View(asignaciones);
        }

        // POST: Asignaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaAsignacion,ProyectoId,EmpleadoId,RolProyectoId")] Asignaciones asignaciones)
        {
            ModelState.Remove("Proyectos");
            ModelState.Remove("Empleados");
            ModelState.Remove("RolesProyecto");
            if (id != asignaciones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionesExists(asignaciones.Id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "NombreEmpleado", asignaciones.EmpleadoId);
            ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "Id", "NombreProyecto", asignaciones.ProyectoId);
            ViewData["RolProyectoId"] = new SelectList(_context.RolesProyectos, "Id", "NombreRolProyecto", asignaciones.RolProyectoId);
            return View(asignaciones);
        }

        // GET: Asignaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaciones = await _context.Asignaciones
                .Include(a => a.Empleados)
                .Include(a => a.Proyectos)
                .Include(a => a.RolesProyecto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignaciones == null)
            {
                return NotFound();
            }

            return View(asignaciones);
        }

        // POST: Asignaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignaciones = await _context.Asignaciones.FindAsync(id);
            if (asignaciones != null)
            {
                _context.Asignaciones.Remove(asignaciones);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionesExists(int id)
        {
            return _context.Asignaciones.Any(e => e.Id == id);
        }
    }
}
