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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OcsoOCS1003P01UpdateJubsuRequest")]
  public partial class OcsoOCS1003P01UpdateJubsuRequest : global::ProtoBuf.IExtensible
  {
      public OcsoOCS1003P01UpdateJubsuRequest() { }
    
    private string _naewon_yn;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"naewon_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string naewon_yn
    {
      get { return _naewon_yn; }
      set { _naewon_yn = value; }
    }
    private string _pk_naewon_key;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"pk_naewon_key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string pk_naewon_key
    {
      get { return _pk_naewon_key; }
      set { _pk_naewon_key = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
