﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IHIS.DRGS.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("IHIS.DRGS.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap excel {
            get {
                object obj = ResourceManager.GetObject("excel", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to コード.
        /// </summary>
        internal static string FindBox_Title_Code {
            get {
                return ResourceManager.GetString("FindBox_Title_Code", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to コード名称.
        /// </summary>
        internal static string FindBox_Title_Name {
            get {
                return ResourceManager.GetString("FindBox_Title_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 服用コードを入力してください。.
        /// </summary>
        internal static string MSG_REQUIRED_CODE {
            get {
                return ResourceManager.GetString("MSG_REQUIRED_CODE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 保存に失敗しました。.
        /// </summary>
        internal static string MSG_SAVE_FAILED {
            get {
                return ResourceManager.GetString("MSG_SAVE_FAILED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 保存が完了しました。.
        /// </summary>
        internal static string MSG_SAVE_SUCCESS {
            get {
                return ResourceManager.GetString("MSG_SAVE_SUCCESS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 保存.
        /// </summary>
        internal static string SAVE_CAP {
            get {
                return ResourceManager.GetString("SAVE_CAP", resourceCulture);
            }
        }
    }
}
