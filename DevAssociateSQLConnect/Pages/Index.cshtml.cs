using DevAssociateSQLConnect.Models;
using DevAssociateSQLConnect.Models.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevAssociateSQLConnect.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;

        public void OnGet()
        {
            var productService = new ProductService();
            Products = productService.GetProducts();
        }
    }
}