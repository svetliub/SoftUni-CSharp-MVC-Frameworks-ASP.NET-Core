#pragma checksum "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\Videos\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8606c63a1a81839596abf5ac6a72d55f4fd5ab16"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MagicOfSewing.Web.Areas.Admin.Videos.Areas_Admin_Views_Videos_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/Videos/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Videos/Details.cshtml", typeof(MagicOfSewing.Web.Areas.Admin.Videos.Areas_Admin_Views_Videos_Details))]
namespace MagicOfSewing.Web.Areas.Admin.Videos
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\_ViewImports.cshtml"
using MagicOfSewing.Web;

#line default
#line hidden
#line 2 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\_ViewImports.cshtml"
using MagicOfSewing.Web.Models;

#line default
#line hidden
#line 3 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\_ViewImports.cshtml"
using MagicOfSewing.Common.Admin.BindingModels;

#line default
#line hidden
#line 4 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\_ViewImports.cshtml"
using MagicOfSewing.Common.Admin.ViewModels;

#line default
#line hidden
#line 5 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\_ViewImports.cshtml"
using MagicOfSewing.Web.Helpers;

#line default
#line hidden
#line 6 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\_ViewImports.cshtml"
using MagicOfSewing.Common.Constants;

#line default
#line hidden
#line 7 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\_ViewImports.cshtml"
using MagicOfSewing.Web.Common;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8606c63a1a81839596abf5ac6a72d55f4fd5ab16", @"/Areas/Admin/Views/Videos/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52e317a2d0170747d0e1af8dc7e1888ba6b2be0f", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Videos_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VideoDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn send"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Videos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-light"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\Videos\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(73, 171, true);
            WriteLiteral("<br />\r\n<div class=\"row\">\r\n    <div class=\"card\" style=\"width: 74rem; justify-content:center\">\r\n        <div class=\"card-body\">\r\n            <h2 style=\"text-align:center\">");
            EndContext();
            BeginContext(245, 11, false);
#line 9 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\Videos\Details.cshtml"
                                     Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(256, 167, true);
            WriteLiteral("</h2>\r\n            <br />\r\n            <div class=\"row\">\r\n                <div class=\"col-md-6 text-center mb-3\">\r\n                    <iframe width=\"550\" height=\"315\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 423, "\"", 475, 2);
            WriteAttributeValue("", 429, "https://www.youtube.com/embed/", 429, 30, true);
#line 13 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\Videos\Details.cshtml"
WriteAttributeValue("", 459, Model.YoutubeId, 459, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(476, 248, true);
            WriteLiteral("\r\n                            frameborder=\"0\" allow=\"autoplay; encrypted-media\" allowfullscreen></iframe>\r\n                </div>\r\n                <div class=\"col-md-6 text-center\">\r\n                    <p class=\"text-left\" style=\"font-size: 10px\">");
            EndContext();
            BeginContext(725, 21, false);
#line 17 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\Videos\Details.cshtml"
                                                            Write(Model.PublishDateTime);

#line default
#line hidden
            EndContext();
            BeginContext(746, 74, true);
            WriteLiteral("</p>\r\n                    <p class=\"text-justify\" style=\"font-size: 15px\">");
            EndContext();
            BeginContext(821, 17, false);
#line 18 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\Videos\Details.cshtml"
                                                               Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(838, 51, true);
            WriteLiteral("</p>\r\n                    <p class=\"text-right\">by ");
            EndContext();
            BeginContext(890, 12, false);
#line 19 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\Videos\Details.cshtml"
                                        Write(Model.Author);

#line default
#line hidden
            EndContext();
            BeginContext(902, 94, true);
            WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<br />\r\n");
            EndContext();
#line 26 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\Videos\Details.cshtml"
 if (User.IsInRole(WebConstants.AdminRole))
{

#line default
#line hidden
            BeginContext(1044, 93, true);
            WriteLiteral("    <div class=\"row product-action-holder mt-4 d-flex justify-content-around\">\r\n        <div>");
            EndContext();
            BeginContext(1137, 141, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d4d82be6dc047209695a39c7396b1ee", async() => {
                BeginContext(1270, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 29 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\Videos\Details.cshtml"
                                                                                              WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 29 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\Videos\Details.cshtml"
                                                                                                                         WriteLiteral(Model.Slug);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-slug", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1278, 16, true);
            WriteLiteral("</div>\r\n        ");
            EndContext();
            BeginContext(1294, 241, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e143a6d615cd41cd8db3f61d376f1175", async() => {
                BeginContext(1429, 99, true);
                WriteLiteral("\r\n            <div><button type=\"submit\" id=\"send\" class=\"btn send\">Delete</button></div>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 30 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\Videos\Details.cshtml"
                                                                             WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 30 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\Videos\Details.cshtml"
                                                                                                        WriteLiteral(Model.Slug);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["slug"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-slug", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["slug"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1535, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(1545, 95, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3beaaf8055484ac0a2d3a9674ecdaf74", async() => {
                BeginContext(1630, 6, true);
                WriteLiteral("Cancel");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1640, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 35 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Areas\Admin\Views\Videos\Details.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VideoDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
