using AutoMapper;
using HMV.AgendamentoBackEnd.Infra.Data;
using HMV.AgendamentoBackEnd.Service.Interfaces;
using HMV.AgendamentoBackEnd.Service.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace HMV.AgendamentoBackEnd.Service.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;


        public PacienteService(IMapper mapper,
                              DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public PacienteViewModel Get(string cpf)
        {
            PacienteViewModel paciente = null;

            string sql = @"
                           SELECT cd_paciente, nr_cpf, nm_paciente, email
                             FROM paciente
                            WHERE nr_cpf = :cpf
                          ";

            DbConnection connection = _context.Database.GetDbConnection();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            var command = connection.CreateCommand();
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            var paramUserName = command.CreateParameter();
            paramUserName.ParameterName = "@cpf";
            paramUserName.Value = cpf;
            paramUserName.DbType = DbType.String;
            paramUserName.Direction = ParameterDirection.Input;

            command.Parameters.Add(paramUserName);

            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                paciente = new PacienteViewModel
                {
                    CdPaciente = (int)reader["cd_paciente"],
                    NrCpf = (string)reader["nr_cpf"],
                    NmPaciente = (string)reader["nm_paciente"],
                    Email = (string)reader["email"],
                };
            }

            return paciente;
        }
    }
}
