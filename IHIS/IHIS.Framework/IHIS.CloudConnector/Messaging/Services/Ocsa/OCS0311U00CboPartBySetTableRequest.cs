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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0311U00CboPartBySetTableRequest")]
  public partial class OCS0311U00CboPartBySetTableRequest : global::ProtoBuf.IExtensible
  {
    public OCS0311U00CboPartBySetTableRequest() {}
    
    private string _curr_group_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"curr_group_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string curr_group_id
    {
      get { return _curr_group_id; }
      set { _curr_group_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
