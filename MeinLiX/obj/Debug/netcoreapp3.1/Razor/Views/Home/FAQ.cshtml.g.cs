#pragma checksum "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Home\FAQ.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ff52984a9de1466e1ff1f1741fe535d5d76ff2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_FAQ), @"mvc.1.0.view", @"/Views/Home/FAQ.cshtml")]
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
#line 1 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\_ViewImports.cshtml"
using MeinLiX;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\_ViewImports.cshtml"
using MeinLiX.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ff52984a9de1466e1ff1f1741fe535d5d76ff2c", @"/Views/Home/FAQ.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4513f0f04d945d020188325abe02cc3470b70e42", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_FAQ : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Home\FAQ.cshtml"
  
    ViewData["Title"] = "F.A.Q";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<section class=""headerr"">
    <div class=""header-title"">
        Frequently Asked Questions
    </div>
</section>

<div class=""content-block"">
    <div id=""myDiv"">
        <ul class=""nav nav-tabs"">
            <li><a data-toggle=""tab"" href=""#MeinLiX"">MeinLiX</a></li>
            <li><a data-toggle=""tab"" href=""#Functional"">Functional</a></li>
            <li><a data-toggle=""tab"" href=""#Pink_Theme"">Pink Theme</a></li>
            <li><a data-toggle=""tab"" href=""#Diagram"">Diagram</a></li>
        </ul>

        <div class=""tab-content"">
            <div id=""MeinLiX"" class=""tab-pane fade in active"">
                <h3>MeinLiX</h3>
                <p>This is My version popular website HLTV</p>
                <p>HLTV, which stands for Half-Life Television, is a news website and forum which covers professional Counter-Strike: Global Offensive esports teams and organisations.</p>
                <p>It is one of the leading websites within the Counter-Strike community with over 4 million uniqu");
            WriteLiteral(@"e visitors each month.</p>
            </div>
            <div id=""Functional"" class=""tab-pane fade"">
                <h3>Functional</h3>
                <p>On this site you can found cybersports organisations our teams (subdivisions) and players.</p>
                <p>As well as information about their sponsors.</p>
                <p>And also add your data.</p>
            </div>
            <div id=""Pink_Theme"" class=""tab-pane fade"">
                <h3>Pink Theme</h3>
                <p>In color psychology, pink is a sign of hope. It is a positive color inspiring warm and comforting feelings, a sense that everything will be okay.</p>
                <p>Combining pink with other darker colors such as dark blue, dark green, black or gray, adds strength and sophistication to pink.</p>
            </div>
            <div id=""Diagram"" class=""tab-pane fade"">
                <h3>Diagram</h3>
                <div class=""container text-center"">
                    <div id=""OrgGame"" class=""inline"">");
            WriteLiteral("</div>\r\n                    <div id=\"Sponsored\" class=\"inline\"></div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>

    <script>
        google.charts.load('current', { packages: ['corechart'] });
        google.charts.setOnLoadCallback(drawChartGame);

        google.charts.load('current', { packages: ['Table'] });
        google.charts.setOnLoadCallback(drawChartSponsor);


        function drawChartGame() {
            $.get('/Api/Game', function (JsonData) {
                data = google.visualization.arrayToDataTable(JsonData, false);
                var option = {
                    title: ""Game Teams"",
                };
                chart = new google.visualization.PieChart(document.getElementById('OrgGame'));
                chart.draw(data, option);
            })
        }
        function drawChartSponsor() {
            $.get('/Api/Sponsor', function (JsonData) {
                data = google.visualization.arrayToDataTable(JsonData, false);
                var option = {
                  ");
                WriteLiteral("  title: \"Sponsored stats\",\r\n                };\r\n                chart = new google.visualization.Table(document.getElementById(\'Sponsored\'));\r\n                chart.draw(data, option);\r\n            })\r\n        }\r\n\r\n\r\n    </script>\r\n");
            }
            );
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
