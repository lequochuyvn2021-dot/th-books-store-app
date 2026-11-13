using Microsoft.AspNetCore.Mvc;
using THBookAPI.Models;

namespace THBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        private readonly ThbookDbContext _context;

        public DonHangController(ThbookDbContext context)
        {
            _context = context;
        }

        [HttpPost("dat-hang")]
        public IActionResult DatHang([FromBody] CheckoutDto dto)
        {
            // 1. Kiểm tra tài khoản khách hàng (QĐ2: nợ không quá 20.000 đ)
            var kh = _context.Taikhoans.Find(dto.MaKhachHang);
            if (kh != null && kh.SoTienNo > 20000)
            {
                return BadRequest(new { message = $"Tài khoản đang nợ {kh.SoTienNo:#,##0} đ, vượt quá mức 20.000 đ quy định (QĐ2). Không thể đặt hàng!" });
            }

            // 2. Kiểm tra tồn kho
            foreach (var item in dto.Items)
            {
                var book = _context.Saches.Find(item.MaSach);
                if (book == null || book.TonKho < item.SoLuong)
                {
                    return BadRequest(new { message = $"Sách '{book?.TenSach}' không đủ số lượng trong kho!" });
                }
                
                // Quy định QĐ2: Sau khi bán tồn kho phải giữ lại ít nhất 20 cuốn
                if (book.TonKho - item.SoLuong < 20)
                {
                    return BadRequest(new { message = $"Quy định QĐ2: Sách '{book.TenSach}' sau khi bán phải giữ lại tồn kho ít nhất 20 cuốn (Hiện tồn {book.TonKho})!" });
                }
            }

            // 3. Tiến hành trừ kho và lưu đơn hàng
            string newOrderId = "ORD-" + new Random().Next(10000, 99999);
            var dh = new Donhang
            {
                MaDonHang = newOrderId,
                MaKhachHang = dto.MaKhachHang,
                TenNguoiNhan = dto.HoTen,
                SoDienThoai = dto.DienThoai,
                DiaChiGiao = dto.DiaChi,
                TongTien = dto.TongTien,
                NgayDat = DateTime.Now,
                TrangThai = "Chờ xử lý"
            };
            _context.Donhangs.Add(dh);

            foreach (var item in dto.Items)
            {
                _context.Chitietdonhangs.Add(new Chitietdonhang
                {
                    MaDonHang = newOrderId,
                    MaSach = item.MaSach,
                    SoLuong = item.SoLuong,
                    DonGia = item.DonGia
                });

                var book = _context.Saches.Find(item.MaSach);
                book.TonKho -= item.SoLuong;
                book.DaBan = (book.DaBan ?? 0) + item.SoLuong;
            }

            _context.SaveChanges();

            return Ok(new { success = true, orderId = newOrderId, message = "Đặt hàng thành công và đã lưu vào cơ sở dữ liệu!" });
        }
    }

    public class CheckoutDto
    {
        public int MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public decimal TongTien { get; set; }
        public List<CartItemDto> Items { get; set; }
    }

    public class CartItemDto
    {
        public int MaSach { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }
}