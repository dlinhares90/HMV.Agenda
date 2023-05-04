using NeurocorBackEnd.Service.ViewModels;

namespace NeurocorBackEnd.Service.Interfaces
{
    public interface IPacienteService
    {
        PacienteViewModel Get(string cpf);
    }
}
