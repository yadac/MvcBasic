using System.Web.Optimization;

namespace MvcBasic
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // change from CDN (Contents Delivery Network)
            bundles.UseCdn = true;
            var jq = new ScriptBundle("~/bundles/jquery", "//code.jquery.com/ui/1.12.1/jquery-ui.min.js")
                .Include("~/Scripts/jquery-{version}.js");
            jq.CdnFallbackExpression = "window.jQuery";
            bundles.Add(jq);


            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/blackword.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));
            //bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
            //            "~/Content/themes/base/jquery-ui.min.css"));
            // テーマ変更(Theme -> Contentに移動)
            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                        "~/Content/themes/redmond/jquery-ui-1.10.3.custom.min.css"));

            // bundle & minification disabled
            BundleTable.EnableOptimizations = true;

        }
    }
}
