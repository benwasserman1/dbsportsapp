#pragma checksum "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31797be57c7a83b63de845a8eed682a5af923214"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31797be57c7a83b63de845a8eed682a5af923214", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ad17fe0765363ff80112d1726f68ff9c19092b2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 405, true);
            WriteLiteral(@"

<input type=""button"" id=""signup"" value=""Sign Up"" onclick=""signUpForm()"" />
<input type=""button"" id=""login"" value=""Log In"" onclick=""loginForm"" />


<table id=""tbl"" style=""width:100%"">
    <tr>
        <th>Date</th>
        <th>Team1</th>
        <th>Team2</th>
    </tr>
    <tr>
        <td>1</td>
        <td>Blazers</td>
        <td>Suns</td>
    </tr>

</table>

<a class=""export""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 450, "\"", 499, 1);
#line 24 "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/Home/Index.cshtml"
WriteAttributeValue("", 457, Url.Action("Export", new {table="Users"}), 457, 42, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(500, 36, true);
            WriteLiteral("> Export </a>\r\n\r\n<a class=\"database\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 536, "\"", 565, 1);
#line 26 "/Users/benjaminwasserman/Desktop/Chapman University/Junior/Database/final/Bet/Bet/Views/Home/Index.cshtml"
WriteAttributeValue("", 543, Url.Action("GetData"), 543, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(566, 13, true);
            WriteLiteral("> Test </a>\r\n");
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
