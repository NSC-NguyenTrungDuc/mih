//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service2.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPL0000Q00LaySigeyulTempListItemInfo")]
  public partial class CPL0000Q00LaySigeyulTempListItemInfo : global::ProtoBuf.IExtensible
  {
    public CPL0000Q00LaySigeyulTempListItemInfo() {}
    
    private string _hangmog_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"hangmog_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hangmog_code
    {
      get { return _hangmog_code; }
      set { _hangmog_code = value; }
    }
    private string _specimen_code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"specimen_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string specimen_code
    {
      get { return _specimen_code; }
      set { _specimen_code = value; }
    }
    private string _specimen_name = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"specimen_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string specimen_name
    {
      get { return _specimen_name; }
      set { _specimen_name = value; }
    }
    private string _gumsa_name = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"gumsa_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gumsa_name
    {
      get { return _gumsa_name; }
      set { _gumsa_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}