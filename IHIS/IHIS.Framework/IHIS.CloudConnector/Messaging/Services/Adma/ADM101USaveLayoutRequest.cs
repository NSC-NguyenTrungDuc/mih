//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ADM101USaveLayoutRequest")]
  public partial class ADM101USaveLayoutRequest : global::ProtoBuf.IExtensible
  {
    public ADM101USaveLayoutRequest() {}
    
    private readonly global::System.Collections.Generic.List<ADM101UGrdGroupItemInfo> _grd_group_item = new global::System.Collections.Generic.List<ADM101UGrdGroupItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_group_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ADM101UGrdGroupItemInfo> grd_group_item
    {
      get { return _grd_group_item; }
    }
  
    private readonly global::System.Collections.Generic.List<ADM101UgrdSystemItemInfo> _grd_system_item = new global::System.Collections.Generic.List<ADM101UgrdSystemItemInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"grd_system_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ADM101UgrdSystemItemInfo> grd_system_item
    {
      get { return _grd_system_item; }
    }
  
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}