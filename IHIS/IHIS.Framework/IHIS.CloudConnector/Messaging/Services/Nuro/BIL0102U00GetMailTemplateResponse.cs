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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BIL0102U00GetMailTemplateResponse")]
  public partial class BIL0102U00GetMailTemplateResponse : global::ProtoBuf.IExtensible
  {
    public BIL0102U00GetMailTemplateResponse() {}
    
    private string _mail_template_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"mail_template_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string mail_template_id
    {
      get { return _mail_template_id; }
      set { _mail_template_id = value; }
    }
    private string _subject = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"subject", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string subject
    {
      get { return _subject; }
      set { _subject = value; }
    }
    private string _content = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"content", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string content
    {
      get { return _content; }
      set { _content = value; }
    }
    private string _gmoLink = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"gmoLink", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gmoLink
    {
      get { return _gmoLink; }
      set { _gmoLink = value; }
    }
    private string _invoice_no = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"invoice_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string invoice_no
    {
      get { return _invoice_no; }
      set { _invoice_no = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
