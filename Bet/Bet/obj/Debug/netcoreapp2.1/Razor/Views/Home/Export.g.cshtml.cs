#pragma checksum "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/Home/Export.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7dc28e9dc788cbe63d77c9796ae8c10ab25661b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Export), @"mvc.1.0.view", @"/Views/Home/Export.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Export.cshtml", typeof(AspNetCore.Views_Home_Export))]
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
#line 1 "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/_ViewImports.cshtml"
using Bet;

#line default
#line hidden
#line 2 "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/_ViewImports.cshtml"
using Bet.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7dc28e9dc788cbe63d77c9796ae8c10ab25661b", @"/Views/Home/Export.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ad17fe0765363ff80112d1726f68ff9c19092b2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Export : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/Home/Export.cshtml"
  
    ViewData["Title"] = "About";

#line default
#line hidden
            BeginContext(41, 4, true);
            WriteLiteral("<h2>");
            EndContext();
            BeginContext(46, 17, false);
#line 4 "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/Home/Export.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(63, 11, true);
            WriteLiteral("</h2>\r\n<h3>");
            EndContext();
            BeginContext(75, 19, false);
#line 5 "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/Home/Export.cshtml"
Write(ViewData["Message"]);

#line default
#line hidden
            EndContext();
            BeginContext(94, 9, true);
            WriteLiteral("</h3>\r\n\r\n");
            EndContext();
#line 7 "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/Home/Export.cshtml"
 foreach (var v in Model)
{

#line default
#line hidden
            BeginContext(133, 9, true);
            WriteLiteral("    <div>");
            EndContext();
            BeginContext(143, 1, false);
#line 9 "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/Home/Export.cshtml"
    Write(v);

#line default
#line hidden
            EndContext();
            BeginContext(144, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 10 "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/Home/Export.cshtml"
}

#line default
#line hidden
            BeginContext(155, 41, true);
            WriteLiteral("\r\n<p>Your download should start now</p>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
