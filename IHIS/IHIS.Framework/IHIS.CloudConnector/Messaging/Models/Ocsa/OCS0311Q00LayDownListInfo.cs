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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0311Q00LayDownListInfo")]
  public partial class OCS0311Q00LayDownListInfo : global::ProtoBuf.IExtensible
  {
    public OCS0311Q00LayDownListInfo() {}
    
    private string _set_part = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"set_part", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string set_part
    {
      get { return _set_part; }
      set { _set_part = value; }
    }
    private string _hangmog_code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"hangmog_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hangmog_code
    {
      get { return _hangmog_code; }
      set { _hangmog_code = value; }
    }
    private string _set_code = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"set_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string set_code
    {
      get { return _set_code; }
      set { _set_code = value; }
    }
    private string _hangmog_code_set = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"hangmog_code_set", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hangmog_code_set
    {
      get { return _hangmog_code_set; }
      set { _hangmog_code_set = value; }
    }
    private string _hangmog_name = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"hangmog_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hangmog_name
    {
      get { return _hangmog_name; }
      set { _hangmog_name = value; }
    }
    private string _suryang = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"suryang", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string suryang
    {
      get { return _suryang; }
      set { _suryang = value; }
    }
    private string _danui = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"danui", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string danui
    {
      get { return _danui; }
      set { _danui = value; }
    }
    private string _danui_name = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"danui_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string danui_name
    {
      get { return _danui_name; }
      set { _danui_name = value; }
    }
    private string _bulyong_yn = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"bulyong_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bulyong_yn
    {
      get { return _bulyong_yn; }
      set { _bulyong_yn = value; }
    }
    private string _slip_name = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"slip_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string slip_name
    {
      get { return _slip_name; }
      set { _slip_name = value; }
    }
    private string _input_control = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"input_control", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_control
    {
      get { return _input_control; }
      set { _input_control = value; }
    }
    private string _bun_code = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"bun_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bun_code
    {
      get { return _bun_code; }
      set { _bun_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}