#pragma checksum "C:\Users\miros\OneDrive\Рабочий стол\GitHubRepos\TestTaskAspNetCore\MyApp\MyApp\Views\Home\Succes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "446a7b0c4379476776cf477f78e29a8fa565bc3d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Succes), @"mvc.1.0.view", @"/Views/Home/Succes.cshtml")]
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
#line 1 "C:\Users\miros\OneDrive\Рабочий стол\GitHubRepos\TestTaskAspNetCore\MyApp\MyApp\Views\_ViewImports.cshtml"
using MyApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\miros\OneDrive\Рабочий стол\GitHubRepos\TestTaskAspNetCore\MyApp\MyApp\Views\_ViewImports.cshtml"
using MyApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"446a7b0c4379476776cf477f78e29a8fa565bc3d", @"/Views/Home/Succes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11677bef14cb8a5c5f02f7f352b9baf0a6209476", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Succes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\miros\OneDrive\Рабочий стол\GitHubRepos\TestTaskAspNetCore\MyApp\MyApp\Views\Home\Succes.cshtml"
  
    ViewData["Title"] = "Данные отправлены";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""text-center"">
        <h1 class=""display-4"">Данные успешно отправлены на сервер</h1>
        <h2>Выберите действие</h2>
        <p><pre><a href=""/Home/Upload""><u>Загрузить еще данные</u></a>      <a href=""/Home/DataView""><u>Просмотреть данные</u></a></pre></p>
    </div>");
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
