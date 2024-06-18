using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using wikisuplementos.Models;
using wikisuplementos.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        public IActionResult Fornecedores()
        {
            return View();
        }

        public IActionResult CadastroAtleta()
        {
            return View();
        }

    public async Task<ActionResult> Fornecedor()
    {
        List<FornecedorSuplemento> fornecedores = new List<FornecedorSuplemento>();
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://localhost:44393/");
            var response = await client.GetAsync("api/FornecedorSuplemento/selecionarTodos");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                fornecedores = JsonConvert.DeserializeObject<List<FornecedorSuplemento>>(dados);
            }
        }
        return View(fornecedores);
    }

    [HttpPost]
    public async Task<ActionResult> UpdateFornecedor(FornecedorSuplemento fornecedor)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://localhost:44393/");
            var content = new StringContent(JsonConvert.SerializeObject(fornecedor), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("api/FornecedorSuplemento/alterar", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Fornecedor"); // Redireciona para a lista atualizada de fornecedores
            }
            else
            {
                // Handle error or redirect to an error page
                return View("Error");
            }
        }
    }


        public async Task<IActionResult> Suplementos()
        {
            var suplementos = await _context.Suplementos.ToListAsync();
            return View(suplementos);
        }

        public async Task<IActionResult> AtletasTreinadores()
        {
            var treinadores = await _context.Treinadores
                                            .Include(t => t.Atletas)
                                            .ToListAsync();

            // Inspecione os dados carregados
            foreach (var treinador in treinadores)
            {
                Console.WriteLine($"{treinador.Nome} tem {treinador.Atletas.Count} atletas.");
            }

            return View(treinadores);
        }

        public async Task<IActionResult> Atletas()
        {
            var atletas = await _context.Atletas.Include(a => a.Treinador).ToListAsync();
            return View(atletas);
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
        public async Task<IActionResult> EditTreinador(int id, [FromBody] TreinadorModel updatedTreinador)
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

                [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> EditSuplemento(int id, [FromBody] SuplementosModel updatedSuplementos)
        {
            try
            {
                var suplemento = await _context.Suplementos.FindAsync(id);
                if (suplemento == null)
                {
                    return NotFound();
                }

                suplemento.Nome = updatedSuplementos.Nome;
                suplemento.Descricao = updatedSuplementos.Descricao;
                suplemento.Grupo = updatedSuplementos.Grupo;
                suplemento.LinkFoto = updatedSuplementos.LinkFoto;
                suplemento.Fabricante = updatedSuplementos.Fabricante;

                _context.Suplementos.Update(suplemento);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao editar suplemento com ID {Id}", id);
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpGet]
        public IActionResult GetAtletaDetails(int id)
        {
            var atleta = _context.Atletas.FirstOrDefault(a => a.Id == id);
            if (atleta == null)
            {
                return NotFound("Atleta não encontrado.");
            }

            var atletaDetails = new
            {
                nome = atleta.Nome,
                descricao = atleta.Descricao,
                linkfoto = atleta.LinkFoto,
                uf = atleta.Uf,
                // Adicione outras propriedades necessárias
            };

            return Json(atletaDetails);
        }




        public IActionResult CadastroSuplmentos()
        {
            return View();
        }

        public IActionResult CadastroAtletasTreinadores()
        {
            return View();
        }

        public IActionResult CadastroAtletas()
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