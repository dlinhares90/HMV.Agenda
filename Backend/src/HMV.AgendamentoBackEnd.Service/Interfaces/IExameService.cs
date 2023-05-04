using HMV.AgendamentoBackEnd.Service.ViewModels;
using System.Collections.Generic;

namespace HMV.AgendamentoBackEnd.Service.Interfaces
{
    public interface IExameService
    {
        List<ExameViewModel> Get(string cpf);
        byte[] GetExame(int exameId);
    }
}
