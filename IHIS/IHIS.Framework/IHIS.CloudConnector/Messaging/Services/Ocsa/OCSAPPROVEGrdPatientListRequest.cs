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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCSAPPROVEGrdPatientListRequest")]
  public partial class OCSAPPROVEGrdPatientListRequest : global::ProtoBuf.IExtensible
  {
    public OCSAPPROVEGrdPatientListRequest() {}
    
    private string _input_gubun = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"input_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_gubun
    {
      get { return _input_gubun; }
      set { _input_gubun = value; }
    }
    private string _io_gubun = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"io_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string io_gubun
    {
      get { return _io_gubun; }
      set { _io_gubun = value; }
    }
    private string _doctor = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _instead_yn = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"instead_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string instead_yn
    {
      get { return _instead_yn; }
      set { _instead_yn = value; }
    }
    private string _approve_yn = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"approve_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string approve_yn
    {
      get { return _approve_yn; }
      set { _approve_yn = value; }
    }
    private string _input_tab = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"input_tab", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_tab
    {
      get { return _input_tab; }
      set { _input_tab = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}