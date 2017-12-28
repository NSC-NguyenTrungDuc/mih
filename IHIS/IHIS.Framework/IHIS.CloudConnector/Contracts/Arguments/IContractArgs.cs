using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments
{
    public interface IContractArgs
    {
        IExtensible GetRequestInstance();
    }
}