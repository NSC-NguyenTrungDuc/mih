//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service2.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS2015U09GetTemplateComboBoxResponse")]
  public partial class OCS2015U09GetTemplateComboBoxResponse : global::ProtoBuf.IExtensible
  {
    public OCS2015U09GetTemplateComboBoxResponse() {}
    
    private readonly global::System.Collections.Generic.List<OCS2015U09GetTemplateComboBoxInfo> _template_list = new global::System.Collections.Generic.List<OCS2015U09GetTemplateComboBoxInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"template_list", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<OCS2015U09GetTemplateComboBoxInfo> template_list
    {
      get { return _template_list; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}