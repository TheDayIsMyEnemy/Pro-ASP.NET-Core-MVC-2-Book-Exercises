using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    {
        public ViewResult Index() => View("Result", "This is a derived controller");

        /*Commonly Used HttpRequest Properties
        Path: This property returns the path section of the request URL.
        QueryString: This property returns the query string section of the request URL.
        Headers: This property returns a dictionary of the request headers, indexed by name.
        Body: This property returns a stream that can be used to read the request body.
        Form: This property returns a dictionary of the form data in the request, indexed by name.
        Cookies: This property returns a dictionary of the request cookies, indexed by name.
        */
        public ViewResult Headers() 
            => View("DictionaryResult", Request.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First()));
    }
}
