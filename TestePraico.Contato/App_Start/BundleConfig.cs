using System.Web;
using System.Web.Optimization;

namespace TestePraico.Contato
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/plugins/jquery/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminLTE").Include(
                        "~/Scripts/adminLTE/js/adminlte.min.js",
                        "~/Scripts/plugins/moment/moment.min.js",
                        "~/Scripts/plugins/inputmask/inputmask.min.js",
                        "~/Scripts/plugins/select2/js/select2.full.min.js",
                        "~/Scripts/plugins/daterangepicker/daterangepicker.js",
                        "~/Scripts/adminLTE/js/adminlte.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/plugins/bootstrap/js/bootstrap.bundle.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/adminLTE/css/adminlte.css",
                      "~/Content/fontawesome-free/css/all.css",
                      "~/Content/adminLTE/css/adminlte.css",
                      "~/Content/adminLTE/select2/css/select2.min.css",
                      "~/Content/adminLTE/select2-bootstrap4-theme/select2-bootstrap4.min.css",
                      "~/Content/Site.css",
                      "~/Content/plugin/daterangepicker/daterangepicker.css"));
        }
    }
}
