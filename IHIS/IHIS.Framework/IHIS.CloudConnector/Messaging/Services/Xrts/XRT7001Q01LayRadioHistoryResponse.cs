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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"XRT7001Q01LayRadioHistoryResponse")]
  public partial class XRT7001Q01LayRadioHistoryResponse : global::ProtoBuf.IExtensible
  {
    public XRT7001Q01LayRadioHistoryResponse() {}
    
    private readonly global::System.Collections.Generic.List<XRT7001Q01LayRadioHistoryListItemInfo> _layRadioHistory_list = new global::System.Collections.Generic.List<XRT7001Q01LayRadioHistoryListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"layRadioHistory_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<XRT7001Q01LayRadioHistoryListItemInfo> layRadioHistory_list
    {
      get { return _layRadioHistory_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
