namespace DEMOQLNH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            GOIMONs = new HashSet<GOIMON>();
        }

        [Key]
        public int MaHoaDon { get; set; }

        [Required]
        [StringLength(5)]
        public string MaBan { get; set; }

        [Required]
        [StringLength(5)]
        public string MaNhanVien { get; set; }

        public DateTime? ThoiGian { get; set; }

        public double? TongTien { get; set; }

        public virtual BAN BAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOIMON> GOIMONs { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
