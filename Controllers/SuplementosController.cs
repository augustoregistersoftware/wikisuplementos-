using Microsoft.AspNetCore.Mvc;
using wikisuplementos.Data;
using wikisuplementos.Models;
using System.Threading.Tasks;

namespace NomeDoProjeto.Controllers
{
    public class SuplementosController : Controller
    {
        private readonly AppDbContext _context;

        public SuplementosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuplementosModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Suplementos.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home"); // Redirecione para uma página de sucesso ou lista de suplementos
            }
            return View(model);
        }
    }
}
