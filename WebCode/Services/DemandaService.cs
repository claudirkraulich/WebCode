using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebCode.Models;
using WebCode.Services.Exceptions;

namespace WebCode.Services
{
    public class DemandaService
    {
        private readonly WebCodeContext _context;

        public DemandaService(WebCodeContext context)
        {
            _context = context;
        }

        public async Task<List<Demanda>> FindAllAsync()
        {
            return await _context.Demanda.Include(obj => obj.Origem).ToListAsync();
        }

        public async Task InsertAsync(Demanda obj)
        {
            _context.Add(obj);
           await _context.SaveChangesAsync();
        }

        public async Task<Demanda> FindByIdAsync(int id)
        {
            return await _context.Demanda.Include(obj => obj.Origem).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Demanda.FindAsync(id);
            _context.Demanda.Remove(obj);
            await _context.SaveChangesAsync();
        }
             
        public async Task UpdateAsync(Demanda obj)
        {
            bool hasAny = await _context.Demanda.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny) 
            {
                throw new NotFoundException("Id não localizado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }

    }
}
