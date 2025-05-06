namespace TraSuaApp
{
    partial class UC_Ban
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
            this.label19 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flpBan = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbSucChua = new System.Windows.Forms.TextBox();
            this.lbTableList = new System.Windows.Forms.Label();
            this.cbTrangThaiBan = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.lbTableCode = new System.Windows.Forms.Label();
            this.tbMaBan = new System.Windows.Forms.TextBox();
            this.lbCapacity = new System.Windows.Forms.Label();
            this.lbTableInfo = new System.Windows.Forms.Label();
            this.dgvCTBan = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.cbTrangThaiDatBan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMaDB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdateDetail = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTBan)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Bisque;
            this.label19.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.OrangeRed;
            this.label19.Location = new System.Drawing.Point(683, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(214, 42);
            this.label19.TabIndex = 21;
            this.label19.Text = "Quản lý bàn";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.flpBan);
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Controls.Add(this.tbSucChua);
            this.panel4.Controls.Add(this.lbTableList);
            this.panel4.Controls.Add(this.cbTrangThaiBan);
            this.panel4.Controls.Add(this.btnUpdate);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.lbStatus);
            this.panel4.Controls.Add(this.btnInsert);
            this.panel4.Controls.Add(this.lbTableCode);
            this.panel4.Controls.Add(this.tbMaBan);
            this.panel4.Controls.Add(this.lbCapacity);
            this.panel4.Location = new System.Drawing.Point(60, 43);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1029, 278);
            this.panel4.TabIndex = 20;
            // 
            // flpBan
            // 
            this.flpBan.AutoScroll = true;
            this.flpBan.Location = new System.Drawing.Point(3, 44);
            this.flpBan.Name = "flpBan";
            this.flpBan.Size = new System.Drawing.Size(650, 226);
            this.flpBan.TabIndex = 17;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkOrange;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(790, 207);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 34);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbSucChua
            // 
            this.tbSucChua.Location = new System.Drawing.Point(817, 109);
            this.tbSucChua.Name = "tbSucChua";
            this.tbSucChua.Size = new System.Drawing.Size(183, 22);
            this.tbSucChua.TabIndex = 39;
            // 
            // lbTableList
            // 
            this.lbTableList.BackColor = System.Drawing.Color.Bisque;
            this.lbTableList.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTableList.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbTableList.Location = new System.Drawing.Point(203, 9);
            this.lbTableList.Name = "lbTableList";
            this.lbTableList.Size = new System.Drawing.Size(285, 36);
            this.lbTableList.TabIndex = 18;
            this.lbTableList.Text = "Danh sách bàn";
            // 
            // cbTrangThaiBan
            // 
            this.cbTrangThaiBan.FormattingEnabled = true;
            this.cbTrangThaiBan.Location = new System.Drawing.Point(817, 159);
            this.cbTrangThaiBan.Name = "cbTrangThaiBan";
            this.cbTrangThaiBan.Size = new System.Drawing.Size(183, 24);
            this.cbTrangThaiBan.TabIndex = 38;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(903, 207);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(107, 34);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.Black;
            this.lbStatus.Location = new System.Drawing.Point(687, 159);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(124, 28);
            this.lbStatus.TabIndex = 37;
            this.lbStatus.Text = "Trạng thái";
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.DarkOrange;
            this.btnInsert.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(677, 207);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(107, 34);
            this.btnInsert.TabIndex = 20;
            this.btnInsert.Text = "Thêm";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // lbTableCode
            // 
            this.lbTableCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTableCode.ForeColor = System.Drawing.Color.Black;
            this.lbTableCode.Location = new System.Drawing.Point(687, 63);
            this.lbTableCode.Name = "lbTableCode";
            this.lbTableCode.Size = new System.Drawing.Size(117, 28);
            this.lbTableCode.TabIndex = 32;
            this.lbTableCode.Text = "Mã bàn";
            // 
            // tbMaBan
            // 
            this.tbMaBan.Location = new System.Drawing.Point(817, 63);
            this.tbMaBan.Name = "tbMaBan";
            this.tbMaBan.Size = new System.Drawing.Size(183, 22);
            this.tbMaBan.TabIndex = 31;
            // 
            // lbCapacity
            // 
            this.lbCapacity.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCapacity.ForeColor = System.Drawing.Color.Black;
            this.lbCapacity.Location = new System.Drawing.Point(687, 109);
            this.lbCapacity.Name = "lbCapacity";
            this.lbCapacity.Size = new System.Drawing.Size(124, 28);
            this.lbCapacity.TabIndex = 30;
            this.lbCapacity.Text = "Sức chứa";
            // 
            // lbTableInfo
            // 
            this.lbTableInfo.BackColor = System.Drawing.Color.Bisque;
            this.lbTableInfo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTableInfo.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbTableInfo.Location = new System.Drawing.Point(203, 14);
            this.lbTableInfo.Name = "lbTableInfo";
            this.lbTableInfo.Size = new System.Drawing.Size(311, 42);
            this.lbTableInfo.TabIndex = 19;
            this.lbTableInfo.Text = "Thông tin đặt bàn";
            // 
            // dgvCTBan
            // 
            this.dgvCTBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCTBan.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCTBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTBan.Location = new System.Drawing.Point(18, 59);
            this.dgvCTBan.Name = "dgvCTBan";
            this.dgvCTBan.RowHeadersVisible = false;
            this.dgvCTBan.RowHeadersWidth = 51;
            this.dgvCTBan.RowTemplate.Height = 24;
            this.dgvCTBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCTBan.Size = new System.Drawing.Size(623, 280);
            this.dgvCTBan.TabIndex = 16;
            this.dgvCTBan.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCTBan_RowEnter);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(689, 97);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 34);
            this.btnSearch.TabIndex = 31;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(689, 59);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(311, 22);
            this.tbSearch.TabIndex = 30;
            // 
            // cbTrangThaiDatBan
            // 
            this.cbTrangThaiDatBan.FormattingEnabled = true;
            this.cbTrangThaiDatBan.Location = new System.Drawing.Point(817, 273);
            this.cbTrangThaiDatBan.Name = "cbTrangThaiDatBan";
            this.cbTrangThaiDatBan.Size = new System.Drawing.Size(183, 24);
            this.cbTrangThaiDatBan.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(685, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 28);
            this.label1.TabIndex = 39;
            this.label1.Text = "Trạng thái";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Bisque;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(683, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 42);
            this.label2.TabIndex = 41;
            this.label2.Text = "Cập nhật";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(685, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 28);
            this.label3.TabIndex = 43;
            this.label3.Text = "Mã đặt bàn";
            // 
            // tbMaDB
            // 
            this.tbMaDB.Location = new System.Drawing.Point(817, 222);
            this.tbMaDB.Name = "tbMaDB";
            this.tbMaDB.Size = new System.Drawing.Size(183, 22);
            this.tbMaDB.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Bisque;
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(685, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 42);
            this.label4.TabIndex = 44;
            this.label4.Text = "Nhập thông tin";
            // 
            // btnUpdateDetail
            // 
            this.btnUpdateDetail.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdateDetail.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateDetail.Location = new System.Drawing.Point(817, 314);
            this.btnUpdateDetail.Name = "btnUpdateDetail";
            this.btnUpdateDetail.Size = new System.Drawing.Size(107, 34);
            this.btnUpdateDetail.TabIndex = 45;
            this.btnUpdateDetail.Text = "Cập nhật";
            this.btnUpdateDetail.UseVisualStyleBackColor = false;
            this.btnUpdateDetail.Click += new System.EventHandler(this.btnUpdateDetail_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbTableInfo);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Controls.Add(this.dgvCTBan);
            this.panel1.Controls.Add(this.btnUpdateDetail);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.tbMaDB);
            this.panel1.Controls.Add(this.cbTrangThaiDatBan);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(60, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 366);
            this.panel1.TabIndex = 46;
            // 
            // UC_Ban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Name = "UC_Ban";
            this.Size = new System.Drawing.Size(1139, 723);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTBan)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbSucChua;
        private System.Windows.Forms.ComboBox cbTrangThaiBan;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label lbTableCode;
        private System.Windows.Forms.TextBox tbMaBan;
        private System.Windows.Forms.Label lbCapacity;
        private System.Windows.Forms.Label lbTableInfo;
        private System.Windows.Forms.Label lbTableList;
        private System.Windows.Forms.FlowLayoutPanel flpBan;
        private System.Windows.Forms.DataGridView dgvCTBan;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ComboBox cbTrangThaiDatBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMaDB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdateDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
    }
}
