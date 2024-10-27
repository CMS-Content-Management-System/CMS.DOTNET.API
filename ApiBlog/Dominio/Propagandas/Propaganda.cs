using ApiBlog.Dominio.Bases;

namespace ApiBlog.Dominio.Propagandas
{
    public class Propaganda : Identificador
    {
        public Propaganda(string titulo, string imagem, string link, int prioridade)
        {
            Id = Guid.NewGuid();
            Link = link;
            Prioridade = prioridade;
            Inativar();
            AlterarTitulo(titulo);
            AlterarImagem(imagem);
        }

        public bool Ativo { get; private set; }
        public string Titulo { get; private set; }
        public string Imagem { get; private set; }
        public string Link { get; private set; }
        public int Prioridade { get; private set; }

        //

        public void Ativar() => Ativo = true;
        public void Inativar() => Ativo = false;

        public void AlterarTitulo(string titulo)
        {
            if (titulo.Trim() == "")
                throw new Exception("Informe um título para propaganda!");

            Titulo = titulo;
        }

        public void AlterarImagem(string imagem)
        {
            if (imagem.Trim() == "")
                throw new Exception("Informe uma imagem para propaganda!");

            Imagem = imagem;
        }

        public void AlterarDados(string titulo, string imagem, string link, int prioridade)
        {
            Link = link;
            Prioridade = prioridade;
            AlterarTitulo(titulo);
            AlterarImagem(imagem);
        }
    }
}
