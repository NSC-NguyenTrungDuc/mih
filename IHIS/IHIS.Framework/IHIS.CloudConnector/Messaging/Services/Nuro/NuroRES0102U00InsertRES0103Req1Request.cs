//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroRES0102U00InsertRES0103Req1Request")]
  public partial class NuroRES0102U00InsertRES0103Req1Request : global::ProtoBuf.IExtensible
  {
    public NuroRES0102U00InsertRES0103Req1Request() {}
    
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private string _doctor = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _am_start_hhmm = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"am_start_hhmm", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string am_start_hhmm
    {
      get { return _am_start_hhmm; }
      set { _am_start_hhmm = value; }
    }
    private string _pm_start_hhmm = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"pm_start_hhmm", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pm_start_hhmm
    {
      get { return _pm_start_hhmm; }
      set { _pm_start_hhmm = value; }
    }
    private string _remark = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"remark", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string remark
    {
      get { return _remark; }
      set { _remark = value; }
    }
    private string _jinryo_pre_date = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"jinryo_pre_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jinryo_pre_date
    {
      get { return _jinryo_pre_date; }
      set { _jinryo_pre_date = value; }
    }
    private string _am_end_hhmm = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"am_end_hhmm", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string am_end_hhmm
    {
      get { return _am_end_hhmm; }
      set { _am_end_hhmm = value; }
    }
    private string _pm_end_hhmm = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"pm_end_hhmm", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pm_end_hhmm
    {
      get { return _pm_end_hhmm; }
      set { _pm_end_hhmm = value; }
    }
    private string _am_gwa_room = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"am_gwa_room", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string am_gwa_room
    {
      get { return _am_gwa_room; }
      set { _am_gwa_room = value; }
    }
    private string _pm_gwa_room = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"pm_gwa_room", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pm_gwa_room
    {
      get { return _pm_gwa_room; }
      set { _pm_gwa_room = value; }
    }
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code
    {
      get { return _hosp_code; }
      set { _hosp_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
