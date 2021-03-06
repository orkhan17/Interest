using Microsoft.AspNetCore.Http;

namespace Project.API.Helpers
{
    public static class Extensions
    {
         public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}