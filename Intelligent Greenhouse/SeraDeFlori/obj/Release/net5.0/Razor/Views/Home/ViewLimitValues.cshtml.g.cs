#pragma checksum "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\ViewLimitValues.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f96d5588be507cc18ec28a53544a7d8949209c87"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewLimitValues), @"mvc.1.0.view", @"/Views/Home/ViewLimitValues.cshtml")]
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
#line 1 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\_ViewImports.cshtml"
using SeraDeFlori;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\_ViewImports.cshtml"
using SeraDeFlori.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f96d5588be507cc18ec28a53544a7d8949209c87", @"/Views/Home/ViewLimitValues.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"251a83e041619dbe55af0574e46ed1d14a1b36ab", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewLimitValues : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\ViewLimitValues.cshtml"
  
    ViewData["Title"] = "View Limit Values";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<p>Valorile limita admise pentru mediu sunt:</p>\r\n\r\n<ul>\r\n    <li>Temperatura minima: ");
#nullable restore
#line 8 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\ViewLimitValues.cshtml"
                       Write(ViewBag.LimitValuesObject.MinTemp);

#line default
#line hidden
#nullable disable
            WriteLiteral(" grade Celsius</li>\r\n    <li>Temperatura maxima: ");
#nullable restore
#line 9 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\ViewLimitValues.cshtml"
                       Write(ViewBag.LimitValuesObject.MaxTemp);

#line default
#line hidden
#nullable disable
            WriteLiteral(" grade Celsius</li>\r\n    <li>Umiditatea minima: ");
#nullable restore
#line 10 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\ViewLimitValues.cshtml"
                      Write(ViewBag.LimitValuesObject.MinHumidity);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</li>\r\n    <li>Umiditatea maxima: ");
#nullable restore
#line 11 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\ViewLimitValues.cshtml"
                      Write(ViewBag.LimitValuesObject.MaxHumidity);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</li>\r\n    <li>Umiditatea solului minima: ");
#nullable restore
#line 12 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\ViewLimitValues.cshtml"
                              Write(ViewBag.LimitValuesObject.MinSoilHumidity);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</li>\r\n    <li>Umiditatea solului maxima: ");
#nullable restore
#line 13 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\ViewLimitValues.cshtml"
                              Write(ViewBag.LimitValuesObject.MaxSoilHumidity);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</li>\r\n    <li>Iluminare minima: ");
#nullable restore
#line 14 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\ViewLimitValues.cshtml"
                     Write(ViewBag.LimitValuesObject.MinLightPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</li>\r\n</ul>\r\n\r\n<a href=\"/Home/WhereToGo\" style=\"text-decoration:none; color: black;\">Inapoi</a>");
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
