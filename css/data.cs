using Microsoft.EntityFrameworkCore;
using QLNhaSach.Models;

namespace QLNhaSach.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Sach> Sachs { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public DbSet<PhieuThu> PhieuThus { get; set; }
    }
}