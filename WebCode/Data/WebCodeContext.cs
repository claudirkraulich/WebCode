
using Microsoft.EntityFrameworkCore;
using WebCode.Models;

namespace WebCode.Data
{
    public class WebCodeContext : DbContext
    {
        public WebCodeContext (DbContextOptions<WebCodeContext> options)
            : base(options)
        {
        }

        public DbSet<Origem> Origem { get; set; }
        public DbSet<Demanda> Demanda { get; set; }
        public DbSet<Atividade> Atividade { get; set; }
    }
}
