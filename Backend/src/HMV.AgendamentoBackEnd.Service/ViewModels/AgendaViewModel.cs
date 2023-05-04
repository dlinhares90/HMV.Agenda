using System;

namespace HMV.AgendamentoBackEnd.Service.ViewModels
{
    public class AgendaViewModel
    {
        public int CD_ITEM_AGENDAMENTO { get; set; }
        public string DS_ITEM_AGENDAMENTO { get; set; }
        public int CD_CONVENIO { get; set; }
        public DateTime HR_AGENDA { get; set; }
        public int CD_AGENDA_CENTRAL { get; set; }
        public string TP_AGENDA { get; set; }
        public DateTime DT_AGENDA { get; set; }
        public int CD_PRESTADOR { get; set; }
        public string NM_PRESTADOR { get; set; }
        public int CD_RECURSO_CENTRAL { get; set; }
        public string DS_RECURSO_CENTRAL { get; set; }
        public int CD_SETOR { get; set; }
        public string NM_SETOR { get; set; }
        public int CD_UNIDADE_ATENDIMENTO { get; set; }
        public string DS_UNIDADE_ATENDIMENTO { get; set; }
    }
}
