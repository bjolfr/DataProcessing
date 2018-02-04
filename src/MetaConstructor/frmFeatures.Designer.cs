namespace MetaConstructor
{
    partial class frmFeatures
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
            this.panelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panelObject = new System.Windows.Forms.FlowLayoutPanel();
            this.pictObject = new System.Windows.Forms.PictureBox();
            this.labelObject = new System.Windows.Forms.Label();
            this.tbObject = new System.Windows.Forms.Label();
            this.btnObject = new System.Windows.Forms.Button();
            this.panelFKind = new System.Windows.Forms.FlowLayoutPanel();
            this.pictFKind = new System.Windows.Forms.PictureBox();
            this.labelFKind = new System.Windows.Forms.Label();
            this.tbFKind = new System.Windows.Forms.Label();
            this.btnFKind = new System.Windows.Forms.Button();
            this.panelFVal = new System.Windows.Forms.FlowLayoutPanel();
            this.pictFVal = new System.Windows.Forms.PictureBox();
            this.labelFVal = new System.Windows.Forms.Label();
            this.tbFVal = new System.Windows.Forms.Label();
            this.btnFVal = new System.Windows.Forms.Button();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictObject)).BeginInit();
            this.panelFKind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictFKind)).BeginInit();
            this.panelFVal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictFVal)).BeginInit();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelObject);
            this.panelMain.Controls.Add(this.panelFKind);
            this.panelMain.Controls.Add(this.panelFVal);
            this.panelMain.Controls.Add(this.panelActions);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(287, 118);
            this.panelMain.TabIndex = 0;
            // 
            // panelObject
            // 
            this.panelObject.Controls.Add(this.pictObject);
            this.panelObject.Controls.Add(this.labelObject);
            this.panelObject.Controls.Add(this.tbObject);
            this.panelObject.Controls.Add(this.btnObject);
            this.panelObject.Location = new System.Drawing.Point(3, 3);
            this.panelObject.Name = "panelObject";
            this.panelObject.Size = new System.Drawing.Size(280, 20);
            this.panelObject.TabIndex = 0;
            // 
            // pictObject
            // 
            this.pictObject.Image = global::MetaConstructor.Properties.Resources.CircleGold;
            this.pictObject.Location = new System.Drawing.Point(0, 0);
            this.pictObject.Margin = new System.Windows.Forms.Padding(0);
            this.pictObject.Name = "pictObject";
            this.pictObject.Size = new System.Drawing.Size(20, 20);
            this.pictObject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictObject.TabIndex = 7;
            this.pictObject.TabStop = false;
            // 
            // labelObject
            // 
            this.labelObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelObject.Location = new System.Drawing.Point(20, 3);
            this.labelObject.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.labelObject.Name = "labelObject";
            this.labelObject.Size = new System.Drawing.Size(60, 13);
            this.labelObject.TabIndex = 0;
            this.labelObject.Text = "Object:";
            // 
            // tbObject
            // 
            this.tbObject.BackColor = System.Drawing.SystemColors.Window;
            this.tbObject.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbObject.Location = new System.Drawing.Point(83, 0);
            this.tbObject.Margin = new System.Windows.Forms.Padding(0);
            this.tbObject.Name = "tbObject";
            this.tbObject.Size = new System.Drawing.Size(177, 20);
            this.tbObject.TabIndex = 10;
            this.tbObject.Text = "select element";
            this.tbObject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnObject
            // 
            this.btnObject.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnObject.Location = new System.Drawing.Point(260, 0);
            this.btnObject.Margin = new System.Windows.Forms.Padding(0);
            this.btnObject.Name = "btnObject";
            this.btnObject.Size = new System.Drawing.Size(20, 20);
            this.btnObject.TabIndex = 1;
            this.btnObject.Text = "...";
            this.btnObject.UseVisualStyleBackColor = true;
            this.btnObject.Click += new System.EventHandler(this.SelectElemInCatalog);
            // 
            // panelFKind
            // 
            this.panelFKind.Controls.Add(this.pictFKind);
            this.panelFKind.Controls.Add(this.labelFKind);
            this.panelFKind.Controls.Add(this.tbFKind);
            this.panelFKind.Controls.Add(this.btnFKind);
            this.panelFKind.Location = new System.Drawing.Point(3, 29);
            this.panelFKind.Name = "panelFKind";
            this.panelFKind.Size = new System.Drawing.Size(280, 20);
            this.panelFKind.TabIndex = 0;
            // 
            // pictFKind
            // 
            this.pictFKind.Image = global::MetaConstructor.Properties.Resources.CircleField;
            this.pictFKind.Location = new System.Drawing.Point(10, 0);
            this.pictFKind.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pictFKind.Name = "pictFKind";
            this.pictFKind.Size = new System.Drawing.Size(20, 20);
            this.pictFKind.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictFKind.TabIndex = 8;
            this.pictFKind.TabStop = false;
            // 
            // labelFKind
            // 
            this.labelFKind.Location = new System.Drawing.Point(33, 3);
            this.labelFKind.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.labelFKind.Name = "labelFKind";
            this.labelFKind.Size = new System.Drawing.Size(60, 13);
            this.labelFKind.TabIndex = 0;
            this.labelFKind.Text = "Type:";
            // 
            // tbFKind
            // 
            this.tbFKind.BackColor = System.Drawing.SystemColors.Info;
            this.tbFKind.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbFKind.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbFKind.Location = new System.Drawing.Point(93, 0);
            this.tbFKind.Margin = new System.Windows.Forms.Padding(0);
            this.tbFKind.Name = "tbFKind";
            this.tbFKind.Size = new System.Drawing.Size(167, 20);
            this.tbFKind.TabIndex = 9;
            this.tbFKind.Text = "select element";
            this.tbFKind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbFKind.DoubleClick += new System.EventHandler(this.SelectElemInCatalog);
            // 
            // btnFKind
            // 
            this.btnFKind.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFKind.Location = new System.Drawing.Point(260, 0);
            this.btnFKind.Margin = new System.Windows.Forms.Padding(0);
            this.btnFKind.Name = "btnFKind";
            this.btnFKind.Size = new System.Drawing.Size(20, 20);
            this.btnFKind.TabIndex = 4;
            this.btnFKind.Text = "...";
            this.btnFKind.UseVisualStyleBackColor = true;
            this.btnFKind.Click += new System.EventHandler(this.SelectElemInCatalog);
            // 
            // panelFVal
            // 
            this.panelFVal.Controls.Add(this.pictFVal);
            this.panelFVal.Controls.Add(this.labelFVal);
            this.panelFVal.Controls.Add(this.tbFVal);
            this.panelFVal.Controls.Add(this.btnFVal);
            this.panelFVal.Location = new System.Drawing.Point(3, 55);
            this.panelFVal.Name = "panelFVal";
            this.panelFVal.Size = new System.Drawing.Size(280, 20);
            this.panelFVal.TabIndex = 2;
            // 
            // pictFVal
            // 
            this.pictFVal.Image = global::MetaConstructor.Properties.Resources.CircleField;
            this.pictFVal.Location = new System.Drawing.Point(10, 0);
            this.pictFVal.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pictFVal.Name = "pictFVal";
            this.pictFVal.Size = new System.Drawing.Size(20, 20);
            this.pictFVal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictFVal.TabIndex = 8;
            this.pictFVal.TabStop = false;
            // 
            // labelFVal
            // 
            this.labelFVal.Location = new System.Drawing.Point(33, 3);
            this.labelFVal.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.labelFVal.Name = "labelFVal";
            this.labelFVal.Size = new System.Drawing.Size(60, 13);
            this.labelFVal.TabIndex = 0;
            this.labelFVal.Text = "Value:";
            // 
            // tbFVal
            // 
            this.tbFVal.BackColor = System.Drawing.SystemColors.Info;
            this.tbFVal.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbFVal.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbFVal.Location = new System.Drawing.Point(93, 0);
            this.tbFVal.Margin = new System.Windows.Forms.Padding(0);
            this.tbFVal.Name = "tbFVal";
            this.tbFVal.Size = new System.Drawing.Size(167, 20);
            this.tbFVal.TabIndex = 10;
            this.tbFVal.Text = "select element";
            this.tbFVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbFVal.DoubleClick += new System.EventHandler(this.SelectElemInCatalog);
            // 
            // btnFVal
            // 
            this.btnFVal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFVal.Location = new System.Drawing.Point(260, 0);
            this.btnFVal.Margin = new System.Windows.Forms.Padding(0);
            this.btnFVal.Name = "btnFVal";
            this.btnFVal.Size = new System.Drawing.Size(20, 20);
            this.btnFVal.TabIndex = 6;
            this.btnFVal.Text = "...";
            this.btnFVal.UseVisualStyleBackColor = true;
            this.btnFVal.Click += new System.EventHandler(this.SelectElemInCatalog);
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.btnOK);
            this.panelActions.Controls.Add(this.btnCancel);
            this.panelActions.Controls.Add(this.btnSave);
            this.panelActions.Location = new System.Drawing.Point(3, 81);
            this.panelActions.Name = "panelActions";
            this.panelActions.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.panelActions.Size = new System.Drawing.Size(279, 30);
            this.panelActions.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(39, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 24);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.SaveChanges);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(119, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(199, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 24);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Apply";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.SaveChanges);
            // 
            // frmFeatures
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(287, 118);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmFeatures";
            this.Text = "Properties";
            this.panelMain.ResumeLayout(false);
            this.panelObject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictObject)).EndInit();
            this.panelFKind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictFKind)).EndInit();
            this.panelFVal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictFVal)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panelFKind;
        private System.Windows.Forms.Label labelFKind;
        private System.Windows.Forms.Button btnFKind;
        private System.Windows.Forms.FlowLayoutPanel panelObject;
        private System.Windows.Forms.Label labelObject;
        private System.Windows.Forms.Button btnObject;
        private System.Windows.Forms.FlowLayoutPanel panelFVal;
        private System.Windows.Forms.Label labelFVal;
        private System.Windows.Forms.Button btnFVal;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox pictObject;
        private System.Windows.Forms.PictureBox pictFKind;
        private System.Windows.Forms.PictureBox pictFVal;
        private System.Windows.Forms.Label tbFKind;
        private System.Windows.Forms.Label tbObject;
        private System.Windows.Forms.Label tbFVal;

    }
}