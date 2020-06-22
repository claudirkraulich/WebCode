using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebCode.Models;
using WebCode.Services.Exceptions;

namespace WebCode.Services
{
    public class AtividadeService
    {
        private readonly WebCodeContext _context;

        public AtividadeService(WebCodeContext context)
        {
            _context = context;
        }

        public async Task<List<Atividade>> FindAllAsync()
        {
            return await _context.Atividade.Include(obj => obj.Demanda).ToListAsync();
        }

        public async Task InsertAsync(Atividade obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Atividade> FindByIdAsync(int id)
        {
            return await _context.Atividade.Include(obj => obj.Demanda).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Atividade.FindAsync(id);
            _context.Atividade.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Atividade obj)
        {
            bool hasAny = await _context.Atividade.AnyAsync(x => x.Id == obj.Id);
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
