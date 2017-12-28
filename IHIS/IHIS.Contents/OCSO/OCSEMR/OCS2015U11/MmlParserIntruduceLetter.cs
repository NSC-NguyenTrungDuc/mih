using EmrDocker.Glossary;
using IHIS.Framework;
using IHIS.Framework.Mml23.MmlRe;
using IHIS.Framework.Mml23.MmlSm;
using MedicalInterface.Mml23.MmlDp;
using MedicalInterface.Mml23.MmlFc;
using MedicalInterface.Mml23.MmlNm;
using MedicalInterface.Mml23.MmlPsi;

namespace MedicalInterfaceTest
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml;

    using EmrDocker.Models;
    using EmrDocker.Types;
    using EmrDocker.Glossary;

    using MedicalInterface;
    using MedicalInterface.Mml23;
    using MedicalInterface.Mml23.MmlAd;
    using MedicalInterface.Mml23.MmlCm;
    using MedicalInterface.Mml23.MmlPc;
    using MedicalInterface.Mml23.MmlPh;
    using MedicalInterface.Mml23.MmlPi;

    public class MmlParserIntruduceLetter
    {
        private readonly Dictionary<string, MmlStorage> TagStorage = new Dictionary<string, MmlStorage>();
        private static readonly MmlParserIntruduceLetter _instance = new MmlParserIntruduceLetter();

        private const string IMAGE_TOKEN = "$IMG$";
        private const string PDF_TOKEN = "$PDF$";
        private const string IMG_TAG_SEPA = "#";
        private const string PDF_TAG_SEPA = "#";

        public static MmlParserIntruduceLetter Instance
        {
            get
            {
                return _instance;
            }
        }

        private MmlParserIntruduceLetter()
        {
            TagStorage.Add("L1", MmlStorage.REFERFROM);
            TagStorage.Add("L2", MmlStorage.REFERFROM);
            TagStorage.Add("L3", MmlStorage.REFERFROM);
            TagStorage.Add("L4", MmlStorage.REFERFROM);
            TagStorage.Add("L5", MmlStorage.REFERFROM);
            TagStorage.Add("L6", MmlStorage.OCCUPATION);
            TagStorage.Add("L7", MmlStorage.PATIENMODULE);
            TagStorage.Add("L8", MmlStorage.PATIENMODULE);
            TagStorage.Add("L9", MmlStorage.PATIENMODULE);
            TagStorage.Add("L10", MmlStorage.PATIENMODULE);
            TagStorage.Add("L11", MmlStorage.PATIENMODULE);
            TagStorage.Add("L12", MmlStorage.PATIENMODULE);
            TagStorage.Add("L13", MmlStorage.TITLE);
            TagStorage.Add("L14", MmlStorage.PRESENTILLNESS);
            TagStorage.Add("L15", MmlStorage.REFERPURPOSE);
            TagStorage.Add("L16", MmlStorage.PASTHISTORY);
            TagStorage.Add("L17", MmlStorage.FAMILYHISTORY);
            TagStorage.Add("L18", MmlStorage.TESTRESULT);
            TagStorage.Add("L19", MmlStorage.CLINICALCOURSE);
            TagStorage.Add("L20", MmlStorage.MEDICATION);
            TagStorage.Add("L21", MmlStorage.REMARKS);
            TagStorage.Add("L22", MmlStorage.REMARKS_REF);
            TagStorage.Add("L23", MmlStorage.REFERTOFACILITY);
        }

        public Triple<List<EmrRecordInfo>, PatientModelInfo, HospitalModelInfo> ToModel(string mml)
        {
            List<EmrRecordInfo> records = new List<EmrRecordInfo>();
            InterfaceFacade facade = new InterfaceFacade();
            PatientModelInfo patient = null;
            HospitalModelInfo hospitalModelInfo = null;
            Mml doc = facade.ReadMml23(mml, false);

            if (doc != null && doc.Body != null && doc.Body.Modules.Count > 0)
            {
                foreach (MmlModuleItem mi in doc.Body.Modules)
                {
                    ReferralModule module = mi.Content as ReferralModule;
                    if (module != null)
                    {
                        EmrRecordInfo emrRecord = new EmrRecordInfo();
                        emrRecord.PkOut = mi.DocInfo.DocId;
                        if (mi.DocInfo.Creator != null && mi.DocInfo.Creator.Parson != null)
                        {
                            emrRecord.HospCode = mi.DocInfo.Creator.Parson.Facility == null ? string.Empty : mi.DocInfo.Creator.Parson.Facility.Id.Text;
                            emrRecord.Facility = mi.DocInfo.Creator.Parson.Facility == null ? string.Empty : mi.DocInfo.Creator.Parson.Facility.Name;
                            emrRecord.Doctor = mi.DocInfo.Creator.Parson.ParsonId.Text;
                        }
                        emrRecord.DateTime = mi.DocInfo.ConfirmDate.ToString("yyyy/MM/dd");

                        //each ProblemItem contains information of only one tag
                        TagInfo tag = null;
                        string tagId = string.Empty;

                        /*if (!string.IsNullOrEmpty(pi.Problem.DxUid))
                        {
                            tagId = pi.Problem.DxUid;
                        }*/

                        if (!TypeCheck.IsNull(module.Patient))
                        {
                            patient = new PatientModelInfo();
                            patient.PatientId = (module.Patient.MasterId != null) ? module.Patient.MasterId.Text : "";
                            patient.PatientName = (module.Patient.KanaName != null) ? module.Patient.KanaName.FullName : "";
                            if (module.Patient.AddressList != null)
                            {
                                foreach (Address address in module.Patient.AddressList)
                                {
                                    patient.PatientAddress = address.FullName;
                                }
                            }

                            patient.PatientBirthday = (module.Patient.Birthday != null) ? module.Patient.Birthday.ToString("yyyy/MM/dd") : DateTime.MinValue.ToString("yyyy/MM/dd");
                            patient.PatientGender = module.Patient.Sex;
                            if (module.Patient.PhoneList != null)
                            {
                                foreach (Phone phone in module.Patient.PhoneList)
                                {
                                    patient.PatientTelephone = phone.Number;
                                }
                            }
                            if (module.Patient.MailAddressList != null)
                            {
                                foreach (MailAddress mailAddress in module.Patient.MailAddressList)
                                {
                                    patient.PatientEmail = mailAddress.Text;
                                }
                            }

                            //insert PatientInfo tags
                            tag = new TagInfo();
                            tag.TagCode = "L7";
                            tag.Type = TypeEnum.Tag;
                            tag.Content = patient.PatientName;
                            tag.Id = tagId;
                            emrRecord.TagInfos.Add(tag);

                            tag = new TagInfo();
                            tag.TagCode = "L8";
                            tag.Type = TypeEnum.Tag;
                            tag.Content = patient.PatientAddress;
                            tag.Id = tagId;
                            emrRecord.TagInfos.Add(tag);

                            tag = new TagInfo();
                            tag.TagCode = "L9";
                            tag.Type = TypeEnum.Tag;
                            tag.Content = patient.PatientBirthday;
                            tag.Id = tagId;
                            emrRecord.TagInfos.Add(tag);

                            tag = new TagInfo();
                            tag.TagCode = "L10";
                            tag.Type = TypeEnum.Tag;
                            tag.Content = patient.PatientGender;
                            tag.Id = tagId;
                            emrRecord.TagInfos.Add(tag);

                            tag = new TagInfo();
                            tag.TagCode = "L11";
                            tag.Type = TypeEnum.Tag;
                            tag.Content = patient.PatientTelephone;
                            tag.Id = tagId;
                            emrRecord.TagInfos.Add(tag);

                            tag = new TagInfo();
                            tag.TagCode = "L12";
                            tag.Type = TypeEnum.Tag;
                            tag.Content = patient.PatientEmail;
                            tag.Id = tagId;
                            emrRecord.TagInfos.Add(tag);
                        }

                        if (!TypeCheck.IsNull(module.Occupation))
                        {
                            tag = ParseTag(module.Occupation);
                            if (tag != null)
                            {
                                tag.Id = tagId;
                                emrRecord.TagInfos.Add(tag);
                            }
                        }

                        if (!TypeCheck.IsNull(module.ReferFrom) && !TypeCheck.IsNull(module.ReferFrom.Parson))
                        {
                            String hospName = (module.ReferFrom.Parson.Facility != null) ? module.ReferFrom.Parson.Facility.Name : "";
                            tag = ParseTag(hospName);
                            if (tag != null)
                            {
                                tag.Id = tagId;
                                emrRecord.TagInfos.Add(tag);
                            }

                            if (module.ReferFrom.Parson.AddressList != null)
                            {
                                foreach (Address address in module.ReferFrom.Parson.AddressList)
                                {
                                    String hospAddress = address.FullName;
                                    tag = ParseTag(hospAddress);
                                    if (tag != null)
                                    {
                                        tag.Id = tagId;
                                        emrRecord.TagInfos.Add(tag);
                                    }
                                }
                            }

                            if (module.ReferFrom.Parson.PhoneList != null)
                            {
                                foreach (Phone phone in module.ReferFrom.Parson.PhoneList)
                                {
                                    String hospTelFax = phone.Number;
                                    tag = ParseTag(hospTelFax);
                                    if (tag != null)
                                    {
                                        tag.Id = tagId;
                                        emrRecord.TagInfos.Add(tag);
                                    }
                                }
                            }
                            String doctorRequest = (module.ReferFrom.Parson.ParsonName != null) ?
                                module.ReferFrom.Parson.ParsonName.FamilyName + " " + module.ReferFrom.Parson.ParsonName.GivenName +
                                " " + module.ReferFrom.Parson.ParsonName.MiddleName : "";
                            String finalDoctorName = doctorRequest.TrimEnd(' ');
                            tag = ParseTag(finalDoctorName);
                            if (tag != null)
                            {
                                tag.Id = tagId;
                                emrRecord.TagInfos.Add(tag);
                            }
                        }

                        if (!TypeCheck.IsNull(module.Title))
                        {
                            tag = ParseTag(module.Title);
                            if (tag != null)
                            {
                                tag.Id = tagId;
                                emrRecord.TagInfos.Add(tag);
                            }
                        }

                        if (!TypeCheck.IsNull(module.ClinicalDiagnosis))
                        {
                            tag = ParseTag(module.ClinicalDiagnosis);
                            if (tag != null)
                            {
                                tag.Id = tagId;
                                emrRecord.TagInfos.Add(tag);
                            }
                        }

                        if (!TypeCheck.IsNull(module.PastHistory))
                        {
                            tag = ParseTag(module.PastHistory.Text);
                            if (tag != null)
                            {
                                tag.Id = tagId;
                                emrRecord.TagInfos.Add(tag);
                            }
                        }

                        if (!TypeCheck.IsNull(module.FamilyHistory))
                        {
                            tag = ParseTag(module.FamilyHistory.Text);
                            if (tag != null)
                            {
                                tag.Id = tagId;
                                emrRecord.TagInfos.Add(tag);
                            }
                        }

                        if (!TypeCheck.IsNull(module.PresentIllness))
                        {
                            tag = ParseTag(module.PresentIllness.Text);
                            if (tag != null)
                            {
                                tag.Id = tagId;
                                emrRecord.TagInfos.Add(tag);
                            }
                        }

                        if (!TypeCheck.IsNull(module.TestResults))
                        {
                            tag = ParseTag(module.TestResults.Text);
                            if (tag != null)
                            {
                                tag.Id = tagId;
                                emrRecord.TagInfos.Add(tag);
                            }
                        }

                        if (!TypeCheck.IsNull(module.ClinicalCourse) && !TypeCheck.IsNull(module.ClinicalCourse.ClinicalRecord))
                        {
                            foreach (ClinicalRecord clinicalRecord in module.ClinicalCourse.ClinicalRecord)
                            {
                                if (clinicalRecord != null)
                                {
                                    tag = ParseTag(clinicalRecord.Text);
                                    if (tag != null)
                                    {
                                        tag.Id = tagId;
                                        emrRecord.TagInfos.Add(tag);
                                    }
                                }
                            }
                        }

                        if (!TypeCheck.IsNull(module.ReferPurpose))
                        {
                            tag = ParseTag(module.ReferPurpose);
                            if (tag != null)
                            {
                                tag.Id = tagId;
                                emrRecord.TagInfos.Add(tag);
                            }
                        }

                        if (!TypeCheck.IsNull(module.Medication))
                        {
                            tag = ParseTag(module.Medication.Text);
                            if (tag != null)
                            {
                                tag.Id = tagId;
                                emrRecord.TagInfos.Add(tag);
                            }
                        }

                        if (!TypeCheck.IsNull(module.Remarks))
                        {
                            tag = ParseTag(module.Remarks.Text);
                            if (tag != null)
                            {
                                tag.Id = tagId;
                                emrRecord.TagInfos.Add(tag);
                            }

                            foreach (ExternalReference ext in module.Remarks.ExRef) {
                                emrRecord.TagInfos.Add(ParseTag(ext.Reference));
                            }
                        }

                        if (!TypeCheck.IsNull(module.ReferToFacility) && !TypeCheck.IsNull(module.ReferToFacility.Department))
                        {
                            tag = ParseTag(module.ReferToFacility.Department.Name);
                            if (tag != null)
                            {
                                tag.Id = tagId;
                                emrRecord.TagInfos.Add(tag);
                            }
                        }

                        records.Add(emrRecord);
                    }
                    PatientModule patientModule = mi.Content as PatientModule;
                    if (patientModule != null)
                    {
                        patient = new PatientModelInfo();
                        if (patientModule.MasterId != null) patient.PatientId = patientModule.MasterId.Text;
                        if (patientModule.Birthday != null) patient.PatientBirthday = patientModule.Birthday.ToString("yyyy/MM/dd");
                        patient.PatientGender = patientModule.Sex;
                        patient.PatientAddress = (patientModule.AddressList != null && patientModule.AddressList.Count == 0)
                                                     ? ""
                                                     : patientModule.AddressList[0].FullName;
                        patient.PatientZip = (patientModule.AddressList != null && patientModule.AddressList.Count == 0)
                                                     ? ""
                                                     : patientModule.AddressList[0].Zip;
                        patient.PatientTelephone = (patientModule.PhoneList != null && patientModule.PhoneList.Count == 0)
                                                       ? ""
                                                       : patientModule.PhoneList[0].Memo;

                    }
                }
            }

            return new Triple<List<EmrRecordInfo>, PatientModelInfo, HospitalModelInfo>(records, patient, hospitalModelInfo);
        }

        private IEnumerable<OrderInfo> ParseOrders(string orderText)
        {
            List<OrderInfo> orders = new List<OrderInfo>();
            if (!string.IsNullOrEmpty(orderText))
            {
                XmlDocument doc = new XmlDocument();
                using (XmlReader reader = XmlReader.Create(new MemoryStream(Encoding.UTF8.GetBytes(orderText))))
                {
                    doc.Load(reader);
                }
                foreach (XmlNode node in doc.FirstChild.ChildNodes)
                {
                    if (node.LocalName.Equals("Order"))
                    {
                        OrderInfo info = new OrderInfo();
                        foreach (XmlNode childNode in node.ChildNodes)
                        {
                            switch (childNode.LocalName)
                            {
                                case "Content":
                                    info.Content = childNode.InnerText;
                                    break;
                                case "ActionDoYn":
                                    info.ActionDoYn = childNode.InnerText;
                                    break;
                                case "Bunho":
                                    info.Bunho = childNode.InnerText;
                                    break;
                                case "Doctor":
                                    info.Doctor = childNode.InnerText;
                                    break;
                                case "GubunBass":
                                    info.GubunBass = childNode.InnerText;
                                    break;
                                case "Gwa":
                                    info.Gwa = childNode.InnerText;
                                    break;
                                case "HangmogCode":
                                    info.HangmogCode = childNode.InnerText;
                                    break;
                                case "InputTab":
                                    info.InputTab = childNode.InnerText;
                                    break;
                                case "NaewonDate":
                                    info.NaewonDate = childNode.InnerText;
                                    break;
                                case "NaewonKey":
                                    info.NaewonKey = childNode.InnerText;
                                    break;
                                case "HangmogName":
                                    info.HangmogName = childNode.InnerText;
                                    break;
                                case "InputGubunName":
                                    info.InputGubunName = childNode.InnerText;
                                    break;
                                case "OrderGubunName":
                                    info.OrderGubunName = childNode.InnerText;
                                    break;
                            }
                        }
                        orders.Add(info);
                    }
                }
            }
            return orders;
        }

        private TagInfo ParseTag(string content)
        {
            if (!string.IsNullOrEmpty(content))
            {
                TagInfo info = new TagInfo();
                info.Type = TypeEnum.Unknown;
                if (content.Trim().StartsWith(IMAGE_TOKEN, StringComparison.CurrentCultureIgnoreCase))
                {
                    info.TagCode = "L22";
                    info.Type = TypeEnum.Image;
                    string strContent = content.Trim().Substring(IMAGE_TOKEN.Length);
                    /*info.DirLocation = content.Trim().Substring(IMAGE_TOKEN.Length);*/

                    if (strContent.Contains(IMG_TAG_SEPA))
                    {
                        /*string[] splContent = strContent.Split(new char[] { '#' });
                        if (splContent.Length > 1)
                        {
                            info.TagCode = !string.IsNullOrEmpty(splContent[0]) ? splContent[0].Trim() : "";
                            info.DirLocation = splContent[1];
                        }*/

                        string dirLocation = "";
                        string tagCode = "";
                        GetTagCodeAndLocation(strContent, out tagCode, out dirLocation);
                        info.TagCode = tagCode;
                        info.DirLocation = dirLocation;
                    }
                    else
                    {
                        info.DirLocation = content.Trim().Substring(IMAGE_TOKEN.Length);
                    }
                }
                else if (content.Trim().StartsWith(PDF_TOKEN, StringComparison.CurrentCultureIgnoreCase))
                {
                    info.TagCode = "L22";
                    info.Type = TypeEnum.Pdf;
                    string strContent = content.Trim().Substring(PDF_TOKEN.Length);
                    /*info.DirLocation = content.Trim().Substring(PDF_TOKEN.Length);*/

                    if (strContent.Contains(PDF_TAG_SEPA))
                    {
                        /*string[] splContent = strContent.Split(new char[] { '#' });
                        if (splContent.Length > 1)
                        {
                            info.TagCode = !string.IsNullOrEmpty(splContent[0]) ? splContent[0].Trim() : "";
                            info.DirLocation = splContent[1];
                        }*/

                        string dirLocation = "";
                        string tagCode = "";
                        GetTagCodeAndLocation(strContent, out tagCode, out dirLocation);
                        info.TagCode = tagCode;
                        info.DirLocation = dirLocation;
                    }
                    else
                    {
                        info.DirLocation = content.Trim().Substring(PDF_TOKEN.Length);
                    }
                }
                else
                {
                    int index = content.Trim().IndexOf("#", 1, StringComparison.Ordinal);
                    if (index > 1)
                    {
                        info.Type = TypeEnum.Tag;
                        info.Content = content.Trim().Substring(index + 1).Trim();
                        info.TagCode = content.Trim().Substring(1, index - 1);
                    }
                }
                return info;
            }
            return null;
        }

        private void GetTagCodeAndLocation(string strContent, out string tagCode, out string dirLocation)
        {
            tagCode = "";
            dirLocation = "";

            string[] splContent = strContent.Split(new char[] { '#' });
            if (splContent.Length > 1)
            {
                tagCode = !string.IsNullOrEmpty(splContent[0]) ? splContent[0].Trim() : "";
                dirLocation = splContent[1];
            }
        }

        public string ToMmL(List<EmrRecordInfo> records, PatientModelInfo patient, string oldContent)
        {
            try
            {
                bool havePatientModule = false;
                InterfaceFacade facade = new InterfaceFacade();

                Mml mml = facade.CreateMml23(patient.PatientId);

                //get old content of ProgressCourseModule
                if (!String.IsNullOrEmpty(oldContent))
                {
                    EmrDocker.Types.Tuple<List<EmrRecordInfo>, PatientModelInfo> oldResult = MmlParser.Instance.ToModel(oldContent);
                    List<EmrRecordInfo> listProgressCourse = oldResult.V1;
                    PatientModelInfo oldPatientInfo = oldResult.V2;
                    if (listProgressCourse.Count > 0)
                    {
                        //generate old MML
                        mml = MmlParser.Instance.ToObjectMmL(listProgressCourse, oldPatientInfo);
                        havePatientModule = true;
                    }
                }

                //create new ReferralModule
                foreach (EmrRecordInfo record in records)
                {
                    MmlModuleItem pcmdlitm = mml.CreateReferralModule();
                    ReferralModule referralModule = (ReferralModule)pcmdlitm.Content;

                    referralModule.ReferFrom = new ReferFrom();
                    referralModule.ReferFrom.Parson = new PersonalizedInfo();

                    foreach (TagInfo info in record.TagInfos)
                    {
                        MmlStorage storage = info.TagCode != null && TagStorage.ContainsKey(info.TagCode)
                                                 ? TagStorage[info.TagCode]
                                                 : MmlStorage.CLINICALDIAGNOSIS;

                        switch (storage)
                        {
                            case MmlStorage.PATIENMODULE:
                                referralModule.Patient = new PatientModule();
                                PatientModule patientModule = new PatientModule();
                                patientModule.MasterId = new Id();
                                patientModule.KanjiName = new Name();
                                patientModule.AddressList = new List<Address>();
                                patientModule.PhoneList = new List<Phone>();
                                patientModule.MailAddressList = new List<MailAddress>();
                                if (patient != null)
                                {
                                    //Default Id
                                    patientModule.MasterId.Text = patient.PatientId;
                                    //Name
                                    patientModule.KanjiName.FullName = patient.PatientName;
                                    //Address
                                    Address addr = new Address();
                                    addr.FullName = patient.PatientAddress;
                                    patientModule.AddressList.Add(addr);
                                    //Birthday
                                    try
                                    {
                                        patientModule.Birthday = DateTime.Parse(patient.PatientBirthday);
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                    patientModule.Sex = patient.PatientGender;
                                    //Tel
                                    Phone tel = new Phone();
                                    tel.Number = patient.PatientTelephone;
                                    patientModule.PhoneList.Add(tel);

                                    //mailAddress
                                    MailAddress mailAddress = new MailAddress();
                                    mailAddress.Text = patient.PatientEmail;
                                    patientModule.MailAddressList.Add(mailAddress);
                                }

                                referralModule.Patient = patientModule;
                                break;
                            case MmlStorage.OCCUPATION:
                                referralModule.Occupation = ToMmlTag(info);
                                break;
                            case MmlStorage.REFERFROM:
                                //referralModule.ReferFrom = new ReferFrom();
                                //PersonalizedInfo personalizedInfo = new PersonalizedInfo();
                                //personalizedInfo.ParsonId = new Id();
                                //personalizedInfo.Facility = new Facility();
                                //personalizedInfo.AddressList = new List<Address>();
                                //personalizedInfo.PhoneList = new List<Phone>();
                                //personalizedInfo.ParsonName = new Name();
                                //if (objHospitalModelInfo != null)
                                //{
                                //    personalizedInfo.ParsonId.Text = "Default Id"; //Hash code
                                //    personalizedInfo.Facility.Name = objHospitalModelInfo.HospName;
                                //    Address addcl = new Address();
                                //    addcl.FullName = objHospitalModelInfo.HospAddress;
                                //    personalizedInfo.AddressList.Add(addcl);
                                //    Phone phone = new Phone();
                                //    phone.Number = objHospitalModelInfo.HospTel;
                                //    Phone fax = new Phone();
                                //    fax.Number = objHospitalModelInfo.HospFax;
                                //    personalizedInfo.PhoneList.Add(phone);
                                //    personalizedInfo.PhoneList.Add(fax);
                                //    personalizedInfo.ParsonName.FullName = objHospitalModelInfo.DoctorRequest;
                                //}
                                //referralModule.ReferFrom.Parson = personalizedInfo;


                                referralModule.ReferFrom.Parson.ParsonId.Text = "Default Person ID";
                                if (info.TagCode == "L1")
                                {
                                    referralModule.ReferFrom.Parson.Facility.Name = ToMmlTag(info);
                                }
                                else if (info.TagCode == "L2")
                                {
                                    Address addcl = new Address();
                                    addcl.FullName = ToMmlTag(info);
                                    referralModule.ReferFrom.Parson.AddressList.Add(addcl);
                                }
                                else if (info.TagCode == "L3")
                                {
                                    Phone fax = new Phone();
                                    fax.Number = ToMmlTag(info);
                                    referralModule.ReferFrom.Parson.PhoneList.Add(fax);
                                }
                                else if (info.TagCode == "L4")
                                {
                                    referralModule.ReferFrom.Parson.ParsonName.FullName = ToMmlTag(info);
                                }
                                else if (info.TagCode == "L5")
                                {
                                    Phone phone = new Phone();
                                    phone.Number = ToMmlTag(info);
                                    referralModule.ReferFrom.Parson.PhoneList.Add(phone);
                                }

                                break;
                            case MmlStorage.TITLE:
                                referralModule.Title = ToMmlTag(info);
                                break;
                            case MmlStorage.PASTHISTORY:
                                referralModule.PastHistory = new PastHistory();
                                referralModule.PastHistory.Text = ToMmlTag(info);
                                break;
                            case MmlStorage.FAMILYHISTORY:
                                referralModule.FamilyHistory = new FamilyHistory();
                                referralModule.FamilyHistory.Text = ToMmlTag(info);
                                break;
                            case MmlStorage.PRESENTILLNESS:
                                referralModule.PresentIllness = new PresentIllness();
                                referralModule.PresentIllness.Text = ToMmlTag(info);
                                break;
                            case MmlStorage.TESTRESULT:
                                referralModule.TestResults = new TestResults();
                                referralModule.TestResults.Text = ToMmlTag(info);
                                break;
                            case MmlStorage.CLINICALCOURSE:
                                referralModule.ClinicalCourse = new ClinicalCourse();
                                ClinicalRecord clRecortd = new ClinicalRecord();
                                clRecortd.Text = ToMmlTag(info);
                                referralModule.ClinicalCourse.ClinicalRecord.Add(clRecortd);
                                break;
                            case MmlStorage.MEDICATION:
                                referralModule.Medication = new Medication();
                                referralModule.Medication.Text = ToMmlTag(info);
                                break;
                            case MmlStorage.REFERPURPOSE:
                                referralModule.ReferPurpose = ToMmlTag(info);
                                break;
                            case MmlStorage.REMARKS:
                                if(referralModule.Remarks == null) referralModule.Remarks = new Remarks();
                                referralModule.Remarks.Text = ToMmlTag(info);
                                break;
                            case MmlStorage.REMARKS_REF:
                                if (referralModule.Remarks == null) referralModule.Remarks = new Remarks();
                                ExternalReference ext = new ExternalReference();
                                //                                ext.ContentType = info.Type
                                ext.Reference = ToMmlTag(info);
                                referralModule.Remarks.ExRef.Add(ext);
                                break;
                            case MmlStorage.REFERTOFACILITY:
                                referralModule.ReferToFacility = new ReferToFacility();
                                referralModule.ReferToFacility.Department = new Department();
                                referralModule.ReferToFacility.Department.Name = ToMmlTag(info);
                                break;
                        }
                        //referralModule.StructuredExpression.Add(item);
                    }
                    //if (record.OrderInfos != null && record.OrderInfos.Count > 0)
                    //{
                    //    ProblemItem item = new ProblemItem();
                    //    item.Plan = new Plan();
                    //    item.Plan.TxOrder = new RxTxTestItem();
                    //    item.Plan.TxOrder.Text = ToOrderText(record.OrderInfos);
                    //    //referralModule.StructuredExpression.Add(item);
                    //}

                    mml.Body.AddModuleItem(pcmdlitm);

                    if (!havePatientModule)
                    {
                        if (patient != null)
                        {
                            //patient module
                            pcmdlitm = mml.CreatePatientModule(record.HospCode, record.Facility, record.Doctor);
                            PatientModule pimd = (PatientModule)pcmdlitm.Content;
                            pimd.MasterId = new Id();
                            pimd.MasterId.Text = patient.PatientId;
                            pimd.Birthday = !string.IsNullOrEmpty(patient.PatientBirthday)
                                ? DateTime.ParseExact(patient.PatientBirthday, "yyyy/MM/dd", new CultureInfo("ja-JP"))
                                : DateTime.Now;
                            pimd.Sex = !string.IsNullOrEmpty(patient.PatientGender) ? patient.PatientGender : "";
                            Address ad = new Address();
                            ad.FullName = !string.IsNullOrEmpty(patient.PatientAddress) ? patient.PatientAddress : "";
                            ad.Zip = !string.IsNullOrEmpty(patient.PatientZip) ? patient.PatientZip : "";
                            pimd.AddressList.Add(ad);

                            Phone ph = new Phone();
                            ph.Memo = !string.IsNullOrEmpty(patient.PatientTelephone) ? patient.PatientTelephone : "";
                            pimd.PhoneList.Add(ph);

                            mml.Body.AddModuleItem(pcmdlitm);
                        }
                    }
                }

                return facade.WriteMml23(mml);
            }
            catch (Exception ex)
            {
                Service.WriteLog("Exception: on ToMml Method of MmlParserIntruduceLetter class: " + ex.StackTrace);
            }

            return null;
        }

        public Mml ToObjectMmL(List<EmrRecordInfo> records, PatientModelInfo patient)
        {
            try
            {
                InterfaceFacade facade = new InterfaceFacade();

                Mml mml = facade.CreateMml23(patient.PatientId);

                //create new ReferralModule
                foreach (EmrRecordInfo record in records)
                {
                    MmlModuleItem pcmdlitm = mml.CreateReferralModule();
                    ReferralModule referralModule = (ReferralModule)pcmdlitm.Content;

                    referralModule.ReferFrom = new ReferFrom();
                    referralModule.ReferFrom.Parson = new PersonalizedInfo();

                    foreach (TagInfo info in record.TagInfos)
                    {
                        MmlStorage storage = info.TagCode != null && TagStorage.ContainsKey(info.TagCode)
                                                 ? TagStorage[info.TagCode]
                                                 : MmlStorage.CLINICALDIAGNOSIS;

                        switch (storage)
                        {
                            case MmlStorage.PATIENMODULE:
                                referralModule.Patient = new PatientModule();
                                PatientModule patientModule = new PatientModule();
                                patientModule.MasterId = new Id();
                                patientModule.KanjiName = new Name();
                                patientModule.AddressList = new List<Address>();
                                patientModule.PhoneList = new List<Phone>();
                                patientModule.MailAddressList = new List<MailAddress>();
                                if (patient != null)
                                {
                                    //Default Id
                                    patientModule.MasterId.Text = patient.PatientId;
                                    //Name
                                    patientModule.KanjiName.FullName = patient.PatientName;
                                    //Address
                                    Address addr = new Address();
                                    addr.FullName = patient.PatientAddress;
                                    patientModule.AddressList.Add(addr);
                                    //Birthday
                                    try
                                    {
                                        patientModule.Birthday = DateTime.Parse(patient.PatientBirthday);
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                    patientModule.Sex = patient.PatientGender;
                                    //Tel
                                    Phone tel = new Phone();
                                    tel.Number = patient.PatientTelephone;
                                    patientModule.PhoneList.Add(tel);

                                    //mailAddress
                                    MailAddress mailAddress = new MailAddress();
                                    mailAddress.Text = patient.PatientEmail;
                                    patientModule.MailAddressList.Add(mailAddress);
                                }

                                referralModule.Patient = patientModule;
                                break;
                            case MmlStorage.OCCUPATION:
                                referralModule.Occupation = ToMmlTag(info);
                                break;
                            case MmlStorage.REFERFROM:
                                //referralModule.ReferFrom = new ReferFrom();
                                //PersonalizedInfo personalizedInfo = new PersonalizedInfo();
                                //personalizedInfo.ParsonId = new Id();
                                //personalizedInfo.Facility = new Facility();
                                //personalizedInfo.AddressList = new List<Address>();
                                //personalizedInfo.PhoneList = new List<Phone>();
                                //personalizedInfo.ParsonName = new Name();
                                //if (objHospitalModelInfo != null)
                                //{
                                //    personalizedInfo.ParsonId.Text = "Default Id"; //Hash code
                                //    personalizedInfo.Facility.Name = objHospitalModelInfo.HospName;
                                //    Address addcl = new Address();
                                //    addcl.FullName = objHospitalModelInfo.HospAddress;
                                //    personalizedInfo.AddressList.Add(addcl);
                                //    Phone phone = new Phone();
                                //    phone.Number = objHospitalModelInfo.HospTel;
                                //    Phone fax = new Phone();
                                //    fax.Number = objHospitalModelInfo.HospFax;
                                //    personalizedInfo.PhoneList.Add(phone);
                                //    personalizedInfo.PhoneList.Add(fax);
                                //    personalizedInfo.ParsonName.FullName = objHospitalModelInfo.DoctorRequest;
                                //}
                                //referralModule.ReferFrom.Parson = personalizedInfo;


                                referralModule.ReferFrom.Parson.ParsonId.Text = "Default Person ID";
                                if (info.TagCode == "L1")
                                {
                                    referralModule.ReferFrom.Parson.Facility.Name = ToMmlTag(info);
                                }
                                else if (info.TagCode == "L2")
                                {
                                    Address addcl = new Address();
                                    addcl.FullName = ToMmlTag(info);
                                    referralModule.ReferFrom.Parson.AddressList.Add(addcl);
                                }
                                else if (info.TagCode == "L3")
                                {
                                    Phone fax = new Phone();
                                    fax.Number = ToMmlTag(info);
                                    referralModule.ReferFrom.Parson.PhoneList.Add(fax);
                                }
                                else if (info.TagCode == "L4")
                                {
                                    referralModule.ReferFrom.Parson.ParsonName.FullName = ToMmlTag(info);
                                }
                                else if (info.TagCode == "L5")
                                {
                                    Phone phone = new Phone();
                                    phone.Number = ToMmlTag(info);
                                    referralModule.ReferFrom.Parson.PhoneList.Add(phone);
                                }

                                break;
                            case MmlStorage.TITLE:
                                referralModule.Title = ToMmlTag(info);
                                break;
                            case MmlStorage.CLINICALDIAGNOSIS:
                                referralModule.ClinicalDiagnosis = ToMmlTag(info);
                                break;
                            case MmlStorage.PASTHISTORY:
                                referralModule.PastHistory = new PastHistory();
                                referralModule.PastHistory.Text = ToMmlTag(info);
                                break;
                            case MmlStorage.FAMILYHISTORY:
                                referralModule.FamilyHistory = new FamilyHistory();
                                referralModule.FamilyHistory.Text = ToMmlTag(info);
                                break;
                            case MmlStorage.PRESENTILLNESS:
                                referralModule.PresentIllness = new PresentIllness();
                                referralModule.PresentIllness.Text = ToMmlTag(info);
                                break;
                            case MmlStorage.TESTRESULT:
                                referralModule.TestResults = new TestResults();
                                referralModule.TestResults.Text = ToMmlTag(info);
                                break;
                            case MmlStorage.CLINICALCOURSE:
                                referralModule.ClinicalCourse = new ClinicalCourse();
                                ClinicalRecord clRecortd = new ClinicalRecord();
                                clRecortd.Text = ToMmlTag(info);
                                referralModule.ClinicalCourse.ClinicalRecord.Add(clRecortd);
                                break;
                            case MmlStorage.MEDICATION:
                                referralModule.Medication = new Medication();
                                referralModule.Medication.Text = ToMmlTag(info);
                                break;
                            case MmlStorage.REFERPURPOSE:
                                referralModule.ReferPurpose = ToMmlTag(info);
                                break;

                            case MmlStorage.REMARKS:
                                if (referralModule.Remarks == null) referralModule.Remarks = new Remarks();
                                referralModule.Remarks.Text = ToMmlTag(info);
                                break;
                            case MmlStorage.REMARKS_REF:
                                if (referralModule.Remarks == null) referralModule.Remarks = new Remarks();
                                ExternalReference ext = new ExternalReference();
//                                ext.ContentType = info.Type
                                ext.Reference = ToMmlTag(info);
                                referralModule.Remarks.ExRef.Add(ext);
                                break;
                            case MmlStorage.REFERTOFACILITY:
                                referralModule.ReferToFacility = new ReferToFacility();
                                referralModule.ReferToFacility.Department = new Department();
                                referralModule.ReferToFacility.Department.Name = ToMmlTag(info);
                                break;
                        }
                        //referralModule.StructuredExpression.Add(item);
                    }
                    //if (record.OrderInfos != null && record.OrderInfos.Count > 0)
                    //{
                    //    ProblemItem item = new ProblemItem();
                    //    item.Plan = new Plan();
                    //    item.Plan.TxOrder = new RxTxTestItem();
                    //    item.Plan.TxOrder.Text = ToOrderText(record.OrderInfos);
                    //    //referralModule.StructuredExpression.Add(item);
                    //}

                    mml.Body.AddModuleItem(pcmdlitm);

                    if (patient != null)
                    {
                        //patient module
                        pcmdlitm = mml.CreatePatientModule(record.HospCode, record.Facility, record.Doctor);
                        PatientModule pimd = (PatientModule)pcmdlitm.Content;
                        pimd.MasterId = new Id();
                        pimd.MasterId.Text = patient.PatientId;
                        pimd.Birthday = !string.IsNullOrEmpty(patient.PatientBirthday)
                            ? DateTime.ParseExact(patient.PatientBirthday, "yyyy/MM/dd", new CultureInfo("ja-JP"))
                            : DateTime.Now;
                        pimd.Sex = !string.IsNullOrEmpty(patient.PatientGender) ? patient.PatientGender : "";
                        Address ad = new Address();
                        ad.FullName = !string.IsNullOrEmpty(patient.PatientAddress) ? patient.PatientAddress : "";
                        ad.Zip = !string.IsNullOrEmpty(patient.PatientZip) ? patient.PatientZip : "";
                        pimd.AddressList.Add(ad);

                        Phone ph = new Phone();
                        ph.Memo = !string.IsNullOrEmpty(patient.PatientTelephone) ? patient.PatientTelephone : "";
                        pimd.PhoneList.Add(ph);

                        mml.Body.AddModuleItem(pcmdlitm);
                    }

                }

                return mml;
            }
            catch (Exception ex)
            {
                Service.WriteLog("Exception: on ToMml Method of MmlParserIntruduceLetter class: " + ex.StackTrace);
            }

            return null;
        }

        private string ToOrderText(List<OrderInfo> orderInfos)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement rootNode = doc.CreateElement("Orders");
            foreach (OrderInfo info in orderInfos)
            {
                XmlElement elm = doc.CreateElement("Order");
                if (!string.IsNullOrEmpty(info.Content)) elm.AppendChild(CreateElement("Content", info.Content, doc));
                if (!string.IsNullOrEmpty(info.GubunBass)) elm.AppendChild(CreateElement("GubunBass", info.GubunBass, doc));
                if (!string.IsNullOrEmpty(info.HangmogCode)) elm.AppendChild(CreateElement("HangmogCode", info.HangmogCode, doc));
                if (!string.IsNullOrEmpty(info.ActionDoYn)) elm.AppendChild(CreateElement("ActionDoYn", info.ActionDoYn, doc));
                if (!string.IsNullOrEmpty(info.Bunho)) elm.AppendChild(CreateElement("Bunho", info.Bunho, doc));
                if (!string.IsNullOrEmpty(info.Doctor)) elm.AppendChild(CreateElement("Doctor", info.Doctor, doc));
                if (!string.IsNullOrEmpty(info.Gwa)) elm.AppendChild(CreateElement("Gwa", info.Gwa, doc));
                if (!string.IsNullOrEmpty(info.NaewonDate)) elm.AppendChild(CreateElement("NaewonDate", info.NaewonDate, doc));
                if (!string.IsNullOrEmpty(info.NaewonKey)) elm.AppendChild(CreateElement("NaewonKey", info.NaewonKey, doc));
                if (!string.IsNullOrEmpty(info.InputTab)) elm.AppendChild(CreateElement("InputTab", info.InputTab, doc));
                if (!string.IsNullOrEmpty(info.HangmogName)) elm.AppendChild(CreateElement("HangmogName", info.HangmogName, doc));
                if (!string.IsNullOrEmpty(info.InputGubunName)) elm.AppendChild(CreateElement("InputGubunName", info.InputGubunName, doc));
                if (!string.IsNullOrEmpty(info.OrderGubunName)) elm.AppendChild(CreateElement("OrderGubunName", info.OrderGubunName, doc));
                rootNode.AppendChild(elm);
            }
            doc.AppendChild(rootNode);
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        private XmlNode CreateElement(string localName, string content, XmlDocument doc)
        {
            XmlElement elm = doc.CreateElement(localName);
            elm.AppendChild(doc.CreateTextNode(content));
            return elm;
        }

        private string ToMmlTag(TagInfo info)
        {
            switch (info.Type)
            {
                case TypeEnum.Tag:
                {
                    return string.Format("#{0}# {1}", info.TagCode, info.Content);
                }
                case TypeEnum.Image:
                {
                    /*return string.Format("{0} {1}", IMAGE_TOKEN, info.DirLocation);*/
                    return string.Format("{0} {1}", IMAGE_TOKEN, info.TagCode + IMG_TAG_SEPA + info.DirLocation);  
                }
                case TypeEnum.Pdf:
                {
                    /*return string.Format("{0} {1}", PDF_TOKEN, info.DirLocation);*/
                    return string.Format("{0} {1}", PDF_TOKEN, info.TagCode + PDF_TAG_SEPA + info.DirLocation);
                }
                default:
                    return string.Empty;
            }
        }

        public enum MmlStorage
        {
            REFERFROM,
            OCCUPATION,
            PATIENMODULE,
            TITLE,
            PRESENTILLNESS,
            REFERPURPOSE,
            PASTHISTORY,
            FAMILYHISTORY,
            TESTRESULT,
            CLINICALCOURSE,
            MEDICATION,
            REMARKS,
            REMARKS_REF,
            REFERTOFACILITY,
            CLINICALDIAGNOSIS
        }
    }
}