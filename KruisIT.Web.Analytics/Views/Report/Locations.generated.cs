﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Report/Locations.cshtml")]
    public partial class _Views_Report_Locations_cshtml : System.Web.Mvc.WebViewPage<KruisIT.Web.Analytics.Models.CurrentList<KruisIT.Web.Analytics.Models.Location>>
    {
        public _Views_Report_Locations_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Report\Locations.cshtml"
  
	Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"analytics-locations\"");

WriteLiteral(">\r\n\t<h4>Locations</h4>\r\n\r\n\t<ul>\r\n");

            
            #line 10 "..\..\Views\Report\Locations.cshtml"
		
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\Report\Locations.cshtml"
         foreach (var location in Model.Data)
		{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t<li>");

            
            #line 12 "..\..\Views\Report\Locations.cshtml"
           Write(Html.ActionLink(location.Url, "Index", new { website = location.Website, location = location.Url, visitor = Model.Filter.Visitor }, null));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n");

            
            #line 13 "..\..\Views\Report\Locations.cshtml"
		}

            
            #line default
            #line hidden
WriteLiteral("\t</ul>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
