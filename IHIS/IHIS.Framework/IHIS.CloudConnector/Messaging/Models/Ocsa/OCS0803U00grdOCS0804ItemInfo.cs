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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0803U00grdOCS0804ItemInfo")]
  public partial class OCS0803U00grdOCS0804ItemInfo : global::ProtoBuf.IExtensible
  {
    public OCS0803U00grdOCS0804ItemInfo() {}
    
    private string _pat_status_gr = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"pat_status_gr", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pat_status_gr
    {
      get { return _pat_status_gr; }
      set { _pat_status_gr = value; }
    }
    private string _pat_status = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"pat_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pat_status
    {
      get { return _pat_status; }
      set { _pat_status = value; }
    }
    private string _pat_status_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"pat_status_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pat_status_name
    {
      get { return _pat_status_name; }
      set { _pat_status_name = value; }
    }
    private string _indispensable_yn = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"indispensable_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string indispensable_yn
    {
      get { return _indispensable_yn; }
      set { _indispensable_yn = value; }
    }
    private string _break_pat_status_code = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"break_pat_status_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string break_pat_status_code
    {
      get { return _break_pat_status_code; }
      set { _break_pat_status_code = value; }
    }
    private string _pat_status_code_name = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"pat_status_code_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string pat_status_code_name
    {
      get { return _pat_status_code_name; }
      set { _pat_status_code_name = value; }
    }
    private string _ment = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"ment", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string ment
    {
      get { return _ment; }
      set { _ment = value; }
    }
    private string _seq = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"seq", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string seq
    {
      get { return _seq; }
      set { _seq = value; }
    }
    private string _row_state = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
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
