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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SchsSCH0201U99ExecTimeListRequest")]
  public partial class SchsSCH0201U99ExecTimeListRequest : global::ProtoBuf.IExtensible
  {
    public SchsSCH0201U99ExecTimeListRequest() {}
    
    private string _i_ip_address = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"i_ip_address", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string i_ip_address
    {
      get { return _i_ip_address; }
      set { _i_ip_address = value; }
    }
    private string _i_jundal_table = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"i_jundal_table", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string i_jundal_table
    {
      get { return _i_jundal_table; }
      set { _i_jundal_table = value; }
    }
    private string _i_jundal_part = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"i_jundal_part", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string i_jundal_part
    {
      get { return _i_jundal_part; }
      set { _i_jundal_part = value; }
    }
    private string _i_gumsaja = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"i_gumsaja", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string i_gumsaja
    {
      get { return _i_gumsaja; }
      set { _i_gumsaja = value; }
    }
    private string _i_reser_date = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"i_reser_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string i_reser_date
    {
      get { return _i_reser_date; }
      set { _i_reser_date = value; }
    }
    private string _hosp_code_link = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"hosp_code_link", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code_link
    {
      get { return _hosp_code_link; }
      set { _hosp_code_link = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
