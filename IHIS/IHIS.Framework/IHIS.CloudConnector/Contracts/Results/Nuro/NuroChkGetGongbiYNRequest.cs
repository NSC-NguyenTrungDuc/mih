//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sample.proto

using System;

namespace IHIS.CloudConnector.Messaging
{
   
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NuroChkGetGongbiYNRequest")]
  public partial class NuroChkGetGongbiYNRequest : global::ProtoBuf.IExtensible
  {
    public NuroChkGetGongbiYNRequest() {}
    
    private string _gubun = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"gubun", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string gubun
    {
      get { return _gubun; }
      set { _gubun = value; }
    }
    private string _date = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"date", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string date
    {
      get { return _date; }
      set { _date = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}