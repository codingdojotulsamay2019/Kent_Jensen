#pragma checksum "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\CRUDlicious\Views\Home\Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6dce43c1d965afe10bea7275045f9fea8cc3699b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Show), @"mvc.1.0.view", @"/Views/Home/Show.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Show.cshtml", typeof(AspNetCore.Views_Home_Show))]
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
#line 1 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\CRUDlicious\Views\_ViewImports.cshtml"
using Crudlicious;

#line default
#line hidden
#line 2 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\CRUDlicious\Views\_ViewImports.cshtml"
using Crudlicious.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6dce43c1d965afe10bea7275045f9fea8cc3699b", @"/Views/Home/Show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02cde5fe96f9b9e0de57c6cb38ae4923b7006a88", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dish>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(13, 26, true);
            WriteLiteral("<a href=\"/\">Home</a>\r\n<h1>");
            EndContext();
            BeginContext(40, 10, false);
#line 3 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\CRUDlicious\Views\Home\Show.cshtml"
Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(50, 12, true);
            WriteLiteral("</h1>\r\n<h3> ");
            EndContext();
            BeginContext(63, 10, false);
#line 4 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\CRUDlicious\Views\Home\Show.cshtml"
Write(Model.Chef);

#line default
#line hidden
            EndContext();
            BeginContext(73, 22, true);
            WriteLiteral(" </h3>\r\n\r\n<hr>\r\n\r\n<h6>");
            EndContext();
            BeginContext(96, 17, false);
#line 8 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\CRUDlicious\Views\Home\Show.cshtml"
Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(113, 33, true);
            WriteLiteral("</h6>\r\n<br>\r\n<br>\r\n<h5>Calories: ");
            EndContext();
            BeginContext(147, 14, false);
#line 11 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\CRUDlicious\Views\Home\Show.cshtml"
         Write(Model.Calories);

#line default
#line hidden
            EndContext();
            BeginContext(161, 23, true);
            WriteLiteral(" </h5>\r\n<h5>Tastiness: ");
            EndContext();
            BeginContext(185, 15, false);
#line 12 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\CRUDlicious\Views\Home\Show.cshtml"
          Write(Model.Tastiness);

#line default
#line hidden
            EndContext();
            BeginContext(200, 43, true);
            WriteLiteral(" </h5>\r\n<br>\r\n<br>\r\n<br>\r\n<br>\r\n\r\n<div>\r\n<a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 243, "\"", 270, 2);
            WriteAttributeValue("", 250, "delete/", 250, 7, true);
#line 19 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\CRUDlicious\Views\Home\Show.cshtml"
WriteAttributeValue("", 257, Model.DishId, 257, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(271, 32, true);
            WriteLiteral("><button>Delete</button></a>\r\n<a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 303, "\"", 328, 2);
            WriteAttributeValue("", 310, "edit/", 310, 5, true);
#line 20 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\CRUDlicious\Views\Home\Show.cshtml"
WriteAttributeValue("", 315, Model.DishId, 315, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(329, 34, true);
            WriteLiteral("><button>Edit</button></a>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dish> Html { get; private set; }
    }
}
#pragma warning restore 1591
