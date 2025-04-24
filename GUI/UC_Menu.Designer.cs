namespace GD
{
    partial class UC_Menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchMenu = new System.Windows.Forms.Button();
            this.tbSearchMenu = new System.Windows.Forms.TextBox();
            this.dgvMenu = new System.Windows.Forms.DataGridView();
            this.lbMenu = new System.Windows.Forms.Label();
            this.lbProductInfo = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lbImage = new System.Windows.Forms.Label();
            this.tbImage = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lbProductName = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.lbProductID = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.tbProductID = new System.Windows.Forms.TextBox();
            this.tbType = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(273, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 28);
            this.label1.TabIndex = 29;
            this.label1.Text = "Tên sản phẩm";
            // 
            // btnSearchMenu
            // 
            this.btnSearchMenu.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSearchMenu.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchMenu.Location = new System.Drawing.Point(749, 93);
            this.btnSearchMenu.Name = "btnSearchMenu";
            this.btnSearchMenu.Size = new System.Drawing.Size(107, 34);
            this.btnSearchMenu.TabIndex = 28;
            this.btnSearchMenu.Text = "Tìm";
            this.btnSearchMenu.UseVisualStyleBackColor = false;
            this.btnSearchMenu.Click += new System.EventHandler(this.btnSearchMenu_Click);
            // 
            // tbSearchMenu
            // 
            this.tbSearchMenu.Location = new System.Drawing.Point(423, 101);
            this.tbSearchMenu.Name = "tbSearchMenu";
            this.tbSearchMenu.Size = new System.Drawing.Size(301, 22);
            this.tbSearchMenu.TabIndex = 27;
            // 
            // dgvMenu
            // 
            this.dgvMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenu.Location = new System.Drawing.Point(150, 139);
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.RowHeadersVisible = false;
            this.dgvMenu.RowHeadersWidth = 51;
            this.dgvMenu.RowTemplate.Height = 24;
            this.dgvMenu.Size = new System.Drawing.Size(863, 246);
            this.dgvMenu.TabIndex = 26;
            // 
            // lbMenu
            // 
            this.lbMenu.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMenu.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbMenu.Location = new System.Drawing.Point(417, 46);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(354, 42);
            this.lbMenu.TabIndex = 25;
            this.lbMenu.Text = "Danh sách sản phẩm";
            // 
            // lbProductInfo
            // 
            this.lbProductInfo.BackColor = System.Drawing.Color.Bisque;
            this.lbProductInfo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductInfo.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbProductInfo.Location = new System.Drawing.Point(417, 437);
            this.lbProductInfo.Name = "lbProductInfo";
            this.lbProductInfo.Size = new System.Drawing.Size(354, 42);
            this.lbProductInfo.TabIndex = 1;
            this.lbProductInfo.Text = "Thông tin sản phẩm";
            // 
            // lbStatus
            // 
            this.lbStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.Black;
            this.lbStatus.Location = new System.Drawing.Point(625, 535);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(164, 27);
            this.lbStatus.TabIndex = 5;
            this.lbStatus.Text = "Trạng thái";
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(749, 540);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(256, 22);
            this.tbStatus.TabIndex = 5;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(516, 642);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(107, 34);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // lbImage
            // 
            this.lbImage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImage.ForeColor = System.Drawing.Color.Black;
            this.lbImage.Location = new System.Drawing.Point(625, 576);
            this.lbImage.Name = "lbImage";
            this.lbImage.Size = new System.Drawing.Size(164, 27);
            this.lbImage.TabIndex = 21;
            this.lbImage.Text = "Hình ảnh";
            // 
            // tbImage
            // 
            this.tbImage.Location = new System.Drawing.Point(749, 581);
            this.tbImage.Name = "tbImage";
            this.tbImage.Size = new System.Drawing.Size(256, 22);
            this.tbImage.TabIndex = 20;
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.DarkOrange;
            this.btnInsert.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(380, 642);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(107, 34);
            this.btnInsert.TabIndex = 17;
            this.btnInsert.Text = "Thêm";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkOrange;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(649, 642);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 34);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // lbProductName
            // 
            this.lbProductName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductName.ForeColor = System.Drawing.Color.Black;
            this.lbProductName.Location = new System.Drawing.Point(153, 532);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(175, 28);
            this.lbProductName.TabIndex = 1;
            this.lbProductName.Text = "Tên sản phẩm";
            // 
            // lbPrice
            // 
            this.lbPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.ForeColor = System.Drawing.Color.Black;
            this.lbPrice.Location = new System.Drawing.Point(153, 575);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(175, 34);
            this.lbPrice.TabIndex = 3;
            this.lbPrice.Text = "Giá sản phẩm";
            // 
            // tbProductName
            // 
            this.tbProductName.Location = new System.Drawing.Point(323, 538);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(237, 22);
            this.tbProductName.TabIndex = 1;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(323, 581);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(237, 22);
            this.tbPrice.TabIndex = 3;
            // 
            // lbProductID
            // 
            this.lbProductID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductID.ForeColor = System.Drawing.Color.Black;
            this.lbProductID.Location = new System.Drawing.Point(153, 491);
            this.lbProductID.Name = "lbProductID";
            this.lbProductID.Size = new System.Drawing.Size(175, 28);
            this.lbProductID.TabIndex = 0;
            this.lbProductID.Text = "Mã sản phẩm";
            // 
            // lbType
            // 
            this.lbType.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.ForeColor = System.Drawing.Color.Black;
            this.lbType.Location = new System.Drawing.Point(625, 491);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(75, 28);
            this.lbType.TabIndex = 4;
            this.lbType.Text = "Loại";
            // 
            // tbProductID
            // 
            this.tbProductID.Location = new System.Drawing.Point(323, 497);
            this.tbProductID.Name = "tbProductID";
            this.tbProductID.Size = new System.Drawing.Size(237, 22);
            this.tbProductID.TabIndex = 0;
            // 
            // tbType
            // 
            this.tbType.Location = new System.Drawing.Point(749, 497);
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(256, 22);
            this.tbType.TabIndex = 4;
            // 
            // UC_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearchMenu);
            this.Controls.Add(this.tbSearchMenu);
            this.Controls.Add(this.dgvMenu);
            this.Controls.Add(this.lbMenu);
            this.Controls.Add(this.tbImage);
            this.Controls.Add(this.lbImage);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbProductName);
            this.Controls.Add(this.tbProductID);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbProductName);
            this.Controls.Add(this.lbProductID);
            this.Controls.Add(this.lbProductInfo);
            this.Name = "UC_Menu";
            this.Size = new System.Drawing.Size(1139, 754);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchMenu;
        private System.Windows.Forms.TextBox tbSearchMenu;
        private System.Windows.Forms.DataGridView dgvMenu;
        private System.Windows.Forms.Label lbMenu;
        private System.Windows.Forms.Label lbProductInfo;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lbImage;
        private System.Windows.Forms.TextBox tbImage;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lbProductName;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label lbProductID;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.TextBox tbProductID;
        private System.Windows.Forms.TextBox tbType;
    }
}
