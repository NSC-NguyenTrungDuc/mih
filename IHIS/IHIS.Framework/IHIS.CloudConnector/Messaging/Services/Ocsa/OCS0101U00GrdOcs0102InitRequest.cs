//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0101U00GrdOcs0102InitRequest")]
  public partial class OCS0101U00GrdOcs0102InitRequest : global::ProtoBuf.IExtensible
  {
    public OCS0101U00GrdOcs0102InitRequest() {}
    
    private string _slip_gubun = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"slip_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string slip_gubun
    {
      get { return _slip_gubun; }
      set { _slip_gubun = value; }
    }
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code
    {
      get { return _hosp_code; }
      set { _hosp_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
