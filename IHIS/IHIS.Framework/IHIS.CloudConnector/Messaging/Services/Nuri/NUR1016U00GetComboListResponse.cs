//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
// Note: requires additional types generated from: system_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NUR1016U00GetComboListResponse")]
  public partial class NUR1016U00GetComboListResponse : global::ProtoBuf.IExtensible
  {
    public NUR1016U00GetComboListResponse() {}
    
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _xEditGridCell7_list = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"xEditGridCell7_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> xEditGridCell7_list
    {
      get { return _xEditGridCell7_list; }
    }
  
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _layComboSet_list = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"layComboSet_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> layComboSet_list
    {
      get { return _layComboSet_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}