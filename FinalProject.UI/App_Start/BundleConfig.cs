﻿using System.Web.Optimization;

namespace FinalProject.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/bootstrap-datetimepicker.min.css",
                      "~/Content/css/flexslider.css",
                      "~/Content/css/templatemo-style.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/jquery-1.11.2.min.js",
                "~/Scripts/moment.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/bootstrap-datetimepicker.min.js",
                "~/Scripts/jquery.flexslider-min.js",
                "~/Scripts/templatemo-script.js"));
        }
    }
}
