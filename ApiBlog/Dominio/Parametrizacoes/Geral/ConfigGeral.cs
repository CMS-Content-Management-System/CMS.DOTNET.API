using ApiBlog.Dominio.Bases;

namespace ApiBlog.Dominio.Parametrizacoes.Geral
{
    public class ConfigGeral : Identificador
    {
        public ConfigGeral(string nomeSite, string imagemSite, string nome, string fone,
            string email, string endereco, string instagram, string facebook)
        {
            NomeSite = nomeSite;
            ImagemSite = imagemSite;
            Nome = nome;
            Fone = fone;
            Email = email;
            Endereco = endereco;
            Instagram = instagram;
            Facebook = facebook;
        }

        public string NomeSite { get; private set; }
        public string ImagemSite { get; private set; }
        public string Nome { get; private set; }
        public string Fone { get; private set; }
        public string Email { get; private set; }
        public string Endereco { get; private set; }
        public string Instagram { get; private set; }
        public string Facebook { get; private set; }

        public void Alterar(string nomeSite, string imagemSite, string nome, string fone,
                string email, string endereco, string instagram, string facebook)
        {
            NomeSite = nomeSite;
            ImagemSite = imagemSite;
            Nome = nome;
            Fone = fone;
            Email = email;
            Endereco = endereco;
            Instagram = instagram;
            Facebook = facebook;
        }
    }
}
