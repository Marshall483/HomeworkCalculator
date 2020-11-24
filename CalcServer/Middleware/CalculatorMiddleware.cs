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
            using (var reader = new StreamReader(context.Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var data = JsonSerializer.Deserialize<JsonData>(body);

                var res = _calculator.Calculate(left: Convert.ToDouble(data.FirstValue),
                                                 action: data.Oper,
                                                 right: Convert.ToDouble(data.SecondValue));

                var resBytes = Encoding.UTF8.GetBytes(res.ToString());
                await context.Response.Body.WriteAsync(resBytes);
            }
        }
    }
}
