#pragma checksum "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dace8708dd7560b5208e95a88a3c990e74591d06"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Players_Sponsorship), @"mvc.1.0.view", @"/Views/Players/Sponsorship.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dace8708dd7560b5208e95a88a3c990e74591d06", @"/Views/Players/Sponsorship.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4513f0f04d945d020188325abe02cc3470b70e42", @"/Views/_ViewImports.cshtml")]
    public class Views_Players_Sponsorship : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MeinLiX.ContractPlayer>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("CreateButton"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateContract", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
  
    ViewData["Title"] = "Sponsorship";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1>Player:");
#nullable restore
#line 8 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
      Write(ViewBag.PlayerNickName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - Sponsor List</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dace8708dd7560b5208e95a88a3c990e74591d064745", async() => {
                WriteLiteral("Add Sponsor");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 11 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
                                                          WriteLiteral(ViewBag.PlayerID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
           Write(Html.DisplayNameFor(model => model.IdSponsorNavigation.SponsorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
           Write(Html.DisplayNameFor(model => model.IdSponsorNavigation.SponsorWebpage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
           Write(Html.DisplayNameFor(model => model.IdSponsorNavigation.SponsorFoundation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
           Write(Html.DisplayNameFor(model => model.ContractValidUntil));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
           Write(Html.DisplayNameFor(model => model.ContractBalance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 34 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 38 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
               Write(Html.DisplayFor(modelItem => item.IdSponsorNavigation.SponsorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 41 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
               Write(Html.DisplayFor(modelItem => item.IdSponsorNavigation.SponsorWebpage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 44 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
               Write(Html.DisplayFor(modelItem => item.IdSponsorNavigation.SponsorFoundation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 46 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
                 if (item.ContractValidUntil < DateTime.Today)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        <p class=\"out-date\">Time expired ");
#nullable restore
#line 49 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
                                                    Write(Html.DisplayFor(modelItem => item.ContractValidUntil));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </td>\r\n");
#nullable restore
#line 51 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 55 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ContractValidUntil));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 57 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 59 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
               Write(Html.DisplayFor(modelItem => item.ContractBalance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 62 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dace8708dd7560b5208e95a88a3c990e74591d0612807", async() => {
                WriteLiteral("Back to Player List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "Y:\RiXi\project\source\repos UNIVER\labs 2ks\IStaTP 2 semestr\MeinLiX\MeinLiX\Views\Players\Sponsorship.cshtml"
                            WriteLiteral(ViewBag.playerId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MeinLiX.ContractPlayer>> Html { get; private set; }
    }
}
#pragma warning restore 1591
