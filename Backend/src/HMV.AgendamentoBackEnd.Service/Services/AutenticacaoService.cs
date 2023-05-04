using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NeurocorBackEnd.Infra.Data;
using NeurocorBackEnd.Service.Interfaces;
using NeurocorBackEnd.Service.ViewModels;
using System.Data;
using System.Data.Common;

namespace NeurocorBackEnd.Service.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;


        public AutenticacaoService(DataContext context,
                                   IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public bool Post(PostAutenticacaoViewModel payload)
        {
            string sql = $@"
                           SELECT p.cd_papel , u.cd_usuario, cd_senha
                             FROM dbasgu.papel_usuarios p ,
                                  dbasgu.usuarios u
                            WHERE u.cd_usuario = p.cd_usuario
                              AND p.cd_papel = {_config.GetValue<int>("CodigoPapelUsuario")}
                              AND UPPER(u.cd_usuario) = UPPER(:userName)
                          ";

            if (payload.Admin)
            {
                DbConnection connection = _context.Database.GetDbConnection();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                var command = connection.CreateCommand();
                command.CommandText = sql;

                var paramUserName = command.CreateParameter();
                paramUserName.ParameterName = "@userName";
                paramUserName.Value = payload.UserName;
                paramUserName.DbType = DbType.String;
                paramUserName.Direction = ParameterDirection.Input;

                command.Parameters.Add(paramUserName);

                var result = command.ExecuteScalar();
                return (result != null);
            }
            else
            {
                var user = _context.Usuario.FirstOrDefaultAsync(p => p.UserName == payload.UserName &&
                                                                     p.Password == payload.Password).Result;
                return (user != null);
            }
        }
    }
}
