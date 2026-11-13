using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THBookAPI.Models
{
    [Table("theloai")]
    public class Theloai
    {
        [Key, Column("ma_the_loai")]
        public string MaTheLoai { get; set; }
        [Column("ten_the_loai")]
        public string TenTheLoai { get; set; }
    }
}