#pragma checksum "C:\Users\KazinDA\Desktop\LibraryApp\Library\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23ee055bd812caabc676937d9b125a914528a041"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
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
#line 1 "C:\Users\KazinDA\Desktop\LibraryApp\Library\Views\_ViewImports.cshtml"
using Library;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\KazinDA\Desktop\LibraryApp\Library\Views\_ViewImports.cshtml"
using Library.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ee055bd812caabc676937d9b125a914528a041", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dadb7a731bfbb305c411bc5eb7a307dbd6008a89", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Library.ViewModels.BooksViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n    <h2>Информация</h2>\r\n    <div>\r\n");
#nullable restore
#line 6 "C:\Users\KazinDA\Desktop\LibraryApp\Library\Views\Home\Details.cshtml"
         foreach (var book in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dl class=\"dl-horizontal\">\r\n            <dt>Название</dt>\r\n            <dd>");
#nullable restore
#line 10 "C:\Users\KazinDA\Desktop\LibraryApp\Library\Views\Home\Details.cshtml"
           Write(book.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n            <dt>Автор</dt>\r\n            <dd>");
#nullable restore
#line 13 "C:\Users\KazinDA\Desktop\LibraryApp\Library\Views\Home\Details.cshtml"
           Write(book.AuthorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n            <dt>Описание</dt>\r\n            <dd>");
#nullable restore
#line 16 "C:\Users\KazinDA\Desktop\LibraryApp\Library\Views\Home\Details.cshtml"
           Write(book.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n        </dl>\r\n");
#nullable restore
#line 18 "C:\Users\KazinDA\Desktop\LibraryApp\Library\Views\Home\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Library.ViewModels.BooksViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
