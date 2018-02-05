using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MetaConstructor
{
    public partial class frmFeatures : Form
    {
        CObjectProperty m_element;
        bool m_changed = false;

        private frmFeatures()
        {
            InitializeComponent();
            this.Text = MetaConstructor.Properties.Resources.frmFeaturesText;
            btnCancel.Text = MetaConstructor.Properties.Resources.frmButtonCancelText;
            tbObject.Text = MetaConstructor.Properties.Resources.frmTipsSelectElement;
            tbFKind.Text = MetaConstructor.Properties.Resources.frmTipsSelectElement;
            tbFVal.Text = MetaConstructor.Properties.Resources.frmTipsSelectElement;
            labelObject.Text = MetaConstructor.Properties.Resources.frmObjectText;
            labelFKind.Text = MetaConstructor.Properties.Resources.frmFeatureKindText;
            labelFVal.Text = MetaConstructor.Properties.Resources.frmFeatureValueText;
            
            btnObject.Enabled = false;
            tbObject.Enabled = false;
            tbFKind.Paint += new PaintEventHandler(DrawTextElementBorder);
            tbObject.Paint += new PaintEventHandler(DrawTextElementBorder);
            tbFVal.Paint += new PaintEventHandler(DrawTextElementBorder);
        }

        public frmFeatures(CObjectProperty element) : this()
        {
            LoadContent(element);
        }

        internal void LoadContent(CObjectProperty source)
        {
            this.m_element = source;
            tbFKind.Text = (m_element.PropertyType == null) ? "" : m_element.PropertyType.descr;
            tbFVal.Text = (m_element.PropertyValue == null) ? "" : m_element.PropertyValue.descr;
            tbObject.Text = (m_element.Owner == null) ? "" : m_element.Owner.descr;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void SelectElemInCatalog(object sender, EventArgs e)
        {
            switch (((Control)sender).Name.ToString())
            {
                case "btnFKind":
                case "tbFKind":
                    using (frmCatalogList frm = Catalogs.PropertyTypes.GetListForm(m_element.PropertyType))
                    {
                        if (frm.ShowDialog() != DialogResult.OK) break;
                        m_element.PropertyType = (CPropertyType)frm.SelectedElement;
                        m_changed = true;
                    }
                    break;
                case "btnFVal":
                case "tbFVal":
                    using (frmCatalogList frm = Catalogs.PropertyValues.GetListForm(m_element.PropertyValue))
                    {
                        if (frm.ShowDialog() != DialogResult.OK) break;
                        m_element.PropertyValue = (CPropertyValue)frm.SelectedElement;
                        m_changed = true;
                    }
                    break;
            }
            if(m_changed)
                this.LoadContent(m_element);
        }

        private void DrawTextElementBorder(object sender, PaintEventArgs e)
        { ControlPaint.DrawBorder(e.Graphics, ((Label)sender).DisplayRectangle, Color.White, ButtonBorderStyle.Solid); }

        private void SaveChanges(object sender, EventArgs e)
        {
            if (m_changed == true) m_element.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}