//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0108U00CreateComboResponse")]
  public partial class OCS0108U00CreateComboResponse : global::ProtoBuf.IExtensible
  {
    public OCS0108U00CreateComboResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCS0108U00CreateComboItemInfo> _combo_item = new global::System.Collections.Generic.List<OCS0108U00CreateComboItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"combo_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS0108U00CreateComboItemInfo> combo_item
    {
      get { return _combo_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}