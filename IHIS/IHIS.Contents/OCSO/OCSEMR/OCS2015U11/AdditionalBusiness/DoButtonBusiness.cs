using System.Globalization;

namespace EmrDocker
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    using DevExpress.XtraRichEdit;
    using DevExpress.XtraRichEdit.API.Native;
    using DevExpress.XtraRichEdit.API.Native.Implementation;

    using EmrDocker.AdditionalBusiness;
    using EmrDocker.Glossary;
    using EmrDocker.Meta;

    using IHIS.CloudConnector;
    using IHIS.CloudConnector.Caching;
    using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
    using IHIS.CloudConnector.Contracts.Arguments.Ocso;
    using IHIS.CloudConnector.Contracts.Models.OcsEmr;
    using IHIS.CloudConnector.Contracts.Models.Ocso;
    using IHIS.CloudConnector.Contracts.Results;
    using IHIS.CloudConnector.Contracts.Results.OcsEmr;
    using IHIS.CloudConnector.Contracts.Results.Ocso;
    using IHIS.Framework;
    using IHIS.OCSO;
    using IHIS.OCSO.Meta;

    using Newtonsoft.Json;

    /// <summary>
    /// DO button - related logic come here
    /// </summary>
    public static class DoButtonBusiness
    {
        /// <summary>
        /// Query all orders by bunho,doctor,gwa,naewon_date,naewon_key (exam reservation key) at specific examination request in the past.
        /// </summary>
        /// <param name="f_bunho"></param>
        /// <param name="f_doctor"></param>
        /// <param name="f_gwa"></param>
        /// <param name="f_naewon_date"></param>
        /// <param name="f_pkorder">FK bang OUT1001 (ma dat kham/pk_order/naewon_key)</param>
        public static List<OcsoOCS1003Q05OrderListItemInfo> QueryAllOrders(string f_bunho, string f_doctor, string f_gwa, string f_naewon_date, string f_pkorder)
        {
            List<OcsoOCS1003Q05OrderListItemInfo> _orderList = new List<OcsoOCS1003Q05OrderListItemInfo>();

            try
            {
                OCS1003Q09GridOCS1003Args args = new OCS1003Q09GridOCS1003Args();
                args.Bunho = f_bunho;
                args.Doctor = f_doctor;
                args.GenericYn = "N";
                args.Gwa = f_gwa;
                args.InputGubun = "D0";
                args.InputTab = "%";
                args.IoGubun = "O";
                args.JubsuNo = "1";
                args.Kijun = "O";

                string format = "yyyy/MM/dd";
                DateTime dt = DateTime.Parse(f_naewon_date);
                string dateTimeConvert = dt.ToString(format);

                args.NaewonDate = dateTimeConvert;
                args.NaewonType = "O";
                args.PkOrder = f_pkorder;
                args.TelYn = "%";
                OCS1003Q09GridOCS1003Result res =
                    CloudService.Instance.Submit<OCS1003Q09GridOCS1003Result, OCS1003Q09GridOCS1003Args>(args);
                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    _orderList.AddRange(res.RidOcs1003Info);
                }


                _internalOrderList = _orderList;
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error on method QueryAllOrders(): " + ex.StackTrace);
            }

            return _orderList;
        }

        private static string TAG_TABLE_META_CHARACTER = "#TABLE";

        /// <summary>
        /// Generate list DO button based on orders data and update orders grid on the Editor.
        /// </summary>
        /// <param name="inpTable">LayoutTable which contains orders data</param>
        /// <param name="naewon_date"></param>
        /// <param name="naewon_key"></param>
        /// <returns></returns>
        public static List<Image> GenerateDoButtonListFromOrders(DataTable inputTable, string naewon_date, string naewon_key, RichEditControl editor)
        {
            List<Image> result = new List<Image>();
            List<string> depts = new List<string>();
            DataView dv = inputTable.DefaultView;
            dv.Sort = "input_tab asc";
            DataTable inpTable = inputTable.DefaultView.ToTable(false);
            try
            {
                Table table;
                if (inpTable.Rows.Count > 0)
                {
                    editor.BeginUpdate();
                    editor.Document.AppendParagraph();
                    DocumentPosition basePosition = editor.Document.Range.End;
                    table = editor.Document.InsertTable(basePosition, inpTable.Rows.Count, 5);

                    if (table != null
                        && table.Rows.Count == inpTable.Rows.Count)
                    {
                        //editor.RichEditControl.Document.AppendText(TAG_TABLE_META_CHARACTER);

                        Document doc = editor.Document;
                        //doc.BeginUpdate();
                        table.BeginUpdate();

                        //foreach (DataRow row in inpTable.Rows)
                        for (int i = 0; i < inpTable.Rows.Count; i++)
                        {
                            DataRow row = inpTable.Rows[i];

                            if (depts.Contains(row["input_tab"].ToString()))
                            {
                                //column 0
                                doc.InsertText(table.Rows[i].Cells[1].Range.Start, row["input_gubun_name"].ToString());
                                //insert order_gubun_name
                                doc.InsertText(table.Rows[i].Cells[2].Range.Start, row["order_gubun_name"].ToString());
                                //insert hangmog_name
                                doc.InsertText(table.Rows[i].Cells[3].Range.Start, row["hangmog_name"].ToString());
                                //column 3: quantity unit * number of days
                                doc.InsertText(table.Rows[i].Cells[4].Range.Start, row["suryang"].ToString() + row["ord_danui_name"].ToString() + "*" + row["nalsu"].ToString());
                            }

                            
                            if (!depts.Contains(row["input_tab"].ToString()))
                            {
                                Image _originalImage = ((Image) Resources.ResourceManager.GetObject("DO"));

                                byte[] data1 = Encoding.ASCII.GetBytes("DO");
                                PropertyItem meta1 =
                                    (PropertyItem) FormatterServices.GetUninitializedObject(typeof (PropertyItem));
                                meta1.Type = 2;
                                meta1.Id = PROPERTY_1; // <-- Image Description
                                meta1.Len = data1.Length;
                                meta1.Value = data1;
                                _originalImage.SetPropertyItem(meta1);
                                //bunho#doctor#gwa#[naewon_date]#[naewon_key]#pkocs1003#input_tab#order_gubun#
                                byte[] data2 =
                                    Encoding.ASCII.GetBytes(row["bunho"].ToString() + SEPARATOR +
                                                            row["doctor"].ToString() + SEPARATOR + row["gwa"].ToString() +
                                                            SEPARATOR + naewon_date + SEPARATOR + naewon_key + SEPARATOR + row["pkocskey"].ToString() + SEPARATOR + row["input_tab"].ToString() + SEPARATOR + row["order_gubun"] + SEPARATOR);
                                PropertyItem meta2 =
                                    (PropertyItem) FormatterServices.GetUninitializedObject(typeof (PropertyItem));
                                meta2.Type = 2;
                                meta2.Id = PROPERTY_2; // <-- Image Description
                                meta2.Len = data2.Length;
                                meta2.Value = data2;
                                _originalImage.SetPropertyItem(meta2);

                                result.Add(_originalImage);


                                //column 0
                                doc.InsertText(table.Rows[i].Cells[1].Range.Start, row["input_gubun_name"].ToString());
                                //insert order_gubun_name
                                doc.InsertText(table.Rows[i].Cells[2].Range.Start, row["order_gubun_name"].ToString());
                                //insert hangmog_name
                                doc.InsertText(table.Rows[i].Cells[3].Range.Start, row["hangmog_name"].ToString());
                                //column 3: quantity unit * number of days
                                doc.InsertText(table.Rows[i].Cells[4].Range.Start, row["suryang"].ToString() + row["ord_danui_name"].ToString() + "*" + row["nalsu"].ToString());
                                //insert DO button group by order_gubun_name
                                doc.InsertImage(table.Rows[i].Cells[0].Range.Start, new ImageDocumentImageSource(_originalImage));

                                depts.Add(row["input_tab"].ToString());
                            }
                        }

                        table.EndUpdate();
                        doc.EndUpdate();
                    }

                    //editor.RichEditControl.EndUpdate();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                editor.EndUpdate();
            }
            
            editor.Options.TableOptions.GridLines = RichEditTableGridLinesVisibility.Hidden;
            return result;
        }

        private static DataTable orderData;

        private static List<OcsoOCS1003Q05OrderListItemInfo> _internalOrderList;

        private static IMainScreen mainScreen;

        /// <summary>
        /// Call DB to clone order record
        /// </summary>
        /// <param name="_doButtonImage">DO button image</param>
        /// <param name="sender">EmrViewer/EmrEditor</param>
        /// <param name="reason">Failure reason</param>
        /// <returns></returns>
        public static bool CloneOrder(DocumentImage _doButtonImage, object sender, out string reason)
        {
            bool res = false;
            reason = "";

            string _sType = sender.GetType().ToString();

            if (_sType.Contains("EmrViewer"))
            //if(true)
            {
                Image nativeImage = _doButtonImage.Image.NativeImage;
                int[] _idList = nativeImage.PropertyIdList;
                for (int i = 0; i < _idList.Length; i++)
                {
                    if (_idList[i] == PROPERTY_1)
                    {
                        PropertyItem meta1 = nativeImage.GetPropertyItem(PROPERTY_1);
                        if (meta1 != null && meta1.Len > 0)
                        {
                            if (Encoding.ASCII.GetString(meta1.Value).Substring(0,2) == "DO")
                            {
                                PropertyItem meta2 = nativeImage.GetPropertyItem(PROPERTY_2);
                                if (meta2 != null && meta2.Len > 0)
                                {
                                    string temp = Encoding.ASCII.GetString(meta2.Value);
                                    string[] infoStrings = temp.Split(SEPARATOR);
                                    string bunho = "";
                                    string doctor = "";
                                    string gwa = "";
                                    string naewon_date = "";
                                    string naewon_key = "";
                                    string pkocs1003 = "";
                                    string input_tab = "";
                                    string groupSerAndInputab = "";
                                    if (infoStrings.Length >= 7)
                                    {
                                        bunho = infoStrings[0];
                                        doctor = infoStrings[1];
                                        gwa = infoStrings[2];
                                        naewon_date = infoStrings[3];
                                        naewon_key = infoStrings[4];
                                        pkocs1003 = infoStrings[5];
                                        input_tab = infoStrings[6];
                                        groupSerAndInputab = infoStrings[7];
                                    }

                                    //TODO: Clone order from old Pkocs1003 
                                    //Simulate 1003Q09 pass data back to 1003P01

                                    CommonItemCollection commandParam = new CommonItemCollection();
                                    //commandParam.Add("isnewgroup", mIsNewGroupSer);
                                    //MultiLayout dloSelectOCS1003 = FeedLayoutTableToMainScreen();
                                    MultiLayout dloSelectOCS1003 = FeedLayoutTableToMainScreen(bunho, doctor, gwa, naewon_date, naewon_key, input_tab, groupSerAndInputab);
                                    commandParam.Add("OCS1003", dloSelectOCS1003);
                                    commandParam.Add("input_gubun", "D0"); 
                                    MainScreen.Command("OCS1003Q09", commandParam);

                                    //MainScreen.BtnList.PerformClick(FunctionType.Query);

                                    reason = naewon_key;
                                    res = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // if sender is not Viewer, do nothing
                reason = "The parent control is not EmrViewer";
                return false;
            }

            return res;
        }

        public static void DoOrder(string bunho, string doctor, string gwa, string naewon_date, string naewon_key, string input_tab, string groupSerAndInputab)
        {
            CommonItemCollection commandParam = new CommonItemCollection();
            //commandParam.Add("isnewgroup", mIsNewGroupSer);
            //MultiLayout dloSelectOCS1003 = FeedLayoutTableToMainScreen();
            MultiLayout dloSelectOCS1003 = FeedLayoutTableToMainScreen(bunho, doctor, gwa, naewon_date, naewon_key, input_tab, groupSerAndInputab);
            commandParam.Add("OCS1003", dloSelectOCS1003);
            commandParam.Add("input_gubun", "D0");
            MainScreen.Command("OCS1003Q09", commandParam);
        }     
        /// <summary>
        /// Simulate data returned from OCS1003Q09 screen
        /// </summary>
        /// <param name="bunho"></param>
        /// <param name="doctor"></param>
        /// <param name="gwa"></param>
        /// <param name="naewon_date"></param>
        /// <param name="naewon_key"></param>
        /// <param name="filter">Filter condition</param>
        /// <returns></returns>
        public static MultiLayout FeedLayoutTableToMainScreen(string bunho, string doctor, string gwa, string naewon_date, string naewon_key, string filter, string groupSerAndInputab)
        {
            string groupSer = "";
            MultiLayout multiLayout = new MultiLayout();            
            DataTable _dt = multiLayout.LayoutTable;

            _internalOrderList = QueryAllOrders(bunho, doctor, gwa, naewon_date, naewon_key);
            string[] words = groupSerAndInputab.Split('-');
            groupSer = words[1];

            if (_internalOrderList != null
                && _internalOrderList.Count > 0)
            {
                IList<object[]> lstObjects = GridOCS1003_ConvertToListObj(_internalOrderList);
                string[] colHeaders = COLUMN_HEADERS.Split(',');

                for (int i = 0; i < colHeaders.Length; i++)
                {
                    _dt.Columns.Add(colHeaders[i], typeof (string));
                }
                foreach (object[] obj in lstObjects)
                {
                    //if (obj[32].ToString() + "-" + obj[1].ToString() == filter) // OcsoOCS1003Q05OrderListItemInfo.InputTab
                    if (obj[32].ToString() == filter && obj[1].ToString() == groupSer) // OcsoOCS1003Q05OrderListItemInfo.InputTab
                    {
                        DataRow dr = _dt.NewRow();
                        for (int i = 0; i < obj.Length; i++)
                        {
                            dr[i] = obj[i];
                        }
                        _dt.Rows.Add(dr);
                        //break;
                    }
                } 
            }
            return multiLayout;
        }

        private static IList<object[]> GridOCS1003_ConvertToListObj(List<OcsoOCS1003Q05OrderListItemInfo> lstDataForOcs1003)
        {
            IList<object[]> lstObjs = new List<object[]>();
            if (lstDataForOcs1003 != null && lstDataForOcs1003.Count > 0)
            {
                foreach (OcsoOCS1003Q05OrderListItemInfo ocs1003Info in lstDataForOcs1003)
                {
                    lstObjs.Add(new object[]
                    {
                        ocs1003Info.InputGubunName,
                        ocs1003Info.GroupSer,
                        ocs1003Info.OrderGubunName,
                        ocs1003Info.HangmogCode,
                        ocs1003Info.HangmogName,
                        ocs1003Info.SpecimenCode,
                        ocs1003Info.SpecimenName,
                        ocs1003Info.Suryang,
                        ocs1003Info.OrdDanui,
                        ocs1003Info.OrdDanuiName,
                        ocs1003Info.DvTime,
                        ocs1003Info.Dv,
                        ocs1003Info.Nalsu,
                        ocs1003Info.Jusa,
                        ocs1003Info.JusaName,
                        ocs1003Info.BogyongCode,
                        ocs1003Info.BogyongName,
                        ocs1003Info.JusaSpdGubun,
                        ocs1003Info.HubalChangeYn,
                        ocs1003Info.Pharmacy,
                        ocs1003Info.DrgPackYn,
                        ocs1003Info.PowderYn,
                        ocs1003Info.WonyoiOrderYn,
                        ocs1003Info.DangilGumsaOrderYn,
                        ocs1003Info.DangilGumsaResultYn,
                        ocs1003Info.Emergency,
                        ocs1003Info.Pay,
                        ocs1003Info.AntiCancerYn,
                        ocs1003Info.Muhyo,
                        ocs1003Info.PortableYn,
                        ocs1003Info.OcsFlag,
                        ocs1003Info.OrderGubun,
                        ocs1003Info.InputTab,
                        ocs1003Info.InputGubun,
                        ocs1003Info.AfterActYn,
                        ocs1003Info.JundalTable,
                        ocs1003Info.JundalPart,
                        ocs1003Info.MovePart,
                        ocs1003Info.Bunho,
                        ocs1003Info.OrderDate,
                        ocs1003Info.Gwa,
                        ocs1003Info.Doctor,
                        ocs1003Info.NaewonType,
                        ocs1003Info.PkOrder,
                        ocs1003Info.Seq,
                        ocs1003Info.Pkocs1003,
                        ocs1003Info.SubSusul,
                        ocs1003Info.SutakYn,
                        ocs1003Info.Amt,
                        ocs1003Info.Dv1,
                        ocs1003Info.Dv2,
                        ocs1003Info.Dv3,
                        ocs1003Info.Dv4,
                        ocs1003Info.HopeDate,
                        ocs1003Info.OrderRemark,
                        ocs1003Info.MixGroup,
                        ocs1003Info.HomeCareYn,
                        ocs1003Info.RegularYn,
                        ocs1003Info.GongbiCode,
                        ocs1003Info.GongbiName,
                        ocs1003Info.DonbokYn,
                        ocs1003Info.DvName,
                        ocs1003Info.SlipCode,
                        ocs1003Info.GroupYn,
                        ocs1003Info.SgCode,
                        ocs1003Info.OrderGubunBas,
                        ocs1003Info.InputControl,
                        ocs1003Info.SugaYn,
                        ocs1003Info.EmergencyCheck,
                        ocs1003Info.LimitSuryang,
                        ocs1003Info.SpecimenYn,
                        ocs1003Info.JaeryoYn,
                        ocs1003Info.OrdDanuiCheck,
                        ocs1003Info.OrdDanuiBas,
                        ocs1003Info.JundalTableOut,
                        ocs1003Info.JundalPartOut,
                        ocs1003Info.MovePartOut,
                        ocs1003Info.JundalTableInp,
                        ocs1003Info.JundalPartInp,
                        ocs1003Info.MovePartInp,
                        ocs1003Info.BulyongCheck,
                        ocs1003Info.WonyoiOrderCrYn,
                        ocs1003Info.DefaultWonyoiOrderYn,
                        ocs1003Info.NdayYn,
                        ocs1003Info.MuhyoYn,
                        ocs1003Info.TelYn,
                        ocs1003Info.DrgInfo,
                        ocs1003Info.DrgBunryu,
                        ocs1003Info.ChildYn,
                        ocs1003Info.BomSourceKey,
                        ocs1003Info.BomOccurYn,
                        ocs1003Info.OrgKey,
                        ocs1003Info.ParentKey,
                        ocs1003Info.BunCode,
                        ocs1003Info.ContKey,
                        ocs1003Info.Fkout1001,
                        ocs1003Info.WonnaeDrgYn,
                        ocs1003Info.DcYn,
                        ocs1003Info.ResultDate,
                        ocs1003Info.ConfirmCheck,
                        ocs1003Info.SunabCheck,
                        ocs1003Info.Dv5,
                        ocs1003Info.Dv6,
                        ocs1003Info.Dv7,
                        ocs1003Info.Dv8,
                        ocs1003Info.GeneralDispYn,
                        ocs1003Info.GenericName,
                        ocs1003Info.State,
                        ocs1003Info.BogyongCodeSub,
                        ocs1003Info.BogyongNameSub,
                        ocs1003Info.OriHopeDate,
                        ocs1003Info.IoYn,
                        ocs1003Info.BroughtDrgYn
                    });
                }
            }
            return lstObjs;
        }

        /// <summary>
        /// Generate new DO button, embed metadata to image
        /// </summary>
        /// <param name="pkocs1003">naewon_key</param>
        /// <returns></returns>
        public static Image GenerateDoButton(string pkocs1003)
        {

            Image _originalImage = ((Image)Resources.ResourceManager.GetObject("DO"));

            byte[] data1 = Encoding.ASCII.GetBytes("DO");
            PropertyItem meta1 = (PropertyItem)FormatterServices.GetUninitializedObject(typeof(PropertyItem));
            meta1.Type = 2;
            meta1.Id = PROPERTY_1; // <-- Image Description
            meta1.Len = data1.Length;
            meta1.Value = data1;
            _originalImage.SetPropertyItem(meta1);

            byte[] data2 = Encoding.ASCII.GetBytes(pkocs1003 + SEPARATOR);
            PropertyItem meta2 = (PropertyItem)FormatterServices.GetUninitializedObject(typeof(PropertyItem));
            meta2.Type = 2;
            meta2.Id = PROPERTY_2; // <-- Image Description
            meta2.Len = data2.Length;
            meta2.Value = data2;
            _originalImage.SetPropertyItem(meta2);

            //_originalImage.Save(@"C:\Users\nextopasia\Pictures\Temp\" + pkocs1003 + ".jpg", _originalImage.RawFormat);

            return _originalImage;
        }

        /// <summary>
        /// Get pkocs1003 from image DO button. Metadata format f_bunho#f_doctor#f_gwa#f_naewon_date#f_pkorder
        /// </summary>
        /// <param name="input">Native image of DocumentImage object</param>
        /// <returns>pkocs1003</returns>
        public static string GetMetaFromDoButton(Image input)
        {
            try
            {
                PropertyItem meta = input.GetPropertyItem(PROPERTY_2);
                return Encoding.ASCII.GetString(meta.Value);
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// Parse returned string from GetMetaFromDoButton method into key value pair object. Metadata format f_bunho#f_doctor#f_gwa#f_naewon_date#f_pkorder
        /// </summary>
        /// <param name="input">string result from GetMetaFromDoButton</param>
        /// <returns></returns>
        public static Dictionary<string, string> ParseMetaFromDoButton(string input)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string[] values = input.Split(SEPARATOR);
            for (int i = 0; i < values.Length; i++)
            {
                if (!result.ContainsKey("f_bunho"))
                {
                    result.Add("f_bunho", values[i]);
                    continue;
                }
                if (!result.ContainsKey("f_doctor"))
                {
                    result.Add("f_doctor", values[i]);
                    continue;
                }
                if (!result.ContainsKey("f_gwa"))
                {
                    result.Add("f_gwa", values[i]);
                    continue;
                }
                if (!result.ContainsKey("f_naewon_date"))
                {
                    result.Add("f_naewon_date", values[i]);
                    continue;
                }
                if (!result.ContainsKey("f_pkorder"))
                {
                    result.Add("f_pkorder", values[i]);
                    continue;
                }
            }
            return result;
        }

        /// <summary>
        /// Make document in Editor editable except DO button region
        /// </summary>
        /// <param name="editControl"></param>
        /// <param name="userName">User name who is editing document</param>
        /// <param name="doButtonList">List of DO button's position</param>
        public static void MakeDoRegionUneditable(RichEditControl editControl, string userName, List<DocumentRange> doButtonList)
        {
            editControl.Options.Authentication.UserName = userName; // set document editable with this user
            RangePermissionCollection disRangeList = editControl.Document.BeginUpdateRangePermissions();
            TableCollection doTables = editControl.Document.Tables;
            foreach (Table doTable in doTables)
            {
                foreach (DocumentRange doButtonRange in doButtonList)
                {
                    if (doTable.Range.Contains(doButtonRange.Start))
                    {
                        RangePermission disabledPermission = new RangePermission(doTable.Range);
                        disabledPermission.UserName = ""; // nobody can edit this range
                        disRangeList.Add(disabledPermission);
                        break;
                    }
                }
            }
            editControl.Document.EndUpdateRangePermissions(disRangeList);
        }

        /// <summary>
        /// Get list of DO button document range
        /// </summary>
        /// <param name="editControl"></param>
        /// <returns>List of document range of DO buttons</returns>
        public static List<DocumentRange> GetDoButtonRangeList(RichEditControl editControl)
        {
            List<DocumentRange> doButtonList = new List<DocumentRange>();
            DocumentImageCollection images = editControl.Document.GetImages(editControl.Document.Range);
            foreach (DocumentImage image in images)
            {
                Image nativeImage = image.Image.NativeImage;
                PropertyItem meta1 = nativeImage.GetPropertyItem(PROPERTY_1);
                if (meta1 != null
                    && meta1.Len > 0)
                {
                    if (Encoding.ASCII.GetString(meta1.Value) == "DO")
                    {
                        doButtonList.Add(image.Range);
                    }
                }
            }

            return doButtonList;
        }

        /// <summary>
        /// Check if an document image is DO button
        /// </summary>
        /// <param name="docImage"></param>
        /// <returns>True if DO, false if other</returns>
        public static bool CheckIfNonDolImage(DocumentImage docImage)
        {
            Image nativeImage = docImage.Image.NativeImage;

            return CheckDoButtonImage(nativeImage);
        }

        /// <summary>
        /// Iterate through all items of PropertyIdList to find DO metadata
        /// </summary>
        /// <param name="nativeImage"></param>
        /// <returns></returns>
        private static bool CheckDoButtonImage(Image nativeImage)
        {
            bool ok = false;

            int[] _idList = nativeImage.PropertyIdList;

            for (int i = 0; i < _idList.Length; i++)
            {
                if (_idList[i] == PROPERTY_1)
                {
                    PropertyItem meta1 = nativeImage.GetPropertyItem(PROPERTY_1);
                    if (meta1 != null
                        && meta1.Len > 0)
                    {
                        if (Encoding.ASCII.GetString(meta1.Value).Substring(0,2) == "DO")
                        {
                            ok = true;

                            break;
                        }
                    }
                } 
            }

            return ok;
        }

        /// <summary>
        /// Check if an ImageMeta is DO button
        /// </summary>
        /// <param name="docImage"></param>
        /// <returns></returns>
        public static bool CheckIfNonDolImage(ImageMeta docImage)
        {
            try
            {
                Image nativeImage = Image.FromFile(docImage.FilePath);

                return CheckDoButtonImage(nativeImage);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// Enable document except DO region
        /// </summary>
        /// <param name="control">RichEditControl</param>
        /// <param name="userName">Username who currently log in</param>
        public static void DisableDoRegion(RichEditControl control, string userName)
        {
            RangePermissionCollection permissionList = control.Document.BeginUpdateRangePermissions();
            permissionList.Clear();
            DocumentImageCollection images = control.Document.GetImages(control.Document.Range);
            TableCollection tables = control.Document.Tables;

            List<Table> sortedTablesList = SortTableRegions(tables);

            //RangePermission docPermission = new RangePermission(control.Document.Range);
            //docPermission.UserName = userName;
            //permissionList.Add(docPermission);

            // Disable DO-table range
            for(int i=0; i<sortedTablesList.Count; i++)
            {
                Table table = sortedTablesList[i];

                foreach (DocumentImage documentImage in images)
                {
                    if (CheckIfNonDolImage(documentImage))
                    {
                        if (table.Range.Contains(documentImage.Range.Start))
                        {
                            RangePermission doPermission = new RangePermission(table.Range);
                            doPermission.UserName = "SUPERUSER";
                            permissionList.Add(doPermission);

                            break;
                        }
                    }
                }
            }

            RangePermissionCollection enablePermissionCollection = new RangePermissionCollection();
            for (int i = 0; i < permissionList.Count; i++)
            {
                if (i == 0 && (permissionList.Count > 1))
                {
                    DocumentPosition start = control.Document.CreatePosition(control.Document.Range.Start.ToInt());
                    //int length = permissionList[i].Range.Start.ToInt() - control.Document.Range.Start.ToInt() - 1;
                    int length = GetLength(permissionList[i].Range.Start, control.Document.Range.Start);
                    DocumentRange documentRange = control.Document.CreateRange(start, length);
                    RangePermission enablePermission = new RangePermission(documentRange);
                    enablePermission.UserName = userName;
                    enablePermissionCollection.Add(enablePermission);
                }
                else if (i == 0 && (permissionList.Count == 1)) // case when there is only one DO-table
                {
                    DocumentPosition start = control.Document.CreatePosition(control.Document.Range.Start.ToInt());
                    //int length = permissionList[i].Range.Start.ToInt() - control.Document.Range.Start.ToInt() - 1;
                    int length = GetLength(permissionList[i].Range.Start, control.Document.Range.Start);
                    DocumentRange documentRange = control.Document.CreateRange(start, length);
                    RangePermission enablePermission = new RangePermission(documentRange);
                    enablePermission.UserName = userName;
                    enablePermissionCollection.Add(enablePermission);

                    if ((control.Document.Range.End.ToInt() - permissionList[permissionList.Count - 1].Range.End.ToInt()) > 0)
                    {
                        DocumentPosition start2 = control.Document.CreatePosition(permissionList[i].Range.End.ToInt() + 1);
                        int length2 = control.Document.Range.End.ToInt() -
                                      permissionList[permissionList.Count - 1].Range.End.ToInt();
                        DocumentRange documentRange2 = control.Document.CreateRange(start2, length2);
                        RangePermission enablePermission2 = new RangePermission(documentRange2);
                        enablePermission2.UserName = userName;
                        enablePermissionCollection.Add(enablePermission2); 
                    }
                }
                else if ((i > 0) && (i == (permissionList.Count - 1)))
                {
                    if ((control.Document.Range.End.ToInt() - permissionList[permissionList.Count - 1].Range.End.ToInt()) > 0)
                    {
                        DocumentPosition start = control.Document.CreatePosition(control.Document.Range.End.ToInt() + 1);
                        int length = control.Document.Range.End.ToInt() - permissionList[i].Range.End.ToInt();
                        DocumentRange documentRange = control.Document.CreateRange(start, length);
                        RangePermission enablePermission = new RangePermission(documentRange);
                        enablePermission.UserName = userName;
                        enablePermissionCollection.Add(enablePermission); 
                    }
                }
                else
                {
                    DocumentPosition start = control.Document.CreatePosition(permissionList[i - 1].Range.End.ToInt() + 1);
                    int length = permissionList[i].Range.Start.ToInt() - permissionList[i - 1].Range.Start.ToInt() - 1;
                    DocumentRange documentRange = control.Document.CreateRange(start, length);
                    RangePermission enablePermission = new RangePermission(documentRange);
                    enablePermission.UserName = userName;
                    enablePermissionCollection.Add(enablePermission); 
                }
            }
            permissionList.AddRange(enablePermissionCollection);


            control.Document.EndUpdateRangePermissions(permissionList);
            control.Document.Protect("123");
            control.Options.Authentication.UserName = userName;
        }

        /// <summary>
        /// Calculate length between two range, except start and end of the range object
        /// </summary>
        /// <param name="end"></param>
        /// <param name="begin"></param>
        /// <returns></returns>
        private static int GetLength(DocumentPosition end, DocumentPosition begin)
        {
            return (end.ToInt() - begin.ToInt() - 1 > 0) ? (end.ToInt() - begin.ToInt() - 1) : 0;
        }

        /// <summary>
        /// Remove all permissions before saving
        /// </summary>
        /// <param name="control"></param>
        public static void RemoveAllPermissions(RichEditControl control)
        {
            RangePermissionCollection permissions = control.Document.BeginUpdateRangePermissions();
            permissions.Clear();
            control.Document.EndUpdateRangePermissions(permissions);
            control.Document.Unprotect();
        }

        /// <summary>
        /// Custom comparer to sort ascending Table list based on Start position
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private static int CompareTableByStartPosition(Table p1, Table p2)
        {
            return p1.Range.Start.ToInt().CompareTo(p2.Range.Start.ToInt());
        }

        /// <summary>
        /// Sorting table collection based on start position
        /// </summary>
        /// <param name="tables"></param>
        /// <returns></returns>
        private static List<Table> SortTableRegions(TableCollection tables)
        {
            List<Table> sortedTablesList = new List<Table>();
            sortedTablesList.AddRange(tables);
            sortedTablesList.Sort(CompareTableByStartPosition);

            return sortedTablesList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inpTable"></param>
        /// <param name="naewon_date"></param>
        /// <param name="naewon_key"></param>
        /// <param name="editor"></param>
        public static void SynchDoDataAfterReload(DataTable inpTable, string naewon_date, string naewon_key, RichEditControl editor)
        {
            RemoveDoRegionWhenReload(editor);
            GenerateDoButtonListFromOrders(inpTable,
                naewon_date, naewon_key,
                editor);

        }

        /// <summary>
        /// Find DO tables in cached document then remove them.
        /// </summary>
        /// <param name="control"></param>
        private static void RemoveDoRegionWhenReload(RichEditControl control)
        {
            TableCollection tables = control.Document.Tables;
            DocumentImageCollection images = control.Document.GetImages(control.Document.Range);
            List<Table> removeTables  =new List<Table>();
            List<DocumentImage> doImages = new List<DocumentImage>();

            foreach (DocumentImage image in images)
            {
                if (CheckIfNonDolImage(image))
                {
                    doImages.Add(image);
                }
            }

            control.Document.BeginUpdate();
            foreach (Table table in tables)
            {
                foreach (DocumentImage doButton in doImages)
                {
                    if (table.Range.Contains(doButton.Range.Start))
                    {
                        removeTables.Add(table);
                        break;
                    }
                }
            }
            foreach (Table table in removeTables)
            {
                control.Document.Tables.Remove(table); 
            }
            control.Document.EndUpdate();
        }

        private static readonly int PROPERTY_1 = 0x0110;  // DO
        private static readonly int PROPERTY_2 = 0x010E;  // metadata
        private static readonly char SEPARATOR = '#';
        private static readonly string COLUMN_HEADERS = "input_gubun_name,group_ser,order_gubun_name,hangmog_code,hangmog_name,specimen_code,specimen_name,suryang,ord_danui,ord_danui_name,dv_time,dv,nalsu,jusa,jusa_name,bogyong_code,bogyong_name,jusa_spd_gubun,hubal_change_yn,pharmacy,drg_pack_yn,powder_yn,wonyoi_order_yn,dangil_gumsa_order_yn,dangil_gumsa_result_yn,emergency,pay,anti_cancer_yn,muhyo,portable_yn,ocs_flag,order_gubun,input_tab,input_gubun,after_act_yn,jundal_table,jundal_part,move_part,bunho,naewon_date,gwa,doctor,naewon_type,pk_order,seq,pkocs1003,sub_susul,sutak_yn,amt,dv_1,dv_2,dv_3,dv_4,hope_date,order_remark,mix_group,home_care_yn,regular_yn,gongbi_code,gongbi_name,donbog_yn,dv_name,slip_code,group_yn,sg_code,order_gubun_bas,input_control,suga_yn,emergency_check,limit_suryang,specimen_yn,jaeryo_yn,ord_danui_check,ord_danui_bas,jundal_table_out,jundal_part_out,move_part_out,jundal_table_inp,jundal_part_inp,move_part_inp,bulyong_check,wonyoi_order_cr_yn,default_wonyoi_order_yn,nday_yn,muhyo_yn,tel_yn,drg_info,drg_bunryu,child_yn,bom_source_key,bom_occur_yn,org_key,parent_key,bun_code,cont_key,fk_key1001,wonnae_drg_yn,dc_yn,result_date,confirm_check,sunab_check,dv_5,dv_6,dv_7,dv_8,general_disp_yn,generic_name,select,bogyong_code_sub,bogyong_name_sub,ori_hope_date,io_yn,brought_drg_yn,object_id,executive_mode,input_id,input_part,input_gwa,ioe_gubun,naewon_key,order_date,gubun,weight";

        public static IMainScreen MainScreen
        {
            get { return mainScreen; }
            set { mainScreen = value; }
        }

        public static DataTable OrderData
        {
            get { return orderData; }
            set { orderData = value; }
        }


        /// <summary>
        /// Filter DO orders by gubun. This method check metadata in DO button to show/hide orders.
        /// </summary>
        /// <param name="emrViewer">EMR viewer</param>
        /// <param name="orderGubun">DO order gubun</param>
        public static void FilterOrderByGubun(RichEditControl emrViewer, string orderGubun)
        {
            TableCollection tables = emrViewer.Document.Tables;
            DocumentImageCollection images = emrViewer.Document.GetImages(emrViewer.Document.Range);
            List<Table> doTables = GetDoTables(tables, images);
            List<DocumentImage> doImages = GetDoImages(emrViewer);
            ShowHideDoTableByGubun(emrViewer.Document, doTables, doImages, orderGubun);
        }

        /// <summary>
        /// Get list of DO button images
        /// </summary>
        /// <param name="emrViewer"></param>
        /// <returns></returns>
        private static List<DocumentImage> GetDoImages(RichEditControl emrViewer)
        {
            List<DocumentImage> doImages = new List<DocumentImage>();
            foreach (DocumentImage image in emrViewer.Document.GetImages(emrViewer.Document.Range))
            {
                if (CheckIfNonDolImage(image))
                {
                    doImages.Add(image);
                }
            }
            return doImages;
        }

        /// <summary>
        /// Get DO image button metadata, compare with orderGubun parameter to show/hide
        /// </summary>
        /// <param name="document">EMR document</param>
        /// <param name="doTables"></param>
        /// <param name="doImages"></param>
        /// <param name="orderGubun">Order gubun</param>
        private static void ShowHideDoTableByGubun(Document document, List<Table> doTables, List<DocumentImage> doImages, string orderGubun)
        {
            bool previousValid = false;
            foreach (Table table in doTables)
            {
                table.ForEachRow(delegate(TableRow row, int rowIndex)
                {
                    foreach (DocumentImage doImg in doImages)
                    {
                        if (row.Range.Contains(doImg.Range.Start))
                        {
                            int[] _idList = doImg.Image.NativeImage.PropertyIdList;

                            for (int i = 0; i < _idList.Length; i++)
                            {
                                if (_idList[i] == PROPERTY_2)
                                {
                                    PropertyItem meta2 = doImg.Image.NativeImage.GetPropertyItem(PROPERTY_2);
                                    if (meta2 != null
                                        && meta2.Len > 0)
                                    {
                                        string strMeta = Encoding.ASCII.GetString(meta2.Value);
                                        string[] metadata = strMeta.Split(SEPARATOR);
                                        string _orderGubun = "";
                                        if (metadata.Length >= 8)
                                        {
                                            _orderGubun = metadata[7];
                                        }
                                        previousValid = _orderGubun == orderGubun;                                        
                                    }
                                }
                            }
                        }
                    }

                    DocumentRange range = row.Range;
                    CharacterProperties cp = document.BeginUpdateCharacters(range);
                    cp.Hidden = !previousValid;
                    document.EndUpdateCharacters(cp);
                });
            }
        }


        /// <summary>
        /// Get list of DO tables.
        /// </summary>
        /// <param name="tables"></param>
        /// <param name="images"></param>
        /// <returns></returns>
        private static List<Table> GetDoTables(TableCollection tables, DocumentImageCollection images)
        {
            List<Table> doTables = new List<Table>();
            foreach (Table table in tables)
            {
                if (CheckDoTable(table, images))
                {
                    doTables.Add(table);
                }
            }
            return doTables;
        }

        /// <summary>
        /// Check if a table is DO table or not
        /// </summary>
        /// <param name="table"></param>
        /// <param name="images"></param>
        /// <returns></returns>
        public static bool CheckDoTable(Table table, DocumentImageCollection images)
        {
            bool isDoTable = false;
            foreach (DocumentImage image in images)
            {
                if (CheckIfNonDolImage(image))
                {
                    if (table.Range.Contains(image.Range.Start))
                    {
                        isDoTable = true;
                        break;
                    }
                }
            }

            return isDoTable;
        }
    }

    /// <summary>
    /// Additional logics of OCS2015U09 come here
    /// </summary>
    public static class OCS2015U09Businesses
    {

        /// <summary>
        /// Get Template list from DB
        /// </summary>
        public static void QueryTemplateList()
        {
            _templateList.Clear();
            List<TemplateMeta> tmp = new List<TemplateMeta>(); // result will be stored in this List<>
            //TODO: query DB
            OCS2015U09GetTemplateComboBoxArgs args = new OCS2015U09GetTemplateComboBoxArgs();
            args.UserId = UserInfo.UserID;
            OCS2015U09GetTemplateComboBoxResult res =
                CloudService.Instance.Submit<OCS2015U09GetTemplateComboBoxResult, OCS2015U09GetTemplateComboBoxArgs>(
                    args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                _tagDictionary.Clear();
                try
                {
                    foreach (OCS2015U09GetTemplateComboBoxInfo comboBoxInfo in res.TemplateList)
                    {
                        TemplateMeta template = new TemplateMeta();
                        template.Description = comboBoxInfo.Description;
                        template.EmrTemplateId = comboBoxInfo.EmrTemplateId;
                        template.EmrTemplateTypeId = comboBoxInfo.EmrTemplateTypeId;
                        template.PermissionType = comboBoxInfo.PermissionType;
                        template.SysId = comboBoxInfo.SysId;
                        template.TemplateContent = comboBoxInfo.TemplateContent;
                        template.TemplateCode = comboBoxInfo.TemplateCode;
                        template.TemplateName = comboBoxInfo.TemplateName;
                        template.UpdId = comboBoxInfo.UpdId;
                        foreach (OCS2015U31EmrTagGetTemplateTagsInfo tagInfo in comboBoxInfo.Tags)
                        {
                            template.TagList[tagInfo.TagCode] = tagInfo.TagDisplayText;

                            if (!_tagDictionary.ContainsKey(tagInfo.TagCode))
                            {
                                _tagDictionary.Add(tagInfo.TagCode, tagInfo.TagDisplayText);
                            }
                            else
                            {
                                _tagDictionary[tagInfo.TagCode] = tagInfo.TagDisplayText;
                            }
                        }


                        tmp.Add(template);
                    }

                    if (tmp.Count > 0)
                    {
                        _templateList.AddRange(tmp);
                    }
                    //GetTagsInEachTemplate();
                }
                catch (Exception ex)
                {
                    
                    throw;
                }
            }
        }

        private static List<TemplateMeta> _templateList = new List<TemplateMeta>();

        /// <summary>
        /// public private _templateList member to outside world
        /// </summary>
        /// <returns>_templateList</returns>
        public static List<TemplateMeta> GetTemplateList()
        {
            return _templateList;
        }

        public static void SetTemplateListToCache()
        {
            foreach (TemplateMeta template in _templateList)
            {
                CacheService.Instance.Set("OCS2015U09GetTemplateComboBox" + template.EmrTemplateId, TransformTemplateToXml(template), TimeSpan.MaxValue); 
            }
        }

        /// <summary>
        /// Convert each TemplateMeta into Xml document
        /// </summary>
        /// <param name="template">TemplateMeta</param>
        /// <returns>XmlDocument</returns>
        public static XmlDocument TransformTemplateToXml(TemplateMeta template)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(template.GetType());
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, template);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                return xmlDoc;
            }
        }

        /// <summary>
        /// Convert List TemplateMeta into List Xml document. This list will be stored later as an object inside client cache.
        /// </summary>
        /// <param name="templateList"></param>
        /// <returns></returns>
        public static List<XmlDocument> TransformTemplateListToXml(List<TemplateMeta> templateList)
        {
            List<XmlDocument> xmlDocList = new List<XmlDocument>();
            foreach (TemplateMeta templateMeta in templateList)
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlSerializer xmlSerializer = new XmlSerializer(templateMeta.GetType());
                using (MemoryStream xmlStream = new MemoryStream())
                {
                    xmlSerializer.Serialize(xmlStream, templateMeta);
                    xmlStream.Position = 0;
                    xmlDoc.Load(xmlStream);
                    xmlDocList.Add(xmlDoc);
                }
            }

            return xmlDocList;
        }

        /// <summary>
        /// Put list XmlDocument to client cache
        /// </summary>
        /// <param name="xmlList"></param>
        public static void SetTemplateListToCache(List<XmlDocument> xmlList)
        {

        }

        /// <summary>
        /// Apply template into EMR editor when combobox changes
        /// </summary>
        /// <param name="editor">Reference to EMR editor</param>
        /// <param name="templateObj">Template obj which stored in client cache</param>
        public static void ApplyTemplate(EmrEditor editor, object templateObj)
        {

        }


        internal static Dictionary<string, string> _tagDictionary = new Dictionary<string, string>();

        static readonly string START_TAG_META_CHARACTER = "#";
        static readonly string END_TAG_META_CHARACTER = "\t[";
        static readonly string END_TAG_DISPLAY_META_CHARACTER = "]:";
        static readonly string STOP_TAG_META_CHARACTER = "#"; // stop character to indicate a tag finishes

        /// <summary>
        /// Parsing cached EMR_RECORD file to get values for tags
        /// </summary>
        /// <param name="oldTemplate"></param>
        /// <param name="currentTemplate"></param>
        /// <param name="bunho"></param>
        /// <param name="editControl"></param>
        public static void SuggestValueForNewTemplate(TemplateMeta oldTemplate, TemplateMeta currentTemplate, string bunho, RichEditControl editControl)
        {
            //TODO: 1.Get EMR tags from cache. (Note the tags will be parsed from document when finishing patient and then will be cached.)
            string json = CacheService.Instance.Get<string>(TAGS_FOR_PATIENT + bunho);
            if (json != null && json.Length > 0)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.All;
                settings.TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple;
                Dictionary<string, TagMeta> tagValueDict = JsonConvert.DeserializeObject<Dictionary<string, TagMeta>>(json);//Newtonsoft.Json.JsonConvert.DeserializeObject(json, settings) as Dictionary<string, string>;
                if (tagValueDict != null && tagValueDict.Count > 0)
                {
                    //string s = editControl.Document.Text;
                    //TODO: 2.For each tag in passed-in template, search for value in EMR document
                    foreach (KeyValuePair<string, TagMeta> item in tagValueDict)
                    {
                        if (item.Key.Trim() != "")
                        {
                            ISearchResult searchStartTagResult = editControl.Document.StartSearch(START_TAG_META_CHARACTER + item.Key,
                                SearchOptions.CaseSensitive, SearchDirection.Forward, editControl.Document.Range);
                            while (searchStartTagResult.FindNext())
                            {
                                ISearchResult searchEndTagResult =
                                    editControl.Document.StartSearch(END_TAG_DISPLAY_META_CHARACTER,
                                        SearchOptions.CaseSensitive, SearchDirection.Forward, editControl.Document.GetParagraph(searchStartTagResult.CurrentResult.Start).Range);
                                while (searchEndTagResult.FindNext())
                                {
                                    //TODO: 3.Set value for each found tag 
                                    DocumentRange tagRange = editControl.Document.InsertText(editControl.Document.CreatePosition(searchEndTagResult.CurrentResult.Start.ToInt() + 2),
                                        item.Value.TagValue == null ? END_TAG_META_CHARACTER : item.Value.TagValue + STOP_TAG_META_CHARACTER);
                                    Paragraph par = editControl.Document.GetParagraph(tagRange.Start);
                                    //par.Style = editControl.Document.ParagraphStyles[item.Key];
                                    foreach (ParagraphStyle style in editControl.Document.ParagraphStyles)
                                    {
                                        if (style.Name == item.Key)
                                        {
                                            par.Style = editControl.Document.ParagraphStyles[item.Key]; 
                                        }
                                    }
                                    break;
                                }
                                break;
                            }
                        }
                    }
                } 
            }
        }

        /// <summary>
        /// class for stored tag information in client cache
        /// </summary>
        private class TagMeta
        {//TODO: need update tag caching from string to this class
            private string _tag_display;
            private string _tag_value;

            public string TagDisplay
            {
                get { return _tag_display; }
                set { _tag_display = value; }
            }

            public string TagValue
            {
                get { return _tag_value; }
                set { _tag_value = value; }
            }
        }

        /// <summary>
        /// Caching tag values in client cache. Need to be called when click Terminate
        /// </summary>
        /// <param name="bunho">Patient code</param>
        /// <param name="editControl">Text control contains EMR record content</param>
        /// <param name="templateList">OCS2015U09Businesses.TemplateList member</param>
        public static void CacheTagsBeforeFinishingPatient(string bunho, RichEditControl editControl, List<TemplateMeta> templateList)
        {
            //TODO: find tags and corresponding values inside emrText
            Dictionary<string, TagMeta> tagValueDict = new Dictionary<string, TagMeta>();
            Dictionary<string, DocumentRange> tagRangeDict = new Dictionary<string, DocumentRange>();
            //Get all available tags in every template. At this step, tagValueDict.Value will store display text for the tag, the purpose is for searching tag in document text
            foreach (TemplateMeta templateMeta in templateList)
            {
                foreach (KeyValuePair<string, string> tag in templateMeta.TagList)
                {
                    if (!tagValueDict.ContainsKey(tag.Key))
                    {
                        TagMeta tagMeta = new TagMeta();
                        tagMeta.TagDisplay = tag.Value;
                        tagValueDict.Add(tag.Key, tagMeta); // get tag display text for search later in edit control
                        tagRangeDict.Add(tag.Key, null);
                    }
                }
            }

            //Search for index of each tag in underlying text
            string allDocText = editControl.Document.Text;
            List<KeyValuePair<string, int>> tagIndexList = ConvertTagDictionaryToOrderedByIndexList(tagValueDict, allDocText);
            for (int i=0;i< tagIndexList.Count;i++)
            {
                if (i == (tagIndexList.Count - 1))
                {
                    KeyValuePair<string, int> pair = tagIndexList[i];
                    if (tagValueDict.ContainsKey(pair.Key))
                    {
                        string tagDisplayText = tagValueDict[pair.Key].TagDisplay;
                        int startPos = pair.Value + tagDisplayText.Length + 1;
                        if (startPos < 0) startPos = 0;
                        else if (startPos >= allDocText.Length) startPos = allDocText.Length > 0 ? allDocText.Length - 1 : 0;
                        int length = (allDocText.IndexOf(STOP_TAG_META_CHARACTER, startPos) == -1 ? (editControl.Document.Range.End.ToInt() - 1) : (allDocText.IndexOf(STOP_TAG_META_CHARACTER, startPos) - startPos)) < 0 ? 0 : (allDocText.IndexOf(STOP_TAG_META_CHARACTER, startPos) == -1 ? (editControl.Document.Range.End.ToInt() - 1) : (allDocText.IndexOf(STOP_TAG_META_CHARACTER, startPos) - startPos));
                        if ((startPos + length) > (allDocText.Length - 1))
                        {
                            length = allDocText.Length - 1 - startPos;
                        }
                        tagValueDict[pair.Key].TagValue = allDocText.Substring(startPos, length);
                    }
                }
                else
                {
                    KeyValuePair<string, int> pair = tagIndexList[i];
                    if (tagValueDict.ContainsKey(pair.Key))
                    {
                        string tagDisplayText = tagValueDict[pair.Key].TagDisplay;
                        int startPos = pair.Value + tagDisplayText.Length + 1;
                        if (startPos < 0) startPos = 0;
                        else if (startPos >= allDocText.Length) startPos = allDocText.Length > 0 ? allDocText.Length - 1 : 0;
                        int length = (allDocText.IndexOf(STOP_TAG_META_CHARACTER, startPos) == -1 ? (tagIndexList[i + 1].Value - 1) : (allDocText.IndexOf(STOP_TAG_META_CHARACTER, startPos) - startPos)) < 0 ? 0 : (allDocText.IndexOf(STOP_TAG_META_CHARACTER, startPos) == -1 ? (tagIndexList[i + 1].Value - 1) : (allDocText.IndexOf(STOP_TAG_META_CHARACTER, startPos) - startPos));
                        if ((startPos + length) > (allDocText.Length - 1))
                        {
                            length = allDocText.Length - 1 - startPos;
                        }
                        tagValueDict[pair.Key].TagValue = allDocText.Substring(startPos, length);
                    }
                }
            }

            //TODO: serialize tags & value into json
            
            //TODO: cache key must contain patient code to differentiate
            if (CacheService.Instance.IsSet(TAGS_FOR_PATIENT + bunho)) CacheService.Instance.Remove(TAGS_FOR_PATIENT + bunho); // clear before update
            CacheService.Instance.Set(TAGS_FOR_PATIENT + bunho, JsonConvert.SerializeObject(tagValueDict), TimeSpan.MaxValue);
        }

        /// <summary>
        /// convert tagRangeDict to list int then ordering elements by it's start position. This method must be run before update tagValueDict parameter
        /// </summary>
        /// <param name="tagValueDict"></param>
        /// <param name="allDocText"></param>
        /// <returns></returns>
        private static List<KeyValuePair<string, int>> ConvertTagDictionaryToOrderedByIndexList(Dictionary<string, TagMeta> tagValueDict, string allDocText)
        {


            List<KeyValuePair<string, int>> result = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, TagMeta> keyValuePair in tagValueDict)
            {
                //int i = allDocText.IndexOf(keyValuePair.Value);
                int i = allDocText.IndexOf(START_TAG_META_CHARACTER + keyValuePair.Key);
                if (i > -1 && i <= allDocText.Length)
                {
                    int j = allDocText.IndexOf(END_TAG_DISPLAY_META_CHARACTER, i + 1);
                    if (j > 0 && j < allDocText.Length )
                    {
                        KeyValuePair<string, int> kvp = new KeyValuePair<string, int>(keyValuePair.Key, i);
                        result.Add(kvp); 
                    }
                }
            }
            result.Sort(
                delegate(KeyValuePair<string, int> a,
                KeyValuePair<string, int> b)
                {
                    return a.Value.CompareTo(b.Value);
                }
            );
            return result;
        }

        /// <summary>
        /// convert tagRangeDict to list Document range then ordering elements by it's start position
        /// </summary>
        /// <param name="tagRangeDict">tagRangeDict</param>
        private static List<KeyValuePair<string, DocumentRange>> ConvertDictionaryToOrderedList(Dictionary<string, DocumentRange> tagRangeDict)
        {
            List<KeyValuePair<string, DocumentRange>> myList = new List<KeyValuePair<string, DocumentRange>>(tagRangeDict);
            myList.Sort(
                delegate(KeyValuePair<string, DocumentRange> a,
                KeyValuePair<string, DocumentRange> b)
                {
                    return a.Value.Start.ToInt().CompareTo(b.Value.Start.ToInt());
                }
            );
            return myList;
        }

        private static int PositionComparison(DocumentRange x, DocumentRange y)
        {
            if (x.Start.ToInt() == y.Start.ToInt())
            {
                return 0;
            }
            else if (x.Start.ToInt() > y.Start.ToInt())
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }



        private static readonly string TAGS_FOR_PATIENT = "TAGS_FOR_PATIENT";
    }

    /// <summary>
    /// Additional logics of OCS2015U06 come here
    /// </summary>
    public static class OCS2015U06Businesses
    {
        /// <summary>
        /// Set marker at the beginning of the paragraph to mark position to put tag
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns>Create custom mark success or not</returns>
        public static bool SetParagraphMarker(Paragraph paragraph, RichEditControl richEditControl)
        {
            bool success = false;
            try
            {
                CustomMark paragraphMarker = richEditControl.Document.CreateCustomMark(paragraph.Range.Start,
                        new ParagraphMarker());
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        /// <summary>
        /// Display tag at the beginning of paragraph.
        /// </summary>
        /// <param name="mode">Display tag mode: Tag code/Tag name/Both</param>
        /// <param name="paragraphs">Document's paragraphs passed in</param>
        public static void DisplayTagBeforeParagraph(RichEditControl richEditControl, ParagraphCollection paragraphs, string mode)
        {
            string tagName;
            int pgMarkerPosition;          
            foreach (Paragraph paragraph in paragraphs)
            {
                if (CheckParagraphTagged(paragraph, out tagName, out pgMarkerPosition, richEditControl))
                {
                    string prefixTag = GetTagPrefix(tagName, mode);
                    richEditControl.BeginUpdate();
                    DocumentRange range = richEditControl.Document.CreateRange(paragraph.Range.Start, ((pgMarkerPosition - paragraph.Range.Start.ToInt()) > 0 ? (pgMarkerPosition - paragraph.Range.Start.ToInt()) : 0));
                    richEditControl.Document.Replace(range, ""); // remove old tag
                    richEditControl.Document.InsertText(range.Start, prefixTag);
                    richEditControl.EndUpdate();
                }
            }         
        }

        public static string GetTagPrefix(string tagName, string mode)
        {
            TagOption code = StringEnum.Parse<TagOption>(mode);  
            TagInfo info = DataProvider.Instance.TagDetail.ContainsKey(tagName) ? DataProvider.Instance.TagDetail[tagName] : null;
            string prefixTag = info == null ? String.Empty : String.Format(
                "#{0}",
                TagOption.TagCode.Equals(code) ? info.TagCode : TagOption.TagDisplay.Equals(code) ? info.TagDisplay : info.Both);
            return prefixTag;
        }

        public static void RemoveEmptyTags(RichEditControl richEditControl, string mode)
        {
            for (int i = 0; i < richEditControl.Document.Paragraphs.Count; i++)
            {
                Paragraph pg = richEditControl.Document.Paragraphs[i];
                Paragraph nextPg = i < richEditControl.Document.Paragraphs.Count - 1 ? richEditControl.Document.Paragraphs[i + 1] : null;
                if (pg.Style != null && !"Normal".Equals(pg.Style.Name, StringComparison.CurrentCultureIgnoreCase)
                    && !"Hyperlink".Equals(pg.Style.Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    string pgContent = richEditControl.Document.GetText(pg.Range).Trim();
                    string prefixTag = GetTagPrefix(pg.Style.Name.Trim(), mode);
                    if ((prefixTag.Equals(pgContent) || pgContent.Equals(prefixTag + ":")) && richEditControl.Document.GetImages(pg.Range).Count == 0 && (nextPg == null || nextPg.Style == null || !nextPg.Style.Name.Equals(pg.Style.Name)))
                    {
                        for (int j = 0; j < richEditControl.Document.CustomMarks.Count; j++)
                        {
                            CustomMark mark = richEditControl.Document.CustomMarks[j];
                            if (pg.Range.Contains(mark.Position))
                            {
                                richEditControl.Document.DeleteCustomMark(mark);
                                j--;
                            }
                        }
                        richEditControl.Document.Delete(pg.Range);
                        i--;
                    }
                }
            }
        }

        public static void SwitchParagraphStyle(RichEditControl richEditControl, ParagraphCollection collection, string tag, string mode)
        {
            //Delete all ParagraphMarker in the selection if any
            for (int i = 0; i < richEditControl.Document.CustomMarks.Count; i++)
            {
                CustomMark mark = richEditControl.Document.CustomMarks[i];
                ParagraphMarker marker = mark.UserData as ParagraphMarker;
                if (marker != null && collection[0].Range.Start.ToInt() <= mark.Position.ToInt()
                    && mark.Position.ToInt() <= collection[collection.Count - 1].Range.End.ToInt())
                {
                    int startPg = richEditControl.Document.GetParagraph(mark.Position).Range.Start.ToInt();
                    richEditControl.Document.Delete(
                        richEditControl.Document.CreateRange(startPg, mark.Position.ToInt() - startPg + 1 < collection[collection.Count - 1].Range.End.ToInt() ? mark.Position.ToInt() - startPg + 1 : mark.Position.ToInt() - startPg));
                    richEditControl.Document.DeleteCustomMark(mark);
                    i--;
                }
            }

            for (int i = richEditControl.Document.Paragraphs.Count - 1; i >= 0; i--)
            {
                Paragraph pg = richEditControl.Document.Paragraphs[i];
                //If previous neighbour paragraph is the same style --> inorge
                if (collection[0].Range.Start.ToInt() > pg.Range.End.ToInt())
                {
                    if (pg.Style != null && tag.Equals(pg.Style.Name))
                    {
                        return;
                    }
                    break;
                }
            }
            if (!"Normal".Equals(tag, StringComparison.CurrentCultureIgnoreCase))
            {
                string prefixTag = GetTagPrefix(tag, mode);
                DocumentRange range = richEditControl.Document.InsertText(collection[0].Range.Start, prefixTag);
                int start = range.End.ToInt();
                richEditControl.Document.InsertText(range.End, ": ");
                richEditControl.Document.CreateCustomMark(richEditControl.Document.CreatePosition(start), new ParagraphMarker());
            }
        }

        /// <summary>
        /// Check if a paragraph is tagged or not, if style name other than "normal" or "hyperlink", it is tagged.
        /// </summary>
        /// <param name="paragraph"></param>
        /// <param name="tagName">Name of the tag</param>
        /// <param name="richEditControl"></param>
        /// <returns></returns>
        public static bool CheckParagraphTagged(Paragraph paragraph, out string tagName, out int pgMarkerPosition, RichEditControl richEditControl)
        {
            tagName = "";
            pgMarkerPosition = 0;
            string styleName = paragraph.Style.Name;
            if (!styleName.ToLower().Equals("normal") && !styleName.ToLower().Equals("hyperlink"))
            {                
                foreach (CustomMark mark in richEditControl.Document.CustomMarks)
                {
                    ParagraphMarker marker = mark.UserData as ParagraphMarker;
                    if (marker != null && paragraph.Range.Contains(mark.Position))
                    {
                        tagName = styleName;
                        pgMarkerPosition = mark.Position.ToInt();
                        return true;
                    }
                }
            }
            return false;
        }

        public class TagInfo
        {
            private string tagCode;
            private string tagDisplay;

            public string TagCode
            {
                get { return tagCode; }
                set { tagCode = value; }
            }

            public string TagDisplay
            {
                get { return tagDisplay; }
                set { tagDisplay = value; }
            }

            public string Both
            {
                get { return String.Format("{0} {1}", tagCode, tagDisplay); }
            }

            public TagInfo(string tagCode, string tagDisplay)
            {
                this.tagCode = tagCode;
                this.tagDisplay = tagDisplay;
                
            }
        }
    }
}
