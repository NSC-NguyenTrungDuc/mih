//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: adma_service.proto
// Note: requires additional types generated from: adma_model.proto
// Note: requires additional types generated from: system_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ADM401UUpdateRequest")]
  public partial class ADM401UUpdateRequest : global::ProtoBuf.IExtensible
  {
    public ADM401UUpdateRequest() {}
    
    private bool _has_version = default(bool);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"has_version", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool has_version
    {
      get { return _has_version; }
      set { _has_version = value; }
    }
    private string _asm_ver = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"asm_ver", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string asm_ver
    {
      get { return _asm_ver; }
      set { _asm_ver = value; }
    }
    private string _asm_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"asm_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string asm_name
    {
      get { return _asm_name; }
      set { _asm_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
