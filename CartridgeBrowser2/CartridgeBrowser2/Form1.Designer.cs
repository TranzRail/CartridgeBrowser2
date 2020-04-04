namespace CartridgeBrowser2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectFolderButton = new System.Windows.Forms.Button();
            this.searchTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.totalSizeText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.numCartridgesText = new System.Windows.Forms.ToolStripStatusLabel();
            this.fastObjectListView1 = new BrightIdeasSoftware.FastObjectListView();
            this._fnameCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._fextCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._fsizeCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._hashCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._ctimeCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._bcodeCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._volnameCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._voluuidCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._fpathCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.selectFolderButton);
            this.groupBox1.Controls.Add(this.searchTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1240, 42);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFolderButton.Location = new System.Drawing.Point(1125, 11);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(109, 23);
            this.selectFolderButton.TabIndex = 2;
            this.selectFolderButton.Text = "Select Folder";
            this.selectFolderButton.UseVisualStyleBackColor = true;
            this.selectFolderButton.Click += new System.EventHandler(this.SelectFolderButton_Click);
            // 
            // searchTextbox
            // 
            this.searchTextbox.Location = new System.Drawing.Point(53, 13);
            this.searchTextbox.Name = "searchTextbox";
            this.searchTextbox.Size = new System.Drawing.Size(316, 20);
            this.searchTextbox.TabIndex = 1;
            this.searchTextbox.TextChanged += new System.EventHandler(this.SearchTextbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.totalSizeText,
            this.toolStripStatusLabel3,
            this.numCartridgesText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 707);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "Total Size:";
            // 
            // totalSizeText
            // 
            this.totalSizeText.Name = "totalSizeText";
            this.totalSizeText.Size = new System.Drawing.Size(40, 17);
            this.totalSizeText.Text = "0.0 GB";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(108, 17);
            this.toolStripStatusLabel3.Text = "Num of Cartridges:";
            // 
            // numCartridgesText
            // 
            this.numCartridgesText.Name = "numCartridgesText";
            this.numCartridgesText.Size = new System.Drawing.Size(13, 17);
            this.numCartridgesText.Text = "0";
            // 
            // fastObjectListView1
            // 
            this.fastObjectListView1.AllColumns.Add(this._fnameCol);
            this.fastObjectListView1.AllColumns.Add(this._fextCol);
            this.fastObjectListView1.AllColumns.Add(this._fsizeCol);
            this.fastObjectListView1.AllColumns.Add(this._hashCol);
            this.fastObjectListView1.AllColumns.Add(this._ctimeCol);
            this.fastObjectListView1.AllColumns.Add(this._bcodeCol);
            this.fastObjectListView1.AllColumns.Add(this._fpathCol);
            this.fastObjectListView1.AllColumns.Add(this._volnameCol);
            this.fastObjectListView1.AllColumns.Add(this._voluuidCol);
            this.fastObjectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fastObjectListView1.CellEditUseWholeCell = false;
            this.fastObjectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._fnameCol,
            this._fextCol,
            this._fsizeCol,
            this._hashCol,
            this._ctimeCol,
            this._bcodeCol,
            this._fpathCol});
            this.fastObjectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListView1.FullRowSelect = true;
            this.fastObjectListView1.GridLines = true;
            this.fastObjectListView1.HideSelection = false;
            this.fastObjectListView1.Location = new System.Drawing.Point(12, 60);
            this.fastObjectListView1.Name = "fastObjectListView1";
            this.fastObjectListView1.ShowGroups = false;
            this.fastObjectListView1.Size = new System.Drawing.Size(1240, 644);
            this.fastObjectListView1.TabIndex = 4;
            this.fastObjectListView1.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView1.View = System.Windows.Forms.View.Details;
            this.fastObjectListView1.VirtualMode = true;
            // 
            // _fnameCol
            // 
            this._fnameCol.AspectName = "Filename";
            this._fnameCol.IsEditable = false;
            this._fnameCol.Text = "Filename";
            this._fnameCol.UseInitialLetterForGroup = true;
            this._fnameCol.Width = 420;
            // 
            // _fextCol
            // 
            this._fextCol.AspectName = "FileExtension";
            this._fextCol.IsEditable = false;
            this._fextCol.Searchable = false;
            this._fextCol.Text = "Type";
            this._fextCol.Width = 40;
            // 
            // _fsizeCol
            // 
            this._fsizeCol.AspectName = "FileSize";
            this._fsizeCol.Groupable = false;
            this._fsizeCol.IsEditable = false;
            this._fsizeCol.Searchable = false;
            this._fsizeCol.Text = "Size";
            this._fsizeCol.Width = 80;
            // 
            // _hashCol
            // 
            this._hashCol.AspectName = "CRC32Hash";
            this._hashCol.Groupable = false;
            this._hashCol.IsEditable = false;
            this._hashCol.Text = "CRC32";
            this._hashCol.Width = 80;
            // 
            // _ctimeCol
            // 
            this._ctimeCol.AspectName = "CreationTime";
            this._ctimeCol.Groupable = false;
            this._ctimeCol.IsEditable = false;
            this._ctimeCol.Searchable = false;
            this._ctimeCol.Text = "Creation Time";
            this._ctimeCol.Width = 140;
            // 
            // _bcodeCol
            // 
            this._bcodeCol.AspectName = "Barcode";
            this._bcodeCol.IsEditable = false;
            this._bcodeCol.IsTileViewColumn = true;
            this._bcodeCol.Searchable = false;
            this._bcodeCol.Text = "Barcode";
            // 
            // _volnameCol
            // 
            this._volnameCol.AspectName = "VolumeName";
            this._volnameCol.DisplayIndex = 7;
            this._volnameCol.IsEditable = false;
            this._volnameCol.IsVisible = false;
            this._volnameCol.Searchable = false;
            this._volnameCol.Text = "Vol Name";
            this._volnameCol.Width = 160;
            // 
            // _voluuidCol
            // 
            this._voluuidCol.AspectName = "VolumeUUID";
            this._voluuidCol.DisplayIndex = 8;
            this._voluuidCol.IsEditable = false;
            this._voluuidCol.IsVisible = false;
            this._voluuidCol.Searchable = false;
            this._voluuidCol.Text = "Vol UUID";
            this._voluuidCol.Width = 220;
            // 
            // _fpathCol
            // 
            this._fpathCol.AspectName = "Filepath";
            this._fpathCol.IsEditable = false;
            this._fpathCol.Searchable = false;
            this._fpathCol.Text = "Path";
            this._fpathCol.Width = 360;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 729);
            this.Controls.Add(this.fastObjectListView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Cartridge Browser - © Shaun Overton 2019";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTextbox;
        private System.Windows.Forms.Button selectFolderButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel totalSizeText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel numCartridgesText;
        private BrightIdeasSoftware.FastObjectListView fastObjectListView1;
        private BrightIdeasSoftware.OLVColumn _fnameCol;
        private BrightIdeasSoftware.OLVColumn _fextCol;
        private BrightIdeasSoftware.OLVColumn _fsizeCol;
        private BrightIdeasSoftware.OLVColumn _hashCol;
        private BrightIdeasSoftware.OLVColumn _ctimeCol;
        private BrightIdeasSoftware.OLVColumn _bcodeCol;
        private BrightIdeasSoftware.OLVColumn _volnameCol;
        private BrightIdeasSoftware.OLVColumn _voluuidCol;
        private BrightIdeasSoftware.OLVColumn _fpathCol;
    }
}

