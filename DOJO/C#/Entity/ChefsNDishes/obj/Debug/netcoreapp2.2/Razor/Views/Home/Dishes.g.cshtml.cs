#pragma checksum "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\ChefsNDishes\Views\Home\Dishes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f031e917528801b8245e4820d561438b5822ec5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dishes), @"mvc.1.0.view", @"/Views/Home/Dishes.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Dishes.cshtml", typeof(AspNetCore.Views_Home_Dishes))]
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
#line 1 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\ChefsNDishes\Views\_ViewImports.cshtml"
using ChefsNDishes;

#line default
#line hidden
#line 2 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\ChefsNDishes\Views\_ViewImports.cshtml"
using ChefsNDishes.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f031e917528801b8245e4820d561438b5822ec5", @"/Views/Home/Dishes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e3683dbd783bea45b88d0b0d3ee52e8ec1e5d61", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dishes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Dish>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\ChefsNDishes\Views\Home\Dishes.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(66, 348, true);
            WriteLiteral(@"
<h1> <a href=""/""> Chefs</a> | Dishes </h1>


<a href=""dishes/new"">Add a Dish</a>

<table class=""table"">
  <thead>
    <tr>
      <th scope=""col"">Name</th>
      <th scope=""col"">Chef</th>
      <th scope=""col"">Tastiness</th>
      <th scope=""col"">Calories</th>
      <th scope=""col"">Description</th>
    </tr>
  </thead>
  <tbody>
");
            EndContext();
#line 23 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\ChefsNDishes\Views\Home\Dishes.cshtml"
       foreach(var dish in Model)
{

#line default
#line hidden
            BeginContext(452, 20, true);
            WriteLiteral("    <tr>\r\n      <td>");
            EndContext();
            BeginContext(473, 9, false);
#line 26 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\ChefsNDishes\Views\Home\Dishes.cshtml"
     Write(dish.Name);

#line default
#line hidden
            EndContext();
            BeginContext(482, 82, true);
            WriteLiteral("</td>\r\n          <!--Need to find method to change date to yrs old -->\r\n      <td>");
            EndContext();
            BeginContext(565, 22, false);
#line 28 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\ChefsNDishes\Views\Home\Dishes.cshtml"
     Write(dish.Creator.firstName);

#line default
#line hidden
            EndContext();
            BeginContext(587, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(589, 21, false);
#line 28 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\ChefsNDishes\Views\Home\Dishes.cshtml"
                             Write(dish.Creator.lastName);

#line default
#line hidden
            EndContext();
            BeginContext(610, 25, true);
            WriteLiteral("\r\n      </td>\r\n      <td>");
            EndContext();
            BeginContext(636, 14, false);
#line 30 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\ChefsNDishes\Views\Home\Dishes.cshtml"
     Write(dish.Tastiness);

#line default
#line hidden
            EndContext();
            BeginContext(650, 17, true);
            WriteLiteral("</td>\r\n      <td>");
            EndContext();
            BeginContext(668, 13, false);
#line 31 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\ChefsNDishes\Views\Home\Dishes.cshtml"
     Write(dish.Calories);

#line default
#line hidden
            EndContext();
            BeginContext(681, 17, true);
            WriteLiteral("</td>\r\n      <td>");
            EndContext();
            BeginContext(699, 16, false);
#line 32 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\ChefsNDishes\Views\Home\Dishes.cshtml"
     Write(dish.Description);

#line default
#line hidden
            EndContext();
            BeginContext(715, 18, true);
            WriteLiteral("</td>\r\n    </tr>\r\n");
            EndContext();
#line 34 "C:\Users\zelin\Desktop\Code\UPLOAD TO GIT\Kent_Jensen\C#\Entity\ChefsNDishes\Views\Home\Dishes.cshtml"
}

#line default
#line hidden
            BeginContext(736, 20, true);
            WriteLiteral("  </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Dish>> Html { get; private set; }
    }
}
#pragma warning restore 1591