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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2015U04EmrRecordLoadBookmarkContentResponse")]
  public partial class OCS2015U04EmrRecordLoadBookmarkContentResponse : global::ProtoBuf.IExtensible
  {
    public OCS2015U04EmrRecordLoadBookmarkContentResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCS2015U04EmrRecordLoadBookmarkContentInfo> _emr_bookmark_content_list = new global::System.Collections.Generic.List<OCS2015U04EmrRecordLoadBookmarkContentInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"emr_bookmark_content_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS2015U04EmrRecordLoadBookmarkContentInfo> emr_bookmark_content_list
    {
      get { return _emr_bookmark_content_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
