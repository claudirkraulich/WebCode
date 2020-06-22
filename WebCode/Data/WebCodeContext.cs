
using Microsoft.EntityFrameworkCore;

namespace WebCode.Models
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
