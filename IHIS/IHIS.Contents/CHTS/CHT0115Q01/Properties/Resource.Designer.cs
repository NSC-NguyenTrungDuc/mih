﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IHIS.CHTS.Properties {
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
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("IHIS.CHTS.Properties.Resource", typeof(Resource).Assembly);
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
        ///   Looks up a localized string similar to 保存失敗.
        /// </summary>
        internal static string mbxCap_JP {
            get {
                return ResourceManager.GetString("mbxCap_JP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 保存が完了しました。.
        /// </summary>
        internal static string mbxMsg_JP {
            get {
                return ResourceManager.GetString("mbxMsg_JP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 저장이 완료되었습니다..
        /// </summary>
        internal static string mbxMsg_Ko {
            get {
                return ResourceManager.GetString("mbxMsg_Ko", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 保存に失敗しました。.
        /// </summary>
        internal static string mbxMsg2_JP {
            get {
                return ResourceManager.GetString("mbxMsg2_JP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 저장이 실패하였습니다..
        /// </summary>
        internal static string mbxMsg2_Ko {
            get {
                return ResourceManager.GetString("mbxMsg2_Ko", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ]は既に登録されています。ご確認ください。.
        /// </summary>
        internal static string parent {
            get {
                return ResourceManager.GetString("parent", resourceCulture);
            }
        }
    }
}