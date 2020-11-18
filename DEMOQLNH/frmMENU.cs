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
    public partial class frmMENU : DevExpress.XtraEditors.XtraForm
    {
        private QuanLyNhaHangDBContext db = new QuanLyNhaHangDBContext();
        public frmMENU()
        {
            InitializeComponent();
        }

        private void MENU_Load(object sender, EventArgs e)
        {
            var list = db.THUCDONs.Select(m => new { m.MaThucDon, m.LOAITHUCDON.TenLoai, m.TenThucDon, m.DonViTinh, m.SoLuongTon, m.DonGia, m.TrangThai }).ToList();
            gridDSTD.DataSource = list;
            gridView1.Columns[0].Caption = "Mã Thực Đơn";
            gridView1.Columns[1].Caption = "Tên Loại Thực Đơn";
            gridView1.Columns[2].Caption = "Tên Thực Đơn";
            gridView1.Columns[3].Caption = "Đơn Vị Tính";
            gridView1.Columns[4].Caption = "Số Lượng Tồn";
            gridView1.Columns[5].Caption = "Đơn Giá";
            gridView1.Columns[6].Caption = "Trạng Thái";

            gridView1.Columns[0].Width = 30;
            gridView1.Columns[1].Width = 80;
            gridView1.Columns[2].Width = 80;
            gridView1.Columns[3].Width = 50;
            gridView1.Columns[4].Width = 30;
            gridView1.Columns[5].Width = 50;
            gridView1.Columns[6].Width = 60;
        }
    }
}