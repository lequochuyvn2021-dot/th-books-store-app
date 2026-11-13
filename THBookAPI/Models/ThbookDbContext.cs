using Microsoft.EntityFrameworkCore;

namespace THBookAPI.Models
{
    public class ThbookDbContext : DbContext
    {
        public ThbookDbContext(DbContextOptions<ThbookDbContext> options) : base(options) { }

        public DbSet<Theloai> Theloais { get; set; }
        public DbSet<Tacgia> Tacgias { get; set; }
        public DbSet<Nhacungcap> Nhacungcaps { get; set; }
        public DbSet<Sach> Saches { get; set; }
        public DbSet<Taikhoan> Taikhoans { get; set; }
        public DbSet<Nhanvien> Nhanviens { get; set; }
        public DbSet<Donhang> Donhangs { get; set; }
        public DbSet<Chitietdonhang> Chitietdonhangs { get; set; }
        public DbSet<Phieunhapkho> Phieunhapkhoes { get; set; }
        public DbSet<Phieuthutien> Phieuthutiens { get; set; }
        public DbSet<Danhgia> Danhgias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Theloai>().ToTable("theloai");
            modelBuilder.Entity<Tacgia>().ToTable("tacgia");
            modelBuilder.Entity<Nhacungcap>().ToTable("nhacungcap");
            modelBuilder.Entity<Sach>().ToTable("sach");
            modelBuilder.Entity<Taikhoan>().ToTable("taikhoan");
            modelBuilder.Entity<Nhanvien>().ToTable("nhanvien");
            modelBuilder.Entity<Donhang>().ToTable("donhang");
            modelBuilder.Entity<Chitietdonhang>().ToTable("chitietdonhang");
            modelBuilder.Entity<Phieunhapkho>().ToTable("phieunhapkho");
            modelBuilder.Entity<Phieuthutien>().ToTable("phieuthutien");
            modelBuilder.Entity<Danhgia>().ToTable("danhgia");
        }
    }
}