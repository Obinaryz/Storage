//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Storage.CMD.Languages {
    using System;
    using System.Reflection;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages_ru {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages_ru() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Storage.CMD.Languages.Messages.ru", typeof(Messages_ru).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string Hello {
            get {
                return ResourceManager.GetString("Hello", resourceCulture);
            }
        }
        
        internal static string EnterName {
            get {
                return ResourceManager.GetString("EnterName", resourceCulture);
            }
        }
        
        internal static string WorkerId {
            get {
                return ResourceManager.GetString("WorkerId", resourceCulture);
            }
        }
        
        internal static string WorkerCountry {
            get {
                return ResourceManager.GetString("WorkerCountry", resourceCulture);
            }
        }
        
        internal static string ContractData {
            get {
                return ResourceManager.GetString("ContractData", resourceCulture);
            }
        }
        
        internal static string WhatWant {
            get {
                return ResourceManager.GetString("WhatWant", resourceCulture);
            }
        }
        
        internal static string EnterrSell {
            get {
                return ResourceManager.GetString("EnterrSell", resourceCulture);
            }
        }
    }
}
