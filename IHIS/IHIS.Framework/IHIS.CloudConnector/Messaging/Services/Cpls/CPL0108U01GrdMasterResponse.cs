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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPL0108U01GrdMasterResponse")]
  public partial class CPL0108U01GrdMasterResponse : global::ProtoBuf.IExtensible
  {
    public CPL0108U01GrdMasterResponse() {}
    
    private readonly global::System.Collections.Generic.List<CPL0108U01GrdMasterItemInfo> _grd_mst_item = new global::System.Collections.Generic.List<CPL0108U01GrdMasterItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_mst_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CPL0108U01GrdMasterItemInfo> grd_mst_item
    {
      get { return _grd_mst_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
