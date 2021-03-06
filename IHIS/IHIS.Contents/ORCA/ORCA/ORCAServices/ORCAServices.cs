using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Xml;
using IHIS.Framework;
using MedicalInterface;
using MedicalInterface.Mml23.MmlHi;
using MedicalInterface.Mml23;
using MedicalInterface.Mml23.MmlFc;
using MedicalInterface.Mml23.MmlAd;
using MedicalInterface.Mml23.MmlRd;
using MedicalInterface.Mml23.Claim;
using ORCA;
using System.Net.Sockets;
using System.IO;
using MedicalInterface.Mml23.MmlPi;

namespace ORCA
{
    public class ORCAServices
    {
        #region Constants

        private const int BufferSize = 32767;

        #endregion

        #region Fields & Properties

        private BookingInfo _bookingInfo;
        private OrdersInfo _ordersInfo;

        public BookingInfo BookingInfo
        {
            get { return _bookingInfo; }
            set { _bookingInfo = value; }
        }
        public OrdersInfo OrdersInfo
        {
            get { return _ordersInfo; }
            set { _ordersInfo = value; }
        }

        #endregion

        #region Constructor

        public ORCAServices(BookingInfo bookingInfo)
        {
            this._bookingInfo = bookingInfo;
        }

        public ORCAServices(OrdersInfo ordersInfo)
        {
            this._ordersInfo = ordersInfo;
        }

        #endregion

        #region Methods (public)

        public void SentBooking(out string msgOutput)
        {
            msgOutput = "";
            string HOST = EnvironInfo.ORCAserverInfo.Host;
            string PORT = EnvironInfo.ORCAserverInfo.BookingPort;
            string USER = EnvironInfo.ORCAserverInfo.User;
            string PASSWD = EnvironInfo.ORCAserverInfo.Password;
            string CONTENT_TYPE = EnvironInfo.ORCAserverInfo.ContentType;
            string STRINGURL = EnvironInfo.ORCAserverInfo.BookingUrl;
            string URL = "http://" + HOST + ":" + PORT + STRINGURL + BookingInfo.AppointmentInfo;

            XmlDocument xml = new XmlDocument();
            XmlElement data = xml.CreateElement("data");
            xml.AppendChild(data);
            XmlElement appointreq = xml.CreateElement("appointreq");
            appointreq.SetAttribute("type", "record");
            data.AppendChild(appointreq);

            XmlElement Patient_ID = xml.CreateElement("Patient_ID");
            Patient_ID.SetAttribute("type", "string");
            Patient_ID.InnerText = BookingInfo.Bunho;
            appointreq.AppendChild(Patient_ID);

            XmlElement WholeName = xml.CreateElement("WholeName");
            WholeName.SetAttribute("type", "string");
            WholeName.InnerText = BookingInfo.WholeName;
            appointreq.AppendChild(WholeName);

            XmlElement WholeName_inKana = xml.CreateElement("WholeName_inKana");
            WholeName_inKana.SetAttribute("type", "string");
            WholeName_inKana.InnerText = BookingInfo.WholeNameKana;
            appointreq.AppendChild(WholeName_inKana);

            XmlElement Appointment_Date = xml.CreateElement("Appointment_Date");
            Appointment_Date.SetAttribute("type", "string");
            Appointment_Date.InnerText = BookingInfo.NaewonDate;
            appointreq.AppendChild(Appointment_Date);

            XmlElement Appointment_Time = xml.CreateElement("Appointment_Time");
            Appointment_Time.SetAttribute("type", "string");
            Appointment_Time.InnerText = BookingInfo.NaewonTime;
            appointreq.AppendChild(Appointment_Time);

            XmlElement Appointment_Id = xml.CreateElement("Appointment_Id");
            Appointment_Id.SetAttribute("type", "string");
            Appointment_Id.InnerText = BookingInfo.AppointmentId;
            appointreq.AppendChild(Appointment_Id);

            XmlElement Department_Code = xml.CreateElement("Department_Code");
            Department_Code.SetAttribute("type", "string");
            Department_Code.InnerText = BookingInfo.Gwa;
            appointreq.AppendChild(Department_Code);

            XmlElement Physician_Code = xml.CreateElement("Physician_Code");
            Physician_Code.SetAttribute("type", "string");
            Physician_Code.InnerText = BookingInfo.Doctor;
            appointreq.AppendChild(Physician_Code);

            XmlElement Medical_Information = xml.CreateElement("Medical_Information");
            Medical_Information.SetAttribute("type", "string");
            Medical_Information.InnerText = BookingInfo.MedicalInfo;
            appointreq.AppendChild(Medical_Information);

            XmlElement Appointment_Information = xml.CreateElement("Appointment_Information");
            Appointment_Information.SetAttribute("type", "string");
            Appointment_Information.InnerText = BookingInfo.AppointmentInfo;
            appointreq.AppendChild(Appointment_Information);

            XmlElement Appointment_Note = xml.CreateElement("Appointment_Note");
            Appointment_Note.SetAttribute("type", "string");
            Appointment_Note.InnerText = BookingInfo.AppointmentNote;
            appointreq.AppendChild(Appointment_Note);

            string BODY = xml.OuterXml;

            byte[] record_in_byte = Encoding.UTF8.GetBytes(BODY);

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(URL);

            req.Method = "POST";
            req.ContentType = CONTENT_TYPE;
            req.ContentLength = record_in_byte.Length;
            req.Credentials = new NetworkCredential(USER, PASSWD);

            HttpWebResponse res = null;
            try
            {
                Stream reqstream = req.GetRequestStream();

                reqstream.Write(record_in_byte, 0, record_in_byte.Length);
                reqstream.Close();

                res = (HttpWebResponse)req.GetResponse();

                //Console.WriteLine(res.ResponseUri);
                //Console.WriteLine(res.StatusDescription);
            }
            catch (WebException exc)
            {
                if (exc.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse err = (HttpWebResponse)exc.Response;

                    int errcode = (int)err.StatusCode;

                    //Console.WriteLine(err.ResponseUri);
                    //XMessageBox.Show("{0}:{1}" + errcode + err.StatusDescription);

                    err.Close();
                    throw exc;

                }
            }

            if (res != null)
            {
                Stream str = res.GetResponseStream();
                StreamReader strread = new StreamReader(str, new UTF8Encoding());

                string FOO = strread.ReadToEnd();
                //string FILE_NAME = "foo.xml";
                //File.WriteAllText(FILE_NAME, FOO);

                //Convert string resp to XML get value by tag name
                XmlDocument respXmlDocument = new XmlDocument();
                respXmlDocument.LoadXml(FOO);
                XmlElement root = respXmlDocument.DocumentElement;
                XmlNode nodeSelectName = root.SelectSingleNode("/xmlio2/appointres/Api_Result_Message");
                XmlNode nodeSelectCode = root.SelectSingleNode("/xmlio2/appointres/Api_Result");
                string outValueCode = nodeSelectCode.InnerText;
                string outValueName = nodeSelectName.InnerText;
                //show message 
                //XMessageBox.Show(outValueCode + " - " + outValueName);
                msgOutput = outValueCode + " - " + outValueName;
                strread.Close();
                str.Close();

                res.Close();
            }
        }

        public bool SaveMmlOrders(string filePath)
        {
            if (this._ordersInfo == null)
            {
                return false;
            }

            InterfaceFacade facade = new InterfaceFacade();

            try
            {
                #region Create MML Header

                // Create header
                facade.PersonalizedInfo = new MedicalInterface.Mml23.MmlPsi.PersonalizedInfo();
                // Id
                facade.PersonalizedInfo.ParsonId.Text = this._ordersInfo.HeaderInfo.FacilityId;
                // Name
                facade.PersonalizedInfo.ParsonName.FullName = this._ordersInfo.HeaderInfo.HospName;
                // Facility
                facade.PersonalizedInfo.Facility.Id.IdType = "insurance";
                facade.PersonalizedInfo.Facility.Id.TableId = "MML0027";
                facade.PersonalizedInfo.Facility.Id.Text = this._ordersInfo.HeaderInfo.FacilityCode;
                facade.PersonalizedInfo.Facility.Name = this._ordersInfo.HeaderInfo.FacilityName;
                facade.PersonalizedInfo.Facility.RepCode = "I";
                facade.PersonalizedInfo.Facility.TableId = "MML0025";
                // Department
                facade.PersonalizedInfo.Department.Id.IdType = "medical";
                facade.PersonalizedInfo.Department.Id.TableId = "MML0029";
                facade.PersonalizedInfo.Department.Id.Text = "01";
                //facade.PersonalizedInfo.Department.Name = this._ordersInfo.DetailInfo.GwaName;
                facade.PersonalizedInfo.Department.RepCode = "I";
                facade.PersonalizedInfo.Department.TableId = "MML0025";
                // AddressList
                facade.PersonalizedInfo.AddressList = new List<Address>();
                Address addr = new Address();
                addr.AddressClass = "";
                addr.CountryCode = "";
                addr.TableId = "MML0025";
                //addr.FullName = "ﾅ・ﾅﾔﾊｸｵｶ靈ﾜｶ｣ｲ｡ﾝ｣ｲ｣ｸ｡ﾝ｣ｱ｣ｶ";
                addr.FullName = this._ordersInfo.HeaderInfo.HospAddress;
                //addr.Zip = "113-0021";
                addr.Zip = this._ordersInfo.HeaderInfo.HospZipCode;
                facade.PersonalizedInfo.AddressList.Add(addr);
                // CreatorParson
                facade.CreatorParson = new ParsonInfo();
                facade.CreatorParson.ProfessionCode = this._ordersInfo.HeaderInfo.CreatorText;

                // Create new MML
                Mml mml = facade.CreateMml23(this._ordersInfo.HeaderInfo.Bunho);
                mml.CreateDate = this._ordersInfo.HeaderInfo.CreateDate;
                mml.Version = this._ordersInfo.HeaderInfo.Version;

                #endregion

                #region Create MML Body

                // Health insurance module
                if (this._ordersInfo.DetailInfo.HiModuleItem != null)
                {
                    this.CreateHealthInsuranceModule(mml, this._ordersInfo.DetailInfo.HiModuleItem);
                }

                // Diagnosis module
                if (this._ordersInfo.DetailInfo.RdModuleItem != null)
                {
                    foreach (RegisteredDiagnosisModuleItem rdItem in this._ordersInfo.DetailInfo.RdModuleItem)
                    {
                        CreateRegisteredDiagnosisModule(mml, rdItem);
                    }
                }

                // Claim module
                if (this._ordersInfo.DetailInfo.ClaimModuleItem != null)
                {
                    this.CreateClaimModule(mml, this._ordersInfo.DetailInfo.ClaimModuleItem);
                }

                // TODO other modules

                #endregion

                // Writes to text file
                string contents = this.WriteMmlToString(mml, facade);
                System.IO.File.WriteAllText(filePath, contents);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void SendTCP(string sendingFile, string IPA, Int32 PortN)
        {
            char EOT = (char)0x04;
            byte[] SendingBuffer = null;
            TcpClient client = null;
            NetworkStream netstream = null;
            try
            {
                client = new TcpClient(IPA, PortN);
                netstream = client.GetStream();
                FileStream Fs = new FileStream(sendingFile, FileMode.Open, FileAccess.Read);
                int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(BufferSize)));
                int TotalLength = (int)Fs.Length;
                int CurrentPacketLength;
                bool endoffile = false;
                for (int i = 0; i < NoOfPackets; i++)
                {
                    if (TotalLength > BufferSize)
                    {
                        CurrentPacketLength = BufferSize;
                        TotalLength = TotalLength - CurrentPacketLength;
                    }
                    else
                    {
                        CurrentPacketLength = TotalLength;
                        endoffile = true;
                    }
                    if (endoffile)
                    {
                        SendingBuffer = new byte[CurrentPacketLength + 1];
                        Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                        SendingBuffer[CurrentPacketLength] = Convert.ToByte(EOT);
                    }
                    else
                    {
                        SendingBuffer = new byte[CurrentPacketLength];
                        Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                    }
                    netstream.Write(SendingBuffer, 0, (int)SendingBuffer.Length);
                }
                Fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                netstream.Close();
                client.Close();
            }
        }

        #endregion

        #region Methods (private)

        #region Create MML

        private void CreateMmlHeader(Mml mml, HeaderInfo info)
        {

        }

        /// <summary>
        /// CreateHealthInsuranceModule
        /// </summary>
        /// <param name="mml">mml stream</param>
        /// <param name="hiModuleInfo">input info</param>
        /// <returns></returns>
        private void CreateHealthInsuranceModule(Mml mml, HealthInsuranceModuleItem hiModuleInfo)
        {
            // Health insurance module
            MmlModuleItem mmiHi = mml.CreateHealthInsuranceModule();
            HealthInsurance hiModuleInsurance = (HealthInsurance)mmiHi.Content;
            hiModuleInsurance.CountryType = hiModuleInfo.CountryType;
            hiModuleInsurance.ClientIdGroup = "";
            hiModuleInsurance.ClientIdNumber = "";
            //hiModuleInsurance.FamilyFlag = true;
            hiModuleInsurance.StartDate = hiModuleInfo.StartDate;
            hiModuleInsurance.EndDate = hiModuleInfo.EndDate;
            hiModuleInsurance.ClientIdGroup = "";
            hiModuleInsurance.ClientIdNumber = "";
            //hiModuleInsurance.PaymentOutRatio = 30;
            hiModuleInsurance.InsuranceNumber = hiModuleInfo.InsuranceNumber;
            // PublicInsurance
            hiModuleInsurance.PublicInsuranceList = new SortedList<int, PublicInsuranceItem>();
            PublicInsuranceItem pItem = new PublicInsuranceItem();
            pItem.Priority = hiModuleInfo.PublicHeathInsuranceItem.PriorityNumber;
            pItem.ProviderName = hiModuleInfo.PublicHeathInsuranceItem.ProviderName;
            pItem.ProviderNumber = hiModuleInfo.PublicHeathInsuranceItem.ProviderNumber;
            pItem.StartDate = hiModuleInfo.PublicHeathInsuranceItem.StartDate;
            pItem.EndDate = hiModuleInfo.PublicHeathInsuranceItem.EndDate;
            hiModuleInsurance.PublicInsuranceList.Add(0, pItem);
            // InsuranceClass
            hiModuleInsurance.InsuranceClass = new InsuranceClass();
            hiModuleInsurance.InsuranceClass.Code = hiModuleInfo.InsuranceCode;
            hiModuleInsurance.InsuranceClass.TableId = "MML0031";
            //hiModuleInsurance.InsuranceClass.Text = "ｹﾝ";

            mml.Body.AddModuleItem(mmiHi);
        }

        /// <summary>
        /// CreateRegisteredDiagnosisModule
        /// </summary>
        /// <param name="mml"></param>
        /// <param name="rdModule"></param>
        private void CreateRegisteredDiagnosisModule(Mml mml, RegisteredDiagnosisModuleItem rdModuleItem)
        {
            MmlModuleItem mmiRd = mml.CreateRegisteredDiagnosisModule();
            RegisteredDiagnosisModule regDiagModule = (RegisteredDiagnosisModule)mmiRd.Content;
            regDiagModule.DiagnosisContents = new List<DiagnosisItem>();
            regDiagModule.Categories = new List<Category>();
            regDiagModule.Diagnosis = new Diagnosis();
            regDiagModule.StartDate = rdModuleItem.DiagnosisStartDate;
            regDiagModule.EndDate = rdModuleItem.DiagnosisEndDate;

            // DiagnosisItem
            DiagnosisItem diagItem = new DiagnosisItem();
            diagItem.Code = rdModuleItem.DiagnosisCode;
            diagItem.System = rdModuleItem.DiagnosisSystem;
            //diagItem.Text = "心房細動";
            regDiagModule.DiagnosisContents.Add(diagItem);

            // Category
            Category ctg = new Category();
            ctg.TableId = rdModuleItem.MmlTableId;
            ctg.Text = rdModuleItem.DiagnosisCategory;
            regDiagModule.Categories.Add(ctg);

            // Append to body
            mml.Body.AddModuleItem(mmiRd);
        }

        /// <summary>
        /// CreateClaimModule
        /// </summary>
        /// <param name="mml"></param>
        /// <param name="claimModuleItem"></param>
        private void CreateClaimModule(Mml mml, ClaimModuleItem claimModuleItem)
        {
            MmlModuleItem mmiClaim = mml.CreateClaimModule(claimModuleItem.DoctorId);
            ClaimModule claimModule = (ClaimModule)mmiClaim.Content;
            claimModule.AdmitFlag = false;
            claimModule.Status = "perform";
            claimModule.PerformTime = claimModuleItem.PerformTime;
            claimModule.RegistTime = claimModuleItem.RegistTime;
            claimModule.GwaName = claimModuleItem.GwaName;
            //claimModule.InsuranceUid = "d115f958-44b1-4304-9158-ef77ff4c2414"; // TODO
            claimModule.BundleList = new List<BundleItem>();
            claimModule.AppointList = new List<AppointItem>();
            AppointItem appItem = new AppointItem();
            appItem.Memo = claimModuleItem.ReserMemo;
            claimModule.AppointList.Add(appItem);

            // BundleItem
            foreach (BundleItemInfo bItem in claimModuleItem.BundleListItem)
            {
                BundleItem item = new BundleItem();
                item.ClassCode = bItem.ClassCode;
                //item.ClassName = "ｿﾇﾎﾅﾎﾁ"; // TODO
                item.Code = bItem.HangmogCode;
                item.BundleNumber = bItem.BundleNumber;
                claimModule.BundleList.Add(item);
            }

            // Append to body
            mml.Body.AddModuleItem(mmiClaim);
        }

        #endregion

        private string WriteMmlToString(Mml mml, InterfaceFacade facade)
        {
            string mmlStr = facade.WriteMml23(mml);
            mmlStr = mmlStr.Replace("<mmlFc:Id>", "");
            mmlStr = mmlStr.Replace("</mmlFc:Id>", "");
            mmlStr = mmlStr.Replace("<mmlDp:Id>", "");
            mmlStr = mmlStr.Replace("</mmlDp:Id>", "");

            return mmlStr;
        }

        #endregion
    }
}
