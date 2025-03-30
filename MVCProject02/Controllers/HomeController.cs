using Microsoft.AspNetCore.Mvc;
using MVCProject02.Models;

namespace MVCProject02.Controllers
{
    public class HomeController : Controller
    {

        //baseURl+Home+Index
        public IActionResult Index()
        {
            return View(); //return view with the same action's name
            //return View(new Movie()); //return view with the same action's name and bind the data to the model
            //return View("ViewName"); // return view with the provided name
            //return View("ViewName" , new Movie() ); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
