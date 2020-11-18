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
using DEMOQLNH.Class;
using System.Data.SqlClient;

namespace DEMOQLNH
{
    public partial class frmTAIKHOAN : DevExpress.XtraEditors.XtraForm
    {
        private QuanLyNhaHangDBContext db = new QuanLyNhaHangDBContext();
        List<TAIKHOAN_NHOMQUYEN> ma1 = new List<TAIKHOAN_NHOMQUYEN>();
        public bool themmoi = false;
        public frmTAIKHOAN()
        {
            InitializeComponent();
        }
        void setButton(bool val)
        {
            gridDSTK.Enabled = val;
            btnAdd.Enabled = val;
            btnDel.Enabled = val;
            btnEdit.Enabled = val;
            btnSave.Enabled = !val;
            btnCancel.Enabled = !val;
            txtTenTaiKhoan.Enabled = !val;
            txtMatKhau.Enabled = !val;
            cmbMaNV.Enabled = !val;
            grcQuyen.Enabled = !val;
        }
        void setNull()
        {
            txtTenTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtTenNV.Text = "";
            cmbMaNV.SelectedIndex = -1;
            checkfalse();
        }
        void bingding()
        {
            cmbMaNV.DataBindings.Clear();
            cmbMaNV.DataBindings.Add("Text", gridDSTK.DataSource, "MaNhanVien");
            txtTenTaiKhoan.DataBindings.Clear();
            txtTenTaiKhoan.DataBindings.Add("Text", gridDSTK.DataSource, "TenTaiKhoan");
            txtMatKhau.DataBindings.Clear();
            txtMatKhau.DataBindings.Add("Text", gridDSTK.DataSource, "MatKhau");
            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", gridDSTK.DataSource, "HoTen");
        }
        private void TAIKHOAN_Load(object sender, EventArgs e)
        {
            txtTenNV.Enabled = false;
            loadtk();
            loadMaNV();
            setButton(true);
        }
        private void loadtk()
        {
            var list_tk = db.TAIKHOANs.Join(
                    db.NHANVIENs,
                    t => t.MaNhanVien,
                    n => n.MaNhanVien,
                    (t, n) => new HoTenTaiKhoan
                    {
                        TenTaiKhoan = t.TenTaiKhoan,
                        MatKhau = t.MatKhau,
                        MaNhanVien = t.MaNhanVien,
                        HoTen = n.Ho + " " + n.Ten,
                    }
                    ).ToList();
            gridDSTK.DataSource = list_tk;
            loadquyen();
            gridView1.Columns[0].Caption = "Tên Tài Khoản";
            gridView1.Columns[1].Caption = "Mật Khẩu";
            gridView1.Columns[2].Caption = "Mã Nhân Viên";
            gridView1.Columns[3].Caption = "Họ tên";

            gridView1.Columns[0].Width = 50;
            gridView1.Columns[1].Width = 50;
            gridView1.Columns[2].Width = 30;
            gridView1.Columns[3].Width = 80;
            bingding();
        }
        private void loadMaNV()
        {
            var listmanv = db.NHANVIENs.ToList();
            cmbMaNV.DataSource = listmanv;
            cmbMaNV.DisplayMember = "MaNhanVien";
            cmbMaNV.ValueMember = "MaNhanVien";
        }
        private void loadquyen()
        {
            if (checkper("QLKV0")) chkKhuVuc.Checked = true;
            if (checkper("QLTD0")) chkThucDon.Checked = true;
            if (checkper("QLGM0")) chkGoiMon.Checked = true;
            if (checkper("QLDT0")) chkDoanhThu.Checked = true;
            if (checkper("QL000")) chkQuanLy.Checked = true;
        }
        private Boolean checkper(string code)
        {
            string tk = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenTaiKhoan").ToString();
            Boolean check = false;
            foreach (string item in Class.Functions.list_MaQuyen(tk))
            {
                if (item == code) check = true;
            }
            return check;
        }
        private Boolean tktontai(string code)
        {
            Boolean check = false;
            List<TAIKHOAN> tk = db.TAIKHOANs.ToList();
            foreach (string item in tk.Select(m => m.TenTaiKhoan))
            {
                if (item == code) check = true;
            }
            return check;
        }
        private void themquyen()
        {
            string taikhoan = txtTenTaiKhoan.Text;
            TAIKHOAN_NHOMQUYEN quyen = new TAIKHOAN_NHOMQUYEN();
            if (chkQuanLy.Checked)
            {
                quyen.TenTaiKhoan = taikhoan;
                quyen.MaQuyen = "QL000";
                db.TAIKHOAN_NHOMQUYEN.Add(quyen);
                db.SaveChanges();
            }
            if (chkKhuVuc.Checked)
            {
                quyen.TenTaiKhoan = taikhoan;
                quyen.MaQuyen = "QLKV0";
                db.TAIKHOAN_NHOMQUYEN.Add(quyen);
                db.SaveChanges();
            }
            if (chkThucDon.Checked)
            {
                quyen.TenTaiKhoan = taikhoan;
                quyen.MaQuyen = "QLTD0";
                db.TAIKHOAN_NHOMQUYEN.Add(quyen);
                db.SaveChanges();
            }
            if (chkGoiMon.Checked)
            {
                quyen.TenTaiKhoan = taikhoan;
                quyen.MaQuyen = "QLGM0";
                db.TAIKHOAN_NHOMQUYEN.Add(quyen);
                db.SaveChanges();
            }
            if (chkDoanhThu.Checked)
            {
                quyen.TenTaiKhoan = taikhoan;
                quyen.MaQuyen = "QLDT0";
                db.TAIKHOAN_NHOMQUYEN.Add(quyen);
                db.SaveChanges();
            }
        }
        private void checkfalse()
        {
            chkQuanLy.Checked = false;
            chkDoanhThu.Checked = false;
            chkGoiMon.Checked = false;
            chkKhuVuc.Checked = false;
            chkThucDon.Checked = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            setNull();
            setButton(false);
            themmoi = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa  không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string tk = txtTenTaiKhoan.Text;
                    ma1 = db.TAIKHOAN_NHOMQUYEN.Where(m => m.TenTaiKhoan == tk).ToList();
                    foreach (int ma in ma1.Select(m => m.MaTKNQ))
                    {
                        TAIKHOAN_NHOMQUYEN t1 = db.TAIKHOAN_NHOMQUYEN.Find(ma);
                        db.TAIKHOAN_NHOMQUYEN.Remove(t1);
                        db.SaveChanges();
                    }    
                    TAIKHOAN t2 = db.TAIKHOANs.Find(tk);
                    db.TAIKHOANs.Remove(t2);
                    db.SaveChanges();
                    loadtk();
                    MessageBox.Show("Đã Xóa Thành Công!", "Thông Báo");
                }
            }
            else
                MessageBox.Show("Bạn phải chọn 1 dòng cần xóa");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            themmoi = false;
            setButton(false);
            txtTenTaiKhoan.Enabled = false;
            cmbMaNV.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTenTaiKhoan.Text;
            string mk = txtMatKhau.Text;
            if(taikhoan != "" && mk != "")
            {
                if (mk.Length < 6 || taikhoan.Length < 6)
                    MessageBox.Show("Tên tài khoản và mật khẩu phải từ 6 chữ số trở lên!");
                else
                {
                    if (themmoi == true)
                    {
                        string tontai = db.TAIKHOANs.Where(m => m.MaNhanVien == cmbMaNV.Text).Select(m => m.TenTaiKhoan).FirstOrDefault();
                        if (tontai != null)
                            MessageBox.Show("Nhân viên này đã có tài khoản!");
                        else
                        {
                            if (tktontai(taikhoan))
                                MessageBox.Show("Tên tài khoản bị trùng!");
                            else
                            {
                                TAIKHOAN tk = new TAIKHOAN();
                                tk.TenTaiKhoan = taikhoan;
                                tk.MatKhau = mk;
                                tk.MaNhanVien = cmbMaNV.Text;
                                db.TAIKHOANs.Add(tk);
                                db.SaveChanges();
                                themquyen();
                                setNull();
                                setButton(true);
                                loadtk();
                                MessageBox.Show("Đã Thêm Thành Công!", "Thông Báo");
                            }
                        }
                    }
                    else
                    {
                        if (gridView1.FocusedRowHandle >= 0)
                        {
                            DialogResult dr = MessageBox.Show("Bạn có chắc muốn sửa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                ma1 = db.TAIKHOAN_NHOMQUYEN.Where(m => m.TenTaiKhoan == taikhoan).ToList();
                                foreach (int ma in ma1.Select(m => m.MaTKNQ))
                                {
                                    TAIKHOAN_NHOMQUYEN t1 = db.TAIKHOAN_NHOMQUYEN.Find(ma);
                                    db.TAIKHOAN_NHOMQUYEN.Remove(t1);
                                    db.SaveChanges();
                                }
                                TAIKHOAN t2 = db.TAIKHOANs.Find(taikhoan);
                                t2.MatKhau = mk;
                                db.SaveChanges();
                                themquyen();
                                setNull();
                                setButton(true);
                                loadtk();
                                MessageBox.Show("Đã Sửa Thành Công!", "Thông Báo");
                            }
                        }
                        else
                            MessageBox.Show("Bạn phải chọn 1 dòng cần sửa");
                    }
                }
            }     
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setButton(true);
            loadtk();
        }

        private void cmbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenNV.Text = db.NHANVIENs.Where(n => n.MaNhanVien == cmbMaNV.Text).Select(n => n.Ho + " " + n.Ten).FirstOrDefault();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            checkfalse();
            loadquyen();
        }
    }
}