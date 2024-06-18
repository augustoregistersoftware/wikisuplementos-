using Microsoft.AspNetCore.Mvc;
using wikisuplementos.Data;
using wikisuplementos.Models;
using System.Threading.Tasks;

namespace NomeDoProjeto.Controllers
{
    public class AtletaController : Controller
    {
        private readonly AppDbContext _context;

        public AtletaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        [HttpPost]
        public async Task<IActionResult> CadastroAtleta(AtletaModel model)
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
