using teste_desafio.domain.entities;
using teste_desafio.repositories;
using teste_desafio.viewmodel;

namespace teste_desafio.service
{
    public class AlunoService : IAlunoService
    {
        private readonly AlunoRepository _repository;

        public AlunoService(AlunoRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int alunoId)
        {
            _repository.Delete(alunoId);
        }

        public List<AlunoViewModel> GetAll()
        {   
            var alunos = _repository.GetAll();
            
            if(alunos == null)
            {
                throw new Exception(message: "Nenhum aluno encontrado");
            }

            return MapperToViewModel(alunos);
        }

        public void Save(AlunoViewModel alunoViewModel)
        {
           var countCpf = _repository.CheckExistCpf(alunoViewModel.Cpf!);

           if (countCpf == 1)
           {
             throw new Exception("Este aluno já esta cadastrado");
           }

            var alunoEntity = MapperToEntity(alunoViewModel);

            _repository.Save(alunoEntity);

        }

        public void Update(AlunoViewModel alunoViewModel)
        {
            var countCpf = _repository.CheckExistCpf(alunoViewModel.Cpf!);

            if (countCpf == 1)
            {
                throw new Exception("");
            }
        }


        private Aluno MapperToEntity(AlunoViewModel alunoViewModel)
        {
            Aluno aluno = new Aluno();
            aluno.Id = alunoViewModel.Id;
            aluno.Cpf = alunoViewModel.Cpf;
            aluno.Email = alunoViewModel.Email;
            aluno.Name = alunoViewModel.Name;

            return aluno;
        }

        private List<AlunoViewModel> MapperToViewModel(List<Aluno> alunos)
        {   
            AlunoViewModel alunoViewModel = new ();
            List<AlunoViewModel> alunosViewModels = new ();

            foreach (var aluno in alunos)
            {   
                alunoViewModel.Id = aluno.Id;
                alunoViewModel.Cpf = aluno.Cpf;
                alunoViewModel.Name = aluno.Name;
                alunoViewModel.Email = aluno.Email; 

                alunosViewModels.Add(alunoViewModel);
            }
            return alunosViewModels;
        }
    }
}