namespace ApiBlog.Dominio.Bases
{
    public class QueryParams
    {
        public int Pagina { get; set; } = 1;
        public int Limite { get; set; } = 10;
        public bool? Ativo { get; set; } = null;
    }
}
