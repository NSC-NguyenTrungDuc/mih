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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Adm107ULayDownListResponse")]
  public partial class Adm107ULayDownListResponse : global::ProtoBuf.IExtensible
  {
    public Adm107ULayDownListResponse() {}
    
    private readonly global::System.Collections.Generic.List<Adm107ULayDownListInfo> _lay_down_list_item = new global::System.Collections.Generic.List<Adm107ULayDownListInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"lay_down_list_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Adm107ULayDownListInfo> lay_down_list_item
    {
      get { return _lay_down_list_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
