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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SchsSCH0201U99GrdTimeListResponse")]
  public partial class SchsSCH0201U99GrdTimeListResponse : global::ProtoBuf.IExtensible
  {
    public SchsSCH0201U99GrdTimeListResponse() {}
    
    private readonly global::System.Collections.Generic.List<SchsSCH0201U99GrdTimeListInfo> _order_list = new global::System.Collections.Generic.List<SchsSCH0201U99GrdTimeListInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"order_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<SchsSCH0201U99GrdTimeListInfo> order_list
    {
      get { return _order_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
