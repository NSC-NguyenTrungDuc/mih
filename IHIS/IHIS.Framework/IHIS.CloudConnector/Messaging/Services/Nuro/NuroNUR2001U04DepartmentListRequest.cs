//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: nuro_service.proto
// Note: requires additional types generated from: nuro_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroNUR2001U04DepartmentListRequest")]
  public partial class NuroNUR2001U04DepartmentListRequest : global::ProtoBuf.IExtensible
  {
    public NuroNUR2001U04DepartmentListRequest() {}
    
    private string _coming_date;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"coming_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string coming_date
    {
      get { return _coming_date; }
      set { _coming_date = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}