using System.Collections.Generic;
using System.Web.Optimization;

namespace HomeworkBuddy.Web
{
    class NonOrderingBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }

    public class BundleConfig
    {


        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.js"));

            //.Include("~/Scripts/methods_pt.js")
            var bundleValidate = new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.unobtrusive-ajax.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/globalize.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js")
                .Include("~/Scripts/jquery.validate.globalize.js")                
                .Include("~/Scripts/jquery.validate.pt-br.js");
            
            bundleValidate.Orderer = new NonOrderingBundleOrderer();

            bundles.Add(bundleValidate);

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap.js", 
                        "~/Scripts/Pagamento.js",
                        "~/Scripts/Site.js"));
                
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-datetimepicker.min.css",
                      "~/Content/DataTables/css/jquery.dataTables.css",
                      "~/Content/DataTables/css/dataTables.jqueryui.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/bootstrap-datepicker3.css"));
            
           bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                "~/Scripts/jquery.inputmask/inputmask.js",
                "~/Scripts/jquery.inputmask/jquery.inputmask.js",
                "~/Scripts/jquery.inputmask/inputmask.extensions.js",
                "~/Scripts/jquery.inputmask/inputmask.date.extensions.js",
                "~/Scripts/jquery.inputmask/inputmask.numeric.extensions.js",
                "~/Scripts/priceformater/jquery.priceformat.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap-datepicker.js",
                "~/Scripts/locales/bootstrap-datepicker.pt-BR.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js"));
        }
    }
}
