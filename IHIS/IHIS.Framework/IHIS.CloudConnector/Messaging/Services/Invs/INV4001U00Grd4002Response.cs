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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INV4001U00Grd4002Response")]
  public partial class INV4001U00Grd4002Response : global::ProtoBuf.IExtensible
  {
    public INV4001U00Grd4002Response() {}
    
    private readonly global::System.Collections.Generic.List<INV4001U00Grd4002Info> _lst = new global::System.Collections.Generic.List<INV4001U00Grd4002Info>();
    [global::ProtoBuf.ProtoMember(1, Name=@"lst", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<INV4001U00Grd4002Info> lst
    {
      get { return _lst; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}