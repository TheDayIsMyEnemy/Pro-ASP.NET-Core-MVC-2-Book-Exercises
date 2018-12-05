using Microsoft.AspNetCore.Mvc;
using UrlRouting.Models;

namespace UrlRouting.Controllers
{
    [Route("app/[controller]/actions/[action]/{id:weekday?}")]
    public class CustomerController : Controller
    {
        /*
        There are two important points to note.The first is that when you use the Route attribute, the value you
        provide to configure the attribute is used to define a complete route so that myroute becomes the complete
        URL to reach the Index action method.The second point to note is that using the Route attribute prevents
        the default routing configuration from being used so that the Index action method can no longer be reached
        by using the /Customer/Index URL.
        */

        /*
         Using the [controller] token in the argument for the Route attribute is rather like using a nameof
            expression and allows for the route to the controller to be specified without hard-coding the class name. 
         */

        //[Route("[controller]/MyAction")]
        public ViewResult Index()
        {
            return View("Result",new Result {
                Controller = nameof(CustomerController),
                Action = nameof(Index)
            });
        }

        public ViewResult List()
        {
            return View("Result", new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(List)
            });
        }
    }
}
