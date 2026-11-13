using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THBookAPI.Models
{
    [Table("donhang")]
    public class Donhang
    {
        [Key, Column("ma_don_hang")]
        public string MaDonHang { get; set; }
        [Column("ma_khach_hang")]
        public int? MaKhachHang { get; set; }
        [Column("ten_nguoi_nhan")]
        public string TenNguoiNhan { get; set; }
        [Column("so_dien_thoai")]
        public string SoDienThoai { get; set; }
        [Column("dia_chi_giao")]
        public string DiaChiGiao { get; set; }
        [Column("tong_tien")]
        public decimal TongTien { get; set; }
        [Column("ngay_dat")]
        public DateTime? NgayDat { get; set; }
        [Column("trang_thai")]
        public string TrangThai { get; set; }

        [ForeignKey("MaKhachHang")]
        public virtual Taikhoan MaKhachHangNavigation { get; set; }
    }
}