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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PFE0101U01SaveLayoutRequest")]
  public partial class PFE0101U01SaveLayoutRequest : global::ProtoBuf.IExtensible
  {
    public PFE0101U01SaveLayoutRequest() {}
    
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private readonly global::System.Collections.Generic.List<PFE0101U01GrdDCodeInfo> _grd_dcode_item = new global::System.Collections.Generic.List<PFE0101U01GrdDCodeInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"grd_dcode_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<PFE0101U01GrdDCodeInfo> grd_dcode_item
    {
      get { return _grd_dcode_item; }
    }
  
    private readonly global::System.Collections.Generic.List<PFE0101U01GrdMCodeInfo> _grd_mcode_item = new global::System.Collections.Generic.List<PFE0101U01GrdMCodeInfo>();
    [global::ProtoBuf.ProtoMember(3, Name=@"grd_mcode_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<PFE0101U01GrdMCodeInfo> grd_mcode_item
    {
      get { return _grd_mcode_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
