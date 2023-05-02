using Microsoft.AspNetCore.Mvc;
using StandBy.Business.Intefaces;

namespace StandBy.Web.Controllers
{
    public abstract class BaseController : Controller
    {

        private readonly INotificador _notificador;

        protected BaseController(INotificador notificador)
        {
            _notificador= notificador;
        }


        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
    }
}
