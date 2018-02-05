using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using Microsoft.SqlServer.Types;

namespace MetaConstructor.Framework
{

    public interface ILocalDb
    {
        event EventHandler<StatusEventArg> StatusChanged;
        event EventHandler Loaded;
        event EventHandler Deleted;

        bool DbReady { get; }

        void CreateDb();
        void DeleteDb();
        void SaveDb();
        void LoadDb();

        void UpdateElement(Element element, string tableName);
        void RemoveElement(Element element, string tableName);
        bool UploadElement(ref Element element, string tableName);

        int GetNextId(string tableName);
        SqlHierarchyId GetNextHid(Element element, string tableName);
        string GetNextCode(Element element);
        Element[] GetHierarchyList(SqlHierarchyId custId, Type _type, string tableName);
        Element GetParent(Element element, string tableName);
        void SetParent(Element element, Element newParent, string tableName);
    }

    public interface IRemoteDb
    {
        event EventHandler<StatusEventArg> StatusChanged;
        void CreateSqlDb();
        void DeleteSqlDb();
        void SaveChanges(DataSet data);
        void LoadFromSql(DataSet data);
    }

    public class StatusEventArg : EventArgs
    {
        private string m_msg;
        public StatusEventArg(string s) { this.m_msg = s; }
        public string Message { get { return m_msg; } }
    }
}

namespace MetaConstructor.Framework.Imp
{
    class LocalDb : DataSet, ILocalDb
    {
        IRemoteDb m_SqlDb;
        bool m_DbReady = false;

        public event EventHandler<StatusEventArg> StatusChanged;
        public event EventHandler Loaded;
        public event EventHandler Deleted;

        public bool DbReady 
        { get { return m_DbReady; } }
        public LocalDb()
        {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
            m_SqlDb = new SqlDb();
            m_SqlDb.StatusChanged += new EventHandler<StatusEventArg>((sender, e) => OnStatusChanged(e.Message));
        }
        private void InitClass()
        {
            this.DataSetName = "localDataSet";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/myDataSet.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
        }
        protected virtual void OnStatusChanged(string status)
        {
            if (StatusChanged != null) StatusChanged(this, new StatusEventArg(status));
        }
        protected virtual void OnLoaded()
        {
            this.m_DbReady = true;
            if (Loaded != null) Loaded(this, EventArgs.Empty);
        }
        protected virtual void OnDeleted()
        {
            this.m_DbReady = false;
            if (Deleted != null) Deleted(this, EventArgs.Empty);
        }

        #region Element
        private static object[] CastObject<T>(DataTable table, T instance)
        {
            FieldInfo[] fi = instance.GetType().GetFields();
            Object[] values = new object[table.Columns.Count];
            foreach (FieldInfo f in fi)
            {
                System.Data.DataColumn dc = table.Columns.Contains(f.Name) ? table.Columns[f.Name] : null;
                if (dc != null)
                    values[dc.Ordinal] = f.GetValue(instance);
            }
            return values;
        }
        private DataRow FindElementById(int idr, string tableName)
        {
            var query =
                from t1 in this.Tables[tableName].Select()
                where t1.Field<int>("idr").Equals(idr)
                select t1;
            return query.FirstOrDefault();
        }
        private void CheckIfRowHasAdded(object[] row, string tableName)
        {
            DataRow dr = this.Tables[tableName].Rows.Find(row[0]);
            if (dr != null && dr.RowState == DataRowState.Added) 
                    dr.RejectChanges();
        }
        public void UpdateElement(Element element, string tableName)
        {
            DataTable table = this.Tables[tableName];
            try
            {
                table.BeginLoadData();
                object[] row = CastObject<Element>(table, element);
                CheckIfRowHasAdded(row, tableName);
                table.LoadDataRow(row, false);
                table.EndLoadData();
            }
            catch (ConstraintException ex) { throw ex; }
        }
        private string LocalOrDefaultDescr(Element element)
        {
            string m_culture = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            var query =
                from sp21 in this.Tables["sp21"].Select()
                join sp22 in this.Tables["sp22"].Select()
                    on sp21["fld35"] equals sp22["idr"]
                join sp23 in this.Tables["sp23"].Select()
                    on sp21["fld34"] equals sp23["idr"]
                where sp21["fld33"].Equals(element.idr) && sp23["descr"].Equals(m_culture)
                select sp22.Field<string>("descr");
            string result = query.FirstOrDefault();
            return (result == null) ? element.descr : result;
        }
        public bool UploadElement(ref Element element, string tableName)
        {
            DataRow dr = this.FindElementById(element.idr, tableName);
            if (dr == null) return false;

            System.Reflection.FieldInfo[] fi = element.GetType().GetFields();
            foreach (System.Reflection.FieldInfo f in fi)
                if (this.Tables[tableName].Columns.Contains(f.Name))
                    f.SetValue(element, dr[f.Name]);

            element.descr = (tableName == "Objects") ? LocalOrDefaultDescr(element) : element.descr;
            return true;
        }
        public void RemoveElement(Element element, string tableName)
        {
            DataRow dr = this.Tables[tableName].Rows.Find(element.idr);
            if (dr != null)
            {
                dr.BeginEdit();
                try { dr.Delete(); }
                catch (System.Data.InvalidConstraintException ex)
                {
                    System.Windows.MessageBox.Show("Cann't delete. Element has a link in the other tables.\n" + ex.Message);
                    dr.CancelEdit();
                }
                dr.EndEdit();
            }
        }
        public int GetNextId(string tableName)
        {
            return this.Tables[tableName].Select().AsEnumerable().Select(e => e.Field<int>("idr")).Max<int>() + 1;
        }
        public SqlHierarchyId GetNextHid(Element element, string tableName)
        {
            if (!this.Tables[tableName].Columns.Contains("hid")) return SqlHierarchyId.Null;
            //Return a next element in the same hierarchy level
            SqlHierarchyId parent_hid = (element==null || element.hid.Equals(SqlHierarchyId.Null)) ? 
                SqlHierarchyId.GetRoot() : element.hid;
            var query = from t1 in this.Tables[tableName].Select()
                        where t1.Field<SqlHierarchyId>("hid").GetAncestor(1).Equals(parent_hid)
                        orderby t1.Field<SqlHierarchyId>("hid") ascending
                        select t1;
            SqlHierarchyId last_hid = (query.Count() == 0) ?
                last_hid = SqlHierarchyId.Null : (query.Last<DataRow>()).Field<SqlHierarchyId>("hid");
            SqlHierarchyId next_hid = parent_hid.GetDescendant(last_hid, SqlHierarchyId.Null);
            return next_hid;
        }
        public string GetNextCode(Element element)
        {
            //take lenght from object 12 (7,29) or set 9
            var query = from t1 in this.Tables["sp21"].Select()
                        where t1["fld33"].Equals(12) && t1["fld34"].Equals(8)
                        join t2 in this.Tables["sp22"].Select()
                        on t1["fld35"] equals t2["idr"]
                        select t2.Field<decimal>("fld39");

            int lenght = (int)query.FirstOrDefault();
            if (lenght == 0) lenght = 9;
            return String.Format("{0:" + "D" + (lenght - element.idr.ToString().Length) + "}", element.idr);
        }
        public Element[] GetHierarchyList(SqlHierarchyId custId, Type _type, string tableName)
        {
            var query =
                from t1 in this.Tables[tableName].Select()
                where t1.Field<SqlHierarchyId>("hid").GetAncestor(1).Equals(custId)
                select t1;

            List<Element> list = new List<Element>();
            foreach (DataRow dr in query)
            {
                Element element = (Element)Activator.CreateInstance(_type);
                element.idr = dr.Field<int>("idr");
                UploadElement(ref element, tableName);
                list.Add(element);
            }
            return list.ToArray();
        }
        public Element GetParent(Element element, string tableName)
        {
            SqlHierarchyId parent_hid = element.hid.GetAncestor(1);
            var query = from t1 in this.Tables[tableName].Select()
                        where t1.Field<SqlHierarchyId>("hid").Equals(parent_hid)
                        select t1.Field<int>("idr");
            int parent_id = query.FirstOrDefault();
            Element parent = Catalogs.FindByElementId(element.GetType(), parent_id);
            return parent;
        }
        public void SetParent(Element element, Element newParent, string tableName)
        {
            SqlHierarchyId newParentHid = (newParent != null) ? newParent.hid : SqlHierarchyId.GetRoot();
            SqlHierarchyId next_hid = GetNextHid(newParent, tableName);
            element.hid = next_hid;
            this.UpdateElement(element, tableName);
        }
        #endregion Element

        #region DB
        public void CreateDb()
        {
            System.ComponentModel.BackgroundWorker bw = new System.ComponentModel.BackgroundWorker();
            bw.DoWork += new System.ComponentModel.DoWorkEventHandler((sender, e) => { this.m_SqlDb.CreateSqlDb(); });
            bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(CreateDbCompleted);
            bw.RunWorkerAsync();
        }
        public void DeleteDb()
        {
            System.ComponentModel.BackgroundWorker bw = new System.ComponentModel.BackgroundWorker();
            bw.DoWork += new System.ComponentModel.DoWorkEventHandler((sender, e) => { this.m_SqlDb.DeleteSqlDb(); });
            bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(DeleteDbCompleted);
            bw.RunWorkerAsync();
        }
        public void LoadDb()
        {
            System.ComponentModel.BackgroundWorker bw = new System.ComponentModel.BackgroundWorker();
            bw.DoWork += new System.ComponentModel.DoWorkEventHandler((sender, e) => { this.m_SqlDb.LoadFromSql(this); });
            bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(LoadDbCompleted);
            bw.RunWorkerAsync();
        }
        public void SaveDb() 
        { 
            m_SqlDb.SaveChanges(this); 
        }
        private void LoadDbCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                global::System.Data.ForeignKeyConstraint fkc;

                this.Tables["Objects"].Constraints.Add(
                    new System.Data.UniqueConstraint(new DataColumn[] { this.Tables["Objects"].Columns["hid"] }, false));
                this.Tables["Objects"].Columns["hid"].Unique = true;
                this.Tables["Objects"].Columns["hid"].AllowDBNull = false;

                //FK_Objects_sp21
                fkc = new ForeignKeyConstraint("FK_Objects_sp21",
                    this.Tables["Objects"].Columns["idr"],
                    this.Tables["sp21"].Columns["fld33"]);
                fkc.AcceptRejectRule = global::System.Data.AcceptRejectRule.Cascade;
                fkc.DeleteRule = global::System.Data.Rule.Cascade;
                fkc.UpdateRule = global::System.Data.Rule.Cascade;

                //FK_Objects_sp21
                DataRelation relation_Objects_sp21 = new DataRelation("FK_Objects_sp21",
                               this.Tables["Objects"].Columns["idr"],
                               this.Tables["sp21"].Columns["fld33"], false);
                this.Relations.Add(relation_Objects_sp21);

                //FK_sp22_sp21
                fkc = new ForeignKeyConstraint("FK_sp22_sp21",
                               this.Tables["sp22"].Columns["idr"],
                               this.Tables["sp21"].Columns["fld35"]);
                this.Tables["sp21"].Constraints.Add(fkc);
                fkc.AcceptRejectRule = global::System.Data.AcceptRejectRule.None;
                fkc.DeleteRule = global::System.Data.Rule.None;
                fkc.UpdateRule = global::System.Data.Rule.Cascade;
                DataRelation relation_sp22_sp21 = new DataRelation("FK_sp22_sp21",
                               this.Tables["sp22"].Columns["idr"],
                               this.Tables["sp21"].Columns["fld35"], false);
                this.Relations.Add(relation_sp22_sp21);

                //FK_sp23_sp21
                fkc = new ForeignKeyConstraint("FK_sp23_sp21",
                               this.Tables["sp23"].Columns["idr"],
                               this.Tables["sp21"].Columns["fld34"]);
                this.Tables["sp21"].Constraints.Add(fkc);
                fkc.AcceptRejectRule = global::System.Data.AcceptRejectRule.None;
                fkc.DeleteRule = global::System.Data.Rule.None;
                fkc.UpdateRule = global::System.Data.Rule.Cascade;
                DataRelation relation_sp23_sp21 = new DataRelation("FK_sp23_sp21",
                                               this.Tables["sp23"].Columns["idr"],
                                               this.Tables["sp21"].Columns["fld34"], false);
                this.Relations.Add(relation_sp23_sp21);

                OnLoaded();
                OnStatusChanged(MetaConstructor.Properties.Resources.InfoStatusReady);
            }
            catch (Exception ex) { throw new SystemException("Error in FK_", ex); }
        } //FormedLocalDb
        private void DeleteDbCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) OnStatusChanged(MetaConstructor.Properties.Resources.InfoMsgDbCanNotDelete);
            else OnStatusChanged(MetaConstructor.Properties.Resources.InfoMsgDbDeleted);
        }
        private void CreateDbCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) OnStatusChanged(MetaConstructor.Properties.Resources.InfoMsgDbCanNotCreate);
            else OnStatusChanged(MetaConstructor.Properties.Resources.InfoMsgDbCreated);
        }
        #endregion DB
    } // LocalDb

    class SqlDb : IRemoteDb
    {
        List<string> listTables = new List<string> { "Objects", "sp21", "sp22", "sp23" };
        Dictionary<string, SqlCommandBuilder> listDataAdaptes = new Dictionary<string, SqlCommandBuilder>();

        public event EventHandler<StatusEventArg> StatusChanged;
        protected virtual void OnStatusChanged(string status)
        {
            if (StatusChanged != null)
                StatusChanged(this, new StatusEventArg(status));
        }
        public void CreateSqlDb()
        {
            SupportLib.SetCurrentThreadCulture();
            System.Text.StringBuilder strCreateDb = new System.Text.StringBuilder(MetaConstructor.Properties.Resources.CrmCreateDb);
            strCreateDb.Replace(@"{0}", MetaConstructor.Properties.Settings.Default.SqlDbPath.ToString());

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(MetaConstructor.Properties.Settings.Default.SqlExpressMasterDb))
            {
                OnStatusChanged(MetaConstructor.Properties.Resources.InfoStatusConnOpening);
                try
                {
                    conn.Open();
                    OnStatusChanged(MetaConstructor.Properties.Resources.InfoStatusDbCreating);
                    new System.Data.SqlClient.SqlCommand(strCreateDb.ToString(), conn).ExecuteNonQuery();
                    OnStatusChanged(MetaConstructor.Properties.Resources.InfoStatusTablesCreating);
                    new System.Data.SqlClient.SqlCommand(MetaConstructor.Properties.Resources.CrmCreateTables, conn).ExecuteNonQuery();
                    OnStatusChanged(MetaConstructor.Properties.Resources.InfoStatusTablesFilling);
                    new System.Data.SqlClient.SqlCommand(MetaConstructor.Properties.Resources.CrmFillTables, conn).ExecuteNonQuery();
                    OnStatusChanged(MetaConstructor.Properties.Resources.InfoStatusDbDetaching);
                    new System.Data.SqlClient.SqlCommand(MetaConstructor.Properties.Resources.CrmDetachDb, conn).ExecuteNonQuery();
                }
                catch (Exception ex) { throw ex; }
                finally { if (conn.State == System.Data.ConnectionState.Open) conn.Close(); }
            } //conn
        }
        public void DeleteSqlDb()
        {
            SupportLib.SetCurrentThreadCulture();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.SqlExpressMasterDb))
            {
                string strAttachDb = new System.Text.StringBuilder(MetaConstructor.Properties.Resources.CrmAttachDb)
                        .Replace(@"{0}", MetaConstructor.Properties.Settings.Default.SqlDbPath).ToString();
                OnStatusChanged(MetaConstructor.Properties.Resources.InfoStatusConnOpening);
                try
                {
                    conn.Open();
                    if (SupportLib.IsDbFilesExist)
                    {
                        OnStatusChanged(MetaConstructor.Properties.Resources.InfoStatusDbAttaching);
                        new System.Data.SqlClient.SqlCommand(strAttachDb, conn).ExecuteNonQuery();
                    }
                    OnStatusChanged(MetaConstructor.Properties.Resources.InfoStatusDbDeleteing);
                    new System.Data.SqlClient.SqlCommand(MetaConstructor.Properties.Resources.CrmDeleteDb, conn).ExecuteNonQuery();
                }
                catch (Exception ex) { throw ex; }
                finally { if (conn.State == System.Data.ConnectionState.Open) conn.Close(); }
            } //conn
        }
        public void LoadFromSql(DataSet data)
        {
            SupportLib.SetCurrentThreadCulture();
            data.Clear();
            data.Relations.Clear();
            data.Locale = global::System.Globalization.CultureInfo.InvariantCulture;

            using (global::System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(
                SupportLib.SqlConnectionString))
            {
                OnStatusChanged(MetaConstructor.Properties.Resources.InfoStatusConnOpening);
                try
                {
                    conn.Open();
                    using (global::System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter())
                    {
                        foreach (string tbl in listTables)
                        {
                            da.SelectCommand = new System.Data.SqlClient.SqlCommand(
                                String.Format(@"SELECT * FROM {0}", tbl),
                                conn);
                            da.Fill(data, tbl);
                            data.Tables[tbl].Constraints.Clear();
                            data.Tables[tbl].Constraints.Add(
                                new System.Data.UniqueConstraint(new global::System.Data.DataColumn[] { data.Tables[tbl].Columns["idr"] }, true));
                            data.Tables[tbl].Columns["idr"].Unique = true;
                            data.Tables[tbl].Columns["idr"].AllowDBNull = false;

                            SqlCommandBuilder scb = new SqlCommandBuilder(da);
                            da.UpdateCommand = scb.GetUpdateCommand(true);
                            da.InsertCommand = scb.GetInsertCommand(true);
                            da.DeleteCommand = scb.GetDeleteCommand(true);
                            listDataAdaptes.Add(tbl, scb);

                            OnStatusChanged(String.Format(MetaConstructor.Properties.Resources.InfoStatusTablesLoading, tbl));
                        }
                    } //DataAdapter
                    OnStatusChanged(MetaConstructor.Properties.Resources.InfoStatusReady);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString(),
                        MetaConstructor.Properties.Resources.ApplicationName, System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                }
                finally { if (conn.State == System.Data.ConnectionState.Open) conn.Close(); }
            } // close connection
        }
        public void SaveChanges(DataSet data) 
        {
            using (SqlConnection conn = new SqlConnection(SupportLib.SqlConnectionString))
            {
                conn.Open();
                using (System.Data.SqlClient.SqlTransaction tran = conn.BeginTransaction())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        foreach (var scb in listDataAdaptes)
                        {
                            SqlCommand cmdInsert = scb.Value.GetInsertCommand();
                            cmdInsert.Connection = conn;
                            cmdInsert.Transaction = tran;
                            da.InsertCommand = cmdInsert;
                            SqlCommand cmdUpdate = scb.Value.GetUpdateCommand();
                            cmdUpdate.Connection = conn;
                            cmdUpdate.Transaction = tran;
                            da.UpdateCommand = cmdUpdate;
                            SqlCommand cmdDelete = scb.Value.GetDeleteCommand();
                            cmdDelete.Connection = conn;
                            cmdDelete.Transaction = tran;
                            da.DeleteCommand = cmdDelete;
                            da.Update(data, scb.Key);
                        }
                    } //da
                    tran.Commit();
                    System.Windows.MessageBox.Show(MetaConstructor.Properties.Resources.InfoMsgChangesSaved);
                }//tran
                conn.Close();
            }// conn
        }
    } // SqlDb
} // Framework.Imp
