namespace products_ms.Repositories;

public interface IFirestroeRepository<T>
{
    T Add(T model);
    bool Delete(T model);
    T Get(T model);
    bool Update(T model);
}