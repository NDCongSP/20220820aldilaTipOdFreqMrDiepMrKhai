﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TipOdFreqAdmin.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4LxE/a+D1aN38ut8vvBCcghMbkTSmcyBcML3Uo+yGpjDFhvHDZ0TTQrNs5BzWTrmXuV8s2qBvGaXtRuv5" +
            "7ncQupXJvdJ9GzPyMRqOL2jhjvjKeVvAbpe3jKbL2NvbpFd7v7h5NvIduukatQeC2mdfmc+ovHfxjti8" +
            "0ChX5YyHIRPpqjUrtLjog==")]
        public string ConString {
            get {
                return ((string)(this["ConString"]));
            }
            set {
                this["ConString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\MyCompany\\8.SourceCode\\3.Projects\\20220820aldilaTipOdFreqMrDiepMrKhai\\info\\DAT" +
            "A\\DATABASE\\Database-Tip OD-Frequency- hieu chinh.csv")]
        public string PathCsvDataOd {
            get {
                return ((string)(this["PathCsvDataOd"]));
            }
            set {
                this["PathCsvDataOd"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\MyCompany\\8.SourceCode\\3.Projects\\20220820aldilaTipOdFreqMrDiepMrKhai\\info\\DAT" +
            "A\\DATABASE\\cong thuc G.csv")]
        public string PathCsvDataFormulaG {
            get {
                return ((string)(this["PathCsvDataFormulaG"]));
            }
            set {
                this["PathCsvDataFormulaG"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\MyCompany\\8.SourceCode\\3.Projects\\20220820aldilaTipOdFreqMrDiepMrKhai\\info\\DAT" +
            "A\\DATABASE\\cong thuc PO.csv")]
        public string PathCsvDataFormulaPo {
            get {
                return ((string)(this["PathCsvDataFormulaPo"]));
            }
            set {
                this["PathCsvDataFormulaPo"] = value;
            }
        }
    }
}
