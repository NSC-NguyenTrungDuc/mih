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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DOC4003U00GetHospInfo")]
  public partial class DOC4003U00GetHospInfo : global::ProtoBuf.IExtensible
  {
    public DOC4003U00GetHospInfo() {}
    
    private string _zip_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"zip_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string zip_code
    {
      get { return _zip_code; }
      set { _zip_code = value; }
    }
    private string _address = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"address", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string address
    {
      get { return _address; }
      set { _address = value; }
    }
    private string _tel = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"tel", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string tel
    {
      get { return _tel; }
      set { _tel = value; }
    }
    private string _yoyang_name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"yoyang_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string yoyang_name
    {
      get { return _yoyang_name; }
      set { _yoyang_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
