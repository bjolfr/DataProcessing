using System;
using System.Windows.Forms;

namespace MetaConstructor
{
    public partial class frmCatalogList : Form
    {
        public Element SelectedElement { get; set; }
        private Type m_type;

        private frmCatalogList()
        {
            InitializeComponent();
            this.Text = MetaConstructor.Properties.Resources.frmCatalogText;
            btnCancel.Text = MetaConstructor.Properties.Resources.frmButtonCancelText;
            chCode.Text = MetaConstructor.Properties.Resources.frmCodeText;
            chDescr.Text = MetaConstructor.Properties.Resources.frmDescrText;
            addToolStripMenuItem.Text = MetaConstructor.Properties.Resources.frmToolMenuAdd;
            editToolStripMenuItem.Text = MetaConstructor.Properties.Resources.frmToolMenuEdit;
            deleteToolStripMenuItem.Text = MetaConstructor.Properties.Resources.frmToolMenuDelete;
        }

        public frmCatalogList(Element element) : this()
        {
            LoadContent(element);
        }

        public frmCatalogList(Type _type) : this()
        {
            this.m_type = _type;
            LoadContent(_type);
        }

        #region events
        private void tvObjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode sn = ((TreeView)sender).SelectedNode;
            if (sn == null) return;
            SelectedElement = (Element)sn.Tag;
#if(DEBUG)
            catalogStatusText.Text = String.Format("{0} {1} {2} {3}", SelectedElement.idr, SelectedElement.code,
                SelectedElement.hid, SelectedElement.descr);
#endif

            lvProperties.Items.Clear();
            ListViewItem parent_lvi = new ListViewItem();
            parent_lvi.Tag = sn.Tag;
            parent_lvi.Name = sn.Name;
            parent_lvi.Text = SelectedElement.code.ToString();
            parent_lvi.SubItems.Add(sn.Text);
            parent_lvi.ImageKey = "CircleGold.png";
            lvProperties.Items.Add(parent_lvi);
            foreach (TreeNode tn in sn.Nodes)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = tn.Tag; 
                lvi.Name = tn.Name;
                lvi.Text = ((Element)tn.Tag).code.ToString();
                lvi.SubItems.Add(tn.Text);
                lvi.ImageKey = ParseTypeOfObject(((Element)tn.Tag));
                lvProperties.Items.Add(lvi);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvProperties.SelectedItems.Count > 0)
                if (SelectedElement.GetElementForm().ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    LoadContent(SelectedElement);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var parent = (tvObjects.SelectedNode.IsSelected) ? (Element)tvObjects.SelectedNode.Tag : null;
            var element = Catalogs.CreateElement(m_type, parent);
            using (var frm = element.GetElementForm())
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    this.LoadContent(parent);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedElement == null) return;

            if(System.Windows.MessageBox.Show(String.Format("Delete {0}?", 
                SelectedElement.descr),
                "Warning", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Warning) == System.Windows.MessageBoxResult.Yes)
            {
                var wasParent = SelectedElement.GetParent();
                SelectedElement.Delete();
                tvObjects.Nodes.Clear();
                LoadContent(wasParent);
            }        
        }

        private void lvProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            var items = ((ListView)sender).SelectedItems;
            if (items.Count > 0)
                SelectedElement = (Element)items[0].Tag;
#if(DEBUG)
            catalogStatusText.Text = String.Format("{0} {1} {2} {3}", SelectedElement.idr, SelectedElement.code,
                SelectedElement.hid, SelectedElement.descr);
#endif
        }

        private void tvObjects_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tvObjects_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvObjects_DragOver(object sender, DragEventArgs e)
        {
            TreeView m_TreeView = ((TreeView)sender); //link to tvObjects
            System.Drawing.Point targetPoint = m_TreeView.PointToClient(
                    new System.Drawing.Point(e.X, e.Y));
            m_TreeView.SelectedNode = m_TreeView.GetNodeAt(targetPoint);
        }

        private void tvObjects_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                System.Drawing.Point targetPoint = ((TreeView)sender).PointToClient(
                    new System.Drawing.Point(e.X, e.Y));
                TreeNode destinationNode = tvObjects.GetNodeAt(targetPoint);
                TreeNode sourceNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                if (!destinationNode.Equals(sourceNode))
                {
                    destinationNode.Nodes.Add((TreeNode)sourceNode.Clone());
                    destinationNode.Expand();
                    SupportLib.ReparentElements(sourceNode, destinationNode);
                    sourceNode.Remove();
                }
            }
        }
        #endregion events

        #region actions
        private void LoadContent(Type _type)
        {
            tvObjects.Nodes.Clear();
            tvObjects.Nodes.AddRange(
                SupportLib.LoadNodesInHierarchy(null, _type));
        }

        private void LoadContent(Element element)
        {
            this.SelectedElement = element;
            this.m_type = element.GetType();
            LoadContent(element.GetType());
            TreeNode[] nodes = tvObjects.Nodes.Find(SelectedElement.idr.ToString(), true);
            if (nodes.Length > 0) tvObjects.SelectedNode = (TreeNode)nodes.GetValue(0);
        }

        private static string ParseTypeOfObject(Element element)
        {
            if (element.code.Contains("fld"))
                return "CircleField.png";
            else if (element.code.Substring(0, 1).Contains("_"))
                return "CircleGold.png";
            else return "CircleViolet.png";
        }
        #endregion actions

    }
}
