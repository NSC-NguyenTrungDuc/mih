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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BIL2016U01LoadPatientInfo")]
  public partial class BIL2016U01LoadPatientInfo : global::ProtoBuf.IExtensible
  {
    public BIL2016U01LoadPatientInfo() {}
    
    private string _bill_date = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"bill_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bill_date
    {
      get { return _bill_date; }
      set { _bill_date = value; }
    }
    private string _bill_number = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"bill_number", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bill_number
    {
      get { return _bill_number; }
      set { _bill_number = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _suname = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"suname", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string suname
    {
      get { return _suname; }
      set { _suname = value; }
    }
    private string _birth = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"birth", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string birth
    {
      get { return _birth; }
      set { _birth = value; }
    }
    private string _sex = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"sex", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sex
    {
      get { return _sex; }
      set { _sex = value; }
    }
    private string _address = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"address", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string address
    {
      get { return _address; }
      set { _address = value; }
    }
    private string _phone = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"phone", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string phone
    {
      get { return _phone; }
      set { _phone = value; }
    }
    private string _comming_date = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"comming_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string comming_date
    {
      get { return _comming_date; }
      set { _comming_date = value; }
    }
    private string _type = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string type
    {
      get { return _type; }
      set { _type = value; }
    }
    private string _type_name = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"type_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string type_name
    {
      get { return _type_name; }
      set { _type_name = value; }
    }
    private string _fkout = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"fkout", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fkout
    {
      get { return _fkout; }
      set { _fkout = value; }
    }
    private string _paid_name = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"paid_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string paid_name
    {
      get { return _paid_name; }
      set { _paid_name = value; }
    }
    private string _type_money = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"type_money", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string type_money
    {
      get { return _type_money; }
      set { _type_money = value; }
    }
    private string _sum_amount = "";
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"sum_amount", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sum_amount
    {
      get { return _sum_amount; }
      set { _sum_amount = value; }
    }
    private string _sum_discount = "";
    [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name=@"sum_discount", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sum_discount
    {
      get { return _sum_discount; }
      set { _sum_discount = value; }
    }
    private string _sum_paid = "";
    [global::ProtoBuf.ProtoMember(17, IsRequired = false, Name=@"sum_paid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sum_paid
    {
      get { return _sum_paid; }
      set { _sum_paid = value; }
    }
    private string _sum_debt = "";
    [global::ProtoBuf.ProtoMember(18, IsRequired = false, Name=@"sum_debt", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sum_debt
    {
      get { return _sum_debt; }
      set { _sum_debt = value; }
    }
    private string _parent_invoiceno = "";
    [global::ProtoBuf.ProtoMember(19, IsRequired = false, Name=@"parent_invoiceno", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string parent_invoiceno
    {
      get { return _parent_invoiceno; }
      set { _parent_invoiceno = value; }
    }
    private string _status_flg = "";
    [global::ProtoBuf.ProtoMember(20, IsRequired = false, Name=@"status_flg", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status_flg
    {
      get { return _status_flg; }
      set { _status_flg = value; }
    }
    private string _ref_id = "";
    [global::ProtoBuf.ProtoMember(21, IsRequired = false, Name=@"ref_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string ref_id
    {
      get { return _ref_id; }
      set { _ref_id = value; }
    }
    private string _status_id = "";
    [global::ProtoBuf.ProtoMember(22, IsRequired = false, Name=@"status_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status_id
    {
      get { return _status_id; }
      set { _status_id = value; }
    }
    private string _pkbil0103 = "";
    [global::ProtoBuf.ProtoMember(23, IsRequired = false, Name=@"pkbil0103", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pkbil0103
    {
      get { return _pkbil0103; }
      set { _pkbil0103 = value; }
    }
    private string _status_text = "";
    [global::ProtoBuf.ProtoMember(24, IsRequired = false, Name=@"status_text", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status_text
    {
      get { return _status_text; }
      set { _status_text = value; }
    }
    private string _sys_id = "";
    [global::ProtoBuf.ProtoMember(25, IsRequired = false, Name=@"sys_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sys_id
    {
      get { return _sys_id; }
      set { _sys_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
