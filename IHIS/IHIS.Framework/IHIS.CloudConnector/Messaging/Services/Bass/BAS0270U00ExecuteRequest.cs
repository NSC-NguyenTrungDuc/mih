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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BAS0270U00ExecuteRequest")]
  public partial class BAS0270U00ExecuteRequest : global::ProtoBuf.IExtensible
  {
    public BAS0270U00ExecuteRequest() {}
    
    private readonly global::System.Collections.Generic.List<BAS0270U00GrdBAS0271Info> _grdBAS0271Info = new global::System.Collections.Generic.List<BAS0270U00GrdBAS0271Info>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grdBAS0271Info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<BAS0270U00GrdBAS0271Info> grdBAS0271Info
    {
      get { return _grdBAS0271Info; }
    }
  
    private readonly global::System.Collections.Generic.List<BAS0270U00GrdBAS0272Info> _grdBAS0272Info = new global::System.Collections.Generic.List<BAS0270U00GrdBAS0272Info>();
    [global::ProtoBuf.ProtoMember(2, Name=@"grdBAS0272Info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<BAS0270U00GrdBAS0272Info> grdBAS0272Info
    {
      get { return _grdBAS0272Info; }
    }
  
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string hosp_code
    {
      get { return _hosp_code; }
      set { _hosp_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
