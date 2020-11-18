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
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DEMOQLNH.Models;
using DEMOQLNH.Report;
using DevExpress.XtraReports.UI;

namespace DEMOQLNH
{
    public partial class frmTHANHTOAN : DevExpress.XtraEditors.XtraForm
    {
        private QuanLyNhaHangDBContext db = new QuanLyNhaHangDBContext();
        public frmTHANHTOAN()
        {
            InitializeComponent();
            galleryControl.Gallery.ItemClick += new GalleryItemClickEventHandler(galleryControl1_Gallery_ItemClick);
        }
        private void THANHTOAN_Load(object sender, EventArgs e)
        {
            loadFrom();
        }

        private void loadFrom()
        {
            txtTongTien.Text = String.Format( 0 + " VNĐ");
            var list = db.BANs.Where(m => m.KHUVUC.TrangThai == "Hoạt Động").Select(m => new { m.MaBan, m.TenBan, m.KHUVUC.TenKhuVuc, m.MoTa }).ToList();
            gridDSBan.DataSource = list;
            gridDSBan.Show();
            gridDSBan2.Hide();
            loadBanTrong();
            var ban = db.BANs.ToList();
            loadAllImage(ban);
        }
        private void loadAllImage(List<BAN> ban)
        {
            galleryControl.Gallery.Groups.Clear();
            var kv = db.KHUVUCs.Where(m => m.TrangThai == "Hoạt Động").Select(m => m.TenKhuVuc).ToList();
            //var ban = db.BANs.ToList();

            galleryControl.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            galleryControl.Gallery.ImageSize = new Size(60, 60);
            galleryControl.Gallery.ShowItemText = true;
            galleryControl.Gallery.ShowGroupCaption = true;

            foreach (string group in kv)
            {
                var galleryItem = new GalleryItemGroup();
                galleryItem.Caption = group;
                galleryItem.CaptionAlignment = GalleryItemGroupCaptionAlignment.Stretch;
                string makv = db.KHUVUCs.Where(m => m.TenKhuVuc == group).Select(m => m.MaKhuVuc).FirstOrDefault();
                foreach (var item in ban)
                {
                    if (makv.Equals(item.MaKhuVuc.ToString()))
                    {
                        var gc_item = new GalleryItem();
                        gc_item.AppearanceCaption.Normal.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        gc_item.AppearanceCaption.Hovered.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        gc_item.AppearanceCaption.Pressed.Font = new Font("Tahoma", 10, FontStyle.Bold);

                        if (item.TrangThai.ToString() == "Đã Có Khách")
                        {
                            gc_item.ImageOptions.Image = imageList1.Images[1];
                        }
                        else
                        {
                            gc_item.ImageOptions.Image = imageList1.Images[0];
                        }
                        gc_item.Caption = item.TenBan.ToString();
                        gc_item.Value = item.MaBan.ToString();

                        galleryItem.Items.Add(gc_item);
                    }
                }
                galleryControl.Gallery.Groups.Add(galleryItem);
            }
        }

        private void loadBanTrong()
        {
            gridView1.Columns[0].Caption = "Mã Bàn";
            gridView1.Columns[1].Caption = "Tên Bàn";
            gridView1.Columns[2].Caption = "Tên Khu Vực";
            gridView1.Columns[3].Caption = "Mô Tả";

            gridView1.Columns[0].Width = 50;
            gridView1.Columns[1].Width = 100;
            gridView1.Columns[2].Width = 100;
            gridView1.Columns[3].Width = 150;
        }
        private void loadBanCoKhach()
        {
            gridView2.Columns[0].Caption = "Số HD";
            gridView2.Columns[1].Caption = "Tên Bàn";
            gridView2.Columns[2].Caption = "Tên Khu Vực";
            gridView2.Columns[3].Caption = "Tên Thực Đơn";
            gridView2.Columns[4].Caption = "Số Lượng";
            gridView2.Columns[5].Caption = "Đơn Giá";
            gridView2.Columns[6].Caption = "Thành Tiền";

            gridView2.Columns[0].Width = 10;
            gridView2.Columns[1].Width = 60;
            gridView2.Columns[2].Width = 60;
            gridView2.Columns[3].Width = 80;
            gridView2.Columns[4].Width = 30;
            gridView2.Columns[5].Width = 40;
            gridView2.Columns[6].Width = 50;

            gridView2.Columns[5].DisplayFormat.FormatString = DateTime.Now.ToString("dd/MM/yyyy") + DateTime.Now.ToString("hh:mm:ss tt");
        }
        private void galleryControl1_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            
            var gc_item = new GalleryItem();
            string id = e.Item.Value.ToString();
            string t = db.BANs.Where(m => m.MaBan == id).Select(m => m.TrangThai).FirstOrDefault();
            if (t == "Còn Trống")
            {
                var list = db.BANs.Where(m => m.MaBan == id).Select(m => new { m.MaBan, m.TenBan, m.KHUVUC.TenKhuVuc, m.MoTa }).ToList();
                gridDSBan.DataSource = list;
                gridDSBan.Show();
                gridDSBan2.Hide();
                loadBanTrong();
            }
            else
            {
                var list = db.GOIMONs.Where(m => m.HOADON.MaBan == id).Select(m => new { m.MaHoaDon, m.HOADON.BAN.TenBan, m.HOADON.BAN.KHUVUC.TenKhuVuc, m.THUCDON.TenThucDon, m.SoLuong, m.THUCDON.DonGia, m.ThanhTien }).ToList();
                gridDSBan2.DataSource = list;
                gridDSBan2.Show();
                gridDSBan.Hide();
                loadBanCoKhach();
            }
            //bool is_status = Convert.ToBoolean(int.Parse(t));
            //string status = (is_status) ? "0" : "1";
            //BAN b = db.BANs.Find(id);
            //b.TrangThai = status;
            //gc_item.ImageOptions.Image = (is_status) ? imageList1.Images[0] : imageList1.Images[1];

            //gc_item.Caption = e.Item.Caption;
            //gc_item.Value = e.Item.Value;
            //e.Item.Assign(gc_item);

        }
        GalleryItem item = null;
        private void popupMenu1_CloseUp(object sender, EventArgs e)
        {
            item = null;
        }

        private void btnThanhToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            float TongTien = 0;
            string id = item.Value.ToString();
            string tenban = db.BANs.Where(m => m.MaBan == id).Select(m => m.TenBan).FirstOrDefault();
            DialogResult dr = MessageBox.Show("BẠN CÓ MUỐN TÍNH TIỀN [ " + tenban +" ] ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                var list = db.GOIMONs.Where(m => m.HOADON.MaBan == id).ToList();
                foreach (float tien in list.Select(m => m.ThanhTien))
                    TongTien = TongTien + tien;
                MessageBox.Show("TỔNG SỐ TIỀN CẦN THANH TOÁN CỦA [ " + tenban + " ] LÀ " + String.Format("{0:#,###}", TongTien) + " VNĐ");
                int mahd = db.GOIMONs.Where(m => m.HOADON.MaBan == id).Select(m => m.MaHoaDon).FirstOrDefault();
                HOADON h = db.HOADONs.Find(mahd);
                h.ThoiGian = DateTime.Now;
                h.TongTien = TongTien;
                db.SaveChanges();
                loadFrom();
            }
        }

        private void galleryControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            Point point = galleryControl.PointToClient(Control.MousePosition);
            RibbonHitInfo hitInfo = galleryControl.CalcHitInfo(point);
            if (hitInfo.InGalleryItem || hitInfo.HitTest == RibbonHitTest.GalleryImage)
            {
                item = hitInfo.GalleryItem;
                var list = db.GOIMONs.Where(m => m.HOADON.MaBan == item.Value.ToString()).ToList();
                if (list.Count > 0)
                {
                    popupMenu1.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                    btnTinhTien.Enabled = true;
                    btnInHoaDon.Enabled = true;
                }    
                else
                {
                    popupMenu3.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                    btnTinhTien.Enabled = false;
                    btnInHoaDon.Enabled = false;
                }    
            }
            else
            {
                popupMenu1.HidePopup();
                popupMenu2.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
            }    
        }

        private void btnBanTrong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var list = db.BANs.Where(m => m.TrangThai == "Còn Trống" && m.KHUVUC.TrangThai == "Hoạt Động").Select(m => new { m.MaBan, m.TenBan, m.KHUVUC.TenKhuVuc, m.MoTa }).ToList();
            gridDSBan.DataSource = list;
            gridDSBan.Show();
            gridDSBan2.Hide();
            loadBanTrong();
            var ban = db.BANs.Where(m => m.TrangThai == "Còn Trống").ToList();
            loadAllImage(ban);
        }

        private void btnBanCoKhach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var list = db.GOIMONs.Select(m => new { m.MaHoaDon, m.HOADON.BAN.TenBan, m.HOADON.BAN.KHUVUC.TenKhuVuc, m.THUCDON.TenThucDon, m.SoLuong, m.THUCDON.DonGia, m.ThanhTien }).ToList();
            gridDSBan2.DataSource = list;
            gridDSBan2.Show();
            gridDSBan.Hide();
            loadBanCoKhach();
            var ban = db.BANs.Where(m => m.TrangThai == "Đã Có Khách").ToList();
            loadAllImage(ban);
        }

        private void btnLoadBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadFrom();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle >= 0)
            {
                string b = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "TenBan").ToString();
                DialogResult dr = MessageBox.Show("BẠN CÓ MUỐN TÍNH TIỀN [ " + b + " ] ?", "Thông Báo", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    float TongTien = 0;
                    string k = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "TenKhuVuc").ToString();
                    string makv = db.KHUVUCs.Where(m => m.TenKhuVuc == k).Select(m => m.MaKhuVuc).FirstOrDefault();
                    string maban = db.BANs.Where(m => m.TenBan == b && m.MaKhuVuc == makv).Select(m => m.MaBan).FirstOrDefault();
                    var list = db.GOIMONs.Where(m => m.HOADON.MaBan == maban).ToList();
                    foreach (float tien in list.Select(m => m.ThanhTien))
                        TongTien = TongTien + tien;
                    MessageBox.Show("TỔNG SỐ TIỀN CẦN THANH TOÁN CỦA [ " + b + " ] LÀ " + String.Format("{0:#,###}", TongTien) + " VNĐ");
                    int mahd = db.GOIMONs.Where(m => m.HOADON.MaBan == maban).Select(m => m.MaHoaDon).FirstOrDefault();
                    HOADON h = db.HOADONs.Find(mahd);
                    h.ThoiGian = DateTime.Now;
                    h.TongTien = TongTien;
                    db.SaveChanges();
                    loadFrom();

                    //gridView1.Columns[5].DisplayFormat.FormatString = DateTime.Now.ToString("dd/MM/yyyy") + DateTime.Now.ToString("hh:mm:ss tt");
                }
            }
            else
                MessageBox.Show("Bạn phải chọn 1 dòng cần sửa");
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            double? tong = 0;
            string b = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "TenBan").ToString();
            string k = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "TenKhuVuc").ToString();
            string td = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "TenThucDon").ToString();
            string makv = db.KHUVUCs.Where(m => m.TenKhuVuc == k).Select(m => m.MaKhuVuc).FirstOrDefault();
            string maban = db.BANs.Where(m => m.TenBan == b && m.MaKhuVuc == makv).Select(m => m.MaBan).FirstOrDefault();
            string matd = db.THUCDONs.Where(m => m.TenThucDon == td).Select(m => m.TenThucDon).FirstOrDefault();
            int magm = db.GOIMONs.Where(m => m.HOADON.MaBan == maban && m.HOADON.BAN.KHUVUC.MaKhuVuc == makv && m.MaThucDon == matd).Select(m => m.MaGoiMon).FirstOrDefault();
            int mahd = db.GOIMONs.Where(m => m.MaGoiMon == magm).Select(m => m.MaHoaDon).FirstOrDefault();
            tong = db.HOADONs.Where(m => m.MaHoaDon == mahd).Select(m => m.TongTien).FirstOrDefault();
            if (tong == 0)
            {
                MessageBox.Show("Hãy thanh toán tiền trước!");
            }
            else
            {
                var gm = db.GOIMONs.Where(m => m.MaHoaDon == mahd).Select(m => new {
                    m.MaHoaDon,
                    m.SoLuong,
                    m.ThanhTien,
                    m.THUCDON.TenThucDon,
                    m.HOADON.MaBan,
                    m.HOADON.MaNhanVien,
                    m.HOADON.ThoiGian,
                    m.HOADON.TongTien,
                    m.THUCDON.DonGia,
                    m.THUCDON.DonViTinh
                }).ToList();
                rptInHoaDon report = new rptInHoaDon();
                report.DataSource = gm;
                report.ShowPreviewDialog();
                var list = db.GOIMONs.Where(m => m.HOADON.MaBan == maban).ToList();
                foreach (int magoimon in list.Select(m => m.MaGoiMon))
                {
                    GOIMON g = db.GOIMONs.Find(magoimon);
                    db.GOIMONs.Remove(g);
                    db.SaveChanges();
                }
            }
        }
        private bool ExistFrom(XtraForm form)
        {
            foreach (var child in frmMain.ActiveForm.MdiChildren)
                if (child.Name == form.Name)
                {
                    child.Activate();
                    return true;
                }
            return false;
        }
        private void btnGoiMon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmQLGOIMON f = new frmQLGOIMON();
            if (ExistFrom(f)) return;
            f.MdiParent = frmMain.ActiveForm;
            WindowState = FormWindowState.Maximized;
            f.Show();
            f.btnAdd_Click(sender,e);
        }

        private void galleryControl_Click(object sender, EventArgs e)
        {
            Point point = galleryControl.PointToClient(Control.MousePosition);
            RibbonHitInfo hitInfo = galleryControl.CalcHitInfo(point);
            if (hitInfo.InGalleryItem || hitInfo.HitTest == RibbonHitTest.GalleryImage)
            {
                item = hitInfo.GalleryItem;
                var list = db.GOIMONs.Where(m => m.HOADON.MaBan == item.Value.ToString()).ToList();
                if (list.Count > 0)
                {
                    btnTinhTien.Enabled = true;
                    btnInHoaDon.Enabled = true;
                }
                else
                {
                    btnTinhTien.Enabled = false;
                    btnInHoaDon.Enabled = false;
                }
                float TongTien = 0;
                string id = item.Value.ToString();
                var list_ = db.GOIMONs.Where(m => m.HOADON.MaBan == id).ToList();
                foreach (float tien in list_.Select(m => m.ThanhTien))
                    TongTien = TongTien + tien;
                if (TongTien == 0)
                {
                    txtTongTien.Text = String.Format("{0} VNĐ", TongTien);
                }
                else
                {
                    txtTongTien.Text = String.Format("{0:#,###} VNĐ", TongTien);
                }
            }
        }
    }
}