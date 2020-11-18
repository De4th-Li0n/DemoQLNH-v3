namespace DEMOQLNH.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyNhaHangDBContext : DbContext
    {
        public QuanLyNhaHangDBContext()
            : base("name=QuanLyNhaHangDBContext")
        {
        }

        public virtual DbSet<BAN> BANs { get; set; }
        public virtual DbSet<GOIMON> GOIMONs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHUVUC> KHUVUCs { get; set; }
        public virtual DbSet<LOAITHUCDON> LOAITHUCDONs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NHOMQUYEN> NHOMQUYENs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<TAIKHOAN_NHOMQUYEN> TAIKHOAN_NHOMQUYEN { get; set; }
        public virtual DbSet<THUCDON> THUCDONs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BAN>()
                .Property(e => e.MaBan)
                .IsUnicode(false);

            modelBuilder.Entity<BAN>()
                .Property(e => e.MaKhuVuc)
                .IsUnicode(false);

            modelBuilder.Entity<BAN>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.BAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GOIMON>()
                .Property(e => e.MaThucDon)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaBan)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.GOIMONs)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHUVUC>()
                .Property(e => e.MaKhuVuc)
                .IsUnicode(false);

            modelBuilder.Entity<KHUVUC>()
                .HasMany(e => e.BANs)
                .WithRequired(e => e.KHUVUC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAITHUCDON>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<LOAITHUCDON>()
                .HasMany(e => e.THUCDONs)
                .WithRequired(e => e.LOAITHUCDON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.TAIKHOANs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHOMQUYEN>()
                .Property(e => e.MaQuyen)
                .IsUnicode(false);

            modelBuilder.Entity<NHOMQUYEN>()
                .HasMany(e => e.TAIKHOAN_NHOMQUYEN)
                .WithRequired(e => e.NHOMQUYEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.TAIKHOAN_NHOMQUYEN)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN_NHOMQUYEN>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN_NHOMQUYEN>()
                .Property(e => e.MaQuyen)
                .IsUnicode(false);

            modelBuilder.Entity<THUCDON>()
                .Property(e => e.MaThucDon)
                .IsUnicode(false);

            modelBuilder.Entity<THUCDON>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<THUCDON>()
                .HasMany(e => e.GOIMONs)
                .WithRequired(e => e.THUCDON)
                .WillCascadeOnDelete(false);
        }
    }
}
