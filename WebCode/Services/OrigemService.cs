using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebCode.Models;
using WebCode.Services.Exceptions;

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

        public async Task InsertAsync(Origem obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Origem> FindByIdAsync(int id)
        {
            return await _context.Origem.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Origem.FindAsync(id);
                _context.Origem.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Não foi possível excluir a Origem pois existem Demandas relacionadas");
            }

        }

        public async Task UpdateAsync(Origem obj)
        {
            bool hasAny = await _context.Origem.AnyAsync(x => x.Id == obj.Id);
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
