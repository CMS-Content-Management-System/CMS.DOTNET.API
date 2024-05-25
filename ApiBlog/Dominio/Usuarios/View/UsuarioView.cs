namespace ApiBlog.Dominio.Usuarios.View
{
    public class UsuarioView
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public string? Nome { get; set; }
        public string? SobreNome { get; set; }
        public string? Email { get; set; }
        public string? FotoPerfil { get; set; }
        public bool Admin { get; set; }
    }
}
