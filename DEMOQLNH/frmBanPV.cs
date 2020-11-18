using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DEMOQLNH.Models;

namespace DEMOQLNH
{
    public partial class frmBanPV : DevExpress.XtraEditors.XtraForm
    {
        private QuanLyNhaHangDBContext db = new QuanLyNhaHangDBContext();
        public frmBanPV()
        {
            InitializeComponent();
        }

        private void frmBanPV_Load(object sender, EventArgs e)
        {
            var list = db.BANs.Where(m => m.TrangThai.ToString() == "Đã Có Khách" && m.KHUVUC.TrangThai.ToString() == "Hoạt Động").Select(m => new { m.MaBan, m.TenBan, m.KHUVUC.TenKhuVuc, m.MoTa }).ToList();
            gridBanPV.DataSource = list;
            gridView1.Columns[0].Caption = "Mã Bàn";
            gridView1.Columns[1].Caption = "Tên Bàn";
            gridView1.Columns[2].Caption = "Tên Khu Vực";
            gridView1.Columns[3].Caption = "Mô Tả";

            gridView1.Columns[0].Width = 50;
            gridView1.Columns[1].Width = 100;
            gridView1.Columns[2].Width = 100;
            gridView1.Columns[3].Width = 150;
        }
    }
}