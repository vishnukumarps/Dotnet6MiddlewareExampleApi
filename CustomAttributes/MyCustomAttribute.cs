using Microsoft.AspNetCore.Mvc.Filters;

namespace Dotnet6MiddlewareExampleApi.CustomAttributes
{
    public class MyCustomAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Get the request body from the HttpContext.Items dictionary
            string requestBody = context.HttpContext.Items["requestBody"] as string;

            // Do something with the request body
            // ...
        }
    }

    public class MyCustomAttribute2 : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Get the request body
            var request = context.HttpContext.Request;
            string requestBody = new StreamReader(request.Body).ReadToEnd();

            // Get the request header
            string requestHeader = request.Headers["MyHeader"];

            // Do something with the request body and header
            // ...
        }
    }
}
