using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using System;
using System.Threading.Tasks;
using CalcOnline.Data.Interface;
using System.IO;
using System.Text;
using JsonLibrary;
using System.Text.Json;

namespace CalcOnline.Middleware
{
    public class CalculatorMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ICalculator _calculator;

        public CalculatorMiddleware(RequestDelegate next, ICalculator calculator)
        {
            _next = next;
            _calculator = calculator; 
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                using (var reader = new StreamReader(context.Request.Body))
                {
                    var body = await reader.ReadToEndAsync();
                    var data = JsonSerializer.Deserialize<JsonData>(body);

                    var res = _calculator.Calculate( left: Convert.ToDouble(data.firstValue), 
                                                     action: data.oper, 
                                                     right: Convert.ToDouble(data.secondValue));

                    var resBytes = Encoding.UTF8.GetBytes(res.ToString());
                    await context.Response.Body.WriteAsync(resBytes);
                }
            }catch(Exception ex) { Console.WriteLine(ex.Message); }

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
