#pragma checksum "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\Errors.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3dc3637b127de3aa4d086b4f2f62c7a57d7f9420"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Errors), @"mvc.1.0.view", @"/Views/Home/Errors.cshtml")]
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
#line 1 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\_ViewImports.cshtml"
using SafeWorkers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\_ViewImports.cshtml"
using SafeWorkers.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dc3637b127de3aa4d086b4f2f62c7a57d7f9420", @"/Views/Home/Errors.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df12113f69d6a851cbb203092c4b2fcdc6d287c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Errors : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\Errors.cshtml"
  
    ViewData["Title"] = "Alter Tabels";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1 style=\"color:red;\"><b>");
#nullable restore
#line 6 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\Errors.cshtml"
                     Write(TempData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h1>\r\n\r\n\r\n<a href=\"/Home/PageSelect\" style=\"text-decoration:none; color: black;\">Inapoi la selectarea paginilor</a>\r\n");
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