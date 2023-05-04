namespace NeurocorBackEnd.Service.ViewModels
{
    public class PutUsuarioViewModel
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public int PacienteId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
