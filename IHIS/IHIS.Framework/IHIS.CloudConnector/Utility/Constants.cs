using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace IHIS.CloudConnector.Utility
{
    public class Constants
    {
        public static class SecurityLogin
        {
            public static readonly int MAX_ATTEMPT_TIMES = Int32.Parse(ConfigurationManager.AppSettings.Get("MaxAttemptTimes"));
            public static readonly string CACHE_ATTEMPT_TIMES = "ATTEMPT_TIMES";
        }

        public static class CacheKeyLayout
        {
            public static readonly string CACHE_USERS_LAYOUT = "USERS_LAYOUT";
            public static readonly string CACHE_USERS_LOCAL = "USERS_LOCAL";
        }

        public static class CacheKinki
        {
            public static readonly string CACHE_KINKI_REVISION_DRUG_KINKI_MESSAGE = "KINKI_REVISION_DRUG_KINKI_MESSAGE";
            public static readonly string CACHE_KINKI_REVISION_DRUG_KINKI_DISEASE = "KINKI_REVISION_DRUG_KINKI_DISEASE";
            public static readonly string CACHE_KINKI_REVISION_DRUG_DOSAGE = "KINKI_REVISION_DRUG_DOSAGE";
            public static readonly string CACHE_KINKI_REVISION_DRUG_CHECKING = "KINKI_REVISION_DRUG_CHECKING";
            public static readonly string CACHE_KINKI_REVISION_DRUG_INTERACTION = "KINKI_REVISION_DRUG_INTERACTION";
            public static readonly string CACHE_KINKI_REVISION_DRUG_GENERIC_NAME = "KINKI_REVISION_DRUG_GENERIC_NAME";
            
        }


        /// <summary>
        /// CacheKeyCbo
        /// </summary>
        public static class CacheKeyCbo
        {
            public static readonly string CACHE_OUTSANGQ00_LAYOUT_GWA                               = "Ocsa.OUTSANGQ00.layoutGwa";
            public static readonly string CACHE_PHY8002U01_CBO_DISUSE_KAIZEN                        = "Phys.PHY8002U01.cboDisuseKaizen";
            public static readonly string CACHE_PHY8002U01_CBO_DISUSE_KAINYU                        = "Phys.PHY8002U01.cboDisuseKainyu";
            public static readonly string CACHE_PHY8002U01_CBO_DISUSE_ADL                           = "Phys.PHY8002U01.cboDisuseADL";
            public static readonly string CACHE_PHY8002U01_CBO_DISUSE_GASYOU                        = "Phys.PHY8002U01.cboDisuseGasyou";
            public static readonly string CACHE_PHY8002U01_CBO_NALSU                                = "Phys.PHY8002U01.layCombo";
            public static readonly string CACHE_XRT0122Q00_LAYCBO_XRT0102                           = "cache_xrt0122q00_laycbo_xrt0102";
            public static readonly string CACHE_ADM102U_FWK_SYSID                                   = "cache_adm102u_fwk_sysid";
            public static readonly string CACHE_ADM106U_FWK_SYSID                                   = "cache_adm106u_fwk_sysid";
            public static readonly string CACHE_OCS_LIBS_DVTIME_CBO                                 = "Cache.OCS.Libs.DvTime.Cbo";
            public static readonly string CACHE_OCS_LIBS_SURYANG_CBO                                = "Cache.OCS.Libs.Suryang.Cbo";
            public static readonly string CACHE_OCS_LIBS_DV_CBO                                     = "Cache.OCS.Libs.Dv.Cbo";
            public static readonly string CACHE_OCS_LIBS_NALSU_CBO                                  = "Cache.OCS.Libs.Nalsu.Cbo";
            public static readonly string CACHE_OCS_LIBS_PORTABLEYN_CBO                             = "Cache.OCS.Libs.PortableYn.Cbo";
            public static readonly string CACHE_OCS_LIBS_PAY_CBO                                    = "Cache.OCS.Libs.Pay.Cbo";
            public static readonly string CACHE_OCS_LIBS_JUSA_CBO                                   = "Cache.OCS.Libs.Jusa.Cbo";
            public static readonly string CACHE_OCS_SEARCH_CONDITION_KEYS                           = "OCSO.CboSearchCondition";
            public static readonly string CACHE_DRG_COMBO_CBX_ACTOR_KEYS                            = "DRG.Cbo.CbxDoctor";
            public static readonly string CACHE_DRG_LAY_CONSTANT_INFO_KEYS                          = "DRG.LayConstantInfo";
            public static readonly string CACHE_OCS_COMBO_ORD_DANUI_KEYS                            = "OCSO.Cbo.OrdDanui";
            public static readonly string CACHE_OCS_COMBO_SANG_END_SAYU_KEYS                        = "OCSO.Cbo.SangEndSayu";
            public static readonly string CACHE_DRG_FWK_CAUTION_LIST_KEYS                           = "DRGS.Fwk.CautionList";
            public static readonly string CACHE_OCS_COMBO_GWA_OUT_JUBSU_YN_KEYS                     = "OCS.GwaOutJubsuYn";
            public static readonly string CACHE_OCS_COMBO_JUBSU_GUBUN_KEYS                          = "OCSO.Cbo.JubsuGubun";
            public static readonly string CACHE_OCS_COMBO_NAEWON_YN_KEYS                            = "OCSO.Cbo.NaewonYn";
            public static readonly string CACHE_OCS_COMBO_JUSA_SPD_GUBUN_KEYS                       = "OCSO.Cbo.JusaSpdGubun";
            public static readonly string CACHE_DRG0120U00_KEYS                                     = "DRG0120U00.xeditgrid";
            public static readonly string CACHE_SCH_COMBO_GUMSA_KEYS                                = "SCH.ComboGumsa";
            public static readonly string CACHE_OCSLIB_GET_APPROVE_FLAGS_KEYS                       = "OCSLIB.GetApproveFlags";
            public static readonly string GET_DEPARTMENT_KEYS                                       = "Combo.Gwa";
            public static readonly string CACHE_COMBO_XRAY_GUBUN_KEY                                = "Cache.Cbo.Xray.Gubun";
            public static readonly string CACHE_COMBO_PART                                          = "Cache.Cbo.Part";
            public static readonly string CACHE_COMBO_BUWI_BUNRYU                                   = "Cache.Cbo.Buwi.Bunryu";
            public static readonly string CACHE_SCH_COMBO_GUMSA_KEY                                 = "Sch.ComboGumsa";
            public static readonly string CACHE_CPLS_COMBO_BARCODE                                  = "Cpls.ComboBarcode";
            public static readonly string CACHE_CPLS_COMBO_RESULT_FORM                              = "Cpls.CboResultForm";
            public static readonly string CACHE_CPLS_COMBO_SPCIAL_NAME                              = "Cpls.CboSpcialName";
            public static readonly string CACHE_CPLS_COMBO_IOGUBUN                                  = "Cpls.CboInoutGubun";
            public static readonly string CACHE_CPLS_CBO_UITAK                                      = "Cpls.Cpl7001Q01.Cbo.Uitak";
            public static readonly string CACHE_CPLS_CBO_PART                                       = "Cpls.Cpl7001Q02.Cbo.Part";
            public static readonly string CACHE_PFE_CBO_PART                                        = "Pfes.pfe7001Q01.Cbo.Part";
            public static readonly string CACHE_COMBO_ADM1110_GET_BY_COL_USER_GUBUN                 = "Cpls.ADM1110.GetUserGubun";
            public static readonly string CACHE_ADM3200_FWKACTOR                                    = "CPL2010U00.ADM3200.fwkActor";
            public static readonly string CACHE_NUR0102_CBOTIME                                     = "CPL2010U00.NUR0102.cboTime";
            public static readonly string CACHE_ADM3200_CBXACTOR                                    = "CPL2010U00.ADM3200.cbxActor";
            public static readonly string CACHE_CPL_CODE_VALUE                                      = "Cpls.code.value";
            public static readonly string CACHE_CPL_CBO_JANGBI_KEY                                  = "Cpls.Cbo.JangbiCode";
            public static readonly string CACHE_BASS_FWK_BUSEOGUBUN                                 = "Bass.Fwk.BuseoGubun";
            public static readonly string CACHE_BASS_XEDITGRIDCELL_19                               = "Bass.XEditGrid.InputGubun";
            public static readonly string CACHE_CHTS_XEDITGRIDCELL_SUSIK_GUBUN                      = "Chts.XEditGrid.SusikGubun";
            public static readonly string CACHE_CHTS_CBO_SUSIK_GUBUN                                = "Chts.Cbo.SusikGubun";
            public static readonly string CACHE_OCSACT_LAYCONSTANT_CONST                            = "Ocsact.Layconstant.Const";
            public static readonly string CACHE_OCSACT_LAYCONSTANT_ALARM                            = "Ocsact.Layconstant.Alarm";
            public static readonly string CACHE_OCSACT_CBO_SYSTEM                                   = "Ocsact.Cbo.System";
            public static readonly string CACHE_OCSACT_CBO_SYSTEM_AND_TIME                          = "Ocsact.Cbo.System.And.Time";
            public static readonly string CACHE_OCSACT_CBO_IO_GUBUN                                 = "Ocsact.Cbo.Io.Gubun";
            public static readonly string CACHE_CBO_SET_PART                                        = "Cache.Cbo.Set.Part";
            public static readonly string CACHE_BAS_CBO_HOSP_JIN_GUBUN                              = "BAS.Cbo.HospJinGubun";
            public static readonly string CACHE_BAS_CBO_BULYONG_SAYU                                = "BAS.Cbo.BulyongSayu";
            public static readonly string CACHE_OCS0132_SERVER_IP                                   = "Ocs0132.Server.Ip";
            public static readonly string CACHE_OCS0103U00_FIND_BOX_C                               = "Cache.Ocs0103U00.Find.Box.C";
            public static readonly string CACHE_OCS0103U00_FIND_BOX_D                               = "Cache.Ocs0103U00.Find.Box.D";
            public static readonly string CACHE_OCS0103U00_CBO_RESULT_GUBUN                         = "Cache.Cbo.Result.Gubun";
            public static readonly string CACHE_OCS0103U00_CBO_IF_INPUT_CONTROL                     = "Cache.Cbo.If.Input.Control";
            public static readonly string CACHE_OCS0103U00_CBO_EMERGENCY                            = "Cache.Cbo.Emergency";
            public static readonly string CACHE_OCS0103U00_CBO_SUBUL_CONVERT_GUBUN                  = "Cache.Cbo.Subul.Convert.Gubun";
            public static readonly string CACHE_OCS0103U00_CBO_WONYOI_ORDER_YN                      = "Cache.Cbo.Wonyoi.Order.Yn";
            public static readonly string CACHE_OCS0103U00_CBO_DV_TIME                              = "Cache.Cbo.Dv.Time";
            public static readonly string CACHE_OCS0103U00_CBO_INPUT_CONTROL                        = "Cache.Cbo.Input.Control";
            public static readonly string CACHE_OCS0103U00_CBO_ORDER_GUBUN                          = "Cache.Cbo.Order.Gubun";
            public static readonly string CACHE_OCS0103U00_CBO_SLIP_GUBUN                           = "Cache.Cbo.Slip.Gubun";
            public static readonly string CACHE_OCS_CBO_OCS_ACT_SYSTEM                              = "OCS.Cbo.OcsActSystem";
            public static readonly string CACHE_ADM107U_FWK_USER_ID                                 = "Cache.Adm107U.Fwk.User.Id";
            public static readonly string CACHE_COMBO_ADM1110_GET_BY_COL_USER_GUBUN_ALL             = "Adma.ADM1110.GetUserGubun.GetAll";
            public static readonly string CACHE_COMBO_DOCTOR_GRADE                                  = "Adma.CboDoctorGrade";
            public static readonly string CACHE_COMBO_USER_GROUP                                    = "Adma.CboUserGroup";
            public static readonly string CACHE_OCS_COMBO_ORD_DANUI_GET_ALL_KEYS                    = "OCSO.Cbo.OrdDanuiAll";
            public static readonly string CACHE_OCS_COMBO_NU_GROUP_ALL_KEYS                         = "BASS.Cbo.NuGroup";
            public static readonly string CACHE_CBO_ADMIN_GUBUN                                     = "BAS.AdminGubun";
            public static readonly string CACHE_CBO_NURI_NUR0101                                    = "NUR.Combo.Nur0101";
            public static readonly string CACHE_CBO_DOCTOR_CODE_PORTABLEYN                          = "OCS.Combo.Ocs1003Q09.LoadComboDataSource";
            public static readonly string MAKE_INPUT_GUBUN_TAB_NR_KEY                               = "MakeInputGubunTab.NR";
            public static readonly string MAKE_INPUT_GUBUN_TAB_D0_KEY                               = "MakeInputGubunTab.D0";
            public static readonly string CACHE_CBO_DATASOURCE_BY_CODE_AND_INPUT_TAB                = "OCS.Ocs1003P01.DataSourceByCodeAndInputTab";
            public static readonly string CACHE_OCS0204Q00_CBO_GWA                                  = "Ocsa.Ocs0204q00.CboGwa";
            public static readonly string CACHE_PHY2001U04_CBO_JUBSU_GUBUN                          = "Cache.Phy2001U04.Cbo.Jubsu.Gubun";
            public static readonly string CACHE_PHY2001U04_GRID_CBO_JUBSU_GUBUN                     = "Cache.Phy2001U04.Grid.Cbo.Jubsu.Gubun";
            public static readonly string CACHE_PHY8002U00_PHY_REHA                                 = "Phys.PHY8002U00.phyReha";
            public static readonly string CACHE_PHY8002U00_PHY_OT                                   = "Phys.PHY8002U00.phyOT";
            public static readonly string CACHE_PHY8002U00_PHY_PT                                   = "Phys.PHY8002U00.phyPT";
            public static readonly string CACHE_PHY8002U00_PHY_ST                                   = "Phys.PHY8002U00.phyST";
            public static readonly string CACHE_INJS_INJ1001U01_COMBO_LIST_SORT_KEY                 = "Cache.Injs.INJ1001U01.Combo.List.Sort.Key";
            public static readonly string CACHE_NUR2001U04_CBO_GWA                                  = "Nuro.NUR2001U04.cboGwa";
            public static readonly string CACHE_FW_PACOMMENT_LAYCMMT_GUBUN                          = "Fw.PaComment.LayCmmt.Gubun";
            public static readonly string CACHE_CBO_SEX                                             = "Nuro.LoadCBoSex";
            public static readonly string CACHE_CBO_MAKE_GWA                                        = "Nuro.LoadCboMakeGwa";
            public static readonly string CACHE_CF_FORM_IL_GWA_LCHANGE_CBO_NALSU                    = "CF_Form.Il.gwa.lChange.Cbo.Nalsu";
            public static readonly string CACHE_CF_FORM_GET_SELECT_HOPEDATE_CBO_NALSU               = "CF.Form.Get.Select.HopeDate.Cbo.Nalsu";
            public static readonly string CACHE_COMMON_ADMIN_YN                                     = "Common.Admin.Yn";
            public static readonly string CACHE_COMMON_ADMIN_NO_CHECK                               = "Common.Admin.NoCheck";
            public static readonly string CACHE_COMMON_ADMIN_LOGIN_TIME                             = "Common.Admin.LoginTime";
            public static readonly string CACHE_COMMON_ID                                           = "Common.Id";
            public static readonly string CACHE_COMMON_MSGSYS                                       = "Common.Msgsys";
            public static readonly string CACHE_COMMON_ADMM_PREFIX                                  = "Common.Admm.";
            public static readonly string CACHE_COMMON_MONITOR_PREFIX                               = "Common.Monitor.";
            public static readonly string CACHE_COMMON_DOCKING_PREFIX                               = "Common.Docking.";
            public static readonly string CACHE_COMMON_USER_PREFIX                                  = "Common.User.";
            public static readonly string CACHE_USER_ID                                             = "User.Id";
            public static readonly string CACHE_CPLMASTERUPLOADER_CBO_MST_TYPE                      = "Cache.Cplmasteruploader.Cbo.Mst.Type";
            public static readonly string CACHE_OCSEMR_BTN_EMR_YN                                   = "Cache.Ocsemr.Btn.Emr.Yn";
            public static readonly string CACHE_OCSEMR_BTN_USE_YN                                   = "Cache.Ocsemr.Btn.Use.Yn";
            public static readonly string CACHE_OCSEMR_CBO_INPUT_TAB                                = "Cache_Ocsemr_Cbo_Input_Tab";
            public static readonly string CACHE_DEFAULT_HOSP_CODE                                   = "Cache.Default.HospCode";
            public static readonly string CACHE_DEFAULT_HOSP_NAME                                   = "Cache.Default.HospName";
        }
    }

}
