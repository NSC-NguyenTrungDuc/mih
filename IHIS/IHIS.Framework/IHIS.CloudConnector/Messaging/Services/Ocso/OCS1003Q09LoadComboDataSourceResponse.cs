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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OCS1003Q09LoadComboDataSourceResponse")]
  public partial class OCS1003Q09LoadComboDataSourceResponse : global::ProtoBuf.IExtensible
  {
    public OCS1003Q09LoadComboDataSourceResponse() {}
    
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _data_for_col_pay = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"data_for_col_pay", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> data_for_col_pay
    {
      get { return _data_for_col_pay; }
    }
  
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _data_for_portable_yn = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(2, Name=@"data_for_portable_yn", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> data_for_portable_yn
    {
      get { return _data_for_portable_yn; }
    }
  
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _data_for_jusa_spd_gubun = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(3, Name=@"data_for_jusa_spd_gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> data_for_jusa_spd_gubun
    {
      get { return _data_for_jusa_spd_gubun; }
    }
  
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _data_for_nalsu = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(4, Name=@"data_for_nalsu", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> data_for_nalsu
    {
      get { return _data_for_nalsu; }
    }
  
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _data_for_suryang = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(5, Name=@"data_for_suryang", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> data_for_suryang
    {
      get { return _data_for_suryang; }
    }
  
    private readonly global::System.Collections.Generic.List<ComboListItemInfo> _data_for_dv = new global::System.Collections.Generic.List<ComboListItemInfo>();
    [global::ProtoBuf.ProtoMember(6, Name=@"data_for_dv", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ComboListItemInfo> data_for_dv
    {
      get { return _data_for_dv; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}