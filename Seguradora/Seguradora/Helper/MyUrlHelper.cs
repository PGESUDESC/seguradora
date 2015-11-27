using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{

    public static class MyUrlHelpers
    {
        public static string Image(this UrlHelper helper, string fileName)
        {
            return helper.Content(string.Format("~/Images/{0}", fileName));
        }
    }
}