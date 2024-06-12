using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using wikisuplementos.Models;
using wikisuplementos.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace wikisuplementos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Suplementos()
        {
            var suplementos = await _context.Suplementos.ToListAsync();
            return View(suplementos);
        }

        public async Task<IActionResult> AtletasTreinadores()
        {
            var treinadores = await _context.Treinadores.ToListAsync();
            return View(treinadores);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> DeleteSuplemento(int id)
        {
            try
            {
                var suplemento = await _context.Suplementos.FindAsync(id);
                if (suplemento == null)
                {
                    return NotFound();
                }

                _context.Suplementos.Remove(suplemento);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir suplemento com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> DeleteTreinadorAtleta(int id)
        {
            try
            {
                var treinador = await _context.Treinadores.FindAsync(id);
                if (treinador == null)
                {
                    return NotFound();
                }

                _context.Treinadores.Remove(treinador);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir treinador com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> EditTreinador(int id, [FromBody] TreinadoresModel updatedTreinador)
        {
            try
            {
                var treinador = await _context.Treinadores.FindAsync(id);
                if (treinador == null)
                {
                    return NotFound();
                }

                treinador.Nome = updatedTreinador.Nome;
                treinador.Descricao = updatedTreinador.Descricao;
                treinador.LinkFoto = updatedTreinador.LinkFoto;
                treinador.Uf = updatedTreinador.Uf;

                _context.Treinadores.Update(treinador);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao editar treinador com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }


        public IActionResult CadastroSuplmentos()
        {
            return View();
        }

        public IActionResult CadastroAtletasTreinadores()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
