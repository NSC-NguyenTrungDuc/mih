//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: schs_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SchsSCH0201Q04GetMonthReserListInfo")]
  public partial class SchsSCH0201Q04GetMonthReserListInfo : global::ProtoBuf.IExtensible
  {
    public SchsSCH0201Q04GetMonthReserListInfo() {}
    
    private string _holi_day = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"holi_day", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string holi_day
    {
      get { return _holi_day; }
      set { _holi_day = value; }
    }
    private string _reser_cnt = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"reser_cnt", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reser_cnt
    {
      get { return _reser_cnt; }
      set { _reser_cnt = value; }
    }
    private string _inwon_cnt = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"inwon_cnt", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string inwon_cnt
    {
      get { return _inwon_cnt; }
      set { _inwon_cnt = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
