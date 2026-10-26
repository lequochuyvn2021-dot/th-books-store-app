using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLNhaSach.Data;
using QLNhaSach.Models;

[Route("api/[controller]")]
[ApiController]
public class DonHangController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly NghiepVuService _nghiepVuService;

    public DonHangController(ApplicationDbContext context, NghiepVuService nghiepVuService)
    {
        _context = context;
        _nghiepVuService = nghiepVuService;
    }

    [HttpPost("dat-hang")]
    public async Task<IActionResult> DatHang([FromBody] DatHangRequestDto dto)
    {
        // 1. Chuẩn bị dữ liệu kiểm tra QĐ2
        var chiTietKiemTra = dto.Items.Select(i => (i.MaSach, i.SoLuong)).ToList();
        var (isValid, message) = await _nghiepVuService.KiemTraQuyDinhBanHang(dto.MaKhachHang, chiTietKiemTra);

        if (!isValid)
        {
            return BadRequest(new { message });
        }

        // 2. Tạo mã hóa đơn mới tự động
        var count = await _context.HoaDons.CountAsync();
        string maSoHD = $"ORD-{count + 1:D5}";

        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var hoaDon = new HoaDon
            {
                MaSoHoaDon = maSoHD,
                MaKhachHang = dto.MaKhachHang,
                HoTenNguoiNhan = dto.HoTen,
                DienThoaiNguoiNhan = dto.DienThoai,
                DiaChiGiaoHang = dto.DiaChi,
                TongTien = dto.TongTien,
                TrangThai = "Chờ xử lý",
                NgayLap = DateTime.Now
            };

            _context.HoaDons.Add(hoaDon);
            await _context.SaveChangesAsync();

            // 3. Lưu chi tiết hóa đơn và trừ tồn kho sách
            foreach (var item in dto.Items)
            {
                var sach = await _context.Sachs.FindAsync(item.MaSach);
                sach.SoLuongTon -= item.SoLuong;
                sach.SoLuongBan += item.SoLuong;

                _context.ChiTietHoaDons.Add(new ChiTietHoaDon
                {
                    MaHoaDon = hoaDon.MaHoaDon,
                    MaSach = item.MaSach,
                    SoLuong = item.SoLuong,
                    DonGia = item.DonGia
                });
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok(new { success = true, message = "Đặt hàng thành công!", orderId = maSoHD });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return StatusCode(500, new { message = "Lỗi hệ thống khi đặt hàng: " + ex.Message });
        }
    }
}

// DTO lớp nhận dữ liệu từ Client
public class DatHangRequestDto
{
    public int MaKhachHang { get; set; }
    public string HoTen { get; set; }
    public string DienThoai { get; set; }
    public string DiaChi { get; set; }
    public decimal TongTien { get; set; }
    public List<ItemDto> Items { get; set; }
}

public class ItemDto
{
    public int MaSach { get; set; }
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
}