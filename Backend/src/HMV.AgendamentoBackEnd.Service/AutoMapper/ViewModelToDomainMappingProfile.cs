using AutoMapper;
using HMV.AgendamentoBackEnd.Domain.Entities;
using HMV.AgendamentoBackEnd.Service.ViewModels;

namespace HMV.AgendamentoBackEnd.Service.AutoMapper
{
    /// <summary>
    /// 
    /// </summary>
    public class ViewModelToDomainMappingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PostUsuarioViewModel, Usuario>();
            CreateMap<PutUsuarioViewModel, Usuario>();
        }
    }
}
