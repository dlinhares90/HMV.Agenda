using NeurocorBackEnd.Service.ViewModels;

namespace NeurocorBackEnd.Service.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioViewModel Get(string cpf);
        UsuarioViewModel Post(PostUsuarioViewModel payload);
        UsuarioViewModel Put(PutUsuarioViewModel payload);
    }
}
