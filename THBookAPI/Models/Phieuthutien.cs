using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THBookAPI.Models
{
    [Table("phieuthutien")]
    public class Phieuthutien
    {
        [Key, Column("ma_phieu_thu")]
        public string MaPhieuThu { get; set; }
        [Column("ma_khach_hang")]
        public int? MaKhachHang { get; set; }
        [Column("dia_chi")]
        public string DiaChi { get; set; }
        [Column("so_dien_thoai")]
        public string SoDienThoai { get; set; }
        [Column("so_tien_thu")]
        public decimal SoTienThu { get; set; }
        [Column("ngay_thu")]
        public DateTime NgayThu { get; set; }

        [ForeignKey("MaKhachHang")]
        public virtual Taikhoan MaKhachHangNavigation { get; set; }
    }
}