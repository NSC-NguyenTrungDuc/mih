using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
  public class NuroOut1101Q01DoctorNameInfoResult : AbstractContractResult
  {
      public NuroOut1101Q01DoctorNameInfoResult() { }
    
    private NuroOUT1101Q01DoctorNameInfo _doctorNameInfo;
    public NuroOUT1101Q01DoctorNameInfo DoctorNameInfo
    {
      get { return _doctorNameInfo; }
      set { _doctorNameInfo = value; }
    }
  }
  
}