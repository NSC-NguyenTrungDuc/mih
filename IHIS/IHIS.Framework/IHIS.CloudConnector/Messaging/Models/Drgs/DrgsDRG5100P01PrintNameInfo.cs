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

  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DrgsDRG5100P01PrintNameInfo")]
  public partial class DrgsDRG5100P01PrintNameInfo : global::ProtoBuf.IExtensible
  {
    public DrgsDRG5100P01PrintNameInfo() {}
    
    private string _b_print_name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"b_print_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string b_print_name
    {
      get { return _b_print_name; }
      set { _b_print_name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
