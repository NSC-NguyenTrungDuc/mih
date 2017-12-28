using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Messaging;
using IHIS.Framework;
using System.Collections;

namespace IHIS.NURO
{
    public partial class ReserCommentForm : XForm
    {
        string mOpenMode = "";
        string mBunho = "";
        string mPkout1001 = "";
        string mGwa = "";
        string mDoctor = "";
        string mReserComment = "";
        string mReserGubun = "";
        string mJinryoPreDate = "";
        string mJinryoPreTime = "";
        string mHospCodeLink = "";
        bool tabIsAll = false;

        public ReserCommentForm(Hashtable ht, string hospCodeLink, bool tabIsAll)
        {
            InitializeComponent();

            if(ht["open_mode"] != null)
                this.mOpenMode = ht["open_mode"].ToString();

            if (ht["bunho"] != null)
                this.mBunho = ht["bunho"].ToString();

            if (ht["pkout1001"] != null)
                this.mPkout1001 = ht["pkout1001"].ToString();

            if (ht["gwa"] != null)
                this.mGwa = ht["gwa"].ToString();

            if (ht["doctor"] != null)
                this.mDoctor = ht["doctor"].ToString();

            if (ht["reser_comment"] != null)
                this.mReserComment = ht["reser_comment"].ToString();

            if (ht["reser_gubun"] != null)
                this.mReserGubun = ht["reser_gubun"].ToString();

            if (ht["jinryo_pre_date"] != null)
                this.mJinryoPreDate = ht["jinryo_pre_date"].ToString();

            if (ht["jinryo_pre_time"] != null)
                this.mJinryoPreTime = ht["jinryo_pre_time"].ToString();
            

            if (this.mOpenMode == "MODIFY")
                this.btnCancel.Visible = true;
            else
                this.btnCancel.Visible = false;

            this.mHospCodeLink = hospCodeLink;
            this.tabIsAll = tabIsAll;

        }


        public string ReserComment
        {
            get
            { return mReserComment; }
        }

        public string ReserGubun
        {
            get
            { return mReserGubun; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.mOpenMode == "NEW")
            {
                this.mReserComment = this.txtReserComment.Text;
                this.mReserGubun = this.cboReserGubun.GetDataValue();
            }
            else if (this.mOpenMode == "MODIFY")
            {
                //TODO: thay thế bằng NuroRES1001U00CheckingPatientExistenceRequest
                NuroRES1001U00CheckingPatientExistenceArgs patientExistenceArgs = new NuroRES1001U00CheckingPatientExistenceArgs();
                patientExistenceArgs.PatientCode = this.mBunho;
                patientExistenceArgs.Pkout1001 = this.mPkout1001;
                patientExistenceArgs.HospCodeLink = this.mHospCodeLink;
                NuroRES1001U00CheckingPatientExistenceResult patientExistenceRes = CloudService.Instance.Submit<NuroRES1001U00CheckingPatientExistenceResult, NuroRES1001U00CheckingPatientExistenceArgs>(patientExistenceArgs);

//                string cmdText = @"SELECT 'Y'
//                                  FROM DUAL
//                                 WHERE EXISTS ( SELECT BUNHO
//                                                  FROM OUT0123
//                                                 WHERE HOSP_CODE    = :f_hosp_code
//                                                   AND BUNHO        = :f_bunho
//                                                   AND FKOUT1001    = :f_pkout1001
//                                                   AND COMMENT_TYPE = '1' )";

//                BindVarCollection bc = new BindVarCollection();
//                bc.Add("f_hosp_code", EnvironInfo.HospCode);
//                bc.Add("f_bunho", this.mBunho);
//                bc.Add("f_pkout1001", this.mPkout1001);
//                bc.Add("f_user_id", UserInfo.UserID);
//                bc.Add("f_reser_comment", this.txtReserComment.Text);
//                bc.Add("f_gwa", this.mGwa);
//                bc.Add("f_doctor", this.mDoctor);
//                bc.Add("f_reser_gubun", this.cboReserGubun.GetDataValue());
//                bc.Add("f_jinryo_pre_date", this.mJinryoPreDate);
//                bc.Add("f_jinryo_pre_time", this.mJinryoPreTime);

                //object retVal = Service.ExecuteScalar(cmdText, bc);

                object retVal = patientExistenceRes.Result;
                bool resOk = false;

                if (!TypeCheck.IsNull(retVal))
                {
                    if (retVal.ToString() == "Y")
                    {
                        //TODO: thay thế bằng NuroRES1001U00ReservationOut0123UpdateRequest
                        NuroRES1001U00ReservationOut0123UpdateArgs reservationOut0123UpdateArgs = new NuroRES1001U00ReservationOut0123UpdateArgs();
                        reservationOut0123UpdateArgs.UserId = UserInfo.UserID;
                        reservationOut0123UpdateArgs.ReserType = this.cboReserGubun.GetDataValue();
                        reservationOut0123UpdateArgs.ReserComment = this.txtReserComment.Text;
                        reservationOut0123UpdateArgs.Pkout1001 = this.mPkout1001;
                        reservationOut0123UpdateArgs.PatientCode = this.mBunho;
                        reservationOut0123UpdateArgs.HospCodeLink = this.mHospCodeLink;
                        UpdateResult reservationOut0123UpdateRes = CloudService.Instance.Submit<UpdateResult, NuroRES1001U00ReservationOut0123UpdateArgs>(reservationOut0123UpdateArgs);
                        resOk = reservationOut0123UpdateRes.Result;

//                        cmdText = @"UPDATE OUT0123
//                                           SET UPD_DATE     = SYSDATE
//                                             , UPD_ID       = :f_user_id
//                                             , COMMENTS     = :f_reser_comment
//                                             , RESER_GUBUN  = :f_reser_gubun
//｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡｡ , REQ_DATE     = TRUNC(SYSDATE)
//                                         WHERE HOSP_CODE    = :f_hosp_code
//                                           AND BUNHO        = :f_bunho
//                                           AND FKOUT1001    = :f_pkout1001
//                                           AND COMMENT_TYPE = '1'";
                    }
                }
                else
                {
                    if (this.txtReserComment.Text != "" || this.cboReserGubun.GetDataValue() != "")
                    {
                        //TODO: thay thế bằng NuroRES1001U00ReservationOut0123InsertRequest
                        NuroRES1001U00ReservationOut0123InsertArgs reservationOut0123InsertArgs = new NuroRES1001U00ReservationOut0123InsertArgs();
                        reservationOut0123InsertArgs.DepartmentCode = this.mGwa;
                        reservationOut0123InsertArgs.DoctorCode = this.mDoctor;
                        reservationOut0123InsertArgs.ExamPreDate = this.mGwa;
                        reservationOut0123InsertArgs.ExamPreTime = this.mGwa;
                        reservationOut0123InsertArgs.PatientCode = this.mBunho;
                        reservationOut0123InsertArgs.Pkout1001 = this.mPkout1001;
                        reservationOut0123InsertArgs.ReserComment = this.txtReserComment.Text;
                        reservationOut0123InsertArgs.ReserType = this.cboReserGubun.GetDataValue();
                        reservationOut0123InsertArgs.UserId = UserInfo.UserID;
                        reservationOut0123InsertArgs.HospCodeLink = this.mHospCodeLink;
                        UpdateResult reservationOut0123InsertRes = CloudService.Instance.Submit<UpdateResult, NuroRES1001U00ReservationOut0123InsertArgs>(reservationOut0123InsertArgs);
                        resOk = reservationOut0123InsertRes.Result;

//                        cmdText = @"INSERT INTO OUT0123 
//                                         ( SYS_DATE          , SYS_ID                       , UPD_DATE          , UPD_ID        
//                                         , HOSP_CODE         , BUNHO                        , SEQ           
//                                         , REQ_DATE          , REQ_TIME                     , REQ_GWA           , REQ_DOCTOR 
//                                         , ANSWER_DATE       , ANSWER_TIME                  , ANSWER_GWA        , ANSWER_DOCTOR
//                                         , ANSWER_END_YN     , IN_OUT_GUBUN                 , COMMENTS          
//                                         , FKOUT1001         , FKINP1001                    , COMMENT_TYPE      , RESER_GUBUN   )
//                                    VALUES 
//                                         ( SYSDATE           , :f_user_id                   , SYSDATE           , :f_user_id
//                                         , :f_hosp_code      , :f_bunho                     , '1'            
//                                         , TRUNC(SYSDATE)    , TO_CHAR(SYSDATE, 'HH24MI')   , :f_gwa            , :f_doctor
//                                         , :f_jinryo_pre_date, :f_jinryo_pre_time           , '%'               , '%'
//                                         , 'Y'               , 'O'                          , :f_reser_comment
//                                         , :f_pkout1001      , ''                           , '1'               , :f_reser_gubun ) ";

                    }
                }

                //if (!Service.ExecuteNonQuery(cmdText, bc))
                if (!resOk)
                {
                    XMessageBox.Show("褸蟲ｫｳｫ皚ﾈｪﾎﾜﾁｪﾋ胱ｪｷｪﾞｪｷｪｿ｡｣\r\n" + Service.ErrFullMsg, "ﾜﾁ胱", MessageBoxIcon.Information);
                }
            
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.mReserComment = "";
            this.mReserGubun = "";
            this.Close();
        }

        private void ReserCommentForm_Load(object sender, EventArgs e)
        {
            this.txtReserComment.Text = this.mReserComment;
            this.cboReserGubun.SetDataValue(this.mReserGubun);
        }


    }
}