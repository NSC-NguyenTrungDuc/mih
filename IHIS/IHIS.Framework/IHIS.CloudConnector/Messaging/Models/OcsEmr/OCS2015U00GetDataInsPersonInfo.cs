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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2015U00GetDataInsPersonInfo")]
  public partial class OCS2015U00GetDataInsPersonInfo : global::ProtoBuf.IExtensible
  {
    public OCS2015U00GetDataInsPersonInfo() {}
    
    private string _ins_person_no = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"ins_person_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string ins_person_no
    {
      get { return _ins_person_no; }
      set { _ins_person_no = value; }
    }
    private string _recipient_no = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"recipient_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string recipient_no
    {
      get { return _recipient_no; }
      set { _recipient_no = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
