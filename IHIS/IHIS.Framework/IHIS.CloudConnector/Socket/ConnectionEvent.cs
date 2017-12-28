using IHIS.CloudConnector.Events;

namespace IHIS.CloudConnector.Socket
{
    public class ConnectionEvent : IApplicationEvent
    {
        private readonly ConnectionStatus _status;

        public ConnectionEvent(ConnectionStatus status)
        {
            _status = status;
        }

        public ConnectionStatus Status
        {
            get { return _status; }
        }
    }
}