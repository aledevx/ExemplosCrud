using System.Threading.Tasks;
using CrudTreino.Data;
using CrudTreino.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CrudTreino.Controllers
{
    public class AnexosController : Controller
    {
        private readonly Contexto db;
        private readonly IStorage storage;

        public AnexosController(Contexto db, IStorage storage)
        {
            this.db = db;
            this.storage = storage;
        }

        public async Task<IActionResult> Download(int id)
        {
            var anexo = await db.Anexos.FindAsync(id);

            if (anexo == null)
            {
                return NotFound();
            }

            byte[] arquivo;

            if (anexo.Bytes is null)
            {
                arquivo = await storage.Download(anexo.LocalizadorDoAnexo);
            }
            else
            {
                arquivo = anexo.Bytes;
            }

            return File(arquivo, anexo.Mime, anexo.Nome);
        }
    }
}