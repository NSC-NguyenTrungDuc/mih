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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SCH0201U99BookingDetailRequest")]
  public partial class SCH0201U99BookingDetailRequest : global::ProtoBuf.IExtensible
  {
    public SCH0201U99BookingDetailRequest() {}
    
    private string _jundal_table = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"jundal_table", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_table
    {
      get { return _jundal_table; }
      set { _jundal_table = value; }
    }
    private string _jundal_part = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"jundal_part", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string jundal_part
    {
      get { return _jundal_part; }
      set { _jundal_part = value; }
    }
    private string _reservation = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"reservation", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reservation
    {
      get { return _reservation; }
      set { _reservation = value; }
    }
    private string _reser_date = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"reser_date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string reser_date
    {
      get { return _reser_date; }
      set { _reser_date = value; }
    }
    private readonly global::System.Collections.Generic.List<SCH0201U99EMRLinkInfo> _emr_link_item = new global::System.Collections.Generic.List<SCH0201U99EMRLinkInfo>();
    [global::ProtoBuf.ProtoMember(5, Name=@"emr_link_item", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<SCH0201U99EMRLinkInfo> emr_link_item
    {
      get { return _emr_link_item; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
