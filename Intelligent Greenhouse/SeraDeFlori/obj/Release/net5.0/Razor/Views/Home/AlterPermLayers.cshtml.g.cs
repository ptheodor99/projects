#pragma checksum "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\AlterPermLayers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec2ed45a45f28c6fc9870c52184d2721601b3aad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AlterPermLayers), @"mvc.1.0.view", @"/Views/Home/AlterPermLayers.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec2ed45a45f28c6fc9870c52184d2721601b3aad", @"/Views/Home/AlterPermLayers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"251a83e041619dbe55af0574e46ed1d14a1b36ab", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AlterPermLayers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\AlterPermLayers.cshtml"
  
    ViewData["Title"] = "Alter PermLayers";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec2ed45a45f28c6fc9870c52184d2721601b3aad3883", async() => {
                WriteLiteral(@"
    <fieldset>
        <table>
            <tr>
                <th style=""width: 200px; height: 20px; border: 1px solid black; text-align: center;"">Nivel de permisiuni</th>
                <th style=""width: 200px; height: 20px; border: 1px solid black; text-align: center;"">WR</th>
                <th style=""width: 200px; height: 20px; border: 1px solid black; text-align: center;"">RR</th>
                <th style=""width: 200px; height: 20px; border: 1px solid black; text-align: center;"">Modifica toate datele</th>
                <th style=""width: 200px; height: 20px; border: 1px solid black; text-align: center;"">Modifica date comune</th>
            </tr>

");
#nullable restore
#line 16 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\AlterPermLayers.cshtml"
             foreach (var x in ViewBag.PermLayersList)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td style=\"width: 200px; height: 20px; border: 1px solid black; text-align: center;\">");
#nullable restore
#line 19 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\AlterPermLayers.cshtml"
                                                                                                    Write(x.LayerLevel);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td style=\"width: 200px; height: 20px; border: 1px solid black; text-align: center;\">");
#nullable restore
#line 20 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\AlterPermLayers.cshtml"
                                                                                                    Write(x.WR);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td style=\"width: 200px; height: 20px; border: 1px solid black; text-align: center;\">");
#nullable restore
#line 21 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\AlterPermLayers.cshtml"
                                                                                                    Write(x.RR);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td style=\"width: 200px; height: 20px; border: 1px solid black; text-align: center;\">");
#nullable restore
#line 22 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\AlterPermLayers.cshtml"
                                                                                                    Write(x.ModifyAllData);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td style=\"width: 200px; height: 20px; border: 1px solid black; text-align: center;\">");
#nullable restore
#line 23 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\AlterPermLayers.cshtml"
                                                                                                    Write(x.ModifyOrdinary);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 25 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\AlterPermLayers.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </table>
            <!--
                <tr>
                    <td style=""width: 200px; height: 20px; border: 1px solid black; text-align: center;"">
                      <input type=""text"" name=""LayerLevel"" style=""width:80px;"" />
                    </td>
                    <td style=""width: 200px; height: 20px; border: 1px solid black; text-align: center;"">
                        <input type=""text"" name=""WR"" style=""width:80px;"" />
                    </td>
                    <td style=""width: 200px; height: 20px; border: 1px solid black; text-align: center;"">
                        <input type=""text"" name=""RR"" style=""width:80px;"" />
                    </td>
                    <td style=""width: 200px; height: 20px; border: 1px solid black; text-align: center;"">
                        <input type=""text"" name=""ModifyAllData"" style=""width:80px;"" />
                    </td>
                    <td style=""width: 200px; height: 20px; border: 1px solid black; text-align: cen");
                WriteLiteral(@"ter;"">
                        <input type=""text"" name=""ModifyOrdinary"" style=""width:80px;"" />
                    </td>
                </tr>
            </table>

            <label>Alege nivelul pe care vrei sa il modifici</label>
            <br />
            <select name=""Layers"">
                <optgroup label=""Alege nivelul"">
                    <option value=""None"">None</option>
");
#nullable restore
#line 53 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\AlterPermLayers.cshtml"
                     foreach (var x in ViewBag.PermLayersList)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec2ed45a45f28c6fc9870c52184d2721601b3aad9347", async() => {
#nullable restore
#line 55 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\AlterPermLayers.cshtml"
                                                 Write(x.LayerLevel);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 55 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\AlterPermLayers.cshtml"
                           WriteLiteral(x.LayerLevel);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 56 "E:\0LICENTE\SeraDeFlori\SeraDeFlori\SeraDeFlori\Views\Home\AlterPermLayers.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </optgroup>
            </select>
            <br />
            <label>Alege actiunea dorita:</label>
            <br />
            <select name=""Action"">
                <optgroup label=""Alege actiunea"">
                    <option value=""add"">Adauga</option>
                    <option value=""delete"">Sterge</option>
                    <option value=""modify"">Modifica</option>
                </optgroup>
            </select>
            <br />
            <input type=""submit"" value=""Modifica"" />-->
</fieldset>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n<br />\r\n\r\n<a href=\"/Home/WhereToGo\" style=\"text-decoration:none; color: black;\">Inapoi la selectarea paginilor</a>\r\n<br />\r\n<a href=\"/Home/AlterData\" style=\"text-decoration:none; color: black;\">Inapoi la selectarea tabelelor</a>");
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