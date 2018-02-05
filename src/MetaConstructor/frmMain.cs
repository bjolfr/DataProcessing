using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;

namespace MetaConstructor
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            SupportLib.myDB = new MetaConstructor.Framework.Imp.LocalDb();
            SupportLib.myDB.StatusChanged += new EventHandler<MetaConstructor.Framework.StatusEventArg>(
                (sender, e) =>
                {
                    if (this.mainStatusText.InvokeRequired) this.mainStatusText.Invoke((MethodInvoker)delegate
                        { mainStatusText.Text = e.Message; });
                    else this.mainStatusText.Text = e.Message;
                });
            SupportLib.myDB.Loaded += new EventHandler(myDb_Loaded);
        }

        #region events
        private void frmMain_Load(object sender, EventArgs e)
        {
#if(DEBUG)
            MetaConstructor.Properties.Settings.Default.SqlDbPath = @"C:\Temp";
            SupportLib.SqlConnectionString = MetaConstructor.Properties.Settings.Default.SqlDebugConnString;
#else
            MetaConstructor.Properties.Settings.Default.SqlDbPath = Application.StartupPath;
            SupportLib.SqlConnectionString = MetaConstructor.Properties.Settings.Default.SqlConnetionString;
#endif
            Properties.Settings.Default.Save();
            try
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture(MetaConstructor.Properties.Settings.Default.CultureAndLanguage); //"ru-RU","en"
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
                ResourceManager rm = new ResourceManager("MetaConstructor.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
                InitializeControlsWithCulture();
            }
            catch (CultureNotFoundException ex) { Console.WriteLine("Unable to instaniate culture {0}", ex.InvalidCultureName); }
            finally { SetButtonStatus(); }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SupportLib.myDB.CreateDb();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (System.Windows.MessageBox.Show(MetaConstructor.Properties.Resources.QstMsgDeleteDB,
                MetaConstructor.Properties.Resources.ApplicationName,
                System.Windows.MessageBoxButton.OKCancel) != System.Windows.MessageBoxResult.OK) return;

            masterBindingSource.EndEdit();
            detailsBindingSource.EndEdit();
            tvObjects.Nodes.Clear();
            lvProperties.Items.Clear();

            SupportLib.myDB.DeleteDb();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SupportLib.myDB.LoadDb();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SupportLib.myDB.SaveDb();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tvObjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode sn = ((TreeView)sender).SelectedNode;
            if (masterBindingSource.DataMember.Equals("")) return;
            if (detailsBindingSource.DataMember.Equals("")) return;
            FillListFeatures(sn);
#if(DEBUG)
            CObject myObject = ((CObject)sn.Tag);
            mainStatusText.Text = String.Format("{0} {1} {2}", myObject.code,
                myObject.hid, myObject.descr);
#endif
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvObjects.SelectedNode == null)
            {
                System.Windows.MessageBox.Show(MetaConstructor.Properties.Resources.ErrMsgChooseElement,
                    MetaConstructor.Properties.Resources.MsgWarning,
                    System.Windows.MessageBoxButton.OK);
                return;
            }
            var element = Catalogs.Properties.CreateElement();
            element.Owner = tvObjects.SelectedNode.Tag as CObject;
            if (element.GetElementForm().ShowDialog() == System.Windows.Forms.DialogResult.OK)
                FillListFeatures(tvObjects.SelectedNode);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.masterBindingSource.EndEdit();
            this.detailsBindingSource.EndEdit();

            if (lvProperties.SelectedItems.Count > 0)
            {
                CObjectProperty element = (CObjectProperty)lvProperties.SelectedItems[0].Tag;
                if (element.GetElementForm().ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    FillListFeatures(tvObjects.SelectedNode);
            }
            else
                System.Windows.MessageBox.Show(MetaConstructor.Properties.Resources.ErrMsgChooseElement,
                                               MetaConstructor.Properties.Resources.MsgWarning,
                                               System.Windows.MessageBoxButton.OK,
                                               System.Windows.MessageBoxImage.Warning);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvProperties.SelectedItems.Count > 0)
            {
                CObjectProperty element = (CObjectProperty)lvProperties.SelectedItems[0].Tag;
                if (System.Windows.MessageBox.Show(String.Format(MetaConstructor.Properties.Resources.QstMsgDeleteElement,
                    element.Owner.descr),
                    MetaConstructor.Properties.Resources.MsgWarning,
                    System.Windows.MessageBoxButton.YesNo,
                    System.Windows.MessageBoxImage.Warning) == System.Windows.MessageBoxResult.Yes)
                {
                    element.Delete();
                    FillListFeatures(tvObjects.SelectedNode);
                }
            }
            else
            {
                System.Windows.MessageBox.Show(MetaConstructor.Properties.Resources.ErrMsgChooseElement,
                    MetaConstructor.Properties.Resources.MsgWarning,
                    System.Windows.MessageBoxButton.OK);
                return;
            }
        }

        private void addToolStripMenuItemMO_Click(object sender, EventArgs e)
        {
            CObject newElement = Catalogs.Objects.CreateElement();
            if (newElement.GetElementForm().ShowDialog() == System.Windows.Forms.DialogResult.OK)
                FillTreeView(newElement.idr);
        }

        private void deleteToolStripMenuItemMO_Click(object sender, EventArgs e)
        {
            if (tvObjects.SelectedNode.IsSelected)
            {
                CObject SelectedElement = (CObject)tvObjects.SelectedNode.Tag;
                if (System.Windows.MessageBox.Show(String.Format(MetaConstructor.Properties.Resources.QstMsgDeleteElement,
                    SelectedElement.descr.ToString()),
                    MetaConstructor.Properties.Resources.MsgWarning,
                    System.Windows.MessageBoxButton.YesNo,
                    System.Windows.MessageBoxImage.Warning) == System.Windows.MessageBoxResult.Yes)
                {
                    SelectedElement.Delete();
                    FillTreeView();
                }
            }
            else
            {
                System.Windows.MessageBox.Show(MetaConstructor.Properties.Resources.ErrMsgChooseElement,
                    MetaConstructor.Properties.Resources.MsgWarning,
                    System.Windows.MessageBoxButton.OK);
                return;
            }
        }

        private void editToolStripMenuItemMO_Click(object sender, EventArgs e)
        {
            if (tvObjects.SelectedNode.IsSelected)
            {
                if (!tvObjects.SelectedNode.IsSelected) return;
                int id = ((Element)tvObjects.SelectedNode.Tag).idr;
                CObject element = Catalogs.Objects.FindById(id);
                if (element.GetElementForm().ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    FillTreeView(element.idr);
            }
            else
            {
                System.Windows.MessageBox.Show(MetaConstructor.Properties.Resources.ErrMsgChooseElement,
                    MetaConstructor.Properties.Resources.MsgWarning,
                    System.Windows.MessageBoxButton.OK);
                return;
            }
        }

        private void toRootToolStripMenuItemMO_Click(object sender, EventArgs e)
        {
            if (tvObjects.SelectedNode.IsSelected)
            {
                TreeNode tn = tvObjects.SelectedNode;
                if (tn.Parent == null) return;
                SupportLib.ReparentElements(tn, null);
                tvObjects.Nodes.Add((TreeNode)tn.Clone());
                tn.Remove();
            }
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
                    try
                    {
                        destinationNode.Nodes.Add((TreeNode)sourceNode.Clone());
                        destinationNode.Expand();
                        SupportLib.ReparentElements(sourceNode, destinationNode);
                        sourceNode.Remove();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("Cann't move {0} to {1}", sourceNode.Text, destinationNode.Text),
                            MetaConstructor.Properties.Resources.ApplicationName,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        throw ex;
                    }
                }
            }
        }

        private void mainStatusText_TextChanged(object sender, EventArgs e)
        {
            if (mainStatusText.Text == MetaConstructor.Properties.Resources.InfoMsgDbCanNotDelete)
                MessageBox.Show(MetaConstructor.Properties.Resources.InfoMsgDbCanNotDelete, MetaConstructor.Properties.Resources.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (mainStatusText.Text == MetaConstructor.Properties.Resources.InfoMsgDbDeleted)
            {
                MessageBox.Show(MetaConstructor.Properties.Resources.InfoMsgDbDeleted, MetaConstructor.Properties.Resources.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetButtonStatus();
            }
            else if (mainStatusText.Text == MetaConstructor.Properties.Resources.InfoMsgDbCanNotCreate)
                MessageBox.Show(MetaConstructor.Properties.Resources.InfoMsgDbCanNotCreate, MetaConstructor.Properties.Resources.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (mainStatusText.Text == MetaConstructor.Properties.Resources.InfoMsgDbCreated)
            {
                MessageBox.Show(MetaConstructor.Properties.Resources.InfoMsgDbCreated, MetaConstructor.Properties.Resources.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetButtonStatus(); return;
            }

            mainStatusPict.Image = (mainStatusText.Text == MetaConstructor.Properties.Resources.InfoStatusReady) ?
                    Properties.Resources.CircleLime :
                    Properties.Resources.CircleGold;
        }

        private void myDb_Loaded(object sender, EventArgs e)
        {
            //Binding to sources
            masterBindingSource.DataSource = SupportLib.myDB;
            masterBindingSource.DataMember = "Objects";

            detailsBindingSource.DataSource = masterBindingSource;
            detailsBindingSource.DataMember = "FK_Objects_sp21";

            FillTreeView();
            SetButtonStatus();
        }
        #endregion events

        #region actions
        private void InitializeControlsWithCulture()
        {
            this.Text = MetaConstructor.Properties.Resources.ApplicationName;
            btnClose.Text = MetaConstructor.Properties.Resources.frmButtonCloseText;
            btnDelete.Text = MetaConstructor.Properties.Resources.frmButtonDeleteText;
            btnExport.Text = MetaConstructor.Properties.Resources.frmButtonExportText;
            btnLoad.Text = MetaConstructor.Properties.Resources.frmButtonLoadText;
            btnNew.Text = MetaConstructor.Properties.Resources.frmButtonNewText;
            btnSave.Text = MetaConstructor.Properties.Resources.frmButtonSaveText;
            chPropType.Text = MetaConstructor.Properties.Resources.frmClmnHdrPropType;
            chPropValue.Text = MetaConstructor.Properties.Resources.frmClmnHdrPropValue;
            addToolStripMenuItem.Text = MetaConstructor.Properties.Resources.frmToolMenuAdd;
            editToolStripMenuItem.Text = MetaConstructor.Properties.Resources.frmToolMenuEdit;
            deleteToolStripMenuItem.Text = MetaConstructor.Properties.Resources.frmToolMenuDelete;
            addToolStripMenuItemMO.Text = MetaConstructor.Properties.Resources.frmToolMenuAdd;
            editToolStripMenuItemMO.Text = MetaConstructor.Properties.Resources.frmToolMenuEdit;
            deleteToolStripMenuItemMO.Text = MetaConstructor.Properties.Resources.frmToolMenuDelete;
        }

        private void SetButtonStatus()
        {
            if (SupportLib.IdDbReady)
            {
                btnNew.Enabled = false; btnLoad.Enabled = false; btnExport.Enabled = true; btnSave.Enabled = true; btnDelete.Enabled = false;
                btnNew.Visible = false; btnLoad.Visible = false; btnExport.Visible = true; btnSave.Visible = true; btnDelete.Visible = false;
            }
            else if (SupportLib.IsDbFilesExist)
            {
                btnNew.Enabled = false; btnLoad.Enabled = true; btnExport.Enabled = false; btnSave.Enabled = false; btnDelete.Enabled = true;
                btnNew.Visible = false; btnLoad.Visible = true; btnExport.Visible = false; btnSave.Visible = false; btnDelete.Visible = true;
                mainStatusText.Text = MetaConstructor.Properties.Settings.Default.SqlDbPath + @"\m_CRM.mdf";
                mainStatusPict.Image = Properties.Resources.CircleWhite;
            }
            else
            {
                btnNew.Enabled = true; btnLoad.Enabled = false; btnExport.Enabled = false; btnSave.Enabled = false; btnDelete.Enabled = false;
                btnNew.Visible = true; btnLoad.Visible = false; btnExport.Visible = false; btnSave.Visible = false; btnDelete.Visible = false;
            }
        }

        private void FillTreeView(int idx = 0)
        {
            tvObjects.Nodes.Clear();
            tvObjects.Nodes.AddRange(
                SupportLib.LoadNodesInHierarchy(null, typeof(CObject)));
            tvObjects.SelectedNode = tvObjects.Nodes.Find(idx.ToString(), true).FirstOrDefault();
        }

        private void FillListFeatures(TreeNode selectedNode)
        {
            masterBindingSource.Position = masterBindingSource.Find("idr", Int32.Parse(selectedNode.Name));

            lvProperties.Items.Clear();
            foreach (System.Data.DataRowView v in detailsBindingSource)
            {
                CObjectProperty element = Catalogs.Properties.FindById(v.Row.Field<int>("idr"));
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = element;
                lvi.SubItems.Add(element.PropertyType.descr);
                lvi.SubItems.Add(element.PropertyValue.descr);
                lvi.ImageIndex = 9;
                lvProperties.Items.Add(lvi);
            }
        }
        #endregion actions

        #region examples
        /*Only for example! Invoke from background worker DeleteDB*/
        //private delegate void SetTextCallback(string text);
        //private void SetText(string text)
        //{
        //    if (this.mainStatusText.InvokeRequired)
        //    {
        //        this.Invoke(new SetTextCallback(SetText), new object[] { text });
        //    }
        //    else
        //        this.mainStatusText.Text = text;
        //}
        #endregion examples
    }
}
