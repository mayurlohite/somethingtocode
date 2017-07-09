using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SomethingToCode.Web.App_Start
{
    public class CustomSCViewEngine : RazorViewEngine
    {
        private static readonly string[] NewPartialViewFormats =
        {
            "~/Views/{1}/Partials/{0}.cshtml",
            "~/Views/Shared/Partials/{0}.cshtml",
            "~/Views/{1}/Widgets/{0}.cshtml",
            "~/Views/Shared/Widgets/{0}.cshtml",
        };

        public CustomSCViewEngine()
        {
            base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(NewPartialViewFormats).ToArray();
        }
    }
}