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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2015U31SaveLayoutRequest")]
  public partial class OCS2015U31SaveLayoutRequest : global::ProtoBuf.IExtensible
  {
    public OCS2015U31SaveLayoutRequest() {}
    
    private readonly global::System.Collections.Generic.List<OCS2015U31GetEmrTemplateInfo> _list_template = new global::System.Collections.Generic.List<OCS2015U31GetEmrTemplateInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"list_template", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS2015U31GetEmrTemplateInfo> list_template
    {
      get { return _list_template; }
    }
  
    private readonly global::System.Collections.Generic.List<OCS2015U31GetTemplateTagsInfo> _list_template_tag = new global::System.Collections.Generic.List<OCS2015U31GetTemplateTagsInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"list_template_tag", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS2015U31GetTemplateTagsInfo> list_template_tag
    {
      get { return _list_template_tag; }
    }
  
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private string _type = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name = @"type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string type
    {
        get { return _type; }
        set { _type = value; }
    }
    private string _dept_code = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name = @"dept_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string dept_code
    {
        get { return _dept_code; }
        set { _dept_code = value; }
    }
    private string _doctor_code = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name = @"doctor_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor_code
    {
        get { return _doctor_code; }
        set { _doctor_code = value; }
    }
    private string _clone_yn = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name = @"clone_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string clone_yn
    {
        get { return _clone_yn; }
        set { _clone_yn = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
