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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BAS2015U00ImportMasterDataRequest")]
  public partial class BAS2015U00ImportMasterDataRequest : global::ProtoBuf.IExtensible
  {
    public BAS2015U00ImportMasterDataRequest() {}
    
    private string _import_type = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"import_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string import_type
    {
      get { return _import_type; }
      set { _import_type = value; }
    }
    private byte[] _bytes_data = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"bytes_data", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public byte[] bytes_data
    {
      get { return _bytes_data; }
      set { _bytes_data = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
