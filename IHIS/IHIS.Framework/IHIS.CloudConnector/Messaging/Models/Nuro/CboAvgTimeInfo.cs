//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: nuro_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CboAvgTimeInfo")]
  public partial class CboAvgTimeInfo : global::ProtoBuf.IExtensible
  {
    public CboAvgTimeInfo() {}
    
    private string _time_term = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"time_term", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string time_term
    {
      get { return _time_term; }
      set { _time_term = value; }
    }
    private string _time_term2 = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"time_term2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string time_term2
    {
      get { return _time_term2; }
      set { _time_term2 = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}