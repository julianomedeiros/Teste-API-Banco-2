using Microsoft.AspNetCore.Mvc;

namespace Teste_API_Banco_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
