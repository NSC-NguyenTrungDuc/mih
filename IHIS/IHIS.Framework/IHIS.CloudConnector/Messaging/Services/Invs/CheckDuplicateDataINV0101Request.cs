//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CheckDuplicateDataINV0101Request")]
  public partial class CheckDuplicateDataINV0101Request : global::ProtoBuf.IExtensible
  {
    public CheckDuplicateDataINV0101Request() {}
    
    private string _code_type = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"code_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code_type
    {
      get { return _code_type; }
      set { _code_type = value; }
    }
    private string _code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code
    {
      get { return _code; }
      set { _code = value; }
    }
    private string _is_master = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"is_master", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string is_master
    {
      get { return _is_master; }
      set { _is_master = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
