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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Report/Aggregates.cshtml")]
    public partial class _Views_Report_Aggregates_cshtml : System.Web.Mvc.WebViewPage<KruisIT.Web.Analytics.Models.CurrentList<KruisIT.Web.Analytics.Models.Aggregate>>
    {
        public _Views_Report_Aggregates_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Report\Aggregates.cshtml"
  
	Layout = null;

	int maxCount = Model.Data.Any() ? Model.Data.Max(m => m.Count) : 0;
	int dayCount = Model.Data.Count;

	int aggregateTotal = Model.Data.Select(m => m.Count).Sum();

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h4>");

            
            #line 11 "..\..\Views\Report\Aggregates.cshtml"
Write(aggregateTotal);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 11 "..\..\Views\Report\Aggregates.cshtml"
               Write(Model.Title);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n<div");

WriteLiteral(" class=\"analytics-aggregates analytics-aggregates-rotated\"");

WriteLiteral(">\r\n\r\n\t<span");

WriteLiteral(" class=\"analytics-aggregates-y-label\"");

WriteLiteral(" id=\"analytics-aggregates-y-label-left\"");

WriteLiteral(">");

            
            #line 14 "..\..\Views\Report\Aggregates.cshtml"
                                                                                 Write(maxCount);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n\t<span");

WriteLiteral(" class=\"analytics-aggregates-y-label\"");

WriteLiteral(" id=\"analytics-aggregates-y-label-right\"");

WriteLiteral(">");

            
            #line 15 "..\..\Views\Report\Aggregates.cshtml"
                                                                                   Write(Model.Data.Any() ? Model.Data.Last().Count : 0);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n\r\n\t<table>\r\n\t\t<thead>\r\n\t\t\t<tr>\r\n\t\t\t\t<th>");

            
            #line 20 "..\..\Views\Report\Aggregates.cshtml"
               Write(Html.DisplayNameFor(model => model.Data.FirstOrDefault().Date));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n\t\t\t\t<th>");

            
            #line 21 "..\..\Views\Report\Aggregates.cshtml"
               Write(Html.DisplayNameFor(model => model.Data.FirstOrDefault().Count));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n\t\t\t</tr>\r\n\t\t</thead>\r\n\t\t<tbody>\r\n");

            
            #line 25 "..\..\Views\Report\Aggregates.cshtml"
			
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Report\Aggregates.cshtml"
             for (int dayIndex = 0; dayIndex < Model.Data.Count; dayIndex++)
			{
				var agg = Model.Data[dayIndex];
				var width = (0 == maxCount) ? 0 : (100 * agg.Count / maxCount);

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t<tr>\r\n\t\t\t\t\t<td");

WriteLiteral(" class=\"analytics-date\"");

WriteLiteral(">\r\n");

            
            #line 31 "..\..\Views\Report\Aggregates.cshtml"
						
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Report\Aggregates.cshtml"
                         if (0 == dayIndex || (dayIndex == (dayCount / 4)) || (dayIndex == (dayCount / 2)) || (dayIndex == (dayCount * 3 / 4)) || dayCount - 1 == dayIndex)
						{ 

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t<div>");

            
            #line 33 "..\..\Views\Report\Aggregates.cshtml"
                            Write(agg.Date.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 34 "..\..\Views\Report\Aggregates.cshtml"
						}
						else
						{

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t\t\t<div");

WriteLiteral(" class=\"analytics-date-secondary\"");

WriteLiteral(">");

            
            #line 37 "..\..\Views\Report\Aggregates.cshtml"
                                                             Write(agg.Date.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 38 "..\..\Views\Report\Aggregates.cshtml"
						}

            
            #line default
            #line hidden
WriteLiteral("\t\t\t\t\t</td>\r\n\t\t\t\t\t<td");

WriteAttribute("class", Tuple.Create(" class=\"", 1443), Tuple.Create("\"", 1515)
, Tuple.Create(Tuple.Create("", 1451), Tuple.Create("analytics-count", 1451), true)
            
            #line 40 "..\..\Views\Report\Aggregates.cshtml"
, Tuple.Create(Tuple.Create(" ", 1466), Tuple.Create<System.Object, System.Int32>(agg.Count == 0 ? "analytics-count-empty" : ""
            
            #line default
            #line hidden
, 1467), false)
);

WriteLiteral("><div");

WriteAttribute("style", Tuple.Create(" style=\"", 1521), Tuple.Create("\"", 1545)
, Tuple.Create(Tuple.Create("", 1529), Tuple.Create("width:", 1529), true)
            
            #line 40 "..\..\Views\Report\Aggregates.cshtml"
                                    , Tuple.Create(Tuple.Create(" ", 1535), Tuple.Create<System.Object, System.Int32>(width
            
            #line default
            #line hidden
, 1536), false)
, Tuple.Create(Tuple.Create("", 1544), Tuple.Create("%", 1544), true)
);

WriteAttribute("title", Tuple.Create(" title=\"", 1546), Tuple.Create("\"", 1599)
            
            #line 40 "..\..\Views\Report\Aggregates.cshtml"
                                                      , Tuple.Create(Tuple.Create("", 1554), Tuple.Create<System.Object, System.Int32>(agg.Date.ToString("yyyy-MM-dd")
            
            #line default
            #line hidden
, 1554), false)
, Tuple.Create(Tuple.Create(" ", 1586), Tuple.Create(":", 1587), true)
            
            #line 40 "..\..\Views\Report\Aggregates.cshtml"
                                                                                        , Tuple.Create(Tuple.Create(" ", 1588), Tuple.Create<System.Object, System.Int32>(agg.Count
            
            #line default
            #line hidden
, 1589), false)
);

WriteLiteral("><span>");

            
            #line 40 "..\..\Views\Report\Aggregates.cshtml"
                                                                                                                                                                                      Write(agg.Count);

            
            #line default
            #line hidden
WriteLiteral("</span></div></td>\r\n\t\t\t\t</tr>\r\n");

            
            #line 42 "..\..\Views\Report\Aggregates.cshtml"
			}

            
            #line default
            #line hidden
WriteLiteral("\t\t</tbody>\r\n\t</table>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
