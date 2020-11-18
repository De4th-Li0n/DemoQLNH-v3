namespace DEMOQLNH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THUCDON")]
    public partial class THUCDON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUCDON()
        {
            GOIMONs = new HashSet<GOIMON>();
        }

        [Key]
        [StringLength(5)]
        public string MaThucDon { get; set; }

        [Required]
        [StringLength(5)]
        public string MaLoai { get; set; }

        [StringLength(50)]
        public string TenThucDon { get; set; }

        [StringLength(10)]
        public string DonViTinh { get; set; }

        public int? SoLuongTon { get; set; }

        public float? DonGia { get; set; }

        [StringLength(15)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOIMON> GOIMONs { get; set; }

        public virtual LOAITHUCDON LOAITHUCDON { get; set; }
    }
}
