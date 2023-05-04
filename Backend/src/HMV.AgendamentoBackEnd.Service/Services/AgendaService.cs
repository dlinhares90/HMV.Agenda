using HMV.AgendamentoBackEnd.Infra.Data;
using HMV.AgendamentoBackEnd.Service.Interfaces;
using HMV.AgendamentoBackEnd.Service.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace HMV.AgendamentoBackEnd.Service.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly DataContext _context;

        public AgendaService(DataContext context)
        {
            _context = context;
        }

        public List<AgendaViewModel> GetAgendas(int idItem, int idConvenio, int idPrestador)
        {
            List<AgendaViewModel> retorno = new List<AgendaViewModel>();

            string sql = @"SELECT * FROM view_apphmv_agendas_scma WHERE cd_item_agendamento = :idItem AND cd_convenio = :idConvenio AND cd_prestador = :idPrestador";

            DbConnection connection = _context.Database.GetDbConnection();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            var command = connection.CreateCommand();
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            var paramItem = command.CreateParameter();
            paramItem.ParameterName = "@idItem";
            paramItem.Value = idItem;
            paramItem.DbType = DbType.Int16;
            paramItem.Direction = ParameterDirection.Input;

            command.Parameters.Add(paramItem);

            var paramConvenio = command.CreateParameter();
            paramConvenio.ParameterName = "@idConvenio";
            paramConvenio.Value = idConvenio;
            paramConvenio.DbType = DbType.Int16;
            paramConvenio.Direction = ParameterDirection.Input;

            command.Parameters.Add(paramConvenio);

            var paramPrestador = command.CreateParameter();
            paramPrestador.ParameterName = "@idPrestador";
            paramPrestador.Value = idPrestador;
            paramPrestador.DbType = DbType.Int64;
            paramPrestador.Direction = ParameterDirection.Input;

            command.Parameters.Add(paramPrestador);

            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                retorno.Add(new AgendaViewModel
                {
                    IdItem = int.Parse(reader["CD_ITEM_AGENDAMENTO"].ToString()),
                    DescricaoItem = (string)reader["DS_ITEM_AGENDAMENTO"],
                    IdConvenio = int.Parse(reader["CD_CONVENIO"].ToString()),
                    HoraAgenda = (DateTime)reader["HR_AGENDA"],
                    IdAgendaCentral = int.Parse(reader["CD_AGENDA_CENTRAL"].ToString()),
                    TipoAgenda = (string)reader["TP_AGENDA"],
                    DataAgenda = (DateTime)reader["DT_AGENDA"],
                    IdPrestador = long.Parse(reader["CD_PRESTADOR"].ToString()),
                    NomePrestador = (string)reader["NM_PRESTADOR"],
                    IdRecursoCentral = int.Parse(reader["CD_RECURSO_CENTRAL"].ToString()),
                    DescricaoRecursoCentral = (string)reader["DS_RECURSO_CENTRAL"],
                    IdSetor = int.Parse(reader["CD_SETOR"].ToString()),
                    NomeSetor = (string)reader["NM_SETOR"],
                    IdUnidadeAtendimento = int.Parse(reader["CD_UNIDADE_ATENDIMENTO"].ToString()),
                    DescricaoUnidadeAtendimento = (string)reader["DS_UNIDADE_ATENDIMENTO"]
                });
            }

            return retorno;
        }
    }
}
