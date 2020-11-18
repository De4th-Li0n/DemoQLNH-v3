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
    public partial class frmQLKV : DevExpress.XtraEditors.XtraForm
    {
        private QuanLyNhaHangDBContext db = new QuanLyNhaHangDBContext();
        public bool themmoi = false;
        public frmQLKV()
        {
            InitializeComponent();
        }
        void setButton(bool val)
        {
            gridDSKV.Enabled = val;
            btnAdd.Enabled = val;
            btnDel.Enabled = val;
            btnEdit.Enabled = val;
            btnSave.Enabled = !val;
            btnCancel.Enabled = !val;
            txtMaKV.Enabled = !val;
            txtTenKV.Enabled = !val;
            cmbTrangThai.Enabled = !val;
            txtMoTa.Enabled = !val;
        }
        void setNull()
        {
            txtMaKV.Text = "";
            txtTenKV.Text = "";
            txtMoTa.Text = "";
            cmbTrangThai.SelectedIndex = -1;
        }
        void bingding()
        {
            cmbTrangThai.DataBindings.Clear();
            cmbTrangThai.DataBindings.Add("Text", gridDSKV.DataSource, "TrangThai");
            txtMaKV.DataBindings.Clear();
            txtMaKV.DataBindings.Add("Text", gridDSKV.DataSource, "MaKhuVuc");
            txtTenKV.DataBindings.Clear();
            txtTenKV.DataBindings.Add("Text", gridDSKV.DataSource, "TenKhuVuc");
            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", gridDSKV.DataSource, "MoTa");
        }
        private void QLKV_Load(object sender, EventArgs e)
        {
            loadKhuVuc();
            setButton(true);
        }
        private void loadKhuVuc()
        {
            var list = db.KHUVUCs.Select(c => new { c.MaKhuVuc, c.TenKhuVuc, c.MoTa, c.TrangThai }).ToList();
            gridDSKV.DataSource = list;
            gridView1.Columns[0].Caption = "Mã Khu Vực";
            gridView1.Columns[1].Caption = "Tên Khu Vực";
            gridView1.Columns[2].Caption = "Mô Tả";
            gridView1.Columns[3].Caption = "Trạng Thái";

            gridView1.Columns[0].Width = 50;
            gridView1.Columns[1].Width = 100;
            gridView1.Columns[2].Width = 150;
            gridView1.Columns[3].Width = 80;
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
                    KHUVUC kv = db.KHUVUCs.Find(txtMaKV.Text);
                    db.KHUVUCs.Remove(kv);
                    db.SaveChanges();
                    loadKhuVuc();
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
            txtMaKV.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMaKV.Text != "" && txtTenKV.Text != "" && cmbTrangThai.Text != "")
            {
                if (txtMaKV.Text.Length != 5)
                {
                    MessageBox.Show("Mã Khu Vực phải là 5 chữ số. VD: KV001.");
                }
                else
                {
                    if (themmoi == true)
                    {
                        string k = db.KHUVUCs.Where(m => m.MaKhuVuc == txtMaKV.Text).Select(m => m.MaKhuVuc).FirstOrDefault();
                        if (k != null)
                        {
                            MessageBox.Show("Mã khu vực này đã tồn tại!");
                        }
                        else
                        {
                            KHUVUC kv = new KHUVUC();
                            kv.MaKhuVuc = txtMaKV.Text;
                            kv.TenKhuVuc = txtTenKV.Text;
                            kv.MoTa = txtMoTa.Text;
                            kv.TrangThai = cmbTrangThai.Text;
                            db.KHUVUCs.Add(kv);
                            db.SaveChanges();
                            setButton(true);
                            loadKhuVuc();
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
                                KHUVUC kv = db.KHUVUCs.Find(txtMaKV.Text);
                                kv.TenKhuVuc = txtTenKV.Text;
                                kv.MoTa = txtMoTa.Text;
                                kv.TrangThai = cmbTrangThai.Text;
                                db.SaveChanges();
                                setButton(true);
                                loadKhuVuc();
                                MessageBox.Show("Đã Sửa Thành Công!", "Thông Báo");
                            }
                        }
                        else
                            MessageBox.Show("Bạn phải chọn 1 dòng cần sửa");
                    }
                }
            }
            else
                MessageBox.Show("Hãy nhập thông tin đầy đủ.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setButton(true);
            loadKhuVuc();
        }
    }
}