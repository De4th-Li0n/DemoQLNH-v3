namespace DEMOQLNH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TAIKHOAN_NHOMQUYEN
    {
        [Key]
        public int MaTKNQ { get; set; }

        [Required]
        [StringLength(30)]
        public string TenTaiKhoan { get; set; }

        [Required]
        [StringLength(5)]
        public string MaQuyen { get; set; }

        public virtual NHOMQUYEN NHOMQUYEN { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
