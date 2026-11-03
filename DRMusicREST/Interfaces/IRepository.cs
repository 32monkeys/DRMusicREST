namespace DRMusicREST.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T obj);
        T Update(int id,T obj);
        T Delete(T obj);
    }
}
