#pragma checksum "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/Home/Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d6eaf14e7fcc8aae39129ec94c2604fccbef242e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Contact), @"mvc.1.0.view", @"/Views/Home/Contact.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Contact.cshtml", typeof(AspNetCore.Views_Home_Contact))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6eaf14e7fcc8aae39129ec94c2604fccbef242e", @"/Views/Home/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ad17fe0765363ff80112d1726f68ff9c19092b2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Contact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/Home/Contact.cshtml"
  
    ViewData["Title"] = "Contact Us";

#line default
#line hidden
            BeginContext(46, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(51, 17, false);
#line 4 "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/Home/Contact.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(68, 11, true);
            WriteLiteral("</h1>\r\n<h3>");
            EndContext();
            BeginContext(80, 19, false);
#line 5 "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/Home/Contact.cshtml"
Write(ViewData["Message"]);

#line default
#line hidden
            EndContext();
            BeginContext(99, 280, true);
            WriteLiteral(@"</h3>

<address>
    One University Drive<br />
    Orange, CA 92866<br />
    <abbr title=""Phone"">P:</abbr>
    541.678.0098
</address>

<address>
    <strong>Support:</strong> <a href=""mailto:wasse114@mail.chapman.edu"">wasse114@mail.chapman.edu</a><br />
</address>
");
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
