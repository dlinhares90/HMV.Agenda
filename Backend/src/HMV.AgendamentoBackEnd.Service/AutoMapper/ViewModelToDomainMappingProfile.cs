using AutoMapper;
using NeurocorBackEnd.Domain.Entities;
using NeurocorBackEnd.Service.ViewModels;

namespace NeurocorBackEnd.Service.AutoMapper
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
