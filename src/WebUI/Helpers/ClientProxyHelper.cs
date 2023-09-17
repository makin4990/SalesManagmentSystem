using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebUI.Helpers
{
    public class ClientProxyHelper
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClientProxyHelper(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(_configuration["ApiBaseURL"]);
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            SetTokenToHeader();
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            return await response?.Content?.ReadFromJsonAsync<T>();
        }

        public async Task<T> PostAsync<T>(string endpoint, object data)
        {
            try
            {
                SetTokenToHeader();
                var response = await _httpClient.PostAsJsonAsync(endpoint, data);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private string GetTokenFromCookies()
        {
            var cookies = _httpContextAccessor.HttpContext.Request.Cookies;
            return cookies["SMS.Auth.Token.Cookies"];
        }
        private void SetTokenToHeader()
        {
            var token = GetTokenFromCookies();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        }
    }
}
