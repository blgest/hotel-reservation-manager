#pragma checksum "C:\Users\Blagovest\Desktop\GitHub\hotel-reservation-manager\HotelReservationManager\HotelReservationManager.Web\Views\HotelUser\ActiveList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11d80ac1698d7461bd54bc7cffab66cfa8c0c202"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HotelUser_ActiveList), @"mvc.1.0.view", @"/Views/HotelUser/ActiveList.cshtml")]
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
#line 1 "C:\Users\Blagovest\Desktop\GitHub\hotel-reservation-manager\HotelReservationManager\HotelReservationManager.Web\Views\_ViewImports.cshtml"
using HotelReservationManager.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Blagovest\Desktop\GitHub\hotel-reservation-manager\HotelReservationManager\HotelReservationManager.Web\Views\_ViewImports.cshtml"
using HotelReservationManager.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11d80ac1698d7461bd54bc7cffab66cfa8c0c202", @"/Views/HotelUser/ActiveList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30587656ca5299e7b51d828ad03df4cdcef04603", @"/Views/_ViewImports.cshtml")]
    public class Views_HotelUser_ActiveList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<div class=\"container\">\r\n\r\n    <h1 class=\"mt-4 mb-3\">Active Users</h1>\r\n\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11d80ac1698d7461bd54bc7cffab66cfa8c0c2024091", async() => {
                WriteLiteral("My Hotel");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </li>
        <li class=""breadcrumb-item active"">Users</li>
        <li class=""breadcrumb-item active"">Active</li>
    </ol>

    <div class=""card mb-4"">
        <h5 class=""card-header"">Search</h5>
        <div class=""card-body"">
            <div class=""input-group"">
                <input id=""search"" type=""text"" class=""form-control"" placeholder=""Search by some Name"">
            </div>
        </div>
    </div>

    <div id=""active-users"">

    </div>


    <ul class=""pagination justify-content-center"">
        <li class=""page-item"">
            <a class=""page-link"" onclick=""prevPage()"" id=""btn_prev"" aria-label=""Previous"">
                <span aria-hidden=""true"">&laquo;</span>
                <span class=""sr-only"">Previous</span>
            </a>
        </li>
        <li class=""page-item"">
            <a class=""page-link"" id=""page""></a>
        </li>
        <li class=""page-item"">
            <a class=""page-link"" onclick=""nextPage()"" id=""btn_next"" aria-label=""Next"">");
            WriteLiteral(@"
                <span aria-hidden=""true"">&raquo;</span>
                <span class=""sr-only"">Next</span>
            </a>
        </li>
    </ul>

</div>

<script src=""https://code.jquery.com/jquery-1.12.4.js""></script>
<script src=""https://code.jquery.com/ui/1.12.1/jquery-ui.js""></script>

<script>
    var search = document.getElementById(""search"");
    var activeUsers = document.getElementById(""active-users"");
    var btn_next = document.getElementById(""btn_next"");
    var btn_prev = document.getElementById(""btn_prev"");
    var page_number = document.getElementById(""page"");
    const records_per_page = 5;
    let current_page = 1;
    let usersHTML = [];

    function searchUsers() {
        $.ajax({
            url: ""/HotelUser/SearchActiveUsers"",
            type: ""GET"",
            dataType: ""json"",
            async: true,
            data: {
                term: search.value
            },
            success: function (items) {
                usersHTML = [];

     ");
            WriteLiteral(@"           items.forEach(item => {
                    createUserCard(item);
                });

                changePage(current_page);
            },
            error: function (response) {
                debugger;
                alert('eror');
            }
        });
    }

    function createUserCard(item) {
        var card = document.createElement(""div"");
        var cardBody = document.createElement(""div"");
        var rowStart = document.createElement(""div"");
        var sizeInCols = document.createElement(""div"");
        var username = document.createElement(""h2"");
        var role = document.createElement(""p"");
        var fullName = document.createElement(""p"");
        var ucn = document.createElement(""p"");
        var phoneNumber = document.createElement(""p"");
        var email = document.createElement(""p"");
        var startDate = document.createElement(""p"");
        var footer = document.createElement(""div"");
        var whiteSpace = document.createElement(""span");
            WriteLiteral(@""");
        var editButton = document.createElement(""a"");
        var blockButton = document.createElement(""a"");

        card.className = ""card mb-4""
        cardBody.className = ""card-body"";
        rowStart.className = ""row"";
        sizeInCols.className = ""col-lg-6"";
        username.innerHTML = ""Username: "" + item.username;
        role.innerHTML = ""Role: "" + item.role;
        fullName.innerHTML = ""Full Name: "" + item.firstName + "" "" + item.secondName + "" "" + item.thirdName;
        ucn.innerHTML = ""UCN: "" + item.ucn;
        phoneNumber.innerHTML = ""Phone Number: "" + item.phoneNumber;
        email.innerHTML = ""Email: "" + item.email;
        startDate.innerHTML = ""Start Date: "" + new Date(item.startDate).toLocaleDateString();
        footer.className = ""card-footer text-muted"";
        whiteSpace.innerHTML = ""&nbsp;"";
        editButton.className = ""btn btn-primary"";
        editButton.href = ""/HotelUser/EditActiveUser/"" + item.id;
        editButton.innerHTML = ""Edit""
        block");
            WriteLiteral(@"Button.className = ""btn btn-primary"";
        blockButton.href = ""/HotelUser/Block/"" + item.id;
        blockButton.innerHTML = ""Block"";

        card.appendChild(cardBody);
        cardBody.appendChild(rowStart);
        rowStart.appendChild(sizeInCols);
        sizeInCols.appendChild(username);
        sizeInCols.appendChild(role);
        sizeInCols.appendChild(fullName);
        sizeInCols.appendChild(ucn);
        sizeInCols.appendChild(phoneNumber);
        sizeInCols.appendChild(email);
        sizeInCols.appendChild(startDate);
        card.appendChild(footer);
        footer.appendChild(editButton);

        if (item.role != ""Admin"") {
            footer.appendChild(whiteSpace);
            footer.appendChild(blockButton);
        }

        usersHTML.push(card);
    }

    function removeActiveUsers() {
        for (var i = activeUsers.children.length - 1; i >= 0; i--) {
            activeUsers.removeChild(activeUsers.children[i]);
        }
    }

    function prevPag");
            WriteLiteral(@"e() {
        if (current_page > 1) {
            current_page--;
            changePage(current_page);
        }
    }

    function nextPage() {
        if (current_page < numPages()) {
            current_page++;
            changePage(current_page);
        }
    }

    function changePage(page) {
        if (page < 1) {
            page = 1
        };

        if (page > numPages()) {
            page = numPages()
        };

        removeActiveUsers();

        for (var i = (page - 1) * records_per_page; i < (page * records_per_page); i++) {
            if (usersHTML.length - 1 >= i && i >= 0) {
                activeUsers.appendChild(usersHTML[i]);
            }
        }
        page_number.innerHTML = page;

        if (page == 1) {
            btn_prev.style.visibility = ""hidden"";
        } else {
            btn_prev.style.visibility = ""visible"";
        }

        if (page == numPages()) {
            btn_next.style.visibility = ""hidden"";
        } else {
");
            WriteLiteral(@"            btn_next.style.visibility = ""visible"";
        }
    }

    function numPages() {
        return Math.ceil(usersHTML.length / records_per_page);
    }

    window.onload = function () {
        searchUsers();
        changePage(1);
    };

    search.addEventListener(""input"", function () {
        removeActiveUsers();
        searchUsers();
    });
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
