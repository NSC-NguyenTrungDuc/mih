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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SyncKinkiDiseaseCacheResponse")]
  public partial class SyncKinkiDiseaseCacheResponse : global::ProtoBuf.IExtensible
  {
    public SyncKinkiDiseaseCacheResponse() {}
    
    private readonly global::System.Collections.Generic.List<DrugKinkiDiseaseInfo> _data_list = new global::System.Collections.Generic.List<DrugKinkiDiseaseInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"data_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<DrugKinkiDiseaseInfo> data_list
    {
      get { return _data_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
