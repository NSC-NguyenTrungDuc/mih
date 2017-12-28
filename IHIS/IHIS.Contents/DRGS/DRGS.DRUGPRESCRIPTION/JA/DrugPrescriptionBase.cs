using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.DRGS
{
    public class DrugPrescriptionBase
    {
        private string _budamjaBunho11 = "";
        private string _budamjaBunho12 = "";
        private string _budamjaBunho13 = "";
        private string _budamjaBunho14 = "";
        private string _budamjaBunho15 = "";
        private string _budamjaBunho16 = "";
        private string _budamjaBunho17 = "";
        private string _budamjaBunho18 = "";
        private string _johap1 = "";
        private string _johap2 = "";
        private string _johap3 = "";
        private string _johap4 = "";
        private string _johap5 = "";
        private string _johap6 = "";
        private string _johap7 = "";
        private string _johap8 = "";
        private string _sugubjaBunho11 = "";
        private string _sugubjaBunho12 = "";
        private string _sugubjaBunho13 = "";
        private string _sugubjaBunho14 = "";
        private string _sugubjaBunho15 = "";
        private string _sugubjaBunho16 = "";
        private string _sugubjaBunho17 = "";
        private string _gaein = "";
        private string _gaeinNo = "";
        private string _nameKana = "";
        private string _nameKanji = "";
        private string _jeadanName = "";
        private string _yoyangName = "";
        private string _address = "";
        private string _address1 = "";
        private string _doctorName = "";
        private string _tel = "";
        private string _birth = "";
        private string _sex = "";
        private string _boninGubunOval = "";
        private List<DrugPrescriptionDetail> _presDetail;
        private string _budamjaBunho21 = "";
        private string _budamjaBunho22 = "";
        private string _budamjaBunho23 = "";
        private string _budamjaBunho24 = "";
        private string _budamjaBunho25 = "";
        private string _budamjaBunho26 = "";
        private string _budamjaBunho27 = "";
        private string _budamjaBunho28 = "";
        private string _sugubjaBunho21 = "";
        private string _sugubjaBunho22 = "";
        private string _sugubjaBunho23 = "";
        private string _sugubjaBunho24 = "";
        private string _sugubjaBunho25 = "";
        private string _sugubjaBunho26 = "";
        private string _sugubjaBunho27 = "";

        public string BudamjaBunho11
        {
            get { return _budamjaBunho11; }
            set { _budamjaBunho11 = value; }
        }

        public string BudamjaBunho12
        {
            get { return _budamjaBunho12; }
            set { _budamjaBunho12 = value; }
        }

        public string BudamjaBunho13
        {
            get { return _budamjaBunho13; }
            set { _budamjaBunho13 = value; }
        }

        public string BudamjaBunho14
        {
            get { return _budamjaBunho14; }
            set { _budamjaBunho14 = value; }
        }

        public string BudamjaBunho15
        {
            get { return _budamjaBunho15; }
            set { _budamjaBunho15 = value; }
        }

        public string BudamjaBunho16
        {
            get { return _budamjaBunho16; }
            set { _budamjaBunho16 = value; }
        }

        public string BudamjaBunho17
        {
            get { return _budamjaBunho17; }
            set { _budamjaBunho17 = value; }
        }

        public string BudamjaBunho18
        {
            get { return _budamjaBunho18; }
            set { _budamjaBunho18 = value; }
        }

        public string SugubjaBunho11
        {
            get { return _sugubjaBunho11; }
            set { _sugubjaBunho11 = value; }
        }

        public string SugubjaBunho12
        {
            get { return _sugubjaBunho12; }
            set { _sugubjaBunho12 = value; }
        }

        public string SugubjaBunho13
        {
            get { return _sugubjaBunho13; }
            set { _sugubjaBunho13 = value; }
        }

        public string SugubjaBunho14
        {
            get { return _sugubjaBunho14; }
            set { _sugubjaBunho14 = value; }
        }

        public string SugubjaBunho15
        {
            get { return _sugubjaBunho15; }
            set { _sugubjaBunho15 = value; }
        }

        public string SugubjaBunho16
        {
            get { return _sugubjaBunho16; }
            set { _sugubjaBunho16 = value; }
        }

        public string SugubjaBunho17
        {
            get { return _sugubjaBunho17; }
            set { _sugubjaBunho17 = value; }
        }

        public string Johap1
        {
            get { return _johap1; }
            set { _johap1 = value; }
        }

        public string Johap2
        {
            get { return _johap2; }
            set { _johap2 = value; }
        }

        public string Johap3
        {
            get { return _johap3; }
            set { _johap3 = value; }
        }

        public string Johap4
        {
            get { return _johap4; }
            set { _johap4 = value; }
        }

        public string Johap5
        {
            get { return _johap5; }
            set { _johap5 = value; }
        }

        public string Johap6
        {
            get { return _johap6; }
            set { _johap6 = value; }
        }

        public string Johap7
        {
            get { return _johap7; }
            set { _johap7 = value; }
        }

        public string Johap8
        {
            get { return _johap8; }
            set { _johap8 = value; }
        }

        public string Gaein
        {
            get { return _gaein; }
            set { _gaein = value; }
        }

        public string GaeinNo
        {
            get { return _gaeinNo; }
            set { _gaeinNo = value; }
        }

        public string NameKana
        {
            get { return _nameKana; }
            set { _nameKana = value; }
        }

        public string NameKanji
        {
            get { return _nameKanji; }
            set { _nameKanji = value; }
        }

        public string Birth
        {
            get { return _birth; }
            set { _birth = value; }
        }

        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        public string JeadanName
        {
            get { return _jeadanName; }
            set { _jeadanName = value; }
        }

        public string YoyangName
        {
            get { return _yoyangName; }
            set { _yoyangName = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        public string DoctorName
        {
            get { return _doctorName; }
            set { _doctorName = value; }
        }

        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        public string BoninGubunOval
        {
            get { return _boninGubunOval; }
            set { _boninGubunOval = value; }
        }

        public List<DrugPrescriptionDetail> PresDetail
        {
            get { return _presDetail; }
            set { _presDetail = value; }
        }

        public string BudamjaBunho21
        {
            get { return _budamjaBunho21; }
            set { _budamjaBunho21 = value; }
        }

        public string BudamjaBunho22
        {
            get { return _budamjaBunho22; }
            set { _budamjaBunho22 = value; }
        }

        public string BudamjaBunho23
        {
            get { return _budamjaBunho23; }
            set { _budamjaBunho23 = value; }
        }

        public string BudamjaBunho24
        {
            get { return _budamjaBunho24; }
            set { _budamjaBunho24 = value; }
        }

        public string BudamjaBunho25
        {
            get { return _budamjaBunho25; }
            set { _budamjaBunho25 = value; }
        }

        public string BudamjaBunho26
        {
            get { return _budamjaBunho26; }
            set { _budamjaBunho26 = value; }
        }

        public string BudamjaBunho27
        {
            get { return _budamjaBunho27; }
            set { _budamjaBunho27 = value; }
        }

        public string BudamjaBunho28
        {
            get { return _budamjaBunho28; }
            set { _budamjaBunho28 = value; }
        }

        public string SugubjaBunho21
        {
            get { return _sugubjaBunho21; }
            set { _sugubjaBunho21 = value; }
        }

        public string SugubjaBunho22
        {
            get { return _sugubjaBunho22; }
            set { _sugubjaBunho22 = value; }
        }

        public string SugubjaBunho23
        {
            get { return _sugubjaBunho23; }
            set { _sugubjaBunho23 = value; }
        }

        public string SugubjaBunho24
        {
            get { return _sugubjaBunho24; }
            set { _sugubjaBunho24 = value; }
        }

        public string SugubjaBunho25
        {
            get { return _sugubjaBunho25; }
            set { _sugubjaBunho25 = value; }
        }

        public string SugubjaBunho26
        {
            get { return _sugubjaBunho26; }
            set { _sugubjaBunho26 = value; }
        }

        public string SugubjaBunho27
        {
            get { return _sugubjaBunho27; }
            set { _sugubjaBunho27 = value; }
        }
    }

    public class DrugPrescriptionDetail
    {
        private string _serialV = "";
        private string _bogyongName = "";
        private string _nalsu = "";
        private string _donbokYn = "";
        private string _dataGubun = "";
        private string _jaeryoName = "";
        private string _orderSuryang = "";
        private string _orderDanui = "";
        private string _dataBlockEnd = "N";
        private string _detailEnd = "N";
        private string _dvTime;
        private string _dv;

        public string Dv
        {
            get { return _dv; }
            set { _dv = value; }
        }

        public string DvTime
        {
            get { return _dvTime; }
            set { _dvTime = value; }
        }

        public string SerialV
        {
            get { return _serialV; }
            set { _serialV = value; }
        }

        public string BogyongName
        {
            get { return _bogyongName; }
            set { _bogyongName = value; }
        }

        public string Nalsu
        {
            get { return _nalsu; }
            set { _nalsu = value; }
        }

        public string DonbokYn
        {
            get { return _donbokYn; }
            set { _donbokYn = value; }
        }

        public string DataGubun
        {
            get { return _dataGubun; }
            set { _dataGubun = value; }
        }

        public string JaeryoName
        {
            get { return _jaeryoName; }
            set { _jaeryoName = value; }
        }

        public string OrderSuryang
        {
            get { return _orderSuryang; }
            set { _orderSuryang = value; }
        }

        public string OrderDanui
        {
            get { return _orderDanui; }
            set { _orderDanui = value; }
        }

        /// <summary>
        /// Set to "Y" to end 1 of data block. Default is "N"
        /// </summary>
        public string DataBlockEnd
        {
            get { return _dataBlockEnd; }
            set { _dataBlockEnd = value; }
        }

        /// <summary>
        /// Set to "Y" to end detail data. Default is "N"
        /// </summary>
        public string DetailEnd
        {
            get { return _detailEnd; }
            set { _detailEnd = value; }
        }

        public DrugPrescriptionDetail()
        { }
    }
}
