#pragma checksum "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\PartialViews\_Documentos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4927c8f7988bb7722dea82efb0ac4a13d0092d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GestionEstudiantes.Pages.PartialViews.Pages_PartialViews__Documentos), @"mvc.1.0.view", @"/Pages/PartialViews/_Documentos.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Pages/PartialViews/_Documentos.cshtml", typeof(GestionEstudiantes.Pages.PartialViews.Pages_PartialViews__Documentos))]
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
#line 4 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\PartialViews\_Documentos.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#line 2 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\PartialViews\_Documentos.cshtml"
using EstudiantesCore.Dtos;

#line default
#line hidden
#line 3 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\PartialViews\_Documentos.cshtml"
using EstudiantesCore.Entidades;

#line default
#line hidden
#line 5 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\PartialViews\_Documentos.cshtml"
using EstudiantesCore.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4927c8f7988bb7722dea82efb0ac4a13d0092d9", @"/Pages/PartialViews/_Documentos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfa7419da8316659c144781a4c853175475d2ac8", @"/Pages/_ViewImports.cshtml")]
    public class Pages_PartialViews__Documentos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(130, 31, true);
            WriteLiteral("\r\n<div class=\"detalle\">\r\n\r\n    ");
            EndContext();
            BeginContext(163, 1776, false);
#line 9 "C:\Users\Usuario\Desktop\GestionEstudiantes-feature2.0\GestionEstudianteRepo\GestionEstudiantes\Pages\PartialViews\_Documentos.cshtml"
Write(Html.DevExtreme().Form<EstudianteDTO>
    ()
    .ID("FormDocumentos")
    .ColCount(12)
    .Items(items =>
    {

        items.AddSimpleFor(g => g.FotocopiaCedula).ColSpan(4).Label(f => f.Location(FormLabelLocation.Top)
        .Text("Fotocopia de la Cédula al 150%"))
        .Editor(d => d.CheckBox());



        items.AddSimpleFor(g => g.RegistroCivil).ColSpan(4).Label(f => f.Location(FormLabelLocation.Top)
        .Text("Fotocopia del Registro Civil"))
        .Editor(d => d.CheckBox());

        items.AddSimpleFor(g => g.TargetaIdentidad).ColSpan(4).Label(f => f.Location(FormLabelLocation.Top)
        .Text("Fotocopia de la Targeta de Identidad"))
        .Editor(d => d.CheckBox());

        items.AddSimpleFor(g => g.Foto).ColSpan(4).Label(f => f.Location(FormLabelLocation.Top)
        .Text("Dos fotos Medio Cuerpo"))
        .Editor(d => d.CheckBox());


        items.AddSimpleFor(g => g.Carpeta).ColSpan(4).Label(f => f.Location(FormLabelLocation.Top)
        .Text("Una Carpeta Azul"))
        .Editor(d => d.CheckBox());

        items.AddSimpleFor(g => g.PazySalvo).ColSpan(4).Label(f => f.Location(FormLabelLocation.Top)
        .Text("Paz y Salvo"))
        .Editor(d => d.CheckBox());

        items.AddSimpleFor(g => g.CertificadoEstudio).ColSpan(4).Label(f => f.Location(FormLabelLocation.Top)
        .Text("Certificado de Último Grado Cursado"))
        .Editor(d => d.CheckBox());


        items.AddEmpty().ColSpan(8);

        items.AddEmpty().ColSpan(12);



        items.AddButton().ColSpan(4).VerticalAlignment(VerticalAlignment.Bottom).ButtonOptions(s => s.Icon("save").ID("btnsalvar").Type(ButtonType.Default).OnClick("SalvarDocumentos").Text("Documentos Completos"));

    })

        );

#line default
#line hidden
            EndContext();
            BeginContext(1940, 14, true);
            WriteLiteral("\r\n\r\n\r\n\r\n</div>");
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