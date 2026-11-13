using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THBookAPI.Models
{
    [Table("nhanvien")]
    public class Nhanvien
    {
        [Key, Column("ma_nv")]
        public string MaNv { get; set; }
        [Column("ho_ten")]
        public string HoTen { get; set; }
        [Column("chuc_vu")]
        public string ChucVu { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("so_dien_thoai")]
        public string SoDienThoai { get; set; }
        [Column("trang_thai")]
        public string TrangThai { get; set; }
    }
}