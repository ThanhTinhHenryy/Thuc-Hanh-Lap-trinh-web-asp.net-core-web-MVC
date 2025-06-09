using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TranThanhTinh_2280603282.Models;
using TranThanhTinh_2280603282.Repositories;

//namespace TranThanhTinh_2280603282.Controllers
//{
//    public class ProductController : Controller
//    {
//        private readonly IProductRepository _productRepository;
//        private readonly ICategoryRepository _categoryRepository;
//        public ProductController(IProductRepository productRepository,
//        ICategoryRepository categoryRepository)
//        {
//            _productRepository = productRepository;
//            _categoryRepository = categoryRepository;
//        }

//        //public IActionResult Index()
//        //{
//        //    var products = _productRepository.GetAll();
//        //    return View(products);
//        //}

//        public IActionResult Add()
//        {
//            var categories = _categoryRepository.GetAllCategories();
//            ViewBag.Categories = new SelectList(categories, "Id", "Name");
//            return View();
//        }
//        [HttpPost]
//        public IActionResult Add(Product product)
//        {
//            if (ModelState.IsValid)
//            {
//                _productRepository.Add(product);
//                return RedirectToAction("Index"); // Chuyển hướng tới trang danh sách sản phẩm
//            }
//            return View(product);
//        }

//        // Các actions khác như Display, Update, Delete
//        // Display a list of products
//        public IActionResult Index()
//        {
//            var products = _productRepository.GetAll();
//            return View(products);
//        }
//        // Display a single product
//        public IActionResult Display(int id)
//        {
//            var product = _productRepository.GetById(id);
//            if (product == null)
//            {
//                return NotFound();
//            }
//            return View(product);
//        }
//        // Show the product update form
//        public IActionResult Update(int id)
//        {
//            var product = _productRepository.GetById(id);
//            if (product == null)
//            {
//                return NotFound();
//            }
//            return View(product);
//        }
//        // Process the product update
//        [HttpPost]
//        public IActionResult Update(Product product)
//        {
//            if (ModelState.IsValid)
//            {
//                _productRepository.Update(product);
//                return RedirectToAction("Index");
//            }
//            return View(product);
//        }
//        // Show the product delete confirmation
//        public IActionResult Delete(int id)
//        {
//            var product = _productRepository.GetById(id);
//            if (product == null)
//            {
//                return NotFound();
//            }
//            return View(product);
//        }

//        // Process the product deletion
//        [HttpPost, ActionName("DeleteConfirmed")]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            _productRepository.Delete(id);
//            return RedirectToAction("Index");
//        }
//        //[HttpPost]
//        //public async Task<IActionResult> Add(Product product, IFormFile imageUrl, List<IFormFile> imageUrls)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        if (imageUrl != null)
//        //        {
//        //            // Lưu hình ảnh đại diện
//        //            product.ImageUrl = await SaveImage(imageUrl);
//        //        }
//        //        if (imageUrls != null)
//        //        {
//        //            product.ImageUrls = new List<string>();
//        //            foreach (var file in imageUrls)
//        //            {
//        //                // Lưu các hình ảnh khác
//        //                product.ImageUrls.Add(await SaveImage(file));
//        //            }
//        //        }
//        //        _productRepository.Add(product);
//        //        return RedirectToAction("Index");
//        //    }
//        //    return View(product);
//        //}
//        [HttpPost]
//        public async Task<IActionResult> Add(Product product, IFormFile imageUrl, List<IFormFile> imageUrls)
//        {
//            if (ModelState.IsValid)
//            {
//                if (imageUrl != null)
//                {
//                    // Lưu hình ảnh đại diện
//                    product.ImageUrl = await SaveImage(imageUrl);
//                }
//                if (imageUrls != null && imageUrls.Count > 0)
//                {
//                    product.ImageUrls = new List<string>();
//                    foreach (var file in imageUrls)
//                    {
//                        // Lưu các hình ảnh khác
//                        product.ImageUrls.Add(await SaveImage(file));
//                    }
//                }
//                _productRepository.Add(product);
//                return RedirectToAction("Index");
//            }
//            return View(product);
//        }

//        //private async Task<string> SaveImage(IFormFile image)
//        //{
//        //    // Thay đổi đường dẫn theo cấu hình của bạn
//        //    var savePath = Path.Combine("wwwroot/images", image.FileName);
//        //    using (var fileStream = new FileStream(savePath, FileMode.Create))
//        //    {
//        //        await image.CopyToAsync(fileStream);
//        //    }
//        //    return "/images/" + image.FileName; // Trả về đường dẫn tương đối
//        //}
//        private async Task<string> SaveImage(IFormFile image)
//        {
//            // Tạo tên file duy nhất dựa vào GUID
//            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
//            var savePath = Path.Combine("wwwroot/images", fileName);

//            // Kiểm tra xem thư mục có tồn tại hay không, nếu chưa thì tạo nó
//            var directory = Path.GetDirectoryName(savePath);
//            if (!Directory.Exists(directory))
//            {
//                Directory.CreateDirectory(directory);
//            }

//            using (var fileStream = new FileStream(savePath, FileMode.Create))
//            {
//                await image.CopyToAsync(fileStream);
//            }

//            return "/images/" + fileName; // Trả về đường dẫn tương đối
//        }

//    }
//}

namespace TranThanhTinh_2280603282.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // Display list of products
        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        // Show form to add new product
        public IActionResult Add()
        {
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        // Handle post request to add a new product
        [HttpPost]
        public async Task<IActionResult> Add(Product product, IFormFile imageUrl, List<IFormFile> imageUrls)
        {
            if (ModelState.IsValid)
            {
                // Process the main image
                if (imageUrl != null)
                {
                    product.ImageUrl = await SaveImage(imageUrl);
                }

                // Process additional images if any
                if (imageUrls != null && imageUrls.Count > 0)
                {
                    product.ImageUrls = new List<string>();
                    foreach (var file in imageUrls)
                    {
                        product.ImageUrls.Add(await SaveImage(file));
                    }
                }

                // Add product to repository
                _productRepository.Add(product);
                return RedirectToAction("Index");
            }
            // If model state is not valid, return back to form
            return View(product);
        }

        // Show details of a single product
        public IActionResult Display(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Show the product update form
        public IActionResult Update(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Handle the product update
        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Show product delete confirmation
        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Process the product deletion
        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction("Index");
        }

        // Helper method to save image to disk and return the relative URL
        private async Task<string> SaveImage(IFormFile image)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName); // Unique file name using GUID
            var savePath = Path.Combine("wwwroot/images", fileName); // Path to save the image

            // Ensure the directory exists
            var directory = Path.GetDirectoryName(savePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Save the image
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return "/images/" + fileName; // Return relative path to the image
        }
    }
}
