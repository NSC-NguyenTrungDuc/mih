//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: bass_service.proto
// Note: requires additional types generated from: bass_model.proto
// Note: requires additional types generated from: system_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BAS0110Q00GrdBAS0110Request")]
  public partial class BAS0110Q00GrdBAS0110Request : global::ProtoBuf.IExtensible
  {
    public BAS0110Q00GrdBAS0110Request() {}
    
    private string _johap_gubun = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"johap_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string johap_gubun
    {
      get { return _johap_gubun; }
      set { _johap_gubun = value; }
    }
    private string _search_gubun = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"search_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string search_gubun
    {
      get { return _search_gubun; }
      set { _search_gubun = value; }
    }
    private string _search_word = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"search_word", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string search_word
    {
      get { return _search_word; }
      set { _search_word = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
