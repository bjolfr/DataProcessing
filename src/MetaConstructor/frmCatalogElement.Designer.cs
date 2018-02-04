namespace MetaConstructor
{
    partial class frmCatalogElement
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
            this.panelElement = new System.Windows.Forms.FlowLayoutPanel();
            this.pictElement = new System.Windows.Forms.PictureBox();
            this.tbElement = new System.Windows.Forms.TextBox();
            this.btnElement = new System.Windows.Forms.Button();
            this.panelFieldCode = new System.Windows.Forms.FlowLayoutPanel();
            this.pictFieldCode = new System.Windows.Forms.PictureBox();
            this.labelFieldCode = new System.Windows.Forms.Label();
            this.tbFieldCode = new System.Windows.Forms.TextBox();
            this.panelFieldDescr = new System.Windows.Forms.FlowLayoutPanel();
            this.pictFieldDescr = new System.Windows.Forms.PictureBox();
            this.labelFieldDescr = new System.Windows.Forms.Label();
            this.tbFieldDescr = new System.Windows.Forms.TextBox();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelElement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictElement)).BeginInit();
            this.panelFieldCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictFieldCode)).BeginInit();
            this.panelFieldDescr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictFieldDescr)).BeginInit();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelElement);
            this.panelMain.Controls.Add(this.panelFieldCode);
            this.panelMain.Controls.Add(this.panelFieldDescr);
            this.panelMain.Controls.Add(this.panelActions);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(285, 116);
            this.panelMain.TabIndex = 1;
            // 
            // panelElement
            // 
            this.panelElement.Controls.Add(this.pictElement);
            this.panelElement.Controls.Add(this.tbElement);
            this.panelElement.Controls.Add(this.btnElement);
            this.panelElement.Location = new System.Drawing.Point(3, 3);
            this.panelElement.Name = "panelElement";
            this.panelElement.Size = new System.Drawing.Size(280, 20);
            this.panelElement.TabIndex = 0;
            // 
            // pictElement
            // 
            this.pictElement.Image = global::MetaConstructor.Properties.Resources.CircleGold;
            this.pictElement.Location = new System.Drawing.Point(0, 0);
            this.pictElement.Margin = new System.Windows.Forms.Padding(0);
            this.pictElement.Name = "pictElement";
            this.pictElement.Size = new System.Drawing.Size(20, 20);
            this.pictElement.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictElement.TabIndex = 7;
            this.pictElement.TabStop = false;
            // 
            // tbElement
            // 
            this.tbElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbElement.BackColor = System.Drawing.SystemColors.Window;
            this.tbElement.Enabled = false;
            this.tbElement.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbElement.Location = new System.Drawing.Point(20, 0);
            this.tbElement.Margin = new System.Windows.Forms.Padding(0);
            this.tbElement.Name = "tbElement";
            this.tbElement.ReadOnly = true;
            this.tbElement.Size = new System.Drawing.Size(240, 20);
            this.tbElement.TabIndex = 0;
            this.tbElement.TabStop = false;
            // 
            // btnElement
            // 
            this.btnElement.Enabled = false;
            this.btnElement.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnElement.Location = new System.Drawing.Point(260, 0);
            this.btnElement.Margin = new System.Windows.Forms.Padding(0);
            this.btnElement.Name = "btnElement";
            this.btnElement.Size = new System.Drawing.Size(20, 20);
            this.btnElement.TabIndex = 1;
            this.btnElement.TabStop = false;
            this.btnElement.Text = "...";
            this.btnElement.UseVisualStyleBackColor = true;
            // 
            // panelFieldCode
            // 
            this.panelFieldCode.Controls.Add(this.pictFieldCode);
            this.panelFieldCode.Controls.Add(this.labelFieldCode);
            this.panelFieldCode.Controls.Add(this.tbFieldCode);
            this.panelFieldCode.Location = new System.Drawing.Point(3, 29);
            this.panelFieldCode.Name = "panelFieldCode";
            this.panelFieldCode.Size = new System.Drawing.Size(280, 20);
            this.panelFieldCode.TabIndex = 1;
            // 
            // pictFieldCode
            // 
            this.pictFieldCode.Image = global::MetaConstructor.Properties.Resources.CircleField;
            this.pictFieldCode.Location = new System.Drawing.Point(10, 0);
            this.pictFieldCode.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pictFieldCode.Name = "pictFieldCode";
            this.pictFieldCode.Size = new System.Drawing.Size(20, 20);
            this.pictFieldCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictFieldCode.TabIndex = 0;
            this.pictFieldCode.TabStop = false;
            // 
            // labelFieldCode
            // 
            this.labelFieldCode.Location = new System.Drawing.Point(30, 3);
            this.labelFieldCode.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.labelFieldCode.Name = "labelFieldCode";
            this.labelFieldCode.Size = new System.Drawing.Size(70, 13);
            this.labelFieldCode.TabIndex = 1;
            this.labelFieldCode.Text = "Code:";
            // 
            // tbFieldCode
            // 
            this.tbFieldCode.BackColor = System.Drawing.SystemColors.Window;
            this.tbFieldCode.Location = new System.Drawing.Point(100, 0);
            this.tbFieldCode.Margin = new System.Windows.Forms.Padding(0);
            this.tbFieldCode.Name = "tbFieldCode";
            this.tbFieldCode.Size = new System.Drawing.Size(180, 20);
            this.tbFieldCode.TabIndex = 0;
            this.tbFieldCode.TextChanged += new System.EventHandler(this.TextIsChanged);
            // 
            // panelFieldDescr
            // 
            this.panelFieldDescr.Controls.Add(this.pictFieldDescr);
            this.panelFieldDescr.Controls.Add(this.labelFieldDescr);
            this.panelFieldDescr.Controls.Add(this.tbFieldDescr);
            this.panelFieldDescr.Location = new System.Drawing.Point(3, 55);
            this.panelFieldDescr.Name = "panelFieldDescr";
            this.panelFieldDescr.Size = new System.Drawing.Size(280, 20);
            this.panelFieldDescr.TabIndex = 2;
            // 
            // pictFieldDescr
            // 
            this.pictFieldDescr.Image = global::MetaConstructor.Properties.Resources.CircleField;
            this.pictFieldDescr.Location = new System.Drawing.Point(10, 0);
            this.pictFieldDescr.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pictFieldDescr.Name = "pictFieldDescr";
            this.pictFieldDescr.Size = new System.Drawing.Size(20, 20);
            this.pictFieldDescr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictFieldDescr.TabIndex = 8;
            this.pictFieldDescr.TabStop = false;
            // 
            // labelFieldDescr
            // 
            this.labelFieldDescr.Location = new System.Drawing.Point(30, 3);
            this.labelFieldDescr.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.labelFieldDescr.Name = "labelFieldDescr";
            this.labelFieldDescr.Size = new System.Drawing.Size(70, 13);
            this.labelFieldDescr.TabIndex = 0;
            this.labelFieldDescr.Text = "Descr:";
            // 
            // tbFieldDescr
            // 
            this.tbFieldDescr.BackColor = System.Drawing.SystemColors.Window;
            this.tbFieldDescr.Location = new System.Drawing.Point(100, 0);
            this.tbFieldDescr.Margin = new System.Windows.Forms.Padding(0);
            this.tbFieldDescr.Name = "tbFieldDescr";
            this.tbFieldDescr.Size = new System.Drawing.Size(180, 20);
            this.tbFieldDescr.TabIndex = 0;
            this.tbFieldDescr.TextChanged += new System.EventHandler(this.TextIsChanged);
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
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(119, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 1;
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
            this.btnSave.TabIndex = 2;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Apply";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmCatalogElement
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(285, 116);
            this.Controls.Add(this.panelMain);
            this.Name = "frmCatalogElement";
            this.Text = "Element";
            this.panelMain.ResumeLayout(false);
            this.panelElement.ResumeLayout(false);
            this.panelElement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictElement)).EndInit();
            this.panelFieldCode.ResumeLayout(false);
            this.panelFieldCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictFieldCode)).EndInit();
            this.panelFieldDescr.ResumeLayout(false);
            this.panelFieldDescr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictFieldDescr)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelMain;
        private System.Windows.Forms.FlowLayoutPanel panelElement;
        private System.Windows.Forms.PictureBox pictElement;
        private System.Windows.Forms.TextBox tbElement;
        private System.Windows.Forms.Button btnElement;
        private System.Windows.Forms.FlowLayoutPanel panelFieldCode;
        private System.Windows.Forms.PictureBox pictFieldCode;
        private System.Windows.Forms.Label labelFieldCode;
        private System.Windows.Forms.TextBox tbFieldCode;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel panelFieldDescr;
        private System.Windows.Forms.PictureBox pictFieldDescr;
        private System.Windows.Forms.Label labelFieldDescr;
        private System.Windows.Forms.TextBox tbFieldDescr;
        private System.Windows.Forms.Button btnSave;
    }
}