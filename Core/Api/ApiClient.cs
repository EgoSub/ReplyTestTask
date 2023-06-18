using Core.Api.Models;
using RestSharp;

namespace Core.ApiClient
{
    public class ApiClient
    {
        public LoginResponseModel Login(string? userName = "", string? password = "")
        {
            userName = userName == "" ? ConfigManager.Username : userName;
            password = password == "" ? ConfigManager.Password : password;
            var options = new RestClientOptions(ConfigManager.BaseUrl);
            var body = new LoginRequestModel("1920", "937", userName, password, "", "en_us", "Flex", "", "", "", "", "0", "1", "-60");
            var request = new RestRequest("/json.php", Method.Post);
            var client = new RestClient(options);
            request.AddBody(body);
            request.AddQueryParameter("action", "login");
            var loginResponse = client.Execute<LoginResponseModel>(request).ThrowIfError();
            return loginResponse.Data;
        }
    }
}
