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
    public partial class frmQLBAN : DevExpress.XtraEditors.XtraForm
    {
        private QuanLyNhaHangDBContext db = new QuanLyNhaHangDBContext();
        public bool themmoi = false;
        public frmQLBAN()
        {
            InitializeComponent();
        }
        void setButton(bool val)
        {
            gridBan.Enabled = val;
            btnAdd.Enabled = val;
            btnDel.Enabled = val;
            btnEdit.Enabled = val;
            btnSave.Enabled = !val;
            btnCancel.Enabled = !val;
            txtMaBan.Enabled = !val;
            txtTenBan.Enabled = !val;
            cmbTrangThai.Enabled = !val;
            cmbTenKV.Enabled = !val;
            txtMoTa.Enabled = !val;
        }
        void setNull()
        {
            txtMaBan.Text = "";
            txtTenBan.Text = "";
            txtMoTa.Text = "";
            cmbTrangThai.SelectedIndex = -1;
            cmbTenKV.SelectedIndex = -1;
        }
        void bingding()
        {
            cmbTenKV.DataBindings.Clear();
            cmbTenKV.DataBindings.Add("Text", gridBan.DataSource, "TenKhuVuc");
            cmbTrangThai.DataBindings.Clear();
            cmbTrangThai.DataBindings.Add("Text", gridBan.DataSource, "TrangThai");
            txtMaBan.DataBindings.Clear();
            txtMaBan.DataBindings.Add("Text", gridBan.DataSource, "MaBan");
            txtTenBan.DataBindings.Clear();
            txtTenBan.DataBindings.Add("Text", gridBan.DataSource, "TenBan");
            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", gridBan.DataSource, "MoTa");
        }
        private void QLBAN_Load(object sender, EventArgs e)
        {
            loadBan();
            loadKV();
            setButton(true);
        }
        private void loadBan()
        {
            var list = db.BANs.Select(m => new { m.MaBan, m.TenBan, m.KHUVUC.TenKhuVuc, m.MoTa, m.TrangThai }).ToList();
            gridBan.DataSource = list;
            gridView1.Columns[0].Caption = "Mã Bàn";
            gridView1.Columns[1].Caption = "Tên Bàn";
            gridView1.Columns[2].Caption = "Tên Khu Vực";
            gridView1.Columns[3].Caption = "Mô Tả";
            gridView1.Columns[4].Caption = "Trạng Thái";

            gridView1.Columns[0].Width = 50;
            gridView1.Columns[1].Width = 100;
            gridView1.Columns[2].Width = 100;
            gridView1.Columns[3].Width = 150;
            gridView1.Columns[4].Width = 80;
            bingding();
        }
        private void loadKV()
        {
            var list = db.KHUVUCs.ToList();
            cmbTenKV.DataSource = list;
            cmbTenKV.DisplayMember = "TenKhuVuc";
            cmbTenKV.ValueMember = "MaKhuVuc";
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
                    BAN b = db.BANs.Find(txtMaBan.Text);
                    db.BANs.Remove(b);
                    db.SaveChanges();
                    loadBan();
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
            txtMaBan.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string makv = cmbTenKV.SelectedValue.ToString();
            if (txtMaBan.Text != "" && txtTenBan.Text != "" && cmbTenKV.Text != "" && cmbTrangThai.Text != "")
            {
                if (txtMaBan.Text.Length != 5)
                {
                    MessageBox.Show("Mã Bàn phải là 5 chữ số. VD: B0001.");
                }
                else
                {
                    List<BAN> ban = new List<BAN>();
                    if (themmoi == true)
                    {
                        ban = db.BANs.Where(m => m.TenBan == txtTenBan.Text && m.MaKhuVuc == makv).ToList();
                        if (ban != null)
                        {
                            MessageBox.Show("Tên Bàn này đã tồn tại trong Khu Vực này!");
                        }
                        else
                        {
                            ban = db.BANs.Where(m => m.MaBan == txtMaBan.Text).ToList();
                            if (ban != null)
                            {
                                MessageBox.Show("Mã Bàn này đã tồn tại!");
                            }
                            else
                            {
                                BAN b = new BAN();
                                b.MaBan = txtMaBan.Text;
                                b.TenBan = txtTenBan.Text;
                                b.MoTa = txtMoTa.Text;
                                b.TrangThai = cmbTrangThai.Text;
                                b.MaKhuVuc = makv;
                                db.BANs.Add(b);
                                db.SaveChanges();
                                setNull();
                                setButton(true);
                                loadBan();
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
                                BAN b = db.BANs.Find(txtMaBan.Text);
                                b.TenBan = txtTenBan.Text;
                                b.MoTa = txtMoTa.Text;
                                b.TrangThai = cmbTrangThai.Text;
                                b.MaKhuVuc = makv;
                                db.SaveChanges();
                                setNull();
                                setButton(true);
                                loadBan();
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
            loadBan();
        }
    }
}