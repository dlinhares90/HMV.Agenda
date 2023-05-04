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
    public class LovService : ILovService
    {
        private readonly DataContext _context;

        public LovService(DataContext context)
        {
            _context = context;
        }

        public List<LovItemViewModel> GetItens()
        {
            List<LovItemViewModel> retorno = new List<LovItemViewModel>();

            string sql = @"SELECT * FROM VIEW_APPHMV_AGENDAS_SCMA_ITEM";

            DbConnection connection = _context.Database.GetDbConnection();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            var command = connection.CreateCommand();
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                retorno.Add(new LovItemViewModel
                {
                    Id = (int)reader["ID"],
                    Descricao = (string)reader["DESCRICAO"]
                });
            }

            return retorno;
        }

        public List<LovConvenioViewModel> GetConvenios(int idItem)
        {
            List<LovConvenioViewModel> retorno = new List<LovConvenioViewModel>();

            string sql = @"SELECT * FROM VIEW_APPHMV_AGENDAS_SCMA_CONV WHERE IDITEMAGENDAMENTO = :idItem";

            DbConnection connection = _context.Database.GetDbConnection();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            var command = connection.CreateCommand();
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            var paramUserName = command.CreateParameter();
            paramUserName.ParameterName = "@idItem";
            paramUserName.Value = idItem;
            paramUserName.DbType = DbType.Int16;
            paramUserName.Direction = ParameterDirection.Input;

            command.Parameters.Add(paramUserName);

            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                retorno.Add(new LovConvenioViewModel
                {
                    Id = (Int16)reader["ID"],
                    Descricao = (string)reader["DESCRICAO"]
                });
            }

            return retorno;
        }

        public List<LovPrestadoreViewModel> GetPrestadores(int idItem, int idConvenio)
        {
            List<LovPrestadoreViewModel> retorno = new List<LovPrestadoreViewModel>();

            string sql = @"SELECT * FROM VIEW_APPHMV_AGENDAS_SCMA_PRES WHERE iditemagendamento = :idItem and idconvenio = :idConvenio";

            DbConnection connection = _context.Database.GetDbConnection();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            var command = connection.CreateCommand();
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            var paramUserName = command.CreateParameter();
            paramUserName.ParameterName = "@idItem";
            paramUserName.Value = idItem;
            paramUserName.DbType = DbType.Int16;
            paramUserName.Direction = ParameterDirection.Input;

            command.Parameters.Add(paramUserName);

            var paramConvenio = command.CreateParameter();
            paramConvenio.ParameterName = "@idConvenio";
            paramConvenio.Value = idConvenio;
            paramConvenio.DbType = DbType.Int16;
            paramConvenio.Direction = ParameterDirection.Input;

            command.Parameters.Add(paramConvenio);

            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                retorno.Add(new LovPrestadoreViewModel
                {
                    Id = (Int64)reader["ID"],
                    Nome = (string)reader["NOMEPRESTADOR"]
                });
            }

            return retorno;
        }
    }
}
