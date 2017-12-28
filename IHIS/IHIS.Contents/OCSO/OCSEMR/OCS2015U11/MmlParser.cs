using EmrDocker.Glossary;
using IHIS.CloudConnector.Caching;
using IHIS.Framework;
using MedicalInterface.Mml23.MmlRd;

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
    using IHIS.CloudConnector.Contracts.Models.Ocso;

    public class MmlParser
    {
        private readonly Dictionary<string, MmlStorage> TagStorage = new Dictionary<string, MmlStorage>();
        private static readonly MmlParser _instance = new MmlParser();

        private const string IMAGE_TOKEN = "$IMG$";
        private const string PDF_TOKEN = "$PDF$";
        private const string IMG_TAG_SEPA = "#";
        private const string PDF_TAG_SEPA = "#";
        private string CACHE_FIRST_DATE_TIME = "CACHE_FIRST_DATE_TIME_{0}";

        public static MmlParser Instance
        {
            get
            {
                return _instance;
            }
        }

        private MmlParser()
        {
            TagStorage.Add("S", MmlStorage.SUBJECTIVE);
            TagStorage.Add("CC", MmlStorage.SUBJECTIVE);
            TagStorage.Add("CR", MmlStorage.SUBJECTIVE);
            TagStorage.Add("AN", MmlStorage.SUBJECTIVE);
            TagStorage.Add("DH", MmlStorage.SUBJECTIVE);
            TagStorage.Add("FH", MmlStorage.SUBJECTIVE);
            TagStorage.Add("LH", MmlStorage.SUBJECTIVE);
            TagStorage.Add("HH", MmlStorage.SUBJECTIVE);

            TagStorage.Add("O", MmlStorage.OBJECTIVE);
            TagStorage.Add("BM", MmlStorage.OBJECTIVE);
            TagStorage.Add("CO", MmlStorage.OBJECTIVE);
            TagStorage.Add("DF", MmlStorage.OBJECTIVE);
            TagStorage.Add("IF", MmlStorage.OBJECTIVE);
            TagStorage.Add("TF", MmlStorage.OBJECTIVE);

            TagStorage.Add("A", MmlStorage.ASSESSMENT);
            TagStorage.Add("MA", MmlStorage.ASSESSMENT);
            TagStorage.Add("MI", MmlStorage.ASSESSMENT);
            TagStorage.Add("MS", MmlStorage.ASSESSMENT);
            TagStorage.Add("AD", MmlStorage.ASSESSMENT);
            TagStorage.Add("CD", MmlStorage.ASSESSMENT);
            TagStorage.Add("LS", MmlStorage.ASSESSMENT);

            TagStorage.Add("P", MmlStorage.PLAN);
            TagStorage.Add("Tx", MmlStorage.PLAN);
            TagStorage.Add("Dx", MmlStorage.PLAN);
            TagStorage.Add("Ex", MmlStorage.PLAN);
            TagStorage.Add("Px", MmlStorage.PLAN);
            TagStorage.Add("Wx", MmlStorage.PLAN);
            TagStorage.Add("Np", MmlStorage.PLAN);
        }

        public EmrDocker.Types.Tuple<List<EmrRecordInfo>, PatientModelInfo> ToModel(string mml)
        {
            List<EmrRecordInfo> records = new List<EmrRecordInfo>();
            InterfaceFacade facade = new InterfaceFacade();
            PatientModelInfo patient = null;
            Mml doc = facade.ReadMml23(mml, false);

            if (doc != null && doc.Body != null && doc.Body.Modules.Count > 0)
            {
                foreach (MmlModuleItem mi in doc.Body.Modules)
                {
                    ProgressCourseModule module = mi.Content as ProgressCourseModule;
                    if (module != null)
                    {
                        EmrRecordInfo emrRecord = new EmrRecordInfo();
                        emrRecord.PkOut = mi.DocInfo.DocId;
                        emrRecord.TemplateId = mi.DocInfo.TemplateId;
                        if (mi.DocInfo.Creator != null && mi.DocInfo.Creator.Parson != null)
                        {
                            emrRecord.HospCode = mi.DocInfo.Creator.Parson.Facility == null ? string.Empty : mi.DocInfo.Creator.Parson.Facility.Id.Text;
                            emrRecord.Facility = mi.DocInfo.Creator.Parson.Facility == null ? string.Empty : mi.DocInfo.Creator.Parson.Facility.Name;
                            emrRecord.Doctor = mi.DocInfo.Creator.Parson.ParsonId.Text;
                        }
                        emrRecord.DateTime = mi.DocInfo.ConfirmDate.ToString("yyyy/MM/dd");
                        foreach (ProblemItem pi in module.StructuredExpression)
                        {
                            //each ProblemItem contains information of only one tag
                            TagInfo tag = null;
                            string tagId = string.Empty;

                            if (pi.Problem != null && !string.IsNullOrEmpty(pi.Problem.DxUid))
                            {
                                tagId = pi.Problem.DxUid;
                            }

                            foreach (MiTuple<string, int> aItem in pi.Assessment)
                            {
                                tag = ParseTag(aItem);
                            }

                            if (pi.Subjective != null)
                            {
                                foreach (SubjectiveItem si in pi.Subjective.Items)
                                {
                                    foreach (string ee in si.EventExpression)
                                    {
                                        tag = ParseTag(new MiTuple<string, int>(ee, si.Permission));
                                    }
                                }
                            }
                            if (pi.Objective != null)
                            {
                                tag = ParseTag(new MiTuple<string, int>(pi.Objective.ObjectiveNotes, pi.Objective.Permission));
                            }
                            if (pi.Plan != null)
                            {
                                if (!string.IsNullOrEmpty(pi.Plan.PlanNotes))
                                {
                                    tag = ParseTag(new MiTuple<string, int>(pi.Plan.PlanNotes, pi.Plan.Permission));
                                }
                                if (pi.Plan.TxOrder != null)
                                {
                                    emrRecord.OrderInfos.AddRange(ParseOrders(pi.Plan.TxOrder.Text));
                                }
                            }
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
                        patient.PatientBirthday = patientModule.Birthday.ToString("yyyy/MM/dd");
                        patient.PatientGender = patientModule.Sex;
                        patient.PatientAddress = patientModule.AddressList.Count == 0
                                                     ? null
                                                     : patientModule.AddressList[0].FullName;
                        patient.PatientZip = patientModule.AddressList.Count == 0
                                                     ? null
                                                     : patientModule.AddressList[0].Zip;
                        patient.PatientTelephone = patientModule.PhoneList.Count == 0
                                                       ? null
                                                       : patientModule.PhoneList[0].Memo;

                    }
                }
            }

            return new EmrDocker.Types.Tuple<List<EmrRecordInfo>, PatientModelInfo>(records, patient);
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
                                case "InputTabAndGroupSer": //Anh-LT: MED-10208 add field group_ser to InputTab for merge cell follow inputtab + group_ser
                                    info.InputTabAndGroupSer = childNode.InnerText;
                                    break;
                                case "OrderDisplayOther":
                                    info.OrderDisplayOther = childNode.InnerText;
                                    break;
                                case "Nalsu":
                                    info.Nalsu = childNode.InnerText;
                                    break;
                                case "Dv":
                                    info.Dv = childNode.InnerText;
                                    break;
                                case "OrdDanuiName":
                                    info.OrdDanuiName = childNode.InnerText;
                                    break;
                                case "Suryang":
                                    info.Suryang = childNode.InnerText;
                                    break;
                                case "BogyongName":
                                    info.BogyongName = childNode.InnerText;
                                    break;
                                    //MED-15473
                                case "DvTime":
                                    info.DvTime = childNode.InnerText;
                                    break;
                                case "MixSet":
                                    info.MixSet = childNode.InnerText;
                                    break;
                                case "JusaName":
                                    info.JusaName= childNode.InnerText;
                                    break;
                                case "UnequalDosage":
                                    info.UnequalDosage = childNode.InnerText;
                                    break;
                                case "HopeDate":
                                    info.HopeDate = childNode.InnerText;
                                    break;
                                case "Comment":
                                    info.Comment = childNode.InnerText;
                                    break;
                                case "NumberOfDay":
                                    info.NumberOfDay = childNode.InnerText;
                                    break;
                                case "GroupSer":
                                    info.GroupSer = childNode.InnerText;
                                    break;                               
                            }
                        }
                        orders.Add(info);
                    }
                }
            }
            return orders;
        }

        private TagInfo ParseTag(MiTuple<string, int> content)
        {
            if (content != null && !string.IsNullOrEmpty(content.V1))
            {
                TagInfo info = new TagInfo();
                info.Type = TypeEnum.Unknown;
                if (content.V1.Trim().StartsWith(IMAGE_TOKEN, StringComparison.CurrentCultureIgnoreCase))
                {
                    info.Type = TypeEnum.Image;
                    string strContent = content.V1.Trim().Substring(IMAGE_TOKEN.Length);
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
                        info.DirLocation = content.V1.Trim().Substring(IMAGE_TOKEN.Length);
                    }
                }
                else if (content.V1.Trim().StartsWith(PDF_TOKEN, StringComparison.CurrentCultureIgnoreCase))
                {
                    info.Type = TypeEnum.Pdf;
                    string strContent = content.V1.Trim().Substring(PDF_TOKEN.Length);
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
                        info.DirLocation = content.V1.Trim().Substring(PDF_TOKEN.Length);
                    }
                }
                else
                {
                    int index = content.V1.Trim().IndexOf("#", 1, StringComparison.Ordinal);
                    if (index > 1)
                    {
                        info.Type = TypeEnum.Tag;
                        info.Content = content.V1.Trim().Substring(index + 1).Trim();
                        info.TagCode = content.V1.Trim().Substring(1, index - 1);
                    }
                }
                info.Permission = content.V2;
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

        public string ToMmL(List<EmrRecordInfo> records, PatientModelInfo patient)
        {
            InterfaceFacade facade = new InterfaceFacade();

            Mml mml = facade.CreateMml23(patient.PatientId);
            foreach (EmrRecordInfo record in records)
            {
                MmlModuleItem pcmdlitm = mml.CreateProgressCourseModule(record.PkOut, record.HospCode, record.Facility, record.Doctor, record.DateTime);
                ProgressCourseModule pcdis = (ProgressCourseModule)pcmdlitm.Content;
                foreach (TagInfo info in record.TagInfos)
                {
                    MmlStorage storage = info.TagCode != null && TagStorage.ContainsKey(info.TagCode)
                                             ? TagStorage[info.TagCode]
                                             : MmlStorage.PLAN;
                    ProblemItem item = new ProblemItem();
                    item.Problem = new Problem();
                    item.Problem.DxUid = info.Id;
                    MiTuple<string, int> tag = ToMmlTag(info);
                    switch (storage)
                    {
                        case MmlStorage.ASSESSMENT:
                            item.Assessment.Add(tag);
                            break;
                        case MmlStorage.OBJECTIVE:
                            item.Objective = new Objective();
                            item.Objective.ObjectiveNotes = tag.V1;
                            item.Objective.Permission = tag.V2;
                            break;
                        case MmlStorage.PLAN:
                            item.Plan = new Plan();
                            item.Plan.PlanNotes = tag.V1;
                            item.Plan.Permission = tag.V2;
                            break;
                        case MmlStorage.SUBJECTIVE:
                            item.Subjective = new Subjective();
                            SubjectiveItem si = new SubjectiveItem();
                            si.TimeExpression = DateTime.Now.ToString("yyyy/MM/dd");
                            si.EventExpression.Add(tag.V1);
                            si.Permission = tag.V2;
                            item.Subjective.Items.Add(si);
                            break;
                    }
                    pcdis.StructuredExpression.Add(item);
                }
                if (record.OrderInfos != null && record.OrderInfos.Count > 0)
                {
                    ProblemItem item = new ProblemItem();
                    item.Plan = new Plan();
                    item.Plan.TxOrder = new RxTxTestItem();
                    item.Plan.TxOrder.Text = ToOrderText(record.OrderInfos);
                    pcdis.StructuredExpression.Add(item);
                }

                mml.Body.AddModuleItem(pcmdlitm);

                if (patient != null)
                {
                    //patient module
                    pcmdlitm = mml.CreatePatientModule(record.HospCode, record.Facility, record.Doctor);
                    PatientModule pimd = (PatientModule)pcmdlitm.Content;
                    pimd.MasterId = new Id();
                    pimd.MasterId.Text = patient.PatientId;
                    pimd.Birthday = !string.IsNullOrEmpty(patient.PatientBirthday) ? DateTime.ParseExact(patient.PatientBirthday, "yyyy/MM/dd", new CultureInfo("ja-JP")) : DateTime.Now;
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
            return facade.WriteMml23(mml);
        }

        public string ToMmL(List<EmrRecordInfo> records, PatientModelInfo patient, string oldMml)
        {
            bool havePatientModule = false;
            InterfaceFacade facade = new InterfaceFacade();

            Mml mml = facade.CreateMml23(patient.PatientId);

            //get old content of ReferralModule
            if (!String.IsNullOrEmpty(oldMml))
            {
                Triple<List<EmrRecordInfo>, PatientModelInfo, HospitalModelInfo> oldResult = MmlParserIntruduceLetter.Instance.ToModel(oldMml);
                List<EmrRecordInfo> listReferral = oldResult.V1;
                PatientModelInfo oldPatientInfo = oldResult.V2;
                if (listReferral.Count > 0)
                {
                    //generate old MML
                    mml = MmlParserIntruduceLetter.Instance.ToObjectMmL(listReferral, oldPatientInfo);
                    havePatientModule = true;
                }
            }

            foreach (EmrRecordInfo record in records)
            {
                MmlModuleItem pcmdlitm = mml.CreateProgressCourseModule(record.PkOut, record.HospCode, record.Facility, record.Doctor, record.DateTime);
                ProgressCourseModule pcdis = (ProgressCourseModule)pcmdlitm.Content;
                foreach (TagInfo info in record.TagInfos)
                {
                    MmlStorage storage = info.TagCode != null && TagStorage.ContainsKey(info.TagCode)
                                             ? TagStorage[info.TagCode]
                                             : MmlStorage.PLAN;
                    ProblemItem item = new ProblemItem();
                    item.Problem = new Problem();
                    item.Problem.DxUid = info.Id;
                    MiTuple<string, int> tag = ToMmlTag(info);

                    switch (storage)
                    {
                        case MmlStorage.ASSESSMENT:
                            item.Assessment.Add(tag);
                            break;
                        case MmlStorage.OBJECTIVE:
                            item.Objective = new Objective();
                            item.Objective.ObjectiveNotes = tag.V1;
                            item.Objective.Permission = tag.V2;
                            break;
                        case MmlStorage.PLAN:
                            item.Plan = new Plan();
                            item.Plan.PlanNotes = tag.V1;
                            item.Plan.Permission = tag.V2;
                            break;
                        case MmlStorage.SUBJECTIVE:
                            item.Subjective = new Subjective();
                            SubjectiveItem si = new SubjectiveItem();
                            si.TimeExpression = DateTime.Now.ToString("yyyy/MM/dd");
                            si.EventExpression.Add(tag.V1);
                            si.Permission = tag.V2;
                            item.Subjective.Items.Add(si);
                            break;                       
                    }
                    pcdis.StructuredExpression.Add(item);
                }
                if (record.OrderInfos != null && record.OrderInfos.Count > 0)
                {
                    ProblemItem item = new ProblemItem();
                    item.Plan = new Plan();
                    item.Plan.TxOrder = new RxTxTestItem();
                    item.Plan.TxOrder.Text = ToOrderText(record.OrderInfos);
                    pcdis.StructuredExpression.Add(item);
                }

                mml.Body.AddModuleItem(pcmdlitm);

                if (!havePatientModule)
                {
                    if (patient != null)
                    {
                        //patient module
                        pcmdlitm = mml.CreatePatientModule(record.HospCode, record.Facility, record.Doctor);
                        PatientModule pimd = (PatientModule) pcmdlitm.Content;
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

        public string ToMmL(List<EmrRecordInfo> records, PatientModelInfo patient, string oldMml, List<OcsoOCS1003P01GridOutSangInfo> lstOutSangInfos)
        {
            bool havePatientModule = false;
            InterfaceFacade facade = new InterfaceFacade();

            Mml mml = facade.CreateMml23(patient.PatientId);

            //get old content of ReferralModule
            if (!String.IsNullOrEmpty(oldMml))
            {
                Triple<List<EmrRecordInfo>, PatientModelInfo, HospitalModelInfo> oldResult = MmlParserIntruduceLetter.Instance.ToModel(oldMml);
                List<EmrRecordInfo> listReferral = oldResult.V1;
                PatientModelInfo oldPatientInfo = oldResult.V2;
                if (listReferral.Count > 0)
                {
                    //generate old MML
                    mml = MmlParserIntruduceLetter.Instance.ToObjectMmL(listReferral, oldPatientInfo);
                    havePatientModule = true;
                }
            }

            foreach (EmrRecordInfo record in records)
            {
                MmlModuleItem pcmdlitm = mml.CreateProgressCourseModule(record.PkOut, record.HospCode, record.Facility, record.Doctor, record.DateTime, record.TemplateId);
                ProgressCourseModule pcdis = (ProgressCourseModule)pcmdlitm.Content;
                foreach (TagInfo info in record.TagInfos)
                {
                    MmlStorage storage = info.TagCode != null && TagStorage.ContainsKey(info.TagCode)
                                             ? TagStorage[info.TagCode]
                                             : MmlStorage.PLAN;
                    ProblemItem item = new ProblemItem();
                    item.Problem = new Problem();
                    item.Problem.DxUid = info.Id;
                    MiTuple<string, int> tag = ToMmlTag(info);

                    switch (storage)
                    {
                        case MmlStorage.ASSESSMENT:
                            item.Assessment.Add(tag);
                            break;
                        case MmlStorage.OBJECTIVE:
                            item.Objective = new Objective();
                            item.Objective.ObjectiveNotes = tag.V1;
                            item.Objective.Permission = tag.V2;
                            break;
                        case MmlStorage.PLAN:
                            item.Plan = new Plan();
                            item.Plan.PlanNotes = tag.V1;
                            item.Plan.Permission = tag.V2;
                            break;
                        case MmlStorage.SUBJECTIVE:
                            item.Subjective = new Subjective();
                            SubjectiveItem si = new SubjectiveItem();
                            si.TimeExpression = DateTime.Now.ToString("yyyy/MM/dd");
                            si.EventExpression.Add(tag.V1);
                            si.Permission = tag.V2;
                            item.Subjective.Items.Add(si);
                            break;
                    }
                    pcdis.StructuredExpression.Add(item);
                }
                if (record.OrderInfos != null && record.OrderInfos.Count > 0)
                {
                    ProblemItem item = new ProblemItem();
                    item.Plan = new Plan();
                    item.Plan.TxOrder = new RxTxTestItem();
                    item.Plan.TxOrder.Text = ToOrderText(record.OrderInfos);
                    pcdis.StructuredExpression.Add(item);
                }

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

            if (lstOutSangInfos != null && lstOutSangInfos.Count > 0)
            {
                foreach (OcsoOCS1003P01GridOutSangInfo outSangInfo in lstOutSangInfos)
                {
                    string cacheKeys = string.Format(CACHE_FIRST_DATE_TIME, NetInfo.Language);
                    string _dateCacheFromServer = CacheService.Instance.Get<string>(cacheKeys);

                    MmlModuleItem pcmdlitmOs = mml.CreateRegisteredDiagnosisModule(!string.IsNullOrEmpty(_dateCacheFromServer) ? _dateCacheFromServer : DateTime.Now.ToShortDateString(), outSangInfo.OutsangId);
                    RegisteredDiagnosisModule rsDiagnosisModule = (RegisteredDiagnosisModule)pcmdlitmOs.Content;
                    rsDiagnosisModule.Diagnosis = new Diagnosis();
                    Diagnosis diagnosis = new Diagnosis();
                    int permission = 15;
                    bool isOk = int.TryParse(outSangInfo.EmrPermission, out permission);
                    diagnosis.Permission = permission;
                    diagnosis.Code = outSangInfo.SugaSangCode;
                    diagnosis.System = "ICD10";
                    diagnosis.Text = outSangInfo.PreModifierName + outSangInfo.SangName + outSangInfo.PostModifierName;
                    rsDiagnosisModule.Diagnosis = diagnosis;

                    /*rsDiagnosisModule.DiagnosisContents = new List<DiagnosisItem>();
                    List<DiagnosisItem> lstDiagnosisItems = new List<DiagnosisItem>();
                    DiagnosisItem diagnosisItem = new DiagnosisItem();
                    diagnosisItem.Code = outSangInfo.SangCode;
                    diagnosisItem.System = outSangInfo.SangName;
                    lstDiagnosisItems.Add(diagnosisItem);
                    rsDiagnosisModule.DiagnosisContents = lstDiagnosisItems;*/

                    if (outSangInfo.JuSangYn == "Y")
                    {
                        rsDiagnosisModule.Categories = new List<Category>();
                        List<Category> lstCategories = new List<Category>();
                        Category category = new Category();
                        category.TableId = "MML0012";
                        category.Text = "MainDiagnosis";
                        lstCategories.Add(category);
                        rsDiagnosisModule.Categories = lstCategories;
                    }

                    rsDiagnosisModule.StartDate = !string.IsNullOrEmpty(outSangInfo.SangStartDate)
                            ? DateTime.ParseExact(outSangInfo.SangStartDate, "yyyy/MM/dd", new CultureInfo("ja-JP"))
                            : DateTime.Now;
                    rsDiagnosisModule.EndDate = !string.IsNullOrEmpty(outSangInfo.SangEndDate)
                            ? DateTime.ParseExact(outSangInfo.SangEndDate, "yyyy/MM/dd", new CultureInfo("ja-JP"))
                            : DateTime.Now;
                    if (!string.IsNullOrEmpty(outSangInfo.CodeName))
                    {
                        rsDiagnosisModule.Outcome = new OutcomeItem();
                        OutcomeItem outcomeItem = new OutcomeItem();
                        outcomeItem.TableId = "MML0016";
                        outcomeItem.Text = outSangInfo.CodeName;

                        rsDiagnosisModule.Outcome = outcomeItem;
                    }

                    rsDiagnosisModule.FirstEncounterDate = !string.IsNullOrEmpty(outSangInfo.SangJindanDate)
                            ? DateTime.ParseExact(outSangInfo.SangJindanDate, "yyyy/MM/dd", new CultureInfo("ja-JP"))
                            : DateTime.Now;

                    mml.Body.AddModuleItem(pcmdlitmOs);
                }
            }

            return facade.WriteMml23(mml);
        }

        public Mml ToObjectMmL(List<EmrRecordInfo> records, PatientModelInfo patient)
        {
            InterfaceFacade facade = new InterfaceFacade();

            Mml mml = facade.CreateMml23(patient.PatientId);
            foreach (EmrRecordInfo record in records)
            {
                MmlModuleItem pcmdlitm = mml.CreateProgressCourseModule(record.PkOut, record.HospCode, record.Facility, record.Doctor, record.DateTime);
                ProgressCourseModule pcdis = (ProgressCourseModule)pcmdlitm.Content;
                foreach (TagInfo info in record.TagInfos)
                {
                    MmlStorage storage = info.TagCode != null && TagStorage.ContainsKey(info.TagCode)
                                             ? TagStorage[info.TagCode]
                                             : MmlStorage.PLAN;
                    ProblemItem item = new ProblemItem();
                    item.Problem = new Problem();
                    item.Problem.DxUid = info.Id;
                    MiTuple<string, int> tag = ToMmlTag(info);
                    switch (storage)
                    {
                        case MmlStorage.ASSESSMENT:
                            item.Assessment.Add(tag);
                            break;
                        case MmlStorage.OBJECTIVE:
                            item.Objective = new Objective();
                            item.Objective.ObjectiveNotes = tag.V1;
                            item.Objective.Permission = tag.V2;
                            break;
                        case MmlStorage.PLAN:
                            item.Plan = new Plan();
                            item.Plan.PlanNotes = tag.V1;
                            item.Plan.Permission = tag.V2;
                            break;
                        case MmlStorage.SUBJECTIVE:
                            item.Subjective = new Subjective();
                            SubjectiveItem si = new SubjectiveItem();
                            si.TimeExpression = DateTime.Now.ToString("yyyy/MM/dd");
                            si.EventExpression.Add(tag.V1);
                            si.Permission = tag.V2;
                            item.Subjective.Items.Add(si);
                            break;
                    }
                    pcdis.StructuredExpression.Add(item);
                }
                if (record.OrderInfos != null && record.OrderInfos.Count > 0)
                {
                    ProblemItem item = new ProblemItem();
                    item.Plan = new Plan();
                    item.Plan.TxOrder = new RxTxTestItem();
                    item.Plan.TxOrder.Text = ToOrderText(record.OrderInfos);
                    pcdis.StructuredExpression.Add(item);
                }

                mml.Body.AddModuleItem(pcmdlitm);

                if (patient != null)
                {
                    //patient module
                    pcmdlitm = mml.CreatePatientModule(record.HospCode, record.Facility, record.Doctor);
                    PatientModule pimd = (PatientModule)pcmdlitm.Content;
                    pimd.MasterId = new Id();
                    pimd.MasterId.Text = patient.PatientId;
                    pimd.Birthday = !string.IsNullOrEmpty(patient.PatientBirthday) ? DateTime.ParseExact(patient.PatientBirthday, "yyyy/MM/dd", new CultureInfo("ja-JP")) : DateTime.Now;
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
                //AnhLT - MED-10208 add field group_ser to InputTab for merge cell follow inputtab + group_ser
                if (!string.IsNullOrEmpty(info.InputTabAndGroupSer)) elm.AppendChild(CreateElement("InputTabAndGroupSer", info.InputTabAndGroupSer, doc));
                if (!string.IsNullOrEmpty(info.OrderDisplayOther)) elm.AppendChild(CreateElement("OrderDisplayOther", info.OrderDisplayOther, doc));
                if (!string.IsNullOrEmpty(info.Nalsu)) elm.AppendChild(CreateElement("Nalsu", info.Nalsu, doc));
                if (!string.IsNullOrEmpty(info.Dv)) elm.AppendChild(CreateElement("Dv", info.Dv, doc));
                if (!string.IsNullOrEmpty(info.OrdDanuiName)) elm.AppendChild(CreateElement("OrdDanuiName", info.OrdDanuiName, doc));
                if (!string.IsNullOrEmpty(info.Suryang)) elm.AppendChild(CreateElement("Suryang", info.Suryang, doc));
                if (!string.IsNullOrEmpty(info.BogyongName)) elm.AppendChild(CreateElement("BogyongName", info.BogyongName, doc));
                //MED-15743
                if (!string.IsNullOrEmpty(info.DvTime)) elm.AppendChild(CreateElement("DvTime", info.DvTime, doc));
                if (!string.IsNullOrEmpty(info.MixSet)) elm.AppendChild(CreateElement("MixSet", info.MixSet, doc));
                if (!string.IsNullOrEmpty(info.JusaName)) elm.AppendChild(CreateElement("JusaName", info.JusaName, doc));
                if (!string.IsNullOrEmpty(info.UnequalDosage)) elm.AppendChild(CreateElement("UnequalDosage", info.UnequalDosage, doc));
                if (!string.IsNullOrEmpty(info.HopeDate)) elm.AppendChild(CreateElement("HopeDate", info.HopeDate, doc));
                if (!string.IsNullOrEmpty(info.Comment)) elm.AppendChild(CreateElement("Comment", info.Comment, doc));
                if (!string.IsNullOrEmpty(info.NumberOfDay)) elm.AppendChild(CreateElement("NumberOfDay", info.NumberOfDay, doc));
                if (!string.IsNullOrEmpty(info.GroupSer)) elm.AppendChild(CreateElement("GroupSer", info.GroupSer, doc));

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

        private MiTuple<string, int> ToMmlTag(TagInfo info)
        {
            switch (info.Type)
            {
                case TypeEnum.Tag:
                    return new MiTuple<string, int>(string.Format("#{0}# {1}", info.TagCode, info.Content), info.Permission);
                case TypeEnum.Image:
                {
                    return new MiTuple<string, int>(string.Format("{0} {1}", IMAGE_TOKEN, info.TagCode + IMG_TAG_SEPA + info.DirLocation), info.Permission);
                }
                case TypeEnum.Pdf:
                {
                    return new MiTuple<string, int>(string.Format("{0} {1}", PDF_TOKEN, info.TagCode + PDF_TAG_SEPA + info.DirLocation), info.Permission);
                }
                default:
                return new MiTuple<string, int>(string.Empty, info.Permission);
            }
        }

        public enum MmlStorage
        {
            //PROBLEM, this element contains information of Tag identifier
            SUBJECTIVE,
            OBJECTIVE,
            PLAN,
            ASSESSMENT
        }
    }
}