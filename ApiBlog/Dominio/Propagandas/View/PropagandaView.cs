namespace ApiBlog.Dominio.Propagandas.View
{
    public class PropagandaView
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Link { get; set; }
        public int Prioridade { get; set; }
    }
}
