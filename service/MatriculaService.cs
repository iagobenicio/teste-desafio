using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_desafio.domain.entities;
using teste_desafio.repositories;

namespace teste_desafio.service
{
    public class MatriculaService : IMatriculaService
    {
        
        private readonly IMatriculaRepository matriculaRepository;

        public MatriculaService(IMatriculaRepository matriculaRepository)
        {
            this.matriculaRepository = matriculaRepository;
            
        }

        public void MatricularAluno(int alunoId, int turmaId)
        {
            if (matriculaRepository.PossuiMatricula(alunoId,turmaId))
            {
                throw new Exception("matricula já existe");
            }
            var matricula = new Matricula
            {
                AlunoId = alunoId,
                TurmaId = turmaId
            };
            matriculaRepository.Save(matricula);
        }
    }
}