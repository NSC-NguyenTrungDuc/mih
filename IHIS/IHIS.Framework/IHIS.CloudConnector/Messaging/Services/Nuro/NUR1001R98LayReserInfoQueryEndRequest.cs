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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NUR1001R98LayReserInfoQueryEndRequest")]
  public partial class NUR1001R98LayReserInfoQueryEndRequest : global::ProtoBuf.IExtensible
  {
    public NUR1001R98LayReserInfoQueryEndRequest() {}
    
    private string _patient_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"patient_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string patient_code
    {
      get { return _patient_code; }
      set { _patient_code = value; }
    }
    private string _reser_date = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"reser_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reser_date
    {
      get { return _reser_date; }
      set { _reser_date = value; }
    }
    private readonly global::System.Collections.Generic.List<DataStringListItemInfo> _department_code = new global::System.Collections.Generic.List<DataStringListItemInfo>();
    [global::ProtoBuf.ProtoMember(3, Name=@"department_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<DataStringListItemInfo> department_code
    {
      get { return _department_code; }
    }
  
    private string _reser_yn = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"reser_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reser_yn
    {
      get { return _reser_yn; }
      set { _reser_yn = value; }
    }
    private string _row_num = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"row_num", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string row_num
    {
      get { return _row_num; }
      set { _row_num = value; }
    }
    private string _code_type = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"code_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code_type
    {
      get { return _code_type; }
      set { _code_type = value; }
    }
    private readonly global::System.Collections.Generic.List<DataStringListItemInfo> _reser_part = new global::System.Collections.Generic.List<DataStringListItemInfo>();
    [global::ProtoBuf.ProtoMember(7, Name=@"reser_part", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<DataStringListItemInfo> reser_part
    {
      get { return _reser_part; }
    }
  
    private string _code_type_getInfoText = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"code_type_getInfoText", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code_type_getInfoText
    {
      get { return _code_type_getInfoText; }
      set { _code_type_getInfoText = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}