using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroRES0102U00GetDataGridViewResult : AbstractContractResult
    {
        private List<NuroRES0102U00GrdRES0102Info> _dataGridRes0102Info = new List<NuroRES0102U00GrdRES0102Info>();
        private List<NuroRES0102U00GrdRES0103Info> _dataGridRes0103Info = new List<NuroRES0102U00GrdRES0103Info>();
        private List<NuroRES0102U00GrdRES0103ResInfo> _dataGridRes0103ResInfo = new List<NuroRES0102U00GrdRES0103ResInfo>();
        private List<NuroRES0102U00GridDoctorInfo> _dataGridDoctorInfo = new List<NuroRES0102U00GridDoctorInfo>();

        public List<NuroRES0102U00GrdRES0102Info> DataGridRes0102Info
        {
            get { return this._dataGridRes0102Info; }
            set { this._dataGridRes0102Info = value; }
        }

        public List<NuroRES0102U00GrdRES0103Info> DataGridRes0103Info
        {
            get { return this._dataGridRes0103Info; }
            set { this._dataGridRes0103Info = value; }
        }

        public List<NuroRES0102U00GrdRES0103ResInfo> DataGridRes0103ResInfo
        {
            get { return this._dataGridRes0103ResInfo; }
            set { this._dataGridRes0103ResInfo = value; }
        }

        public List<NuroRES0102U00GridDoctorInfo> DataGridDoctorInfo
        {
            get { return this._dataGridDoctorInfo; }
            set { this._dataGridDoctorInfo = value; }
        }

        public NuroRES0102U00GetDataGridViewResult() { }

    }
}