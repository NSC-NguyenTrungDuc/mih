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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2016U00UpdateQuestionRequest")]
  public partial class OCS2016U00UpdateQuestionRequest : global::ProtoBuf.IExtensible
  {
    public OCS2016U00UpdateQuestionRequest() {}
    
    private string _grp_question_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"grp_question_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string grp_question_id
    {
      get { return _grp_question_id; }
      set { _grp_question_id = value; }
    }
    private string _upd_id = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"upd_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string upd_id
    {
      get { return _upd_id; }
      set { _upd_id = value; }
    }
    private string _content = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"content", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string content
    {
      get { return _content; }
      set { _content = value; }
    }
    private string _action_type = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"action_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string action_type
    {
      get { return _action_type; }
      set { _action_type = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}