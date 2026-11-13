using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THBookAPI.Models
{
    [Table("nhacungcap")]
    public class Nhacungcap
    {
        [Key, Column("ma_don_vi")]
        public string MaDonVi { get; set; }
        [Column("ten_don_vi")]
        public string TenDonVi { get; set; }
        [Column("loai_don_vi")]
        public string LoaiDonVi { get; set; }
        [Column("dia_chi")]
        public string DiaChi { get; set; }
        [Column("so_dien_thoai")]
        public string SoDienThoai { get; set; }
    }
}