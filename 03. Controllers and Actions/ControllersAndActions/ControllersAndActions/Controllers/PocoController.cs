using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace ControllersAndActions.Controllers
{
    public class PocoController
    {
        /* The Most Important ControllerContext Properties
        ActionDescriptor: This property returns an ActionDescriptor object, which describes the action
        method.
        HttpContext: This property returns an HttpContext object, which provides details of the HTTP
        request and the HTTP response that will be sent in return.
        ModelState: This property returns a ModelStateDictionary object, which is used to validate
        data sent by the client.
        RouteData: This property returns a RouteData object that describes the way that the routingsystem has processed the request
        */
        [ControllerContext]
        public ControllerContext ControllerContext { get; set; }

        public ViewResult Index() => new ViewResult()
        {
            ViewName = "Result",
            ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(),new ModelStateDictionary())
            {
                Model = $"This is a POCO controller"
            }
        };

        public ViewResult Headers() =>
                new ViewResult()
                {
                    ViewName = "DictionaryResult",
                    ViewData = new ViewDataDictionary(
                                    new EmptyModelMetadataProvider(),
                                    new ModelStateDictionary())
                    {
                        Model = ControllerContext.HttpContext.Request.Headers
                         .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First())
                    }
                };
    }
}
