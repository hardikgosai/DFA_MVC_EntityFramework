using Getri_DFA_EntityFramework.Models;
using Getri_DFA_EntityFramework.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Getri_DFA_EntityFramework.Controllers
{
    public class ProductController : Controller
    {        
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public IActionResult GetAllProducts()
        {
            List<Product> products = new List<Product>();
            products = productRepository.GetProducts().ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View("~/Views/Product/CreateProduct.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProducts(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.InsertProduct(product);
                return RedirectToAction("GetAllProducts");
            }
            return View("~/Views/Product/CreateProduct.cshtml");
        }
    }
}
