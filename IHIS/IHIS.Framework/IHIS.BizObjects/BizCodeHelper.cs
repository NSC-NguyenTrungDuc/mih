using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design.Serialization;
using System.Security;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;

namespace IHIS.Framework
{
	/// <summary>
	/// BizCodeHelper에 대한 요약 설명입니다.
	/// Business Logic이 포함된 각종코드(기준정보,진료과,병동,의사리스트,간호사리스트 등의 정보)의 리스트를
	/// 조회해주는 Helper Class
	/// </summary>
	public class BizCodeHelper
	{
		private static MultiLayout layCodeList = new MultiLayout();
	    private const string CACHE_BIZCODEHELPER_BUSEOCOMBO_GWA_KEY = "BizCodeHelper.combo.gwa";

		static BizCodeHelper()
		{
			//CodeList는 Code, CodeName 컬럼을 가지는 Layout
			MultiLayoutItem item = new MultiLayoutItem();
			item.DataName = "Code";
			item.DataType = DataType.String;
			layCodeList.LayoutItems.Add(item);
			item = new MultiLayoutItem();
			item.DataName = "CodeName";
			item.DataType = DataType.String;
			layCodeList.LayoutItems.Add(item);
			layCodeList.InitializeLayoutTable();
		}
		public static MultiLayout GetBaseInfoList(string codeType)
		{
			//기존 Data Reset
			layCodeList.Reset();
            layCodeList.ParamList = new List<string>(new String[] { "f_code_type" });
		    layCodeList.ExecuteQuery = BaseInfoList;

			//조회 SQL SET (BAS0102 : 기준정보 의 해당 CODE TYPE 데이타 GET)
//            layCodeList.QuerySQL = @"SELECT A.CODE, A.CODE_NAME 
//                                       FROM BAS0102 A
//                                      WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
//                                        AND A.CODE_TYPE = :f_code_type
//                                    ";

            

			//Bind변수 SET
			layCodeList.SetBindVarValue("f_code_type", codeType);

			if (!layCodeList.QueryLayout(true)) //조회실패
				XMessageBox.Show(Service.ErrMsg, "GetBaseInfoList");
			return layCodeList;
		}




        private static IList<object[]> BaseInfoList(BindVarCollection varList)
        {
            List<object[]> data = new List<object[]>();

            ComboListByCodeTypeArgs args = new ComboListByCodeTypeArgs();
            args.CodeType = varList["f_code_type"].VarValue;
            args.IsAll = false;

            ComboListItemResult result = CloudService.Instance
                    .Submit<ComboListItemResult, ComboListByCodeTypeArgs>(args);

            if (result != null && result.ListItemInfos .Count > 0)
            {
                foreach (ComboListItemInfo item in result.ListItemInfos)
                {
                    data.Add(new object[]
                    {
                        item.Code,
                        item.CodeName 
                    });
                }
            }

            return data;
        }

		public static MultiLayout GetBuseoList(BuseoType buseoGubun)
		{
			//기존 Data Reset
			layCodeList.Reset();
            layCodeList.ParamList = new List<string>(new String[] { "f_buseo_gubun" });
            layCodeList.ExecuteQuery = GetBuseoExecuteQuery;
			//조회 SQL SET
			//f_buseo_gubun : 부서구분. 1.진료과,2.병동,3.진료지원부서,4.행정부서,5.외래응급,6.입원응급,9.일반부서
            //layCodeList.QuerySQL
            //    = "SELECT A.BUSEO_CODE BUSEO_CODE, A.BUSEO_NAME BUSEO_NAME"
            //    + "  FROM VW_GWA_NAME A"
            //    + " WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode +"'"
            //    + "   AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE"
            //    + "   AND A.BUSEO_GUBUN = :f_buseo_gubun";
			
			//Bind변수 SET
			layCodeList.SetBindVarValue("f_buseo_gubun", ((int) buseoGubun).ToString());
			if (!layCodeList.QueryLayout(true)) //조회실패
				XMessageBox.Show(Service.ErrMsg, "GetBuseoList");

			return layCodeList;
		}

	    private static IList<object[]> GetBuseoExecuteQuery(BindVarCollection varList)
	    {
            List<object[]> data = new List<object[]>();
	        
	        BuseoListArgs args = new BuseoListArgs();
	        args.BuseoGubun = varList["f_buseo_gubun"].VarValue;
//            BuseoListResult res = CloudService.Instance.Submit<BuseoListResult, BuseoListArgs>(args);
            BuseoListResult res = CacheService.Instance.Get<BuseoListArgs, BuseoListResult>(args);

	        if (res != null && res.BuseoList.Count > 0)
	        {
	            foreach (BuseoInfo item in res.BuseoList)
	            {
                    data.Add(new object[]
                    {
                        item.BuseoCode,
                        item.BuseoName
                    });    
	            }
	        }

	        return data;
	    }

	    /// <summary>
		/// 현재일 기준의 해당부서Type과 부서코드의 사용자리스트를 Return합니다.
		/// </summary>
		/// <param name="personType"></param>
		/// <param name="buseoCode"></param>
		/// <returns></returns>
		public static MultiLayout GetPersonList(XPersonComboType personType, string buseoCode)
		{
			return GetPersonList(personType, buseoCode, EnvironInfo.GetSysDate());
		}
		public static MultiLayout GetPersonList(XPersonComboType personType, string buseoCode, string baseDate)
		{
			//기존 Data Reset
			layCodeList.Reset();

			string msg = "";
			//string baseDate는 YYYYMMDD OR YYYY/MM/DD형도 가능함
			DateTime baseDt = DateTime.Today;
			if (TypeCheck.IsDateTime(baseDate))
			{
				baseDt = DateTime.Parse(baseDate);
			}
			else if (baseDate.Length == 8)
			{
				string dateStr = baseDate.Substring(0,4) + "/" + baseDate.Substring(4,2) + "/" + baseDate.Substring(6);
				if (!TypeCheck.IsDateTime(dateStr))
				{
					msg = (NetInfo.Language == LangMode.Ko ? "[GetPersonList]기준일을 잘못 지정하셨습니다.[" + baseDate + "]"
						: "[GetPersonList] 基準日の指定が間違いました。[" + baseDate + "]");
					XMessageBox.Show(msg);
					return layCodeList;
				}
				baseDt = DateTime.Parse(dateStr);
			}
			else
			{
				msg = (NetInfo.Language == LangMode.Ko ? "[GetPersonList]기준일을 잘못 지정하셨습니다.[" + baseDate + "]"
					: "[GetPersonList] 基準日の指定が間違いました。[" + baseDate + "]");
				XMessageBox.Show(msg);
				return layCodeList;
			}

			return GetPersonList(personType, buseoCode, baseDt);
			
		}
		public static MultiLayout GetPersonList(XPersonComboType personType, string buseoCode, DateTime baseDate)
		{
			//기존 Data Reset
			layCodeList.Reset();

			//부서코드 입력여부 확인
			if (buseoCode.Trim() == "")
			{
				string msg = (NetInfo.Language == LangMode.Ko ? "[GetPersonList]부서코드를 입력하십시오"
					: "[GetPersonList]部署コードを 入力してください。");
				XMessageBox.Show(msg);
				return layCodeList;
			}

			//PersonType에 따라 SQL문 다르게 설정한다.
			if (personType == XPersonComboType.Doctor) //의사 (BAS0270)
			{
				layCodeList.QuerySQL
					= "SELECT A.DOCTOR PERSON_ID, A.DOCTOR_NAME PERSON_NAME"
					+ "  FROM BAS0270 A"
                    + " WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'"
                    + "   AND A.DOCTOR_GWA = :f_buseo_code"
                    + "   AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE"
					+ " ORDER BY 1";
			}
			else //간호사 (NRS0110 부서별 간호 근무인원 관리)
			{
				layCodeList.QuerySQL
					= "SELECT A.SABUN PERSON_ID, A.SABUN_NAME PERSON_NAME"
					+ "  FROM NRS0110 A"
                    + " WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'"
                    + "   AND A.BUSEO_CODE = :f_buseo_code"
                    + "   AND :f_base_dt BETWEEN A.FROM_DATE AND A.END_DATE"
					+ " ORDER BY 1";
			}
			//Bind변수 SET (f_buseo_code, f_base_dt)
			layCodeList.SetBindVarValue("f_buseo_code", buseoCode);
			layCodeList.SetBindVarValue("f_base_dt", baseDate.ToString("yyyy/MM/dd").Replace("-","/")); //YYYY/MM/DD
			if (!layCodeList.QueryLayout(true))  //실패시 에러 MSG Display
				XMessageBox.Show(Service.ErrMsg, "GetPersonList");
			return layCodeList;
		}

		public static string GetStandardBunHo(string bunHo)
		{
			//입력된 일련번호의 환자번호(543을 9자리 환자번호 000000543)으로 변경하여 Return
			//데이타 Conversion 관계로 일단 8자리로 반영함
			//2006.01.26 확정 9자리로 변경처리
			//2007/01/24 환자번호 길이정보는 각 병원마다 다르므로 서버의 IFC/comlib/appcfg/ifc.cfg에서 관리하고
			//이를 EnvironInfo의 속성으로 관리하여 그 정보를 가지로 Padding 처리한다.
			//return bunHo.PadLeft(9, '0');
			return bunHo.PadLeft(EnvironInfo.BunhoLength, '0');
		}

        public static void ApplyColumnFont(IHIS.Framework.XEditGridCell xEditGridCell)
        {
            xEditGridCell.AlterateRowFont = Service.COMMON_FONT;
            xEditGridCell.HeaderFont = Service.COMMON_FONT;
            xEditGridCell.RowFont = Service.COMMON_FONT;
        }

        public static void ApplyCommonFont(XEditGrid xEditGrid)
        {
            ((System.ComponentModel.ISupportInitialize)(xEditGrid)).BeginInit();
            foreach (XGridCell gridCell in xEditGrid.CellInfos)
            {
                gridCell.AlterateRowFont = Service.COMMON_FONT;
                gridCell.HeaderFont = Service.COMMON_FONT;
                gridCell.RowFont = Service.COMMON_FONT;
            }

            foreach (XGridHeader xGridHeader in xEditGrid.HeaderInfos)
            {
                xGridHeader.HeaderFont = Service.COMMON_FONT;
            }

            ((System.ComponentModel.ISupportInitialize)(xEditGrid)).EndInit();
        }
        
	}

	#region enum
	/// <summary>
	/// 사용자의 종류 (1.Doctor, 2.Nurse,, 필요시 계속추가함)
	/// </summary>
	[Serializable]
	public enum XPersonComboType
	{
		Doctor = 1,
		Nurse  = 2
	}
	#endregion
}
