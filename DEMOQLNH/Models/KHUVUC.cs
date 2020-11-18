namespace DEMOQLNH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHUVUC")]
    public partial class KHUVUC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHUVUC()
        {
            BANs = new HashSet<BAN>();
        }

        [Key]
        [StringLength(5)]
        public string MaKhuVuc { get; set; }

        [StringLength(15)]
        public string TenKhuVuc { get; set; }

        [StringLength(30)]
        public string MoTa { get; set; }

        [StringLength(20)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAN> BANs { get; set; }
    }
}
