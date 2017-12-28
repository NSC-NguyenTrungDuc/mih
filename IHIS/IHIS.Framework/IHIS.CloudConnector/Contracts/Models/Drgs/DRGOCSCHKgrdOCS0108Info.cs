using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    public class DRGOCSCHKgrdOCS0108Info
    {
        private String _hangmogCode;
        private String _ordDanui;
        private String _seq;
        private String _changeQty1;
        private String _changeQty2;
        private String _hospCode;
        private String _hangmogStartDate;
        private String _changeDanui1;
        private String _changeDanui2;
        private String _rowState;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String OrdDanui
        {
            get { return this._ordDanui; }
            set { this._ordDanui = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public String ChangeQty1
        {
            get { return this._changeQty1; }
            set { this._changeQty1 = value; }
        }

        public String ChangeQty2
        {
            get { return this._changeQty2; }
            set { this._changeQty2 = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String HangmogStartDate
        {
            get { return this._hangmogStartDate; }
            set { this._hangmogStartDate = value; }
        }

        public String ChangeDanui1
        {
            get { return this._changeDanui1; }
            set { this._changeDanui1 = value; }
        }

        public String ChangeDanui2
        {
            get { return this._changeDanui2; }
            set { this._changeDanui2 = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public DRGOCSCHKgrdOCS0108Info() { }

        public DRGOCSCHKgrdOCS0108Info(String hangmogCode, String ordDanui, String seq, String changeQty1, String changeQty2, String hospCode, String hangmogStartDate, String changeDanui1, String changeDanui2, String rowState)
        {
            this._hangmogCode = hangmogCode;
            this._ordDanui = ordDanui;
            this._seq = seq;
            this._changeQty1 = changeQty1;
            this._changeQty2 = changeQty2;
            this._hospCode = hospCode;
            this._hangmogStartDate = hangmogStartDate;
            this._changeDanui1 = changeDanui1;
            this._changeDanui2 = changeDanui2;
            this._rowState = rowState;
        }

    }
}