#pragma checksum "D:\PROJETOS\dedinfoservices\DedInfoservices\Views\Login\RecuperacaoDeSenha.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b309ef3d34640236fe7d3b522e06d8a47119bb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_RecuperacaoDeSenha), @"mvc.1.0.view", @"/Views/Login/RecuperacaoDeSenha.cshtml")]
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
#line 1 "D:\PROJETOS\dedinfoservices\DedInfoservices\Views\_ViewImports.cshtml"
using DedInfoservices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\PROJETOS\dedinfoservices\DedInfoservices\Views\_ViewImports.cshtml"
using DedInfoservices.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b309ef3d34640236fe7d3b522e06d8a47119bb3", @"/Views/Login/RecuperacaoDeSenha.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82ee5ac7fe13ea48b16769e01951cddff79f5a64", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_RecuperacaoDeSenha : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\PROJETOS\dedinfoservices\DedInfoservices\Views\Login\RecuperacaoDeSenha.cshtml"
  
    ViewData["Title"] = "Recuperaçao de Senha";
    Layout = "_LayoutLogin";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"center-form background-image-login\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b309ef3d34640236fe7d3b522e06d8a47119bb33908", async() => {
                WriteLiteral(@"
        <div class=""titulo-login"">
            <h3>LOGIN</h3>
        </div>

        <div>
            <div id=""errorModal"" style=""display: none"">
                <div id=""msgError"" class=""alert alert-danger alert-dismissible fade show"" role=""alert"">
                    <i class=""fa fa-ban""></i>
                    <button class=""btn-close"" onclick=""fechar_alerta();"" aria-hidden=""true"" type=""button""></button>

                    <span id=""erroMsg""></span>
                </div>
            </div>
            <div id=""sucessModal"" style=""display: none"">
                <div id=""msgSucess"" class=""alert alert-success alert-dismissible fade show"" role=""alert"">
                    <i class=""fa fa-check""></i>
                    <button class=""btn-close"" onclick=""fechar_alerta();"" aria-hidden=""true"" type=""button""></button>

                    <span id=""sucessMsg""></span>
                </div>
            </div>
        </div>

        <div class=""form-group"">
            <label for=""em");
                WriteLiteral(@"ail"">Email</label>
            <input type=""email"" class=""form-control"" id=""email"" aria-describedby=""email"" placeholder=""login@login.com.br"">
        </div>

        <div class=""form-group mt-3"">
            <button class=""btn btn-success"" type=""button"" id=""btn-entrar"" onclick=""EsqueceuSenha();"">Recuperar</button>
        </div>


        <div class=""form-group voltar"">
            <a");
                BeginWriteAttribute("href", " href=\"", 1582, "\"", 1618, 1);
#nullable restore
#line 42 "D:\PROJETOS\dedinfoservices\DedInfoservices\Views\Login\RecuperacaoDeSenha.cshtml"
WriteAttributeValue("", 1589, Url.Action("Index", "Login"), 1589, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Voltar</a>\r\n        </div>\r\n\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>

<script>

    function EsqueceuSenha() {
        fechar_alerta();

        let email = $('#email').val();
        $('#msgError #erroMsg').html();
        $('#item_form #msgError').hide();
        $.ajax({
            type: 'POST',
            data: {
                'email': email,
            },
            url: '");
#nullable restore
#line 61 "D:\PROJETOS\dedinfoservices\DedInfoservices\Views\Login\RecuperacaoDeSenha.cshtml"
             Write(Url.Action("EsqueceuSenha", "Login"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            success: function (result) {
                if (result.is_action) {
                    $('.overlay').hide();
                    $('#errorModal').hide();
                    $('#msgSucess #sucessMsg').html('Nova senha enviada com sucesso!!!');
                    $('#sucessModal').show();
                    $('#email').val('');
                }
                else
                {
                    $('#msgError #erroMsg').html(result.error);
                    $('#errorModal').show();
                    $('#sucessModal').hide();
                }
            },
            error: function (error) {
                $('#msgError #erroMsg').html(result.error);
                $('#errorModal').show();
            },
            datatype: 'json'
        });
    }

    function fechar_alerta() {
        $('#errorModal').hide();
        $('#sucessModal').hide();
    }


</script>
");
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
