namespace MetaConstructor
{
    partial class frmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ColumnHeader chProp;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.detailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tvObjects = new System.Windows.Forms.TreeView();
            this.contextMenuObjects = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItemMO = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItemMO = new System.Windows.Forms.ToolStripMenuItem();
            this.toRootToolStripMenuItemMO = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItemMO = new System.Windows.Forms.ToolStripMenuItem();
            this.smImages = new System.Windows.Forms.ImageList(this.components);
            this.lvProperties = new System.Windows.Forms.ListView();
            this.chPropType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPropValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuProperties = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.mainStatusPict = new System.Windows.Forms.PictureBox();
            this.mainStatusText = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            chProp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.detailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.contextMenuObjects.SuspendLayout();
            this.contextMenuProperties.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainStatusPict)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // chProp
            // 
            chProp.Text = "";
            chProp.Width = 20;
            // 
            // detailsBindingSource
            // 
            this.detailsBindingSource.DataSource = this.masterBindingSource;
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.tvObjects);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.lvProperties);
            this.mainSplitContainer.Size = new System.Drawing.Size(468, 334);
            this.mainSplitContainer.SplitterDistance = 218;
            this.mainSplitContainer.TabIndex = 1;
            this.mainSplitContainer.TabStop = false;
            // 
            // tvObjects
            // 
            this.tvObjects.AllowDrop = true;
            this.tvObjects.ContextMenuStrip = this.contextMenuObjects;
            this.tvObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvObjects.ImageIndex = 0;
            this.tvObjects.ImageList = this.smImages;
            this.tvObjects.Location = new System.Drawing.Point(0, 0);
            this.tvObjects.Name = "tvObjects";
            this.tvObjects.SelectedImageIndex = 0;
            this.tvObjects.Size = new System.Drawing.Size(218, 334);
            this.tvObjects.TabIndex = 2;
            this.tvObjects.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvObjects_ItemDrag);
            this.tvObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvObjects_AfterSelect);
            this.tvObjects.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvObjects_DragDrop);
            this.tvObjects.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvObjects_DragEnter);
            this.tvObjects.DragOver += new System.Windows.Forms.DragEventHandler(this.tvObjects_DragOver);
            // 
            // contextMenuObjects
            // 
            this.contextMenuObjects.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItemMO,
            this.editToolStripMenuItemMO,
            this.toRootToolStripMenuItemMO,
            this.deleteToolStripMenuItemMO});
            this.contextMenuObjects.Name = "contextMenuObjects";
            this.contextMenuObjects.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuObjects.ShowImageMargin = false;
            this.contextMenuObjects.Size = new System.Drawing.Size(99, 92);
            // 
            // addToolStripMenuItemMO
            // 
            this.addToolStripMenuItemMO.Name = "addToolStripMenuItemMO";
            this.addToolStripMenuItemMO.Size = new System.Drawing.Size(98, 22);
            this.addToolStripMenuItemMO.Text = "Add";
            this.addToolStripMenuItemMO.Click += new System.EventHandler(this.addToolStripMenuItemMO_Click);
            // 
            // editToolStripMenuItemMO
            // 
            this.editToolStripMenuItemMO.Name = "editToolStripMenuItemMO";
            this.editToolStripMenuItemMO.Size = new System.Drawing.Size(98, 22);
            this.editToolStripMenuItemMO.Text = "Edit";
            this.editToolStripMenuItemMO.Click += new System.EventHandler(this.editToolStripMenuItemMO_Click);
            // 
            // toRootToolStripMenuItemMO
            // 
            this.toRootToolStripMenuItemMO.Name = "toRootToolStripMenuItemMO";
            this.toRootToolStripMenuItemMO.Size = new System.Drawing.Size(98, 22);
            this.toRootToolStripMenuItemMO.Text = "To Root";
            this.toRootToolStripMenuItemMO.Click += new System.EventHandler(this.toRootToolStripMenuItemMO_Click);
            // 
            // deleteToolStripMenuItemMO
            // 
            this.deleteToolStripMenuItemMO.Name = "deleteToolStripMenuItemMO";
            this.deleteToolStripMenuItemMO.Size = new System.Drawing.Size(98, 22);
            this.deleteToolStripMenuItemMO.Text = "Delete";
            this.deleteToolStripMenuItemMO.Click += new System.EventHandler(this.deleteToolStripMenuItemMO_Click);
            // 
            // smImages
            // 
            this.smImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smImages.ImageStream")));
            this.smImages.TransparentColor = System.Drawing.Color.Transparent;
            this.smImages.Images.SetKeyName(0, "CircleSelected.png");
            this.smImages.Images.SetKeyName(1, "CircleWhite.png");
            this.smImages.Images.SetKeyName(2, "CircleField.png");
            this.smImages.Images.SetKeyName(3, "CircleGold.png");
            this.smImages.Images.SetKeyName(4, "CircleRed.png");
            this.smImages.Images.SetKeyName(5, "CircleBlue.png");
            this.smImages.Images.SetKeyName(6, "CircleLime.png");
            this.smImages.Images.SetKeyName(7, "CircleGreen.png");
            this.smImages.Images.SetKeyName(8, "CircleNavy.png");
            this.smImages.Images.SetKeyName(9, "CircleViolet.png");
            // 
            // lvProperties
            // 
            this.lvProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            chProp,
            this.chPropType,
            this.chPropValue});
            this.lvProperties.ContextMenuStrip = this.contextMenuProperties;
            this.lvProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProperties.FullRowSelect = true;
            this.lvProperties.GridLines = true;
            this.lvProperties.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvProperties.Location = new System.Drawing.Point(0, 0);
            this.lvProperties.Name = "lvProperties";
            this.lvProperties.Size = new System.Drawing.Size(246, 334);
            this.lvProperties.SmallImageList = this.smImages;
            this.lvProperties.TabIndex = 3;
            this.lvProperties.UseCompatibleStateImageBehavior = false;
            this.lvProperties.View = System.Windows.Forms.View.Details;
            this.lvProperties.DoubleClick += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // chPropType
            // 
            this.chPropType.Text = "Property";
            this.chPropType.Width = 100;
            // 
            // chPropValue
            // 
            this.chPropValue.Text = "Value";
            this.chPropValue.Width = 120;
            // 
            // contextMenuProperties
            // 
            this.contextMenuProperties.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuProperties.Name = "contextMenuProperties";
            this.contextMenuProperties.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuProperties.ShowImageMargin = false;
            this.contextMenuProperties.Size = new System.Drawing.Size(92, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.mainStatusPict);
            this.panelButtons.Controls.Add(this.mainStatusText);
            this.panelButtons.Controls.Add(this.btnNew);
            this.panelButtons.Controls.Add(this.btnLoad);
            this.panelButtons.Controls.Add(this.btnExport);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(3, 337);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.panelButtons.Size = new System.Drawing.Size(468, 30);
            this.panelButtons.TabIndex = 4;
            // 
            // mainStatusPict
            // 
            this.mainStatusPict.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainStatusPict.Image = global::MetaConstructor.Properties.Resources.CircleWhite;
            this.mainStatusPict.InitialImage = global::MetaConstructor.Properties.Resources.CircleWhite;
            this.mainStatusPict.Location = new System.Drawing.Point(3, 3);
            this.mainStatusPict.Margin = new System.Windows.Forms.Padding(0);
            this.mainStatusPict.Name = "mainStatusPict";
            this.mainStatusPict.Size = new System.Drawing.Size(15, 24);
            this.mainStatusPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mainStatusPict.TabIndex = 13;
            this.mainStatusPict.TabStop = false;
            // 
            // mainStatusText
            // 
            this.mainStatusText.AutoSize = true;
            this.mainStatusText.Location = new System.Drawing.Point(20, 9);
            this.mainStatusText.Margin = new System.Windows.Forms.Padding(3);
            this.mainStatusText.Name = "mainStatusText";
            this.mainStatusText.Size = new System.Drawing.Size(16, 13);
            this.mainStatusText.TabIndex = 10;
            this.mainStatusText.Text = "   ";
            this.mainStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mainStatusText.TextChanged += new System.EventHandler(this.mainStatusText_TextChanged);
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNew.Location = new System.Drawing.Point(-12, 3);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 24);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "Create";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLoad.Location = new System.Drawing.Point(68, 3);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 24);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Open";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(148, 3);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 24);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Location = new System.Drawing.Point(228, 3);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 24);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(308, 3);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 24);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(388, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 24);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.mainSplitContainer);
            this.mainPanel.Controls.Add(this.panelButtons);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(3, 3);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(3);
            this.mainPanel.Size = new System.Drawing.Size(476, 372);
            this.mainPanel.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(482, 378);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Constructor";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterBindingSource)).EndInit();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.contextMenuObjects.ResumeLayout(false);
            this.contextMenuProperties.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainStatusPict)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource masterBindingSource;
        private System.Windows.Forms.BindingSource detailsBindingSource;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.TreeView tvObjects;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ImageList smImages;
        private System.Windows.Forms.ListView lvProperties;
        private System.Windows.Forms.ColumnHeader chPropType;
        private System.Windows.Forms.ColumnHeader chPropValue;
        private System.Windows.Forms.ContextMenuStrip contextMenuProperties;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label mainStatusText;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.PictureBox mainStatusPict;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuObjects;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItemMO;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItemMO;
        private System.Windows.Forms.ToolStripMenuItem toRootToolStripMenuItemMO;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItemMO;
    }
}

