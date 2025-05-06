namespace TraSuaApp
{
    partial class UC_DonHang
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
            this.lbHDList = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDH = new System.Windows.Forms.DataGridView();
            this.lbInfo = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnUpdateOrder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMaDH = new System.Windows.Forms.TextBox();
            this.cbTrangThaiDH = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCTDH = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDH)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDH)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbHDList
            // 
            this.lbHDList.BackColor = System.Drawing.Color.Bisque;
            this.lbHDList.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHDList.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbHDList.Location = new System.Drawing.Point(432, 41);
            this.lbHDList.Name = "lbHDList";
            this.lbHDList.Size = new System.Drawing.Size(350, 42);
            this.lbHDList.TabIndex = 42;
            this.lbHDList.Text = "Danh sách đơn hàng";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvDH);
            this.panel3.Location = new System.Drawing.Point(72, 142);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(994, 236);
            this.panel3.TabIndex = 41;
            // 
            // dgvDH
            // 
            this.dgvDH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDH.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDH.Location = new System.Drawing.Point(0, 0);
            this.dgvDH.Name = "dgvDH";
            this.dgvDH.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvDH.RowHeadersVisible = false;
            this.dgvDH.RowHeadersWidth = 51;
            this.dgvDH.RowTemplate.Height = 24;
            this.dgvDH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDH.Size = new System.Drawing.Size(994, 236);
            this.dgvDH.TabIndex = 1;
            this.dgvDH.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDH_RowEnter);
            // 
            // lbInfo
            // 
            this.lbInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.ForeColor = System.Drawing.Color.Black;
            this.lbInfo.Location = new System.Drawing.Point(227, 98);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(178, 28);
            this.lbInfo.TabIndex = 45;
            this.lbInfo.Text = "Nhập thông tin";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(816, 92);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 34);
            this.btnSearch.TabIndex = 44;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(411, 101);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(399, 22);
            this.tbSearch.TabIndex = 43;
            // 
            // btnUpdateOrder
            // 
            this.btnUpdateOrder.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdateOrder.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateOrder.Location = new System.Drawing.Point(153, 128);
            this.btnUpdateOrder.Name = "btnUpdateOrder";
            this.btnUpdateOrder.Size = new System.Drawing.Size(107, 34);
            this.btnUpdateOrder.TabIndex = 51;
            this.btnUpdateOrder.Text = "Cập nhật";
            this.btnUpdateOrder.UseVisualStyleBackColor = false;
            this.btnUpdateOrder.Click += new System.EventHandler(this.btnUpdateOrder_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(21, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 28);
            this.label3.TabIndex = 50;
            this.label3.Text = "Mã đơn";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 28);
            this.label1.TabIndex = 46;
            this.label1.Text = "Trạng thái";
            // 
            // tbMaDH
            // 
            this.tbMaDH.Location = new System.Drawing.Point(153, 36);
            this.tbMaDH.Name = "tbMaDH";
            this.tbMaDH.Size = new System.Drawing.Size(183, 22);
            this.tbMaDH.TabIndex = 49;
            // 
            // cbTrangThaiDH
            // 
            this.cbTrangThaiDH.FormattingEnabled = true;
            this.cbTrangThaiDH.Location = new System.Drawing.Point(153, 87);
            this.cbTrangThaiDH.Name = "cbTrangThaiDH";
            this.cbTrangThaiDH.Size = new System.Drawing.Size(183, 24);
            this.cbTrangThaiDH.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Bisque;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(801, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 42);
            this.label2.TabIndex = 48;
            this.label2.Text = "Cập nhật";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvCTDH);
            this.panel1.Location = new System.Drawing.Point(68, 440);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 223);
            this.panel1.TabIndex = 52;
            // 
            // dgvCTDH
            // 
            this.dgvCTDH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCTDH.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCTDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTDH.Location = new System.Drawing.Point(0, 0);
            this.dgvCTDH.Name = "dgvCTDH";
            this.dgvCTDH.RowHeadersVisible = false;
            this.dgvCTDH.RowHeadersWidth = 51;
            this.dgvCTDH.RowTemplate.Height = 24;
            this.dgvCTDH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCTDH.Size = new System.Drawing.Size(610, 223);
            this.dgvCTDH.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tbMaDH);
            this.panel2.Controls.Add(this.btnUpdateOrder);
            this.panel2.Controls.Add(this.cbTrangThaiDH);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(702, 440);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 223);
            this.panel2.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Bisque;
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(232, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(301, 42);
            this.label4.TabIndex = 54;
            this.label4.Text = "Chi tiết đơn hàng";
            // 
            // UC_DonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lbHDList);
            this.Controls.Add(this.panel3);
            this.Name = "UC_DonHang";
            this.Size = new System.Drawing.Size(1139, 723);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDH)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDH)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbHDList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvDH;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnUpdateOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMaDH;
        private System.Windows.Forms.ComboBox cbTrangThaiDH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCTDH;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
    }
}
