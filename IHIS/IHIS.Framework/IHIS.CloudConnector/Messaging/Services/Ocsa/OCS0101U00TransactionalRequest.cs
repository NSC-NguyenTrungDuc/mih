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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0101U00TransactionalRequest")]
  public partial class OCS0101U00TransactionalRequest : global::ProtoBuf.IExtensible
  {
    public OCS0101U00TransactionalRequest() {}
    
    private readonly global::System.Collections.Generic.List<OCS0101U00GrdOcs0101ListItemInfo> _list_grd_ocs0101 = new global::System.Collections.Generic.List<OCS0101U00GrdOcs0101ListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"list_grd_ocs0101", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS0101U00GrdOcs0101ListItemInfo> list_grd_ocs0101
    {
      get { return _list_grd_ocs0101; }
    }
  
    private readonly global::System.Collections.Generic.List<OCS0101U00GrdOcs0102ListItemInfo> _list_grd_ocs0102 = new global::System.Collections.Generic.List<OCS0101U00GrdOcs0102ListItemInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"list_grd_ocs0102", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS0101U00GrdOcs0102ListItemInfo> list_grd_ocs0102
    {
      get { return _list_grd_ocs0102; }
    }
  
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code
    {
      get { return _hosp_code; }
      set { _hosp_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
