//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: nuro_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroOUT0101U02GridGongbiListInfo")]
  public partial class NuroOUT0101U02GridGongbiListInfo : global::ProtoBuf.IExtensible
  {
    public NuroOUT0101U02GridGongbiListInfo() {}
    
    private string _start_date = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"start_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string start_date
    {
      get { return _start_date; }
      set { _start_date = value; }
    }
    private string _bunho = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bunho
    {
      get { return _bunho; }
      set { _bunho = value; }
    }
    private string _budamja_bunho = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"budamja_bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string budamja_bunho
    {
      get { return _budamja_bunho; }
      set { _budamja_bunho = value; }
    }
    private string _gongbi_code = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"gongbi_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gongbi_code
    {
      get { return _gongbi_code; }
      set { _gongbi_code = value; }
    }
    private string _sugubja_bunho = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"sugubja_bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sugubja_bunho
    {
      get { return _sugubja_bunho; }
      set { _sugubja_bunho = value; }
    }
    private string _end_date = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"end_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string end_date
    {
      get { return _end_date; }
      set { _end_date = value; }
    }
    private string _remark = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"remark", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string remark
    {
      get { return _remark; }
      set { _remark = value; }
    }
    private string _last_check_date = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"last_check_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string last_check_date
    {
      get { return _last_check_date; }
      set { _last_check_date = value; }
    }
    private string _gongbi_name = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"gongbi_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gongbi_name
    {
      get { return _gongbi_name; }
      set { _gongbi_name = value; }
    }
    private string _retrieve_yn = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"retrieve_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string retrieve_yn
    {
      get { return _retrieve_yn; }
      set { _retrieve_yn = value; }
    }
    private string _old_start_date = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"old_start_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string old_start_date
    {
      get { return _old_start_date; }
      set { _old_start_date = value; }
    }
    private string _end_yn = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"end_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string end_yn
    {
      get { return _end_yn; }
      set { _end_yn = value; }
    }
    private string _data_row_state = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"data_row_state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string data_row_state
    {
      get { return _data_row_state; }
      set { _data_row_state = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
