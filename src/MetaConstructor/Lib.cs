using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using Microsoft.SqlServer.Types;


namespace MetaConstructor
{
    public static class SupportLib
    {
        internal static MetaConstructor.Framework.ILocalDb myDB;
        internal static string SqlConnectionString;

        internal static System.Windows.Forms.TreeNode[] LoadNodesInHierarchy(System.Windows.Forms.TreeNode oNode, Type _type)
        {
            System.Collections.Generic.List<System.Windows.Forms.TreeNode> result =
                new System.Collections.Generic.List<System.Windows.Forms.TreeNode>();

            Element element = (oNode == null) ? null : oNode.Tag as Element;
            Element[] list = Catalogs.GetList(_type, element);
            foreach(var e in list)
            {
                System.Windows.Forms.TreeNode tn = new System.Windows.Forms.TreeNode();
                tn.Tag = e;
                tn.Name = e.idr.ToString();
                tn.Text = e.descr;
                tn.ImageKey = ParseTypeOfObject(e);
                if (oNode == null)
                    result.Add(tn);
                else
                    oNode.Nodes.Add(tn);
                LoadNodesInHierarchy(tn, _type);
            }
            return result.ToArray();
        }
        internal static void ReparentElements(System.Windows.Forms.TreeNode tnSelected, System.Windows.Forms.TreeNode tnNewParent)
        {
            try
            {
                if (tnSelected == null || tnSelected.Tag == null) return;
                Element newParent = (tnNewParent != null) ? tnNewParent.Tag as Element : null;
                Element element = (Element)tnSelected.Tag;
                element.SetParent(newParent);
                foreach (System.Windows.Forms.TreeNode e in tnSelected.Nodes)
                    ReparentElements(e, tnSelected);
            }
            catch (Exception ex) { throw new SystemException("Error in reparent function!", ex); }
        }
        internal static string ParseTypeOfObject(Element element)
        {
            if (element.code.Contains("fld"))
                return "CircleField.png";
            else if (element.code.Substring(0, 1).Contains("_"))
                return "CircleGold.png";
            else return "CircleWhite.png";
        }

        internal static void SetCurrentThreadCulture()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CreateSpecificCulture(MetaConstructor.Properties.Settings.Default.CultureAndLanguage); //"ru-RU","en"
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
        }
        internal static bool IsDbFilesExist
        {
            get
            {
                try
                {
                    string[] dir = System.IO.Directory.GetFiles(Properties.Settings.Default.SqlDbPath, "m_CRM.?df");
                    return (dir.Length > 0) ? true : false;
                }
                catch (Exception ex) { throw new SystemException("Error in function IsDbExists\n" + ex.ToString(), ex); }
            }
        }
        internal static bool IdDbReady
        {
            get { return myDB.DbReady; }
        }

        #region tools
        private static object[] CastObject<T>(System.Data.DataTable table, T instance)
        {
            System.Reflection.PropertyInfo[] pi = instance.GetType().GetProperties();
            Object[] values = new object[pi.Length];
            foreach (System.Reflection.PropertyInfo p in pi)
            {
                System.Data.DataColumn dc = table.Columns.Contains(p.Name) ? table.Columns[p.Name]
                    : table.Columns.Add(p.Name, p.PropertyType);
                values[dc.Ordinal] = p.GetValue(instance, null);
            }
            return values;
        }
        private static System.Data.DataTable CastToDataTable<T>(System.Collections.Generic.IEnumerable<T> source, System.Data.DataTable table, string tableName)
        {
            System.Collections.Generic.IEnumerator<T> e = source.GetEnumerator();

            //Create a table
            if (tableName == null) tableName = source.GetType().Name;
            if (table == null) table = new System.Data.DataTable(tableName);

            //Enumerate the source
            table.BeginLoadData();
            while (e.MoveNext())
                table.LoadDataRow(CastObject(table, e.Current), true);
            table.EndLoadData();
            return table;
        }
        public static System.Data.DataTable CopyToDataTable<T>(this System.Collections.Generic.IEnumerable<T> source)
        {
            return CastToDataTable(source, null, null);
        }
        public static System.Data.DataTable CopyToDataTable<T>(this System.Collections.Generic.IEnumerable<T> source, string tableName)
        {
            return CastToDataTable<T>(source, null, tableName);
        }
        public static System.Data.DataTable CopyToDataTable<T>(this System.Collections.Generic.IEnumerable<T> source, System.Data.DataTable table)
        {
            return CastToDataTable<T>(source, table, table.TableName);
        }
        #endregion tools
    }
}
