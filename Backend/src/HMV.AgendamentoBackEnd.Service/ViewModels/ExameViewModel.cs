using System;
using System.Collections.Generic;
using System.Text;

namespace NeurocorBackEnd.Service.ViewModels
{
    public class ExameViewModel
    {
        public int Id { get; set; }   //cd_itped_rx
        public DateTime DataPedido { get; set; }
        public DateTime DataLaudo { get; set; }
        public string DescricaoExame { get; set; }
        public int PacienteId { get; set; }
        public byte[] Conteudo { get; set; }
    }
}
