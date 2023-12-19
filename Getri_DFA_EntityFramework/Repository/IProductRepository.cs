using Getri_DFA_EntityFramework.Models;

namespace Getri_DFA_EntityFramework.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int productId);
        Product InsertProduct(Product product);
        bool DeleteProduct(int productId);
        Product UpdateProduct(Product product);
    }
}
