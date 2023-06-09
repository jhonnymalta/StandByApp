using Microsoft.AspNetCore.Mvc;

namespace StandBy.Web.Extensions
{
    public class SummarytViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
