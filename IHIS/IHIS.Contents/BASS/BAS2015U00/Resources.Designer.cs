﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IHIS.BASS {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("IHIS.BASS.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to エクスポート.
        /// </summary>
        internal static string BTN_LIST_EXCUTE_TEXT {
            get {
                return ResourceManager.GetString("BTN_LIST_EXCUTE_TEXT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to インポート.
        /// </summary>
        internal static string BTN_LIST_UPDATE_TEXT {
            get {
                return ResourceManager.GetString("BTN_LIST_UPDATE_TEXT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 確認します.
        /// </summary>
        internal static string CAPTION_CONFIRM {
            get {
                return ResourceManager.GetString("CAPTION_CONFIRM", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [データを保存しますか？] [YES/保存][NO/取消].
        /// </summary>
        internal static string MSG_CONFIRM {
            get {
                return ResourceManager.GetString("MSG_CONFIRM", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to システムはエラーが発生しましたので、トランザクションがロールバックされます。.
        /// </summary>
        internal static string MSG_ERR {
            get {
                return ResourceManager.GetString("MSG_ERR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ファイルの出力が失敗です。.
        /// </summary>
        internal static string MSG_EXP_FAILED {
            get {
                return ResourceManager.GetString("MSG_EXP_FAILED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ファイルの出力が成功です。.
        /// </summary>
        internal static string MSG_EXP_SUCCESS {
            get {
                return ResourceManager.GetString("MSG_EXP_SUCCESS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This file is required {0} columns..
        /// </summary>
        internal static string MSG_FILE_VALIDATE {
            get {
                return ResourceManager.GetString("MSG_FILE_VALIDATE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to インポートファイルに成功.
        /// </summary>
        internal static string MSG_SUCCESS {
            get {
                return ResourceManager.GetString("MSG_SUCCESS", resourceCulture);
            }
        }
    }
}