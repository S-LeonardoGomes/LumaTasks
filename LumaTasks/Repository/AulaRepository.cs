using LumaTasks.Models;
using LumaTasks.Repository.Context;
using LumaTasks.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LumaTasks.Repository
{
    public class AulaRepository : IAulaRepository
    {
        private readonly AlunoDbContext _context;

        public AulaRepository(AlunoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Aula> GetAulas()
        {
            try
            {
                return _context.Aulas.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Aula GetAulaById(string id)
        {
            try
            {
                return _context.Aulas.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void ScheduleAula(Aula aula)
        {
            try
            {
                _context.Aulas.Add(aula);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateEvent(Aula aula)
        {
            try
            {
                _context.Aulas.Update(aula);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
