//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DRG0201U00PrDrgUpdateChulgoRequest")]
  public partial class DRG0201U00PrDrgUpdateChulgoRequest : global::ProtoBuf.IExtensible
  {
    public DRG0201U00PrDrgUpdateChulgoRequest() {}
    
    private string _jubsu_date = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"jubsu_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jubsu_date
    {
      get { return _jubsu_date; }
      set { _jubsu_date = value; }
    }
    private string _drg_bunho = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"drg_bunho", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string drg_bunho
    {
      get { return _drg_bunho; }
      set { _drg_bunho = value; }
    }
    private string _chulgo_date = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"chulgo_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string chulgo_date
    {
      get { return _chulgo_date; }
      set { _chulgo_date = value; }
    }
    private string _act_user = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"act_user", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string act_user
    {
      get { return _act_user; }
      set { _act_user = value; }
    }
    private string _chulgo_buseo = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"chulgo_buseo", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string chulgo_buseo
    {
      get { return _chulgo_buseo; }
      set { _chulgo_buseo = value; }
    }
    private string _wonyoi_order_yn = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"wonyoi_order_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string wonyoi_order_yn
    {
      get { return _wonyoi_order_yn; }
      set { _wonyoi_order_yn = value; }
    }
    private string _act_yn = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"act_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string act_yn
    {
      get { return _act_yn; }
      set { _act_yn = value; }
    }
    private readonly global::System.Collections.Generic.List<DRG0201U00InventoryInfo> _lst = new global::System.Collections.Generic.List<DRG0201U00InventoryInfo>();
    [global::ProtoBuf.ProtoMember(8, Name=@"lst", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<DRG0201U00InventoryInfo> lst
    {
      get { return _lst; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
