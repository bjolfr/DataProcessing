namespace MetaConstructor
{
    partial class frmCatalogList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCatalogList));
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tvObjects = new System.Windows.Forms.TreeView();
            this.smImages = new System.Windows.Forms.ImageList(this.components);
            this.lvProperties = new System.Windows.Forms.ListView();
            this.chCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDescr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuReference = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.catalogStatusText = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.contextMenuReference.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.tvObjects);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.lvProperties);
            this.mainSplitContainer.Size = new System.Drawing.Size(482, 335);
            this.mainSplitContainer.SplitterDistance = 174;
            this.mainSplitContainer.TabIndex = 0;
            this.mainSplitContainer.TabStop = false;
            // 
            // tvObjects
            // 
            this.tvObjects.AllowDrop = true;
            this.tvObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvObjects.ImageIndex = 0;
            this.tvObjects.ImageList = this.smImages;
            this.tvObjects.Location = new System.Drawing.Point(0, 0);
            this.tvObjects.Name = "tvObjects";
            this.tvObjects.SelectedImageIndex = 0;
            this.tvObjects.Size = new System.Drawing.Size(174, 335);
            this.tvObjects.TabIndex = 1;
            this.tvObjects.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvObjects_ItemDrag);
            this.tvObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvObjects_AfterSelect);
            this.tvObjects.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvObjects_DragDrop);
            this.tvObjects.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvObjects_DragEnter);
            this.tvObjects.DragOver += new System.Windows.Forms.DragEventHandler(this.tvObjects_DragOver);
            // 
            // smImages
            // 
            this.smImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smImages.ImageStream")));
            this.smImages.TransparentColor = System.Drawing.Color.Transparent;
            this.smImages.Images.SetKeyName(0, "CircleSelected.png");
            this.smImages.Images.SetKeyName(1, "CircleWhite.png");
            this.smImages.Images.SetKeyName(2, "CircleField.png");
            this.smImages.Images.SetKeyName(3, "CircleGold.png");
            this.smImages.Images.SetKeyName(4, "CircleViolet.png");
            this.smImages.Images.SetKeyName(5, "CircleLime.png");
            this.smImages.Images.SetKeyName(6, "CircleRed.png");
            this.smImages.Images.SetKeyName(7, "CircleBlue.png");
            this.smImages.Images.SetKeyName(8, "CircleGreen.png");
            this.smImages.Images.SetKeyName(9, "CircleNavy.png");
            // 
            // lvProperties
            // 
            this.lvProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCode,
            this.chDescr});
            this.lvProperties.ContextMenuStrip = this.contextMenuReference;
            this.lvProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProperties.FullRowSelect = true;
            this.lvProperties.GridLines = true;
            this.lvProperties.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvProperties.Location = new System.Drawing.Point(0, 0);
            this.lvProperties.MultiSelect = false;
            this.lvProperties.Name = "lvProperties";
            this.lvProperties.Size = new System.Drawing.Size(304, 335);
            this.lvProperties.SmallImageList = this.smImages;
            this.lvProperties.TabIndex = 2;
            this.lvProperties.UseCompatibleStateImageBehavior = false;
            this.lvProperties.View = System.Windows.Forms.View.Details;
            this.lvProperties.SelectedIndexChanged += new System.EventHandler(this.lvProperties_SelectedIndexChanged);
            this.lvProperties.DoubleClick += new System.EventHandler(this.btnOK_Click);
            // 
            // chCode
            // 
            this.chCode.Text = "Code";
            this.chCode.Width = 80;
            // 
            // chDescr
            // 
            this.chDescr.Text = "Descr";
            this.chDescr.Width = 220;
            // 
            // contextMenuReference
            // 
            this.contextMenuReference.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuReference.Name = "contextMenuProperties";
            this.contextMenuReference.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuReference.ShowImageMargin = false;
            this.contextMenuReference.Size = new System.Drawing.Size(92, 70);
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
            this.panelButtons.Controls.Add(this.catalogStatusText);
            this.panelButtons.Controls.Add(this.btnOK);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 335);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.panelButtons.Size = new System.Drawing.Size(482, 30);
            this.panelButtons.TabIndex = 3;
            // 
            // catalogStatusText
            // 
            this.catalogStatusText.AutoSize = true;
            this.catalogStatusText.Location = new System.Drawing.Point(6, 9);
            this.catalogStatusText.Name = "catalogStatusText";
            this.catalogStatusText.Size = new System.Drawing.Size(0, 13);
            this.catalogStatusText.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(322, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 24);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(402, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmCatalogList
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(482, 365);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.panelButtons);
            this.Name = "frmCatalogList";
            this.Text = "Reference";
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.contextMenuReference.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.TreeView tvObjects;
        private System.Windows.Forms.ImageList smImages;
        private System.Windows.Forms.ListView lvProperties;
        private System.Windows.Forms.ColumnHeader chCode;
        private System.Windows.Forms.ColumnHeader chDescr;
        private System.Windows.Forms.ContextMenuStrip contextMenuReference;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label catalogStatusText;
    }
}

