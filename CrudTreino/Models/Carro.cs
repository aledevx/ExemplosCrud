namespace CrudTreino.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int? PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}