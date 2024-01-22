using Academia.Dados;
using Academia.Models;

namespace Academia.Repositorio
{
    public class ClienteRepositorio 
    {
        private readonly ContextoBanco _contextoBanco;

        public ClienteRepositorio(ContextoBanco ContBanco)
        {        
            _contextoBanco = ContBanco;
        }
        public ClienteModel AdicionarCliente(ClienteModel CliModel)
        {
            _contextoBanco.Tb_Clientes.Add(CliModel);
            _contextoBanco.SaveChanges();
            return CliModel;

        }        

    }
}
