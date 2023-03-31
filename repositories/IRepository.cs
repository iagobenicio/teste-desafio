namespace teste_desafio.repositories
{
    public interface IRepository<T> where T : class 
    {
        public List<T> GetAll();
        void Register(T entidade);
        void Update(T entidade, int id);
        void Delete(int id);
    }
}