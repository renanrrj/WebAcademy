﻿using Academia.Dados;

namespace Academia.Repositorio
{
    public class ClienteRepositorio 
    {
        private readonly ContextoBanco _contextoBanco;

        public ClienteRepositorio(ContextoBanco ContBanco)
        {        
            _contextoBanco = ContBanco;
        }
    }
}
