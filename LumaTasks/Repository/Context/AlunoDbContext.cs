using LumaTasks.Models;
using Microsoft.EntityFrameworkCore;

namespace LumaTasks.Repository.Context
{
    public class AlunoDbContext : DbContext
    {
        public AlunoDbContext(DbContextOptions<AlunoDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Aula> Aulas { get; set; }
    }
}
