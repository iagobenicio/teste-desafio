using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_desafio.domain.entities;

namespace teste_desafio.repositories
{
    public interface IMatriculaRepository : IRepository<Matricula>
    {
        bool PossuiMatricula(int alunoId, int turmaId);
    }
}