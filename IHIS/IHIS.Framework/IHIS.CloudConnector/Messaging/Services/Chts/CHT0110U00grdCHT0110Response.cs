//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CHT0110U00grdCHT0110Response")]
  public partial class CHT0110U00grdCHT0110Response : global::ProtoBuf.IExtensible
  {
    public CHT0110U00grdCHT0110Response() {}
    
    private readonly global::System.Collections.Generic.List<CHT0110U00grdCHT0110ItemInfo> _grd_item = new global::System.Collections.Generic.List<CHT0110U00grdCHT0110ItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CHT0110U00grdCHT0110ItemInfo> grd_item
    {
      get { return _grd_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
