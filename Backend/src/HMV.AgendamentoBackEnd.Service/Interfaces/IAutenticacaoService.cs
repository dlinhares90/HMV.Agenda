using NeurocorBackEnd.Service.ViewModels;

namespace NeurocorBackEnd.Service.Interfaces
{
    public interface IAutenticacaoService
    {
        bool Post(PostAutenticacaoViewModel payload);
    }
}
