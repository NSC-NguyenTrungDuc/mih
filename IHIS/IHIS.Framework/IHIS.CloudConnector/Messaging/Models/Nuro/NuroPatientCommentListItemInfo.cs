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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroPatientCommentListItemInfo")]
  public partial class NuroPatientCommentListItemInfo : global::ProtoBuf.IExtensible
  {
    public NuroPatientCommentListItemInfo() {}
    
    private string _comment;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"comment", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string comment
    {
      get { return _comment; }
      set { _comment = value; }
    }
    private string _ser;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"ser", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ser
    {
      get { return _ser; }
      set { _ser = value; }
    }
    private string _patient_code;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"patient_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string patient_code
    {
      get { return _patient_code; }
      set { _patient_code = value; }
    }
    private string _cont_key = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"cont_key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string cont_key
    {
      get { return _cont_key; }
      set { _cont_key = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
