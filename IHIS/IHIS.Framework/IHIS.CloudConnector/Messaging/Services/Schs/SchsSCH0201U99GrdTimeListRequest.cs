//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SchsSCH0201U99GrdTimeListRequest")]
  public partial class SchsSCH0201U99GrdTimeListRequest : global::ProtoBuf.IExtensible
  {
    public SchsSCH0201U99GrdTimeListRequest() {}
    
    private string _ip_addr = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"ip_addr", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string ip_addr
    {
      get { return _ip_addr; }
      set { _ip_addr = value; }
    }
    private string _out_hospcode = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"out_hospcode", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string out_hospcode
    {
      get { return _out_hospcode; }
      set { _out_hospcode = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}