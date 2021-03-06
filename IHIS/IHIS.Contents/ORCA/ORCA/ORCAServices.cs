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
using System.Collections;
using System.Reflection;
using IHIS.Framework;

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
        private PatientModInfo _patientModInfo;

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

        /// <summary>
        /// Booking examination
        /// </summary>
        /// <param name="bookingInfo"></param>
        public ORCAServices(BookingInfo bookingInfo)
        {
            this._bookingInfo = bookingInfo;
        }

        /// <summary>
        /// Transfers orders
        /// </summary>
        /// <param name="ordersInfo"></param>
        public ORCAServices(OrdersInfo ordersInfo)
        {
            this._ordersInfo = ordersInfo;
        }

        /// <summary>
        /// Registers patient
        /// </summary>
        /// <param name="patientModInfo"></param>
        public ORCAServices(PatientModInfo patientModInfo)
        {
            this._patientModInfo = patientModInfo;
        }

        #endregion

        #region Methods (public)

        public void SentBooking(out string msgOutput)
        {

            try
            {
                msgOutput = "";
                string HOST = UserInfo.OrcaIp;
                string PORT = EnvironInfo.ORCAserverInfo.BookingPort;
                string USER = UserInfo.OrcaUser;
                string PASSWD = UserInfo.OrcaPassword;
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
                    req.KeepAlive = false;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SentBooking(out string msgOutput, string orcaIp, string orcaUser, string orcaPwd)
        {

            try
            {
                msgOutput = "";
                string HOST = orcaIp;
                string PORT = EnvironInfo.ORCAserverInfo.BookingPort;
                string USER = orcaUser;
                string PASSWD = orcaPwd;
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
                req.KeepAlive = false;
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
            catch (Exception ex)
            {
                throw ex;
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
                facade.PersonalizedInfo.Department.Id.Text = _ordersInfo.HeaderInfo.DepartmentCode;
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

        public bool SendTCP(string sendingFile, string IPA, Int32 PortN)
        {
            bool result = false;

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

                byte[] buffer = new byte[32];
                // 5s to time out
                netstream.ReadTimeout = 5000;
                int num = netstream.Read(buffer, 0, buffer.Length);
                for (int i = 0; i < num; i++)
                {
                    // Sending file success
                    byte b = buffer[i];
                    if (buffer[i] == 0x06)
                    {
                        result = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.Message);
                throw ex;
            }
            finally
            {
                netstream.Close();
                client.Close();
            }

            return result;
        }

        /// <summary>
        /// Register patient in ORCA
        /// reference: https://www.orca.med.or.jp/receipt/tec/api/patientmod.html
        /// </summary>
        /// <returns></returns>
        public void SendPatientMod(string ORCAIp, string ORCAPort, string ORCAUser, string ORCAPsw, out ArrayList msgLst, out OutPatientInfo outPatientInfo)
        {
            Service.StartWriteLog();
            Service.WriteLog("[SEND PATIENT TO ORCA]");
            Service.WriteLog("[ORCA_IP]: " + ORCAIp);
            Service.WriteLog("[ORCA_PORT]: " + ORCAPort);
            Service.EndWriteLog();

            msgLst = new ArrayList();
            outPatientInfo = new OutPatientInfo();
            string uri = string.Format("http://{0}:{1}/orca12/patientmodv2?class=01", ORCAIp, ORCAPort);
            string xmlStr = CreateMMLForPatientMod(this._patientModInfo);

            byte[] record_in_byte = Encoding.UTF8.GetBytes(xmlStr);

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.KeepAlive = false;
            req.Method = "POST";
            req.ContentType = EnvironInfo.ORCAserverInfo.ContentType;
            req.ContentLength = record_in_byte.Length;
            req.Credentials = new NetworkCredential(ORCAUser, ORCAPsw);
            HttpWebResponse res = null;

            try
            {
                Stream reqstream = req.GetRequestStream();

                reqstream.Write(record_in_byte, 0, record_in_byte.Length);
                reqstream.Close();

                res = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException exc)
            {
                if (exc.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse err = (HttpWebResponse)exc.Response;
                    int errcode = (int)err.StatusCode;
                    err.Close();

                    Service.StartWriteLog();
                    Service.WriteLog("[SEND PATIENT FAILED] - Message: " + exc.Message);
                    Service.EndWriteLog();
                    throw exc;
                }

                Service.StartWriteLog();
                Service.WriteLog("[SEND PATIENT FAILED] - WebExceptionStatus: " + exc.Status.ToString());
                Service.EndWriteLog();
            }
            catch (Exception ex)
            {
                Service.StartWriteLog();
                Service.WriteLog("[SEND PATIENT FAILED] - Message: " + ex.Message);
                Service.WriteLog("[SEND PATIENT FAILED] - StackTrace: " + ex.StackTrace);
                Service.EndWriteLog();

                return;
            }
            finally
            {
                Service.StartWriteLog();
                Service.WriteLog("[SEND PATIENT COMPLETED] - StatusCode: " + res.StatusCode + "(200 is OK)");
                Service.WriteLog("[SEND PATIENT COMPLETED] - StatusDescription: " + res.StatusDescription);
                Service.EndWriteLog();
            }

            if (res != null)
            {
                Stream str = res.GetResponseStream();
                StreamReader strread = new StreamReader(str, new UTF8Encoding());

                try
                {
                    string FOO = strread.ReadToEnd();

                    //Convert string resp to XML get value by tag name
                    XmlDocument respXmlDocument = new XmlDocument();
                    respXmlDocument.LoadXml(FOO);
                    XmlElement root = respXmlDocument.DocumentElement;

                    // Get result message
                    XmlNode selectedNodeCode = root.SelectSingleNode("/xmlio2/patientmodres/Api_Result");
                    XmlNode selectedNodeCodeName = root.SelectSingleNode("/xmlio2/patientmodres/Api_Result_Message");
                    string code = selectedNodeCode.InnerText;
                    string codeName = selectedNodeCodeName.InnerText;
                    msgLst.Add(code);
                    msgLst.Add(codeName);

                    // Get patient info (registered on ORCA successfully)
                    if (code == "00"
                        || code == "K0"
                        || code == "K1"
                        || code == "K2"
                        || code == "K3"
                        || code == "K4")
                    {
                        XmlNode patientNode;
                        patientNode = root.SelectSingleNode("/xmlio2/patientmodres/Patient_Information/Patient_ID");
                        outPatientInfo.Bunho = patientNode != null ? patientNode.InnerText : "";
                        patientNode = root.SelectSingleNode("/xmlio2/patientmodres/Patient_Information/WholeName");
                        outPatientInfo.Suname = patientNode != null ? patientNode.InnerText : "";
                        patientNode = root.SelectSingleNode("/xmlio2/patientmodres/Patient_Information/WholeName_inKana");
                        outPatientInfo.Suname2 = patientNode != null ? patientNode.InnerText : "";
                        patientNode = root.SelectSingleNode("/xmlio2/patientmodres/Patient_Information/BirthDate");
                        outPatientInfo.Birth = patientNode != null ? patientNode.InnerText : "";
                        patientNode = root.SelectSingleNode("/xmlio2/patientmodres/Patient_Information/Sex");
                        outPatientInfo.Sex = patientNode != null ? patientNode.InnerText : "";
                        patientNode = root.SelectSingleNode("/xmlio2/patientmodres/Patient_Information/WholeAddress1");
                        outPatientInfo.Address1 = patientNode != null ? patientNode.InnerText : "";
                        patientNode = root.SelectSingleNode("/xmlio2/patientmodres/Patient_Information/PhoneNumber1");
                        outPatientInfo.Tel = patientNode != null ? patientNode.InnerText : "";
                    }
                }
                catch (Exception ex)
                {
                    Service.WriteLog(MethodBase.GetCurrentMethod().Name + " error: " + ex.Message);
                    Service.WriteLog(MethodBase.GetCurrentMethod().Name + " stacktrace: " + ex.StackTrace);
                }
                finally
                {
                    strread.Close();
                    str.Close();
                    res.Close();
                }
            }
        }

        #endregion

        #region Methods (private)

        #region Create MML for transfering orders (ORDERTRANS) 

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
            try
            {
                // Health insurance module
                MmlModuleItem mmiHi = mml.CreateHealthInsuranceModule(hiModuleInfo.DocId);
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
                for (int i = 0; i < hiModuleInfo.PublicHeathInsuranceItem.Count; i++)
                {
                    PublicInsuranceItem pItem = new PublicInsuranceItem();
                    pItem.Priority = hiModuleInfo.PublicHeathInsuranceItem[i].PriorityNumber;
                    pItem.ProviderName = hiModuleInfo.PublicHeathInsuranceItem[i].ProviderName;
                    pItem.ProviderNumber = hiModuleInfo.PublicHeathInsuranceItem[i].ProviderNumber;
                    pItem.StartDate = hiModuleInfo.PublicHeathInsuranceItem[i].StartDate;
                    pItem.EndDate = hiModuleInfo.PublicHeathInsuranceItem[i].EndDate;
                    hiModuleInsurance.PublicInsuranceList.Add(i, pItem);
                }
                // InsuranceClass
                hiModuleInsurance.InsuranceClass = new InsuranceClass();
                hiModuleInsurance.InsuranceClass.Code = hiModuleInfo.InsuranceCode;
                hiModuleInsurance.InsuranceClass.TableId = "MML0031";

                mml.Body.AddModuleItem(mmiHi);
            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.Message);
            }
        }

        /// <summary>
        /// CreateRegisteredDiagnosisModule
        /// </summary>
        /// <param name="mml"></param>
        /// <param name="rdModule"></param>
        private void CreateRegisteredDiagnosisModule(Mml mml, RegisteredDiagnosisModuleItem rdModuleItem)
        {
            string diagnosisCat = "";
            string mmlTableId = "";

            try
            {
                MmlModuleItem mmiRd = mml.CreateRegisteredDiagnosisModule();
                RegisteredDiagnosisModule regDiagModule = (RegisteredDiagnosisModule)mmiRd.Content;
                regDiagModule.DiagnosisContents = new List<DiagnosisItem>();
                regDiagModule.Categories = new List<Category>();
                regDiagModule.Diagnosis = new Diagnosis();
                regDiagModule.StartDate = rdModuleItem.DiagnosisStartDate;
                //regDiagModule.EndDate = rdModuleItem.DiagnosisEndDate;
                regDiagModule.Diagnosis.Text = "発作性";

                if (rdModuleItem.JusangYn == "Y")
                {
                    regDiagModule.EndDate = rdModuleItem.DiagnosisEndDate;

                    // Diagnosis
                    Diagnosis diagItem = new Diagnosis();
                    diagItem.Code = rdModuleItem.DiagnosisCode;
                    diagItem.System = rdModuleItem.DiagnosisSystem;
                    //diagItem.Text = "";
                    regDiagModule.Diagnosis = diagItem;

                    diagnosisCat = "mainDiagnosis";
                    mmlTableId = "MML0012";
                }
                else
                {
                    regDiagModule.FirstEncounterDate = rdModuleItem.EncounterDate.HasValue ? rdModuleItem.EncounterDate : DateTime.MinValue;

                    //// DiagnosisItem
                    //DiagnosisItem diagItem = new DiagnosisItem();
                    //diagItem.Code = rdModuleItem.DiagnosisCode;
                    //diagItem.System = rdModuleItem.DiagnosisSystem;
                    //regDiagModule.DiagnosisContents.Add(diagItem);

                    // Diagnosis
                    Diagnosis diagItem = new Diagnosis();
                    diagItem.Code = rdModuleItem.DiagnosisCode;
                    diagItem.System = rdModuleItem.DiagnosisSystem;
                    //diagItem.Text = "心房細動";
                    regDiagModule.Diagnosis = diagItem;

                    diagnosisCat = "suspectedDiagnosis";
                    mmlTableId = "MML0015";
                }

                // Category
                Category ctg = new Category();
                //ctg.TableId = rdModuleItem.MmlTableId;
                ctg.TableId = mmlTableId;
                //ctg.Text = rdModuleItem.DiagnosisCategory;
                ctg.Text = diagnosisCat;
                regDiagModule.Categories.Add(ctg);

                // Append to body
                mml.Body.AddModuleItem(mmiRd);
            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.Message);
            }
        }

        /// <summary>
        /// CreateClaimModule
        /// </summary>
        /// <param name="mml"></param>
        /// <param name="claimModuleItem"></param>
        private void CreateClaimModule(Mml mml, ClaimModuleItem claimModuleItem)
        {
            try
            {
                MmlModuleItem mmiClaim = mml.CreateClaimModule(claimModuleItem.DoctorId);
                ClaimModule claimModule = (ClaimModule)mmiClaim.Content;
                claimModule.AdmitFlag = claimModuleItem.AdmitFlg;
                claimModule.Status = "perform";
                claimModule.PerformTime = claimModuleItem.PerformTime;
                claimModule.RegistTime = claimModuleItem.RegistTime;
                claimModule.GwaName = claimModuleItem.GwaName;
                claimModule.InsuranceUid = claimModuleItem.UidCode;
                claimModule.TimeClass = claimModuleItem.TimeClass;
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
                    item.Code = bItem.HangmogCode;
                    item.BundleNumber = bItem.BundleNumber;
                    item.Number = bItem.Number;
                    item.NumberCode = bItem.NumberCode;
                    claimModule.BundleList.Add(item);
                }

                // Append to body
                mml.Body.AddModuleItem(mmiClaim);
            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.Message);
            }
        }

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

        #region Create MML for PatientMod

        /// <summary>
        /// Generates MML for patient mod
        /// Templates:
        /// <data>
        ///         <patientmodreq type="record">
        ///                 <Mod_Key type="string">2</Mod_Key>
        ///                 <Patient_ID type="string">*</Patient_ID>
        ///                 <WholeName type="string">日医　太郎</WholeName>
        ///                 <WholeName_inKana type="string">ニチイ　タロウ</WholeName_inKana>
        ///                 <BirthDate type="string">1970-01-01</BirthDate>
        ///                 <Sex type="string">1</Sex>
        ///                 <HouseHolder_WholeName type="string">日医　太郎</HouseHolder_WholeName>
        ///                 <Relationship type="string">本人</Relationship>
        ///                 <Occupation type="string">会社員</Occupation>
        ///                 <CellularNumber type="string">09011112222</CellularNumber>
        ///                 <FaxNumber type="string">03-0011-2233</FaxNumber>
        ///                 <EmailAddress type="string">test@tt.dot.jp</EmailAddress>
        ///                 <Home_Address_Information type="record">
        ///                         <Address_ZipCode type="string">1130021</Address_ZipCode>
        ///                         <WholeAddress1 type="string">東京都文京区本駒込</WholeAddress1>
        ///                         <WholeAddress2 type="string">６−１６−３</WholeAddress2>
        ///                         <PhoneNumber1 type="string">03-3333-2222</PhoneNumber1>
        ///                         <PhoneNumber2 type="string">03-3333-1133</PhoneNumber2>
        ///                 </Home_Address_Information>
        ///                 <WorkPlace_Information type="record">
        ///                         <WholeName type="string">てすと　株式会社</WholeName>
        ///                         <Address_ZipCode type="string">1130022</Address_ZipCode>
        ///                         <WholeAddress1 type="string">東京都文京区本駒込</WholeAddress1>
        ///                         <WholeAddress2 type="string">５−１２−１１</WholeAddress2>
        ///                         <PhoneNumber type="string">03-3333-2211</PhoneNumber>
        ///                 </WorkPlace_Information>
        ///                 <Contraindication1 type="string">状態</Contraindication1>
        ///                 <Allergy1 type="string">アレルギ</Allergy1>
        ///                 <Infection1 type="string">感染症</Infection1>
        ///                 <Comment1 type="string">コメント</Comment1>
        ///                 <HealthInsurance_Information type="record">
        ///                         <InsuranceProvider_Class type="string">060</InsuranceProvider_Class>
        ///                         <InsuranceProvider_Number type="string">138057</InsuranceProvider_Number>
        ///                         <InsuranceProvider_WholeName type="string">国保</InsuranceProvider_WholeName>
        ///                         <HealthInsuredPerson_Symbol type="string">０１</HealthInsuredPerson_Symbol>
        ///                         <HealthInsuredPerson_Number type="string">１２３４５６７</HealthInsuredPerson_Number>
        ///                         <RelationToInsuredPerson type="string">1</RelationToInsuredPerson>
        ///                         <Certificate_StartDate type="string">2010-05-01</Certificate_StartDate>
        ///                         <PublicInsurance_Information type="array">
        ///                                 <PublicInsurance_Information_child type="record">
        ///                                         <PublicInsurance_Class type="string">010</PublicInsurance_Class>
        ///                                         <PublicInsurance_Name type="string">感３７の２</PublicInsurance_Name>
        ///                                         <PublicInsurer_Number type="string">10131142</PublicInsurer_Number>
        ///                                         <PublicInsuredPerson_Number type="string">1234566</PublicInsuredPerson_Number>
        ///                                         <Certificate_IssuedDate type="string">2010-05-01</Certificate_IssuedDate>
        ///                                 </PublicInsurance_Information_child>
        ///                         </PublicInsurance_Information>
        ///                 </HealthInsurance_Information>
        ///         </patientmodreq>
        /// </data>
        /// References: https://www.orca.med.or.jp/receipt/tec/api/patientmod.html
        /// </summary>
        /// <param name="xml">MML doc</param>
        /// <param name="patientModInfo">Patient info</param>
        /// <returns></returns>
        private string CreateMMLForPatientMod(PatientModInfo patientModInfo)
        {
            XmlDocument xml = new XmlDocument();

            try
            {
                #region Common info.
                XmlElement data = xml.CreateElement("data");
                xml.AppendChild(data);
                XmlElement patientmodreq = xml.CreateElement("patientmodreq");
                patientmodreq.SetAttribute("type", "record");
                data.AppendChild(patientmodreq);

                XmlElement modKey = xml.CreateElement("Mod_Key");
                modKey.SetAttribute("type", "string");
                modKey.InnerText = patientModInfo.Modkey;
                patientmodreq.AppendChild(modKey);

                XmlElement patientID = xml.CreateElement("Patient_ID");
                patientID.SetAttribute("type", "string");
                patientID.InnerText = patientModInfo.PatientID;
                patientmodreq.AppendChild(patientID);

                XmlElement wholeName = xml.CreateElement("WholeName");
                wholeName.SetAttribute("type", "string");
                wholeName.InnerText = patientModInfo.WholeName;
                patientmodreq.AppendChild(wholeName);

                XmlElement wholeNameKana = xml.CreateElement("WholeName_inKana");
                wholeNameKana.SetAttribute("type", "string");
                wholeNameKana.InnerText = patientModInfo.WholeNameKana;
                patientmodreq.AppendChild(wholeNameKana);

                XmlElement birthdate = xml.CreateElement("BirthDate");
                birthdate.SetAttribute("type", "string");
                birthdate.InnerText = patientModInfo.Birthdate;
                patientmodreq.AppendChild(birthdate);

                XmlElement sex = xml.CreateElement("Sex");
                sex.SetAttribute("type", "string");
                sex.InnerText = patientModInfo.Sex;
                patientmodreq.AppendChild(sex);

                XmlElement houseHolderWholeName = xml.CreateElement("HouseHolder_WholeName");
                houseHolderWholeName.SetAttribute("type", "string");
                houseHolderWholeName.InnerText = patientModInfo.HouseHolderWholeName;
                patientmodreq.AppendChild(houseHolderWholeName);

                XmlElement relationship = xml.CreateElement("Relationship");
                relationship.SetAttribute("type", "string");
                relationship.InnerText = patientModInfo.Relationship;
                patientmodreq.AppendChild(relationship);

                XmlElement occupation = xml.CreateElement("Occupation");
                occupation.SetAttribute("type", "string");
                occupation.InnerText = patientModInfo.Occupation;
                patientmodreq.AppendChild(occupation);

                XmlElement cellularNumber = xml.CreateElement("CellularNumber");
                cellularNumber.SetAttribute("type", "string");
                cellularNumber.InnerText = patientModInfo.CellularNumber;
                patientmodreq.AppendChild(cellularNumber);

                XmlElement faxNumber = xml.CreateElement("FaxNumber");
                faxNumber.SetAttribute("type", "string");
                faxNumber.InnerText = patientModInfo.FaxNumber;
                patientmodreq.AppendChild(faxNumber);

                XmlElement emailAddress = xml.CreateElement("EmailAddress");
                emailAddress.SetAttribute("type", "string");
                emailAddress.InnerText = patientModInfo.EmailAddress;
                patientmodreq.AppendChild(emailAddress);
                #endregion

                #region Home_Address_Information
                if (patientModInfo.HomeAddressInfo != null)
                {
                    foreach (HomeAddressInfo item in patientModInfo.HomeAddressInfo)
                    {
                        XmlElement homeAddressInfo = xml.CreateElement("Home_Address_Information");
                        homeAddressInfo.SetAttribute("type", "record");
                        patientmodreq.AppendChild(homeAddressInfo);

                        XmlElement zipCode = xml.CreateElement("Address_ZipCode");
                        zipCode.SetAttribute("type", "string");
                        zipCode.InnerText = item.ZipCode;
                        homeAddressInfo.AppendChild(zipCode);

                        XmlElement wholeAddress1 = xml.CreateElement("WholeAddress1");
                        wholeAddress1.SetAttribute("type", "string");
                        wholeAddress1.InnerText = item.WholeAddress1;
                        homeAddressInfo.AppendChild(wholeAddress1);

                        XmlElement wholeAddress2 = xml.CreateElement("WholeAddress2");
                        wholeAddress2.SetAttribute("type", "string");
                        wholeAddress2.InnerText = item.WholeAddress2;
                        homeAddressInfo.AppendChild(wholeAddress2);

                        XmlElement phoneNumber1 = xml.CreateElement("PhoneNumber1");
                        phoneNumber1.SetAttribute("type", "string");
                        phoneNumber1.InnerText = item.PhoneNumber1;
                        homeAddressInfo.AppendChild(phoneNumber1);

                        XmlElement phoneNumber2 = xml.CreateElement("PhoneNumber2");
                        phoneNumber2.SetAttribute("type", "string");
                        phoneNumber2.InnerText = item.PhoneNumber2;
                        homeAddressInfo.AppendChild(phoneNumber2);
                    }
                }
                #endregion

                #region WorkPlace_Information
                if (patientModInfo.WorkPlaceInfo != null)
                {
                    foreach (WorkPlaceInfo item in patientModInfo.WorkPlaceInfo)
                    {
                        XmlElement workPlaceInfo = xml.CreateElement("WorkPlace_Information");
                        workPlaceInfo.SetAttribute("type", "record");
                        patientmodreq.AppendChild(workPlaceInfo);

                        XmlElement wholeNameNode = xml.CreateElement("WholeName");
                        wholeNameNode.SetAttribute("type", "string");
                        wholeNameNode.InnerText = item.WholeName;
                        workPlaceInfo.AppendChild(wholeNameNode);

                        XmlElement zipCode = xml.CreateElement("Address_ZipCode");
                        zipCode.SetAttribute("type", "string");
                        zipCode.InnerText = item.ZipCode;
                        workPlaceInfo.AppendChild(zipCode);

                        XmlElement wholeAddress1 = xml.CreateElement("WholeAddress1");
                        wholeAddress1.SetAttribute("type", "string");
                        wholeAddress1.InnerText = item.WholeAddress1;
                        workPlaceInfo.AppendChild(wholeAddress1);

                        XmlElement wholeAddress2 = xml.CreateElement("WholeAddress2");
                        wholeAddress2.SetAttribute("type", "string");
                        wholeAddress2.InnerText = item.WholeAddress2;
                        workPlaceInfo.AppendChild(wholeAddress2);

                        XmlElement phoneNumber = xml.CreateElement("PhoneNumber");
                        phoneNumber.SetAttribute("type", "string");
                        phoneNumber.InnerText = item.PhoneNumber;
                        workPlaceInfo.AppendChild(phoneNumber);
                    }
                }
                #endregion

                XmlElement contraindication1 = xml.CreateElement("Contraindication1");
                contraindication1.SetAttribute("type", "string");
                contraindication1.InnerText = patientModInfo.Contraindication1;
                patientmodreq.AppendChild(contraindication1);

                XmlElement allergy1 = xml.CreateElement("Allergy1");
                allergy1.SetAttribute("type", "string");
                allergy1.InnerText = patientModInfo.Allergy1;
                patientmodreq.AppendChild(allergy1);

                XmlElement infection1 = xml.CreateElement("Infection1");
                infection1.SetAttribute("type", "string");
                infection1.InnerText = patientModInfo.Infection1;
                patientmodreq.AppendChild(infection1);

                XmlElement comment1 = xml.CreateElement("Comment1");
                comment1.SetAttribute("type", "string");
                comment1.InnerText = patientModInfo.Comment1;
                patientmodreq.AppendChild(comment1);

                #region HealthInsurance_Information
                if (patientModInfo.InsuranceInfo != null)
                {
                    foreach (InsuranceInfo item in patientModInfo.InsuranceInfo)
                    {
                        XmlElement insInfo = xml.CreateElement("HealthInsurance_Information");
                        insInfo.SetAttribute("type", "record");
                        patientmodreq.AppendChild(insInfo);

                        XmlElement insClass = xml.CreateElement("InsuranceProvider_Class");
                        insClass.SetAttribute("type", "string");
                        insClass.InnerText = item.InsuranceProviderClass;
                        insInfo.AppendChild(insClass);

                        XmlElement insuranceProviderNumber = xml.CreateElement("InsuranceProvider_Number");
                        insuranceProviderNumber.SetAttribute("type", "string");
                        insuranceProviderNumber.InnerText = item.InsuranceProviderNumber;
                        insInfo.AppendChild(insuranceProviderNumber);

                        XmlElement insuranceProviderWholeName = xml.CreateElement("InsuranceProvider_WholeName");
                        insuranceProviderWholeName.SetAttribute("type", "string");
                        insuranceProviderWholeName.InnerText = item.InsuranceProviderWholeName;
                        insInfo.AppendChild(insuranceProviderWholeName);

                        XmlElement healthInsuredPersonSymbol = xml.CreateElement("HealthInsuredPerson_Symbol");
                        healthInsuredPersonSymbol.SetAttribute("type", "string");
                        healthInsuredPersonSymbol.InnerText = item.HealthInsuredPersonSymbol;
                        insInfo.AppendChild(healthInsuredPersonSymbol);

                        XmlElement healthInsuredPersonNumber = xml.CreateElement("HealthInsuredPerson_Number");
                        healthInsuredPersonNumber.SetAttribute("type", "string");
                        healthInsuredPersonNumber.InnerText = item.HealthInsuredPersonNumber;
                        insInfo.AppendChild(healthInsuredPersonNumber);

                        XmlElement relationToInsuredPerson = xml.CreateElement("RelationToInsuredPerson");
                        relationToInsuredPerson.SetAttribute("type", "string");
                        relationToInsuredPerson.InnerText = item.RelationToInsuredPerson;
                        insInfo.AppendChild(relationToInsuredPerson);

                        XmlElement certificateStartDate = xml.CreateElement("Certificate_StartDate");
                        certificateStartDate.SetAttribute("type", "string");
                        certificateStartDate.InnerText = item.CertificateStartDate;
                        insInfo.AppendChild(certificateStartDate);

                        // Public Health insurance
                        if (item.PublicInsuranceInfo != null)
                        {
                            XmlElement publicInsInfo = xml.CreateElement("PublicInsurance_Information");
                            publicInsInfo.SetAttribute("type", "array");
                            insInfo.AppendChild(publicInsInfo);

                            foreach (PublicInsuranceInfo publicItem in item.PublicInsuranceInfo)
                            {
                                XmlElement publicInsInfoChild = xml.CreateElement("PublicInsurance_Information_child");
                                publicInsInfoChild.SetAttribute("type", "record");
                                publicInsInfo.AppendChild(publicInsInfoChild);

                                XmlElement publicInsuranceClass = xml.CreateElement("PublicInsurance_Class");
                                publicInsuranceClass.SetAttribute("type", "string");
                                publicInsuranceClass.InnerText = publicItem.PublicInsuranceClass;
                                publicInsInfoChild.AppendChild(publicInsuranceClass);

                                XmlElement publicInsuranceName = xml.CreateElement("PublicInsurance_Name");
                                publicInsuranceName.SetAttribute("type", "string");
                                publicInsuranceName.InnerText = publicItem.PublicInsuranceName;
                                publicInsInfoChild.AppendChild(publicInsuranceName);

                                XmlElement publicInsurerNumber = xml.CreateElement("PublicInsurer_Number");
                                publicInsurerNumber.SetAttribute("type", "string");
                                publicInsurerNumber.InnerText = publicItem.PublicInsurerNumber;
                                publicInsInfoChild.AppendChild(publicInsurerNumber);

                                XmlElement publicInsuredPersonNumber = xml.CreateElement("PublicInsuredPerson_Number");
                                publicInsuredPersonNumber.SetAttribute("type", "string");
                                publicInsuredPersonNumber.InnerText = publicItem.PublicInsuredPersonNumber;
                                publicInsInfoChild.AppendChild(publicInsuredPersonNumber);

                                XmlElement certificateIssuedDate = xml.CreateElement("Certificate_IssuedDate");
                                certificateIssuedDate.SetAttribute("type", "string");
                                certificateIssuedDate.InnerText = publicItem.CertificateIssuedDate;
                                publicInsInfoChild.AppendChild(certificateIssuedDate);
                            }
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " error: " + ex.Message);
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " stacktrace: " + ex.StackTrace);
            }

            return xml.OuterXml;
        }

        #endregion

        #endregion
    }
}
