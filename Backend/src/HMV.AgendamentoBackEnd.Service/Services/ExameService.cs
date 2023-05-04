using HMV.AgendamentoBackEnd.Infra.Data;
using HMV.AgendamentoBackEnd.Service.Helpers;
using HMV.AgendamentoBackEnd.Service.Interfaces;
using HMV.AgendamentoBackEnd.Service.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;

namespace HMV.AgendamentoBackEnd.Service.Services
{
    public class ExameService : IExameService
    {
        private readonly DataContext _context;

        public ExameService(DataContext context)
        {
            _context = context;
        }

        public List<ExameViewModel> Get(string cpf)
        {
            List<ExameViewModel> exames = null;

            string sql = @"
                           SELECT *
                             FROM view_exame_diagnostico
                            WHERE cd_paciente = :pacienteId
                          ";


                return exames;
            

            DbConnection connection = _context.Database.GetDbConnection();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            var command = connection.CreateCommand();
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            var paramUserName = command.CreateParameter();
            paramUserName.ParameterName = "@pacienteId";
            paramUserName.Value = "";
            paramUserName.DbType = DbType.String;
            paramUserName.Direction = ParameterDirection.Input;

            command.Parameters.Add(paramUserName);

            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (exames == null)
                {
                    exames = new List<ExameViewModel>();
                }

                exames.Add(new ExameViewModel
                {
                    Id = (int)reader["CD_ITPED_RX"],
                    DataLaudo = (DateTime)reader["DATA_LAUDO"],
                    DataPedido = (DateTime)reader["DT_PEDIDO"],
                    DescricaoExame = (string)reader["DS_EXA_RX"],
                    PacienteId = (int)reader["CD_PACIENTE"],
                    Conteudo = (byte[])reader["BLOB_CONTEUDO"]
                });
            }

            return exames;
        }

        public byte[] GetExame(int exameId)
        {
            throw new NotImplementedException();
        }
    }
}
