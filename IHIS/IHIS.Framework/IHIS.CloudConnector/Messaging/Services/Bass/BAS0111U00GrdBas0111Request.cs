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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BAS0111U00GrdBas0111Request")]
  public partial class BAS0111U00GrdBas0111Request : global::ProtoBuf.IExtensible
  {
    public BAS0111U00GrdBas0111Request() {}
    
    private string _f_hosp_code = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"f_hosp_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string f_hosp_code
    {
      get { return _f_hosp_code; }
      set { _f_hosp_code = value; }
    }
    private string _f_johap_gubun = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"f_johap_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string f_johap_gubun
    {
      get { return _f_johap_gubun; }
      set { _f_johap_gubun = value; }
    }
    private string _f_johap = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"f_johap", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string f_johap
    {
      get { return _f_johap; }
      set { _f_johap = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
