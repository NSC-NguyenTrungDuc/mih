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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCSACTGrdOrderRequest")]
  public partial class OCSACTGrdOrderRequest : global::ProtoBuf.IExtensible
  {
    public OCSACTGrdOrderRequest() {}
    
    private bool _rbx_non_act;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"rbx_non_act", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool rbx_non_act
    {
      get { return _rbx_non_act; }
      set { _rbx_non_act = value; }
    }
    private bool _rbx_act;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"rbx_act", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool rbx_act
    {
      get { return _rbx_act; }
      set { _rbx_act = value; }
    }
    private string _cbo_system = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"cbo_system", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string cbo_system
    {
      get { return _cbo_system; }
      set { _cbo_system = value; }
    }
    private string _cbo_val = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"cbo_val", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string cbo_val
    {
      get { return _cbo_val; }
      set { _cbo_val = value; }
    }
    private string _io_gubun = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"io_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string io_gubun
    {
      get { return _io_gubun; }
      set { _io_gubun = value; }
    }
    private string _act_gubun = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"act_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string act_gubun
    {
      get { return _act_gubun; }
      set { _act_gubun = value; }
    }
    private string _from_date = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"from_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string from_date
    {
      get { return _from_date; }
      set { _from_date = value; }
    }
    private string _to_date = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"to_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string to_date
    {
      get { return _to_date; }
      set { _to_date = value; }
    }
    private string _jundal_table_code = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"jundal_table_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_table_code
    {
      get { return _jundal_table_code; }
      set { _jundal_table_code = value; }
    }
    private string _jundal_part = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"jundal_part", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_part
    {
      get { return _jundal_part; }
      set { _jundal_part = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _gwa = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa
    {
      get { return _gwa; }
      set { _gwa = value; }
    }
    private string _doctor = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _system_id = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"system_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string system_id
    {
      get { return _system_id; }
      set { _system_id = value; }
    }
    private string _cbo_part = "";
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"cbo_part", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string cbo_part
    {
      get { return _cbo_part; }
      set { _cbo_part = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
