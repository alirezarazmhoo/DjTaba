#pragma checksum "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77d4be5454b70b1669fb4d6e9576d038e15f9dd9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Albums_Create), @"mvc.1.0.view", @"/Views/Albums/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77d4be5454b70b1669fb4d6e9576d038e15f9dd9", @"/Views/Albums/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"198e11a37b47d68768299520323e335e46ccc2ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Albums_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DjTaba.Models.Album>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml"
  
    ViewData["Title"] = "Create";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml"
 using (Html.BeginForm("Create",
                    "MarketerTutorials",
                    FormMethod.Post, new { enctype = "multipart/form-data" }))
{



#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""row"">
        <div class=""col-xs-12"">
            <div class=""box"" style=""height:auto"">

                <div class=""text-center text-blue"" style=""border-style:solid;"">
                    <h2>Add Album</h2>
                </div>

                <div class=""form-horizontal"">

                    <hr />
                    ");
#nullable restore
#line 25 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml"
               Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    <div class=\"form-horizontal\">\r\n                        <div class=\"form-group\">\r\n                            ");
#nullable restore
#line 29 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml"
                       Write(Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <div class=\"col-md-10\">\r\n                                ");
#nullable restore
#line 31 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml"
                           Write(Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control", @style = "width:50%" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 32 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml"
                           Write(Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            ");
#nullable restore
#line 36 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml"
                       Write(Html.LabelFor(model => model.PublishedDate, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <div class=\"col-md-10\">\r\n                                ");
#nullable restore
#line 38 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml"
                           Write(Html.EditorFor(model => model.PublishedDate, new { htmlAttributes = new { @class = "form-control", @style = "width:50%", @type = "date" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 39 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml"
                           Write(Html.ValidationMessageFor(model => model.PublishedDate, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"form-group\">\r\n                            ");
#nullable restore
#line 43 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml"
                       Write(Html.LabelFor(model => model.PhotoCreator, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <div class=\"col-md-10\">\r\n                                ");
#nullable restore
#line 45 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml"
                           Write(Html.EditorFor(model => model.PhotoCreator, new { htmlAttributes = new { @class = "form-control", @style = "width:50%" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 46 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml"
                           Write(Html.ValidationMessageFor(model => model.PhotoCreator, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"form-group\" style=\"margin-right:-10px\">\r\n                            ");
#nullable restore
#line 50 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml"
                       Write(Html.LabelFor(model => model.Description, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            <div class=""col-md-10"">
                                <textarea class=""form-control"" name=""Description"" placeholder=""Description"" style=""max-width:50%;max-height:200px"">
                            </textarea>
                                ");
#nullable restore
#line 54 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml"
                           Write(Html.ValidationMessageFor(model => model.Description, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                        </div>
                        <div class=""form-group "" style=""margin-left:60px"">
                            <div id=""main-container"">
                                <button type=""button"" style=""height:20%;margin-left:15px;top:0;"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#ModalGenre""><i class=""fa fa-language""></i> Select Genres  </button>
                            </div>
                        </div>
                        <div class=""form-group "" style=""margin-left:60px"">
                            <div id=""main-container"">
                                <button type=""button"" style=""height:20%;margin-left:15px;top:0;"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#ModalArtist""><i class=""fa fa-users""></i> Select Artists  </button>
                            </div>
                        </div>
                        <div class=""form-group "" style=""margin-left:60px"">
                            <div ");
            WriteLiteral(@"id=""main-container"">
                                <button type=""button"" style=""height:20%;margin-left:15px;top:0;"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#ModalMusic""><i class=""fa fa-music""></i> Select Musics  </button>
                            </div>
                        </div>


                        <div class=""form-group "" style=""margin-left:60px"">
                            <label for=""exampleInputEmail1""> SelecAlbumCoverPicutre :</label>
                            <div id=""main-container"">
                                <input display=""Album"" id=""PicutreAlbumUrl"" name=""PicutreAlbumUrl"" class=""TheFile"" onchange=""SetPictures('PicutreAlbumUrl','ImageAlbumUrl');"" style=""display:none"" type=""file"" required>
                                <button type=""button"" style=""height:20%;margin-left:15px;top:0;"" class=""btn btn-primary"" onclick=""PicutreAlbumUrl.click()""><i class=""fa fa-photo""></i> Choose Picture  </button>
                                <div id=""ImageAlbumUrl""");
            WriteLiteral(@" style=""width:400px;height:auto;margin-left:5px;margin-top:5px"">
                                </div>
                            </div>
                        </div>
                        <div class=""form-group"" style=""margin-left:60px;margin-top:10px"">
                            <label for=""exampleInputEmail1""> ChooseOtherPictures :</label>
                            <div id=""main-container"">
                                <input display=""AlbumsFiles"" id=""AlbumsFiles"" name=""AlbumsFiles"" class=""AlbumsUrl"" onchange=""SetPictures('AlbumsFiles','AlbumsFilesItems');"" style=""display:none"" multiple type=""file"">
                                <button type=""button"" style=""height:20%;margin-left:15px;top:0;"" class=""btn btn-primary"" onclick=""AlbumsFiles.click()""><i class=""fa fa-file-audio-o""></i>Choose</button>
                                <div id=""AlbumsFilesItems"" style=""width:400px;height:auto;margin-left:5px;margin-top:10px"">
                                </div>
                            ");
            WriteLiteral("</div>\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n");
#nullable restore
#line 101 "C:\Users\Razmjoo\source\repos\DjTaba\DjTaba\Views\Albums\Create.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""modal fade"" id=""ModalGenre"" role=""dialog"" style=""height:auto;overflow-y:visible"">
    <div class=""modal-dialog modal-sm"" style=""width:400px"">
        <div class=""modal-content"">
            <div class=""modal-header text-center"">
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                <h4 class=""modal-title"">Select Genres</h4>
            </div>
            <div class=""modal-body text-center"" style=""height:auto;"" id=""listGenresModalBody"">
");
            WriteLiteral(@"           

            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"">Cancel</button>
                <button type=""button"" class=""btn btn-success"">ok</button>
            </div>
        </div>
    </div>
</div>
<div class=""modal fade"" id=""ModalArtist"" role=""dialog"" style=""height:auto;overflow-y:visible"">
    <div class=""modal-dialog modal-lg"" style=""width:400px"">
        <div class=""modal-content"">
            <div class=""modal-header text-center"">
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                <h4 class=""modal-title"">Select Artists</h4>
            </div>
            <div class=""modal-body"" style=""height:auto"">
                <table id=""tableProduct"" class=""table table-hover text-center"">
                    <tr>
                        <th>Row</th>
                        <th>Name </th>
                        <th>Select</th>

               ");
            WriteLiteral(@"     </tr>
                    <tr>
                        <td>1</td>

                        <td>Ali</td>
                        <td><input type=""checkbox"" /></td>

                    </tr>
                    <tr>
                        <td>2</td>

                        <td>Reza</td>
                        <td><input type=""checkbox"" /></td>


                    </tr>
                </table>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"">Cancel</button>
                <button type=""button"" class=""btn btn-success"">ok</button>
            </div>
        </div>
    </div>
</div>
<div class=""modal fade"" id=""ModalMusic"" role=""dialog"" style=""height:auto;overflow-y:visible"">
    <div class=""modal-dialog modal-sm"" style=""width:400px"">
        <div class=""modal-content"">
            <div class=""modal-header text-center"">
                <button type=""button"" class=""close"" data-dismiss=""");
            WriteLiteral(@"modal"">&times;</button>
                <h4 class=""modal-title"">Select Muscis</h4>
            </div>
            <div class=""modal-body"" style=""height:auto"">
                <table id=""tableProduct"" class=""table table-hover text-center"">
                    <tr>
                        <th>Row</th>
                        <th>Name </th>
                        <th>Select</th>

                    </tr>
                    <tr>
                        <td>1</td>

                        <td>Music1</td>
                        <td><input type=""checkbox"" /></td>

                    </tr>
                    <tr>
                        <td>2</td>

                        <td>Musci2</td>
                        <td><input type=""checkbox"" /></td>


                    </tr>
                </table>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"">Cancel</button>
                <button type=""b");
            WriteLiteral(@"utton"" class=""btn btn-success"">ok</button>
            </div>
        </div>
    </div>
</div>
<div class=""row"" style=""margin-left : 10px"">
    <a class=""btn btn-warning"" href=""/Albums/Index""> Return</a>
    <input type=""submit"" value=""Save"" class=""btn btn-success"" />
</div>



<script>
        window.onload = Load;
	function Load() {
		FillModal();
	}

	function FillModal() {
		AjaxFillModal(""../Albums/LoadGenres"",""listGenresModalBody"");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DjTaba.Models.Album> Html { get; private set; }
    }
}
#pragma warning restore 1591