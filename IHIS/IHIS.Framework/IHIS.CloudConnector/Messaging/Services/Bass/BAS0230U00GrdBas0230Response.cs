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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BAS0230U00GrdBas0230Response")]
  public partial class BAS0230U00GrdBas0230Response : global::ProtoBuf.IExtensible
  {
    public BAS0230U00GrdBas0230Response() {}
    
    private readonly global::System.Collections.Generic.List<BAS0230U00GrdBas0230Info> _grd_bas0230_info = new global::System.Collections.Generic.List<BAS0230U00GrdBas0230Info>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_bas0230_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<BAS0230U00GrdBas0230Info> grd_bas0230_info
    {
      get { return _grd_bas0230_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
