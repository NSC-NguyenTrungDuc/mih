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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PHY2001U04GrdExcelResponse")]
  public partial class PHY2001U04GrdExcelResponse : global::ProtoBuf.IExtensible
  {
    public PHY2001U04GrdExcelResponse() {}
    
    private readonly global::System.Collections.Generic.List<PHY2001U04GrdExcelInfo> _grd_excel_item = new global::System.Collections.Generic.List<PHY2001U04GrdExcelInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"grd_excel_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<PHY2001U04GrdExcelInfo> grd_excel_item
    {
      get { return _grd_excel_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
