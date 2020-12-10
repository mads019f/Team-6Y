using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Middleware
{
    public class LoggerOptions 
    {
        public string FileName { get; set; }

    }

    public class LoggerMiddleware
    {
        //public delegate Task RequestDelegate(HttpContext context);
        private readonly RequestDelegate _next;
        private readonly LoggerOptions _options;

        public LoggerMiddleware(RequestDelegate next, IOptions<LoggerOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            var requestLogMessage = $"REQUEST:\n{request.Method} - {request.Path.Value}{request.QueryString}";
            requestLogMessage += $"\nContentType: {request.ContentType ?? "Not specified"}";
            requestLogMessage += $"\nHost: {request.Host}";
            File.AppendAllText(_options.FileName, $"{DateTime.Now.ToString("s")}\n{requestLogMessage}");

            await _next(context);

            var response = context.Response;
            var responseLogMessage = $"\nRESPONSE:\nStatus Code: {response.StatusCode}";
            File.AppendAllText(_options.FileName, $"{responseLogMessage}\n\n");
        }
    }
    public static class LoggerMiddlewareExstensions
    {
        public static IApplicationBuilder UseMyFileLogger(this IApplicationBuilder app, LoggerOptions options)
        {
            return app.UseMiddleware<LoggerMiddleware>(Options.Create(options));
        }
    }
}
