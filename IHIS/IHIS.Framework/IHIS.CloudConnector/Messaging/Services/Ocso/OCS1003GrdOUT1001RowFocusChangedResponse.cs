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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS1003GrdOUT1001RowFocusChangedResponse")]
  public partial class OCS1003GrdOUT1001RowFocusChangedResponse : global::ProtoBuf.IExtensible
  {
    public OCS1003GrdOUT1001RowFocusChangedResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCS1003Q02grdOCS1001Info> _grd_ocs1001_info = new global::System.Collections.Generic.List<OCS1003Q02grdOCS1001Info>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_ocs1001_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS1003Q02grdOCS1001Info> grd_ocs1001_info
    {
      get { return _grd_ocs1001_info; }
    }
  
    private readonly global::System.Collections.Generic.List<OCS1003Q02LayQueryLayoutInfo> _lay_query_layout_info = new global::System.Collections.Generic.List<OCS1003Q02LayQueryLayoutInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"lay_query_layout_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS1003Q02LayQueryLayoutInfo> lay_query_layout_info
    {
      get { return _lay_query_layout_info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}