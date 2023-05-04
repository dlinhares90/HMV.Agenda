using AutoMapper;
using NeurocorBackEnd.Domain.Entities;
using NeurocorBackEnd.Service.ViewModels;

namespace NeurocorBackEnd.Service.AutoMapper
{
    /// <summary>
    /// 
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Paciente, PacienteViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
