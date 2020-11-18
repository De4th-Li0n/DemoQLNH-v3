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
using DEMOQLNH.Models;

namespace DEMOQLNH
{
    public partial class frmLOAITHUCDON : DevExpress.XtraEditors.XtraForm
    {
        private QuanLyNhaHangDBContext db = new QuanLyNhaHangDBContext();
        public bool themmoi = false;
        public frmLOAITHUCDON()
        {
            InitializeComponent();
        }
        void setButton(bool val)
        {
            gridLoaiTD.Enabled = val;
            btnAdd.Enabled = val;
            btnDel.Enabled = val;
            btnEdit.Enabled = val;
            btnSave.Enabled = !val;
            btnCancel.Enabled = !val;
            txtMaLoai.Enabled = !val;
            txtTenLoai.Enabled = !val;
            cmbTrangThai.Enabled = !val;
        }
        void setNull()
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            cmbTrangThai.SelectedIndex = -1;
        }
        void bingding()
        {
            cmbTrangThai.DataBindings.Clear();
            cmbTrangThai.DataBindings.Add("Text", gridLoaiTD.DataSource, "TrangThai");
            txtMaLoai.DataBindings.Clear();
            txtMaLoai.DataBindings.Add("Text", gridLoaiTD.DataSource, "MaLoai");
            txtTenLoai.DataBindings.Clear();
            txtTenLoai.DataBindings.Add("Text", gridLoaiTD.DataSource, "TenLoai");
        }
        private void frmLOAITHUCDON_Load(object sender, EventArgs e)
        {
            loadLoaiTD();
            setButton(true);
        }
        private void loadLoaiTD()
        {
            var list = db.LOAITHUCDONs.Select(c => new { c.MaLoai, c.TenLoai, c.TrangThai }).ToList();
            gridLoaiTD.DataSource = list;
            gridView1.Columns[0].Caption = "Mã Loại";
            gridView1.Columns[1].Caption = "Tên Loại";
            gridView1.Columns[2].Caption = "Trạng Thái";

            gridView1.Columns[0].Width = 50;
            gridView1.Columns[1].Width = 120;
            gridView1.Columns[2].Width = 80;
            Class.Functions.TrangThaiTD();
            Class.Functions.TrangThaiLoaiTD();
            bingding();
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
                    LOAITHUCDON l = db.LOAITHUCDONs.Find(txtMaLoai.Text);
                    db.LOAITHUCDONs.Remove(l);
                    db.SaveChanges();
                    loadLoaiTD();
                }
            }
            else
                MessageBox.Show("Bạn phải chọn 1 dòng cần xóa");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            themmoi = false;
            setButton(false);
            txtMaLoai.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text != "" && txtTenLoai.Text != "" && cmbTrangThai.Text != "")
            {
                if (txtMaLoai.Text.Length != 5)
                {
                    MessageBox.Show("Mã Loại Thực Đơn phải là 5 chữ số. VD: LTD01.");
                }
                else
                {
                    if (themmoi == true)
                    {
                        string ma = db.LOAITHUCDONs.Where(m => m.MaLoai == txtMaLoai.Text).Select(m => m.MaLoai).FirstOrDefault();
                        if (ma != null)
                        {
                            MessageBox.Show("Mã Loại Thực Đơn này đã tồn tại!");
                        }
                        else
                        {
                            LOAITHUCDON l = new LOAITHUCDON();
                            l.MaLoai = txtMaLoai.Text;
                            l.TenLoai = txtTenLoai.Text;
                            l.TrangThai = cmbTrangThai.Text;
                            db.LOAITHUCDONs.Add(l);
                            db.SaveChanges();
                            setButton(true);
                            loadLoaiTD();
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
                                LOAITHUCDON l = db.LOAITHUCDONs.Find(txtMaLoai.Text);
                                l.TenLoai = txtTenLoai.Text;
                                l.TrangThai = cmbTrangThai.Text;
                                db.SaveChanges();
                                setButton(true);
                                loadLoaiTD();
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
                MessageBox.Show("Hãy nhập thông tin đầy đủ.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setButton(true);
            loadLoaiTD();
        }

        private void brnReset_Click(object sender, EventArgs e)
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
                    t.TrangThai = "Còn Hàng";
                    db.SaveChanges();
                }
                loadLoaiTD();
            }    
        }
    }
}