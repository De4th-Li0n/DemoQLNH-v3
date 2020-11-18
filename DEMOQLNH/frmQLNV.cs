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
using DevExpress.Utils.Extensions;
using System.Data.SqlClient;

namespace DEMOQLNH
{
    public partial class frmQLNV : DevExpress.XtraEditors.XtraForm
    {
        private QuanLyNhaHangDBContext db = new QuanLyNhaHangDBContext();
        public bool themmoi = false;
        public frmQLNV()
        {
            InitializeComponent();
        }
        void setButton(bool val)
        {
            gridDSNV.Enabled = val;
            btnAdd.Enabled = val;
            btnDel.Enabled = val;
            btnEdit.Enabled = val;
            btnSave.Enabled = !val;
            btnCancel.Enabled = !val;
            txtMaNV.Enabled = !val;
            txtHo.Enabled = !val;
            txtTen.Enabled = !val;
            txtDT.Enabled = !val;
            txtDiaChi.Enabled = !val;
            cmbGioi.Enabled = !val;
            dtpNS.Enabled = !val;
        }
        void setNull()
        {
            txtMaNV.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtDT.Text = "";
            cmbGioi.SelectedIndex = -1;
        }
        void bingding()
        {
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", gridDSNV.DataSource, "MaNhanVien");
            txtHo.DataBindings.Clear();
            txtHo.DataBindings.Add("Text", gridDSNV.DataSource, "Ho");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", gridDSNV.DataSource, "Ten");
            txtDT.DataBindings.Clear();
            txtDT.DataBindings.Add("Text", gridDSNV.DataSource, "DienThoai");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", gridDSNV.DataSource, "DiaChi");
            cmbGioi.DataBindings.Clear();
            cmbGioi.DataBindings.Add("Text", gridDSNV.DataSource, "GioiTinh");
            dtpNS.DataBindings.Clear();
            dtpNS.DataBindings.Add("Text", gridDSNV.DataSource, "NgaySinh");
        }
        private void QLNV_Load(object sender, EventArgs e)
        {
            setButton(true);
            loadNhanVien();
        }
        private void loadNhanVien()
        {
            var listnhanvien = db.NHANVIENs.Select(c => new { c.MaNhanVien, c.Ho, c.Ten, c.NgaySinh, c.GioiTinh, c.DienThoai, c.DiaChi }).ToList();
            gridDSNV.DataSource = listnhanvien;
            gridView1.Columns[0].Caption = "Mã Nhân Viên";
            gridView1.Columns[1].Caption = "Họ";
            gridView1.Columns[2].Caption = "Tên";
            gridView1.Columns[3].Caption = "Ngày Sinh";
            gridView1.Columns[4].Caption = "Giới Tính";
            gridView1.Columns[5].Caption = "Điện Thoại";
            gridView1.Columns[6].Caption = "Địa Chỉ";

            gridView1.Columns[0].Width = 40;
            gridView1.Columns[1].Width = 70;
            gridView1.Columns[2].Width = 50;
            gridView1.Columns[3].Width = 40;
            gridView1.Columns[4].Width = 30;
            gridView1.Columns[5].Width = 70;
            gridView1.Columns[6].Width = 150;

            bingding();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dtpNS.DataBindings.Clear();
            setNull();
            setButton(false);
            themmoi = true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            setButton(true);
            loadNhanVien();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.Text;
            string ho = txtHo.Text;
            string ten = txtTen.Text;
            string dienthoai = txtDT.Text;
            string dc = txtDiaChi.Text;
            if (manv != "" && ho != "" && ten != "" && cmbGioi.Text != "")
            {
                if (manv.Length != 5)
                {
                    MessageBox.Show("Mã nhân viên phải là 5 chữ số. VD: NV001.");
                }
                else
                {
                    if (dtpNS.Value > DateTime.Now)
                    {
                        MessageBox.Show("Ngày Sinh không được lớn hơn ngày hiện tại!");
                    }
                    else
                    {
                        if (themmoi == true)
                        {
                            string n = db.NHANVIENs.Where(m => m.MaNhanVien == manv).Select(m => m.MaNhanVien).FirstOrDefault();
                            if (n != null)
                            {
                                MessageBox.Show("Mã nhân viên này đã tồn tại!");
                            }
                            else
                            {
                                NHANVIEN nv = new NHANVIEN();
                                nv.MaNhanVien = manv;
                                nv.Ho = ho;
                                nv.Ten = ten;
                                nv.DienThoai = dienthoai;
                                nv.DiaChi = dc;
                                nv.GioiTinh = cmbGioi.Text;
                                nv.NgaySinh = Convert.ToDateTime(dtpNS.Value);
                                db.NHANVIENs.Add(nv);
                                db.SaveChanges();
                                setButton(true);
                                loadNhanVien();
                                MessageBox.Show("Đã Thêm Thành Công!", "Thông Báo");
                            }
                        }
                        else
                        {
                            if (gridView1.FocusedRowHandle >= 0)
                            {
                                DialogResult dr = MessageBox.Show("Bạn có chắc muốn sửa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dr == DialogResult.Yes)
                                {
                                    NHANVIEN nv = db.NHANVIENs.Find(manv);
                                    nv.Ho = ho;
                                    nv.Ten = ten;
                                    nv.DienThoai = dienthoai;
                                    nv.DiaChi = dc;
                                    nv.GioiTinh = cmbGioi.Text;
                                    nv.NgaySinh = Convert.ToDateTime(dtpNS.Value);
                                    db.SaveChanges();
                                    setButton(true);
                                    loadNhanVien();
                                    MessageBox.Show("Đã Sửa Thành Công!", "Thông Báo");
                                }
                            }
                            else
                                MessageBox.Show("Bạn phải chọn 1 dòng cần sửa");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập thông tin đầy đủ.");
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if(gridView1.FocusedRowHandle >= 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa  không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    NHANVIEN nv = db.NHANVIENs.Find(txtMaNV.Text);
                    db.NHANVIENs.Remove(nv);
                    db.SaveChanges();
                    loadNhanVien();
                    MessageBox.Show("Đã Xóa Thành Công!", "Thông Báo");
                }
            }
            else
                MessageBox.Show("Bạn phải chọn 1 dòng cần xóa");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dtpNS.DataBindings.Clear();
            themmoi = false;
            setButton(false);
            txtMaNV.Enabled = false;
        }

        private void txtDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}