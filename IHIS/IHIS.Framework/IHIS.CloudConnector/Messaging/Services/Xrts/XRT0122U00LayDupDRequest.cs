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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"XRT0122U00LayDupDRequest")]
  public partial class XRT0122U00LayDupDRequest : global::ProtoBuf.IExtensible
  {
    public XRT0122U00LayDupDRequest() {}
    
    private string _buwi_bunryu = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"buwi_bunryu", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string buwi_bunryu
    {
      get { return _buwi_bunryu; }
      set { _buwi_bunryu = value; }
    }
    private string _buwi_code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"buwi_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string buwi_code
    {
      get { return _buwi_code; }
      set { _buwi_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
