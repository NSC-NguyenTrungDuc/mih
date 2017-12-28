using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.NURI
{
    public partial class OCS2005R02 : IHIS.Framework.XScreen
    {
        public OCS2005R02()
        {
            InitializeComponent();
        }

        #region Screen 변수 

        private bool mIsPrintMode = false;
        private string mPkinp1001 = "";
        private string mQueryMode = "K";     // 'K'끼로 조회, 'C'코드로 조회
        private string mDirectGubun = "";
        private string mDirectCode = "";

        #endregion

        #region SCreen Load

        private void OCS2005R02_Load(object sender, EventArgs e)
        {
            if (this.OpenParam != null)
            {
                if (this.OpenParam.Contains("date"))
                {
                    this.dtpQryDate.SetDataValue(this.OpenParam["date"].ToString());
                }
                else
                {
                    this.dtpQryDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
                }

                if (this.OpenParam.Contains("bunho"))
                {
                    this.fbxBunho.SetDataValue(this.OpenParam["bunho"].ToString());
                }

                if (this.OpenParam.Contains("pkinp1001"))
                {
                    this.mPkinp1001 = this.OpenParam["pkinp1001"].ToString();
                }

                if (this.OpenParam.Contains("ki_gubun"))
                {
                    this.cboKiGubun.SetDataValue(this.OpenParam["ki_gubun"].ToString());
                }
                else
                {
                    if (this.OpenParam.Contains("direct_gubun"))
                    {
                        this.mDirectGubun = this.OpenParam["direct_gubun"].ToString();
                    }

                    if (this.OpenParam.Contains("direct_code"))
                    {
                        this.mDirectCode = this.OpenParam["direct_code"].ToString();
                        this.mQueryMode = "C";
                    }
                }

                if (this.OpenParam.Contains("print_mode"))
                {
                    this.mIsPrintMode = (bool)this.OpenParam["print_mode"];
                }

            }
            else
            {
                this.dtpQryDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
                this.cboKiGubun.SelectedIndex = 0;
            }

            if (this.mIsPrintMode && this.mPkinp1001 != "")
            {
                this.ParentForm.WindowState = FormWindowState.Minimized;

                this.btnList.PerformClick(FunctionType.Query);

                this.btnList.PerformClick(FunctionType.Print);

                this.btnList.PerformClick(FunctionType.Close);
            }
        }

        #endregion

        private string GetQuerySql()
        {
            string returnSql = "";

            if (this.mQueryMode == "K")     // 끼구분으로 조회
            {
                returnSql = @"SELECT A.BUNHO                                      BUNHO       ,
       A.FKINP1001                                  FKINP1001   ,
       C.SUNAME                                     SUNAME      ,
       C.SUNAME2                                    SUNAME2     ,
       FN_BAS_TO_JAPAN_DATE_CONVERT('1', C.BIRTH)   BIRTH       ,
       FN_BAS_LOAD_AGE(:f_order_date, C.BIRTH, 'XXX') AGE       ,
       FN_BAS_LOAD_CODE_NAME('SEX', C.SEX)            SEX       ,
       F.HEIGHT                                     HEIGHT      ,
       F.WEIGHT                                     WEIGHT      ,
       SUBSTR(TO_CHAR(B.IPWON_DATE, 'YYYYMMDD'), 1, 4) || '年' ||  SUBSTR(TO_CHAR(B.IPWON_DATE, 'YYYYMMDD'), 5, 2) || '月' ||
       SUBSTR(TO_CHAR(B.IPWON_DATE, 'YYYYMMDD'), 7, 2) || '日'  IPWON_DATE  ,
       B.GWA                                        GWA         ,
       FN_BAS_LOAD_GWA_NAME(B.GWA, NVL(A.ORDER_DATE, A.DRT_FROM_DATE))   GWA_NAME ,
       B.HO_DONG1                                   HO_DONG     ,
       E.GWA_NAME                                   HO_DONG_NAME,
       B.HO_CODE1 || ' 号室'                        HO_CODE     ,
       D.NUR_MD_NAME                                SIK_GUBUN   ,
       CASE WHEN SUBSTR(A.DIRECT_CODE, 3, 1) = '0'
            THEN DECODE(A.DIRECT_CONT1, '06', H.NUR_SO_NAME || ' ( ' || A.JUSIK_YUDONG || ' ) ', H.NUR_SO_NAME)
            WHEN SUBSTR(A.DIRECT_CODE, 3, 1) = '1'
            THEN DECODE(A.DIRECT_CONT1, '99', H.NUR_SO_NAME || ' ( ' || A.JUSIK_YUDONG || ' ) ', H.NUR_SO_NAME)
            ELSE H.NUR_SO_NAME
       END    AS JUSIK ,
       DECODE(A.DIRECT_CONT2, '06', I.NUR_SO_NAME || ' ( ' || A.BUSIK_YUDONG || ' ) ', I.NUR_SO_NAME) AS BUSIK ,
       
       SUBSTR(TO_CHAR(A.DRT_FROM_DATE, 'YYYYMMDD'), 1, 4) || '年' ||  SUBSTR(TO_CHAR(A.DRT_FROM_DATE, 'YYYYMMDD'), 5, 2) || '月' ||
       SUBSTR(TO_CHAR(A.DRT_FROM_DATE, 'YYYYMMDD'), 7, 2) || '日'          DRT_FROM_DATE,
       
       DECODE(A.DRT_TO_DATE, NULL, '継続', SUBSTR(TO_CHAR(A.DRT_TO_DATE, 'YYYYMMDD'), 1, 4) || '年' ||  SUBSTR(TO_CHAR(A.DRT_TO_DATE,  'YYYYMMDD'), 5, 2) || '月' ||
       SUBSTR(TO_CHAR(A.DRT_TO_DATE, 'YYYYMMDD'), 7, 2) || '日' )          DRT_TO_DATE ,
       
       SUBSTR(:f_from_date, 1, 4) || '年' ||  SUBSTR(:f_from_date, 5, 2) || '月' ||
       SUBSTR(:f_from_date, 7, 2) || '日'           ORDER_DATE ,
       
       G.PRE_MODIFIER_NAME || SANG_NAME || POST_MODIFIER_NAME SANG_NAME, 
       A.JORI_TYPE                                  JORI_TYPE   ,
       A.KUMJISIK                                   KUMJISIK    ,
       A.DIRECT_TEXT                                DIRECT_TEXT
  FROM OCS2005 A    ,
       INP1001 B    ,
       OUT0101 C    ,
       NUR0111 D    ,
       BAS0260 E    ,
     ( SELECT A.HEIGHT, A.WEIGHT, A.BUNHO
         FROM NUR7001 A
        WHERE A.BUNHO = :f_bunho
          AND TO_CHAR(A.MEASURE_DATE, 'YYYYMMDD') || A.MEASURE_TIME = ( SELECT MAX(TO_CHAR(B.MEASURE_DATE, 'YYYYMMDD') || B.MEASURE_TIME)
                                                                          FROM NUR7001 B
                                                                         WHERE B.BUNHO = A.BUNHO )
     ) F            ,
       OUTSANG G    ,
       NUR0112 H    ,
       NUR0114 I
 WHERE :f_query_mode = 'K'
   AND A.BUNHO       = :f_bunho
   AND A.FKINP1001   = :f_fkinp1001
   AND :f_from_date BETWEEN NVL(A.DRT_FROM_DATE, A.ORDER_DATE)
                                AND DECODE(A.DRT_FROM_DATE, NULL, A.ORDER_DATE, NVL(A.DRT_TO_DATE, TO_DATE('99981231', 'YYYYMMDD')))
   AND A.DIRECT_GUBUN = '02'
   AND (
          ( :f_ki_gubun = '1' AND A.DIRECT_CODE IN ( '2001','2011','2021' ) )
          OR
          ( :f_ki_gubun = '2' AND A.DIRECT_CODE IN ( '2002','2012','2022' ) )
          OR
          ( :f_ki_gubun = '3' AND A.DIRECT_CODE IN ( '2003','2013','2023' ) )
          OR
          ( :f_ki_gubun IS NULL AND A.DIRECT_CODE IN ( '2001','2011','2021', '2002','2012','2022', '2003','2013','2023' ) )
       )
   AND A.BUNHO       = B.BUNHO
   AND A.FKINP1001   = B.PKINP1001
   AND A.HOSP_CODE   = B.HOSP_CODE
   AND A.BUNHO       = C.BUNHO
   AND A.HOSP_CODE   = C.HOSP_CODE
   AND A.DIRECT_GUBUN = D.NUR_GR_CODE
   AND A.DIRECT_CODE = D.NUR_MD_CODE
   AND A.HOSP_CODE   = D.HOSP_CODE
   AND B.HO_DONG1    = E.GWA
   AND B.HOSP_CODE   = E.HOSP_CODE
   AND :f_from_date BETWEEN E.START_DATE AND E.END_DATE
   AND A.BUNHO       = F.BUNHO(+)
   AND B.BUNHO       = G.BUNHO(+)
   AND B.GWA         = G.GWA(+)
   AND B.HOSP_CODE   = G.HOSP_CODE(+)
   AND G.JU_SANG_YN(+) = 'Y'
   
   AND A.DIRECT_GUBUN = H.NUR_GR_CODE(+)
   AND A.DIRECT_CODE  = H.NUR_MD_CODE(+)
   AND A.DIRECT_CONT1 = H.NUR_SO_CODE(+)
   AND A.DIRECT_GUBUN = I.NUR_GR_CODE(+)
   AND A.DIRECT_CODE  = I.NUR_MD_CODE(+)
   AND A.DIRECT_CONT1 = I.NUR_SO_CODE(+)";
            }
            else // 코드로 조회
            {
                returnSql = @"SELECT A.BUNHO                                      BUNHO       ,
       A.FKINP1001                                  FKINP1001   ,
       C.SUNAME                                     SUNAME      ,
       C.SUNAME2                                    SUNAME2     ,
       FN_BAS_TO_JAPAN_DATE_CONVERT('1', C.BIRTH)   BIRTH       ,
       FN_BAS_LOAD_AGE(:f_order_date, C.BIRTH, 'XXX') AGE       ,
       FN_BAS_LOAD_CODE_NAME('SEX', C.SEX)            SEX       ,
       F.HEIGHT                                     HEIGHT      ,
       F.WEIGHT                                     WEIGHT      ,
       SUBSTR(TO_CHAR(B.IPWON_DATE, 'YYYYMMDD'), 1, 4) || '年' ||  SUBSTR(TO_CHAR(B.IPWON_DATE, 'YYYYMMDD'), 5, 2) || '月' ||
       SUBSTR(TO_CHAR(B.IPWON_DATE, 'YYYYMMDD'), 7, 2) || '日'  IPWON_DATE  ,
       B.GWA                                        GWA         ,
       FN_BAS_LOAD_GWA_NAME(B.GWA, NVL(A.ORDER_DATE, A.DRT_FROM_DATE))   GWA_NAME ,
       B.HO_DONG1                                   HO_DONG     ,
       E.GWA_NAME                                   HO_DONG_NAME,
       B.HO_CODE1 || ' 号室'                        HO_CODE     ,
       D.NUR_MD_NAME                                SIK_GUBUN   ,
       CASE WHEN SUBSTR(A.DIRECT_CODE, 3, 1) = '0'
            THEN DECODE(A.DIRECT_CONT1, '06', H.NUR_SO_NAME || ' ( ' || A.JUSIK_YUDONG || ' ) ', H.NUR_SO_NAME)
            WHEN SUBSTR(A.DIRECT_CODE, 3, 1) = '1'
            THEN DECODE(A.DIRECT_CONT1, '99', H.NUR_SO_NAME || ' ( ' || A.JUSIK_YUDONG || ' ) ', H.NUR_SO_NAME)
            ELSE H.NUR_SO_NAME
       END    AS JUSIK ,
       DECODE(A.DIRECT_CONT2, '06', I.NUR_SO_NAME || ' ( ' || A.BUSIK_YUDONG || ' ) ', I.NUR_SO_NAME) AS BUSIK ,
       
       SUBSTR(TO_CHAR(A.DRT_FROM_DATE, 'YYYYMMDD'), 1, 4) || '年' ||  SUBSTR(TO_CHAR(A.DRT_FROM_DATE, 'YYYYMMDD'), 5, 2) || '月' ||
       SUBSTR(TO_CHAR(A.DRT_FROM_DATE, 'YYYYMMDD'), 7, 2) || '日'          DRT_FROM_DATE,
       
       DECODE(A.DRT_TO_DATE, NULL, '継続', SUBSTR(TO_CHAR(A.DRT_TO_DATE, 'YYYYMMDD'), 1, 4) || '年' ||  SUBSTR(TO_CHAR(A.DRT_TO_DATE,  'YYYYMMDD'), 5, 2) || '月' ||
       SUBSTR(TO_CHAR(A.DRT_TO_DATE, 'YYYYMMDD'), 7, 2) || '日' )          DRT_TO_DATE ,
       
       SUBSTR(:f_from_date, 1, 4) || '年' ||  SUBSTR(:f_from_date, 5, 2) || '月' ||
       SUBSTR(:f_from_date, 7, 2) || '日'           ORDER_DATE ,
       
       G.PRE_MODIFIER_NAME || SANG_NAME || POST_MODIFIER_NAME SANG_NAME, 
       A.JORI_TYPE                                  JORI_TYPE   ,
       A.KUMJISIK                                   KUMJISIK    ,
       A.DIRECT_TEXT                                DIRECT_TEXT
  FROM OCS2005 A    ,
       INP1001 B    ,
       OUT0101 C    ,
       NUR0111 D    ,
       BAS0260 E    ,
     ( SELECT A.HEIGHT, A.WEIGHT, A.BUNHO
         FROM NUR7001 A
        WHERE A.BUNHO = :f_bunho
          AND TO_CHAR(A.MEASURE_DATE, 'YYYYMMDD') || A.MEASURE_TIME = ( SELECT MAX(TO_CHAR(B.MEASURE_DATE, 'YYYYMMDD') || B.MEASURE_TIME)
                                                                          FROM NUR7001 B
                                                                         WHERE B.BUNHO = A.BUNHO )
     ) F            ,
       OUTSANG G    ,
       NUR0112 H    ,
       NUR0114 I
 WHERE :f_query_mode = 'C'
   AND A.BUNHO       = :f_bunho
   AND A.FKINP1001   = :f_fkinp1001
   AND :f_from_date BETWEEN NVL(A.DRT_FROM_DATE, A.ORDER_DATE)
                                AND DECODE(A.DRT_FROM_DATE, NULL, A.ORDER_DATE, NVL(A.DRT_TO_DATE, TO_DATE('99981231', 'YYYYMMDD')))
   AND A.DIRECT_GUBUN = '02'
   AND A.DIRECT_CODE  = :f_direct_code
   AND A.BUNHO       = B.BUNHO
   AND A.FKINP1001   = B.PKINP1001
   AND A.HOSP_CODE   = B.HOSP_CODE
   AND A.BUNHO       = C.BUNHO
   AND A.HOSP_CODE   = C.HOSP_CODE
   AND A.DIRECT_GUBUN = D.NUR_GR_CODE
   AND A.DIRECT_CODE = D.NUR_MD_CODE
   AND A.HOSP_CODE   = D.HOSP_CODE
   AND B.HO_DONG1    = E.GWA
   AND B.HOSP_CODE   = E.HOSP_CODE
   AND :f_from_date BETWEEN E.START_DATE AND E.END_DATE
   AND A.BUNHO       = F.BUNHO(+)
   AND B.BUNHO       = G.BUNHO(+)
   AND B.GWA         = G.GWA(+)
   AND B.HOSP_CODE   = G.HOSP_CODE(+)
   AND G.JU_SANG_YN(+) = 'Y' 
   
   AND A.DIRECT_GUBUN = H.NUR_GR_CODE(+)
   AND A.DIRECT_CODE  = H.NUR_MD_CODE(+)
   AND A.DIRECT_CONT1 = H.NUR_SO_CODE(+)
   AND A.DIRECT_GUBUN = I.NUR_GR_CODE(+)
   AND A.DIRECT_CODE  = I.NUR_MD_CODE(+)
   AND A.DIRECT_CONT1 = I.NUR_SO_CODE(+)";
            }

            return returnSql;
        }

        private void LoadData()
        {
            this.layData.QuerySQL = this.GetQuerySql();

            this.layData.SetBindVarValue("f_query_mode",  this.mQueryMode);
            this.layData.SetBindVarValue("f_bunho",       this.fbxBunho.GetDataValue());
            this.layData.SetBindVarValue("f_fkinp1001",   this.mPkinp1001);
            this.layData.SetBindVarValue("f_from_date",   this.dtpQryDate.GetDataValue().Replace("/", "").Replace("-", ""));
            this.layData.SetBindVarValue("f_ki_gubun",    this.cboKiGubun.GetDataValue());
            this.layData.SetBindVarValue("f_direct_code", this.mDirectCode);

            this.layData.QueryLayout(true);

            this.dwPrint.Reset();
            if (layData.RowCount > 0)
            {
                this.dwPrint.FillData(this.layData.LayoutTable);
            }
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    this.AcceptData();

                    e.IsBaseCall = false;

                    this.LoadData();

                    break;

                case FunctionType.Print:

                    this.AcceptData();

                    e.IsBaseCall = false;

                    if (this.layData.RowCount <= 0) return;

                    try
                    {
                        this.dwPrint.Print();
                    }
                    catch
                    {
                    }

                    break;
            }
        }
    }
}