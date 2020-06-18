using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCode.Models;


namespace WebCode.Data
{
    public class SeedingService
    {
        private WebCodeContext _context;

        public SeedingService(WebCodeContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Demanda.Any()||
               _context.Atividade.Any() ||
               _context.Origem.Any())
            {
                return;  // DB já foi populado
            }

            Origem o1 = new Origem(1, "TCE");

            _context.Origem.AddRange(o1);

            _context.SaveChanges();
        }
    }
}
