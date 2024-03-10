using Blog.Dominio.Bases;
using Blog.Dominio.Geral;

namespace Blog.Dominio.Usuarios
{
    public class Usuario : Identificador
    {
        public Usuario(string nome, string sobreNome, string email)
        {
            AlterarDados(nome, sobreNome, email);
            
            Id = Guid.NewGuid();
            Ativo = true;
            Senha = "";
            FotoPerfil = "";
            Admin = false;
            DataCriacao = DateTime.Now;
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

        public void AlterarDados(string nome, string sobreNome, string email)
        {
            AlterarNome(nome, sobreNome);
            AlterarEmail(email);
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

        public void Ativar() => Ativo = true;
        public void Inativar() => Ativo = false;
        public void TornarAdmin() => Admin = true;
        public void DexarAdmin() => Admin = false;
    }
}
