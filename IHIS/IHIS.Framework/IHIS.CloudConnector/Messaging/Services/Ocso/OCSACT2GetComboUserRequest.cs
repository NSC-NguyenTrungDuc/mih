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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCSACT2GetComboUserRequest")]
  public partial class OCSACT2GetComboUserRequest : global::ProtoBuf.IExtensible
  {
    public OCSACT2GetComboUserRequest() {}
    
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code
    {
      get { return _hosp_code; }
      set { _hosp_code = value; }
    }
    private string _jundal_table = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"jundal_table", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_table
    {
      get { return _jundal_table; }
      set { _jundal_table = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
