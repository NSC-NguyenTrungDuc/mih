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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ORCATransferOrdersClaimInfo")]
  public partial class ORCATransferOrdersClaimInfo : global::ProtoBuf.IExtensible
  {
    public ORCATransferOrdersClaimInfo() {}
    
    private string _doc_uid_03 = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"doc_uid_03", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doc_uid_03
    {
      get { return _doc_uid_03; }
      set { _doc_uid_03 = value; }
    }
    private string _confirm_date_03 = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"confirm_date_03", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string confirm_date_03
    {
      get { return _confirm_date_03; }
      set { _confirm_date_03 = value; }
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
    private string _gwa_name = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"gwa_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gwa_name
    {
      get { return _gwa_name; }
      set { _gwa_name = value; }
    }
    private string _sg_code = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"sg_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sg_code
    {
      get { return _sg_code; }
      set { _sg_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
