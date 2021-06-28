using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CrudTreino.Interface;

namespace CrudTreino.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome.")]
        public string Nome { get; set; }
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF precisa ter 11 dígitos.")]
        public string Cpf { get; set; }
        public Anexo Anexo { get; set; }
        public ICollection<Carro> Carros { get; set; }

         public async Task AdicionarAnexo(IFormFile arquivo, IStorage storage)
         {
             this.Anexo = new Anexo(arquivo);
             await storage.Upload(this.Anexo.LocalizadorDoAnexo, arquivo);
         }
    }
}