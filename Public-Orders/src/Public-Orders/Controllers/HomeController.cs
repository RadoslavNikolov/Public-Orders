namespace PublicOrders.Controllers
{
    using System.Linq;
    using Data.AppData.UnitOfWork;
    using Microsoft.AspNet.Mvc;

    [RequireHttps]
    public class HomeController : BaseController
    {
        public HomeController(IPublicOrdersData data)
            : base(data)
        {
            
        }
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult About()
        {
            this.ViewData["Message"] = "Your application description page.";

            return this.View();
        }

        public IActionResult Contact()
        {
            this.ViewData["Message"] = "Your contact page.";

            return this.View();
        }

        public IActionResult Error()
        {
            return this.View();
        }
    }
}
