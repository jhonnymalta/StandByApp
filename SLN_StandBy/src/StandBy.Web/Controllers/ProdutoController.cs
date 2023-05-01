using Microsoft.AspNetCore.Mvc;

namespace StandBy.Web.Controllers
{
    
    public class ProdutoController : Controller
    {
        [Route("lista-de-produtos")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
