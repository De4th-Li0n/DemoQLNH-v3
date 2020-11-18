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
using DEMOQLNH.Report;
using DevExpress.XtraReports.UI;
namespace DEMOQLNH
{
    public partial class frmThongKeHoaDon : DevExpress.XtraEditors.XtraForm
    {
        private QuanLyNhaHangDBContext db = new QuanLyNhaHangDBContext();
        public frmThongKeHoaDon()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (rdbNgay.Checked)
            {
                rdbThang.Enabled = false;
                rdbTuNgay.Enabled = false;
                var list = db.HOADONs.Where(m => m.ThoiGian == dtpNgay.Value).ToList();
                rptDSHoaDon report = new rptDSHoaDon();
                report.DataSource = list;
                report.ShowPreviewDialog();
            }    
            if (rdbThang.Checked)
            {
                rdbNgay.Enabled = false;
                rdbTuNgay.Enabled = false;
                var list = db.HOADONs.Where(m => m.ThoiGian == dtpThang.Value).ToList();
                rptDSHoaDon report = new rptDSHoaDon();
                report.DataSource = list;
                report.ShowPreviewDialog();
            }
            else
            {
                rdbNgay.Enabled = false;
                rdbThang.Enabled = false;
                var Tungay = Convert.ToDateTime(dtpTuNgay.Value);
                var DenNgay = Convert.ToDateTime(dtpDenNgay.Value);

            }    
        }
    }
}