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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroNUR1001R98PageCountResponse")]
  public partial class NuroNUR1001R98PageCountResponse : global::ProtoBuf.IExtensible
  {
    public NuroNUR1001R98PageCountResponse() {}
    
    private string _count = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"count", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string count
    {
      get { return _count; }
      set { _count = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}