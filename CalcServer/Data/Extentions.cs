using CalcOnline.Middleware;
using Microsoft.AspNetCore.Builder;

namespace CalcOnline.Data.Extentions
{
    public static class CalculatorExtention
    {
        public static IApplicationBuilder UseCalculator(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CalculatorMiddleware>();
        }
    }
}
