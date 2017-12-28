namespace IHIS.CloudConnector.Contracts.Results
{
    public enum ExecutionStatus
    {
        Timeout,
        Success,
        Failure,
        RequireVpn, // 9
        Maintainance, // 10
        Unknown
    }
}