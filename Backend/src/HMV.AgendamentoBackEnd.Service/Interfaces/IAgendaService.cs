using HMV.AgendamentoBackEnd.Service.ViewModels;
using System.Collections.Generic;

namespace HMV.AgendamentoBackEnd.Service.Interfaces
{
    public interface IAgendaService
    {
        List<AgendaViewModel> GetAgendas(int idItem, int idConvenio, int idprestador);
    }
}
