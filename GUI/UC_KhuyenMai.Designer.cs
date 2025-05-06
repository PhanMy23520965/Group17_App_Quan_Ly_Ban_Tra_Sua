namespace TraSuaApp
{
    partial class UC_KhuyenMai
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvKM = new System.Windows.Forms.DataGridView();
            this.tbGTT = new System.Windows.Forms.TextBox();
            this.tbND = new System.Windows.Forms.TextBox();
            this.tbChietKhau = new System.Windows.Forms.TextBox();
            this.tbGTD = new System.Windows.Forms.TextBox();
            this.tbCouponID = new System.Windows.Forms.TextBox();
            this.lbLeastTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbMaxForDiscount = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbCouponCode = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpKetThuc = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKM)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Bisque;
            this.label13.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.OrangeRed;
            this.label13.Location = new System.Drawing.Point(381, 399);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(438, 42);
            this.label13.TabIndex = 64;
            this.label13.Text = "Thông tin mã khuyến mãi";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Bisque;
            this.label14.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.OrangeRed;
            this.label14.Location = new System.Drawing.Point(424, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(413, 42);
            this.label14.TabIndex = 63;
            this.label14.Text = "Danh sách khuyến mãi";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvKM);
            this.panel1.Location = new System.Drawing.Point(115, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 240);
            this.panel1.TabIndex = 62;
            // 
            // dgvKM
            // 
            this.dgvKM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKM.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvKM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKM.Location = new System.Drawing.Point(0, 3);
            this.dgvKM.Name = "dgvKM";
            this.dgvKM.RowHeadersVisible = false;
            this.dgvKM.RowHeadersWidth = 51;
            this.dgvKM.RowTemplate.Height = 24;
            this.dgvKM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKM.Size = new System.Drawing.Size(914, 237);
            this.dgvKM.TabIndex = 1;
            this.dgvKM.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenu_RowEnter);
            // 
            // tbGTT
            // 
            this.tbGTT.Location = new System.Drawing.Point(767, 547);
            this.tbGTT.Name = "tbGTT";
            this.tbGTT.Size = new System.Drawing.Size(263, 22);
            this.tbGTT.TabIndex = 85;
            // 
            // tbND
            // 
            this.tbND.Location = new System.Drawing.Point(280, 502);
            this.tbND.Name = "tbND";
            this.tbND.Size = new System.Drawing.Size(266, 22);
            this.tbND.TabIndex = 83;
            // 
            // tbChietKhau
            // 
            this.tbChietKhau.Location = new System.Drawing.Point(764, 461);
            this.tbChietKhau.Name = "tbChietKhau";
            this.tbChietKhau.Size = new System.Drawing.Size(266, 22);
            this.tbChietKhau.TabIndex = 82;
            // 
            // tbGTD
            // 
            this.tbGTD.Location = new System.Drawing.Point(767, 502);
            this.tbGTD.Name = "tbGTD";
            this.tbGTD.Size = new System.Drawing.Size(263, 22);
            this.tbGTD.TabIndex = 79;
            // 
            // tbCouponID
            // 
            this.tbCouponID.Location = new System.Drawing.Point(280, 461);
            this.tbCouponID.Name = "tbCouponID";
            this.tbCouponID.Size = new System.Drawing.Size(266, 22);
            this.tbCouponID.TabIndex = 68;
            // 
            // lbLeastTotal
            // 
            this.lbLeastTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeastTotal.ForeColor = System.Drawing.Color.Black;
            this.lbLeastTotal.Location = new System.Drawing.Point(611, 547);
            this.lbLeastTotal.Name = "lbLeastTotal";
            this.lbLeastTotal.Size = new System.Drawing.Size(149, 28);
            this.lbLeastTotal.TabIndex = 86;
            this.lbLeastTotal.Text = "Giá tối thiểu";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(112, 499);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 28);
            this.label9.TabIndex = 84;
            this.label9.Text = "Nội dung";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(611, 461);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(135, 28);
            this.label16.TabIndex = 81;
            this.label16.Text = "Chiết khấu";
            // 
            // lbMaxForDiscount
            // 
            this.lbMaxForDiscount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaxForDiscount.ForeColor = System.Drawing.Color.Black;
            this.lbMaxForDiscount.Location = new System.Drawing.Point(608, 502);
            this.lbMaxForDiscount.Name = "lbMaxForDiscount";
            this.lbMaxForDiscount.Size = new System.Drawing.Size(152, 27);
            this.lbMaxForDiscount.TabIndex = 80;
            this.lbMaxForDiscount.Text = "Giảm tối đa";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkOrange;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(656, 644);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 34);
            this.btnDelete.TabIndex = 78;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(523, 644);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(107, 34);
            this.btnUpdate.TabIndex = 77;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.DarkOrange;
            this.btnInsert.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(387, 644);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(107, 34);
            this.btnInsert.TabIndex = 76;
            this.btnInsert.Text = "Thêm";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(110, 547);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 27);
            this.label8.TabIndex = 75;
            this.label8.Text = "Ngày bắt đầu";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(110, 593);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(168, 25);
            this.label10.TabIndex = 73;
            this.label10.Text = "Ngày kết thúc";
            // 
            // lbCouponCode
            // 
            this.lbCouponCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCouponCode.ForeColor = System.Drawing.Color.Black;
            this.lbCouponCode.Location = new System.Drawing.Point(110, 455);
            this.lbCouponCode.Name = "lbCouponCode";
            this.lbCouponCode.Size = new System.Drawing.Size(164, 28);
            this.lbCouponCode.TabIndex = 71;
            this.lbCouponCode.Text = "Mã khuyến mãi";
            // 
            // lbInfo
            // 
            this.lbInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.ForeColor = System.Drawing.Color.Black;
            this.lbInfo.Location = new System.Drawing.Point(223, 83);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(187, 28);
            this.lbInfo.TabIndex = 89;
            this.lbInfo.Text = "Nhập thông tin";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(810, 78);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 34);
            this.btnSearch.TabIndex = 88;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(416, 86);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(364, 22);
            this.tbSearch.TabIndex = 87;
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.Location = new System.Drawing.Point(280, 547);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(266, 22);
            this.dtpBatDau.TabIndex = 90;
            // 
            // dtpKetThuc
            // 
            this.dtpKetThuc.Location = new System.Drawing.Point(280, 593);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.Size = new System.Drawing.Size(266, 22);
            this.dtpKetThuc.TabIndex = 91;
            // 
            // UC_KhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.dtpKetThuc);
            this.Controls.Add(this.dtpBatDau);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.tbGTT);
            this.Controls.Add(this.tbND);
            this.Controls.Add(this.tbChietKhau);
            this.Controls.Add(this.tbGTD);
            this.Controls.Add(this.tbCouponID);
            this.Controls.Add(this.lbLeastTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lbMaxForDiscount);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbCouponCode);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Name = "UC_KhuyenMai";
            this.Size = new System.Drawing.Size(1139, 723);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvKM;
        private System.Windows.Forms.TextBox tbGTT;
        private System.Windows.Forms.TextBox tbND;
        private System.Windows.Forms.TextBox tbChietKhau;
        private System.Windows.Forms.TextBox tbGTD;
        private System.Windows.Forms.TextBox tbCouponID;
        private System.Windows.Forms.Label lbLeastTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbMaxForDiscount;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbCouponCode;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.DateTimePicker dtpKetThuc;
    }
}
