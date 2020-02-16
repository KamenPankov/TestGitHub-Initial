namespace Andreys.App.Controllers
{
    using Andreys.Services.Products;
    using Andreys.ViewModels.Products;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.View();
            }
            else
            {
                ProductsListViewModel productsListViewModel = new ProductsListViewModel()
                {
                    Products = this.productsService.All()
                };

                return this.View(productsListViewModel, "Home");
            }
            
        }
    }
}
