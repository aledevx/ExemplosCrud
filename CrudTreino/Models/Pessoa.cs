using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CrudTreino.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome.")]
        public string Nome { get; set; }
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF precisa ter 11 dígitos.")]
        public string Cpf { get; set; }
        public ICollection<Carro> Carros { get; set; }
    }
}