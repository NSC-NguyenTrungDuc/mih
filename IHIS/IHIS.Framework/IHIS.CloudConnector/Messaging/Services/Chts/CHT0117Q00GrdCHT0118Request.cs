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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CHT0117Q00GrdCHT0118Request")]
  public partial class CHT0117Q00GrdCHT0118Request : global::ProtoBuf.IExtensible
  {
    public CHT0117Q00GrdCHT0118Request() {}
    
    private string _gubun = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gubun
    {
      get { return _gubun; }
      set { _gubun = value; }
    }
    private string _buwi = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"buwi", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string buwi
    {
      get { return _buwi; }
      set { _buwi = value; }
    }
    private string _buwi_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"buwi_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string buwi_name
    {
      get { return _buwi_name; }
      set { _buwi_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
