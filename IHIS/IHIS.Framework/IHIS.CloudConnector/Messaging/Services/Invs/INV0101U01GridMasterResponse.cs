//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INV0101U01GridMasterResponse")]
  public partial class INV0101U01GridMasterResponse : global::ProtoBuf.IExtensible
  {
    public INV0101U01GridMasterResponse() {}
    
    private readonly global::System.Collections.Generic.List<INV0101U01GridMasterInfo> _grd_master_info = new global::System.Collections.Generic.List<INV0101U01GridMasterInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_master_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<INV0101U01GridMasterInfo> grd_master_info
    {
      get { return _grd_master_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
