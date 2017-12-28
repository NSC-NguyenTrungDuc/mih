using System;
using System.Collections.Generic;
using EmrDocker.Glossary;

namespace EmrDocker
{
    public class EmrModel
    {
        private string _hospCode;
        public string HospCode
        {
            get { return _hospCode; }
            set { _hospCode = value; }
        }

        private string _facitity;
        public string Facitity
        {
            get { return _facitity; }
            set { _facitity = value; }
        }

        private string _dateTime;
        public string DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        private string _doctor;
        public string Doctor
        {
            get { return _doctor; }
            set { _doctor = value; }
        }

        private string _pkOut;
        public string PkOut
        {
            get { return _pkOut; }
            set { _pkOut = value; }
        }

        private List<Tag> _lstTag;
        public List<Tag> Tag
        {
            get { return _lstTag; }
            set { _lstTag = value; }
        }

        private List<Order> _order;
        public List<Order> Order
        {
            get { return _order; }
            set { _order = value; }
        }
    }

    public class Tag
    {
        private int _currentEmrRecord;
        public int CurrentEmrRecord
        {
            get { return _currentEmrRecord; }
            set { _currentEmrRecord = value; }
        }

        private string _tagCode;
        public string TagCode
        {
            get { return _tagCode; }
            set { _tagCode = value; }
        }

        private string _tagName;
        public string TagName
        {
            get { return _tagName; }
            set { _tagName = value; }
        }


        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private Enum _type;
        public Enum Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _order;
        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public Tag(int currentEmrRecord, string tagCode, string tagName, string content, Enum type, int order)
        {
            _currentEmrRecord = currentEmrRecord;
            _tagCode = tagCode;
            _tagName = tagName;
            _content = content;
            _type = type;
            _order = order;
        }
    }

    public class Order
    {
        private string _orderCurrent;
        public string OrderCurrent
        {
            get { return _orderCurrent; }
            set { _orderCurrent = value; }
        }

        private string _parrentTagCurrent;
        public string ParrentTagCurrent
        {
            get { return _parrentTagCurrent; }
            set { _parrentTagCurrent = value; }
        }

        private string _orderType;
        public string OrderType
        {
            get { return _orderType; }
            set { _orderType = value; }
        }

        private string _orderId;
        public string OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public Order(string orderCurrent, string parrentTagCurrent, string orderType, string orderId, string content)
        {
            _orderCurrent = orderCurrent;
            _parrentTagCurrent = parrentTagCurrent;
            _orderType = orderType;
            _orderId = orderId;
            _content = content;
        }
    }

    public class EmrMasterModel
    {
        private int _currentEmrRecord;
        public int CurrentEmrRecord
        {
            get { return _currentEmrRecord; }
            set { _currentEmrRecord = value; }
        }

        private string _tagCode;
        public string TagCode
        {
            get { return _tagCode; }
            set { _tagCode = value; }
        }

        private string _tagName;
        public string TagName
        {
            get { return _tagName; }
            set { _tagName = value; }
        }


        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private TypeEnum _type;
        public TypeEnum Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _orders;
        public int Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        private List<Order> _orderDetail;
        public List<Order> OrderDetail
        {
            get { return _orderDetail; }
            set { _orderDetail = value; }
        }

        public EmrMasterModel(int currentEmrRecord, string tagCode, string tagName, string content, TypeEnum type, int order, List<Order> lsOrders)
        {
            _currentEmrRecord = currentEmrRecord;
            _tagCode = tagCode;
            _tagName = tagName;
            _content = content;
            _type = type;
            _orders = order;
            _orderDetail = lsOrders;
        }
    }
}
