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
using System.Data.SqlClient;

namespace DEMOQLNH
{
    public partial class frmQLTHUCDON : DevExpress.XtraEditors.XtraForm
    {
        private QuanLyNhaHangDBContext db = new QuanLyNhaHangDBContext();
        public bool themmoi = false;
        public frmQLTHUCDON()
        {
            InitializeComponent();
        }
        void setButton(bool val)
        {
            gridDSTD.Enabled = val;
            btnAdd.Enabled = val;
            btnDel.Enabled = val;
            btnEdit.Enabled = val;
            btnSave.Enabled = !val;
            btnCancel.Enabled = !val;
            txtMaTD.Enabled = !val;
            txtTenTD.Enabled = !val;
            cmbTrangThai.Enabled = !val;
            cmbTenLoai.Enabled = !val;
            txtDVT.Enabled = !val;
            txtGia.Enabled = !val;
            txtSLT.Enabled = !val;
        }
        void setNull()
        {
            txtMaTD.Text = "";
            txtTenTD.Text = "";
            txtDVT.Text = "";
            txtGia.Text = "";
            txtSLT.Text = "";
            cmbTrangThai.SelectedIndex = -1;
            cmbTenLoai.SelectedIndex = -1;
        }
        void bingding()
        {
            cmbTenLoai.DataBindings.Clear();
            cmbTenLoai.DataBindings.Add("Text", gridDSTD.DataSource, "TenLoai");
            cmbTrangThai.DataBindings.Clear();
            cmbTrangThai.DataBindings.Add("Text", gridDSTD.DataSource, "TrangThai");
            txtMaTD.DataBindings.Clear();
            txtMaTD.DataBindings.Add("Text", gridDSTD.DataSource, "MaThucDon");
            txtTenTD.DataBindings.Clear();
            txtTenTD.DataBindings.Add("Text", gridDSTD.DataSource, "TenThucDon");
            txtDVT.DataBindings.Clear();
            txtDVT.DataBindings.Add("Text", gridDSTD.DataSource, "DonViTinh");
            txtGia.DataBindings.Clear();  
            txtGia.DataBindings.Add("Text", gridDSTD.DataSource, "DonGia");
            txtSLT.DataBindings.Clear();
            txtSLT.DataBindings.Add("Text", gridDSTD.DataSource, "SoLuongTon");
        }
        private void QLTHUCDON_Load(object sender, EventArgs e)
        {
            loadLoai();
            loadTD();
            setButton(true);
        }
        private void loadTD()
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
            Class.Functions.TrangThaiTD();
            Class.Functions.TrangThaiLoaiTD();
            Class.Functions.checkperSL();
            bingding();
        }
        private void loadLoai()
        {
            var list = db.LOAITHUCDONs.ToList();
            cmbTenLoai.DataSource = list;
            cmbTenLoai.DisplayMember = "TenLoai";
            cmbTenLoai.ValueMember = "MaLoai";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            setNull();
            setButton(false);
            themmoi = true;
            txtMaTD.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa  không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    THUCDON td = db.THUCDONs.Find(txtMaTD.Text);
                    db.THUCDONs.Remove(td);
                    db.SaveChanges();
                    loadTD();
                    MessageBox.Show("Đã Xóa Thành Công!", "Thông Báo");
                }
            }
            else
                MessageBox.Show("Bạn phải chọn 1 dòng cần xóa");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtGia.DataBindings.Clear();
            txtSLT.DataBindings.Clear();
            themmoi = false;
            setButton(false);
            txtMaTD.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMaTD.Text != "" && txtTenTD.Text != "" && txtGia.Text != "" && txtDVT.Text != "" && txtSLT.Text != "" && cmbTenLoai.Text != "" && cmbTrangThai.Text != "")
            {
                if (txtMaTD.Text.Length != 5)
                {
                    MessageBox.Show("Mã Thực Đơn phải là 5 chữ số. VD: TD001.");
                }
                else
                {
                    float gia = Convert.ToInt32(txtGia.Text);
                    int sl = Convert.ToInt32(txtSLT.Text);
                    if (themmoi == true)
                    {
                        string ma = db.THUCDONs.Where(m => m.TenThucDon == txtTenTD.Text).Select(m => m.TenThucDon).FirstOrDefault();
                        if (ma != null)
                        {
                            MessageBox.Show("Tên Thực Đơn này đã tồn tại!");
                        }
                        else
                        {
                            ma = db.THUCDONs.Where(m => m.MaThucDon == txtMaTD.Text).Select(m => m.MaThucDon).FirstOrDefault();
                            if (ma != null)
                            {
                                MessageBox.Show("Mã Thực Đơn này đã tồn tại!");
                            }
                            else
                            {
                                THUCDON t = new THUCDON();
                                t.MaThucDon = txtMaTD.Text;
                                t.TenThucDon = txtTenTD.Text;
                                t.DonGia = gia;
                                t.DonViTinh = txtDVT.Text;
                                t.SoLuongTon = sl;
                                t.TrangThai = cmbTrangThai.Text;
                                t.MaLoai = cmbTenLoai.SelectedValue.ToString();
                                db.THUCDONs.Add(t);
                                db.SaveChanges();
                                setButton(true);
                                loadTD();
                                MessageBox.Show("Đã Thêm Thành Công!", "Thông Báo");
                            }
                        }
                    }
                    else
                    {
                        if (gridView1.FocusedRowHandle >= 0)
                        {
                            string ma = db.THUCDONs.Where(m => m.MaThucDon == txtMaTD.Text && m.TenThucDon == txtTenTD.Text).Select(m => txtTenTD.Text).FirstOrDefault();
                            if (ma != null)
                            {
                                DialogResult dr = MessageBox.Show("Bạn có chắc muốn sửa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dr == DialogResult.Yes)
                                {
                                    THUCDON td = db.THUCDONs.Find(txtMaTD.Text);
                                    td.TenThucDon = txtTenTD.Text;
                                    td.DonGia = gia;
                                    td.DonViTinh = txtDVT.Text;
                                    td.SoLuongTon = sl;
                                    td.TrangThai = cmbTrangThai.Text;
                                    td.MaLoai = cmbTenLoai.SelectedValue.ToString();
                                    db.SaveChanges();
                                    setButton(true);
                                    loadTD();
                                    MessageBox.Show("Đã Sửa Thành Công!", "Thông Báo");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Tên Thực Đơn này đã tồn tại!", "Thông Báo");
                                txtTenTD.Focus();
                            }    
                        }
                        else
                            MessageBox.Show("Bạn phải chọn 1 dòng cần sửa");
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập thông tin đầy đủ.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setButton(true);
            loadTD();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn Reset Hàng?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                List<LOAITHUCDON> list = db.LOAITHUCDONs.ToList();
                foreach (string c in list.Select(m => m.MaLoai))
                {
                    LOAITHUCDON l = db.LOAITHUCDONs.Find(c);
                    l.TrangThai = "Còn Hàng";
                    db.SaveChanges();
                }
                List<THUCDON> listtd = db.THUCDONs.ToList();
                foreach (string td in listtd.Select(m => m.MaThucDon))
                {
                    THUCDON t = db.THUCDONs.Find(td);
                    t.SoLuongTon = 50;
                    t.TrangThai = "Còn Hàng";
                    db.SaveChanges();
                }
                loadTD();
            }
        }
    }
}