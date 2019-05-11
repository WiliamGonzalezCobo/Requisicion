using System.Web;
using System.Web.Optimization;

namespace G_H_WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //retiros
            bundles.Add(new StyleBundle("~/Content/cssGH").Include(
        "~/assets/lib/bootstrap-4.1.3-dist/bootstrap.min.css",
        "~/assets/lib/fontawesome/font-awesome.min.css",
        "~/assets/lib/bootstrap-datepicker-1.6.4-dist/css/bootstrap-datepicker.min.css",
        "~/css/gestion-humana.css",
        "~/Scripts/dropzone/css/basic.css",
        "~/Scripts/dropzone/dropzone.css",
         "~/css/modal-retiros.css" ));

            bundles.Add(new ScriptBundle("~/bundles/scriptsGH").Include(
                        "~/assets/lib/jquery/jquery-3.3.1.min.js",
                        "~/assets/lib/popper/popper.min.js",
                        "~/assets/lib/bootstrap-4.1.3-dist/bootstrap.min.js",
                        "~/assets/lib/bootstrap-datepicker-1.6.4-dist/js/bootstrap-datepicker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/scriptsGHasset").Include(
                   "~/assets/js/scripts.js"));

            //plantilla microsoft 

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
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/scripts/dropzonescripts").Include(
                    "~/Scripts/dropzone/dropzone.min.js"));

        }
    }
}
