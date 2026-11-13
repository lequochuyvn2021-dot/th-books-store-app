using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THBookAPI.Models;

namespace THBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SachController : ControllerBase
    {
        private readonly ThbookDbContext _context;

        public SachController(ThbookDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSachs()
        {
            var list = await _context.Saches
                .Include(s => s.MaTacGiaNavigation)
                .Select(s => new {
                    id = s.MaSach,
                    title = s.TenSach,
                    author = s.MaTacGiaNavigation != null ? s.MaTacGiaNavigation.TenTacGia : "Đang cập nhật",
                    category = s.MaTheLoai,
                    price = s.GiaBan,
                    stock = s.TonKho,
                    discount = s.GiamGia,
                    sold = s.DaBan,
                    image = s.HinhAnh,
                    desc = s.MoTa
                }).ToListAsync();

            return Ok(list);
        }
    }
}