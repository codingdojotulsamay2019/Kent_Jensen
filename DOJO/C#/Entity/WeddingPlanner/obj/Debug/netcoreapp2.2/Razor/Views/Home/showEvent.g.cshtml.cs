#pragma checksum "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\WeddingPlanner\Views\Home\showEvent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3218d477f30c9ce7aa192cece90404026a666256"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_showEvent), @"mvc.1.0.view", @"/Views/Home/showEvent.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/showEvent.cshtml", typeof(AspNetCore.Views_Home_showEvent))]
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
#line 1 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\WeddingPlanner\Views\_ViewImports.cshtml"
using WeddingPlanner;

#line default
#line hidden
#line 2 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\WeddingPlanner\Views\_ViewImports.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3218d477f30c9ce7aa192cece90404026a666256", @"/Views/Home/showEvent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9e38482b8beecdb199b7be73dfa5c3d6a2f574", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_showEvent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Event>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(14, 9, true);
            WriteLiteral(" \r\n\r\n<h1>");
            EndContext();
            BeginContext(24, 13, false);
#line 4 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\WeddingPlanner\Views\Home\showEvent.cshtml"
Write(Model.Wedder1);

#line default
#line hidden
            EndContext();
            BeginContext(37, 3, true);
            WriteLiteral(" & ");
            EndContext();
            BeginContext(41, 13, false);
#line 4 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\WeddingPlanner\Views\Home\showEvent.cshtml"
                Write(Model.Wedder2);

#line default
#line hidden
            EndContext();
            BeginContext(54, 91, true);
            WriteLiteral("\'s Wedding</h1>\r\n<a href=\"/Dashboard\">Dashboard</a><a href=\"Logout\">Logout</a>\r\n\r\n<p>Date: ");
            EndContext();
            BeginContext(146, 10, false);
#line 7 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\WeddingPlanner\Views\Home\showEvent.cshtml"
    Write(Model.Date);

#line default
#line hidden
            EndContext();
            BeginContext(156, 32, true);
            WriteLiteral("</p>\r\n\r\n\r\n<p>Guests:</p>\r\n<ul>\r\n");
            EndContext();
#line 12 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\WeddingPlanner\Views\Home\showEvent.cshtml"
 foreach(var e in Model.allUsersAttending)
{

#line default
#line hidden
            BeginContext(235, 8, true);
            WriteLiteral("    <li>");
            EndContext();
            BeginContext(244, 16, false);
#line 14 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\WeddingPlanner\Views\Home\showEvent.cshtml"
   Write(e.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(260, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(262, 15, false);
#line 14 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\WeddingPlanner\Views\Home\showEvent.cshtml"
                     Write(e.User.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(277, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 15 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\WeddingPlanner\Views\Home\showEvent.cshtml"
}

#line default
#line hidden
            BeginContext(287, 26, true);
            WriteLiteral("</ul>\r\n\r\n<p>Map:</p>\r\n<img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 313, "\"", 452, 3);
            WriteAttributeValue("", 319, "https://maps.googleapis.com/maps/api/staticmap?center=", 319, 54, true);
#line 19 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\WeddingPlanner\Views\Home\showEvent.cshtml"
WriteAttributeValue("", 373, Model.Address, 373, 14, false);

#line default
#line hidden
            WriteAttributeValue("", 387, "&zoom=12&size=400x400&key=AIzaSyB2dZT3ENLKtmXPsen2BlqDUZJU36CFkxE", 387, 65, true);
            EndWriteAttribute();
            BeginContext(453, 1, true);
            WriteLiteral(">");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Event> Html { get; private set; }
    }
}
#pragma warning restore 1591
