using System.Web;
using System.Web.Optimization;

namespace MvcGLAtelelier2023
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));



            // Utilisez la version de développement de Modernizr pour développer et apprendre. Puis, lorsque vous êtes
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/asset/vendor/jquery/jquery.min.js",
                      "~/asset/vendor/bootstrap/js/bootstrap.bundle.min.js",
                      "~/asset/vendor/jquery-easing/jquery.easing.min.js",
                      "~/asset/js/sb-admin-2.min.js",
                      "~/asset/vendor/chart.js/Chart.min.js",
                      "~/asset/js/demo/chart-area-demo.js",
                      "~/asset/js/demo/chart-pie-demo.js"
                      ));


            bundles.Add(new StyleBundle("~/asset/css").Include(
                      "~/asset/vendor/fontawesome-free/css/all.min.css",
                      "~/asset/css/sb-admin-2.min.css"
                      ));
        }
    }
}
