//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service2.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPL0000Q00GetSigeyulDataSelect2Response")]
  public partial class CPL0000Q00GetSigeyulDataSelect2Response : global::ProtoBuf.IExtensible
  {
    public CPL0000Q00GetSigeyulDataSelect2Response() {}
    
    private readonly global::System.Collections.Generic.List<CPL0000Q00GetSigeyulDataSelect2ListItemInfo> _result_list = new global::System.Collections.Generic.List<CPL0000Q00GetSigeyulDataSelect2ListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"result_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CPL0000Q00GetSigeyulDataSelect2ListItemInfo> result_list
    {
      get { return _result_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
