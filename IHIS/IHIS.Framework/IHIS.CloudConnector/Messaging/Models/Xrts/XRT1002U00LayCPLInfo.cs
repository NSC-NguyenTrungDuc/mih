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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"XRT1002U00LayCPLInfo")]
  public partial class XRT1002U00LayCPLInfo : global::ProtoBuf.IExtensible
  {
    public XRT1002U00LayCPLInfo() {}
    
    private string _hangmog_name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"hangmog_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hangmog_name
    {
      get { return _hangmog_name; }
      set { _hangmog_name = value; }
    }
    private string _hangmog_result = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"hangmog_result", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hangmog_result
    {
      get { return _hangmog_result; }
      set { _hangmog_result = value; }
    }
    private string _hangmog_result_date = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"hangmog_result_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hangmog_result_date
    {
      get { return _hangmog_result_date; }
      set { _hangmog_result_date = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
