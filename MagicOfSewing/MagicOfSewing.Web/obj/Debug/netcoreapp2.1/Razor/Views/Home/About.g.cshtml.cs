#pragma checksum "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c8f2c21ba57c625c9aadb93ca7195c45ccee12b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/About.cshtml", typeof(AspNetCore.Views_Home_About))]
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
#line 1 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Views\_ViewImports.cshtml"
using MagicOfSewing.Web;

#line default
#line hidden
#line 2 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Views\_ViewImports.cshtml"
using MagicOfSewing.Web.Models;

#line default
#line hidden
#line 3 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Views\_ViewImports.cshtml"
using MagicOfSewing.Models;

#line default
#line hidden
#line 4 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Views\_ViewImports.cshtml"
using MagicOfSewing.Common.Constants;

#line default
#line hidden
#line 5 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 6 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Views\_ViewImports.cshtml"
using MagicOfSewing.Common.Admin.ViewModels;

#line default
#line hidden
#line 7 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Views\_ViewImports.cshtml"
using MagicOfSewing.Web.Common;

#line default
#line hidden
#line 8 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Views\_ViewImports.cshtml"
using MagicOfSewing.Web.Helpers.Messages;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c8f2c21ba57c625c9aadb93ca7195c45ccee12b", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"860145fd9aa89a10431c6fcfb64f96e95bd584a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UserConciseViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Views\Home\About.cshtml"
  
    ViewData["Title"] = "About";

#line default
#line hidden
            BeginContext(85, 128, true);
            WriteLiteral("<h2 style=\"text-align:center\">About Us</h2>\r\n\r\n<h4 style=\"text-align:center\">The inspirers</h4>\r\n<br />\r\n<div class=\"row\">\r\n    ");
            EndContext();
            BeginContext(214, 22, false);
#line 11 "C:\Users\Steve\Desktop\Local_Disc(D)\GITHUB\SoftUni-CSharp-MVC-Frameworks-ASP.NET-Core\MagicOfSewing\MagicOfSewing.Web\Views\Home\About.cshtml"
Write(Html.DisplayForModel());

#line default
#line hidden
            EndContext();
            BeginContext(236, 12, true);
            WriteLiteral("    \r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UserConciseViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591