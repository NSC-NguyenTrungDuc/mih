//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
// Note: requires additional types generated from: import.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2015U00GetInfoEPortViewerResponse")]
  public partial class OCS2015U00GetInfoEPortViewerResponse : global::ProtoBuf.IExtensible
  {
    public OCS2015U00GetInfoEPortViewerResponse() {}
    
    private string _folder_path = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"folder_path", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string folder_path
    {
      get { return _folder_path; }
      set { _folder_path = value; }
    }
    private string _exe_path = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"exe_path", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string exe_path
    {
      get { return _exe_path; }
      set { _exe_path = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}