using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NeurocorBackEnd.Domain.Entities;
using NeurocorBackEnd.Infra.Data;
using NeurocorBackEnd.Service.Interfaces;
using NeurocorBackEnd.Service.ViewModels;

namespace NeurocorBackEnd.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IAutenticacaoService _autenticacaoService;
        private readonly DataContext _context;


        public UsuarioService(IMapper mapper,
                              IAutenticacaoService autenticacaoService,
                              DataContext context)
        {
            _mapper = mapper;
            _autenticacaoService = autenticacaoService;
            _context = context;
        }

        public UsuarioViewModel Get(string cpf)
        {
            var user = _context.Usuario.FirstOrDefaultAsync(p => p.Cpf == cpf).Result;
            return _mapper.Map<UsuarioViewModel>(user);
        }

        public UsuarioViewModel Post(PostUsuarioViewModel payload)
        {
            var model = _mapper.Map<Usuario>(payload);

            _context.Usuario.Add(model);
            _context.SaveChanges();

            return _mapper.Map<UsuarioViewModel>(model);
        }

        public UsuarioViewModel Put(PutUsuarioViewModel payload)
        {
            var model = _mapper.Map<Usuario>(payload);

            _context.Usuario.Update(model);
            _context.SaveChanges();

            return _mapper.Map<UsuarioViewModel>(model);
        }
    }
}
