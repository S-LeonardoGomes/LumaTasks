using LumaTasks.Models;

namespace LumaTasks.Repository.Interfaces
{
    public interface IAlunoRepository
    {
        IEnumerable<Aluno> GetAlunos();
        Aluno GetAlunoById(string id);
        void Register(Aluno aluno);
    }
}
