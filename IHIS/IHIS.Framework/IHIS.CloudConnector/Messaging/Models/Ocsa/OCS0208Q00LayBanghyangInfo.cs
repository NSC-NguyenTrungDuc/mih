//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ocsa_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0208Q00LayBanghyangInfo")]
  public partial class OCS0208Q00LayBanghyangInfo : global::ProtoBuf.IExtensible
  {
    public OCS0208Q00LayBanghyangInfo() {}
    
    private string _banghyang = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"banghyang", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string banghyang
    {
      get { return _banghyang; }
      set { _banghyang = value; }
    }
    private string _donbog_yn = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"donbog_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string donbog_yn
    {
      get { return _donbog_yn; }
      set { _donbog_yn = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}