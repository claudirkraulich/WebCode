using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<WebCode.Models.Origem> Origem { get; set; }
    }
}
