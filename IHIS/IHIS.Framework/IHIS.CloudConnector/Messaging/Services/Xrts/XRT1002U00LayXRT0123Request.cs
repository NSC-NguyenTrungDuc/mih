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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"XRT1002U00LayXRT0123Request")]
  public partial class XRT1002U00LayXRT0123Request : global::ProtoBuf.IExtensible
  {
    public XRT1002U00LayXRT0123Request() {}
    
    private string _buwi_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"buwi_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string buwi_code
    {
      get { return _buwi_code; }
      set { _buwi_code = value; }
    }
    private string _xray_gubun = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"xray_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string xray_gubun
    {
      get { return _xray_gubun; }
      set { _xray_gubun = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
