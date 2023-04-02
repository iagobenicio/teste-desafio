namespace teste_desafio.repositories
{
    public interface IRepository<T> where T : class 
    {
        public List<T> GetAll();
        Task Register(T entidade);
        Task Update(T entidade, int id);
        Task Delete(int id);
    }
}