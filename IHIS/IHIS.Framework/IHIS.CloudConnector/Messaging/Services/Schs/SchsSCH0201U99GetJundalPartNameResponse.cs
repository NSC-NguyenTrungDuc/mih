//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SchsSCH0201U99GetJundalPartNameResponse")]
  public partial class SchsSCH0201U99GetJundalPartNameResponse : global::ProtoBuf.IExtensible
  {
    public SchsSCH0201U99GetJundalPartNameResponse() {}
    
    private string _jundal_part_name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"jundal_part_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_part_name
    {
      get { return _jundal_part_name; }
      set { _jundal_part_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
