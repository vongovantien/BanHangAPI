#pragma checksum "D:\BanHangAPI\BanHangAPI\Views\Documents\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82ab98a64f1c790fa92c867f58f27e926a34075e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Documents_Index), @"mvc.1.0.view", @"/Views/Documents/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82ab98a64f1c790fa92c867f58f27e926a34075e", @"/Views/Documents/Index.cshtml")]
    public class Views_Documents_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BanHangAPI.Entities.Document>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\BanHangAPI\BanHangAPI\Views\Documents\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "D:\BanHangAPI\BanHangAPI\Views\Documents\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FileName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "D:\BanHangAPI\BanHangAPI\Views\Documents\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ContentType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "D:\BanHangAPI\BanHangAPI\Views\Documents\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FileSize));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 28 "D:\BanHangAPI\BanHangAPI\Views\Documents\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 31 "D:\BanHangAPI\BanHangAPI\Views\Documents\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FileName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "D:\BanHangAPI\BanHangAPI\Views\Documents\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ContentType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "D:\BanHangAPI\BanHangAPI\Views\Documents\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FileSize));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 985, "\"", 1016, 1);
#nullable restore
#line 40 "D:\BanHangAPI\BanHangAPI\Views\Documents\Index.cshtml"
WriteAttributeValue("", 1000, item.DocumentId, 1000, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1069, "\"", 1100, 1);
#nullable restore
#line 41 "D:\BanHangAPI\BanHangAPI\Views\Documents\Index.cshtml"
WriteAttributeValue("", 1084, item.DocumentId, 1084, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1155, "\"", 1186, 1);
#nullable restore
#line 42 "D:\BanHangAPI\BanHangAPI\Views\Documents\Index.cshtml"
WriteAttributeValue("", 1170, item.DocumentId, 1170, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 45 "D:\BanHangAPI\BanHangAPI\Views\Documents\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BanHangAPI.Entities.Document>> Html { get; private set; }
    }
}
#pragma warning restore 1591
