using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

public class FornecedorSuplementoController : Controller
{
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
}
