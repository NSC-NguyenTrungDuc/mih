//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: input(1).proto
namespace IHIS.CloudConnector.Messaging
{

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BIL0102U00GetExaminationInfoResponse")]
  public partial class BIL0102U00GetExaminationInfoResponse : global::ProtoBuf.IExtensible
  {
    public BIL0102U00GetExaminationInfoResponse() {}
    
    private string _naewon_date = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"naewon_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string naewon_date
    {
      get { return _naewon_date; }
      set { _naewon_date = value; }
    }
    private string _jubsu_time = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"jubsu_time", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jubsu_time
    {
      get { return _jubsu_time; }
      set { _jubsu_time = value; }
    }
    private BIL0102U00GetbankInfo _bank_info = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"bank_info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public BIL0102U00GetbankInfo bank_info
    {
      get { return _bank_info; }
      set { _bank_info = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
