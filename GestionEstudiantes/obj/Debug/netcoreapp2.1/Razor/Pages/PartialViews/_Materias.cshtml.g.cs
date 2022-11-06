#pragma checksum "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\PartialViews\_Materias.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "053b6c470c4163537122bc0e6c24324c58a6479e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GestionEstudiantes.Pages.PartialViews.Pages_PartialViews__Materias), @"mvc.1.0.view", @"/Pages/PartialViews/_Materias.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Pages/PartialViews/_Materias.cshtml", typeof(GestionEstudiantes.Pages.PartialViews.Pages_PartialViews__Materias))]
namespace GestionEstudiantes.Pages.PartialViews
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
#line 6 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\PartialViews\_Materias.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#line 4 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\PartialViews\_Materias.cshtml"
using EstudiantesCore.Dtos;

#line default
#line hidden
#line 5 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\PartialViews\_Materias.cshtml"
using EstudiantesCore.Entidades;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"053b6c470c4163537122bc0e6c24324c58a6479e", @"/Pages/PartialViews/_Materias.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfa7419da8316659c144781a4c853175475d2ac8", @"/Pages/_ViewImports.cshtml")]
    public class Pages_PartialViews__Materias : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(119, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(210, 28, true);
            WriteLiteral("\n<div class=\"detalle\">\n\n    ");
            EndContext();
            BeginContext(240, 1123, false);
#line 10 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\PartialViews\_Materias.cshtml"
Write(Html.DevExtreme().DataGrid<MateriasXEstudiante>()
            .ID("TableMaterias")
            .ShowRowLines(true)
            .Export(s => s.Enabled(true))
            .RowAlternationEnabled(true)
            .ShowBorders(true)            
            .ShowColumnLines(true)
            .FilterRow(s => s.Visible(true))
            .ShowRowLines(true)
            .NoDataText("El estudiante no tiene materías matriculadas")
            .AllowColumnReordering(true)
            .AllowColumnResizing(true)
            .ColumnAutoWidth(true)
            .Paging(s => s.Enabled(true).PageSize(5))
            .SearchPanel(d => d.Visible(true))
            .DataSource(s => s.RemoteController().LoadUrl("/Estudiantes?handler=MateriasEstudiante").OnBeforeSend("MandarDataEstudiante"))
            .Columns(s =>
            {
                s.AddFor(q => q.Materia.Nombre).Caption("Matería");
                s.AddFor(q => q.Estado.Id).Caption("Estado").Lookup(g => g.DataSource(f => f.RemoteController().LoadUrl("/Materias?handler=ObtenerEstadoMaterias").Key("Id")).DisplayExpr("Nombre").ValueExpr("Id"));

            })

    );

#line default
#line hidden
            EndContext();
            BeginContext(1364, 12, true);
            WriteLiteral("\n\n\n\n\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
