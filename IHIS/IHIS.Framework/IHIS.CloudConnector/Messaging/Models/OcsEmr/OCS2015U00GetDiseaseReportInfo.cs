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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2015U00GetDiseaseReportInfo")]
  public partial class OCS2015U00GetDiseaseReportInfo : global::ProtoBuf.IExtensible
  {
    public OCS2015U00GetDiseaseReportInfo() {}
    
    private string _sang_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"sang_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sang_code
    {
      get { return _sang_code; }
      set { _sang_code = value; }
    }
    private string _sang_name = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"sang_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string sang_name
    {
      get { return _sang_name; }
      set { _sang_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
