#pragma checksum "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudiantes\Pages\Profesores.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebe5e9e0b588506d334a73e456fea052c6e147dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GestionEstudiantes.Pages.Pages_Profesores), @"mvc.1.0.razor-page", @"/Pages/Profesores.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Profesores.cshtml", typeof(GestionEstudiantes.Pages.Pages_Profesores), null)]
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
#line 1 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudiantes\Pages\_ViewImports.cshtml"
using GestionEstudiantes;

#line default
#line hidden
#line 6 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudiantes\Pages\Profesores.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#line 7 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudiantes\Pages\Profesores.cshtml"
using EstudiantesCore.Entidades;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebe5e9e0b588506d334a73e456fea052c6e147dc", @"/Pages/Profesores.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfa7419da8316659c144781a4c853175475d2ac8", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Profesores : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Profesores.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(59, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(61, 23, false);
#line 5 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudiantes\Pages\Profesores.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(84, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(147, 129, true);
            WriteLiteral("\n\n<div class=\"divalumnos\">\n    <div class=\"card\">\n        <div class=\"card-body\">\n            <div class=\"mb-4\">\n                ");
            EndContext();
            BeginContext(278, 109, false);
#line 14 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudiantes\Pages\Profesores.cshtml"
            Write(Html.DevExtreme().Button().OnClick("AddModeGrid").Icon("add").Text("Nuevo profesor").Type(ButtonType.Default));

#line default
#line hidden
            EndContext();
            BeginContext(388, 56, true);
            WriteLiteral("\n\n            </div>\n            <div>\n\n                ");
            EndContext();
            BeginContext(446, 2351, false);
#line 19 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudiantes\Pages\Profesores.cshtml"
            Write(Html.DevExtreme().DataGrid<Profesor>()
            .ID("TableProfesores")
            .OnEditorPreparing("EditorPreparado")
            .ShowRowLines(true)
            .OnEditingStart("SetEditmode")
            .Export(s => s.Enabled(true))
            .Editing(s=>s.AllowUpdating(true).UseIcons(true).Mode(GridEditMode.Popup).Popup(h=>h.DragEnabled(true)))
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
            .DataSource(s => s.RemoteController().UpdateUrl("/Profesores?handler=ActualizarProfesor").InsertUrl("/Profesores?handler=CrearProfesor").LoadUrl("/Profesores?handler=ObtenerProfesores").Key("Id"))
            .Columns(s =>
            {

                s.AddFor(q => q.TipoDocumento.Id).Caption("Tipo documento").FormItem(f=>f.Editor(g=>g.SelectBox().ID("SelectTipoDocumento").DataSource(h=>h.RemoteController().LoadUrl("/Estudiantes?handler=TipoDocumento").Key("Id")).DisplayExpr("Nombre"))).Lookup(g => g.DataSource(f => f.RemoteController().LoadUrl("/Estudiantes?handler=TipoDocumento").Key("Id")).DisplayExpr("Nombre").ValueExpr("Id"));
                s.AddFor(g => g.Documento).ValidationRules(f=>f.AddAsync().ValidationCallback("IdentificacionUnica").Message("Ya existe un profesor registrado con este documento").Reevaluate(true)) .ValidationRules(g => g.AddRequired().Message("El documento es requerido")).ValidationRules(g => g.AddStringLength().Min(3).Message("Mínimo 3 caracteres")).Caption("Documento").FormItem(k => k.Editor(l => l.TextBox().MaxLength(20)));
                s.AddFor(q => q.Nombre).ValidationRules(g=>g.AddRequired().Message("El nombre es requerido")).Caption("Nombre");
                s.AddFor(q => q.Apellido).ValidationRules(g => g.AddRequired().Message("El apellido es requerido")).Caption("Apellido");
                s.AddFor(q => q.Estado.Id).Caption("Estado").Lookup(g => g.DataSource(f => f.RemoteController().LoadUrl("/Profesores?handler=EstadosProfesores").Key("Id")).ValueExpr("Id").DisplayExpr("Nombre"));

            })

            );

#line default
#line hidden
            EndContext();
            BeginContext(2798, 58, true);
            WriteLiteral("\n\n\n            </div>\n        </div>\n    </div>\n</div>\n\n\n\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2878, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(2883, 42, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4c42614f7a448c6b5dd042ceb758c11", async() => {
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
                BeginContext(2925, 1, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestionEstudiantes.Pages.ProfesoresModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GestionEstudiantes.Pages.ProfesoresModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GestionEstudiantes.Pages.ProfesoresModel>)PageContext?.ViewData;
        public GestionEstudiantes.Pages.ProfesoresModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
