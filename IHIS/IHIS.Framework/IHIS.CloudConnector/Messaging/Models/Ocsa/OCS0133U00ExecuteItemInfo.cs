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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0133U00ExecuteItemInfo")]
  public partial class OCS0133U00ExecuteItemInfo : global::ProtoBuf.IExtensible
  {
    public OCS0133U00ExecuteItemInfo() {}
    
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private string _input_control = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"input_control", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_control
    {
      get { return _input_control; }
      set { _input_control = value; }
    }
    private string _input_control_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"input_control_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_control_name
    {
      get { return _input_control_name; }
      set { _input_control_name = value; }
    }
    private string _specimen_cr_yn = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"specimen_cr_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string specimen_cr_yn
    {
      get { return _specimen_cr_yn; }
      set { _specimen_cr_yn = value; }
    }
    private string _suryang_cr_yn = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"suryang_cr_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string suryang_cr_yn
    {
      get { return _suryang_cr_yn; }
      set { _suryang_cr_yn = value; }
    }
    private string _ord_danui_cr_yn = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"ord_danui_cr_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string ord_danui_cr_yn
    {
      get { return _ord_danui_cr_yn; }
      set { _ord_danui_cr_yn = value; }
    }
    private string _dv_cr_yn = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"dv_cr_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string dv_cr_yn
    {
      get { return _dv_cr_yn; }
      set { _dv_cr_yn = value; }
    }
    private string _nalsu_cr_yn = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"nalsu_cr_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string nalsu_cr_yn
    {
      get { return _nalsu_cr_yn; }
      set { _nalsu_cr_yn = value; }
    }
    private string _jusa_cr_yn = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"jusa_cr_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jusa_cr_yn
    {
      get { return _jusa_cr_yn; }
      set { _jusa_cr_yn = value; }
    }
    private string _bogyong_code_cr_yn = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"bogyong_code_cr_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bogyong_code_cr_yn
    {
      get { return _bogyong_code_cr_yn; }
      set { _bogyong_code_cr_yn = value; }
    }
    private string _toiwon_drg_cr_yn = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"toiwon_drg_cr_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string toiwon_drg_cr_yn
    {
      get { return _toiwon_drg_cr_yn; }
      set { _toiwon_drg_cr_yn = value; }
    }
    private string _portable_cr_yn = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"portable_cr_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string portable_cr_yn
    {
      get { return _portable_cr_yn; }
      set { _portable_cr_yn = value; }
    }
    private string _amt_cr_yn = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"amt_cr_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string amt_cr_yn
    {
      get { return _amt_cr_yn; }
      set { _amt_cr_yn = value; }
    }
    private string _wonyoi_order_cr_yn = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"wonyoi_order_cr_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string wonyoi_order_cr_yn
    {
      get { return _wonyoi_order_cr_yn; }
      set { _wonyoi_order_cr_yn = value; }
    }
    private string _powder_cr_yn = "";
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"powder_cr_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string powder_cr_yn
    {
      get { return _powder_cr_yn; }
      set { _powder_cr_yn = value; }
    }
    private string _row_state = "";
    [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name=@"row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
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
