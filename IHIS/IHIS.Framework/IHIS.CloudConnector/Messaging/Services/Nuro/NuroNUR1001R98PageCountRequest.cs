//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: nuro_service.proto
// Note: requires additional types generated from: nuro_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroNUR1001R98PageCountRequest")]
  public partial class NuroNUR1001R98PageCountRequest : global::ProtoBuf.IExtensible
  {
    public NuroNUR1001R98PageCountRequest() {}
    
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
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}