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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CPLMASTERUPLOADERCboMstTypeRequest")]
  public partial class CPLMASTERUPLOADERCboMstTypeRequest : global::ProtoBuf.IExtensible
  {
    public CPLMASTERUPLOADERCboMstTypeRequest() {}
    
    private bool _is_popup;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"is_popup", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool is_popup
    {
      get { return _is_popup; }
      set { _is_popup = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
