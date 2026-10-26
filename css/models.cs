using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNhaSach.Models
{
    [Table("Sach")]
    public class Sach
    {
        [Key]
        public int MaSach { get; set; }
        [Required]
        public string TenSach { get; set; }
        [Required]
        public string TacGia { get; set; }
        public string MaTheLoai { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal GiaBan { get; set; }
        public int PhanTramGiam { get; set; }
        public int SoLuongTon { get; set; }
        public int SoLuongBan { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
    }

    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        public int MaTaiKhoan { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string MatKhauHash { get; set; }
        public string DienThoai { get; set; }
        public string VaiTro { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SoTienNo { get; set; }
    }
}