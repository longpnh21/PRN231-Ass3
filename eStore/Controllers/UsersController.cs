using Microsoft.AspNetCore.Mvc;

namespace eStore.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit([FromQuery] int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete([FromQuery] int id)
        {
            return View();
        }
    }
}
