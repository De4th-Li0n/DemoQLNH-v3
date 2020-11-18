namespace DEMOQLNH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN()
        {
            TAIKHOAN_NHOMQUYEN = new HashSet<TAIKHOAN_NHOMQUYEN>();
        }

        [Key]
        [StringLength(30)]
        public string TenTaiKhoan { get; set; }

        [StringLength(30)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(5)]
        public string MaNhanVien { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAIKHOAN_NHOMQUYEN> TAIKHOAN_NHOMQUYEN { get; set; }
    }
}
