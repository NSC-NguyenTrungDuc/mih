//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BAS0111U00GrdMasterItemInfo")]
  public partial class BAS0111U00GrdMasterItemInfo : global::ProtoBuf.IExtensible
  {
    public BAS0111U00GrdMasterItemInfo() {}
    
    private string _johap_gubun = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"johap_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string johap_gubun
    {
      get { return _johap_gubun; }
      set { _johap_gubun = value; }
    }
    private string _johap = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"johap", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string johap
    {
      get { return _johap; }
      set { _johap = value; }
    }
    private string _johap_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"johap_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string johap_name
    {
      get { return _johap_name; }
      set { _johap_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
