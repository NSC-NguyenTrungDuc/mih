//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CLIS2015U02GrdProtocolRequest")]
  public partial class CLIS2015U02GrdProtocolRequest : global::ProtoBuf.IExtensible
  {
    public CLIS2015U02GrdProtocolRequest() {}
    
    private string _protocol_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"protocol_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string protocol_code
    {
      get { return _protocol_code; }
      set { _protocol_code = value; }
    }
    private string _protocol_name = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"protocol_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string protocol_name
    {
      get { return _protocol_name; }
      set { _protocol_name = value; }
    }
    private string _from_date = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"from_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string from_date
    {
      get { return _from_date; }
      set { _from_date = value; }
    }
    private string _to_date = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"to_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string to_date
    {
      get { return _to_date; }
      set { _to_date = value; }
    }
    private string _protocol_status = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"protocol_status", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string protocol_status
    {
      get { return _protocol_status; }
      set { _protocol_status = value; }
    }
    private string _patient_code = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"patient_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string patient_code
    {
      get { return _patient_code; }
      set { _patient_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}