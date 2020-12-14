using System.Web;
using System.Web.Optimization;

namespace PMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/src/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerytemplate").Include(
                      "~/src/libs/jquery/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstraptemplate").Include(
                      "~/src/libs/bootstrap/js/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                      "~/src/libs/metismenu/metisMenu.min.js",
                      "~/src/libs/simplebar/simplebar.min.js",
                      "~/src/libs/node-waves/waves.min.js",
                      "~/src/js/app.js"));

            bundles.Add(new StyleBundle("~/Content/cssUser").Include(
                      "~/Content/bootstrap.css",
                      "~/src/user/css/app.min.css",
                      "~/src/user/css/icons.min.css"));
        }
    }
}
