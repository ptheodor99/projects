#pragma checksum "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "285d64678008e29a14aca9f82590555b2c703788"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AlterCommands), @"mvc.1.0.view", @"/Views/Home/AlterCommands.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"285d64678008e29a14aca9f82590555b2c703788", @"/Views/Home/AlterCommands.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df12113f69d6a851cbb203092c4b2fcdc6d287c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AlterCommands : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Red", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Yellow", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Green", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Buzzer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Alarm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "ON", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Test", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "None", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
  
    ViewData["Title"] = "Alter Commands";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<p><b>Comenzile actuale sunt:</b></p>\r\n<ul>\r\n");
#nullable restore
#line 8 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
     if(ViewBag.CommandsObject.Red == "OFF")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>LED Rosu: Oprit</li>\r\n");
#nullable restore
#line 11 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>LED Rosu: Pornit pentru ");
#nullable restore
#line 14 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
                               Write(ViewBag.CommandsTimeObject.Red);

#line default
#line hidden
#nullable disable
            WriteLiteral(" secunde</li>\r\n");
#nullable restore
#line 15 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 17 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
     if(ViewBag.CommandsObject.Yellow == "OFF")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>LED Galben: Oprit</li>\r\n");
#nullable restore
#line 20 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>LED Galben: Pornit pentru ");
#nullable restore
#line 23 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
                                 Write(ViewBag.CommandsTimeObject.Yellow);

#line default
#line hidden
#nullable disable
            WriteLiteral(" secunde</li>\r\n");
#nullable restore
#line 24 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 26 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
     if(ViewBag.CommandsObject.Green == "OFF")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>LED Verde: Oprit</li>\r\n");
#nullable restore
#line 29 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>LED Verde: Pornit pentru ");
#nullable restore
#line 32 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
                                Write(ViewBag.CommandsTimeObject.Green);

#line default
#line hidden
#nullable disable
            WriteLiteral(" secunde</li>\r\n");
#nullable restore
#line 33 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 35 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
     if(ViewBag.CommandsObject.Buzzer == "OFF")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>Buzzer: Oprit</li>\r\n");
#nullable restore
#line 38 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>Buzzer: Pornit pentru ");
#nullable restore
#line 41 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
                             Write(ViewBag.CommandsTimeObject.Buzzer);

#line default
#line hidden
#nullable disable
            WriteLiteral(" secunde</li>\r\n");
#nullable restore
#line 42 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 44 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
     if(ViewBag.CommandsObject.Test == "OFF")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>Test: Oprit</li>\r\n");
#nullable restore
#line 47 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>Test: Pornit pentru ");
#nullable restore
#line 50 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
                           Write(ViewBag.CommandsTimeObject.Test);

#line default
#line hidden
#nullable disable
            WriteLiteral(" secunde</li>\r\n");
#nullable restore
#line 51 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\AlterCommands.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n<br />\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "285d64678008e29a14aca9f82590555b2c70378811480", async() => {
                WriteLiteral("\r\n    <fieldset>\r\n        <label>Selecteaza dispozitivul:</label>\r\n        <br />\r\n        <select name = \"Apps\">\r\n            <optgroup label=\"Dispozitiv\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "285d64678008e29a14aca9f82590555b2c70378811925", async() => {
                    WriteLiteral("Rosu");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "285d64678008e29a14aca9f82590555b2c70378813163", async() => {
                    WriteLiteral("Galben");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "285d64678008e29a14aca9f82590555b2c70378814403", async() => {
                    WriteLiteral("Verde");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "285d64678008e29a14aca9f82590555b2c70378815642", async() => {
                    WriteLiteral("Buzzer");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "285d64678008e29a14aca9f82590555b2c70378816882", async() => {
                    WriteLiteral("Alarm");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </optgroup>\r\n        </select>\r\n        <br />\r\n        <label>Selecteaza comanda:</label>\r\n        <br />\r\n        <select name=\"Command\">\r\n            <optgroup label=\"Comanda\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "285d64678008e29a14aca9f82590555b2c70378818332", async() => {
                    WriteLiteral("Pornit");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "285d64678008e29a14aca9f82590555b2c70378819572", async() => {
                    WriteLiteral("Testeaza");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "285d64678008e29a14aca9f82590555b2c70378820814", async() => {
                    WriteLiteral("Reincarca");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            </optgroup>
        </select>
        <br />
        <label>Introdu timpul daca ai ales Pornit</label>
        <br />
        <input type=""text"" name=""Time"" style=""width:80px;"" />
        <br />
        <input type=""submit"" value=""Modifica"" />
    </fieldset>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<br />\r\n<a href=\"/Home/PageSelect\" style=\"text-decoration:none; color: black;\">Inapoi</a>");
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
