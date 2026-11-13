using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THBookAPI.Models
{
    [Table("taikhoan")]
    public class Taikhoan
    {
        [Key, Column("ma_tai_khoan")]
        public int MaTaiKhoan { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("mat_khau")]
        public string MatKhau { get; set; }
        [Column("ho_ten")]
        public string HoTen { get; set; }
        [Column("so_dien_thoai")]
        public string SoDienThoai { get; set; }
        [Column("vai_tro")]
        public string VaiTro { get; set; }
        [Column("so_tien_no")]
        public decimal SoTienNo { get; set; }
    }
}