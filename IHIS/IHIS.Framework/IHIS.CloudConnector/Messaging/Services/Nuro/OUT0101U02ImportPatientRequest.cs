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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OUT0101U02ImportPatientRequest")]
  public partial class OUT0101U02ImportPatientRequest : global::ProtoBuf.IExtensible
  {
    public OUT0101U02ImportPatientRequest() {}
    
    private readonly global::System.Collections.Generic.List<OUT0101U02ImportPatientInfo> _patients = new global::System.Collections.Generic.List<OUT0101U02ImportPatientInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"patients", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OUT0101U02ImportPatientInfo> patients
    {
      get { return _patients; }
    }
  
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private bool _ignore_duplicate;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"ignore_duplicate", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool ignore_duplicate
    {
      get { return _ignore_duplicate; }
      set { _ignore_duplicate = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
