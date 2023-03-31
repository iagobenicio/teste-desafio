using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste_desafio.failures
{
    public class EntityNotFound : Exception
    {
        public EntityNotFound(string? e) : base (e){}
    }
}