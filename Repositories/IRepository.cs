namespace VisionStore.Repositories
{
    public interface IRepository<T> where T : class
    {
        public abstract T Create(T entity);
    }
}
