using System;
using System.Collections.Generic;
using System.Text;

namespace ORCA
{
    public class OrdersInfo
    {
        private HeaderInfo _headerInfo;
        private DetailInfo _detailInfo;

        public HeaderInfo HeaderInfo
        {
            get { return _headerInfo; }
            set { _headerInfo = value; }
        }

        public DetailInfo DetailInfo
        {
            get { return _detailInfo; }
            set { _detailInfo = value; }
        }

        public OrdersInfo(HeaderInfo headerInfo, DetailInfo detailInfo)
        {
            this._headerInfo = headerInfo;
            this._detailInfo = detailInfo;
        }
    }
}