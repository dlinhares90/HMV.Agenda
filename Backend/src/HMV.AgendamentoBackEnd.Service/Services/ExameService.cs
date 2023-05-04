using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;
using ClinosonBackEnd.Infra.Data;
using ClinosonBackEnd.Service.Helpers;
using ClinosonBackEnd.Service.Interfaces;
using ClinosonBackEnd.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;

namespace ClinosonBackEnd.Service.Services
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

            var paciente = _context.Usuario.FirstOrDefaultAsync(p => p.Cpf == cpf).Result;

            if (paciente == null)
            {
                return exames;
            }

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
            paramUserName.Value = paciente.PacienteId;
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
            string sql = @"
                           SELECT *
                             FROM view_exame_diagnostico
                            WHERE cd_ped_rx = :exameId
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
            paramUserName.ParameterName = "@exameId";
            paramUserName.Value = exameId;
            paramUserName.DbType = DbType.String;
            paramUserName.Direction = ParameterDirection.Input;

            command.Parameters.Add(paramUserName);

            DbDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return default;
            }

            var conteudo = (byte[])reader["BLOB_CONTEUDO"];

            var str = Encoding.Default.GetString(conteudo);
            var textoLimpo = RichTextStripper.StripRichTextFormat(str).Replace("\t", "");

            Document doc = new Document(PageSize.A4, 40, 40, 80, 60);

            using (MemoryStream output = new MemoryStream())
            {
                PdfWriter wri = PdfWriter.GetInstance(doc, output);
                doc.Open();

                var imgCabecalho = Path.Combine(Directory.GetCurrentDirectory(), "assets\\imagem\\cabecalho.png");
                var imgRodape = Path.Combine(Directory.GetCurrentDirectory(), "assets\\imagem\\rodape.jpg");

                PdfContentByte cb = wri.DirectContent;
                PdfTemplate headerTemplate;
                PdfTemplate footerTemplate;

                headerTemplate = cb.CreateTemplate(doc.PageSize.GetRight(20), 60);
                footerTemplate = cb.CreateTemplate(doc.PageSize.GetRight(20), 50);

                ////ADICIONA CABECALHO
                //Image imageCabecalho = Image.GetInstance(imgCabecalho);
                //var scalePercentCabecalho = (((doc.PageSize.Width / imageCabecalho.Width) * 100) - 2);
                //imageCabecalho.ScalePercent(scalePercentCabecalho);
                //imageCabecalho.SetAbsolutePosition(doc.PageSize.GetLeft(10), doc.PageSize.GetTop(60));

                //cb.BeginText();
                //cb.SetTextMatrix(doc.PageSize.GetLeft(10), doc.PageSize.GetTop(60));
                //cb.AddImage(imageCabecalho);
                //cb.EndText();
                //cb.AddTemplate(headerTemplate, doc.PageSize.GetLeft(10), doc.PageSize.GetTop(60));
                ////END CABECALHO

                var linhas = textoLimpo.Split('\n').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                var fontTitle = FontFactory.GetFont("Verdana", 14);
                var fontText = FontFactory.GetFont("Verdana", 12);


                for (int i = 0; i < linhas.Length - 1; i++)
                {
                    if (string.IsNullOrWhiteSpace(linhas[i])) continue;

                    if (i == 0)
                    {
                        Paragraph p = new Paragraph(linhas[i]);
                        p.Alignment = Element.ALIGN_CENTER;
                        doc.Add(p);

                        doc.Add(Chunk.NEWLINE);
                    }
                    else
                    {
                        Paragraph p = new Paragraph("        " + linhas[i])
                        {
                            Alignment = Element.ALIGN_LEFT
                        };
                        doc.Add(p);
                        doc.Add(Chunk.NEWLINE);
                    }
                }

                //ADICIONA RODAPE             
                //Image imageRodape = Image.GetInstance(imgRodape);
                //var scalePercentRodape = (((doc.PageSize.Width / imageRodape.Width) * 100) - 3);
                //imageRodape.ScalePercent(scalePercentRodape);
                //imageRodape.SetAbsolutePosition(doc.PageSize.GetLeft(10), doc.PageSize.GetBottom(10));

                cb.BeginText();
                cb.SetTextMatrix(doc.PageSize.GetLeft(10), doc.PageSize.GetBottom(10));
                //cb.AddImage(imageRodape);
                cb.EndText();
                cb.AddTemplate(footerTemplate, doc.PageSize.GetLeft(10), doc.PageSize.GetBottom(10));
                //END RODAPE
                doc.Close();
                
                return output.ToArray();

            }
        }
    }
}
