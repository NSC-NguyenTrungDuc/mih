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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ORCATransferOrdersDiseaseInfo")]
  public partial class ORCATransferOrdersDiseaseInfo : global::ProtoBuf.IExtensible
  {
    public ORCATransferOrdersDiseaseInfo() {}
    
    private string _diagnosis_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"diagnosis_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string diagnosis_code
    {
      get { return _diagnosis_code; }
      set { _diagnosis_code = value; }
    }
    private string _diagnosis_system = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"diagnosis_system", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string diagnosis_system
    {
      get { return _diagnosis_system; }
      set { _diagnosis_system = value; }
    }
    private string _diagnosis_start_date = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"diagnosis_start_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string diagnosis_start_date
    {
      get { return _diagnosis_start_date; }
      set { _diagnosis_start_date = value; }
    }
    private string _diagnosis_end_date = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"diagnosis_end_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string diagnosis_end_date
    {
      get { return _diagnosis_end_date; }
      set { _diagnosis_end_date = value; }
    }
    private string _mml_table_id = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"mml_table_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string mml_table_id
    {
      get { return _mml_table_id; }
      set { _mml_table_id = value; }
    }
    private string _diagnosis_category = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"diagnosis_category", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string diagnosis_category
    {
      get { return _diagnosis_category; }
      set { _diagnosis_category = value; }
    }
    private string _jusang_yn = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"jusang_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jusang_yn
    {
      get { return _jusang_yn; }
      set { _jusang_yn = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
