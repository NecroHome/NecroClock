using Microsoft.AspNetCore.Builder;
using NecroClock.Application.Middleware;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroClock.Application.Extensions
{
    public static  class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(
            this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
