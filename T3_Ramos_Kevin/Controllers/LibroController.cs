using Microsoft.AspNetCore.Mvc;
using T3_Ramos_Kevin.Models;
using T3_Ramos_Kevin.Datos;
using Microsoft.AspNetCore.Authorization;

namespace T2_Ramos_Kevin.Controllers
{
    public class LibroController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LibroController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Libro> lista = _db.Libro;
            return View(lista);
        }
        [Authorize]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Libro Libro)
        {
            if (ModelState.IsValid)
            {
                _db.Libro.Add(Libro);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(Libro);

        }

        //Get Editar
        [Authorize]
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var obj = _db.Libro.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //Post Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Libro Libro)
        {
            if (ModelState.IsValid)
            {
                _db.Libro.Update(Libro);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(Libro);

        }

        //Get Eliminar
        [Authorize]
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var obj = _db.Libro.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //Post Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Libro distribuidor)
        {
            if (distribuidor == null)
            {
                return NotFound();
            }
            _db.Libro.Remove(distribuidor);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
