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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2016U00LoadDiscussionResponse")]
  public partial class OCS2016U00LoadDiscussionResponse : global::ProtoBuf.IExtensible
  {
    public OCS2016U00LoadDiscussionResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCS2016U00LoadDiscussionInfo> _item_discussion_info = new global::System.Collections.Generic.List<OCS2016U00LoadDiscussionInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"item_discussion_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS2016U00LoadDiscussionInfo> item_discussion_info
    {
      get { return _item_discussion_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}