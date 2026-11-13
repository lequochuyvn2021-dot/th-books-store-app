using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THBookAPI.Models
{
    [Table("tacgia")]
    public class Tacgia
    {
        [Key, Column("ma_tac_gia")]
        public string MaTacGia { get; set; }
        [Column("ten_tac_gia")]
        public string TenTacGia { get; set; }
        [Column("quoc_tich")]
        public string QuocTich { get; set; }
    }
}