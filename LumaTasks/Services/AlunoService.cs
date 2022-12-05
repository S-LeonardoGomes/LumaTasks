using LumaTasks.Models;
using LumaTasks.Repository.Interfaces;
using LumaTasks.Services.Interfaces;
using System.Data;

namespace LumaTasks.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public IEnumerable<Aluno> GetAlunos()
        {
            try
            {
                return _alunoRepository.GetAlunos();
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
                return _alunoRepository.GetAlunoById(id);
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
                _alunoRepository.Register(aluno);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
