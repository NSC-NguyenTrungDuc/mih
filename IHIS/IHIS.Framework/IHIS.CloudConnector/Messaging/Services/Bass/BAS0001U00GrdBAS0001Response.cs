//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input(1).proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BAS0001U00GrdBAS0001Response")]
  public partial class BAS0001U00GrdBAS0001Response : global::ProtoBuf.IExtensible
  {
    public BAS0001U00GrdBAS0001Response() {}
    
    private readonly global::System.Collections.Generic.List<BAS0001U00GrdBAS0001Info> _item_info = new global::System.Collections.Generic.List<BAS0001U00GrdBAS0001Info>();
    [global::ProtoBuf.ProtoMember(1, Name=@"item_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<BAS0001U00GrdBAS0001Info> item_info
    {
      get { return _item_info; }
    }
  
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _bank_info = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"bank_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> bank_info
    {
      get { return _bank_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
