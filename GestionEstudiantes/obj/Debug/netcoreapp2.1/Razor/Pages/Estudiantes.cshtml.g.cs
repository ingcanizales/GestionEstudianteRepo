#pragma checksum "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Estudiantes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "edd91ffce7d214f3464c24e9934a3b43d28b6df9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GestionEstudiantes.Pages.Pages_Estudiantes), @"mvc.1.0.razor-page", @"/Pages/Estudiantes.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Estudiantes.cshtml", typeof(GestionEstudiantes.Pages.Pages_Estudiantes), null)]
namespace GestionEstudiantes.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\_ViewImports.cshtml"
using GestionEstudiantes;

#line default
#line hidden
#line 8 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Estudiantes.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#line 3 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Estudiantes.cshtml"
using EstudiantesCore.Dtos;

#line default
#line hidden
#line 4 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Estudiantes.cshtml"
using EstudiantesCore.Entidades;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edd91ffce7d214f3464c24e9934a3b43d28b6df9", @"/Pages/Estudiantes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfa7419da8316659c144781a4c853175475d2ac8", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Estudiantes : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Estudiantes.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(126, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(129, 23, false);
#line 7 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Estudiantes.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(152, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(184, 221, true);
            WriteLiteral("\r\n<div class=\"divalumnos\">\r\n\r\n    <div class=\"card\">\r\n\r\n        <div class=\"card-body\">\r\n\r\n            <div id=\"divgrid\">\r\n\r\n                <h1>Estudiantes Matriculados</h1>\r\n\r\n                <div>\r\n                    ");
            EndContext();
            BeginContext(407, 137, false);
#line 21 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Estudiantes.cshtml"
                Write(Html.DevExtreme().Button().Text("Nuevo Estudiante").Type(ButtonType.Default).Icon("add").OnClick("EsconderGrid").Type(ButtonType.Default));

#line default
#line hidden
            EndContext();
            BeginContext(545, 46, true);
            WriteLiteral("\r\n                </div>\r\n\r\n\r\n                ");
            EndContext();
            BeginContext(593, 2132, false);
#line 25 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Estudiantes.cshtml"
            Write(Html.DevExtreme().DataGrid<Estudiante>()
    .ID("TableEstudiantes")
    //.Editing(s=>s.AllowAdding(true).AllowUpdating(true).AllowDeleting(true).UseIcons(true).Mode(GridEditMode.Form))
    .ShowRowLines(true)
    .RemoteOperations(d => d.Paging(true).Filtering(true))
    .Export(s => s.Enabled(true))
    .RowAlternationEnabled(true)
    .ShowBorders(true)
    .ShowColumnLines(true)
    .FilterRow(s => s.Visible(true))
    .ShowRowLines(true)
    .OnRowExpanding("Expading")
    .AllowColumnReordering(true)
    .AllowColumnResizing(true)
    .ColumnAutoWidth(true)
    .Paging(s => s.Enabled(true).PageSize(5))
    .Pager(s => s.AllowedPageSizes(new List<int>
    { 5, 10, 15 }).ShowNavigationButtons(true).ShowPageSizeSelector(true))
    .SearchPanel(d => d.Visible(true))
    .DataSource(s => s.RemoteController().LoadUrl("/Estudiantes?handler=AllEstudiante").OnBeforeSend("MandarParametrosBusqueda"))
    .Columns(s=>
    {
        s.AddFor(q => q.TipoDocumento.Id).Caption("Tipo de documento").Lookup(q => q.DataSource(f => f.RemoteController().LoadUrl("/Estudiantes?handler=TipoDocumento").Key("Id")).ValueExpr("Id").DisplayExpr("Nombre"));
        s.AddFor(q => q.Documento).Caption("Documento");
        s.AddFor(q => q.Nombre).Caption("Nombres");
        s.AddFor(q => q.Apellido).Caption("Apellidos");
        s.AddFor(q => q.Estado.Id).Caption("Estado").Lookup(h => h.DataSource(f => f.RemoteController().LoadUrl("/Estudiantes?handler=EstadoEstudiante").Key("Id")).DisplayExpr("Nombre").ValueExpr("Id"));
        s.Add().Visible(true)
        .Type(GridCommandColumnType.Buttons)
        .Width(110).Buttons(b =>
        {
            //Icons: DevExtreme - JavaScript UI Components for Angular ...
            b.Add().Icon("edit").Hint("Editar").OnClick("EditarEstudianteFromGrid");
            b.Add().Icon("info").Hint("Detalle").OnClick("VerEstudianteFromGrid");
            b.Add().Icon("trash").Hint("Eliminar").OnClick("EliminarEstudiante");

        });

    }).MasterDetail(d => d.AutoExpandAll(false).Enabled(true).Template(new TemplateName("DetalleEstudiante")))
    );

#line default
#line hidden
            EndContext();
            BeginContext(2726, 103, true);
            WriteLiteral("\r\n\r\n\r\n            </div>\r\n\r\n            <div style=\"display:none\" id=\"divformulario\">\r\n                ");
            EndContext();
            BeginContext(2831, 69, false);
#line 70 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Estudiantes.cshtml"
            Write(await Html.PartialAsync("/Pages/PartialViews/_formestudiante.cshtml"));

#line default
#line hidden
            EndContext();
            BeginContext(2901, 66, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n</div>\r\n\r\n\r\n");
            EndContext();
#line 79 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Estudiantes.cshtml"
 using (Html.DevExtreme().NamedTemplate("DetalleEstudiante"))
{

#line default
#line hidden
            BeginContext(3033, 638, false);
#line 80 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Estudiantes.cshtml"
Write(Html.DevExtreme().TabPanel()
        .SelectedIndex(0)
        .ID("Tappanel")
        .Loop(false)
        .AnimationEnabled(true)
        .SwipeEnabled(true)
        .Items(item2 =>
        {

            item2.Add().Icon("add").Title("Materias").Template(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    BeginContext(3307, 1, true);
    WriteLiteral(" ");
    EndContext();
    BeginContext(3310, 63, false);
#line 89 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Estudiantes.cshtml"
                                                                   Write(await Html.PartialAsync("/Pages/PartialViews/_Materias.cshtml"));

#line default
#line hidden
    EndContext();
    BeginContext(3374, 1, true);
    WriteLiteral(" ");
    EndContext();
    PopWriter();
}
));
            //item2.Add().Icon("add").Title("Materias").Template(@<text> @(await Html.PartialAsync("/Pages/PartialViews/_MateriasActivas.cshtml")) </text>);
            item2.Add().Icon("add").Title("Notas").Template(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    BeginContext(3611, 1, true);
    WriteLiteral(" ");
    EndContext();
    BeginContext(3614, 60, false);
#line 91 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Estudiantes.cshtml"
                                                                Write(await Html.PartialAsync("/Pages/PartialViews/_notas.cshtml"));

#line default
#line hidden
    EndContext();
    BeginContext(3675, 1, true);
    WriteLiteral(" ");
    EndContext();
    PopWriter();
}
));

        })
    );

#line default
#line hidden
            EndContext();
#line 94 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Estudiantes.cshtml"
     }

#line default
#line hidden
            BeginContext(3709, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            BeginContext(4270, 16, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(4309, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4315, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f656c332bdac4752b05e292cfb4aa5ca", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4358, 2, true);
                WriteLiteral("\r\n");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestionEstudiantes.Pages.EstudiantesModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GestionEstudiantes.Pages.EstudiantesModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GestionEstudiantes.Pages.EstudiantesModel>)PageContext?.ViewData;
        public GestionEstudiantes.Pages.EstudiantesModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
