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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2015U31GetTemplateTagsResponse")]
  public partial class OCS2015U31GetTemplateTagsResponse : global::ProtoBuf.IExtensible
  {
    public OCS2015U31GetTemplateTagsResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCS2015U31GetTemplateTagsInfo> _tem_tag_root_item_info = new global::System.Collections.Generic.List<OCS2015U31GetTemplateTagsInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"tem_tag_root_item_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS2015U31GetTemplateTagsInfo> tem_tag_root_item_info
    {
      get { return _tem_tag_root_item_info; }
    }
  
    private readonly global::System.Collections.Generic.List<OCS2015U31GetTemplateTagsInfo> _tem_tag_node_item_info = new global::System.Collections.Generic.List<OCS2015U31GetTemplateTagsInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"tem_tag_node_item_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS2015U31GetTemplateTagsInfo> tem_tag_node_item_info
    {
      get { return _tem_tag_node_item_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
