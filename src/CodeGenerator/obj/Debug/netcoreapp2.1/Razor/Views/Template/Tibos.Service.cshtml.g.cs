#pragma checksum "C:\Users\xingbo\Documents\Work\netcore.generator\src\CodeGenerator\Views\Template\Tibos.Service.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7dd8cef7002dcf09d384c52a43972ef5ee302169"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Template_Tibos_Service), @"mvc.1.0.view", @"/Views/Template/Tibos.Service.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Template/Tibos.Service.cshtml", typeof(AspNetCore.Views_Template_Tibos_Service))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7dd8cef7002dcf09d384c52a43972ef5ee302169", @"/Views/Template/Tibos.Service.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f64f30916aefe84e4ab0089b1a21327c3023dd3", @"/Views/_ViewImports.cshtml")]
    public class Views_Template_Tibos_Service : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TableConfig>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(19, 239, true);
            WriteLiteral("<pre>\nusing FLShop.BusinessModel.Model;\nusing FLShop.IRepository;\nusing FLShop.IService.Fulu;\nusing System;\nusing System.Collections.Generic;\nusing System.Text;\nusing FLShop.IService.Fulu;\n\nnamespace FLShop.Service.Fulu\n{\n    public class ");
            EndContext();
            BeginContext(259, 14, false);
#line 13 "C:\Users\xingbo\Documents\Work\netcore.generator\src\CodeGenerator\Views\Template\Tibos.Service.cshtml"
            Write(Model.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(273, 13, true);
            WriteLiteral(":BaseService<");
            EndContext();
            BeginContext(287, 15, false);
#line 13 "C:\Users\xingbo\Documents\Work\netcore.generator\src\CodeGenerator\Views\Template\Tibos.Service.cshtml"
                                        Write(Model.TableName);

#line default
#line hidden
            EndContext();
            BeginContext(302, 3, true);
            WriteLiteral(">,I");
            EndContext();
            BeginContext(307, 14, false);
#line 13 "C:\Users\xingbo\Documents\Work\netcore.generator\src\CodeGenerator\Views\Template\Tibos.Service.cshtml"
                                                            Write(Model.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(322, 48, true);
            WriteLiteral("\n    {\n        private readonly IBaseRepository<");
            EndContext();
            BeginContext(371, 15, false);
#line 15 "C:\Users\xingbo\Documents\Work\netcore.generator\src\CodeGenerator\Views\Template\Tibos.Service.cshtml"
                                    Write(Model.TableName);

#line default
#line hidden
            EndContext();
            BeginContext(386, 22, true);
            WriteLiteral("> dao;\n        public ");
            EndContext();
            BeginContext(410, 14, false);
#line 16 "C:\Users\xingbo\Documents\Work\netcore.generator\src\CodeGenerator\Views\Template\Tibos.Service.cshtml"
           Write(Model.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(425, 17, true);
            WriteLiteral("(IBaseRepository<");
            EndContext();
            BeginContext(443, 15, false);
#line 16 "C:\Users\xingbo\Documents\Work\netcore.generator\src\CodeGenerator\Views\Template\Tibos.Service.cshtml"
                                            Write(Model.TableName);

#line default
#line hidden
            EndContext();
            BeginContext(458, 79, true);
            WriteLiteral("> dao):base(dao)\n        {\n            this.dao = dao;\n        }\n    }\n}\n</pre>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TableConfig> Html { get; private set; }
    }
}
#pragma warning restore 1591
