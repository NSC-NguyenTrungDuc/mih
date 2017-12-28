using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
    public class SchsSCH0201U99DateScheduleItemInfo
    {
        private String _dayofmon;
        private String _checkYn;
        private String _inwon;
        private String _outwon;

        public String Dayofmon
        {
            get { return this._dayofmon; }
            set { this._dayofmon = value; }
        }

        public String CheckYn
        {
            get { return this._checkYn; }
            set { this._checkYn = value; }
        }

        public String Inwon
        {
            get { return this._inwon; }
            set { this._inwon = value; }
        }

        public String Outwon
        {
            get { return this._outwon; }
            set { this._outwon = value; }
        }

        public SchsSCH0201U99DateScheduleItemInfo() { }

        public SchsSCH0201U99DateScheduleItemInfo(String dayofmon, String checkYn, String inwon, String outwon)
        {
            this._dayofmon = dayofmon;
            this._checkYn = checkYn;
            this._inwon = inwon;
            this._outwon = outwon;
        }

    }
}