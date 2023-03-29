using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste_desafio.service
{
    public interface IMatriculaService
    {
        void MatricularAluno(int alunoId, int turmaId);
    }
}