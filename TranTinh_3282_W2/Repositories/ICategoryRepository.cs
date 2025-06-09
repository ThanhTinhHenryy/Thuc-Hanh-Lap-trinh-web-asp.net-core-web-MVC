using TranThanhTinh_2280603282.Models;

namespace TranThanhTinh_2280603282.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}
