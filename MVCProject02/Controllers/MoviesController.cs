using Microsoft.AspNetCore.Mvc;

namespace MVCProject02.Controllers
{
    public class MoviesController : Controller
    {
        // Action : Public , Non Static method inside the contorller

        // to execute any action => BaseUrl+ControllerName+ActionName/?
        
        public string Index(int id) 
        {
            return $"Hello {id}";
        }

        //public String GetMovie(int? id, string name)
        //{
        //    if (id is not null)
        //        return $"Movie {id}/{name}";
        //    else
        //        return "No Movie";
        //}

        public ContentResult GetMovie(int? id, string name)
        {
            //ContentResult result=new ContentResult();
            //result.Content = $"Movie {id} </br> {name}";
            //result.ContentType = "text/html" ;
            //result.StatusCode = 900 ;

            //return result ;

            return Content($"Movie {id} </br> {name}", "text/html");

        }

        public IActionResult Movie(int id)
        {
            if (id == 0)
                return BadRequest();
            else if (id < 10)
                return NotFound();
            else
                return Content($"Movie {id}");
        }

        public IActionResult TestRedirectAction()
        {
            return Redirect("https://vbn3.t4ce4ma.shop/");
        }

        public IActionResult TestRedirectToGetMovie() 
        {
            return RedirectToAction("GetMovie");
        }

        //[HttpGet]
        public IActionResult TestModelBinding([FromRoute] int id, [FromQuery] string name) 
        {
            return Content($"Movie ID {id} , Name {name}");
        }
    }
}
