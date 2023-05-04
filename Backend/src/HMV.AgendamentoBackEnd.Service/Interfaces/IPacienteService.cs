using HMV.AgendamentoBackEnd.Service.ViewModels;

namespace HMV.AgendamentoBackEnd.Service.Interfaces
{
    public interface IPacienteService
    {
        PacienteViewModel Get(string cpf);
    }
}
