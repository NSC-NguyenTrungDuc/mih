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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PFE0101U00GrdDCodeInfo")]
  public partial class PFE0101U00GrdDCodeInfo : global::ProtoBuf.IExtensible
  {
    public PFE0101U00GrdDCodeInfo() {}
    
    private string _code_type = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"code_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code_type
    {
      get { return _code_type; }
      set { _code_type = value; }
    }
    private string _code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code
    {
      get { return _code; }
      set { _code = value; }
    }
    private string _code_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"code_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code_name
    {
      get { return _code_name; }
      set { _code_name = value; }
    }
    private string _code_name_re = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"code_name_re", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code_name_re
    {
      get { return _code_name_re; }
      set { _code_name_re = value; }
    }
    private string _code_value = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"code_value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code_value
    {
      get { return _code_value; }
      set { _code_value = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}