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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPL2010U00LayChkNamesResponse")]
  public partial class CPL2010U00LayChkNamesResponse : global::ProtoBuf.IExtensible
  {
    public CPL2010U00LayChkNamesResponse() {}
    
    private readonly global::System.Collections.Generic.List<CPL2010U00LayChkNameListItemInfo> _layChkNames_list = new global::System.Collections.Generic.List<CPL2010U00LayChkNameListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"layChkNames_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CPL2010U00LayChkNameListItemInfo> layChkNames_list
    {
      get { return _layChkNames_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}