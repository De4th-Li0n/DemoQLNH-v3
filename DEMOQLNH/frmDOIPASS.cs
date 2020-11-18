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
    public partial class frmDOIPASS : DevExpress.XtraEditors.XtraForm
    {
        private QuanLyNhaHangDBContext db = new QuanLyNhaHangDBContext();
        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-TT294U1;Initial Catalog=QLNhaHang;Integrated Security=True");
        public frmDOIPASS()
        {
            InitializeComponent();
        }

        private void frmDOIPASS_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Class.Functions.getID(txtUser.Text,txtPasscu.Text) != "")
            {
                if(txtPassmoi.Text != txtNhaplai.Text)
                {
                    MessageBox.Show("Nhập lại không đúng!");
                }
                else
                {
                    TAIKHOAN tk = new TAIKHOAN();
                    tk = db.TAIKHOANs.Find(txtUser.Text);
                    tk.MatKhau = txtPassmoi.Text;
                    db.SaveChanges();
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    frmMain f = new frmMain();
                    f.Show();
                    //try
                    //{
                    //    con.Open();
                    //    SqlCommand cmd = new SqlCommand("UPDATE TAIKHOAN SET MatKhau = '" + txtNhaplai.Text + "' WHERE TenTaiKhoan = '" + txtUser.Text + "'", con);
                    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //    DataTable dt = new DataTable();
                    //    da.Fill(dt);
                    //    frmMain f = new frmMain();
                    //    f.Show();
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
                    //}
                    //finally
                    //{
                    //    con.Close();
                    //}
                }
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu cũ không đúng !");
            }
        }

        private void frmDOIPASS_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain f = new frmMain();
            f.Show();
        }
    }
}