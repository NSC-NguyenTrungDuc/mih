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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RES1001U00SaveLayoutItemResponse")]
  public partial class RES1001U00SaveLayoutItemResponse : global::ProtoBuf.IExtensible
  {
    public RES1001U00SaveLayoutItemResponse() {}
    
    private bool _result;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool result
    {
      get { return _result; }
      set { _result = value; }
    }
    private string _err_code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"err_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string err_code
    {
      get { return _err_code; }
      set { _err_code = value; }
    }
    private string _doctor_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"doctor_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string doctor_name
    {
      get { return _doctor_name; }
      set { _doctor_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
