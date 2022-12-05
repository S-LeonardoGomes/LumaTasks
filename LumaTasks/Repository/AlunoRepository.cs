using LumaTasks.Models;
using LumaTasks.Repository.Context;
using LumaTasks.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LumaTasks.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AlunoDbContext _context;

        public AlunoRepository(AlunoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Aluno> GetAlunos()
        {
            try
            {
                return _context.Alunos.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Aluno GetAlunoById(string id)
        {
            try
            {
                return _context.Alunos.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Register(Aluno aluno)
        {
            try
            {
                _context.Alunos.Add(aluno);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
