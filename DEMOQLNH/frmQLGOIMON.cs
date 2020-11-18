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
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraExport.Xls;
using DevExpress.Xpo;

namespace DEMOQLNH
{
    public partial class frmQLGOIMON : DevExpress.XtraEditors.XtraForm
    {
        private QuanLyNhaHangDBContext db = new QuanLyNhaHangDBContext();
        public bool themmoi;
        public frmQLGOIMON()
        {
            InitializeComponent();
        }

        void setButton(bool val)
        {
            gridDSGM.Enabled = val;
            btnAdd.Enabled = val;
            btnDel.Enabled = val;
            btnEdit.Enabled = val;
            btnSave.Enabled = !val;
            btnCancel.Enabled = !val;
            cmbLoaiTD.Enabled = !val;
            cmbTenKV.Enabled = !val;
            cmbTenTD.Enabled = !val;
            cmbTenBan.Enabled = !val;
            txtSoLuong.Enabled = !val;
        }
        void setNull()
        {
            cmbTenKV.SelectedIndex = -1;
            cmbLoaiTD.SelectedIndex = -1;
            cmbTenTD.SelectedIndex = -1;
            cmbTenBan.SelectedIndex = -1;
            txtGia.Text = "0";
            txtSoLuong.Text = "0";
        }
        void bingding()
        {
            cmbTenKV.DataBindings.Clear();
            cmbTenKV.DataBindings.Add("Text", gridDSGM.DataSource, "TenKhuVuc");
            cmbTenTD.DataBindings.Clear();
            cmbTenTD.DataBindings.Add("Text", gridDSGM.DataSource, "TenThucDon");
            cmbTenBan.DataBindings.Clear();
            cmbTenBan.DataBindings.Add("Text", gridDSGM.DataSource, "TenBan");
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", gridDSGM.DataSource, "SoLuong");
            txtGia.DataBindings.Clear();
            txtGia.DataBindings.Add("Text", gridDSGM.DataSource, "DonGia");
        }
        private void frmQLGOIMON_Load(object sender, EventArgs e)
        {
            setButton(true);
            loadLoaiTD();
            loadKhuVuc();
            loadGM();
            setNull();
        }
        private void loadGM()
        {
            var list = db.GOIMONs.Select(m => new { m.MaHoaDon, m.HOADON.BAN.TenBan, m.HOADON.BAN.KHUVUC.TenKhuVuc, m.THUCDON.TenThucDon, m.SoLuong, m.THUCDON.DonGia, m.ThanhTien }).ToList();
            gridDSGM.DataSource = list;
            gridView1.Columns[0].Caption = "Số HD";
            gridView1.Columns[1].Caption = "Tên Bàn";
            gridView1.Columns[2].Caption = "Tên Khu Vực";
            gridView1.Columns[3].Caption = "Tên Thực Đơn";
            gridView1.Columns[4].Caption = "Số Lượng";
            gridView1.Columns[5].Caption = "Đơn Giá";
            gridView1.Columns[6].Caption = "Thành Tiền";

            gridView1.Columns[0].Width = 10;
            gridView1.Columns[1].Width = 60;
            gridView1.Columns[2].Width = 60;
            gridView1.Columns[3].Width = 80;
            gridView1.Columns[4].Width = 30;
            gridView1.Columns[5].Width = 40;
            gridView1.Columns[6].Width = 50;

            Class.Functions.TrangThaiBan();
            bingding();
        }
        private void loadKhuVuc()
        {
            var list = db.KHUVUCs.Where(m => m.TrangThai.ToString() == "Hoạt Động").ToList();
            cmbTenKV.DataSource = list;
            cmbTenKV.DisplayMember = "TenKhuVuc";
            cmbTenKV.ValueMember = "MaKhuVuc";
        }
        private void loadLoaiTD()
        {
            var list = db.LOAITHUCDONs.Where(m => m.TrangThai.ToString() == "Còn Hàng").ToList();
            cmbLoaiTD.DataSource = list;
            cmbLoaiTD.DisplayMember = "TenLoai";
            cmbLoaiTD.ValueMember = "MaLoai";
        }
        private void cmbLoaiTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenTD.Items.Count > 0)
            {
                cmbTenTD.Text = "";
            }
            string maloai = db.LOAITHUCDONs.Where(m => m.TenLoai == cmbLoaiTD.Text).Select(m => m.MaLoai).FirstOrDefault();
            var listTD = db.THUCDONs.Where(t => t.MaLoai == maloai && t.TrangThai.ToString() == "Còn Hàng").ToList();
            cmbTenTD.DataSource = listTD;
            cmbTenTD.DisplayMember = "TenThucDon";
            cmbTenTD.ValueMember = "MaThucDon";
        }

        private void cmbTenKV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenBan.Items.Count > 0)
            {
                cmbTenBan.Text = "";
            }
            string makv = db.KHUVUCs.Where(m => m.TenKhuVuc == cmbTenKV.Text).Select(m => m.MaKhuVuc).FirstOrDefault();
            var listBan = db.BANs.Where(t => t.MaKhuVuc == makv && t.TrangThai.ToString() == "Còn Trống" || t.MaKhuVuc == makv && t.TrangThai.ToString() == "Đã Có Khách").ToList();
            cmbTenBan.DataSource = listBan;
            cmbTenBan.DisplayMember = "TenBan";
            cmbTenBan.ValueMember = "MaBan";
        }
        private void cmbTenTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            float? gia = db.THUCDONs.Where(t => t.TenThucDon == cmbTenTD.Text).Select(t => t.DonGia).FirstOrDefault();
            txtGia.Text = gia.ToString();
            string maloai = db.THUCDONs.Where(m => m.TenThucDon == cmbTenTD.Text).Select(m => m.MaLoai).FirstOrDefault();
            cmbLoaiTD.Text = db.LOAITHUCDONs.Where(m => m.MaLoai == maloai).Select(m => m.TenLoai).FirstOrDefault();
        }
        public void btnAdd_Click(object sender, EventArgs e)
        {
            txtGia.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();
            setNull();
            setButton(false);
            themmoi = true;
            cmbLoaiTD.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa  không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string makv = db.KHUVUCs.Where(m => m.TenKhuVuc == cmbTenKV.Text).Select(m => m.MaKhuVuc).First();
                    string maban = db.BANs.Where(m => m.TenBan == cmbTenBan.Text && m.MaKhuVuc == makv).Select(m => m.MaBan).First();
                    string matd = db.THUCDONs.Where(m => m.TenThucDon == cmbTenTD.Text).Select(m => m.MaThucDon).First();
                    int ma = db.GOIMONs.Where(m => m.HOADON.MaBan == maban && m.HOADON.BAN.MaKhuVuc == makv && m.MaThucDon == matd).Select(m => m.MaGoiMon).FirstOrDefault();
                    int sl = db.GOIMONs.Where(m => m.MaGoiMon == ma).Select(m => m.SoLuong).FirstOrDefault().GetValueOrDefault();
                    THUCDON td = db.THUCDONs.Find(matd);
                    td.SoLuongTon = td.SoLuongTon + sl;
                    db.SaveChanges();
                    Class.Functions.checkperSL();
                    GOIMON g = db.GOIMONs.Find(ma);
                    db.GOIMONs.Remove(g);
                    db.SaveChanges();
                    loadGM();
                    setNull();
                    MessageBox.Show("Đã Xóa Thành Công!", "Thông Báo");
                }
            }
            else
                MessageBox.Show("Bạn phải chọn 1 dòng cần xóa");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtGia.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();
            themmoi = false;
            setButton(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            float gia = float.Parse(txtGia.Text);
            int sl = Convert.ToInt32(txtSoLuong.Text);
            if (SoLuong(sl))
            {
                MessageBox.Show("Không đủ số lượng tồn của thực đơn!\nHãy kiểm tra lại số lượng tồn.", "Thông Báo");
            }
            else
            {
                //////string v = string.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"));
                if (cmbLoaiTD.Text != "" && cmbTenBan.Text != "" && cmbTenKV.Text != "" && cmbTenTD.Text != "" && sl > 0)
                {
                    string maban = cmbTenBan.SelectedValue.ToString();
                    string makv = cmbTenKV.SelectedValue.ToString();
                    string manv = db.TAIKHOANs.Where(m => m.TenTaiKhoan == FrmLogin.ID_USER).Select(m => m.MaNhanVien).First();
                    if (themmoi)
                    {
                        if (Class.Functions.HoaDonGoimon(cmbTenBan.Text,cmbTenKV.Text))
                        {
                            int hd = db.GOIMONs.Where(m => m.HOADON.MaBan == maban && m.HOADON.BAN.MaKhuVuc == makv).Select(m => m.MaHoaDon).FirstOrDefault();
                            GOIMON g = new GOIMON();
                            g.MaHoaDon = hd;
                            g.MaThucDon = cmbTenTD.SelectedValue.ToString();
                            g.SoLuong = sl;
                            g.ThanhTien = sl * gia;
                            db.GOIMONs.Add(g);
                            db.SaveChanges();
                            MessageBox.Show("Đã Thêm Thành Công!", "Thông Báo");
                            setButton(true);
                            loadGM();
                        }
                        else
                        {
                            HOADON h = new HOADON();
                            h.MaBan = maban;
                            h.MaNhanVien = manv;
                            db.HOADONs.Add(h);
                            db.SaveChanges();
                            GOIMON g = new GOIMON();
                            g.MaHoaDon = h.MaHoaDon;
                            g.MaThucDon = cmbTenTD.SelectedValue.ToString();
                            g.SoLuong = sl;
                            //g.ThoiGian = DateTime.Now;
                            g.ThanhTien = sl * gia;
                            db.GOIMONs.Add(g);
                            db.SaveChanges();
                            MessageBox.Show("Đã Thêm Thành Công!", "Thông Báo");
                            setButton(true);
                            loadGM();
                        }    
                    }
                    else
                    {
                        if (gridView1.FocusedRowHandle >= 0)
                        {
                            DialogResult dr = MessageBox.Show("Bạn có chắc muốn sửa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                int h = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaHoaDon").ToString());
                                string t = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenThucDon").ToString();
                                string matd = db.THUCDONs.Where(m => m.TenThucDon == t).Select(m => m.MaThucDon).FirstOrDefault();
                                int ma = db.GOIMONs.Where(m => m.MaHoaDon == h && m.MaThucDon == matd).Select(m => m.MaGoiMon).FirstOrDefault();
                                GOIMON g = db.GOIMONs.Find(ma);
                                g.MaThucDon = cmbTenTD.SelectedValue.ToString();
                                g.SoLuong = sl;
                                g.ThanhTien = sl * gia;
                                db.SaveChanges();
                                setButton(true);
                                loadGM();
                                MessageBox.Show("Đã Sửa Thành Công!", "Thông Báo");
                            }
                        }
                        else
                            MessageBox.Show("Bạn phải chọn 1 dòng cần sửa");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy nhập đầy đủ thông tin!");
                }
            }  
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setButton(true);
            loadGM();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string maloai = db.THUCDONs.Where(m => m.TenThucDon == cmbTenTD.Text).Select(m => m.MaLoai).FirstOrDefault();
            cmbLoaiTD.Text = db.LOAITHUCDONs.Where(m => m.MaLoai == maloai).Select(m => m.TenLoai).FirstOrDefault();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool SoLuong(int sl)
        {
            bool check = false;
            THUCDON td = db.THUCDONs.Find(cmbTenTD.SelectedValue.ToString());
            int s = td.SoLuongTon.GetValueOrDefault() - sl;
            if (s < 0)
            {
                check = true;
            }
            else
            {
                td.SoLuongTon = td.SoLuongTon - sl;
                db.SaveChanges();
                Class.Functions.checkperSL();
            }
            return check;
        }
    }
}