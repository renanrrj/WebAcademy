using Academia.Dados;

namespace Academia.Repositorio
{
    public class ProfessorRepositorio
    {
        private readonly ContextoBanco _contextoBanco;

        public ProfessorRepositorio(ContextoBanco ContBanco)
        {
            _contextoBanco = ContBanco;
        }
    }
}
