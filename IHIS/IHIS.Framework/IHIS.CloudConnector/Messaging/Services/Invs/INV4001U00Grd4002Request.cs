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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"INV4001U00Grd4002Request")]
  public partial class INV4001U00Grd4002Request : global::ProtoBuf.IExtensible
  {
    public INV4001U00Grd4002Request() {}
    
    private string _f_fkinv4001 = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"f_fkinv4001", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string f_fkinv4001
    {
      get { return _f_fkinv4001; }
      set { _f_fkinv4001 = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
