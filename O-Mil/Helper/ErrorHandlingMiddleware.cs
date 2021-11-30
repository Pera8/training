using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace O_Mil.Helper
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly AppSettings _appSettings;

        public ErrorHandlingMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            this.next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (exception is UnauthorizedAccessException) code = HttpStatusCode.Unauthorized;
            else if (exception is HttpRequestException) code = HttpStatusCode.Forbidden;
            else if (exception is KeyNotFoundException) code = HttpStatusCode.NotFound;
            else if (exception is ArgumentException) code = HttpStatusCode.BadRequest;

            var result = JsonConvert.SerializeObject(new { message = exception.Message, StatusCode = (int)code });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
