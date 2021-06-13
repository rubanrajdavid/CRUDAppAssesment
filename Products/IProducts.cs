using CRUDAppAssesment.Models;
using System.Collections.Generic;

namespace CRUDAppAssesment.Products
{
    public interface IProducts
    {
        List<Product> ListAllProducts();
        Product CreateProduct(Product product);
        Product ReadProduct(int ID);
        Product UpdateProduct(int ID , ProductAsBodyDto product);
        int     DeleteProduct(Product product);
    }
}
