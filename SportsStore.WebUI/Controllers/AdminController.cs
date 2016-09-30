using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["massege"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is smth wrong with data values
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product()); // we call the Edit view with empty patameter object so the fields will be empty too.
        }

        [HttpPost]
        public ActionResult Delete(int productID)
        {
            Product deleteProduct = repository.DeleteProduct(productID);
            if (deleteProduct != null)            
                TempData["message"] = $"{deleteProduct.Name} was deleted";
            return RedirectToAction("Index");
        }
    }
}