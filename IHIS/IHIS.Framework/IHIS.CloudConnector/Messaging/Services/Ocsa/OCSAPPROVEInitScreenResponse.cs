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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCSAPPROVEInitScreenResponse")]
  public partial class OCSAPPROVEInitScreenResponse : global::ProtoBuf.IExtensible
  {
    public OCSAPPROVEInitScreenResponse() {}
    
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _cbo_suryang = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"cbo_suryang", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> cbo_suryang
    {
      get { return _cbo_suryang; }
    }
  
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _cbo_nalsu = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"cbo_nalsu", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> cbo_nalsu
    {
      get { return _cbo_nalsu; }
    }
  
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _cbo_dv = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(3, Name=@"cbo_dv", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> cbo_dv
    {
      get { return _cbo_dv; }
    }
  
    private bool _post_approve_visible = default(bool);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"post_approve_visible", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool post_approve_visible
    {
      get { return _post_approve_visible; }
      set { _post_approve_visible = value; }
    }
    private bool _approve_force = default(bool);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"approve_force", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool approve_force
    {
      get { return _approve_force; }
      set { _approve_force = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
