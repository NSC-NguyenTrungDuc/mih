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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"XRT0001U00GrdXRTRequest")]
  public partial class XRT0001U00GrdXRTRequest : global::ProtoBuf.IExtensible
  {
    public XRT0001U00GrdXRTRequest() {}
    
    private string _txtParam = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"txtParam", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string txtParam
    {
      get { return _txtParam; }
      set { _txtParam = value; }
    }
    private string _xray_gubun = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"xray_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string xray_gubun
    {
      get { return _xray_gubun; }
      set { _xray_gubun = value; }
    }
    private string _special_yn = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"special_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string special_yn
    {
      get { return _special_yn; }
      set { _special_yn = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
