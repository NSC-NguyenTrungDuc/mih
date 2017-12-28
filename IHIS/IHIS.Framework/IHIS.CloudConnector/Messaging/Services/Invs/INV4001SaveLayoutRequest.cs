using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Messaging
{
    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"INV4001SaveLayoutRequest")]
    public partial class INV4001SaveLayoutRequest : global::ProtoBuf.IExtensible
    {
        public INV4001SaveLayoutRequest() { }

        private readonly global::System.Collections.Generic.List<INV4001U00Grd4001Info> _inv4001 = new global::System.Collections.Generic.List<INV4001U00Grd4001Info>();
        [global::ProtoBuf.ProtoMember(1, Name = @"inv4001", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<INV4001U00Grd4001Info> inv4001
        {
            get { return _inv4001; }
        }

        private readonly global::System.Collections.Generic.List<INV4001U00Grd4002Info> _inv4002 = new global::System.Collections.Generic.List<INV4001U00Grd4002Info>();
        [global::ProtoBuf.ProtoMember(2, Name = @"inv4002", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<INV4001U00Grd4002Info> inv4002
        {
            get { return _inv4002; }
        }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
  
}
