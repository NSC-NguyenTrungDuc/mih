//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input(1).proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NUR2016CheckExitsEMRLinkRequest")]
  public partial class NUR2016CheckExitsEMRLinkRequest : global::ProtoBuf.IExtensible
  {
    public NUR2016CheckExitsEMRLinkRequest() {}
    
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code
    {
      get { return _hosp_code; }
      set { _hosp_code = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _hosp_code_link = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"hosp_code_link", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code_link
    {
      get { return _hosp_code_link; }
      set { _hosp_code_link = value; }
    }
    private string _bunho_link = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"bunho_link", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho_link
    {
      get { return _bunho_link; }
      set { _bunho_link = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}