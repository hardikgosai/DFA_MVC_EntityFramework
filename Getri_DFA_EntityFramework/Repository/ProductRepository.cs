using Getri_DFA_EntityFramework.EntityFramework;
using Getri_DFA_EntityFramework.Models;

namespace Getri_DFA_EntityFramework.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly GetridfaContext dbContext;
        
        public ProductRepository(GetridfaContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public bool DeleteProduct(int productId)
        {
            var product = dbContext.Products.Find(productId);
            if (product == null)
            {
                return false;
            }
            else
            {
                var result = dbContext.Products.Remove(product);
                dbContext.SaveChanges();
                return true;
            }            
        }

        public Product GetProductByID(int productId)
        {
            return dbContext.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            products = dbContext.Products.ToList();
            return products;
        }

        public Product InsertProduct(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            var productToUpdate = dbContext.Products.Find(product.Id);
            if (productToUpdate == null)
            {
                return null;
            }
            else
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                productToUpdate.Price = product.Price;
                productToUpdate.Quantity = product.Quantity;
            }
            dbContext.Products.Update(productToUpdate);
            dbContext.SaveChanges();
            return productToUpdate;
        }
    }
}
