using AutoMapper;
using teste_desafio.domain.entities;
using teste_desafio.repositories;
using teste_desafio.viewmodel;

namespace teste_desafio.service
{
    public class TurmaService : ITurmaService
    {   
        private readonly TurmaRepository _repository;
        private readonly IMapper _mapper;
        public TurmaService(TurmaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Delete(int turmaId)
        {
            _repository.Delete(turmaId);
        }

        public List<TurmaViewModel> GetAll()
        {
           var turmas = _repository.GetAll();

           if (turmas == null)
           {
                throw new Exception("Nenhuma turma encontrada");
           }
           var turmasViewModel = _mapper.Map<List<TurmaViewModel>>(turmas);

           return turmasViewModel;
        }

        public void Save(TurmaViewModel turmaViewModel)
        {     

            var turmaEntity = _mapper.Map<Turma>(turmaViewModel);

            _repository.Save(turmaEntity);
        }

        public void Update(TurmaViewModel turmaViewModel, int id)
        {
            var turmaEntity = _mapper.Map<Turma>(turmaViewModel);

            _repository.Update(turmaEntity,id);
        }
    }
}