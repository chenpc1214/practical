#pragma checksum "C:\Users\user\Dropbox\我的電腦 (LAPTOP-MHIK44II)\Desktop\Work\Views\Items\Panel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f6983fe1ec5f7462174d1bcb6a16973b854496a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Items_Panel), @"mvc.1.0.view", @"/Views/Items/Panel.cshtml")]
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
#line 1 "C:\Users\user\Dropbox\我的電腦 (LAPTOP-MHIK44II)\Desktop\Work\Views\_ViewImports.cshtml"
using Work;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Dropbox\我的電腦 (LAPTOP-MHIK44II)\Desktop\Work\Views\_ViewImports.cshtml"
using Work.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f6983fe1ec5f7462174d1bcb6a16973b854496a", @"/Views/Items/Panel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fd5ee3b6184dd8396b8a0eac32d8e3d98a4c303", @"/Views/_ViewImports.cshtml")]
    public class Views_Items_Panel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\user\Dropbox\我的電腦 (LAPTOP-MHIK44II)\Desktop\Work\Views\Items\Panel.cshtml"
  
    ViewData["Title"] = "Panel";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div class=\"text-center\" id=\"divMain\">\r\n\r\n</div>\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n        <script>\r\n\r\n            /*/Items/Index*/\r\n            $(function () {\r\n                $.ajax({\r\n                    type: \"GET\",\r\n                    url: \"");
#nullable restore
#line 20 "C:\Users\user\Dropbox\我的電腦 (LAPTOP-MHIK44II)\Desktop\Work\Views\Items\Panel.cshtml"
                     Write(Url.Action("Index", "Items"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                    contentType: ""html"",
                    dataType:""html"",
                    success: (function (res) {
                        $(""#divMain"").html(res)
                    })

                })
        } );
        </script>
    ");
            }
            );
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
