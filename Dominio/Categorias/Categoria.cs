using Blog.Dominio.Bases;
using Blog.Dominio.Noticias;
using System.Text.Json.Serialization;

namespace Blog.Dominio.Categorias
{
    public class Categoria : Identificador
    {
        public Categoria(string descricao)
        {           
            AlterarDescricao(descricao);

            Id = Guid.NewGuid();
            Ativo = true;
            DataCriacao = DateTime.Now;
            DATAULTIMAALTERACAO = DateTime.Now;
        }

        public bool Ativo { get; private set; }
        public string? Descricao { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DATAULTIMAALTERACAO { get; private set; }
        public void Ativar() => Ativo = true;
        public void Inativar() => Ativo = false;

        [JsonIgnore]
        public ICollection<Noticia> Noticias { get; set; }

        public void AlterarDescricao(string descricao)
        {
            if (descricao.Trim() == "")
                throw new Exception("Informe uma descrição para a categoria!");

            Descricao = descricao;
        }
    }
}
