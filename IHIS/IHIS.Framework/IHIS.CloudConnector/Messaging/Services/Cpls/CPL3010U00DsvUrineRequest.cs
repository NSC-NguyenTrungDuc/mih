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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPL3010U00DsvUrineRequest")]
  public partial class CPL3010U00DsvUrineRequest : global::ProtoBuf.IExtensible
  {
    public CPL3010U00DsvUrineRequest() {}
    
    private string _specimen_ser = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"specimen_ser", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string specimen_ser
    {
      get { return _specimen_ser; }
      set { _specimen_ser = value; }
    }
    private string _fkocs = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"fkocs", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fkocs
    {
      get { return _fkocs; }
      set { _fkocs = value; }
    }
    private string _in_out_gubun = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"in_out_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string in_out_gubun
    {
      get { return _in_out_gubun; }
      set { _in_out_gubun = value; }
    }
    private string _gubun = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gubun
    {
      get { return _gubun; }
      set { _gubun = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
