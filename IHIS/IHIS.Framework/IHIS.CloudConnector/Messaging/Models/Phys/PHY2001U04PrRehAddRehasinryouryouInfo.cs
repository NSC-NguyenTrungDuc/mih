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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PHY2001U04PrRehAddRehasinryouryouInfo")]
  public partial class PHY2001U04PrRehAddRehasinryouryouInfo : global::ProtoBuf.IExtensible
  {
    public PHY2001U04PrRehAddRehasinryouryouInfo() {}
    
    private string _sinryouryou_gubun = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"sinryouryou_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sinryouryou_gubun
    {
      get { return _sinryouryou_gubun; }
      set { _sinryouryou_gubun = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
