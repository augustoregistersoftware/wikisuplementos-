using Microsoft.AspNetCore.Mvc;
using wikisuplementos.Data;
using wikisuplementos.Models;
using System.Threading.Tasks;

namespace NomeDoProjeto.Controllers
{
    public class TreinadorController : Controller
    {
        private readonly AppDbContext _context;

        public TreinadorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TreinadorModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Treinadores.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home"); // Redirecione para uma página de sucesso ou lista de treinadores
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateAtleta()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAtleta(AtletaModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Atletas.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home"); // Redirecione para uma página de sucesso ou lista de suplementos
            }
            return View(model);
        }
    }
}
