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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INJ1001U01SaveLayoutInfo")]
  public partial class INJ1001U01SaveLayoutInfo : global::ProtoBuf.IExtensible
  {
    public INJ1001U01SaveLayoutInfo() {}
    
    private string _pkinj1002 = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"pkinj1002", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkinj1002
    {
      get { return _pkinj1002; }
      set { _pkinj1002 = value; }
    }
    private string _acting_date = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"acting_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string acting_date
    {
      get { return _acting_date; }
      set { _acting_date = value; }
    }
    private string _hangmog_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"hangmog_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hangmog_name
    {
      get { return _hangmog_name; }
      set { _hangmog_name = value; }
    }
    private string _acting_flag = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"acting_flag", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string acting_flag
    {
      get { return _acting_flag; }
      set { _acting_flag = value; }
    }
    private string _tonggye_code = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"tonggye_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tonggye_code
    {
      get { return _tonggye_code; }
      set { _tonggye_code = value; }
    }
    private string _mix_group = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"mix_group", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string mix_group
    {
      get { return _mix_group; }
      set { _mix_group = value; }
    }
    private string _jujongja = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"jujongja", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jujongja
    {
      get { return _jujongja; }
      set { _jujongja = value; }
    }
    private string _silsi_remark = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"silsi_remark", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string silsi_remark
    {
      get { return _silsi_remark; }
      set { _silsi_remark = value; }
    }
    private string _row_state = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string row_state
    {
      get { return _row_state; }
      set { _row_state = value; }
    }
    private string _hangmog_code = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"hangmog_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hangmog_code
    {
      get { return _hangmog_code; }
      set { _hangmog_code = value; }
    }
    private string _fkocs1003 = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"fkocs1003", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fkocs1003
    {
      get { return _fkocs1003; }
      set { _fkocs1003 = value; }
    }
    private string _suryang = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"suryang", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string suryang
    {
      get { return _suryang; }
      set { _suryang = value; }
    }
    private string _nalsu = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"nalsu", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string nalsu
    {
      get { return _nalsu; }
      set { _nalsu = value; }
    }
    private string _dv = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"dv", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string dv
    {
      get { return _dv; }
      set { _dv = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
