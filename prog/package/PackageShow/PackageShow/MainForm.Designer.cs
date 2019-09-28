namespace PackageShow
{
    partial class PackageShowFormClass
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FactoryStation = new System.Windows.Forms.Label();
            this.GunReturnText = new System.Windows.Forms.TextBox();
            this.info_package = new System.Windows.Forms.DataGridView();
            this.PackageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalLayers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAreas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPlates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.package_label = new System.Windows.Forms.Label();
            this.PartInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.IndexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WidthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThickColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartInfoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.info_package)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartInfoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FactoryStation
            // 
            this.FactoryStation.AutoSize = true;
            this.FactoryStation.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FactoryStation.Location = new System.Drawing.Point(511, -2);
            this.FactoryStation.Name = "FactoryStation";
            this.FactoryStation.Size = new System.Drawing.Size(100, 29);
            this.FactoryStation.TabIndex = 0;
            this.FactoryStation.Text = "瀚海：";
            // 
            // GunReturnText
            // 
            this.GunReturnText.Location = new System.Drawing.Point(0, 43);
            this.GunReturnText.Name = "GunReturnText";
            this.GunReturnText.Size = new System.Drawing.Size(100, 21);
            this.GunReturnText.TabIndex = 1;
            this.GunReturnText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GunReturnText_KeyPress);
            // 
            // info_package
            // 
            this.info_package.AllowUserToAddRows = false;
            this.info_package.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.info_package.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PackageID,
            this.TotalLayers,
            this.TotalAreas,
            this.TotalPlates});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(237)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.info_package.DefaultCellStyle = dataGridViewCellStyle1;
            this.info_package.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.info_package.Location = new System.Drawing.Point(0, 96);
            this.info_package.Name = "info_package";
            this.info_package.ReadOnly = true;
            this.info_package.RowHeadersVisible = false;
            this.info_package.RowTemplate.Height = 23;
            this.info_package.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.info_package.Size = new System.Drawing.Size(278, 138);
            this.info_package.TabIndex = 3;
            this.info_package.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.info_package_CellMouseClick);
            // 
            // PackageID
            // 
            this.PackageID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PackageID.HeaderText = "编    号";
            this.PackageID.Name = "PackageID";
            this.PackageID.ReadOnly = true;
            this.PackageID.Width = 78;
            // 
            // TotalLayers
            // 
            this.TotalLayers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TotalLayers.HeaderText = "总层数";
            this.TotalLayers.Name = "TotalLayers";
            this.TotalLayers.ReadOnly = true;
            this.TotalLayers.Width = 66;
            // 
            // TotalAreas
            // 
            this.TotalAreas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TotalAreas.HeaderText = "总面积";
            this.TotalAreas.Name = "TotalAreas";
            this.TotalAreas.ReadOnly = true;
            this.TotalAreas.Width = 66;
            // 
            // TotalPlates
            // 
            this.TotalPlates.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TotalPlates.HeaderText = "总块数";
            this.TotalPlates.Name = "TotalPlates";
            this.TotalPlates.ReadOnly = true;
            this.TotalPlates.Width = 66;
            // 
            // package_label
            // 
            this.package_label.AutoSize = true;
            this.package_label.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.package_label.Location = new System.Drawing.Point(1098, 11);
            this.package_label.Name = "package_label";
            this.package_label.Size = new System.Drawing.Size(112, 16);
            this.package_label.TabIndex = 4;
            this.package_label.Text = "某某放置信息:";
            // 
            // PartInfoDataGridView
            // 
            this.PartInfoDataGridView.AllowUserToAddRows = false;
            this.PartInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PartInfoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IndexColumn,
            this.PartIdColumn,
            this.HeightColumn,
            this.WidthColumn,
            this.ThickColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(237)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PartInfoDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.PartInfoDataGridView.Location = new System.Drawing.Point(0, 407);
            this.PartInfoDataGridView.Name = "PartInfoDataGridView";
            this.PartInfoDataGridView.ReadOnly = true;
            this.PartInfoDataGridView.RowHeadersVisible = false;
            this.PartInfoDataGridView.RowTemplate.Height = 23;
            this.PartInfoDataGridView.Size = new System.Drawing.Size(278, 150);
            this.PartInfoDataGridView.TabIndex = 5;
            // 
            // IndexColumn
            // 
            this.IndexColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IndexColumn.HeaderText = "序号";
            this.IndexColumn.Name = "IndexColumn";
            this.IndexColumn.ReadOnly = true;
            this.IndexColumn.Width = 54;
            // 
            // PartIdColumn
            // 
            this.PartIdColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PartIdColumn.HeaderText = "部件号";
            this.PartIdColumn.Name = "PartIdColumn";
            this.PartIdColumn.ReadOnly = true;
            this.PartIdColumn.Width = 66;
            // 
            // HeightColumn
            // 
            this.HeightColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HeightColumn.HeaderText = "高度";
            this.HeightColumn.Name = "HeightColumn";
            this.HeightColumn.ReadOnly = true;
            this.HeightColumn.Width = 54;
            // 
            // WidthColumn
            // 
            this.WidthColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.WidthColumn.HeaderText = "宽度";
            this.WidthColumn.Name = "WidthColumn";
            this.WidthColumn.ReadOnly = true;
            this.WidthColumn.Width = 54;
            // 
            // ThickColumn
            // 
            this.ThickColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ThickColumn.HeaderText = "厚度";
            this.ThickColumn.Name = "ThickColumn";
            this.ThickColumn.ReadOnly = true;
            this.ThickColumn.Width = 54;
            // 
            // PartInfoLabel
            // 
            this.PartInfoLabel.AutoSize = true;
            this.PartInfoLabel.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PartInfoLabel.Location = new System.Drawing.Point(12, 374);
            this.PartInfoLabel.Name = "PartInfoLabel";
            this.PartInfoLabel.Size = new System.Drawing.Size(136, 16);
            this.PartInfoLabel.TabIndex = 6;
            this.PartInfoLabel.Text = "某某包部件信息：";
            // 
            // PackageShowFormClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 670);
            this.Controls.Add(this.PartInfoLabel);
            this.Controls.Add(this.PartInfoDataGridView);
            this.Controls.Add(this.package_label);
            this.Controls.Add(this.info_package);
            this.Controls.Add(this.GunReturnText);
            this.Controls.Add(this.FactoryStation);
            this.KeyPreview = true;
            this.Name = "PackageShowFormClass";
            this.Text = "MainForm";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PackageShowFormClass_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.info_package)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartInfoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FactoryStation;
        private System.Windows.Forms.TextBox GunReturnText;
        private System.Windows.Forms.DataGridView info_package;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalLayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAreas;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPlates;
        private System.Windows.Forms.Label package_label;
        private System.Windows.Forms.DataGridView PartInfoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeightColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WidthColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThickColumn;
        private System.Windows.Forms.Label PartInfoLabel;
    }
}

