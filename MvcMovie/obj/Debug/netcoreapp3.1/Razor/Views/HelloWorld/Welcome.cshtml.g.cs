#pragma checksum "C:\Users\jows1\source\repos\MvcMovie\HomeworkCalculator\MvcMovie\Views\HelloWorld\Welcome.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c0367bd6083db3b7692ae4c79898b0ac14828f6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HelloWorld_Welcome), @"mvc.1.0.view", @"/Views/HelloWorld/Welcome.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\jows1\source\repos\MvcMovie\HomeworkCalculator\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jows1\source\repos\MvcMovie\HomeworkCalculator\MvcMovie\Views\_ViewImports.cshtml"
using MvcMovie.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c0367bd6083db3b7692ae4c79898b0ac14828f6", @"/Views/HelloWorld/Welcome.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"686ad2e38abb871af45be971520cc6c3156da389", @"/Views/_ViewImports.cshtml")]
    public class Views_HelloWorld_Welcome : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\jows1\source\repos\MvcMovie\HomeworkCalculator\MvcMovie\Views\HelloWorld\Welcome.cshtml"
  
    ViewData["Title"] = "Movie List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n\r\n    <h2>Welcome to welcome!</h2>\r\n\r\n    <ul>\r\n");
#nullable restore
#line 10 "C:\Users\jows1\source\repos\MvcMovie\HomeworkCalculator\MvcMovie\Views\HelloWorld\Welcome.cshtml"
         for (int i = 0; i < (int)ViewData["Count"]; i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <li> ");
#nullable restore
#line 11 "C:\Users\jows1\source\repos\MvcMovie\HomeworkCalculator\MvcMovie\Views\HelloWorld\Welcome.cshtml"
          Write(ViewData["Name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </li> ");
#nullable restore
#line 11 "C:\Users\jows1\source\repos\MvcMovie\HomeworkCalculator\MvcMovie\Views\HelloWorld\Welcome.cshtml"
                                       }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
