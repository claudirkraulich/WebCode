using System.Collections.Generic;
using System.Linq;
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

        public List<Demanda> FindAll()
        {
            return _context.Demanda.Include(obj => obj.Origem).ToList();
        }

        public void Insert(Demanda obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Demanda FindById(int id)
        {
            return _context.Demanda.Include(obj => obj.Origem).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Demanda.Find(id);
            _context.Demanda.Remove(obj);
            _context.SaveChanges();
        }
             
        public void Update(Demanda obj)
        {
            if (!_context.Demanda.Any(x => x.Id == obj.Id)) 
            {
                throw new NotFoundException("Id não localizado");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }

    }
}
