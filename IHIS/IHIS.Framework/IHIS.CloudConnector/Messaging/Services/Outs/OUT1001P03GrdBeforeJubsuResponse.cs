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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OUT1001P03GrdBeforeJubsuResponse")]
  public partial class OUT1001P03GrdBeforeJubsuResponse : global::ProtoBuf.IExtensible
  {
    public OUT1001P03GrdBeforeJubsuResponse() {}
    
    private readonly global::System.Collections.Generic.List<OUT1001P03GrdBeforeJubsuInfo> _grd_before_jubsu_info = new global::System.Collections.Generic.List<OUT1001P03GrdBeforeJubsuInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_before_jubsu_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OUT1001P03GrdBeforeJubsuInfo> grd_before_jubsu_info
    {
      get { return _grd_before_jubsu_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
