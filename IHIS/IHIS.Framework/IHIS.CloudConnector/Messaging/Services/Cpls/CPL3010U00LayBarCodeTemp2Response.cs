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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPL3010U00LayBarCodeTemp2Response")]
  public partial class CPL3010U00LayBarCodeTemp2Response : global::ProtoBuf.IExtensible
  {
    public CPL3010U00LayBarCodeTemp2Response() {}
    
    private readonly global::System.Collections.Generic.List<CPL3010U00LayBarCodeTemp2ListItemInfo> _lay_bar_code_temp2 = new global::System.Collections.Generic.List<CPL3010U00LayBarCodeTemp2ListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"lay_bar_code_temp2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<CPL3010U00LayBarCodeTemp2ListItemInfo> lay_bar_code_temp2
    {
      get { return _lay_bar_code_temp2; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}