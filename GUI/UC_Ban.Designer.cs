namespace GD
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
            this.tbCapacity = new System.Windows.Forms.TextBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.lbTableCode = new System.Windows.Forms.Label();
            this.tbTableCode = new System.Windows.Forms.TextBox();
            this.lbCapacity = new System.Windows.Forms.Label();
            this.lbTableInfo = new System.Windows.Forms.Label();
            this.lbTableList = new System.Windows.Forms.Label();
            this.flpTableList = new System.Windows.Forms.FlowLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.dgvTableList = new System.Windows.Forms.DataGridView();
            this.panel4.SuspendLayout();
            this.flpTableList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableList)).BeginInit();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Bisque;
            this.label19.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.OrangeRed;
            this.label19.Location = new System.Drawing.Point(765, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(214, 42);
            this.label19.TabIndex = 21;
            this.label19.Text = "Quản lý bàn";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.tbCapacity);
            this.panel4.Controls.Add(this.cbStatus);
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Controls.Add(this.lbStatus);
            this.panel4.Controls.Add(this.btnInsert);
            this.panel4.Controls.Add(this.lbTableCode);
            this.panel4.Controls.Add(this.tbTableCode);
            this.panel4.Controls.Add(this.lbCapacity);
            this.panel4.Location = new System.Drawing.Point(679, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(393, 220);
            this.panel4.TabIndex = 20;
            // 
            // tbCapacity
            // 
            this.tbCapacity.Location = new System.Drawing.Point(150, 49);
            this.tbCapacity.Name = "tbCapacity";
            this.tbCapacity.Size = new System.Drawing.Size(183, 22);
            this.tbCapacity.TabIndex = 39;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(150, 99);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(183, 24);
            this.cbStatus.TabIndex = 38;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkOrange;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(150, 147);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 34);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Sửa";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // lbStatus
            // 
            this.lbStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.Black;
            this.lbStatus.Location = new System.Drawing.Point(20, 99);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(146, 28);
            this.lbStatus.TabIndex = 37;
            this.lbStatus.Text = "Trạng thái";
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.DarkOrange;
            this.btnInsert.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(24, 147);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(107, 34);
            this.btnInsert.TabIndex = 20;
            this.btnInsert.Text = "Thêm";
            this.btnInsert.UseVisualStyleBackColor = false;
            // 
            // lbTableCode
            // 
            this.lbTableCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTableCode.ForeColor = System.Drawing.Color.Black;
            this.lbTableCode.Location = new System.Drawing.Point(20, 3);
            this.lbTableCode.Name = "lbTableCode";
            this.lbTableCode.Size = new System.Drawing.Size(124, 28);
            this.lbTableCode.TabIndex = 32;
            this.lbTableCode.Text = "Mã bàn";
            // 
            // tbTableCode
            // 
            this.tbTableCode.Location = new System.Drawing.Point(150, 3);
            this.tbTableCode.Name = "tbTableCode";
            this.tbTableCode.Size = new System.Drawing.Size(183, 22);
            this.tbTableCode.TabIndex = 31;
            // 
            // lbCapacity
            // 
            this.lbCapacity.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCapacity.ForeColor = System.Drawing.Color.Black;
            this.lbCapacity.Location = new System.Drawing.Point(20, 49);
            this.lbCapacity.Name = "lbCapacity";
            this.lbCapacity.Size = new System.Drawing.Size(146, 28);
            this.lbCapacity.TabIndex = 30;
            this.lbCapacity.Text = "Sức chứa";
            // 
            // lbTableInfo
            // 
            this.lbTableInfo.BackColor = System.Drawing.Color.Bisque;
            this.lbTableInfo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTableInfo.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbTableInfo.Location = new System.Drawing.Point(462, 438);
            this.lbTableInfo.Name = "lbTableInfo";
            this.lbTableInfo.Size = new System.Drawing.Size(311, 42);
            this.lbTableInfo.TabIndex = 19;
            this.lbTableInfo.Text = "Thông tin đặt bàn";
            // 
            // lbTableList
            // 
            this.lbTableList.BackColor = System.Drawing.Color.Bisque;
            this.lbTableList.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTableList.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbTableList.Location = new System.Drawing.Point(233, 52);
            this.lbTableList.Name = "lbTableList";
            this.lbTableList.Size = new System.Drawing.Size(311, 42);
            this.lbTableList.TabIndex = 18;
            this.lbTableList.Text = "Danh sách bàn";
            // 
            // flpTableList
            // 
            this.flpTableList.Controls.Add(this.button3);
            this.flpTableList.Controls.Add(this.button4);
            this.flpTableList.Controls.Add(this.button5);
            this.flpTableList.Controls.Add(this.button6);
            this.flpTableList.Controls.Add(this.button7);
            this.flpTableList.Controls.Add(this.button8);
            this.flpTableList.Controls.Add(this.button9);
            this.flpTableList.Controls.Add(this.button10);
            this.flpTableList.Controls.Add(this.button11);
            this.flpTableList.Controls.Add(this.button12);
            this.flpTableList.Controls.Add(this.button13);
            this.flpTableList.Controls.Add(this.button15);
            this.flpTableList.Location = new System.Drawing.Point(105, 97);
            this.flpTableList.Name = "flpTableList";
            this.flpTableList.Size = new System.Drawing.Size(526, 338);
            this.flpTableList.TabIndex = 17;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 99);
            this.button3.TabIndex = 1;
            this.button3.Text = "Bàn X\r\nSức chứa: Y\r\n(Trống)\r\n\r\n";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(123, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 99);
            this.button4.TabIndex = 2;
            this.button4.Text = "Bàn X\r\nSức chứa: Y\r\n(Đã đặt)\r\n\r\n";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Orange;
            this.button5.Location = new System.Drawing.Point(243, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(114, 99);
            this.button5.TabIndex = 3;
            this.button5.Text = "Bàn X\r\nSức chứa: Y\r\n(Trống)\r\n\r\n";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Orange;
            this.button6.Location = new System.Drawing.Point(363, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(114, 99);
            this.button6.TabIndex = 4;
            this.button6.Text = "Bàn X\r\nSức chứa: Y\r\n(Trống)\r\n\r\n";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Orange;
            this.button7.Location = new System.Drawing.Point(3, 108);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(114, 99);
            this.button7.TabIndex = 5;
            this.button7.Text = "Bàn X\r\nSức chứa: Y\r\n(Trống)\r\n\r\n";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Orange;
            this.button8.Location = new System.Drawing.Point(123, 108);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(114, 99);
            this.button8.TabIndex = 7;
            this.button8.Text = "Bàn X\r\nSức chứa: Y\r\n(Trống)\r\n\r\n";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Orange;
            this.button9.Location = new System.Drawing.Point(243, 108);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(114, 99);
            this.button9.TabIndex = 8;
            this.button9.Text = "Bàn X\r\nSức chứa: Y\r\n(Trống)\r\n\r\n";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Red;
            this.button10.Location = new System.Drawing.Point(363, 108);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(114, 99);
            this.button10.TabIndex = 9;
            this.button10.Text = "Bàn X\r\nSức chứa: Y\r\n(Đã đặt)\r\n\r\n";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Red;
            this.button11.Location = new System.Drawing.Point(3, 213);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(114, 99);
            this.button11.TabIndex = 10;
            this.button11.Text = "Bàn X\r\nSức chứa: Y\r\n(Đã đặt)\r\n\r\n";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Orange;
            this.button12.Location = new System.Drawing.Point(123, 213);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(114, 99);
            this.button12.TabIndex = 11;
            this.button12.Text = "Bàn X\r\nSức chứa: Y\r\n(Trống)\r\n\r\n";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Red;
            this.button13.Location = new System.Drawing.Point(243, 213);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(114, 99);
            this.button13.TabIndex = 12;
            this.button13.Text = "Bàn X\r\nSức chứa: Y\r\n(Đã đặt)\r\n\r\n";
            this.button13.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Orange;
            this.button15.Location = new System.Drawing.Point(363, 213);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(114, 99);
            this.button15.TabIndex = 14;
            this.button15.Text = "Bàn X\r\nSức chứa: Y\r\n(Trống)\r\n\r\n";
            this.button15.UseVisualStyleBackColor = false;
            // 
            // dgvTableList
            // 
            this.dgvTableList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTableList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableList.Location = new System.Drawing.Point(76, 483);
            this.dgvTableList.Name = "dgvTableList";
            this.dgvTableList.RowHeadersVisible = false;
            this.dgvTableList.RowHeadersWidth = 51;
            this.dgvTableList.RowTemplate.Height = 24;
            this.dgvTableList.Size = new System.Drawing.Size(996, 220);
            this.dgvTableList.TabIndex = 16;
            // 
            // UC_Ban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.label19);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lbTableInfo);
            this.Controls.Add(this.lbTableList);
            this.Controls.Add(this.flpTableList);
            this.Controls.Add(this.dgvTableList);
            this.Name = "UC_Ban";
            this.Size = new System.Drawing.Size(1139, 754);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flpTableList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbCapacity;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label lbTableCode;
        private System.Windows.Forms.TextBox tbTableCode;
        private System.Windows.Forms.Label lbCapacity;
        private System.Windows.Forms.Label lbTableInfo;
        private System.Windows.Forms.Label lbTableList;
        private System.Windows.Forms.FlowLayoutPanel flpTableList;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.DataGridView dgvTableList;
    }
}
