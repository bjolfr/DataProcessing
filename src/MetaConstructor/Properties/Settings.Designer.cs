﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.2034
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MetaConstructor.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Temp\\m_CRM.mdf;Initial Catalog=m_CRM" +
            ";Integrated Security=True;Connect Timeout=30;User Instance=True")]
        public string SqlDebugConnString {
            get {
                return ((string)(this["SqlDebugConnString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|m_CRM.mdf;Integrated Sec" +
            "urity=True;Connect Timeout=30;User Instance=True")]
        public string SqlConnetionString {
            get {
                return ((string)(this["SqlConnetionString"]));
            }
            set {
                this["SqlConnetionString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("|DataDirectory|")]
        public string SqlDbPath {
            get {
                return ((string)(this["SqlDbPath"]));
            }
            set {
                this["SqlDbPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;Integrated security=SSPI;database=master")]
        public string SqlExpressMasterDb {
            get {
                return ((string)(this["SqlExpressMasterDb"]));
            }
            set {
                this["SqlExpressMasterDb"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ru-RU")]
        public string CultureAndLanguage {
            get {
                return ((string)(this["CultureAndLanguage"]));
            }
            set {
                this["CultureAndLanguage"] = value;
            }
        }
    }
}