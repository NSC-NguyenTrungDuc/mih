using System;
using System.Collections.Generic;

namespace EmrDocker.Models
{
    public class EmrRecordInfo
    {
        private String _hospCode;
        private String _facility;
        private String _dateTime;
        private String _doctor;
        private String _pkOut;
        private String _templateId;
        private List<TagInfo> _tagInfos;
        private List<OrderInfo> _orderInfos;


        public String HospCode
        {
            get { return _hospCode; }
            set { _hospCode = value; }
        }

        public String Facility
        {
            get { return _facility; }
            set { _facility = value; }
        }

        public String DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        public String Doctor
        {
            get { return _doctor; }
            set { _doctor = value; }
        }

        public String PkOut
        {
            get { return _pkOut; }
            set { _pkOut = value; }
        }

        public string TemplateId
        {
            get { return _templateId; }
            set { _templateId = value; }
        }

        public List<TagInfo> TagInfos
        {
            get { return _tagInfos; }
        }

        public List<OrderInfo> OrderInfos
        {
            get { return _orderInfos; }
            set { _orderInfos = value; }
        }

        public EmrRecordInfo()
        {
            this._orderInfos = new List<OrderInfo>();
            this._tagInfos = new List<TagInfo>();
        }

        public EmrRecordInfo(String hospCode, String facility, String dateTime, String doctor, String pkOut, String templateId, List<TagInfo> tagInfos, List<OrderInfo> orderInfos)
        {
            _hospCode = hospCode;
            _facility = facility;
            _dateTime = dateTime;
            _doctor = doctor;
            _pkOut = pkOut;
            _templateId = templateId;
            _tagInfos = tagInfos ?? new List<TagInfo>();
            _orderInfos = orderInfos ?? new List<OrderInfo>();
        }
    }
}