using NeurocorBackEnd.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeurocorBackEnd.Service.Interfaces
{
    public interface IExameService
    {
        List<ExameViewModel> Get(string cpf);
        byte[] GetExame(int exameId);
    }
}
