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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ORCATransferOrdersClaimOrdersFeeInfo")]
  public partial class ORCATransferOrdersClaimOrdersFeeInfo : global::ProtoBuf.IExtensible
  {
    public ORCATransferOrdersClaimOrdersFeeInfo() {}
    
    private string _doc_uid = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"doc_uid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doc_uid
    {
      get { return _doc_uid; }
      set { _doc_uid = value; }
    }
    private string _confirm_date = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"confirm_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string confirm_date
    {
      get { return _confirm_date; }
      set { _confirm_date = value; }
    }
    private string _perform_time = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"perform_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string perform_time
    {
      get { return _perform_time; }
      set { _perform_time = value; }
    }
    private string _bundle_number = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"bundle_number", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bundle_number
    {
      get { return _bundle_number; }
      set { _bundle_number = value; }
    }
    private string _hangmog_code = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"hangmog_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hangmog_code
    {
      get { return _hangmog_code; }
      set { _hangmog_code = value; }
    }
    private string _doctor_id = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"doctor_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor_id
    {
      get { return _doctor_id; }
      set { _doctor_id = value; }
    }
    private string _gwa = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"gwa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa
    {
      get { return _gwa; }
      set { _gwa = value; }
    }
    private string _numb = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"numb", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string numb
    {
      get { return _numb; }
      set { _numb = value; }
    }
    private string _number_code = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"number_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string number_code
    {
      get { return _number_code; }
      set { _number_code = value; }
    }
    private string _cls_code = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"cls_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string cls_code
    {
      get { return _cls_code; }
      set { _cls_code = value; }
    }
    private string _gwa_name = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"gwa_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa_name
    {
      get { return _gwa_name; }
      set { _gwa_name = value; }
    }
    private string _acting_date = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"acting_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string acting_date
    {
      get { return _acting_date; }
      set { _acting_date = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
