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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2016U00LoadDiscussionRequest")]
  public partial class OCS2016U00LoadDiscussionRequest : global::ProtoBuf.IExtensible
  {
    public OCS2016U00LoadDiscussionRequest() {}
    
    private string _grp_question_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"grp_question_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string grp_question_id
    {
      get { return _grp_question_id; }
      set { _grp_question_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}