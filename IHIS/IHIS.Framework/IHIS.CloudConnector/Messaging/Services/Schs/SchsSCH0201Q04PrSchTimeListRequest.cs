//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: schs_service.proto
// Note: requires additional types generated from: schs_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SchsSCH0201Q04PrSchTimeListRequest")]
  public partial class SchsSCH0201Q04PrSchTimeListRequest : global::ProtoBuf.IExtensible
  {
    public SchsSCH0201Q04PrSchTimeListRequest() {}
    
    private string _ip_addr = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"ip_addr", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string ip_addr
    {
      get { return _ip_addr; }
      set { _ip_addr = value; }
    }
    private string _jundal_table = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"jundal_table", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_table
    {
      get { return _jundal_table; }
      set { _jundal_table = value; }
    }
    private string _jundal_part = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"jundal_part", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_part
    {
      get { return _jundal_part; }
      set { _jundal_part = value; }
    }
    private string _gumsaja = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"gumsaja", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gumsaja
    {
      get { return _gumsaja; }
      set { _gumsaja = value; }
    }
    private string _reser_date = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"reser_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reser_date
    {
      get { return _reser_date; }
      set { _reser_date = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
