using System.ComponentModel.DataAnnotations;

namespace TranThanhTinh_2280603282.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
