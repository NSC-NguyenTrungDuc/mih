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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0301Q09GrdOCS0301Info")]
  public partial class OCS0301Q09GrdOCS0301Info : global::ProtoBuf.IExtensible
  {
    public OCS0301Q09GrdOCS0301Info() {}
    
    private string _memb = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"memb", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string memb
    {
      get { return _memb; }
      set { _memb = value; }
    }
    private string _pk_seq = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"pk_seq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pk_seq
    {
      get { return _pk_seq; }
      set { _pk_seq = value; }
    }
    private string _yaksok_gubun = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"yaksok_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string yaksok_gubun
    {
      get { return _yaksok_gubun; }
      set { _yaksok_gubun = value; }
    }
    private string _yaksok_gubun_name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"yaksok_gubun_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string yaksok_gubun_name
    {
      get { return _yaksok_gubun_name; }
      set { _yaksok_gubun_name = value; }
    }
    private string _yaksok_code = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"yaksok_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string yaksok_code
    {
      get { return _yaksok_code; }
      set { _yaksok_code = value; }
    }
    private string _yaksok_name = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"yaksok_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string yaksok_name
    {
      get { return _yaksok_name; }
      set { _yaksok_name = value; }
    }
    private string _input_tab = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"input_tab", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_tab
    {
      get { return _input_tab; }
      set { _input_tab = value; }
    }
    private string _pk_yaksok = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"pk_yaksok", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pk_yaksok
    {
      get { return _pk_yaksok; }
      set { _pk_yaksok = value; }
    }
    private string _input_tab_name = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"input_tab_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_tab_name
    {
      get { return _input_tab_name; }
      set { _input_tab_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
