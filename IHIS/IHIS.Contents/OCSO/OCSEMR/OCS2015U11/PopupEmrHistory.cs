using System.Collections.Generic;
using System;
using System.Data;
using System.Windows.Forms;
using EmrDocker.Models;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.Framework;
using IHIS.OCSO;
using System.Globalization;




namespace EmrDocker
{
    public partial class PopupEmrHistory : Form
    {

        private string Bunho;
        private List<EmrRecordInfo> EmrRecordData;
        private string NaewonDate;


        public PopupEmrHistory(List<EmrRecordInfo> emrRecordInfo, string bunho, string naewonDate)
        {
            InitializeComponent();
            calSchedule.SelectDate(DateTime.Now);
            EmrRecordData = emrRecordInfo;
            Bunho = bunho;
            if (!String.IsNullOrEmpty(naewonDate))
            {
                DateTime dt1 = DateTime.ParseExact(naewonDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                NaewonDate = dt1.ToString("dd/MM/yyyy");
            }            
            
           // CreateTable();
        }

        private DataTable dtListDoctorPaTable = new DataTable();
        private DataTable dtListDiseaseTable = new DataTable();
        private DataTable dtListOrderTable = new DataTable();
        private DataTable dtListContentTable = new DataTable();

        public void CreateTable()
        {

            dtListDoctorPaTable.Columns.Add("doctor_name");
            dtListDoctorPaTable.Columns.Add("gwa_name");
            dtListDoctorPaTable.Columns.Add("yotang_name");
            dtListDoctorPaTable.Columns.Add("adress_doc");
            dtListDoctorPaTable.Columns.Add("tel_doc");
            dtListDoctorPaTable.Columns.Add("seqvalue");
            dtListDoctorPaTable.Columns.Add("suname");
            dtListDoctorPaTable.Columns.Add("birth");
            dtListDoctorPaTable.Columns.Add("sex");
            dtListDoctorPaTable.Columns.Add("adress_pa");
            dtListDoctorPaTable.Columns.Add("tel_pa");
            dtListDoctorPaTable.Columns.Add("bunho");
            dtListDoctorPaTable.Columns.Add("naewon_date");

            dtListDiseaseTable.Columns.Add("sang_code");
            dtListDiseaseTable.Columns.Add("sang_name");

            dtListOrderTable.Columns.Add("hangmog_code");
            dtListOrderTable.Columns.Add("hangmog_name");
            dtListOrderTable.Columns.Add("suryang");
            dtListOrderTable.Columns.Add("dv");
            dtListOrderTable.Columns.Add("nalsu");
            dtListOrderTable.Columns.Add("multil");
            dtListOrderTable.Columns.Add("bogyong_name");
            dtListOrderTable.Columns.Add("code_name");

            dtListContentTable.Columns.Add("reason");
            dtListContentTable.Columns.Add("patient_symptom");
            dtListContentTable.Columns.Add("medical_history");
            dtListContentTable.Columns.Add("health_index");
            dtListContentTable.Columns.Add("doctor_comment");
            dtListContentTable.Columns.Add("doctor_comment_detail");
            dtListContentTable.Columns.Add("examination_comment");
            dtListContentTable.Columns.Add("xray_comment");
            dtListContentTable.Columns.Add("function_comment");
            dtListContentTable.Columns.Add("method");
            dtListContentTable.Columns.Add("doctor_remind");
        }

        private void DeleteDataTable()
        {
            //Clear 

            dtListDoctorPaTable.Clear();
            dtListDiseaseTable.Clear();
            dtListOrderTable.Clear();
            dtListContentTable.Clear();
        }


        private void DataPrint(string choose)
        {
            for (int i = 0; i < EmrRecordData.Count; i++)
            {

                //DataSet ds = new DataSet();
                DataSetReport ds = new DataSetReport();
                ds.Clear();
                //DeleteDataTable();
                if (choose != "all" && EmrRecordData[i].DateTime != calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd"))
                {
                    continue;
                }


                #region Table 1

                OCS2015U00GetDoctorPatientReportArgs args = new OCS2015U00GetDoctorPatientReportArgs();
                args.Doctor = UserInfo.DoctorID;
                args.Bunho = Bunho;
                args.Pkout1001 = EmrRecordData[i].PkOut;
                args.NaewonDate = EmrRecordData[i].DateTime;
                args.Gwa = UserInfo.Gwa;
                OCS2015U00GetDoctorPatientReportResult result = CloudService.Instance
                    .Submit<OCS2015U00GetDoctorPatientReportResult, OCS2015U00GetDoctorPatientReportArgs>(args);
                if (result != null)
                {
                    List<OCS2015U00GetDoctorPatientReportInfo> ListItemItem =
                        new List<OCS2015U00GetDoctorPatientReportInfo>();
                    ListItemItem.Add(result.ListItem);
                    if (ListItemItem.Count > 0)
                    {
                        foreach (OCS2015U00GetDoctorPatientReportInfo info in ListItemItem)
                        {

                            //DataRow row = dtListDoctorPaTable.NewRow();
                            DataRow row = ds.DataTable1.NewRow();
                            row["doctor_name"] = info.DoctorName.ToUpper();
                            row["gwa_name"] = info.GwaName;
                            row["yotang_name"] = UserInfo.HospName;
                            row["adress_doc"] = info.AdressDoc;
                            row["tel_doc"] = info.TelDoc;
                            row["seqvalue"] = info.Seqvalue.ToUpper();
                            row["suname"] = info.Suname.ToUpper();
                            if (!string.IsNullOrEmpty(info.Birth))
                            {
                                DateTime dt = DateTime.ParseExact(info.Birth, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                                row["birth"] = dt.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                row["birth"] = "";
                            }
                            if (info.Sex == "F")
                            {
                                row["sex"] = "NỮ";
                            }
                            else
                            {
                                row["sex"] = "NAM";
                            }
                            row["adress_pa"] = info.AdressPa;
                            row["tel_pa"] = info.TelPa;
                            row["bunho"] = Bunho;
                            row["naewon_date"] = NaewonDate;
                            row["fax_doc"] = info.FaxDoc;
                            row["website"] = info.Website;

                            ds.DataTable1.Rows.Add(row);


                        }
                    }
                }

                #endregion

                #region Table 2

                if (result.ListDisease.Count > 0)
                {
                    foreach (OCS2015U00GetDiseaseReportInfo info in result.ListDisease)
                    {
                        //DataRow row = dtListDiseaseTable.NewRow();
                        DataRow row = ds.DataTable2.NewRow();
                        row["sang_code"] = info.SangCode;
                        row["sang_name"] = info.SangName;
                        ds.DataTable2.Rows.Add(row);
                    }
                }

                #endregion

                #region Table3


                if (result.ListOrder.Count > 0)
                {
                    foreach (OCS2015U00GetOrderReportInfo info in result.ListOrder)
                    {
                        //DataRow row = dtListOrderTable.NewRow();
                        DataRow row = ds.DataTable3.NewRow();
                        row["hangmog_code"] = info.HangmogCode;
                        row["hangmog_name"] = info.HangmogName;
                        row["suryang"] = info.Suryang;
                        row["dv"] = info.Dv;
                        row["nalsu"] = info.Nalsu;
                        //decimal mutil = (Convert.ToDecimal(info.Suryang) * Convert.ToDecimal(info.Dv) *
                        //                    Convert.ToDecimal(info.Nalsu));
                        //if (mutil != 0) row["multil"] = Convert.ToInt32(mutil).ToString();
                        row["multil"] = Convert.ToInt32(Convert.ToDecimal(info.DvQuantity)).ToString();
                        row["bogyong_name"] = info.BogyongName;
                        row["code_name"] = info.CodeName;
                        ds.DataTable3.Rows.Add(row);

                    }
                }

                #endregion

                #region Table4

                foreach (TagInfo itemTagInfo in EmrRecordData[i].TagInfos)
                {
                    DataRow row1 = ds.DataTable4.NewRow();
                    if (!String.IsNullOrEmpty(itemTagInfo.Content+""))
                    {
                        switch (itemTagInfo.Type){
                            case EmrDocker.Glossary.TypeEnum.Image:
                                row1["TagName"] = itemTagInfo.TagName;
                                row1["ImagePath"] = itemTagInfo.DirLocation;
                                ds.DataTable4.Rows.Add(row1);
                                break;

                            case EmrDocker.Glossary.TypeEnum.Pdf:
                                break;

                            default:
                                row1["TagName"] = itemTagInfo.TagName;
                                row1["Content"] = itemTagInfo.Content;
                                ds.DataTable4.Rows.Add(row1);
                                break;
                        }
                        
                    }
                    #region Update Report VN
                    
                    
                    //switch (itemTagInfo.TagCode)
                    //{
                    //    case "A":
                    //        row1["reason"] = itemTagInfo.Content;
                    //        break;
                    //    case "B1":
                    //        row1["patient_symptom"] = itemTagInfo.Content;
                    //        break;
                    //    case "B2":
                    //        row1["medical_history"] = itemTagInfo.Content;
                    //        break;
                    //    case "C1":
                    //        row1["health_index"] = itemTagInfo.Content;
                    //        break;
                    //    case "C2":
                    //        row1["doctor_comment"] = itemTagInfo.Content;
                    //        break;
                    //    case "C3":
                    //        row1["doctor_comment_detail"] = itemTagInfo.Content;
                    //        break;
                    //    case "C5":
                    //        row1["examination_comment"] = itemTagInfo.Content;
                    //        break;
                    //    case "C6":
                    //        row1["xray_comment"] = itemTagInfo.Content;
                    //        break;
                    //    case "C7":
                    //        row1["function_comment"] = itemTagInfo.Content;
                    //        break;
                    //    case "C8":
                    //        row1["method"] = itemTagInfo.Content;
                    //        break;
                    //    case "C9":
                    //        row1["doctor_remind"] = itemTagInfo.Content;
                    //        break;
                    //}
                    #endregion
                }

               

                #endregion

                #region Table5
               
                //foreach (TagInfo itemTagInfo in EmrRecordData[i].TagInfos)
                //{

                //    switch (itemTagInfo.TagCode)
                //    {

                //        case "C6":
                            if (EmrRecordData[i].TagInfos.Count > 0)
                            {
                                for (int j = 0; j < EmrRecordData[i].TagInfos.Count; j++)
                                {
                                    if (!String.IsNullOrEmpty(EmrRecordData[i].TagInfos[j].DirLocation))
                                    {
                                        DataRow row2 = ds.DataTable5.NewRow();
                                        row2["link_picture"] = IHIS.OCSO.Utilities.ConvertToLocalPath(EmrRecordData[i].TagInfos[j].DirLocation.Trim(), UserInfo.HospCode, Bunho);
                                        //ds.DataTable5.Rows.Add(row2);
                                    }
                                    
                                }
                            }
                //            break;

                //    }

                //}
              
                



                #endregion
                //ds.Tables.Add(dtListDoctorPaTable.Copy());
                //    ds.Tables.Add(dtListDiseaseTable.Copy());
                //    ds.Tables.Add(dtListOrderTable.Copy());
                //    ds.Tables.Add(dtListContentTable.Copy());
                ReportMedicalRecord xReport = new ReportMedicalRecord();
                xReport.DataSource = ds;
                //xReport.DataMember = "DataTable1";
                xReport.Print();

            }
        }

        private bool CheckPrint()
        {
            if (calSchedule.SelectedDays.Count == 0)
            {
                XMessageBox.Show("Hãy chọn ngày để in");
                return false;
            }
            return true;
        }


        private void xButtonList2_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            try
            {
                if (EmrRecordData.Count > 0)
                {
                    DataPrint("all"); // print all
                }

            }
            catch
            {
                XMessageBox.Show("Error");
            }
        }

        private void xButtonList1_ButtonClick(object sender, ButtonClickEventArgs e)
        {

            switch (e.Func)
            {
                case FunctionType.Print:
                    if (!CheckPrint()) return;
                    if (EmrRecordData.Count > 0)
                    {
                        DataPrint("not all"); //print not all
                    }
                    break;
                case FunctionType.Close:
                    this.Close();
                    break;



            }
        }
    }
}


