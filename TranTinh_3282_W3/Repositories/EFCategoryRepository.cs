using Microsoft.EntityFrameworkCore;
using TranTinh_3282_W3.Models;

namespace TranTinh_3282_W3.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public EFCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy tất cả các danh mục (Categories)
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories
                .ToListAsync(); // Trả về tất cả các Category trong cơ sở dữ liệu
        }

        // Lấy thông tin một danh mục theo ID
        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id); // Lấy Category theo ID
        }

        // Thêm mới một danh mục vào cơ sở dữ liệu
        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category); // Thêm Category vào DbSet
            await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
        }

        // Cập nhật thông tin một danh mục
        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category); // Cập nhật thông tin Category
            await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
        }

        // Xóa một danh mục theo ID
        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id); // Tìm Category theo ID
            if (category != null)
            {
                _context.Categories.Remove(category); // Xóa Category
                await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }
    }

}
