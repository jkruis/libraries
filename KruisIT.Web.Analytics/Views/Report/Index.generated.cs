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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Report/Index.cshtml")]
    public partial class _Views_Report_Index_cshtml : System.Web.Mvc.WebViewPage<KruisIT.Web.Analytics.Models.CurrentList<string>>
    {
        public _Views_Report_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Report\Index.cshtml"
  
	ViewBag.Title = "Analytics";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<link");

WriteLiteral(" rel=\"stylesheet\"");

WriteAttribute("href", Tuple.Create(" href=\"", 119), Tuple.Create("\"", 162)
            
            #line 6 "..\..\Views\Report\Index.cshtml"
, Tuple.Create(Tuple.Create("", 126), Tuple.Create<System.Object, System.Int32>(ViewBag.Url
            
            #line default
            #line hidden
, 126), false)
, Tuple.Create(Tuple.Create("", 140), Tuple.Create("Resource/analytics_css", 140), true)
);

WriteLiteral(" />\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 198), Tuple.Create("\"", 239)
            
            #line 7 "..\..\Views\Report\Index.cshtml"
, Tuple.Create(Tuple.Create("", 204), Tuple.Create<System.Object, System.Int32>(ViewBag.Url
            
            #line default
            #line hidden
, 204), false)
, Tuple.Create(Tuple.Create("", 218), Tuple.Create("Resource/analytics_js", 218), true)
);

WriteLiteral("></script>\r\n\r\n<h2>\r\n");

WriteLiteral("\t");

            
            #line 10 "..\..\Views\Report\Index.cshtml"
Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("\r\n\t");

WriteLiteral("\r\n</h2>\r\n\r\n<div");

WriteLiteral(" class=\"analytics-menu\"");

WriteLiteral(">\r\n");

            
            #line 17 "..\..\Views\Report\Index.cshtml"
	
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Report\Index.cshtml"
     if (Model.Data.Any())
	{

            
            #line default
            #line hidden
WriteLiteral("\t\t<div");

WriteLiteral(" id=\"analytics-filter-website\"");

WriteLiteral(">\r\n");

            
            #line 20 "..\..\Views\Report\Index.cshtml"
			
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Report\Index.cshtml"
             if (Model.Data.Count > 1)
			{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<h3>website</h3>\r\n");

WriteLiteral("\t\t\t\t<select");

WriteLiteral(" id=\"analytics-filter-website-value\"");

WriteLiteral(">\r\n");

            
            #line 24 "..\..\Views\Report\Index.cshtml"
					
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Report\Index.cshtml"
                     foreach (var site in Model.Data)
					{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t<option>");

            
            #line 26 "..\..\Views\Report\Index.cshtml"
                           Write(site);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 27 "..\..\Views\Report\Index.cshtml"
					}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t</select>\r\n");

            
            #line 29 "..\..\Views\Report\Index.cshtml"
			}
			else
			{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<span");

WriteLiteral(" id=\"analytics-filter-website-value\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">");

            
            #line 32 "..\..\Views\Report\Index.cshtml"
                                                                            Write(Model.Data.First());

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n");

            
            #line 33 "..\..\Views\Report\Index.cshtml"
			}

            
            #line default
            #line hidden
WriteLiteral("\t\t</div>\r\n");

            
            #line 35 "..\..\Views\Report\Index.cshtml"
	}
	else
	{

            
            #line default
            #line hidden
WriteLiteral("\t\t<div>No Data</div>\r\n");

            
            #line 39 "..\..\Views\Report\Index.cshtml"
	}

            
            #line default
            #line hidden
WriteLiteral("\r\n\t<div");

WriteLiteral(" id=\"analytics-filter-location\"");

WriteLiteral(">\r\n\t\t<h3>location</h3>\r\n\t\t<input");

WriteLiteral(" id=\"analytics-filter-location-value\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" />\r\n\t\t<button");

WriteLiteral(" class=\"clear\"");

WriteLiteral(">x</button>\r\n\t</div>\r\n\r\n\t<div");

WriteLiteral(" id=\"analytics-filter-view\"");

WriteLiteral(">\r\n\t\t<h3>view</h3>\r\n\t\t<ul");

WriteLiteral(" id=\"analytics-filter-view-value\"");

WriteLiteral(">\r\n\t\t\t<li><input");

WriteLiteral(" type=\"radio\"");

WriteLiteral(" name=\"view\"");

WriteLiteral(" id=\"vwVisits\"");

WriteLiteral(" value=\"Aggregates_Visits\"");

WriteLiteral(" checked=\"checked\"");

WriteLiteral(" /><label");

WriteLiteral(" for=\"vwVisits\"");

WriteLiteral(">Page views</label></li>\r\n\t\t\t<li><input");

WriteLiteral(" type=\"radio\"");

WriteLiteral(" name=\"view\"");

WriteLiteral(" id=\"vwVisitors\"");

WriteLiteral(" value=\"Aggregates_Visitors\"");

WriteLiteral(" /><label");

WriteLiteral(" for=\"vwVisitors\"");

WriteLiteral(">Visitors</label></li>\r\n\t\t\t<li><input");

WriteLiteral(" type=\"radio\"");

WriteLiteral(" name=\"view\"");

WriteLiteral(" id=\"vwMostViewed\"");

WriteLiteral(" value=\"MostViewed\"");

WriteLiteral(" /><label");

WriteLiteral(" for=\"vwMostViewed\"");

WriteLiteral(">Most viewed</label></li>\r\n\t\t</ul>\r\n\t</div>\r\n\r\n\t<div");

WriteLiteral(" id=\"analytics-filter-dates\"");

WriteLiteral(">\r\n\t\t<h3>date</h3>\r\n\t\tfrom\r\n\t\t<input");

WriteLiteral(" id=\"analytics-filter-date-start\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" placeholder=\"yyyy-MM-dd\"");

WriteLiteral(" data-value=\"");

            
            #line 59 "..\..\Views\Report\Index.cshtml"
                                                                                             Write(Model.Filter.StartDate.HasValue ? Model.Filter.StartDate.Value.ToString("yyyy-MM-dd") : "");

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1850), Tuple.Create("\"", 1951)
            
            #line 59 "..\..\Views\Report\Index.cshtml"
                                                                                                                        , Tuple.Create(Tuple.Create("", 1858), Tuple.Create<System.Object, System.Int32>(Model.Filter.StartDate.HasValue ? Model.Filter.StartDate.Value.ToString("yyyy-MM-dd") : ""
            
            #line default
            #line hidden
, 1858), false)
);

WriteLiteral(" />\r\n\t\tto\r\n\t\t<input");

WriteLiteral(" id=\"analytics-filter-date-end\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" placeholder=\"yyyy-MM-dd\"");

WriteLiteral(" data-value=\"");

            
            #line 61 "..\..\Views\Report\Index.cshtml"
                                                                                           Write(Model.Filter.EndDate.HasValue ? Model.Filter.EndDate.Value.ToString("yyyy-MM-dd") : "");

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2142), Tuple.Create("\"", 2239)
            
            #line 61 "..\..\Views\Report\Index.cshtml"
                                                                                                                  , Tuple.Create(Tuple.Create("", 2150), Tuple.Create<System.Object, System.Int32>(Model.Filter.EndDate.HasValue ? Model.Filter.EndDate.Value.ToString("yyyy-MM-dd") : ""
            
            #line default
            #line hidden
, 2150), false)
);

WriteLiteral(" />\r\n\t</div>\r\n\r\n\t<div");

WriteLiteral(" id=\"analytics-base-url\"");

WriteLiteral(">");

            
            #line 64 "..\..\Views\Report\Index.cshtml"
                             Write(ViewBag.Url);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\t<div");

WriteLiteral(" id=\"analytics-refresh\"");

WriteLiteral(">&#8635;</div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" id=\"analytics-message\"");

WriteLiteral("></div>\r\n\r\n<div");

WriteLiteral(" class=\"analytics-block\"");

WriteLiteral(">\r\n\t<div");

WriteLiteral(" id=\"analytics-data\"");

WriteLiteral("></div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
