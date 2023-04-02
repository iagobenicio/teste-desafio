namespace teste_desafio.failures
{
    public class EntityNotFound : Exception
    {
        public EntityNotFound(string? e) : base (e){}
    }
}