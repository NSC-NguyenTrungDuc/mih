//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto
// Note: requires additional types generated from: mixed_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0304U00GrdOCS0306SaveLayoutRequest")]
  public partial class OCS0304U00GrdOCS0306SaveLayoutRequest : global::ProtoBuf.IExtensible
  {
    public OCS0304U00GrdOCS0306SaveLayoutRequest() {}
    
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private readonly global::System.Collections.Generic.List<OcsaOCS0304U00GrdOCS0306ListInfo> _grdOcs0306_list = new global::System.Collections.Generic.List<OcsaOCS0304U00GrdOCS0306ListInfo>();
    [global::ProtoBuf.ProtoMember(3, Name=@"grdOcs0306_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OcsaOCS0304U00GrdOCS0306ListInfo> grdOcs0306_list
    {
      get { return _grdOcs0306_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
