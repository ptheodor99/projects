#pragma checksum "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterTabels.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47fa2e4dbb3dc36e80ee94b8ecb26a60a56a7247"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AlterTabels), @"mvc.1.0.view", @"/Views/Home/AlterTabels.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47fa2e4dbb3dc36e80ee94b8ecb26a60a56a7247", @"/Views/Home/AlterTabels.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df12113f69d6a851cbb203092c4b2fcdc6d287c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AlterTabels : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterTabels.cshtml"
  
    ViewData["Title"] = "Alter Tabels";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<p>Alege ce tabel vrei sa modifici:</p>

<ul>
    <li><a href=""/Home/AlterDanger"" style=""text-decoration:none;color:black;"">Aici poti modifica tabelul cotelor maxime admise pentru gaze.</a></li>
    <li><a href=""/Home/AlterMQ2_1"" style=""text-decoration:none;color:black;"">Aici poti vizualiza tabelul pentru MQ2 din Modulul 1.</a></li>
    <li><a href=""/Home/AlterMQ2_2"" style=""text-decoration:none;color:black;"">Aici poti vizualiza tabelul pentru MQ2 din Modulul 2.</a></li>
    <li><a href=""/Home/AlterMQ9_1"" style=""text-decoration:none;color:black;"">Aici poti vizualiza tabelul pentru MQ9 din Modulul 1.</a></li>
    <li><a href=""/Home/AlterMQ9_2"" style=""text-decoration:none;color:black;"">Aici poti vizualiza tabelul pentru MQ2 din Modulul 2.</a></li>
    <li><a href=""/Home/AlterMQ135_1"" style=""text-decoration:none;color:black;"">Aici poti vizualiza tabelul pentru MQ135 din Modulul 1.</a></li>
    <li><a href=""/Home/AlterMQ135_2"" style=""text-decoration:none;color:black;"">Aici poti vizualiza tabelul pentr");
            WriteLiteral(@"u MQ135 din Modulul 2.</a></li>
    <li><a href=""/Home/AlterDHT_1"" style=""text-decoration:none;color:black;"">Aici poti vizualiza tabelul pentru DHT din Modulul 1.</a></li>
    <li><a href=""/Home/AlterDHT_2"" style=""text-decoration:none;color:black;"">Aici poti vizualiza tabelul pentru DHT din Modulul 2.</a></li>
    <li><a href=""/Home/AlterCredentials"" style=""text-decoration:none;color:black;"">Aici poti modifica tabelul pentru credentiale.</a></li>
    <li><a href=""/Home/AlterPermLayers"" style=""text-decoration:none;color:black;"">Aici poti vizualiza tabelul pentru permisiuni.</a></li>
    <li><a href=""/Home/AlterMalicious"" style=""text-decoration:none;color:black;"">Aici poti modifica timpii de functionare.</a></li>
</ul>

<a href=""/Home/PageSelect"" style=""text-decoration:none; color: black;"">Inapoi</a>");
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
