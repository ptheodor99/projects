#pragma checksum "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\PageSelect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53e63c2180841b623fac2fca18b5d22d345d5ec9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_PageSelect), @"mvc.1.0.view", @"/Views/Home/PageSelect.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53e63c2180841b623fac2fca18b5d22d345d5ec9", @"/Views/Home/PageSelect.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df12113f69d6a851cbb203092c4b2fcdc6d287c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_PageSelect : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\PageSelect.cshtml"
  
    ViewData["Title"] = "Page Select";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<p>Unde vrei sa mergi?</p>
<ul>
    <li><a href=""/Home/Danger"" style=""text-decoration: none; color:black;"">Limite maxime adminse</a></li>
    <li><a href=""/Home/RealTimeData"" style=""text-decoration: none; color:black;"">Date in tip real</a></li>
    <li><a href=""/Home/AlterTabels"" style=""text-decoration: none; color:black;"">Modifica date</a></li>
    <li><a href=""/Home/ViewMalicious"" style=""text-decoration: none; color:black;"">Vezi timpii de functionare</a></li>
    <li><a href=""/Home/AlterCommands"" style=""text-decoration: none; color:black;"">Comanda sistemul</a></li>
    <li><a href=""/Home/ViewStatistics"" style=""text-decoration: none; color:black;"">Vezi statistici</a></li>
</ul>

");
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
