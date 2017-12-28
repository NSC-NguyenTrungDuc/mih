namespace EmrDocker
{
    using IHIS.Framework;

    public interface IMainScreen
    {
        object Command(string commandName, CommonItemCollection commandParam);

        void CancelSaving(string emrRecordId, string updId);

        IHIS.OCS.PatientInfo MSelectedPatientInfo
        {
            get;
        }
    }
}
