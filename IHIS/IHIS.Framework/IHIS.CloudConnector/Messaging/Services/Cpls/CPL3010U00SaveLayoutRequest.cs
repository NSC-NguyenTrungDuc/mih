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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPL3010U00SaveLayoutRequest")]
  public partial class CPL3010U00SaveLayoutRequest : global::ProtoBuf.IExtensible
  {
    public CPL3010U00SaveLayoutRequest() {}
    
    private readonly global::System.Collections.Generic.List<CPL3010U00GrdPartListItemInfo> _grd_part_info = new global::System.Collections.Generic.List<CPL3010U00GrdPartListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_part_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CPL3010U00GrdPartListItemInfo> grd_part_info
    {
      get { return _grd_part_info; }
    }
  
    private readonly global::System.Collections.Generic.List<CPL3010U00GrdGumListItemInfo> _grd_gum_info = new global::System.Collections.Generic.List<CPL3010U00GrdGumListItemInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"grd_gum_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CPL3010U00GrdGumListItemInfo> grd_gum_info
    {
      get { return _grd_gum_info; }
    }
  
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
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
