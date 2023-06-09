using StandBy.Business.Notificacoes;

namespace StandBy.Web.Extensions
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
        void ClearNotificacao();
    }
}
