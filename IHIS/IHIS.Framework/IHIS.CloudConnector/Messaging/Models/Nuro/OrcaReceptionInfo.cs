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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OrcaReceptionInfo")]
  public partial class OrcaReceptionInfo : global::ProtoBuf.IExtensible
  {
    public OrcaReceptionInfo() {}
    
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code
    {
      get { return _hosp_code; }
      set { _hosp_code = value; }
    }
    private string _fkout1001 = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"fkout1001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fkout1001
    {
      get { return _fkout1001; }
      set { _fkout1001 = value; }
    }
    private string _orca_reception_id = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"orca_reception_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string orca_reception_id
    {
      get { return _orca_reception_id; }
      set { _orca_reception_id = value; }
    }
    private string _gwa = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa
    {
      get { return _gwa; }
      set { _gwa = value; }
    }
    private string _doctor = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _order_time = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"order_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_time
    {
      get { return _order_time; }
      set { _order_time = value; }
    }
    private string _app_time = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"app_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string app_time
    {
      get { return _app_time; }
      set { _app_time = value; }
    }
    private string _regist_time = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"regist_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string regist_time
    {
      get { return _regist_time; }
      set { _regist_time = value; }
    }
    private string _perform_time = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"perform_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string perform_time
    {
      get { return _perform_time; }
      set { _perform_time = value; }
    }
    private string _io_flag = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"io_flag", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string io_flag
    {
      get { return _io_flag; }
      set { _io_flag = value; }
    }
    private string _time_clazz = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"time_clazz", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string time_clazz
    {
      get { return _time_clazz; }
      set { _time_clazz = value; }
    }
    private string _bund_num = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"bund_num", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bund_num
    {
      get { return _bund_num; }
      set { _bund_num = value; }
    }
    private string _clazz_code = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"clazz_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string clazz_code
    {
      get { return _clazz_code; }
      set { _clazz_code = value; }
    }
    private string _sub_code = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"sub_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sub_code
    {
      get { return _sub_code; }
      set { _sub_code = value; }
    }
    private string _act_code = "";
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"act_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string act_code
    {
      get { return _act_code; }
      set { _act_code = value; }
    }
    private string _active_flg = "";
    [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name=@"active_flg", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string active_flg
    {
      get { return _active_flg; }
      set { _active_flg = value; }
    }
    private string _sys_id = "";
    [global::ProtoBuf.ProtoMember(17, IsRequired = false, Name=@"sys_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sys_id
    {
      get { return _sys_id; }
      set { _sys_id = value; }
    }
    private string _udp_id = "";
    [global::ProtoBuf.ProtoMember(18, IsRequired = false, Name=@"udp_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string udp_id
    {
      get { return _udp_id; }
      set { _udp_id = value; }
    }
    private string _created = "";
    [global::ProtoBuf.ProtoMember(19, IsRequired = false, Name=@"created", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string created
    {
      get { return _created; }
      set { _created = value; }
    }
    private string _updated = "";
    [global::ProtoBuf.ProtoMember(20, IsRequired = false, Name=@"updated", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string updated
    {
      get { return _updated; }
      set { _updated = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}