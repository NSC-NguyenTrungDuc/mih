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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS4001U00SaveInfo")]
  public partial class OCS4001U00SaveInfo : global::ProtoBuf.IExtensible
  {
    public OCS4001U00SaveInfo() {}
    
    private string _id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string id
    {
      get { return _id; }
      set { _id = value; }
    }
    private string _tpl_code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"tpl_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tpl_code
    {
      get { return _tpl_code; }
      set { _tpl_code = value; }
    }
    private string _format_type = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"format_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string format_type
    {
      get { return _format_type; }
      set { _format_type = value; }
    }
    private string _form_code = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"form_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string form_code
    {
      get { return _form_code; }
      set { _form_code = value; }
    }
    private string _form_name = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"form_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string form_name
    {
      get { return _form_name; }
      set { _form_name = value; }
    }
    private string _input_content = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"input_content", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_content
    {
      get { return _input_content; }
      set { _input_content = value; }
    }
    private string _input_value = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"input_value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_value
    {
      get { return _input_value; }
      set { _input_value = value; }
    }
    private string _print_content = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"print_content", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string print_content
    {
      get { return _print_content; }
      set { _print_content = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code
    {
      get { return _hosp_code; }
      set { _hosp_code = value; }
    }
    private string _create_date = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"create_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string create_date
    {
      get { return _create_date; }
      set { _create_date = value; }
    }
    private string _print_datetime = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"print_datetime", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string print_datetime
    {
      get { return _print_datetime; }
      set { _print_datetime = value; }
    }
    private string _sys_id = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"sys_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sys_id
    {
      get { return _sys_id; }
      set { _sys_id = value; }
    }
    private string _sys_date = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"sys_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sys_date
    {
      get { return _sys_date; }
      set { _sys_date = value; }
    }
    private string _upd_id = "";
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"upd_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string upd_id
    {
      get { return _upd_id; }
      set { _upd_id = value; }
    }
    private string _upd_date = "";
    [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name=@"upd_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string upd_date
    {
      get { return _upd_date; }
      set { _upd_date = value; }
    }
    private string _active_flg = "";
    [global::ProtoBuf.ProtoMember(17, IsRequired = false, Name=@"active_flg", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string active_flg
    {
      get { return _active_flg; }
      set { _active_flg = value; }
    }
    private string _prescription_date = "";
    [global::ProtoBuf.ProtoMember(18, IsRequired = false, Name=@"prescription_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string prescription_date
    {
      get { return _prescription_date; }
      set { _prescription_date = value; }
    }
    private string _row_state = "";
    [global::ProtoBuf.ProtoMember(19, IsRequired = false, Name=@"row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
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