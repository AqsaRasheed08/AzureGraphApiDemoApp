namespace AzureGraphApiDemoApp.Controllers
{
    internal class clientSecretCrediential
    {
        private string tenantId;
        private string clientId;
        private string clientSecret;

        public clientSecretCrediential(string tenantId, string clientId, string clientSecret)
        {
            this.tenantId = tenantId;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }
    }
}