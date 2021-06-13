using CRUDAppAssesment.Contexts;
using CRUDAppAssesment.Models;
using System.Collections.Generic;
using System.Linq;
//This Class is used only for operations that interact with database

namespace CRUDAppAssesment.Products
{
    public class ProductsImplementation : IProducts
    {
        //ProductContext is the DBConnection Class
        //_Product is an instance of ProductContext
        private ProductContext  _ProductDBConnectionInstance;

        //Constructor to initialize the ProductContext instance
        public ProductsImplementation(ProductContext product)
        {
            _ProductDBConnectionInstance = product;
        }

        //Create New Product in Database
        public Product CreateProduct(Product product)
        {
            _ProductDBConnectionInstance.Products.Add(product);
            _ProductDBConnectionInstance.SaveChanges();
            return product;
        }
        //Create Delete a Product
        public int DeleteProduct(Product product)
        {
            _ProductDBConnectionInstance.Products.Remove(product);
            _ProductDBConnectionInstance.SaveChanges();
            return 1;
        }
        //Return all Products as a list
        public List<Product> ListAllProducts()
        {
            var AllProducts = _ProductDBConnectionInstance.Products.OrderBy(p=>p.Name).ToList();
            return AllProducts;
        }
        //Return a single Product with the Matching ID
        public Product ReadProduct(int ID)
        {
            var SingleProduct = _ProductDBConnectionInstance.Products.Find(ID);
            return SingleProduct;
        }
        //Update the product with the given ID and return the updated product
        public Product UpdateProduct(int ID,ProductAsBodyDto product)
        {
            var ProductToUpdate = _ProductDBConnectionInstance.Products.Find(ID);
            ProductToUpdate.Name = product.Name;
            ProductToUpdate.Quantity = product.Quantity;
            _ProductDBConnectionInstance.Update(ProductToUpdate);
            _ProductDBConnectionInstance.SaveChanges();
            return _ProductDBConnectionInstance.Products.Find(ID);
        }
    }
}
