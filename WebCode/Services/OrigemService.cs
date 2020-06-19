using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Origem>> FindAllAsync()
        {
            return await _context.Origem.OrderBy(x => x.Nome).ToListAsync();
        }

    }
}
