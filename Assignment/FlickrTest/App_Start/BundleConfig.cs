using System.Web.Optimization;

namespace FlickrTest.App_Start
{
    /// <summary>
    /// Handles bundle configuration
    /// </summary>
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.lazyload.js",
                        "~/Scripts/jquery.imageloader.js"));

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                        "~/Scripts/script.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css","~/Content/bootstrap.css" ));

        }
    }
}