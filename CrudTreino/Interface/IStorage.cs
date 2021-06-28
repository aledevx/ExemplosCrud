using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CrudTreino.Interface
{
    public interface IStorage
    {
        Task Upload(string localizador, IFormFile arquivo );
        Task<byte[]> Download(string localizador);
        Task Excluir(string localizador); 
    }
}