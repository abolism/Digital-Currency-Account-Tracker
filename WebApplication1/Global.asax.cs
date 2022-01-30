using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication1.Models;

namespace WebApplication1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SetRecords();
        }

        private void SetRecords()
        {
            
            if (Records.allWallets == null)
            {
                var str = File.ReadAllText(@"D:\WebApi\WebApplication1\jsonData.json");
                if (str == "")
                {
                    string jsonSerialWalletsList = "[]";
                    var fileMode = FileMode.Append;
                    string fileName = $@"D:\WebApi\WebApplication1\jsonData.json";
                    FileStream fs = new FileStream(fileName, fileMode);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(jsonSerialWalletsList);
                    sw.Close();
                    fs.Close();
                }
                str = File.ReadAllText(@"D:\WebApi\WebApplication1\jsonData.json");
                dynamic dynJson = JsonConvert.DeserializeObject(str);
                foreach (var item in dynJson)
                {
                    Console.WriteLine(item);
                }
                Records.allWallets = System.Text.Json.JsonSerializer.Deserialize<List<Wallets>>(str);
                //JsonSerializer.Deserialize<List<Wallets>>(JsonSerializer.Deserialize<List<Json>>(str));
                
            }
        }
    }
}
