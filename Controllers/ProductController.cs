using CRUDAppAssesment.Models;
using CRUDAppAssesment.Products;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAppAssesment.Controllers
{
    [ApiController]
    [Route("api/product")]   
    public class ProductController : ControllerBase
    {
        //ProductImplentation is the DBOperations Class
        //_Products is an instance of ProductImplentation
        public IProducts _Products;
        public ProductController(IProducts ProductInterface)
        {
            _Products = ProductInterface;
        }
        // Listing all Products
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var AllProducts = _Products.ListAllProducts();
            return Ok(AllProducts);
        }
        // Return a Single Product with ID
        [HttpGet("{ID}")]
        public IActionResult GetOneProduct(int ID)
        {
            var Product = _Products.ReadProduct(ID);
            return Ok(Product);
        }
        // Update a Product with Product ID
        [HttpPut("{ID}")]
        public IActionResult UpdateProduct(int ID,[FromBody] ProductAsBodyDto UpdatedProduct)
        {
            var ProductToUpdate = _Products.ReadProduct(ID);
            if (ProductToUpdate == null)
            {
                return NotFound();
            }
            if (UpdatedProduct.Quantity < 0)
            {
                ModelState.AddModelError("Quantity", "Cannot be less than Zero");
            }
            if(UpdatedProduct.Name == null || UpdatedProduct.Name == null)
            {
                ModelState.AddModelError("Error", "Both fields are Mandatory");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var UpdateResult = _Products.UpdateProduct(ID, UpdatedProduct);
            return NoContent();
        }
        // Create a Product
        [HttpPost]
        public IActionResult CreateNewProduct([FromBody]Product NewProduct)
        {
            var CreatedProduct = _Products.CreateProduct(NewProduct);
            return Ok();
            //should be changed to Created type return method
        }
        // Delete the Product
        [HttpDelete("{ID}")]
        public IActionResult DeleteProduct(int ID)
        {
            var ProductToDelete = _Products.ReadProduct(ID);
            if (ProductToDelete == null)
            {
                return NotFound();
            }
            var Result = _Products.DeleteProduct(ProductToDelete);
            return Ok();
        }

    }
}
