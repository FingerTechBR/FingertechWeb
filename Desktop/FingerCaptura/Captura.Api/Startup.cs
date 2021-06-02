using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Web.Http;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Captura.Api.Startup))]

namespace Captura.Api
{
    public class Startup
    {
        //#region Utilizar quando Self-Hosting
        //public static void StartServer()
        //{
        //    string baseAddress = "http://192.168.17.2:71/";

        //    IDisposable webApplication = WebApp.Start(baseAddress);

        //    try
        //    {
        //        Console.WriteLine("Started...");

        //        Console.ReadKey();
        //    }
        //    finally
        //    {
        //        webApplication.Dispose();
        //    }
        //} 
        //#endregion

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}