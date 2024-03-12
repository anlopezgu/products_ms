using products_ms.Models;

namespace products_ms.Repositories;

public class ProductRepository : IFirestroeRepository<Product>
{
    private readonly string CollectionName = "products";
    private readonly FirestoreRepository firestoreRepository;

    public ProductRepository()
    {
        firestoreRepository = new FirestoreRepository(CollectionName);
    }

    public Product Add(Product product)
    {
        return firestoreRepository.Add(product);
    }

    public bool Delete(Product model)
    {
        return firestoreRepository.Delete(model);
    }

    public Product Get(Product product)
    {
        return firestoreRepository.Get(product);
    }


    public bool Update(Product model)
    {
        return firestoreRepository.Update(model);
    }

    public bool UpdatePayment(Product model)
    {
        return firestoreRepository.Update(model);
    }
}