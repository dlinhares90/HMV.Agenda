using System;

namespace HMV.AgendamentoBackEnd.Service.ViewModels
{
    public class AgendaViewModel
    {
        public int IdItem { get; set; }
        public string DescricaoItem { get; set; }
        public int IdConvenio { get; set; }
        public DateTime HoraAgenda { get; set; }
        public int IdAgendaCentral { get; set; }
        public string TipoAgenda { get; set; }
        public DateTime DataAgenda { get; set; }
        public long IdPrestador { get; set; }
        public string NomePrestador { get; set; }
        public int IdRecursoCentral { get; set; }
        public string DescricaoRecursoCentral { get; set; }
        public int IdSetor { get; set; }
        public string NomeSetor { get; set; }
        public int IdUnidadeAtendimento { get; set; }
        public string DescricaoUnidadeAtendimento { get; set; }
    }
}
