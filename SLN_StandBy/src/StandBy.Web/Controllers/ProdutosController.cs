using Microsoft.AspNetCore.Mvc;

namespace StandBy.Web.Controllers
{
    
    public class ProdutosController : Controller
    {
        [Route("lista-de-produtos")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
