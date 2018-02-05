using System;
using System.Linq;
using Microsoft.SqlServer.Types;
using System.Windows.Forms;

namespace MetaConstructor
{
    public abstract class Element
    {
        public int idr;
        public SqlHierarchyId hid;
        public string code;
        public string descr;

        public abstract void Save();
        public abstract void Delete();
        public abstract Form GetElementForm();
        public abstract Element GetParent();
        public abstract void SetParent(Element newParent);
        
        protected Element GetParent<T>()
        {
            string table = Catalogs.MapToDataTable(typeof(T));
            return Catalogs.m_DB.GetParent(this, table);
        }
        protected void Save<T>()
        {
            string table = Catalogs.MapToDataTable(typeof(T));
            Catalogs.m_DB.UpdateElement(this, table);
        }
        protected void Delete<T>()
        {
            string table = Catalogs.MapToDataTable(typeof(T));
            Catalogs.m_DB.RemoveElement(this, table);
        }
        protected void SetParent<T>(Element newParent)
        {
            string table = Catalogs.MapToDataTable(typeof(T));
            Catalogs.m_DB.SetParent(this, newParent, table);
        }
    }

    public static class Catalogs
    {
        internal static MetaConstructor.Framework.ILocalDb m_DB = SupportLib.myDB;

        public class TableNameAttribute : Attribute
        {
            public string TableName { get; set; }
            public TableNameAttribute(string tableName) { this.TableName = tableName; }
        }

        internal static string MapToDataTable(Type _type)
        {
            System.Reflection.MemberInfo info = _type;
            object[] attributes = info.GetCustomAttributes(typeof(Catalogs.TableNameAttribute), true);
            return ((Catalogs.TableNameAttribute)attributes.FirstOrDefault()).TableName;
        }

        public static Element[] GetList(Type _type, Element parent)
        {
            string tableName = Catalogs.MapToDataTable(_type);
            SqlHierarchyId parent_hid = parent == null ? SqlHierarchyId.GetRoot() : parent.hid;
            return m_DB.GetHierarchyList(parent_hid, _type, tableName);
        }
        public static Element CreateElement(Type _type, Element parent = null)
        {
            string table = MapToDataTable(_type);
            Element tmp = (Element)Activator.CreateInstance(_type);
            tmp.idr = m_DB.GetNextId(table);
            tmp.hid = m_DB.GetNextHid((parent == null) ? tmp : parent, table);
            tmp.code = m_DB.GetNextCode(tmp);
            return tmp;   
        }
        public static Element FindByElementId(Type _type, int id)
        {
            string table = MapToDataTable(_type);
            Element tmp = (Element)Activator.CreateInstance(_type);
            tmp.idr = id;
            return (m_DB.UploadElement(ref tmp, table)) ? tmp : null;
        }

        public static class Objects
        {
            public static CObject CreateElement()
            {
                return (CObject)Catalogs.CreateElement(typeof(CObject));
            }
            public static CObject FindById(int idr)
            {
                return (CObject)Catalogs.FindByElementId(typeof(CObject), idr);
            }
            public static frmCatalogList GetListForm()
            {
                return new frmCatalogList(typeof(CObject));
            }

            public static CObject FindByCode(string code) { throw new MethodAccessException(); }
            public static CObject FindByName(string name) { throw new MethodAccessException(); }
        }
        public static class Properties
        {
            public static CObjectProperty CreateElement()
            {
                return (CObjectProperty)Catalogs.CreateElement(typeof(CObjectProperty));
            }
            public static CObjectProperty FindById(int idr)
            {
                try
                {
                    CObjectProperty tmp = (CObjectProperty)Catalogs.FindByElementId(typeof(CObjectProperty), idr);
                    tmp.PropertyType = Catalogs.PropertyTypes.FindById(tmp.fld34);
                    tmp.PropertyValue = Catalogs.PropertyValues.FindById(tmp.fld35);
                    return tmp;
                }
                catch (Exception ex) { throw new SystemException("Cann't find element!", ex); }
            }
        }
        public static class PropertyTypes
        {
            public static CPropertyType CreateElement()
            {
                return (CPropertyType)Catalogs.CreateElement(typeof(CPropertyType));
            }
            public static CPropertyType FindById(int idr)
            {
                return (CPropertyType)Catalogs.FindByElementId(typeof(CPropertyType), idr);
            }
            public static frmCatalogList GetListForm()
            {
                return new frmCatalogList(typeof(CPropertyType));
            }
            public static frmCatalogList GetListForm(CPropertyType element)
            {
                return (element != null) ? new frmCatalogList(element) : PropertyTypes.GetListForm();
            }

            public static CPropertyType FindByCode(string code) { throw new MethodAccessException(); }
            public static CPropertyType FindByName(string name) { throw new MethodAccessException(); }
        }
        public static class PropertyValues
        {
            public static CPropertyValue CreateElement()
            {
                return (CPropertyValue)Catalogs.CreateElement(typeof(CPropertyValue));
            }
            public static CPropertyValue FindById(int idr)
            {
                return (CPropertyValue)Catalogs.FindByElementId(typeof(CPropertyValue), idr);
            }
            public static frmCatalogList GetListForm()
            {
                return new frmCatalogList(typeof(CPropertyValue));
            }
            public static frmCatalogList GetListForm(CPropertyValue element)
            {
                return (element != null) ? new frmCatalogList(element) : PropertyValues.GetListForm();
            }

            public static CPropertyValue FindByCode(string code) { throw new MethodAccessException(); }
            public static CPropertyValue FindByName(string name) { throw new MethodAccessException(); }
        }
    }

    [Catalogs.TableName("Objects")]
    public sealed class CObject : Element
    {
        public override void Save()
        {
            base.Save<CObject>();
        }
        public override void Delete()
        {
            base.Delete<CObject>();
        }
        public override Form GetElementForm()
        {
            return new frmCatalogElement(this);
        }
        public override Element GetParent()
        {
            return base.GetParent<CObject>();
        }
        public override void SetParent(Element newParent)
        {
            base.SetParent<CObject>(newParent);
        }
    }

    [Catalogs.TableName("sp21")]
    public sealed class CObjectProperty : Element
    {
        public int fld32; //link to table 1=Objects 
        public int fld33; //Owner
        public int fld34; //PropertyType
        public int fld35; //PropertyValue

        public CObject Owner 
        { 
            get { return Catalogs.Objects.FindById(fld33); }
            set { fld33 = value.idr; }
        }
        public CPropertyType PropertyType {
            get { return Catalogs.PropertyTypes.FindById(fld34);}
            set { fld34 = value.idr;}
        }
        public CPropertyValue PropertyValue {
            get { return Catalogs.PropertyValues.FindById(fld35);}
            set { fld35 = value.idr;}
        }

        public override void Save()
        {
            base.Save<CObjectProperty>();
        }
        public override void Delete()
        {
            base.Delete<CObjectProperty>();
        }
        public override Form GetElementForm()
        {
            return new frmFeatures(this);
        }
        public override Element GetParent()
        {
            throw new NotImplementedException();
        }
        public override void SetParent(Element newParent)
        {
            throw new NotImplementedException();
        }
    }

    [Catalogs.TableName("sp23")]
    public sealed class CPropertyType : Element
    {
        public override void Save()
        {
            base.Save<CPropertyType>();
        }
        public override void Delete()
        {
            base.Delete<CPropertyType>();
        }
        public override Form GetElementForm()
        {
            return new frmCatalogElement(this);
        }
        public override Element GetParent()
        {
            return base.GetParent<CPropertyType>();
        }
        public override void SetParent(Element newParent)
        {
            base.SetParent<CPropertyType>(newParent);
        }
    }

    [Catalogs.TableName("sp22")]
    public sealed class CPropertyValue : Element
    {
        public override void Save()
        {
            base.Save<CPropertyValue>();
        }
        public override void Delete()
        {
            base.Delete<CPropertyValue>();
        }
        public override Form GetElementForm()
        {
            return new frmCatalogElement(this);
        }
        public override Element GetParent()
        {
            return base.GetParent<CPropertyValue>();
        }
        public override void SetParent(Element newParent)
        {
            base.SetParent<CPropertyValue>(newParent);
        }
    }
}
