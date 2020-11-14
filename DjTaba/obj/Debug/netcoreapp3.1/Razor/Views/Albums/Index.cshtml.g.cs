#pragma checksum "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8dc8dba20afa4235eabb5f0454453252f6b2395"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Albums_Index), @"mvc.1.0.view", @"/Views/Albums/Index.cshtml")]
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
#line 1 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\_ViewImports.cshtml"
using DjTaba;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\_ViewImports.cshtml"
using DjTaba.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8dc8dba20afa4235eabb5f0454453252f6b2395", @"/Views/Albums/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"198e11a37b47d68768299520323e335e46ccc2ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Albums_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DjTaba.Utility.PaginatedList<DjTaba.Models.Album>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""content-header"">
    <h1 style=""float:right"">
        AlbumsManager
    </h1>
    <ol class=""breadcrumb"">
        <li><a href=""#""><i class=""fa fa-dashboard""></i> Home</a></li>
        <li class=""active"">Albums</li>
    </ol>
</section>
<p>
<a id=""addnew"" class=""btn btn-success openmodal"" href=""../Albums/Create"" style=""margin-right: 10px;margin-top: 30px;"" data-toggle=""modal"" data-target=""#myModal""> Add New</a>
</p>
<div class=""row"">
    <div class=""col-sm-12"">
        <div class=""text-center"" style=""border-style: solid;border-color:dimgray"">
            <h2 style=""font-size:medium"">Search</h2>
        </div>
");
#nullable restore
#line 23 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
         using (Html.BeginForm("Index",
             "Albums",
             FormMethod.Post))
        {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""box zmdi-border-color"" style=""height:auto"">
                <div class=""box-body table-responsive no-padding row "">
                    <div style=""width:90%;margin-right:30px;margin-top:20px;"">
                        <div class=""row"" style=""margin-left:20px;"">
                            <label for=""exampleInputEmail1"">Search By Title:</label>
                            <input name=""searchString"" placeholder=""Insert FullName""");
            BeginWriteAttribute("class", " class=\"", 1366, "\"", 1374, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width:260px"">
                        </div>
                    </div>
                </div>
                <div style=""margin-top:20px"">
                    <button style=""margin-right:20px;"" type=""submit"" class=""btn btn-primary"">Search Or Reload</button>
                </div>
            </div>
");
#nullable restore
#line 41 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>




<div class=""row"">
    <div class=""col-xs-12"">
        <div class=""box"">
            <div class=""box-body table-responsive no-padding"">
                <table class=""table table-hover text-center"">
                    <tr>
                        <th>
                            Row
                        </th>
                        <th>
                            Name
                        </th>
                        <th>
                            Genre
                        </th>
                        <th>
                            Description
                        </th>
                        <th>
                            PhotoCreator
                        </th>
                        <th>
                            PublishedDate
                        </th>
                        <th>
                            Image
                        </th>
                        <th>
                            Views
             ");
            WriteLiteral("           </th>\r\n                        <th>\r\n                            Actions\r\n                        </th>\r\n                    </tr>\r\n");
#nullable restore
#line 82 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                       int rowNo = 0; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 87 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                    Write(rowNo += 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 90 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 93 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                   Write(item.Genre.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 95 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                      
                        if (string.IsNullOrEmpty(item.Description))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text text-danger\">\r\n                                No Description !\r\n                            </td>\r\n");
#nullable restore
#line 101 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                ");
#nullable restore
#line 105 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                           Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n");
#nullable restore
#line 107 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                        }

                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 110 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                      

                        if (string.IsNullOrEmpty(item.PhotoCreator))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text text-danger\">\r\n                                No PhotoCreator !\r\n                            </td>\r\n");
#nullable restore
#line 117 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                ");
#nullable restore
#line 121 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                           Write(item.PhotoCreator);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n");
#nullable restore
#line 123 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                        }

                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 126 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                      

                        if (item.PublishedDate == DateTime.MinValue)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"text text-danger\">\r\n                                No Date !\r\n                            </td>\r\n");
#nullable restore
#line 133 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                ");
#nullable restore
#line 137 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                           Write(item.PublishedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n");
#nullable restore
#line 139 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                        }

                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 4900, "\"", 4960, 2);
            WriteAttributeValue("", 4906, "../Upload/Albums/ThumbNail/", 4906, 27, true);
#nullable restore
#line 143 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
WriteAttributeValue("", 4933, item.MainImageUrlThumbNail, 4933, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:50px;height:60px\" />\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 146 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                   Write(item.View);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <button type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#QuestionModal\" onclick=\"AssignButtonClicked(this)\" data-assigned-id=\"");
#nullable restore
#line 149 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                                                                                                                                                                       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"> Remove</button> |\r\n                        <button type=\"button\" class=\"btn btn-warning\" data-toggle=\"modal\" data-target=\"#EditModal\"");
            BeginWriteAttribute("id", " id=\"", 5455, "\"", 5468, 1);
#nullable restore
#line 150 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
WriteAttributeValue("", 5460, item.Id, 5460, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> Edit</button>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 153 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </table>\r\n            </div>\r\n        </div>\r\n\r\n");
#nullable restore
#line 158 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
          
            var prevDisabled = !Model.HasPreviousPage ? "disabled" : "";
            var nextDisabled = !Model.HasNextPage ? "disabled" : "";
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8dc8dba20afa4235eabb5f0454453252f6b239514852", async() => {
                WriteLiteral("\r\n            Previous\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageNumber", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 164 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                      WriteLiteral(Model.PageIndex - 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageNumber", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5899, "btn", 5899, 3, true);
            AddHtmlAttributeValue(" ", 5902, "btn-default", 5903, 12, true);
#nullable restore
#line 165 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
AddHtmlAttributeValue(" ", 5914, prevDisabled, 5915, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8dc8dba20afa4235eabb5f0454453252f6b239517658", async() => {
                WriteLiteral("\r\n            Next\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageNumber", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 169 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
                      WriteLiteral(Model.PageIndex + 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageNumber", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 6075, "btn", 6075, 3, true);
            AddHtmlAttributeValue(" ", 6078, "btn-default", 6079, 12, true);
#nullable restore
#line 170 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Index.cshtml"
AddHtmlAttributeValue(" ", 6090, nextDisabled, 6091, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DjTaba.Utility.PaginatedList<DjTaba.Models.Album>> Html { get; private set; }
    }
}
#pragma warning restore 1591
