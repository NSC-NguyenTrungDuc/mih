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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPL0101U00MakeFindWorkerRequest")]
  public partial class CPL0101U00MakeFindWorkerRequest : global::ProtoBuf.IExtensible
  {
    public CPL0101U00MakeFindWorkerRequest() {}
    
    private string _aCtr_name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"aCtr_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string aCtr_name
    {
      get { return _aCtr_name; }
      set { _aCtr_name = value; }
    }
    private string _code_type = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"code_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string code_type
    {
      get { return _code_type; }
      set { _code_type = value; }
    }
    private string _find1 = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"find1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string find1
    {
      get { return _find1; }
      set { _find1 = value; }
    }
    private string _find2 = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"find2", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string find2
    {
      get { return _find2; }
      set { _find2 = value; }
    }
    private string _system_gubun = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"system_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string system_gubun
    {
      get { return _system_gubun; }
      set { _system_gubun = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}