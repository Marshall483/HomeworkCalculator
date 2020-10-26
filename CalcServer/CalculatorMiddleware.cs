using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public void WriteResultAtHeaders(HttpContext context, string result) {
            if (result != "Fail") context.Response.Headers.Add("result", result);
            else context.Response.Headers.Add("result", result.ToString()); }

 
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Query.Count == 0)
                return;

            string first = context.Request.Query["first"];
            string second = context.Request.Query["second"];
            string action = context.Request.Query["action"];


            var res = Calculator.Calculate(int.Parse(first), int.Parse(second), action);

            if (res != int.MinValue)
            {
                WriteResultAtHeaders(context, res.ToString());
                context.Response.StatusCode = (int)HttpStatusCode.OK;
            }
            else
                WriteResultAtHeaders(context, "Fail");

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
