using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEMOQLNH.Models;

namespace DEMOQLNH.Class
{
    class Functions
    {
        public static QuanLyNhaHangDBContext qlnh = new QuanLyNhaHangDBContext();
        public static string getID(string username, string pass)
        {
            string id = "";
            List<TAIKHOAN> tk = new List<TAIKHOAN>();
            tk = Functions.qlnh.TAIKHOANs.Where(m => m.TenTaiKhoan == username && m.MatKhau == pass).ToList();
            if (tk != null)
                id = username;  
            return id;
        }
        public static List<string> list_MaQuyen(string TaiKhoan)
        {
            List<string> List_MQ = new List<string>();
            List<TAIKHOAN_NHOMQUYEN> list = Functions.qlnh.TAIKHOAN_NHOMQUYEN.Where(m => m.TenTaiKhoan == TaiKhoan).ToList();
            foreach (string ma in list.Select(m => m.MaQuyen))
            {
                List_MQ.Add(ma);
            }    
            return List_MQ;
        }
        public static void TrangThaiBan()
        {
            List<string> list_gm = new List<string>();
            List<GOIMON> list = Functions.qlnh.GOIMONs.ToList();
            foreach (string t in list.Select(m => m.HOADON.MaBan))
            {
                list_gm.Add(t);
                BAN b = Functions.qlnh.BANs.Find(t);
                b.TrangThai = "Đã Có Khách";
                Functions.qlnh.SaveChanges();
            }
            List<string> listdsban = Functions.qlnh.BANs.Select(m => m.MaBan).ToList();
            IEnumerable<string> list_ko = listdsban.Except(list_gm);
            foreach (string c in list_ko)
            {
                BAN bt = Functions.qlnh.BANs.Find(c);
                bt.TrangThai = "Còn Trống";
                Functions.qlnh.SaveChanges();
            }
        }
        public static void TrangThaiTD()
        {
            List<LOAITHUCDON> list = Functions.qlnh.LOAITHUCDONs.ToList();
            List<THUCDON> listtd = Functions.qlnh.THUCDONs.ToList();
            foreach (string c in list.Where(m => m.TrangThai.ToString() == "Hết Hàng").Select(m => m.MaLoai))
            {
                foreach (string t in listtd.Where(m => m.MaLoai == c).Select(m => m.MaThucDon))
                {
                    THUCDON l = Functions.qlnh.THUCDONs.Find(t);
                    l.TrangThai = "Hết Hàng";
                    l.SoLuongTon = 0;
                    Functions.qlnh.SaveChanges();
                }    
            }
        }
        public static void checkperSL()
        {
            List<THUCDON> listtd = Functions.qlnh.THUCDONs.Where(m => m.SoLuongTon == 0).ToList();
            foreach (string item in listtd.Select(m => m.MaThucDon))
            {
                    THUCDON l = Functions.qlnh.THUCDONs.Find(item);
                    l.TrangThai = "Hết Hàng";
                    Functions.qlnh.SaveChanges();
            }
            List<THUCDON> list = Functions.qlnh.THUCDONs.Where(m => m.SoLuongTon > 0).ToList();
            foreach (string item in listtd.Select(m => m.MaThucDon))
            {    
                THUCDON l = Functions.qlnh.THUCDONs.Find(item);
                l.TrangThai = "Còn Hàng";
                Functions.qlnh.SaveChanges();
            }
        }

        public static Boolean checkper(string code)
        {
            List<THUCDON> listtd = Functions.qlnh.THUCDONs.ToList();
            Boolean check = false;
            foreach (string item in listtd.Where(m => m.MaLoai == code).Select(m => m.MaThucDon))
            {
                string tt = Functions.qlnh.THUCDONs.Where(m => m.MaThucDon == item).Select(m => m.TrangThai).FirstOrDefault();
                if (tt == "Còn Hàng") return check = true;
            }
            return check;
        }
        public static void TrangThaiLoaiTD()
        {
            List<LOAITHUCDON> list = Functions.qlnh.LOAITHUCDONs.ToList();
            foreach (string l in list.Select(m => m.MaLoai))
            {
                if (Functions.checkper(l))
                {
                    LOAITHUCDON ltd = Functions.qlnh.LOAITHUCDONs.Find(l);
                    ltd.TrangThai = "Còn Hàng";
                    Functions.qlnh.SaveChanges();
                }    
                else
                {
                    LOAITHUCDON ltd = Functions.qlnh.LOAITHUCDONs.Find(l);
                    ltd.TrangThai = "Hết Hàng";
                    Functions.qlnh.SaveChanges();
                }    
            }    
        }
        //public static int MaHD(string ban, string khuvuc)
        //{
        //    int ma = 0;
        //    List<HOADON> list_hd = Functions.qlnh.HOADONs.Where(m => m.BAN.TenBan == ban && m.BAN.KHUVUC.TenKhuVuc == khuvuc).ToList();
        //    int mahd = Functions.qlnh.GOIMONs.Where(m => m.HOADON.BAN.TenBan == ban && m.HOADON.BAN.KHUVUC.TenKhuVuc == khuvuc).Select(m => m.MaHoaDon).FirstOrDefault();
        //    foreach (int mahd in list_hd.Select(m => m.MaHoaDon))
        //    {
        //        int gm = Functions.qlnh.GOIMONs.Where(m => m.MaHoaDon == mahd).Select(m => m.MaGoiMon).FirstOrDefault();
        //        if (gm != 0)
        //        {
        //        }
        //    }
        //    return ma;
        //}
        public static Boolean HoaDonGoimon(string ban, string khuvuc)
        {
            Boolean check = false;
            int gm = 0;
            List<HOADON> list_hd = Functions.qlnh.HOADONs.Where(m => m.BAN.TenBan == ban && m.BAN.KHUVUC.TenKhuVuc == khuvuc).ToList();
            foreach (int mahd in list_hd.Select(m => m.MaHoaDon))
            {
                gm = Functions.qlnh.GOIMONs.Where(m => m.MaHoaDon == mahd).Select(m => m.MaGoiMon).FirstOrDefault();
                if (gm != 0)
                {
                    check = true;
                    return check;
                }    
            }
            return check;
        }
    }
}
