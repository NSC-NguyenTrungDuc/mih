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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BIL0102OrderListInfo")]
  public partial class BIL0102OrderListInfo : global::ProtoBuf.IExtensible
  {
    public BIL0102OrderListInfo() {}
    
    private string _order_name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"order_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_name
    {
      get { return _order_name; }
      set { _order_name = value; }
    }
    private string _unit = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"unit", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string unit
    {
      get { return _unit; }
      set { _unit = value; }
    }
    private string _price = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"price", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string price
    {
      get { return _price; }
      set { _price = value; }
    }
    private string _quantity = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"quantity", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string quantity
    {
      get { return _quantity; }
      set { _quantity = value; }
    }
    private string _amount = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"amount", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string amount
    {
      get { return _amount; }
      set { _amount = value; }
    }
    private string _insurance_pay = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"insurance_pay", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string insurance_pay
    {
      get { return _insurance_pay; }
      set { _insurance_pay = value; }
    }
    private string _patient_pay = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"patient_pay", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string patient_pay
    {
      get { return _patient_pay; }
      set { _patient_pay = value; }
    }
    private string _dept_req_nm = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"dept_req_nm", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string dept_req_nm
    {
      get { return _dept_req_nm; }
      set { _dept_req_nm = value; }
    }
    private string _doctor_req_nm = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"doctor_req_nm", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor_req_nm
    {
      get { return _doctor_req_nm; }
      set { _doctor_req_nm = value; }
    }
    private string _doctor_exc_nm = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"doctor_exc_nm", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor_exc_nm
    {
      get { return _doctor_exc_nm; }
      set { _doctor_exc_nm = value; }
    }
    private string _order_grp_nm = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"order_grp_nm", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_grp_nm
    {
      get { return _order_grp_nm; }
      set { _order_grp_nm = value; }
    }
    private string _discount_reason = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"discount_reason", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string discount_reason
    {
      get { return _discount_reason; }
      set { _discount_reason = value; }
    }
    private string _order_code = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"order_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string order_code
    {
      get { return _order_code; }
      set { _order_code = value; }
    }
    private string _fkocs1003 = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"fkocs1003", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fkocs1003
    {
      get { return _fkocs1003; }
      set { _fkocs1003 = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
