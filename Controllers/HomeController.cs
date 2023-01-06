using System.Diagnostics;
using AzureGraphApiDemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;

namespace AzureGraphApiDemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _Confuration;

        public HomeController(ILogger<HomeController> logger, 
            IConfiguration confuration)
        {
            _logger = logger;
            _Confuration = confuration;
        }

        public IActionResult Index()
        {
            var clientId = _Confuration.GetValue<string>("AzureAd:clientId");
            var tenantId = _Confuration.GetValue<string>("AzureAd:TenantId");
            var ClientSecret = _Confuration.GetValue<string>("AzureAd:ClientSecret");
            var clientSecretCredential = new clientSecretCrediential(tenantId, clientId, ClientSecret);
            GraphServiceClient graphServiceClient = new GraphServiceClient((IAuthenticationProvider)clientSecretCredential);

            var users = graphServiceClient.Users.Request()
                .Select(x => x.DisplayName).GetAsync().Result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}