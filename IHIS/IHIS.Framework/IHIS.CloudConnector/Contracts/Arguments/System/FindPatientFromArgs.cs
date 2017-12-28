using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    public class FindPatientFromArgs : IContractArgs
    {
        private String _patientName2;
        private String _sex;
        private String _brith;
        private String _tel;
        private String _type;
        private String _pageNumber;
        private String _offset;

        public String PatientName2
        {
            get { return this._patientName2; }
            set { this._patientName2 = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String Brith
        {
            get { return this._brith; }
            set { this._brith = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public String Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public String PageNumber
        {
            get { return this._pageNumber; }
            set { this._pageNumber = value; }
        }

        public String Offset
        {
            get { return this._offset; }
            set { this._offset = value; }
        }

        public FindPatientFromArgs() { }

        public FindPatientFromArgs(String patientName2, String sex, String brith, String tel, String type, String pageNumber, String offset)
        {
            this._patientName2 = patientName2;
            this._sex = sex;
            this._brith = brith;
            this._tel = tel;
            this._type = type;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.FindPatientFromRequest();
        }
    }
}