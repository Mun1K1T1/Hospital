using Laboratory2_Data.

namespace Repository_Generic.Repositories
{
    public interface IRepository<T> where T : EEntity
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate = null);
        void Create(T Entity);
        void Update(T Entity);
        void Delete(Guid key);
        T GetFirst(Func<T, bool> predicate);
    }
}
