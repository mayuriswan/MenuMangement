using MenuMangement.API.Models;
using MenuMangements.Ui.Services.Abstraction;

namespace MenuMangements.Ui.Services.Implementation
{
    public class MenuService : IMenuService
    {
        private readonly HttpClient _httpClient;

        public MenuService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Menu>> GetAllMenus()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Menu>>("api/menus");
        }

        public async Task<Menu> GetMenuById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Menu>($"api/menus/{id}");
        }

    }
}
