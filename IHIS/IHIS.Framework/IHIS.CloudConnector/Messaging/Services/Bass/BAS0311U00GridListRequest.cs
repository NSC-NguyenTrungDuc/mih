//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BAS0311U00GridListRequest")]
  public partial class BAS0311U00GridListRequest : global::ProtoBuf.IExtensible
  {
    public BAS0311U00GridListRequest() {}
    
    private string _f_hosp_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"f_hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string f_hosp_code
    {
      get { return _f_hosp_code; }
      set { _f_hosp_code = value; }
    }
    private string _f_sg_code = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"f_sg_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string f_sg_code
    {
      get { return _f_sg_code; }
      set { _f_sg_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
