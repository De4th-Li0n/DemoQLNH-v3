namespace DEMOQLNH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHOMQUYEN")]
    public partial class NHOMQUYEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHOMQUYEN()
        {
            TAIKHOAN_NHOMQUYEN = new HashSet<TAIKHOAN_NHOMQUYEN>();
        }

        [Key]
        [StringLength(5)]
        public string MaQuyen { get; set; }

        [StringLength(50)]
        public string TenQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAIKHOAN_NHOMQUYEN> TAIKHOAN_NHOMQUYEN { get; set; }
    }
}
