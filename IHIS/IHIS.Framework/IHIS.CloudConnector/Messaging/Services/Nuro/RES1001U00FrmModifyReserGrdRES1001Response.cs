//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: nuro_service.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RES1001U00FrmModifyReserGrdRES1001Response")]
  public partial class RES1001U00FrmModifyReserGrdRES1001Response : global::ProtoBuf.IExtensible
  {
    public RES1001U00FrmModifyReserGrdRES1001Response() {}
    
    private readonly global::System.Collections.Generic.List<RES1001U00FrmModifyReserGrdRES1001Info> _grd_res1001_info = new global::System.Collections.Generic.List<RES1001U00FrmModifyReserGrdRES1001Info>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_res1001_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<RES1001U00FrmModifyReserGrdRES1001Info> grd_res1001_info
    {
      get { return _grd_res1001_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
