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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2015U31GetTemplateTagsInfo")]
  public partial class OCS2015U31GetTemplateTagsInfo : global::ProtoBuf.IExtensible
  {
    public OCS2015U31GetTemplateTagsInfo() {}
    
    private string _tag_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"tag_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tag_id
    {
      get { return _tag_id; }
      set { _tag_id = value; }
    }
    private string _tag_code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"tag_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tag_code
    {
      get { return _tag_code; }
      set { _tag_code = value; }
    }
    private string _tag_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"tag_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tag_name
    {
      get { return _tag_name; }
      set { _tag_name = value; }
    }
    private string _type = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string type
    {
      get { return _type; }
      set { _type = value; }
    }
    private string _default_content = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"default_content", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string default_content
    {
      get { return _default_content; }
      set { _default_content = value; }
    }
    private string _tag_parent = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"tag_parent", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tag_parent
    {
      get { return _tag_parent; }
      set { _tag_parent = value; }
    }
    private string _tag_child = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"tag_child", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tag_child
    {
      get { return _tag_child; }
      set { _tag_child = value; }
    }
    private string _tag_level = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"tag_level", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tag_level
    {
      get { return _tag_level; }
      set { _tag_level = value; }
    }
    private string _template_id = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"template_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string template_id
    {
      get { return _template_id; }
      set { _template_id = value; }
    }
    private string _row_state = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string row_state
    {
      get { return _row_state; }
      set { _row_state = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
