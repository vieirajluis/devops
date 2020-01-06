using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MySqlEFCore.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration config;

        public HomeController(IConfiguration config)
        {
            this.config = config;
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult MySqlData([FromServices] TestContext context)
        {
          
            return View(context.TestData.ToList());
        }

      
    }
}