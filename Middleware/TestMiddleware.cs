using Dotnet6MiddlewareExampleApi.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
//https://devblogs.microsoft.com/dotnet/re-reading-asp-net-core-request-bodies-with-enablebuffering/
namespace Dotnet6MiddlewareExampleApi.Middleware
{
    public class TestMiddleware : IMiddleware
    {
        private Stream jsonString;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            context.Request.EnableBuffering();

            // Leave the body open so the next middleware can read it.
            using (var reader = new StreamReader(
                context.Request.Body,
                encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
           
                leaveOpen: true))
            {
                var body = await reader.ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<Student>(body);
                // Do some processing with body…
                context.Items["requestBody"] = data;
                // Reset the request body stream position so the next middleware can read it
                context.Request.Body.Position = 0;


                // Store the request body in the HttpContext.Items dictionary
              
                await next(context);
            }


         

            //if (false)
            //{
               
            //}
            //else if(false)
            //{
            //    context.Response.StatusCode = 400;
            //    await context.Response.WriteAsync("Bad request");
            //    return;
            //}
            //else if (true)
            //{
            //    context.Response.StatusCode = 400;
            //    context.Response.WriteAsync("Bad Request");
            //    context.Response.ContentType = "application/json";
            //    var error = new { error = "Invalid request" };
            //    await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(error));
            //}
        }
    }

}
