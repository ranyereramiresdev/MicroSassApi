namespace MicroSassApi.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdResponsavel { get; set; }
    }
}
