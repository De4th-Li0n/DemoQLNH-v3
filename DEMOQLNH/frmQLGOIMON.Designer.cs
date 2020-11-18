namespace DEMOQLNH
{
    partial class frmQLGOIMON
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
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridDSGM = new DevExpress.XtraGrid.GridControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grcQLNV = new DevExpress.XtraEditors.GroupControl();
            this.cmbLoaiTD = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.cmbTenBan = new System.Windows.Forms.ComboBox();
            this.cmbTenTD = new System.Windows.Forms.ComboBox();
            this.cmbTenKV = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSGM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcQLNV)).BeginInit();
            this.grcQLNV.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(406, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(269, 29);
            this.label8.TabIndex = 23;
            this.label8.Text = "DANH SÁCH GỌI MÓN";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSoLuong.Location = new System.Drawing.Point(922, 33);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(110, 22);
            this.txtSoLuong.TabIndex = 4;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.GridControl = this.gridDSGM;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridDSGM
            // 
            this.gridDSGM.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridDSGM.Location = new System.Drawing.Point(12, 211);
            this.gridDSGM.MainView = this.gridView1;
            this.gridDSGM.Name = "gridDSGM";
            this.gridDSGM.Size = new System.Drawing.Size(1060, 333);
            this.gridDSGM.TabIndex = 17;
            this.gridDSGM.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(841, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số Lượng :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(7, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Thực Đơn :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(508, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Bàn :";
            // 
            // grcQLNV
            // 
            this.grcQLNV.AppearanceCaption.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grcQLNV.AppearanceCaption.Options.UseFont = true;
            this.grcQLNV.Controls.Add(this.cmbLoaiTD);
            this.grcQLNV.Controls.Add(this.label7);
            this.grcQLNV.Controls.Add(this.label6);
            this.grcQLNV.Controls.Add(this.txtGia);
            this.grcQLNV.Controls.Add(this.cmbTenBan);
            this.grcQLNV.Controls.Add(this.cmbTenTD);
            this.grcQLNV.Controls.Add(this.cmbTenKV);
            this.grcQLNV.Controls.Add(this.label4);
            this.grcQLNV.Controls.Add(this.txtSoLuong);
            this.grcQLNV.Controls.Add(this.label3);
            this.grcQLNV.Controls.Add(this.label2);
            this.grcQLNV.Controls.Add(this.label1);
            this.grcQLNV.Location = new System.Drawing.Point(12, 18);
            this.grcQLNV.Name = "grcQLNV";
            this.grcQLNV.Size = new System.Drawing.Size(1060, 100);
            this.grcQLNV.TabIndex = 16;
            this.grcQLNV.Text = "Thông Tin Gọi Món";
            // 
            // cmbLoaiTD
            // 
            this.cmbLoaiTD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbLoaiTD.FormattingEnabled = true;
            this.cmbLoaiTD.Location = new System.Drawing.Point(113, 33);
            this.cmbLoaiTD.Name = "cmbLoaiTD";
            this.cmbLoaiTD.Size = new System.Drawing.Size(279, 24);
            this.cmbLoaiTD.TabIndex = 18;
            this.cmbLoaiTD.SelectedIndexChanged += new System.EventHandler(this.cmbLoaiTD_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(4, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Loại Thực Đơn :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(851, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Đơn Giá :";
            // 
            // txtGia
            // 
            this.txtGia.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtGia.Location = new System.Drawing.Point(922, 66);
            this.txtGia.Name = "txtGia";
            this.txtGia.ReadOnly = true;
            this.txtGia.Size = new System.Drawing.Size(110, 22);
            this.txtGia.TabIndex = 15;
            // 
            // cmbTenBan
            // 
            this.cmbTenBan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbTenBan.FormattingEnabled = true;
            this.cmbTenBan.Location = new System.Drawing.Point(578, 66);
            this.cmbTenBan.Name = "cmbTenBan";
            this.cmbTenBan.Size = new System.Drawing.Size(209, 24);
            this.cmbTenBan.TabIndex = 14;
            // 
            // cmbTenTD
            // 
            this.cmbTenTD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbTenTD.FormattingEnabled = true;
            this.cmbTenTD.Location = new System.Drawing.Point(113, 66);
            this.cmbTenTD.Name = "cmbTenTD";
            this.cmbTenTD.Size = new System.Drawing.Size(279, 24);
            this.cmbTenTD.TabIndex = 13;
            this.cmbTenTD.SelectedIndexChanged += new System.EventHandler(this.cmbTenTD_SelectedIndexChanged);
            // 
            // cmbTenKV
            // 
            this.cmbTenKV.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cmbTenKV.FormattingEnabled = true;
            this.cmbTenKV.Location = new System.Drawing.Point(578, 33);
            this.cmbTenKV.Name = "cmbTenKV";
            this.cmbTenKV.Size = new System.Drawing.Size(209, 24);
            this.cmbTenKV.TabIndex = 12;
            this.cmbTenKV.SelectedIndexChanged += new System.EventHandler(this.cmbTenKV_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(479, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tên Khu Vực :";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = global::DEMOQLNH.Properties.Resources.Luu;
            this.btnSave.Location = new System.Drawing.Point(590, 124);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 52);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.ImageOptions.Image = global::DEMOQLNH.Properties.Resources.Sua;
            this.btnEdit.Location = new System.Drawing.Point(464, 124);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 52);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDel.Appearance.Options.UseFont = true;
            this.btnDel.ImageOptions.Image = global::DEMOQLNH.Properties.Resources.Xoa;
            this.btnDel.Location = new System.Drawing.Point(338, 124);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(120, 52);
            this.btnDel.TabIndex = 19;
            this.btnDel.Text = "Xóa";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = global::DEMOQLNH.Properties.Resources.Them;
            this.btnAdd.Location = new System.Drawing.Point(212, 124);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 52);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.Image = global::DEMOQLNH.Properties.Resources.Huy;
            this.btnCancel.Location = new System.Drawing.Point(716, 124);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 52);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmQLGOIMON
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 556);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridDSGM);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grcQLNV);
            this.Name = "frmQLGOIMON";
            this.Text = "QUẢN LÝ GỌI MÓN";
            this.Load += new System.EventHandler(this.frmQLGOIMON_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSGM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcQLNV)).EndInit();
            this.grcQLNV.ResumeLayout(false);
            this.grcQLNV.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSoLuong;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridDSGM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl grcQLNV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTenBan;
        private System.Windows.Forms.ComboBox cmbTenTD;
        private System.Windows.Forms.ComboBox cmbTenKV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.ComboBox cmbLoaiTD;
        private System.Windows.Forms.Label label7;
    }
}