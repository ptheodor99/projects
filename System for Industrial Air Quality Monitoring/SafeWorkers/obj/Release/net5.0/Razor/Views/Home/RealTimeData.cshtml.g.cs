#pragma checksum "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73d3edecc9796ab0ceb8c36e08bc58987eb7a521"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_RealTimeData), @"mvc.1.0.view", @"/Views/Home/RealTimeData.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73d3edecc9796ab0ceb8c36e08bc58987eb7a521", @"/Views/Home/RealTimeData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df12113f69d6a851cbb203092c4b2fcdc6d287c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_RealTimeData : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
  
    ViewData["Title"] = "RealTimeData";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"




<script src=""https://canvasjs.com/assets/script/canvasjs.min.js""></script>

<script>
window.onload = function () {

    var MQ2_1_Chart = new CanvasJS.Chart(""MQ2_1"", {
        exportEnabled: true,
    animationEnabled: true,
    title: {
        text: ""MQ2_1""
    },
    toolTip: {
        shared: true
    },
    data: [{
        type: ""line"",
        name: ""H2"",
        showInLegend: true,
        dataPoints: ");
#nullable restore
#line 27 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ2_1_H2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"LPG\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 33 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ2_1_LPG));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Methane\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 39 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ2_1_Methane));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"CO\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 45 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ2_1_CO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Alcohol\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 51 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ2_1_Alcohol));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Smoke\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 57 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ2_1_Smoke));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Propane\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 63 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ2_1_Propane));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    }
    ]
    });



     var MQ2_2_Chart = new CanvasJS.Chart(""MQ2_2"", {
        exportEnabled: true,
    animationEnabled: true,
    title: {
        text: ""MQ2_2""
    },
    toolTip: {
        shared: true
    },
    data: [{
        type: ""line"",
        name: ""H2"",
        showInLegend: true,
        dataPoints: ");
#nullable restore
#line 83 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ2_2_H2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"LPG\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 89 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ2_2_LPG));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Methane\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 95 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ2_2_Methane));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"CO\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 101 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ2_2_CO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Alcohol\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 107 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ2_2_Alcohol));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Smoke\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 113 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ2_2_Smoke));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Propane\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 119 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ2_2_Propane));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    }
    ]
    });







    var MQ9_1_Chart = new CanvasJS.Chart(""MQ9_1"", {
        exportEnabled: true,
    animationEnabled: true,
    title: {
        text: ""MQ9_1""
    },
    toolTip: {
        shared: true
    },
    data: [{
        type: ""line"",
        name: ""LPG"",
        showInLegend: true,
        dataPoints: ");
#nullable restore
#line 143 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ9_1_LPG));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"CO\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 149 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ9_1_CO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Methane\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 155 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ9_1_Methane));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    }
    ]
    });







    var MQ9_2_Chart = new CanvasJS.Chart(""MQ9_2"", {
        exportEnabled: true,
    animationEnabled: true,
    title: {
        text: ""MQ9_2""
    },
    toolTip: {
        shared: true
    },
    data: [{
        type: ""line"",
        name: ""LPG"",
        showInLegend: true,
        dataPoints: ");
#nullable restore
#line 179 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ9_2_LPG));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"CO\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 185 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ9_2_CO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Methane\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 191 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ9_2_Methane));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    }
    ]
    });



    var MQ135_1_Chart = new CanvasJS.Chart(""MQ135_1"", {
        exportEnabled: true,
    animationEnabled: true,
    title: {
        text: ""MQ135_1""
    },
    toolTip: {
        shared: true
    },
    data: [{
        type: ""line"",
        name: ""CO2"",
        showInLegend: true,
        dataPoints: ");
#nullable restore
#line 211 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ135_1_CO2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"CO\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 217 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ135_1_CO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Alcohol\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 223 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ135_1_Alcohol));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"NH4\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 229 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ135_1_NH4));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Toluene\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 235 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ135_1_Toluene));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Acetone\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 241 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ135_1_Acetone));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    }
    ]
    });




    var MQ135_2_Chart = new CanvasJS.Chart(""MQ135_2"", {
        exportEnabled: true,
    animationEnabled: true,
    title: {
        text: ""MQ135_2""
    },
    toolTip: {
        shared: true
    },
    data: [{
        type: ""line"",
        name: ""CO2"",
        showInLegend: true,
        dataPoints: ");
#nullable restore
#line 262 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ135_2_CO2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"CO\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 268 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ135_2_CO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Alcohol\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 274 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ135_2_Alcohol));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"NH4\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 280 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ135_2_NH4));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Toluene\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 286 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ135_2_Toluene));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Acetone\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 292 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.MQ135_2_Acetone));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    }
    ]
    });






    var DHT_1_Chart = new CanvasJS.Chart(""DHT_1"", {
        exportEnabled: true,
    animationEnabled: true,
    title: {
        text: ""DHT_1""
    },
    toolTip: {
        shared: true
    },
    data: [{
        type: ""line"",
        name: ""Temperature"",
        showInLegend: true,
        dataPoints: ");
#nullable restore
#line 315 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.DHT_1_Temperature));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Humidity\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 321 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.DHT_1_Humidity));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    }
    ]
    });



     var DHT_2_Chart = new CanvasJS.Chart(""DHT_2"", {
        exportEnabled: true,
    animationEnabled: true,
    title: {
        text: ""DHT_2""
    },
    toolTip: {
        shared: true
    },
    data: [{
        type: ""line"",
        name: ""Temperature"",
        showInLegend: true,
        dataPoints: ");
#nullable restore
#line 341 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.DHT_2_Temperature));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    },\r\n        {\r\n        type: \"line\",\r\n        name: \"Humidity\",\r\n        showInLegend: true,\r\n        dataPoints: ");
#nullable restore
#line 347 "C:\Users\teoal\source\repos\SafeWorkers\SafeWorkers\Views\Home\RealTimeData.cshtml"
               Write(Html.Raw(ViewBag.DHT_2_Humidity));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    }
    ]
    });

    MQ2_1_Chart.render();
    MQ2_2_Chart.render();
    MQ9_1_Chart.render();
    MQ9_2_Chart.render();
    MQ135_1_Chart.render();
    MQ135_2_Chart.render();
    DHT_1_Chart.render();
    DHT_2_Chart.render();
}


</script>








<div id=""MQ2_1"" style=""height: 370px; width: 100%;""></div>
<div id=""MQ2_2"" style=""height: 370px; width: 100%;""></div>
<div id=""MQ9_1"" style=""height: 370px; width: 100%;""></div>
<div id=""MQ9_2"" style=""height: 370px; width: 100%;""></div>
<div id=""MQ135_1"" style=""height: 370px; width: 100%;""></div>
<div id=""MQ135_2"" style=""height: 370px; width: 100%;""></div>
<div id=""DHT_1"" style=""height: 370px; width: 100%;""></div>
<div id=""DHT_2"" style=""height: 370px; width: 100%;""></div>

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
