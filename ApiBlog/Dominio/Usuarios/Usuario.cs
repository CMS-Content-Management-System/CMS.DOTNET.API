using ApiBlog.Dominio.Bases;
using ApiBlog.Dominio.Geral;

namespace ApiBlog.Dominio.Usuarios
{
    public class Usuario : Identificador
    {
        public Usuario()
        {
                
        }
        public Usuario(string nome, string sobreNome, string email, string senha)
        {
            AlterarDados(nome, sobreNome, email, senha);

            Id = Guid.NewGuid();
            Ativo = true;
            FotoPerfil = "";
            Admin = false;
            DataCriacao = DateTime.Now;

            Senha = EncriptarSenha(Senha);
        }

        public bool Ativo { get; private set; }
        public string? Nome { get; private set; }
        public string? SobreNome { get; private set; }
        public string? Email { get; private set; }
        public string? Senha { get; private set; }
        public string? FotoPerfil { get; private set; }
        public bool Admin { get; private set; }
        public DateTime DataCriacao { get; private set; }

        //

        public void AlterarDados(string nome, string sobreNome, string email, string senha)
        {
            AlterarNome(nome, sobreNome);
            AlterarEmail(email);
            AlterarSenha(senha);
        }

        public void AlterarNome(string nome, string sobreNome)
        {
            if (nome.Trim() == "" || sobreNome.Trim() == "")
                throw new Exception("Informe um 'nome' e 'sobrenome'!");

            Nome = nome;
            SobreNome = sobreNome;
        }

        public void AlterarEmail(string email)
        {
            if (!Util.EmailEhValido(email))
                throw new Exception("Informe um 'e-mail' válido!");

            Email = email;
        }

        public void AlterarSenha(string senha)
        {
            if (senha.Trim().Length < 6 || senha.Trim().Length > 10)
                throw new Exception("A senha deve conter entre 6 e 10 caracteres!");

            Senha = senha.Trim();
        }

        public void Ativar() => Ativo = true;
        public void Inativar() => Ativo = false;
        public void TornarAdmin() => Admin = true;
        public void DeixarAdmin() => Admin = false;

        public static string EncriptarSenha(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha, "$2a$10$U7b8xqO8n7M7SXj9VUgoCe");
        }
    }
}

