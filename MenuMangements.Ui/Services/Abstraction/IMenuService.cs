using MenuMangement.API.Models;

namespace MenuMangements.Ui.Services.Abstraction
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetAllMenus();
        Task<Menu> GetMenuById(int id);
        
    }
}
