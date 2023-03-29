using teste_desafio.viewmodel;

namespace teste_desafio.service
{
    public interface ITurmaService
    {   
        public void Save(TurmaViewModel turmaViewModel);
        public void Update(TurmaViewModel turmaViewModel, int id);
        public void Delete(int turmaId);
        public List<TurmaViewModel> GetAll();
    }
}