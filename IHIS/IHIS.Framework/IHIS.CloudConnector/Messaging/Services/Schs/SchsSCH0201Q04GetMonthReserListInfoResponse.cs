//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: schs_service.proto
// Note: requires additional types generated from: schs_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SchsSCH0201Q04GetMonthReserListInfoResponse")]
  public partial class SchsSCH0201Q04GetMonthReserListInfoResponse : global::ProtoBuf.IExtensible
  {
    public SchsSCH0201Q04GetMonthReserListInfoResponse() {}
    
    private readonly global::System.Collections.Generic.List<SchsSCH0201Q04GetMonthReserListInfo> _month_reser_list_item = new global::System.Collections.Generic.List<SchsSCH0201Q04GetMonthReserListInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"month_reser_list_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<SchsSCH0201Q04GetMonthReserListInfo> month_reser_list_item
    {
      get { return _month_reser_list_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
