using CrudTreino.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudTreino.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
            {
            }

            public DbSet<Pessoa> Pessoas { get; set; }
            public DbSet<Carro> Carros { get; set; }
    }
}