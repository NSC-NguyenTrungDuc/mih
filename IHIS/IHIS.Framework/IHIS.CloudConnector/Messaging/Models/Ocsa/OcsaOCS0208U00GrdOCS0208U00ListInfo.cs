//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ocsa_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OcsaOCS0208U00GrdOCS0208U00ListInfo")]
  public partial class OcsaOCS0208U00GrdOCS0208U00ListInfo : global::ProtoBuf.IExtensible
  {
    public OcsaOCS0208U00GrdOCS0208U00ListInfo() {}
    
    private string _doctor = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _seq = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"seq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string seq
    {
      get { return _seq; }
      set { _seq = value; }
    }
    private string _bogyong_code = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"bogyong_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bogyong_code
    {
      get { return _bogyong_code; }
      set { _bogyong_code = value; }
    }
    private string _bogyong_name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"bogyong_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bogyong_name
    {
      get { return _bogyong_name; }
      set { _bogyong_name = value; }
    }
    private string _bunryu1 = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"bunryu1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunryu1
    {
      get { return _bunryu1; }
      set { _bunryu1 = value; }
    }
    private string _data_row_state = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"data_row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string data_row_state
    {
      get { return _data_row_state; }
      set { _data_row_state = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
