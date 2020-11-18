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
using System.Data.SqlClient;
using DEMOQLNH.Class;
using DEMOQLNH.Models;
using DEMOQLNH.Report;
using DevExpress.XtraReports.UI;

namespace DEMOQLNH
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void QuyenTruyCap()
        {
            if (checkper("QL000"))
            {
                rpgLuong.Enabled = true;
                rpgQLNV.Enabled = true;
                navQLNV.Visible = true;
                navGroupQLNH.Expanded = true;
            }
            if (checkper("QLKV0") || checkper("QL000"))
            {
                rpgBan.Enabled = true;
                navGroupQLNH.Visible = true;
                navQLKV.Visible = true;
                navQLBA.Visible = true;
                navGroupQLNH.Expanded = true;
            }
            if (checkper("QLTD0") || checkper("QL000"))
            {
                btnQLLoaiTD.Enabled = true;
                btnQLTD.Enabled = true;
                navQLTD.Visible = true;
            }
            if (checkper("QLGM0") || checkper("QL000"))
            {
                rpgGoiMon.Enabled = true;
                navQLGM.Visible = true;
                navThanhToan.Visible = true;
                navGroupThanhToan.Visible = true;
            }
            if (checkper("QLDT0") || checkper("QL000"))
            {
                rpgDoanhThu.Enabled = true;
                rpgThongKe.Enabled = true;
                navDoanhThu.Visible = true;
                navThongKe.Visible = true;
                navGroupBaoCao.Visible = true;
            }
        }
        private void LoadMain()
        {
            navGroupBaoCao.Visible = false;
            navGroupThanhToan.Visible = false;
            navGroupQLNH.Visible = false;
            navQLNV.Visible = false;
            navQLKV.Visible = false;
            navQLBA.Visible = false;
            navQLTD.Visible = false;
            navQLGM.Visible = false;
            navThanhToan.Visible = false;
            navDoanhThu.Visible = false;
            navThongKe.Visible = false;
            QuyenTruyCap();
            btnDoiPass.Enabled = true;
            btnDX.Enabled = true;
            navBarControl1.Visible = true;
            btnLogin.Enabled = false;
            btnQMK.Enabled = false;
            btnMenu.Enabled = true;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            if (FrmLogin.ID_USER == "")
                navBarControl1.Visible = false;
            else
                LoadMain();
        }
        private QuanLyNhaHangDBContext db = new QuanLyNhaHangDBContext();
        private Boolean checkper(string code)
        {
            Boolean check = false;
            foreach (string item in Class.Functions.list_MaQuyen(FrmLogin.ID_USER))
            {
                if (item == code)
                    check = true;
            }
            return check;
        }
        //Xem Form có tồn tại trên form Main hay chưa.
        private bool ExistFrom(XtraForm form)
        {
            foreach (var child in MdiChildren)
                if (child.Name == form.Name)
                {
                    child.Activate();
                    return true;
                }
            return false;
        }
        private void btnLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
            FrmLogin frm_login = new FrmLogin();
            if (ExistFrom(frm_login)) return;
            frm_login.Show();
        }

        private void btnDoiPass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
            frmDOIPASS frm = new frmDOIPASS();
            if (ExistFrom(frm)) return;
            frm.Show();
        }
        private void btnQLNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmQLNV f = new frmQLNV();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }
        private void navQLNV_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmQLNV f = new frmQLNV();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        //private void btnFind_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    frmFind f = new frmFind();
        //    if (ExistFrom(f)) return;
        //    f.MdiParent = this;
        //    f.Show();
        //}

        private void btnPhanQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTAIKHOAN f = new frmTAIKHOAN();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btnThanhToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTHANHTOAN f = new frmTHANHTOAN();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }
        private void navThanhToan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmTHANHTOAN f = new frmTHANHTOAN();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btnQLKV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmQLKV f = new frmQLKV();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void navQLKV_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmQLKV f = new frmQLKV();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btnQLB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmQLBAN f = new frmQLBAN();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void navQLBA_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmQLBAN f = new frmQLBAN();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btnQLLoaiTD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLOAITHUCDON f = new frmLOAITHUCDON();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btnQLTD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmQLTHUCDON f = new frmQLTHUCDON();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void navQLTD_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmQLTHUCDON f = new frmQLTHUCDON();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btnMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMENU f = new frmMENU();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void navMenu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmMENU f = new frmMENU();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btnQLGM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmQLGOIMON f = new frmQLGOIMON();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void navQLGM_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmQLGOIMON f = new frmQLGOIMON();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnDX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Hide();
                FrmLogin.ID_USER = "";
                frmMain f = new frmMain();
                f.Show();
            }    
        }

        private void btnChamCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("CHỨC NĂNG NÀY ĐANG ĐƯỢC PHÁT TRIỂN!", "Thông Báo");
        }

        private void btnTinhLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("CHỨC NĂNG NÀY ĐANG ĐƯỢC PHÁT TRIỂN!", "Thông Báo");
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                Application.Exit();
            else
                e.Cancel = true;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnQLBanTrong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBanTrong f = new frmBanTrong();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btnBanPV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBanPV f = new frmBanPV();
            if (ExistFrom(f)) return;
            f.MdiParent = this;
            WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btnThuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("CHỨC NĂNG NÀY ĐANG ĐƯỢC PHÁT TRIỂN!", "Thông Báo");
        }

        private void btnChiTieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("CHỨC NĂNG NÀY ĐANG ĐƯỢC PHÁT TRIỂN!", "Thông Báo");
        }

        private void btnThongKe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var list = db.HOADONs.ToList();
            rptDSHoaDon report = new rptDSHoaDon();
            report.DataSource = list;
            report.ShowPreviewDialog();
        }

        private void navThongKe_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MessageBox.Show("CHỨC NĂNG NÀY ĐANG ĐƯỢC PHÁT TRIỂN!", "Thông Báo");
        }

        private void navDoanhThu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MessageBox.Show("CHỨC NĂNG NÀY ĐANG ĐƯỢC PHÁT TRIỂN!", "Thông Báo");
        }

        private void btnQMK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("CHỨC NĂNG NÀY ĐANG ĐƯỢC PHÁT TRIỂN!", "Thông Báo");
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var list = db.NHANVIENs.ToList();
            rptDSNV nv = new rptDSNV();
            nv.DataSource = list;
            nv.ShowPreviewDialog();
        }
    }
}