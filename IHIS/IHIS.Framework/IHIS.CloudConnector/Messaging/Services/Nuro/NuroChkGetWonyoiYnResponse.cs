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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroChkGetWonyoiYnResponse")]
  public partial class NuroChkGetWonyoiYnResponse : global::ProtoBuf.IExtensible
  {
    public NuroChkGetWonyoiYnResponse() {}
    
    private string _wonyoi_yn = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"wonyoi_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string wonyoi_yn
    {
      get { return _wonyoi_yn; }
      set { _wonyoi_yn = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}