//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BAS0212U00GrdItemInfo")]
  public partial class BAS0212U00GrdItemInfo : global::ProtoBuf.IExtensible
  {
    public BAS0212U00GrdItemInfo() {}
    
    private string _gongbi_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"gongbi_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gongbi_code
    {
      get { return _gongbi_code; }
      set { _gongbi_code = value; }
    }
    private string _start_date = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"start_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string start_date
    {
      get { return _start_date; }
      set { _start_date = value; }
    }
    private string _end_date = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"end_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string end_date
    {
      get { return _end_date; }
      set { _end_date = value; }
    }
    private string _law_no = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"law_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string law_no
    {
      get { return _law_no; }
      set { _law_no = value; }
    }
    private string _gongbi_name = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"gongbi_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gongbi_name
    {
      get { return _gongbi_name; }
      set { _gongbi_name = value; }
    }
    private string _total_yn = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"total_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string total_yn
    {
      get { return _total_yn; }
      set { _total_yn = value; }
    }
    private string _gongbi_jiyeok = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"gongbi_jiyeok", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gongbi_jiyeok
    {
      get { return _gongbi_jiyeok; }
      set { _gongbi_jiyeok = value; }
    }
    private string _row_state = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
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