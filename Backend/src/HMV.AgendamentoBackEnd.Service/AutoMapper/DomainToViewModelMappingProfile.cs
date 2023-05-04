using AutoMapper;
using HMV.AgendamentoBackEnd.Domain.Entities;
using HMV.AgendamentoBackEnd.Service.ViewModels;

namespace HMV.AgendamentoBackEnd.Service.AutoMapper
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
