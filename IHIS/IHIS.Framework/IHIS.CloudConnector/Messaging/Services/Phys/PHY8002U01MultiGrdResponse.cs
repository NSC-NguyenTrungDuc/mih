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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PHY8002U01MultiGrdResponse")]
  public partial class PHY8002U01MultiGrdResponse : global::ProtoBuf.IExtensible
  {
    public PHY8002U01MultiGrdResponse() {}
    
    private readonly global::System.Collections.Generic.List<PHY8002U01GrdOTListItemInfo> _grdOT_list = new global::System.Collections.Generic.List<PHY8002U01GrdOTListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grdOT_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<PHY8002U01GrdOTListItemInfo> grdOT_list
    {
      get { return _grdOT_list; }
    }
  
    private readonly global::System.Collections.Generic.List<PHY8002U01GrdOTListItemInfo> _grdPT_list = new global::System.Collections.Generic.List<PHY8002U01GrdOTListItemInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"grdPT_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<PHY8002U01GrdOTListItemInfo> grdPT_list
    {
      get { return _grdPT_list; }
    }
  
    private readonly global::System.Collections.Generic.List<PHY8002U01GrdOTListItemInfo> _grdST_list = new global::System.Collections.Generic.List<PHY8002U01GrdOTListItemInfo>();
    [global::ProtoBuf.ProtoMember(3, Name=@"grdST_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<PHY8002U01GrdOTListItemInfo> grdST_list
    {
      get { return _grdST_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
