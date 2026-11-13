using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THBookAPI.Models
{
    [Table("chitietdonhang")]
    public class Chitietdonhang
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("ma_don_hang")]
        public string MaDonHang { get; set; }
        [Column("ma_sach")]
        public int MaSach { get; set; }
        [Column("so_luong")]
        public int SoLuong { get; set; }
        [Column("don_gia")]
        public decimal DonGia { get; set; }

        [ForeignKey("MaDonHang")]
        public virtual Donhang MaDonHangNavigation { get; set; }
        [ForeignKey("MaSach")]
        public virtual Sach MaSachNavigation { get; set; }
    }
}