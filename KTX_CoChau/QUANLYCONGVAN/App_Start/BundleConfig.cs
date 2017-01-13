using System.Web;
using System.Web.Optimization;

namespace QUANLYCONGVAN
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/Assets").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Assets/Bootstrap/js/bootstrap.min.js",
                        "~/Assets/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                        "~/Assets/jquery-slimscroll/jquery.slimscroll.min.js",
                        "~/Assets/Js/moment.min.js",
                        "~/Assets/fullcalendar/fullcalendar.min.js",
                        "~/Assets/jquery-ui/jquery-ui.min.js",
                        "~/Assets/Js/datatable.js",
                        "~/Assets/datatables/datatables.min.js",
                        "~/Assets/datatables/plugins/bootstrap/datatables.bootstrap.js",
                        "~/Assets/Js/app.min.js",
                        "~/Assets/Js/calendar.min.js",
                        "~/Assets/datepicker/js/bootstrap-datepicker.min.js",
                   
                        "~/Assets/Js/layout.min.js",
                        "~/Assets/Js/demo.min.js",
                        "~/Assets/Js/quick-sidebar.min.js",
                        "~/Scripts/ownJS.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Assets/css").Include(
              //http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all
              //              "http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all",
              "~/Assets/Font-awesome/css/font-awesome.min.css",
                    "~/Assets/Simple-icon/simple-line-icons.min.css",
                    "~/Assets/Bootstrap/css/bootstrap.min.css",
                    "~/Assets/uniform/css/uniform.default.css",
                    "~/Assets/bootstrap-switch/css/bootstrap-switch.min.css",
                    "~/Assets/datatables/datatables.min.css",
                    "~/Assets/datatables/plugins/bootstrap/datatables.bootstrap.css",
                    "~/Assets/fullcalendar/fullcalendar.min.css",
                    "~/Assets/Css/components.min.css",
                    "~/Assets/Css/plugins.min.css",
                    "~/Assets/Css/layout.min.css",
                    "~/Assets/Css/darkblue.min.css",
                    "~/Assets/Css/custom.min.css",
                    "~/Assets/datepicker/css/bootstrap-datepicker.min.css",
                    "~/Assets/datepicker/css/bootstrap-datepicker3.min.css",

                    "~/Assets/Css/style.css"));


        }
    }

}
public class sss
{
    void recycle()
    {

        //"~/Assets/Bootstrap/js/bootstrap.min.js",
        //"~/Assets/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
        //"~/Assets/jquery-slimscroll/jquery.slimscroll.min.js",
        //"~/Assets/Js/moment.min.js",
        //"~/Assets/fullcalendar/fullcalendar.min.js",
        //"~/Assets/jquery-ui/jquery-ui.min.js",
        //"~/Assets/Js/datatable.js",
        //"~/Assets/datatables/datatables.min.js",
        //"~/Assets/datatables/plugins/bootstrap/datatables.bootstrap.js",
        //"~/Assets/Js/app.min.js",
        //"~/Assets/Js/calendar.min.js",
        //"~/Assets/datepicker/js/bootstrap-datepicker.min.js",
        //"~/Assets/Js/layout.min.js",
        //"~/Assets/Js/demo.min.js",
        //"~/Assets/Js/quick-sidebar.min.js",
    }
}