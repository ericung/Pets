#pragma checksum "C:\Users\Eric\source\repos\Pets\Pets\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b879471549718c633ef8715690ae84919040c74"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Eric\source\repos\Pets\Pets\Views\_ViewImports.cshtml"
using Pets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eric\source\repos\Pets\Pets\Views\_ViewImports.cshtml"
using Pets.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Eric\source\repos\Pets\Pets\Views\_ViewImports.cshtml"
using Pets.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Eric\source\repos\Pets\Pets\Views\_ViewImports.cshtml"
using Pets.Repository;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b879471549718c633ef8715690ae84919040c74", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b41b3bc511db05b49ff7a7fe8cd457ff321c65", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Eric\source\repos\Pets\Pets\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <!-- <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p> -->\r\n");
#nullable restore
#line 10 "C:\Users\Eric\source\repos\Pets\Pets\Views\Home\Index.cshtml"
     if (Model.Pets != null)
	{
		

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Eric\source\repos\Pets\Pets\Views\Home\Index.cshtml"
         foreach(var pet in Model.Pets)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<div>\r\n\t\t\t\t<h1>");
#nullable restore
#line 15 "C:\Users\Eric\source\repos\Pets\Pets\Views\Home\Index.cshtml"
               Write(pet.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\t\t\t\t<div>\r\n\t\t\t\t\t");
#nullable restore
#line 17 "C:\Users\Eric\source\repos\Pets\Pets\Views\Home\Index.cshtml"
               Write(pet.AnimalType);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n");
#nullable restore
#line 20 "C:\Users\Eric\source\repos\Pets\Pets\Views\Home\Index.cshtml"
		}

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Eric\source\repos\Pets\Pets\Views\Home\Index.cshtml"
         
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
