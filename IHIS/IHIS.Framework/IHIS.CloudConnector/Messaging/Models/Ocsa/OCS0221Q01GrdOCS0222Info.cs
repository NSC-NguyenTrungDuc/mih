//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0221Q01GrdOCS0222Info")]
  public partial class OCS0221Q01GrdOCS0222Info : global::ProtoBuf.IExtensible
  {
    public OCS0221Q01GrdOCS0222Info() {}
    
    private string _memb = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"memb", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string memb
    {
      get { return _memb; }
      set { _memb = value; }
    }
    private string _seq = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"seq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string seq
    {
      get { return _seq; }
      set { _seq = value; }
    }
    private string _serial = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"serial", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string serial
    {
      get { return _serial; }
      set { _serial = value; }
    }
    private string _comment_title = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"comment_title", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string comment_title
    {
      get { return _comment_title; }
      set { _comment_title = value; }
    }
    private string _comment_text = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"comment_text", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string comment_text
    {
      get { return _comment_text; }
      set { _comment_text = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
