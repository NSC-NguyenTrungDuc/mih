using System;
using System.Reflection;
using IHIS.CloudConnector.Events;
using IHIS.CloudConnector.Mappings;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    using IHIS.CloudConnector.Messaging;
    [Serializable]
    public class RpcResult : IApplicationEvent
    {
        private readonly long _id;
        private readonly int _result;
        private readonly Object _payload;
        private static readonly MethodInfo MapMethod = GetMapMethod();

        private static MethodInfo GetMapMethod()
        {
            foreach (MethodInfo method in typeof(Mapper).GetMethods())
            {
                if (method.GetParameters().Length == 1 && method.IsGenericMethod && method.Name.Equals("Map"))
                {
                    return method;
                }
            }
            throw new InvalidOperationException("Can't find method Map");
        }

        public RpcResult(long id, int result, Object payload)
        {
            _id = id;
            _result = result;
            _payload = payload;
        }

        public long Id
        {
            get { return _id; }
        }public int Result
        {
            get { return _result; }
        }

        public T GetPayload<T>() where T : IContractResult
        {
            if (_payload == null || _result != (int)RpcMessage.Result.SUCCESS)
            {
                T val = Activator.CreateInstance<T>();

                // https://sofiamedix.atlassian.net/browse/MED-10582
                if (_result == (int)RpcMessage.Result.REQUIRE_VPN)
                {
                    val.ExecutionStatus = ExecutionStatus.RequireVpn;
                }
                // https://sofiamedix.atlassian.net/browse/MED-12344
                else if (_result == (int)RpcMessage.Result.MAINTAINANCE)
                {
                    val.ExecutionStatus = ExecutionStatus.Maintainance;
                }
                else
                {
                    val.ExecutionStatus = ExecutionStatus.Failure;
                }

                return val;
            }
            MethodInfo newMethod = MapMethod.MakeGenericMethod(typeof(T), _payload.GetType());
            newMethod.Invoke(Mapper.Instance, new object[] { _payload });

            MethodInfo method = MapMethod.MakeGenericMethod(new Type[] { typeof(T), _payload.GetType() });
            T retVal = (T)method.Invoke(Mapper.Instance, new object[] { _payload });
            retVal.ExecutionStatus = ExecutionStatus.Success;
            return retVal;
        }
    }
}