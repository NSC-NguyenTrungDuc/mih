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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPL3020U00FwkNoteGubunRequest")]
  public partial class CPL3020U00FwkNoteGubunRequest : global::ProtoBuf.IExtensible
  {
    public CPL3020U00FwkNoteGubunRequest() {}
    
    private string _jundal_gubun = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"jundal_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_gubun
    {
      get { return _jundal_gubun; }
      set { _jundal_gubun = value; }
    }
    private string _find1 = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"find1", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string find1
    {
      get { return _find1; }
      set { _find1 = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}