using HMV.AgendamentoBackEnd.Service.ViewModels;
using System.Collections.Generic;

namespace HMV.AgendamentoBackEnd.Service.Interfaces
{
    public interface ILovService
    {
        List<LovItemViewModel> GetItens();
        List<LovConvenioViewModel> GetConvenios(int idItem);
        List<LovPrestadoreViewModel> GetPrestadores(int idItem, int idConvenio);

    }
}
