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

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = productRepository.GetProductByID(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View("~/Views/Product/EditProduct.cshtml", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.UpdateProduct(product);
                return RedirectToAction("GetAllProducts");
            }
            return View("~/Views/Product/EditProduct.cshtml", product);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = productRepository.GetProductByID(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View("~/Views/Product/DeleteProduct.cshtml", product);
        }

        public IActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = productRepository.GetProductByID(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View("~/Views/Product/ProductDetails.cshtml", product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            productRepository.DeleteProduct(id);
            return RedirectToAction("GetAllProducts");
        }
    }
}
