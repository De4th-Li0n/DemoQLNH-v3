namespace DEMOQLNH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GOIMON")]
    public partial class GOIMON
    {
        [Key]
        public int MaGoiMon { get; set; }

        public int MaHoaDon { get; set; }

        [Required]
        [StringLength(5)]
        public string MaThucDon { get; set; }

        public int? SoLuong { get; set; }

        public double? ThanhTien { get; set; }

        public virtual HOADON HOADON { get; set; }

        public virtual THUCDON THUCDON { get; set; }
    }
}
