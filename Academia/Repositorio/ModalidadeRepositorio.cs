using Academia.Dados;

namespace Academia.Repositorio
{
    public class ModalidadeRepositorio
    {
        private readonly ContextoBanco _contextoBanco;

        public ModalidadeRepositorio(ContextoBanco ContBanco)
        {
            _contextoBanco = ContBanco;
        }
    }
}
