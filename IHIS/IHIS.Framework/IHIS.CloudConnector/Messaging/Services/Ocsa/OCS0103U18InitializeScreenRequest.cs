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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS0103U18InitializeScreenRequest")]
  public partial class OCS0103U18InitializeScreenRequest : global::ProtoBuf.IExtensible
  {
    public OCS0103U18InitializeScreenRequest() {}
    
    private string _m_order_mode = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"m_order_mode", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string m_order_mode
    {
      get { return _m_order_mode; }
      set { _m_order_mode = value; }
    }
    private LoadColumnCodeNameInfo _col_code_name = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"col_code_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public LoadColumnCodeNameInfo col_code_name
    {
      get { return _col_code_name; }
      set { _col_code_name = value; }
    }
    private GetMainGwaDoctorCodeInfo _gwa_doctor_code = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"gwa_doctor_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public GetMainGwaDoctorCodeInfo gwa_doctor_code
    {
      get { return _gwa_doctor_code; }
      set { _gwa_doctor_code = value; }
    }
    private string _user_id = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"user_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string user_id
    {
      get { return _user_id; }
      set { _user_id = value; }
    }
    private string _input_tab = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"input_tab", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_tab
    {
      get { return _input_tab; }
      set { _input_tab = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
