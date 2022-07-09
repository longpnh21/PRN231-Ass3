using Microsoft.AspNetCore.Mvc;

namespace eStore.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

            public IActionResult Edit([FromQuery] int id)
        {
            return View();
        }

        public IActionResult Delete([FromQuery] int id)
        {
            return View();
        }
    }
}
