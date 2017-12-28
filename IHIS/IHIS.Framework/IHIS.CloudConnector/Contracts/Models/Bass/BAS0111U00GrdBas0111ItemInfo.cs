using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class BAS0111U00GrdBas0111ItemInfo
    {
        private String _johapGubun;
        private String _johap;
        private String _gaein;
        private String _useYn;
        private String _zipCode1;
        private String _zipCode2;
        private String _address;
        private String _address1;
        private String _name;
        private String _contKey;
        private String _rowState;

        public String JohapGubun
        {
            get { return this._johapGubun; }
            set { this._johapGubun = value; }
        }

        public String Johap
        {
            get { return this._johap; }
            set { this._johap = value; }
        }

        public String Gaein
        {
            get { return this._gaein; }
            set { this._gaein = value; }
        }

        public String UseYn
        {
            get { return this._useYn; }
            set { this._useYn = value; }
        }

        public String ZipCode1
        {
            get { return this._zipCode1; }
            set { this._zipCode1 = value; }
        }

        public String ZipCode2
        {
            get { return this._zipCode2; }
            set { this._zipCode2 = value; }
        }

        public String Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public String Address1
        {
            get { return this._address1; }
            set { this._address1 = value; }
        }

        public String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public String ContKey
        {
            get { return this._contKey; }
            set { this._contKey = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public BAS0111U00GrdBas0111ItemInfo() { }

        public BAS0111U00GrdBas0111ItemInfo(String johapGubun, String johap, String gaein, String useYn, String zipCode1, String zipCode2, String address, String address1, String name, String contKey, String rowState)
        {
            this._johapGubun = johapGubun;
            this._johap = johap;
            this._gaein = gaein;
            this._useYn = useYn;
            this._zipCode1 = zipCode1;
            this._zipCode2 = zipCode2;
            this._address = address;
            this._address1 = address1;
            this._name = name;
            this._contKey = contKey;
            this._rowState = rowState;
        }

    }
}