using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using wikisuplementos.Models;
using wikisuplementos.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace wikisuplementos.Controllers;

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

    public IActionResult AtletasTreinadores()
    {
        return View();
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
