using System;
using System.Windows.Forms;

namespace MetaConstructor
{
    public partial class frmCatalogElement : Form
    {
        private Element m_element;
        private bool m_changed = false;

        private frmCatalogElement()
        {
            InitializeComponent();
            this.Text = MetaConstructor.Properties.Resources.frmCatalogText;
            btnCancel.Text = MetaConstructor.Properties.Resources.frmButtonCancelText;
            labelFieldCode.Text = MetaConstructor.Properties.Resources.frmCodeText;
            labelFieldDescr.Text = MetaConstructor.Properties.Resources.frmDescrText;
        }

        public frmCatalogElement(Element element) : this()
        {
            LoadContent(element);
        }

        #region events
        private void TextIsChanged(object sender, EventArgs e)
        {
            m_changed = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveContent();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveContent();
        }
        #endregion events

        #region actions
        internal void LoadContent(Element element)
        {
            m_element = element;
            tbElement.Tag = m_element.GetParent();
            tbElement.Text = (tbElement.Tag != null) ? m_element.GetParent().descr : "..";
            tbFieldCode.Text = m_element.code;
            tbFieldDescr.Text = m_element.descr;
        }

        private void SaveContent()
        {
            if (!m_changed) return;
            m_element.code = tbFieldCode.Text;
            m_element.descr = tbFieldDescr.Text;
            m_element.Save();
        }
        #endregion actions
    }
}
