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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCSACTCompositeSecondRequest")]
  public partial class OCSACTCompositeSecondRequest : global::ProtoBuf.IExtensible
  {
    public OCSACTCompositeSecondRequest() {}
    
    private OCSACTGrdJearyoRequest _grd_jearyo_param = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"grd_jearyo_param", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCSACTGrdJearyoRequest grd_jearyo_param
    {
      get { return _grd_jearyo_param; }
      set { _grd_jearyo_param = value; }
    }
    private OCSACTGrdSangByungRequest _grd_sang_param = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"grd_sang_param", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCSACTGrdSangByungRequest grd_sang_param
    {
      get { return _grd_sang_param; }
      set { _grd_sang_param = value; }
    }
    private OCSACTDefaultJearyoRequest _grd_default_param = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"grd_default_param", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public OCSACTDefaultJearyoRequest grd_default_param
    {
      get { return _grd_default_param; }
      set { _grd_default_param = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
