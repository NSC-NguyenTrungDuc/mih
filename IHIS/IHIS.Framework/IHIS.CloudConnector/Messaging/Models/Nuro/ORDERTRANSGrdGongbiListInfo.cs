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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ORDERTRANSGrdGongbiListInfo")]
  public partial class ORDERTRANSGrdGongbiListInfo : global::ProtoBuf.IExtensible
  {
    public ORDERTRANSGrdGongbiListInfo() {}
    
    private string _gongbi_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"gongbi_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gongbi_code
    {
      get { return _gongbi_code; }
      set { _gongbi_code = value; }
    }
    private string _gongbi_name = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"gongbi_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gongbi_name
    {
      get { return _gongbi_name; }
      set { _gongbi_name = value; }
    }
    private string _last_check_date = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"last_check_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string last_check_date
    {
      get { return _last_check_date; }
      set { _last_check_date = value; }
    }
    private string _budamja_bunho = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"budamja_bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string budamja_bunho
    {
      get { return _budamja_bunho; }
      set { _budamja_bunho = value; }
    }
    private string _sugubja_bunho = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"sugubja_bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sugubja_bunho
    {
      get { return _sugubja_bunho; }
      set { _sugubja_bunho = value; }
    }
    private string _select_yn = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"select_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string select_yn
    {
      get { return _select_yn; }
      set { _select_yn = value; }
    }
    private string _priority = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"priority", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string priority
    {
      get { return _priority; }
      set { _priority = value; }
    }
    private string _if_valid_yn = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"if_valid_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string if_valid_yn
    {
      get { return _if_valid_yn; }
      set { _if_valid_yn = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
