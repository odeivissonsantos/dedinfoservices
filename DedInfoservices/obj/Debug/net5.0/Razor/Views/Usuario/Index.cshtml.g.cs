#pragma checksum "D:\PROJETOS\dedinfoservices\DedInfoservices\Views\Usuario\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f06c2722d195ac7038282823661a58bc9ecca41c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Index), @"mvc.1.0.view", @"/Views/Usuario/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f06c2722d195ac7038282823661a58bc9ecca41c", @"/Views/Usuario/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82ee5ac7fe13ea48b16769e01951cddff79f5a64", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/usuario.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\PROJETOS\dedinfoservices\DedInfoservices\Views\Usuario\Index.cshtml"
  
    ViewData["Title"] = "Usuários";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f06c2722d195ac7038282823661a58bc9ecca41c4003", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<section>
    <div class=""text-center container"">
        <br />
        <h2>Usuários</h2>
        <br />

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

        <table id=""list_ite");
            WriteLiteral(@"ms"" class=""table table-bordered table-striped"">
            <thead>
                <tr>
                    <th>Nome</th>
                    <th>Perfil</th>
                    <th>Data Cadastro</th>
                    <th>Qtd. Acessos</th>
                    <th>Último Acesso</th>
                    <th>Ação</th>
                </tr>
            </thead>
            <tbody></tbody>
            <tfoot>
                <tr>
                    <th>Nome</th>
                    <th>Perfil</th>
                    <th>Data Cadastro</th>
                    <th>Qtd. Acessos</th>
                    <th>Último Acesso</th>
                    <th>Ação</th>
                </tr>
            </tfoot>
        </table>
    </div>


</section>

<script type=""text/javascript"">

    $(document).ready(function () {
        listar();
    });

    function listar() {
        $('#list_items').dataTable({
            'bPaginate': true,
            'bJQueryUI': true,
            'bPro");
            WriteLiteral("cessing\': true,\r\n            \'bServerSide\': true,\r\n            \"searching\": true,\r\n            \'bDestroy\': true,\r\n            \'sAjaxSource\': `");
#nullable restore
#line 75 "D:\PROJETOS\dedinfoservices\DedInfoservices\Views\Usuario\Index.cshtml"
                       Write(Url.Action("UsuariosPagination", "Usuario"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"`,
            'sServerMethod': 'POST',
            'aoColumns': [
                { 'mData': 'nome' },
                { 'mData': 'perfil' },
                { 'mData': 'data_cadastro' },
                { 'mData': 'qtd_acessos' },
                { 'mData': 'data_ultimo_acesso' },
                { 'mData': 'acao' },
            ],
            ""language"": {
                ""url"": ""//cdn.datatables.net/plug-ins/1.12.1/i18n/pt-BR.json""
            }
        });
    };

    function reativar(guuid) {
        fechar_alerta();
        $.ajax({
            type: 'POST',
            data: {
                'guuid': guuid
            },
            url: '");
#nullable restore
#line 98 "D:\PROJETOS\dedinfoservices\DedInfoservices\Views\Usuario\Index.cshtml"
             Write(Url.Action("ReativarUsuario", "Usuario"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            success: function (result) {
                if (result.is_action) {
                    $('#msgSucess #sucessMsg').html('Usuário reativado com sucesso.');
                    $('#sucessModal').show();
                    listar();
                }
                else {
                    $('#msgError #erroMsg').html(result.error);
                    $('#errorModal').show();
                }
            },
            error: function (error)
            {
                $('#msgError #erroMsg').html(error.error);
                $('#errorModal').show();
            },
            datatype: 'json'
        });
    }

    function desativar(guuid) {
        fechar_alerta();
        $.ajax({
            type: 'POST',
            data: {
                'guuid': guuid
            },
            url: '");
#nullable restore
#line 126 "D:\PROJETOS\dedinfoservices\DedInfoservices\Views\Usuario\Index.cshtml"
             Write(Url.Action("DesativarUsuario", "Usuario"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            success: function (result) {
                if (result.is_action) {
                    $('#msgSucess #sucessMsg').html('Usuário desativado com sucesso.');
                    $('#sucessModal').show();
                    listar();
                }
                else {
                    $('#msgError #erroMsg').html(result.error);
                    $('#errorModal').show();
                }
            },
            error: function (error)
            {
                $('#msgError #erroMsg').html(error.error);
                $('#errorModal').show();
            },
            datatype: 'json'
        });
    }

    function fechar_alerta() {
        $('#errorModal').hide();
        $('#sucessModal').hide();
    }


</script>");
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
