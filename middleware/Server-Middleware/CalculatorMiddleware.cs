using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CalcOnline.Middleware
{
    public class CalculatorMiddleware
    {

        private readonly RequestDelegate _next;

        public CalculatorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string first = context.Request.Query["first"];
            string second = context.Request.Query["second"];
            string action = context.Request.Query["action"];

            if (first == null || second == null || action == null)
                return;

            var res = Calculator.Calculate(int.Parse(first), int.Parse(second), action);

            await _next.Invoke(context);
        }
    }

    public static class CalculatorExtention
    {
        public static IApplicationBuilder UseCalculator(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CalculatorMiddleware>();
        }
    }
}
