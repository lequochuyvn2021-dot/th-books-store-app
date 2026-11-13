using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THBookAPI.Models
{
    [Table("phieunhapkho")]
    public class Phieunhapkho
    {
        [Key, Column("ma_phieu")]
        public string MaPhieu { get; set; }
        [Column("ngay_nhap")]
        public DateTime NgayNhap { get; set; }
        [Column("ma_sach")]
        public int MaSach { get; set; }
        [Column("so_luong_nhap")]
        public int SoLuongNhap { get; set; }

        [ForeignKey("MaSach")]
        public virtual Sach MaSachNavigation { get; set; }
    }
}