//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: chts_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CHT0110Q01GrdCHT0110MListInfo")]
  public partial class CHT0110Q01GrdCHT0110MListInfo : global::ProtoBuf.IExtensible
  {
    public CHT0110Q01GrdCHT0110MListInfo() {}
    
    private string _sang_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"sang_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sang_code
    {
      get { return _sang_code; }
      set { _sang_code = value; }
    }
    private string _sang_name = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"sang_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sang_name
    {
      get { return _sang_name; }
      set { _sang_name = value; }
    }
    private string _sang_name_han = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"sang_name_han", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sang_name_han
    {
      get { return _sang_name_han; }
      set { _sang_name_han = value; }
    }
    private string _sang_name_self = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"sang_name_self", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sang_name_self
    {
      get { return _sang_name_self; }
      set { _sang_name_self = value; }
    }
    private string _sang_name_inx = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"sang_name_inx", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sang_name_inx
    {
      get { return _sang_name_inx; }
      set { _sang_name_inx = value; }
    }
    private string _start_date = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"start_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string start_date
    {
      get { return _start_date; }
      set { _start_date = value; }
    }
    private string _bulyong_yn = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"bulyong_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bulyong_yn
    {
      get { return _bulyong_yn; }
      set { _bulyong_yn = value; }
    }
    private string _suga_sang_code = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"suga_sang_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string suga_sang_code
    {
      get { return _suga_sang_code; }
      set { _suga_sang_code = value; }
    }
    private string _suga_sang_name = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"suga_sang_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string suga_sang_name
    {
      get { return _suga_sang_name; }
      set { _suga_sang_name = value; }
    }
    private string _junyeom_bunryu = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"junyeom_bunryu", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string junyeom_bunryu
    {
      get { return _junyeom_bunryu; }
      set { _junyeom_bunryu = value; }
    }
    private string _junyeom_kind = "";
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"junyeom_kind", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string junyeom_kind
    {
      get { return _junyeom_kind; }
      set { _junyeom_kind = value; }
    }
    private string _samang_sang_group = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"samang_sang_group", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string samang_sang_group
    {
      get { return _samang_sang_group; }
      set { _samang_sang_group = value; }
    }
    private string _samang_group_name = "";
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"samang_group_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string samang_group_name
    {
      get { return _samang_group_name; }
      set { _samang_group_name = value; }
    }
    private string _rank_cnt = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"rank_cnt", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string rank_cnt
    {
      get { return _rank_cnt; }
      set { _rank_cnt = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}