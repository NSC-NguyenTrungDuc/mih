//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: schs_service.proto
namespace IHIS.CloudConnector.Messaging
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SchsSCH0201Q01ReserListCboRequest")]
  public partial class SchsSCH0201Q01ReserListCboRequest : global::ProtoBuf.IExtensible
  {
    public SchsSCH0201Q01ReserListCboRequest() {}
    
    private string _from_date = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"from_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string from_date
    {
      get { return _from_date; }
      set { _from_date = value; }
    }
    private string _to_date = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"to_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string to_date
    {
      get { return _to_date; }
      set { _to_date = value; }
    }
    private string _jundal_table = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"jundal_table", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_table
    {
      get { return _jundal_table; }
      set { _jundal_table = value; }
    }
    private string _jundal_part = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"jundal_part", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_part
    {
      get { return _jundal_part; }
      set { _jundal_part = value; }
    }
    private bool _chkchecked = default(bool);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"chkchecked", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool chkchecked
    {
      get { return _chkchecked; }
      set { _chkchecked = value; }
    }
    private bool _is_selected_gumsa = default(bool);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"is_selected_gumsa", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool is_selected_gumsa
    {
      get { return _is_selected_gumsa; }
      set { _is_selected_gumsa = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}