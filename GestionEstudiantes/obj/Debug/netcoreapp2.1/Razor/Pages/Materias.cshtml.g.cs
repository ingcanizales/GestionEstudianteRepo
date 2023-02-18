#pragma checksum "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Materias.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6a94fe8cdae062d22f404e38318aadb3596a131"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GestionEstudiantes.Pages.Pages_Materias), @"mvc.1.0.razor-page", @"/Pages/Materias.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Materias.cshtml", typeof(GestionEstudiantes.Pages.Pages_Materias), null)]
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
#line 6 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Materias.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#line 7 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Materias.cshtml"
using EstudiantesCore.Entidades;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6a94fe8cdae062d22f404e38318aadb3596a131", @"/Pages/Materias.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfa7419da8316659c144781a4c853175475d2ac8", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Materias : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Materias.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(57, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(59, 23, false);
#line 5 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Materias.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(82, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(145, 129, true);
            WriteLiteral("\n\n<div class=\"divalumnos\">\n    <div class=\"card\">\n        <div class=\"card-body\">\n            <div class=\"mb-4\">\n                ");
            EndContext();
            BeginContext(276, 108, false);
#line 14 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Materias.cshtml"
            Write(Html.DevExtreme().Button().OnClick("AddModeGrid").Icon("add").Text("Nueva matería").Type(ButtonType.Default));

#line default
#line hidden
            EndContext();
            BeginContext(385, 52, true);
            WriteLiteral("\n\n            </div>\n            <div>\n\n            ");
            EndContext();
            BeginContext(439, 1900, false);
#line 19 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\Materias.cshtml"
        Write(Html.DevExtreme().DataGrid<Materia>()
            .ID("TableMateria")
            .ShowRowLines(true)
            .OnEditorPreparing("EditorPreparado")
            .OnEditingStart("SetEditmode")
            .Export(s => s.Enabled(true))
            .Editing(s=>s.AllowUpdating(true).UseIcons(true).Mode(GridEditMode.Form))
            .RowAlternationEnabled(true)
            .ShowBorders(true)
            .ShowColumnLines(true)
            .FilterRow(s => s.Visible(true))
            .ShowRowLines(true)
            .AllowColumnReordering(true)
            .AllowColumnResizing(true)
            .ColumnAutoWidth(true)
            .Paging(s => s.Enabled(true).PageSize(5))
            .SearchPanel(d => d.Visible(true))
            .DataSource(s => s.RemoteController().UpdateUrl("/Materias?handler=ActualizarMateria").InsertUrl("/Materias?handler=CrearMateria").LoadUrl("/Materias?handler=ObtenerMaterias").Key("Id"))
            .Columns(s =>
            {

                s.AddFor(q => q.Code).Caption("Codigo").ValidationRules(k=>k.AddRequired().Message("Codido es requerido")).ValidationRules(y=>y.AddAsync().ValidationCallback("CodigoUnico").Message("Ya existe una matería con ese codigo registrado")).FormItem(h=>h.Editor(e=>e.TextBox().MaxLength(4)));
                s.AddFor(q => q.Nombre).ValidationRules(g=>g.AddRequired().Message("El nombre es requerido")).Caption("Nombre");
                s.AddFor(q => q.Estado.Id).Caption("Estado").Lookup(g => g.DataSource(f => f.RemoteController().LoadUrl("/Materias?handler=ObtenerEstadoMaterias").Key("Id")).DisplayExpr("Nombre").ValueExpr("Id"));
                s.AddFor(g => g.year).ValidationRules(g => g.AddRequired().Message("El año es requerido")).Caption("Año").FormItem(k => k.Editor(l => l.NumberBox().Min(DateTime.Now.Year)));
                //s.AddFor(g => g.MatriculaPorDefecto).Caption("Defecto");
            })

            );

#line default
#line hidden
            EndContext();
            BeginContext(2340, 58, true);
            WriteLiteral("\n\n\n            </div>\n        </div>\n    </div>\n</div>\n\n\n\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2420, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(2425, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6eb1ef8701b4bd5a9404fc1c97a2193", async() => {
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
                BeginContext(2465, 1, true);
                WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestionEstudiantes.Pages.MateriasModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GestionEstudiantes.Pages.MateriasModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GestionEstudiantes.Pages.MateriasModel>)PageContext?.ViewData;
        public GestionEstudiantes.Pages.MateriasModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
