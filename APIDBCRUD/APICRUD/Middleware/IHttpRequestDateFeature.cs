using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICRUD.Middleware
{
    interface IHttpRequestDateFeature 
    {
        DateTime RequestDate { get; }

    }

    public class HttpRequestDateFeature : IHttpRequestDateFeature
    {
        public DateTime RequestDate { get; }

        public HttpRequestDateFeature()
        {

            RequestDate = ConvertTime();
        }

        public DateTime ConvertTime()
        {
           
           return DateTime.Parse(DateTime.Today.ToString("MM/dd/yyyy"));
        }
    }

    public class RequestDateMiddleWare
    {
        private readonly RequestDelegate _next;

        public RequestDateMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            var httpRequestDateFeature = new HttpRequestDateFeature();
            context.Features.Set<IHttpRequestDateFeature>(httpRequestDateFeature);

            // Call the next delegate/middleware in the pipeline
            return this._next(context);
        }
    }

    public static class RequestDateMiddlewareExtension
    {
        public static IApplicationBuilder UseDateConverter(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestDateMiddleWare>();
        }
    }

    
}

