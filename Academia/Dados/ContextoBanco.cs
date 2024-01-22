using Academia.Models;
using Microsoft.EntityFrameworkCore;

namespace Academia.Dados
{
    public class ContextoBanco : DbContext
    {
        public ContextoBanco(DbContextOptions<ContextoBanco> opt) : base(opt)
        {

        }

        public DbSet<ClienteModel> Tb_Clientes { get; set; }
        public DbSet<ProfessorModel> Tb_Professores { get; set; }
        public DbSet<ModalidadeModel> Tb_Modalidades { get; set; }
    }
}
