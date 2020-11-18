namespace DEMOQLNH
{
    partial class frmTAIKHOAN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridDSTK = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcQLNV = new DevExpress.XtraEditors.GroupControl();
            this.cmbMaNV = new System.Windows.Forms.ComboBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTenTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grcQuyen = new DevExpress.XtraEditors.GroupControl();
            this.chkGoiMon = new DevExpress.XtraEditors.CheckEdit();
            this.chkThucDon = new DevExpress.XtraEditors.CheckEdit();
            this.chkKhuVuc = new DevExpress.XtraEditors.CheckEdit();
            this.chkDoanhThu = new DevExpress.XtraEditors.CheckEdit();
            this.chkQuanLy = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcQLNV)).BeginInit();
            this.grcQLNV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcQuyen)).BeginInit();
            this.grcQuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkGoiMon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThucDon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKhuVuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDoanhThu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuanLy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.Image = global::DEMOQLNH.Properties.Resources.Huy;
            this.btnCancel.Location = new System.Drawing.Point(717, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 52);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = global::DEMOQLNH.Properties.Resources.Luu;
            this.btnSave.Location = new System.Drawing.Point(591, 137);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 52);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.ImageOptions.Image = global::DEMOQLNH.Properties.Resources.Sua;
            this.btnEdit.Location = new System.Drawing.Point(465, 137);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 52);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDel.Appearance.Options.UseFont = true;
            this.btnDel.ImageOptions.Image = global::DEMOQLNH.Properties.Resources.Xoa;
            this.btnDel.Location = new System.Drawing.Point(339, 137);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(120, 52);
            this.btnDel.TabIndex = 10;
            this.btnDel.Text = "Xóa";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = global::DEMOQLNH.Properties.Resources.Them;
            this.btnAdd.Location = new System.Drawing.Point(213, 137);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 52);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridDSTK
            // 
            this.gridDSTK.Location = new System.Drawing.Point(12, 232);
            this.gridDSTK.MainView = this.gridView1;
            this.gridDSTK.Name = "gridDSTK";
            this.gridDSTK.Size = new System.Drawing.Size(1055, 311);
            this.gridDSTK.TabIndex = 8;
            this.gridDSTK.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridDSTK;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // grcQLNV
            // 
            this.grcQLNV.AppearanceCaption.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grcQLNV.AppearanceCaption.Options.UseFont = true;
            this.grcQLNV.Controls.Add(this.cmbMaNV);
            this.grcQLNV.Controls.Add(this.txtTenNV);
            this.grcQLNV.Controls.Add(this.label6);
            this.grcQLNV.Controls.Add(this.label5);
            this.grcQLNV.Controls.Add(this.txtMatKhau);
            this.grcQLNV.Controls.Add(this.txtTenTaiKhoan);
            this.grcQLNV.Controls.Add(this.label2);
            this.grcQLNV.Controls.Add(this.label1);
            this.grcQLNV.Location = new System.Drawing.Point(12, 12);
            this.grcQLNV.Name = "grcQLNV";
            this.grcQLNV.Size = new System.Drawing.Size(604, 119);
            this.grcQLNV.TabIndex = 7;
            this.grcQLNV.Text = "Thông Tin Nhân Viên";
            // 
            // cmbMaNV
            // 
            this.cmbMaNV.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbMaNV.FormattingEnabled = true;
            this.cmbMaNV.Location = new System.Drawing.Point(370, 34);
            this.cmbMaNV.Name = "cmbMaNV";
            this.cmbMaNV.Size = new System.Drawing.Size(213, 24);
            this.cmbMaNV.TabIndex = 19;
            this.cmbMaNV.SelectedIndexChanged += new System.EventHandler(this.cmbMaNV_SelectedIndexChanged);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenNV.Location = new System.Drawing.Point(370, 74);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.ReadOnly = true;
            this.txtTenNV.Size = new System.Drawing.Size(213, 22);
            this.txtTenNV.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(263, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Tên Nhân Viên :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(266, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Mã Nhân Viên :";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMatKhau.Location = new System.Drawing.Point(110, 74);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(133, 22);
            this.txtMatKhau.TabIndex = 4;
            // 
            // txtTenTaiKhoan
            // 
            this.txtTenTaiKhoan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenTaiKhoan.Location = new System.Drawing.Point(110, 34);
            this.txtTenTaiKhoan.Name = "txtTenTaiKhoan";
            this.txtTenTaiKhoan.Size = new System.Drawing.Size(133, 22);
            this.txtTenTaiKhoan.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(5, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật Khẩu :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(5, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Tài Khoản :";
            // 
            // grcQuyen
            // 
            this.grcQuyen.AppearanceCaption.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grcQuyen.AppearanceCaption.Options.UseFont = true;
            this.grcQuyen.Controls.Add(this.chkGoiMon);
            this.grcQuyen.Controls.Add(this.chkThucDon);
            this.grcQuyen.Controls.Add(this.chkKhuVuc);
            this.grcQuyen.Controls.Add(this.chkDoanhThu);
            this.grcQuyen.Controls.Add(this.chkQuanLy);
            this.grcQuyen.Controls.Add(this.groupControl3);
            this.grcQuyen.Location = new System.Drawing.Point(622, 12);
            this.grcQuyen.Name = "grcQuyen";
            this.grcQuyen.Size = new System.Drawing.Size(445, 119);
            this.grcQuyen.TabIndex = 16;
            this.grcQuyen.Text = "Quyền Truy Cập";
            // 
            // chkGoiMon
            // 
            this.chkGoiMon.Location = new System.Drawing.Point(317, 36);
            this.chkGoiMon.Name = "chkGoiMon";
            this.chkGoiMon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkGoiMon.Properties.Appearance.Options.UseFont = true;
            this.chkGoiMon.Properties.Caption = "Gọi Món";
            this.chkGoiMon.Size = new System.Drawing.Size(91, 23);
            this.chkGoiMon.TabIndex = 19;
            // 
            // chkThucDon
            // 
            this.chkThucDon.Location = new System.Drawing.Point(168, 89);
            this.chkThucDon.Name = "chkThucDon";
            this.chkThucDon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkThucDon.Properties.Appearance.Options.UseFont = true;
            this.chkThucDon.Properties.Caption = "Thực Đơn";
            this.chkThucDon.Size = new System.Drawing.Size(103, 23);
            this.chkThucDon.TabIndex = 18;
            // 
            // chkKhuVuc
            // 
            this.chkKhuVuc.Location = new System.Drawing.Point(168, 35);
            this.chkKhuVuc.Name = "chkKhuVuc";
            this.chkKhuVuc.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkKhuVuc.Properties.Appearance.Options.UseFont = true;
            this.chkKhuVuc.Properties.Caption = "Khu Vực";
            this.chkKhuVuc.Size = new System.Drawing.Size(91, 23);
            this.chkKhuVuc.TabIndex = 17;
            // 
            // chkDoanhThu
            // 
            this.chkDoanhThu.Location = new System.Drawing.Point(317, 89);
            this.chkDoanhThu.Name = "chkDoanhThu";
            this.chkDoanhThu.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkDoanhThu.Properties.Appearance.Options.UseFont = true;
            this.chkDoanhThu.Properties.Caption = "Doanh Thu";
            this.chkDoanhThu.Size = new System.Drawing.Size(111, 23);
            this.chkDoanhThu.TabIndex = 16;
            // 
            // chkQuanLy
            // 
            this.chkQuanLy.Location = new System.Drawing.Point(42, 58);
            this.chkQuanLy.Name = "chkQuanLy";
            this.chkQuanLy.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkQuanLy.Properties.Appearance.Options.UseFont = true;
            this.chkQuanLy.Properties.Caption = "Quản Lý";
            this.chkQuanLy.Size = new System.Drawing.Size(91, 23);
            this.chkQuanLy.TabIndex = 15;
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.textBox3);
            this.groupControl3.Controls.Add(this.textBox4);
            this.groupControl3.Controls.Add(this.label7);
            this.groupControl3.Controls.Add(this.label8);
            this.groupControl3.Location = new System.Drawing.Point(554, 9);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(505, 103);
            this.groupControl3.TabIndex = 14;
            this.groupControl3.Text = "Thông Tin Nhân Viên";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox3.Location = new System.Drawing.Point(135, 65);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(158, 22);
            this.textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox4.Location = new System.Drawing.Point(135, 35);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(158, 22);
            this.textBox4.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(31, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Họ :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(31, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Mã Nhân Viên :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(377, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 29);
            this.label3.TabIndex = 17;
            this.label3.Text = "DANH SÁCH TÀI KHOẢN";
            // 
            // frmTAIKHOAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 555);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grcQuyen);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridDSTK);
            this.Controls.Add(this.grcQLNV);
            this.Name = "frmTAIKHOAN";
            this.Text = "TÀI KHOẢN";
            this.Load += new System.EventHandler(this.TAIKHOAN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDSTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcQLNV)).EndInit();
            this.grcQLNV.ResumeLayout(false);
            this.grcQLNV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcQuyen)).EndInit();
            this.grcQuyen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkGoiMon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThucDon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKhuVuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDoanhThu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuanLy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.GridControl gridDSTK;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl grcQLNV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTenTaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl grcQuyen;
        private DevExpress.XtraEditors.CheckEdit chkGoiMon;
        private DevExpress.XtraEditors.CheckEdit chkThucDon;
        private DevExpress.XtraEditors.CheckEdit chkKhuVuc;
        private DevExpress.XtraEditors.CheckEdit chkDoanhThu;
        private DevExpress.XtraEditors.CheckEdit chkQuanLy;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMaNV;
        private System.Windows.Forms.TextBox txtTenNV;
    }
}