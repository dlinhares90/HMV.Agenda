namespace HMV.AgendamentoBackEnd.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public int PacienteId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
