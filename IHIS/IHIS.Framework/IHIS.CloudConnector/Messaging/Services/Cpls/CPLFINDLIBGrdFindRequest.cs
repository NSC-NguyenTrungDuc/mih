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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPLFINDLIBGrdFindRequest")]
  public partial class CPLFINDLIBGrdFindRequest : global::ProtoBuf.IExtensible
  {
    public CPLFINDLIBGrdFindRequest() {}
    
    private string _isExist = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"isExist", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string isExist
    {
      get { return _isExist; }
      set { _isExist = value; }
    }
    private string _result_form = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"result_form", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string result_form
    {
      get { return _result_form; }
      set { _result_form = value; }
    }
    private string _find = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"find", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string find
    {
      get { return _find; }
      set { _find = value; }
    }
    private string _code_type = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"code_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code_type
    {
      get { return _code_type; }
      set { _code_type = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
