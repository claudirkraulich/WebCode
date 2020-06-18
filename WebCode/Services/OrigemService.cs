using System.Collections.Generic;
using System.Linq;
using WebCode.Models;

namespace WebCode.Services
{
    public class OrigemService
    {
        private readonly WebCodeContext _context;

        public OrigemService(WebCodeContext context)
        {
            _context = context;
        }

        public List<Origem> FindAll()
        {
            return _context.Origem.OrderBy(x => x.Nome).ToList();
        }

    }
}
