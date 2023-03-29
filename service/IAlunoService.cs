using teste_desafio.viewmodel;

namespace teste_desafio.service
{
    public interface IAlunoService
    {
        public void Save(AlunoViewModel alunoViewModel);
        public void Update(AlunoViewModel alunoViewModel);
        public void Delete(int alunoId);
        public List<AlunoViewModel> GetAll();
    }
}