#pragma checksum "F:\Dot Net Project\MLS\src\mls-web\MLS.Web\Views\Shared\Header.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9337988eab8d579bdabd0bb5a521a4816c8b5265"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Header), @"mvc.1.0.view", @"/Views/Shared/Header.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Header.cshtml", typeof(AspNetCore.Views_Shared_Header))]
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
#line 1 "F:\Dot Net Project\MLS\src\mls-web\MLS.Web\Views\_ViewImports.cshtml"
using MLS.Web;

#line default
#line hidden
#line 2 "F:\Dot Net Project\MLS\src\mls-web\MLS.Web\Views\_ViewImports.cshtml"
using MLS.Web.Models.Module;

#line default
#line hidden
#line 3 "F:\Dot Net Project\MLS\src\mls-web\MLS.Web\Views\_ViewImports.cshtml"
using MLS.Web.Models.Account;

#line default
#line hidden
#line 4 "F:\Dot Net Project\MLS\src\mls-web\MLS.Web\Views\_ViewImports.cshtml"
using MLS.Web.Models;

#line default
#line hidden
#line 1 "F:\Dot Net Project\MLS\src\mls-web\MLS.Web\Views\Shared\Header.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "F:\Dot Net Project\MLS\src\mls-web\MLS.Web\Views\Shared\Header.cshtml"
using MLS.Entities.Main;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9337988eab8d579bdabd0bb5a521a4816c8b5265", @"/Views/Shared/Header.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a541cbc1348884ad77c75b2b923ccba91733f2be", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Header : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("responsive-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/logo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(108, 12, true);
            WriteLiteral("\r\n<header>\r\n");
            EndContext();
            BeginContext(262, 289, true);
            WriteLiteral(@"    <div class=""teal lighten-2"">
        <div class=""container"">
            <div class="""">
                <nav class=""teal lighten-2 z-depth-0"">
                    <div class=""nav-wrapper"">
                        <a href=""#"" class=""right brand-logo"">
                            ");
            EndContext();
            BeginContext(551, 65, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "29e8cc987461491e99f08e8d6a4af520", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(616, 32, true);
            WriteLiteral("\r\n                        </a>\r\n");
            EndContext();
#line 18 "F:\Dot Net Project\MLS\src\mls-web\MLS.Web\Views\Shared\Header.cshtml"
                         if (SignInManager.IsSignedIn(User))
                        {

#line default
#line hidden
            BeginContext(737, 337, true);
            WriteLiteral(@"                            <ul class=""left hide-on-med-and-down"">
                                <li><a href=""sass.html"">Sass</a></li>
                                <li><a href=""badges.html"">Components</a></li>
                                <li><a href=""collapsible.html"">JavaScript</a></li>
                            </ul>
");
            EndContext();
#line 25 "F:\Dot Net Project\MLS\src\mls-web\MLS.Web\Views\Shared\Header.cshtml"
                        }

                        else
                        {

#line default
#line hidden
            BeginContext(1160, 174, true);
            WriteLiteral("                            <ul class=\"left hide-on-med-and-down\">\r\n                                <li><a href=\"sass.html\">Sass</a></li>\r\n                            </ul>\r\n");
            EndContext();
#line 32 "F:\Dot Net Project\MLS\src\mls-web\MLS.Web\Views\Shared\Header.cshtml"
                        }

#line default
#line hidden
            BeginContext(1361, 52, true);
            WriteLiteral("                    </div>\r\n                </nav>\r\n");
            EndContext();
            BeginContext(1513, 57, true);
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</header>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<User> SignInManager { get; private set; }
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
