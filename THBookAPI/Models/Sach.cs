using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THBookAPI.Models
{
    [Table("sach")]
    public class Sach
    {
        [Key, Column("ma_sach")]
        public int MaSach { get; set; }
        [Column("ten_sach")]
        public string TenSach { get; set; }
        [Column("ma_tac_gia")]
        public string MaTacGia { get; set; }
        [Column("ma_the_loai")]
        public string MaTheLoai { get; set; }
        [Column("gia_ban")]
        public decimal GiaBan { get; set; }
        [Column("ton_kho")]
        public int TonKho { get; set; }
        [Column("giam_gia")]
        public int GiamGia { get; set; }
        [Column("da_ban")]
        public int? DaBan { get; set; }
        [Column("hinh_anh")]
        public string HinhAnh { get; set; }
        [Column("mo_ta")]
        public string MoTa { get; set; }

        [ForeignKey("MaTacGia")]
        public virtual Tacgia MaTacGiaNavigation { get; set; }
    }
}