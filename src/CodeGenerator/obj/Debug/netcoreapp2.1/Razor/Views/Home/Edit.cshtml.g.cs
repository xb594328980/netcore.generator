#pragma checksum "C:\Users\xingbo\Documents\Work\netcore.generator\src\CodeGenerator\Views\Home\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b03066be1d091f6bb1d4aa4d8d650e98fffb5bf5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Edit), @"mvc.1.0.view", @"/Views/Home/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Edit.cshtml", typeof(AspNetCore.Views_Home_Edit))]
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
#line 1 "C:\Users\xingbo\Documents\Work\netcore.generator\src\CodeGenerator\Views\_ViewImports.cshtml"
using CodeGenerator;

#line default
#line hidden
#line 2 "C:\Users\xingbo\Documents\Work\netcore.generator\src\CodeGenerator\Views\_ViewImports.cshtml"
using CodeGenerator.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b03066be1d091f6bb1d4aa4d8d650e98fffb5bf5", @"/Views/Home/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f64f30916aefe84e4ab0089b1a21327c3023dd3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SqlConnect>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\xingbo\Documents\Work\netcore.generator\src\CodeGenerator\Views\Home\Edit.cshtml"
  
    ViewData["Title"] = "创建";
    Layout = "/Views/Shared/_IFrame.cshtml";

#line default
#line hidden
            BeginContext(99, 56, false);
#line 6 "C:\Users\xingbo\Documents\Work\netcore.generator\src\CodeGenerator\Views\Home\Edit.cshtml"
Write(Html.Partial("~/Views/Home/_CreateOrEdit.cshtml", Model));

#line default
#line hidden
            EndContext();
            BeginContext(155, 2, true);
            WriteLiteral("\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SqlConnect> Html { get; private set; }
    }
}
#pragma warning restore 1591