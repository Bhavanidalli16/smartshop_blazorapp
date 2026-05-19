using System.Net.Http.Json;
using SmartShop.Shared;

namespace SmartShop.Web.Services
{
    public class UserService
    {
        private readonly HttpClient _http =
            new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7191/")
            };

        // GET USERS
        public async Task<List<User>> GetUsers()
        {
            return await _http.GetFromJsonAsync<List<User>>(
                "api/users");
        }

        // REGISTER USER
        public async Task RegisterUser(User user)
        {
            await _http.PostAsJsonAsync(
                "api/users",
                user);
        }

        // LOGIN USER
        public async Task<User?> Login(User user)
        {
            var response =
                await _http.PostAsJsonAsync(
                    "api/users/login",
                    user);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<User>();
            }

            return null;
        }
    }
}