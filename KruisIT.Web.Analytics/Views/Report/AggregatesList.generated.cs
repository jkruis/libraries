﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Report/AggregatesList.cshtml")]
    public partial class _Views_Report_AggregatesList_cshtml : System.Web.Mvc.WebViewPage<KruisIT.Web.Analytics.Models.CurrentList<KruisIT.Web.Analytics.Models.Aggregate>>
    {
        public _Views_Report_AggregatesList_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Report\AggregatesList.cshtml"
  
	Layout = null;

	int aggregateTotal = Model.Data.Select(m => m.Count).Sum();

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h4>");

            
            #line 8 "..\..\Views\Report\AggregatesList.cshtml"
Write(Model.Title);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n<div");

WriteLiteral(" class=\"analytics-aggregates\"");

WriteLiteral(">\r\n\r\n\t<table");

WriteLiteral(" class=\"analytics-data\"");

WriteLiteral(">\r\n\t\t<thead>\r\n\t\t\t<tr>\r\n\t\t\t\t<th>");

            
            #line 14 "..\..\Views\Report\AggregatesList.cshtml"
               Write(Html.DisplayNameFor(model => model.Data.FirstOrDefault().Count));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n\t\t\t\t<th>");

            
            #line 15 "..\..\Views\Report\AggregatesList.cshtml"
               Write(Html.DisplayNameFor(model => model.Data.FirstOrDefault().Location));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n\t\t\t</tr>\r\n\t\t</thead>\r\n\t\t<tbody>\r\n");

            
            #line 19 "..\..\Views\Report\AggregatesList.cshtml"
			
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\Report\AggregatesList.cshtml"
             foreach (var item in Model.Data)
			{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<tr>\r\n\t\t\t\t\t<td>");

            
            #line 22 "..\..\Views\Report\AggregatesList.cshtml"
                   Write(item.Count);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n\t\t\t\t\t<td");

WriteLiteral(" class=\"analytics-select-location\"");

WriteLiteral(">");

            
            #line 23 "..\..\Views\Report\AggregatesList.cshtml"
                                                     Write(Html.ActionLink(item.Location, "", new { location = item.Location }));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n\t\t\t\t</tr>\r\n");

            
            #line 25 "..\..\Views\Report\AggregatesList.cshtml"
			}

            
            #line default
            #line hidden
WriteLiteral("\t\t</tbody>\r\n\t</table>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
