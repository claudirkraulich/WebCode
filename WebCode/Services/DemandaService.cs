using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCode.Models;

namespace WebCode.Services
{
    public class DemandaService
    {
        private readonly WebCodeContext _context;

        public DemandaService(WebCodeContext context)
        {
            _context = context;
        }

        public List<Demanda> FindAll()
        {
            return _context.Demanda.ToList();
        }

        public void Insert(Demanda obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
