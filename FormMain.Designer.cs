namespace FlickrAlbumSort
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnGetAlbums = new System.Windows.Forms.Button();
            this.dgvPhotosets = new System.Windows.Forms.DataGridView();
            this.bindingSourcePhotosets = new System.Windows.Forms.BindingSource(this.components);
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTakenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbLoginAccount = new System.Windows.Forms.ComboBox();
            this.btnAddLoginAccount = new System.Windows.Forms.Button();
            this.btnRemoveLoginAccount = new System.Windows.Forms.Button();
            this.titleDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTakenDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timePeriodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photosetTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photosetIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbSortOrder = new System.Windows.Forms.ComboBox();
            this.lblSortOrder = new System.Windows.Forms.Label();
            this.EnableSearch = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TItle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhotosets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePhotosets)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1026, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 30);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 34);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 30);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnSort
            // 
            this.btnSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSort.Location = new System.Drawing.Point(778, 95);
            this.btnSort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(112, 35);
            this.btnSort.TabIndex = 22;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnGetAlbums
            // 
            this.btnGetAlbums.Location = new System.Drawing.Point(19, 95);
            this.btnGetAlbums.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGetAlbums.Name = "btnGetAlbums";
            this.btnGetAlbums.Size = new System.Drawing.Size(112, 35);
            this.btnGetAlbums.TabIndex = 11;
            this.btnGetAlbums.Text = "Get Albums";
            this.btnGetAlbums.UseVisualStyleBackColor = true;
            this.btnGetAlbums.Click += new System.EventHandler(this.btnGetAlbums_Click);
            // 
            // dgvPhotosets
            // 
            this.dgvPhotosets.AllowUserToAddRows = false;
            this.dgvPhotosets.AllowUserToDeleteRows = false;
            this.dgvPhotosets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhotosets.AutoGenerateColumns = false;
            this.dgvPhotosets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPhotosets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhotosets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EnableSearch,
            this.TItle,
            this.StatusColumn,
            this.DateCreated,
            this.CountColumn,
            this.DescriptionColumn});
            this.dgvPhotosets.DataSource = this.bindingSourcePhotosets;
            this.dgvPhotosets.Location = new System.Drawing.Point(19, 158);
            this.dgvPhotosets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvPhotosets.Name = "dgvPhotosets";
            this.dgvPhotosets.RowHeadersVisible = false;
            this.dgvPhotosets.RowHeadersWidth = 62;
            this.dgvPhotosets.Size = new System.Drawing.Size(993, 480);
            this.dgvPhotosets.TabIndex = 12;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.Width = 52;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 85;
            // 
            // dateTakenDataGridViewTextBoxColumn
            // 
            this.dateTakenDataGridViewTextBoxColumn.DataPropertyName = "DateTaken";
            this.dateTakenDataGridViewTextBoxColumn.HeaderText = "DateTaken";
            this.dateTakenDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dateTakenDataGridViewTextBoxColumn.Name = "dateTakenDataGridViewTextBoxColumn";
            this.dateTakenDataGridViewTextBoxColumn.Width = 86;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Flickr login account:";
            // 
            // cbLoginAccount
            // 
            this.cbLoginAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoginAccount.FormattingEnabled = true;
            this.cbLoginAccount.Location = new System.Drawing.Point(207, 48);
            this.cbLoginAccount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLoginAccount.Name = "cbLoginAccount";
            this.cbLoginAccount.Size = new System.Drawing.Size(560, 28);
            this.cbLoginAccount.TabIndex = 3;
            this.cbLoginAccount.SelectedIndexChanged += new System.EventHandler(this.cbLoginAccount_SelectedIndexChanged);
            // 
            // btnAddLoginAccount
            // 
            this.btnAddLoginAccount.Location = new System.Drawing.Point(778, 45);
            this.btnAddLoginAccount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddLoginAccount.Name = "btnAddLoginAccount";
            this.btnAddLoginAccount.Size = new System.Drawing.Size(112, 35);
            this.btnAddLoginAccount.TabIndex = 4;
            this.btnAddLoginAccount.Text = "Add...";
            this.btnAddLoginAccount.UseVisualStyleBackColor = true;
            this.btnAddLoginAccount.Click += new System.EventHandler(this.btnAddLoginAccount_Click);
            // 
            // btnRemoveLoginAccount
            // 
            this.btnRemoveLoginAccount.Location = new System.Drawing.Point(900, 45);
            this.btnRemoveLoginAccount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemoveLoginAccount.Name = "btnRemoveLoginAccount";
            this.btnRemoveLoginAccount.Size = new System.Drawing.Size(112, 35);
            this.btnRemoveLoginAccount.TabIndex = 5;
            this.btnRemoveLoginAccount.Text = "Remove...";
            this.btnRemoveLoginAccount.UseVisualStyleBackColor = true;
            this.btnRemoveLoginAccount.Click += new System.EventHandler(this.btnRemoveLoginAccount_Click);
            // 
            // titleDataGridViewTextBoxColumn2
            // 
            this.titleDataGridViewTextBoxColumn2.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn2.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.titleDataGridViewTextBoxColumn2.Name = "titleDataGridViewTextBoxColumn2";
            this.titleDataGridViewTextBoxColumn2.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn2.Width = 52;
            // 
            // descriptionDataGridViewTextBoxColumn2
            // 
            this.descriptionDataGridViewTextBoxColumn2.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn2.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.descriptionDataGridViewTextBoxColumn2.Name = "descriptionDataGridViewTextBoxColumn2";
            this.descriptionDataGridViewTextBoxColumn2.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn2.Width = 85;
            // 
            // dateTakenDataGridViewTextBoxColumn1
            // 
            this.dateTakenDataGridViewTextBoxColumn1.DataPropertyName = "DateTaken";
            this.dateTakenDataGridViewTextBoxColumn1.HeaderText = "Date Taken";
            this.dateTakenDataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dateTakenDataGridViewTextBoxColumn1.Name = "dateTakenDataGridViewTextBoxColumn1";
            this.dateTakenDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dateTakenDataGridViewTextBoxColumn1.Width = 89;
            // 
            // timePeriodDataGridViewTextBoxColumn
            // 
            this.timePeriodDataGridViewTextBoxColumn.DataPropertyName = "TimePeriod";
            this.timePeriodDataGridViewTextBoxColumn.HeaderText = "Time of day";
            this.timePeriodDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.timePeriodDataGridViewTextBoxColumn.Name = "timePeriodDataGridViewTextBoxColumn";
            this.timePeriodDataGridViewTextBoxColumn.ReadOnly = true;
            this.timePeriodDataGridViewTextBoxColumn.Width = 87;
            // 
            // photosetTitleDataGridViewTextBoxColumn
            // 
            this.photosetTitleDataGridViewTextBoxColumn.DataPropertyName = "PhotosetTitle";
            this.photosetTitleDataGridViewTextBoxColumn.HeaderText = "Album";
            this.photosetTitleDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.photosetTitleDataGridViewTextBoxColumn.Name = "photosetTitleDataGridViewTextBoxColumn";
            this.photosetTitleDataGridViewTextBoxColumn.ReadOnly = true;
            this.photosetTitleDataGridViewTextBoxColumn.Width = 61;
            // 
            // photoIdDataGridViewTextBoxColumn
            // 
            this.photoIdDataGridViewTextBoxColumn.DataPropertyName = "PhotoId";
            this.photoIdDataGridViewTextBoxColumn.HeaderText = "Photo ID";
            this.photoIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.photoIdDataGridViewTextBoxColumn.Name = "photoIdDataGridViewTextBoxColumn";
            this.photoIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.photoIdDataGridViewTextBoxColumn.Width = 74;
            // 
            // photosetIdDataGridViewTextBoxColumn1
            // 
            this.photosetIdDataGridViewTextBoxColumn1.DataPropertyName = "PhotosetId";
            this.photosetIdDataGridViewTextBoxColumn1.HeaderText = "Album ID";
            this.photosetIdDataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.photosetIdDataGridViewTextBoxColumn1.Name = "photosetIdDataGridViewTextBoxColumn1";
            this.photosetIdDataGridViewTextBoxColumn1.ReadOnly = true;
            this.photosetIdDataGridViewTextBoxColumn1.Width = 75;
            // 
            // cbSortOrder
            // 
            this.cbSortOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSortOrder.FormattingEnabled = true;
            this.cbSortOrder.Location = new System.Drawing.Point(293, 99);
            this.cbSortOrder.Name = "cbSortOrder";
            this.cbSortOrder.Size = new System.Drawing.Size(240, 28);
            this.cbSortOrder.TabIndex = 23;
            this.cbSortOrder.SelectedIndexChanged += new System.EventHandler(this.cbSortOrder_SelectedIndexChanged);
            // 
            // lblSortOrder
            // 
            this.lblSortOrder.AutoSize = true;
            this.lblSortOrder.Location = new System.Drawing.Point(203, 102);
            this.lblSortOrder.Name = "lblSortOrder";
            this.lblSortOrder.Size = new System.Drawing.Size(84, 20);
            this.lblSortOrder.TabIndex = 24;
            this.lblSortOrder.Text = "Sort order:";
            // 
            // EnableSearch
            // 
            this.EnableSearch.DataPropertyName = "EnableSearch";
            this.EnableSearch.HeaderText = "";
            this.EnableSearch.MinimumWidth = 18;
            this.EnableSearch.Name = "EnableSearch";
            this.EnableSearch.Width = 18;
            // 
            // TItle
            // 
            this.TItle.DataPropertyName = "Title";
            this.TItle.HeaderText = "TItle";
            this.TItle.MinimumWidth = 8;
            this.TItle.Name = "TItle";
            this.TItle.ReadOnly = true;
            this.TItle.Width = 76;
            // 
            // StatusColumn
            // 
            this.StatusColumn.DataPropertyName = "Status";
            this.StatusColumn.HeaderText = "Status";
            this.StatusColumn.MinimumWidth = 8;
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            this.StatusColumn.Width = 92;
            // 
            // DateCreated
            // 
            this.DateCreated.DataPropertyName = "DateCreated";
            this.DateCreated.HeaderText = "Date Created";
            this.DateCreated.MinimumWidth = 8;
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.ReadOnly = true;
            this.DateCreated.Width = 141;
            // 
            // CountColumn
            // 
            this.CountColumn.DataPropertyName = "NumberOfPhotos";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CountColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.CountColumn.HeaderText = "Count";
            this.CountColumn.MinimumWidth = 8;
            this.CountColumn.Name = "CountColumn";
            this.CountColumn.ReadOnly = true;
            this.CountColumn.Width = 88;
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.DataPropertyName = "Description";
            this.DescriptionColumn.HeaderText = "Description";
            this.DescriptionColumn.MinimumWidth = 8;
            this.DescriptionColumn.Name = "DescriptionColumn";
            this.DescriptionColumn.ReadOnly = true;
            this.DescriptionColumn.Width = 125;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 652);
            this.Controls.Add(this.lblSortOrder);
            this.Controls.Add(this.cbSortOrder);
            this.Controls.Add(this.btnRemoveLoginAccount);
            this.Controls.Add(this.btnAddLoginAccount);
            this.Controls.Add(this.cbLoginAccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetAlbums);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgvPhotosets);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1039, 708);
            this.Name = "FormMain";
            this.Text = "Flickr Album Sort";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhotosets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePhotosets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnGetAlbums;
        private System.Windows.Forms.DataGridView dgvPhotosets;
        private System.Windows.Forms.BindingSource bindingSourcePhotosets;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTakenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTakenDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn timePeriodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn photosetTitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn photoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn photosetIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLoginAccount;
        private System.Windows.Forms.Button btnAddLoginAccount;
        private System.Windows.Forms.Button btnRemoveLoginAccount;
        private System.Windows.Forms.ComboBox cbSortOrder;
        private System.Windows.Forms.Label lblSortOrder;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EnableSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn TItle;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
    }
}

