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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0103U10FormLoadRequest")]
  public partial class OCS0103U10FormLoadRequest : global::ProtoBuf.IExtensible
  {
    public OCS0103U10FormLoadRequest() {}
    
    private GetUserOptionInfo _general_disp_yn = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"general_disp_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public GetUserOptionInfo general_disp_yn
    {
      get { return _general_disp_yn; }
      set { _general_disp_yn = value; }
    }
    private GetUserOptionInfo _sentou_search_yn = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"sentou_search_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public GetUserOptionInfo sentou_search_yn
    {
      get { return _sentou_search_yn; }
      set { _sentou_search_yn = value; }
    }
    private string _order_mode = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"order_mode", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_mode
    {
      get { return _order_mode; }
      set { _order_mode = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _pkinp1001 = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"pkinp1001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkinp1001
    {
      get { return _pkinp1001; }
      set { _pkinp1001 = value; }
    }
    private string _input_tab = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"input_tab", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_tab
    {
      get { return _input_tab; }
      set { _input_tab = value; }
    }
    private string _memb = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"memb", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string memb
    {
      get { return _memb; }
      set { _memb = value; }
    }
    private LoadOftenUsedTabInfo _used_tab_info = null;
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"used_tab_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public LoadOftenUsedTabInfo used_tab_info
    {
      get { return _used_tab_info; }
      set { _used_tab_info = value; }
    }
    private bool _is_check_drg_time = default(bool);
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"is_check_drg_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool is_check_drg_time
    {
      get { return _is_check_drg_time; }
      set { _is_check_drg_time = value; }
    }
    private LoadColumnCodeNameInfo _code_name_info = null;
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"code_name_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public LoadColumnCodeNameInfo code_name_info
    {
      get { return _code_name_info; }
      set { _code_name_info = value; }
    }
    private GetMainGwaDoctorCodeInfo _gwa_doctor_code_info = null;
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"gwa_doctor_code_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public GetMainGwaDoctorCodeInfo gwa_doctor_code_info
    {
      get { return _gwa_doctor_code_info; }
      set { _gwa_doctor_code_info = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
