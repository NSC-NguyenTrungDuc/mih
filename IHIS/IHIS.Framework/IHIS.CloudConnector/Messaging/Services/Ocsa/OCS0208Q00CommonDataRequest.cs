//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: ocsa_service.proto
// Note: requires additional types generated from: ocsa_model.proto
// Note: requires additional types generated from: ocs.lib_model.proto
// Note: requires additional types generated from: system_model.proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0208Q00CommonDataRequest")]
  public partial class OCS0208Q00CommonDataRequest : global::ProtoBuf.IExtensible
  {
    public OCS0208Q00CommonDataRequest() {}
    
    private ComboDataSourceInfo _dv_time_info = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"dv_time_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public ComboDataSourceInfo dv_time_info
    {
      get { return _dv_time_info; }
      set { _dv_time_info = value; }
    }
    private ComboDataSourceInfo _dv_info = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"dv_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public ComboDataSourceInfo dv_info
    {
      get { return _dv_info; }
      set { _dv_info = value; }
    }
    private string _bogyong_code = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"bogyong_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string bogyong_code
    {
      get { return _bogyong_code; }
      set { _bogyong_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
