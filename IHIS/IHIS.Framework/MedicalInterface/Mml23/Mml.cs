using System;
using System.Collections.Generic;

using System.Text;
using System.IO;

namespace MedicalInterface.Mml23
{
    using System.Globalization;

    using MedicalInterface.Mml23.MmlCi;
    using MedicalInterface.Mml23.MmlHi;
    using MedicalInterface.Mml23.Claim;
    using System.Windows.Forms;
    using IHIS.Framework.Mml23.MmlRe;

    public class Mml
    {
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        public MmlHeader Header
        {
            get { return _header; }
            set { _header = value; }
        }

        public MmlBody Body
        {
            get { return _body; }
            set { _body = value; }
        }


        private MmlTableManager _TableManager;
        private string _version;
        private DateTime _createDate;
        private MmlHeader _header;
        private MmlBody _body;

        public MmlTableManager TableManager
        {
            get { return _TableManager; }
        }

        public Mml()
        {
            this.Version = "2.3";
            this.CreateDate = DateTime.Now;
            LoadTableManager();
        }

        public void SetSupplementData()
        {
            //TOCタグのセット
            AddTableOfContents();

            //MMLテーブルを使用してのデータ設定
        }

        private void LoadTableManager()
        {
            _TableManager = null;
            //string tblfile = Environment.CurrentDirectory + "\\Mml23\\Table\\MML23Table.config";
            string tblfile = Application.StartupPath + "\\Mml23\\Table\\MML23Table.config";
            object obj = null;
            using (System.IO.StreamReader stream = new StreamReader(tblfile))
            {
                TextReader reader = stream;
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(MmlTableManager));
                obj = serializer.Deserialize(reader);
                _TableManager = (MmlTableManager)obj;
            }
        }

        private void AddTableOfContents()
        {
            //必ず出現するもの
            this.Header.AddToc(MmlCm.Id.NameSpaceURI);
            this.Header.AddToc(MmlCi.CreatorInfo.NameSpaceURI);
            this.Header.AddToc(MmlDp.Department.NameSpaceURI);
            this.Header.AddToc(MmlFc.Facility.NameSpaceURI);
            this.Header.AddToc(MmlNm.Name.NameSpaceURI);
            this.Header.AddToc(MmlPsi.PersonalizedInfo.NameSpaceURI);
            this.Header.AddToc(Claim.ClaimModule.NameSpaceURI);
            this.Header.AddToc(MmlHi.HealthInsurance.NameSpaceURI);

            //Address
            if (this.Header.Creator.Parson.AddressList.Count > 0)
            {
                this.Header.AddToc(MmlAd.Address.NameSpaceURI);
            }

            //Phone
            if (this.Header.Creator.Parson.PhoneList.Count > 0)
            {
                this.Header.AddToc(MmlPh.Phone.NameSpaceURI);
            }

            //TODO:各モジュールのTOCを取得してヘッダのtocにセット
        }

        public MmlModuleItem CreateRegisteredDiagnosisModule(string dateTime)
        {
            MmlModuleItem mdl = new MmlModuleItem();

            const string culture = "ja-JP";
            //const string format = "yyyy/MM/dd";
            CultureInfo info = new CultureInfo(culture);

            /*mdl.DocInfo.ConfirmDate = DateTime.ParseExact(dateTime, format, info);*/
            //ConfirmDate only follow Date not follow time.
            mdl.DocInfo.ConfirmDate = !string.IsNullOrEmpty(dateTime) ? DateTime.Parse(dateTime) : DateTime.Now;
            mdl.DocInfo.ContentModuleType = "registeredDiagnosis";
            mdl.DocInfo.Title = "Regist";
            mdl.DocInfo.DocId = DateTime.Now.Ticks.ToString();

            mdl.DocInfo.Creator = this.Header.Creator.Clone();

            MmlAccessRight acc = new MmlAccessRight();
            acc.Permit = "all";
            mdl.DocInfo.AccessRightList.Add(acc);

            mdl.Content = new MmlRd.RegisteredDiagnosisModule();

            return mdl;
        }

        public MmlModuleItem CreateRegisteredDiagnosisModule(string dateTime, string outSangId)
        {
            MmlModuleItem mdl = new MmlModuleItem();

            const string culture = "ja-JP";
            //const string format = "yyyy/MM/dd";
            CultureInfo info = new CultureInfo(culture);

            /*mdl.DocInfo.ConfirmDate = DateTime.ParseExact(dateTime, format, info);*/
            //ConfirmDate only follow Date not follow time.
            mdl.DocInfo.ConfirmDate = !string.IsNullOrEmpty(dateTime) ? DateTime.Parse(dateTime) : DateTime.Now;
            mdl.DocInfo.ContentModuleType = "registeredDiagnosis";
            mdl.DocInfo.Title = "Regist";
            mdl.DocInfo.DocId = !string.IsNullOrEmpty(outSangId) ? outSangId : DateTime.Now.Ticks.ToString();

            mdl.DocInfo.Creator = this.Header.Creator.Clone();

            MmlAccessRight acc = new MmlAccessRight();
            acc.Permit = "all";
            mdl.DocInfo.AccessRightList.Add(acc);

            mdl.Content = new MmlRd.RegisteredDiagnosisModule();

            return mdl;
        }

        /// <summary>
        /// https://sofiamedix.atlassian.net/browse/MED-11420
        /// </summary>
        /// <returns></returns>
        public MmlModuleItem CreateRegisteredDiagnosisModule()
        {
            MmlModuleItem mdl = new MmlModuleItem();

            mdl.DocInfo.ContentModuleType = "registeredDiagnosis";
            //mdl.DocInfo.ConfirmDate = DateTime.Now;
            //mdl.DocInfo.Title = "Regist";
            //mdl.DocInfo.DocId = DateTime.Now.Ticks.ToString();

            //mdl.DocInfo.Creator = this.Header.Creator.Clone();

            //MmlAccessRight acc = new MmlAccessRight();
            //acc.Permit = "all";
            //mdl.DocInfo.AccessRightList.Add(acc);

            mdl.Content = new MmlRd.RegisteredDiagnosisModule();

            return mdl;
        }

        public MmlModuleItem CreateProgressCourseModule()
        {
            MmlModuleItem mdl = new MmlModuleItem();

            mdl.DocInfo.ContentModuleType = "progressCourse";
            mdl.DocInfo.ConfirmDate = DateTime.Now;
            mdl.DocInfo.Title = "Regist";
            mdl.DocInfo.DocId = DateTime.Now.Ticks.ToString();

            mdl.DocInfo.Creator = this.Header.Creator.Clone();

            MmlAccessRight acc = new MmlAccessRight();
            acc.Permit = "all";
            mdl.DocInfo.AccessRightList.Add(acc);

            mdl.Content = new MmlPc.ProgressCourseModule();

            return mdl;
        }

        public MmlModuleItem CreateProgressCourseModule(string id, string hospCode, string facility, string doctor, string dateTime)
        {
            MmlModuleItem mdl = new MmlModuleItem();

            const string culture = "ja-JP";
            //const string format = "yyyy/MM/dd";
            CultureInfo info = new CultureInfo(culture);

            mdl.DocInfo.ContentModuleType = "progressCourse";

            //MED-11691
            /*mdl.DocInfo.ConfirmDate = DateTime.ParseExact(dateTime, format, info);*/
            //ConfirmDate only follow Date not follow time.
            mdl.DocInfo.ConfirmDate = !string.IsNullOrEmpty(dateTime) ? DateTime.Parse(dateTime) : DateTime.Now;
            mdl.DocInfo.Title = "Progress Course";
            mdl.DocInfo.DocId = id;

            mdl.DocInfo.Creator = new CreatorInfo();
            mdl.DocInfo.Creator.Parson.Facility.Id.Text = hospCode;
            mdl.DocInfo.Creator.Parson.Facility.Name = facility;
            mdl.DocInfo.Creator.Parson.ParsonId.Text = doctor;

            MmlAccessRight acc = new MmlAccessRight();
            acc.Permit = "all";
            mdl.DocInfo.AccessRightList.Add(acc);

            mdl.Content = new MmlPc.ProgressCourseModule();

            return mdl;
        }

        public MmlModuleItem CreateProgressCourseModule(string id, string hospCode, string facility, string doctor, string dateTime, string templateId)
        {
            MmlModuleItem mdl = new MmlModuleItem();

            const string culture = "ja-JP";
            //const string format = "yyyy/MM/dd";
            CultureInfo info = new CultureInfo(culture);

            mdl.DocInfo.ContentModuleType = "progressCourse";
            mdl.DocInfo.TemplateId = templateId;

            //MED-11691
            /*mdl.DocInfo.ConfirmDate = DateTime.ParseExact(dateTime, format, info);*/
            //ConfirmDate only follow Date not follow time.
            mdl.DocInfo.ConfirmDate = !string.IsNullOrEmpty(dateTime) ? DateTime.Parse(dateTime) : DateTime.Now;
            mdl.DocInfo.Title = "Progress Course";
            mdl.DocInfo.DocId = id;

            mdl.DocInfo.Creator = new CreatorInfo();
            mdl.DocInfo.Creator.Parson.Facility.Id.Text = hospCode;
            mdl.DocInfo.Creator.Parson.Facility.Name = facility;
            mdl.DocInfo.Creator.Parson.ParsonId.Text = doctor;

            MmlAccessRight acc = new MmlAccessRight();
            acc.Permit = "all";
            mdl.DocInfo.AccessRightList.Add(acc);

            mdl.Content = new MmlPc.ProgressCourseModule();

            return mdl;
        }

        public MmlModuleItem CreatePatientModule(string hospCode, string facility, string doctor)
        {
            MmlModuleItem mdl = new MmlModuleItem();

            mdl.DocInfo.ContentModuleType = "patientInfo";
            mdl.DocInfo.ConfirmDate = DateTime.Now;
            mdl.DocInfo.Title = "Patient";
            mdl.DocInfo.DocId = DateTime.Now.Ticks.ToString();

            mdl.DocInfo.Creator = new CreatorInfo();
            mdl.DocInfo.Creator.Parson.Facility.Id.Text = hospCode;
            mdl.DocInfo.Creator.Parson.Facility.Name = facility;
            mdl.DocInfo.Creator.Parson.ParsonId.Text = doctor;

            MmlAccessRight acc = new MmlAccessRight();
            acc.Permit = "all";
            mdl.DocInfo.AccessRightList.Add(acc);

            mdl.Content = new MmlPi.PatientModule();

            return mdl;
        }

        public MmlModuleItem CreateHealthInsuranceModule(string docId)
        {
            MmlModuleItem mdl = new MmlModuleItem();

            mdl.DocInfo.ContentModuleType = "healthInsurance";
            //mdl.DocInfo.ConfirmDate = DateTime.Now;
            //mdl.DocInfo.Title = "Patient";
            //mdl.DocInfo.DocId = DateTime.Now.Ticks.ToString();
            mdl.DocInfo.DocId = docId;
            //mdl.DocInfo.DocId = System.Guid.NewGuid().ToString();
            //mdl.DocInfo.Creator = new CreatorInfo();
            //mdl.DocInfo.Creator.Parson.Facility.Id.Text = "01";

            //MmlAccessRight acc = new MmlAccessRight();
            //acc.Permit = "all";
            //mdl.DocInfo.AccessRightList.Add(acc);

            mdl.Content = new HealthInsurance();

            return mdl;
        }

        public MmlModuleItem CreateClaimModule(string doctorId)
        {
            MmlModuleItem mdl = new MmlModuleItem();

            mdl.DocInfo.ContentModuleType = "claim";
            //mdl.DocInfo.ConfirmDate = DateTime.Now;
            //mdl.DocInfo.Title = "Data of Regist";
            //mdl.DocInfo.DocId = DateTime.Now.Ticks.ToString();
            //mdl.DocInfo.DocId = System.Guid.NewGuid().ToString();
            mdl.DocInfo.Creator = this.Header.Creator.Clone();
            mdl.DocInfo.Creator.Parson.ParsonId.Text = doctorId;

            MmlAccessRight acc = new MmlAccessRight();
            acc.Permit = "all";
            mdl.DocInfo.AccessRightList.Add(acc);

            mdl.Content = new ClaimModule();

            return mdl;
        }

        public MmlModuleItem CreateReferralModule()
        {
            MmlModuleItem mdl = new MmlModuleItem();

            mdl.DocInfo.ContentModuleType = "referral";
            mdl.DocInfo.ConfirmDate = DateTime.Now;
            mdl.DocInfo.Title = "Data of Regist";
            mdl.DocInfo.DocId = DateTime.Now.Ticks.ToString();
            mdl.DocInfo.DocId = System.Guid.NewGuid().ToString();
            mdl.DocInfo.Creator = this.Header.Creator.Clone();
            //mdl.DocInfo.Creator.Parson.ParsonId.Text = doctorId;

            MmlAccessRight acc = new MmlAccessRight();
            acc.Permit = "all";
            mdl.DocInfo.AccessRightList.Add(acc);

            mdl.Content = new ReferralModule();

            return mdl;
        }
    }
}
