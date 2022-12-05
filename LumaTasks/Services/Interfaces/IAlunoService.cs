using LumaTasks.Models;

namespace LumaTasks.Services.Interfaces
{
    public interface IAlunoService
    {
        IEnumerable<Aluno> GetAlunos();
        Aluno GetAlunoById(string id);
        void Register(Aluno aluno);
    }
}
