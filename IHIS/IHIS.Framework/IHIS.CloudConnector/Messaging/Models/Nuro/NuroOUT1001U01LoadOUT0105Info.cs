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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroOUT1001U01LoadOUT0105Info")]
  public partial class NuroOUT1001U01LoadOUT0105Info : global::ProtoBuf.IExtensible
  {
    public NuroOUT1001U01LoadOUT0105Info() {}
    
    private string _gongbi_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"gongbi_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gongbi_code
    {
      get { return _gongbi_code; }
      set { _gongbi_code = value; }
    }
    private string _priority = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"priority", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string priority
    {
      get { return _priority; }
      set { _priority = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
