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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SaveBIL2016U02Request")]
  public partial class SaveBIL2016U02Request : global::ProtoBuf.IExtensible
  {
    public SaveBIL2016U02Request() {}
    
    private readonly global::System.Collections.Generic.List<LoadGridBIL2016U02Info> _list_info = new global::System.Collections.Generic.List<LoadGridBIL2016U02Info>();
    [global::ProtoBuf.ProtoMember(1, Name=@"list_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<LoadGridBIL2016U02Info> list_info
    {
      get { return _list_info; }
    }
  
    private string _invoice_no = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"invoice_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string invoice_no
    {
      get { return _invoice_no; }
      set { _invoice_no = value; }
    }
    private string _invoice_date = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"invoice_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string invoice_date
    {
      get { return _invoice_date; }
      set { _invoice_date = value; }
    }
    private string _payment_code = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"payment_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string payment_code
    {
      get { return _payment_code; }
      set { _payment_code = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _suname = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"suname", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string suname
    {
      get { return _suname; }
      set { _suname = value; }
    }
    private string _address = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"address", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string address
    {
      get { return _address; }
      set { _address = value; }
    }
    private string _sex = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"sex", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sex
    {
      get { return _sex; }
      set { _sex = value; }
    }
    private string _birth = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"birth", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string birth
    {
      get { return _birth; }
      set { _birth = value; }
    }
    private string _naewon_date = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"naewon_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string naewon_date
    {
      get { return _naewon_date; }
      set { _naewon_date = value; }
    }
    private string _gwa = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa
    {
      get { return _gwa; }
      set { _gwa = value; }
    }
    private string _doctor = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"doctor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor
    {
      get { return _doctor; }
      set { _doctor = value; }
    }
    private string _gwa_name = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"gwa_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa_name
    {
      get { return _gwa_name; }
      set { _gwa_name = value; }
    }
    private string _doctor_name = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"doctor_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor_name
    {
      get { return _doctor_name; }
      set { _doctor_name = value; }
    }
    private string _bunho_type = "";
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"bunho_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho_type
    {
      get { return _bunho_type; }
      set { _bunho_type = value; }
    }
    private string _paid_name = "";
    [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name=@"paid_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string paid_name
    {
      get { return _paid_name; }
      set { _paid_name = value; }
    }
    private string _payment_name = "";
    [global::ProtoBuf.ProtoMember(17, IsRequired = false, Name=@"payment_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string payment_name
    {
      get { return _payment_name; }
      set { _payment_name = value; }
    }
    private string _fkout1001 = "";
    [global::ProtoBuf.ProtoMember(18, IsRequired = false, Name=@"fkout1001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fkout1001
    {
      get { return _fkout1001; }
      set { _fkout1001 = value; }
    }
    private string _amount = "";
    [global::ProtoBuf.ProtoMember(19, IsRequired = false, Name=@"amount", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string amount
    {
      get { return _amount; }
      set { _amount = value; }
    }
    private string _discount = "";
    [global::ProtoBuf.ProtoMember(20, IsRequired = false, Name=@"discount", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string discount
    {
      get { return _discount; }
      set { _discount = value; }
    }
    private string _revert_type = "";
    [global::ProtoBuf.ProtoMember(21, IsRequired = false, Name=@"revert_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string revert_type
    {
      get { return _revert_type; }
      set { _revert_type = value; }
    }
    private string _revert_comment = "";
    [global::ProtoBuf.ProtoMember(22, IsRequired = false, Name=@"revert_comment", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string revert_comment
    {
      get { return _revert_comment; }
      set { _revert_comment = value; }
    }
    private string _bunho_type_name = "";
    [global::ProtoBuf.ProtoMember(23, IsRequired = false, Name=@"bunho_type_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho_type_name
    {
      get { return _bunho_type_name; }
      set { _bunho_type_name = value; }
    }
    private string _phone = "";
    [global::ProtoBuf.ProtoMember(24, IsRequired = false, Name=@"phone", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string phone
    {
      get { return _phone; }
      set { _phone = value; }
    }
    private string _discount_type = "";
    [global::ProtoBuf.ProtoMember(25, IsRequired = false, Name=@"discount_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string discount_type
    {
      get { return _discount_type; }
      set { _discount_type = value; }
    }
    private string _row_state = "";
    [global::ProtoBuf.ProtoMember(26, IsRequired = false, Name=@"row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string row_state
    {
      get { return _row_state; }
      set { _row_state = value; }
    }
    private string _discount_reason_total = "";
    [global::ProtoBuf.ProtoMember(27, IsRequired = false, Name=@"discount_reason_total", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string discount_reason_total
    {
      get { return _discount_reason_total; }
      set { _discount_reason_total = value; }
    }
    private string _parent_invoice_no = "";
    [global::ProtoBuf.ProtoMember(28, IsRequired = false, Name=@"parent_invoice_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string parent_invoice_no
    {
      get { return _parent_invoice_no; }
      set { _parent_invoice_no = value; }
    }
    private string _status_flg = "";
    [global::ProtoBuf.ProtoMember(29, IsRequired = false, Name=@"status_flg", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status_flg
    {
      get { return _status_flg; }
      set { _status_flg = value; }
    }
    private string _type = "";
    [global::ProtoBuf.ProtoMember(30, IsRequired = false, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string type
    {
      get { return _type; }
      set { _type = value; }
    }
    private string _status_flg_parent_no_null = "";
    [global::ProtoBuf.ProtoMember(31, IsRequired = false, Name=@"status_flg_parent_no_null", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status_flg_parent_no_null
    {
      get { return _status_flg_parent_no_null; }
      set { _status_flg_parent_no_null = value; }
    }
    private string _revert_reason = "";
    [global::ProtoBuf.ProtoMember(32, IsRequired = false, Name=@"revert_reason", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string revert_reason
    {
      get { return _revert_reason; }
      set { _revert_reason = value; }
    }
    private string _amount_debt_latest = "";
    [global::ProtoBuf.ProtoMember(33, IsRequired = false, Name=@"amount_debt_latest", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string amount_debt_latest
    {
      get { return _amount_debt_latest; }
      set { _amount_debt_latest = value; }
    }
    private string _pay_money = "";
    [global::ProtoBuf.ProtoMember(34, IsRequired = false, Name=@"pay_money", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pay_money
    {
      get { return _pay_money; }
      set { _pay_money = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
