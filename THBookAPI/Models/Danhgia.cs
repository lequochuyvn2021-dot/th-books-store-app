using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THBookAPI.Models
{
    [Table("danhgia")]
    public class Danhgia
    {
        [Key, Column("ma_danh_gia")]
        public int MaDanhGia { get; set; }
        [Column("ma_sach")]
        public int MaSach { get; set; }
        [Column("ma_tai_khoan")]
        public int MaTaiKhoan { get; set; }
        [Column("so_sao")]
        public int? SoSao { get; set; }
        [Column("binh_luan")]
        public string BinhLuan { get; set; }
        [Column("ngay_danh_gia")]
        public DateTime? NgayDanhGia { get; set; }

        [ForeignKey("MaSach")]
        public virtual Sach MaSachNavigation { get; set; }
        [ForeignKey("MaTaiKhoan")]
        public virtual Taikhoan MaTaiKhoanNavigation { get; set; }
    }
}