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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OcsaOCS0208U00SaveLayoutRequest")]
  public partial class OcsaOCS0208U00SaveLayoutRequest : global::ProtoBuf.IExtensible
  {
    public OcsaOCS0208U00SaveLayoutRequest() {}
    
    private readonly global::System.Collections.Generic.List<OcsaOCS0208U00GrdOCS0208U00ListInfo> _grd_save_item = new global::System.Collections.Generic.List<OcsaOCS0208U00GrdOCS0208U00ListInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_save_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OcsaOCS0208U00GrdOCS0208U00ListInfo> grd_save_item
    {
      get { return _grd_save_item; }
    }
  
    private string _user_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private string _hosp_code = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
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
