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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2015U09GetRootTagsForContextResponse")]
  public partial class OCS2015U09GetRootTagsForContextResponse : global::ProtoBuf.IExtensible
  {
    public OCS2015U09GetRootTagsForContextResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCS2015U09GetTagsForContextInfo> _root_tag_list = new global::System.Collections.Generic.List<OCS2015U09GetTagsForContextInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"root_tag_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS2015U09GetTagsForContextInfo> root_tag_list
    {
      get { return _root_tag_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
