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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2016GetLinkingDepartmentInfo")]
  public partial class OCS2016GetLinkingDepartmentInfo : global::ProtoBuf.IExtensible
  {
    public OCS2016GetLinkingDepartmentInfo() {}
    
    private string _department_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"department_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string department_code
    {
      get { return _department_code; }
      set { _department_code = value; }
    }
    private string _department_name = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"department_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string department_name
    {
      get { return _department_name; }
      set { _department_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
