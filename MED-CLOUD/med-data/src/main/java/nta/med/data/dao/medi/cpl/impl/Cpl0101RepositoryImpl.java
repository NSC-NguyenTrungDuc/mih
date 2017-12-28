package nta.med.data.dao.medi.cpl.impl;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl0101RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.cpls.*;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * @author dainguyen.
 */
public class Cpl0101RepositoryImpl implements Cpl0101RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<CplCPL0104U00GrdMasterCPL0104ListItemInfo> getCPL0104U00GrdMaster(String hospCode, String hangmogCode, 
			String specimenCode,String emergency, String gumsaName,Integer startNum, Integer endNum) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.HANGMOG_CODE                                                        ");
		sql.append(" , A.SPECIMEN_CODE                                                            ");
		sql.append(" , B.CODE_NAME                                                                ");
		sql.append(" , A.EMERGENCY                                                                ");
		sql.append(" , A.GUMSA_NAME                                                               ");
		sql.append(" FROM CPL0109 B                                                               ");
		sql.append(" , CPL0101 A                                                                  ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code                                          ");
		sql.append(" AND A.SYSTEM_GUBUN = 'CPL'                                                   ");
		sql.append(" AND A.HANGMOG_CODE    LIKE CONCAT('%',IFNULL(:f_hangmog_code,''),'%')        ");
		sql.append(" AND A.SPECIMEN_CODE   LIKE CONCAT('%',IFNULL(:f_specimen_code,''),'%')       ");
		sql.append(" AND A.EMERGENCY       LIKE CONCAT('%',IFNULL(:f_emergency,''),'%')           ");
		sql.append(" AND A.GUMSA_NAME      LIKE CONCAT('%',IFNULL(:f_gumsa_name,''),'%')          ");
		sql.append(" AND B.CODE_TYPE    = '04'                                                    ");
		sql.append(" AND B.HOSP_CODE    = A.HOSP_CODE                                             ");
		sql.append(" AND B.CODE         = A.SPECIMEN_CODE                                         ");
		sql.append(" ORDER BY 1,2,3                                                               ");
		if(endNum != 0){
			sql.append(" LIMIT :startNum, :endNum                                                 ");
		}
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_code", hangmogCode);
		query.setParameter("f_specimen_code", specimenCode);
		query.setParameter("f_emergency", emergency);
		query.setParameter("f_gumsa_name", gumsaName);
		if(endNum != 0){
			query.setParameter("startNum", startNum);
			query.setParameter("endNum", endNum);
		}
		List<CplCPL0104U00GrdMasterCPL0104ListItemInfo> listGrdMaster= new JpaResultMapper().list(query, CplCPL0104U00GrdMasterCPL0104ListItemInfo.class);
		return listGrdMaster;
	}

	@Override
	public List<CPL0106U00FwkGumsaListItemInfo> getCPL0106U00FwkGumsaListItemInfo(String hospCode, String language, String find1, boolean isLike) {
		StringBuilder sql= new StringBuilder();
		sql.append("SELECT A.HANGMOG_CODE                                             ");
		sql.append("     , A.SPECIMEN_CODE                                            ");
		sql.append("     , Z.CODE_NAME SPECIMEN_NAME                                  ");
		sql.append("     , A.EMERGENCY                                                ");
		sql.append("     , A.GUMSA_NAME                                               ");
		sql.append("  FROM CPL0101 A LEFT JOIN CPL0109 Z ON Z.HOSP_CODE = A.HOSP_CODE ");
		sql.append("   AND Z.CODE_TYPE = '04'                                         ");
		sql.append("   AND Z.CODE      = A.SPECIMEN_CODE                              ");
		sql.append("   AND Z.LANGUAGE  = :language                                    ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode                                    ");
		if(!StringUtils.isEmpty(find1)) {
			if(isLike)
				sql.append("   AND A.HANGMOG_CODE LIKE CONCAT('%',:find1 ,'%')        ");
			else 
				sql.append("   AND A.HANGMOG_CODE = :find1							  ");
		}
		sql.append(" ORDER BY A.HANGMOG_CODE                                          ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		if(!StringUtils.isEmpty(find1)) {
			query.setParameter("find1", find1);
		}
		List<CPL0106U00FwkGumsaListItemInfo> listGrdMaster= new JpaResultMapper().list(query, CPL0106U00FwkGumsaListItemInfo.class);
		return listGrdMaster;
	}
	
	@Override
	public List<CPL0106U00GrdGroupListItemInfo> getCPL0106U00GrdGroupListItemInfo(String hospCode, String language, String hangmogCode,
			String gumsaName) {
		StringBuilder sql= new StringBuilder();
		sql.append("SELECT A.GROUP_GUBUN                                                                                  ");
		sql.append("     , A.HANGMOG_CODE                                                                                 ");
		sql.append("     , A.SPECIMEN_CODE                                                                                ");
		sql.append("     , (SELECT X.CODE_NAME                                                                            ");
		sql.append("          FROM CPL0109 X                                                                              ");
		sql.append("         WHERE X.HOSP_CODE = 'K01'                                                                    ");
		sql.append("           AND X.CODE_TYPE = '04'                                                                     ");
		sql.append("           AND X.CODE = A.SPECIMEN_CODE                                                               ");
		sql.append("           AND X.LANGUAGE = :language) SPECIMEN_NAME                                                  ");
		sql.append("     , A.EMERGENCY                                                                                    ");
		sql.append("     , A.GUMSA_NAME    GUMSA_NAME                                                                     ");
		sql.append("     , A.JUNDAL_GUBUN                                                                                 ");
		sql.append("     , (SELECT X.CODE_NAME                                                                            ");
		sql.append("          FROM CPL0109 X                                                                              ");
		sql.append("         WHERE X.HOSP_CODE = 'K01'                                                                    ");
		sql.append("           AND X.CODE_TYPE = '01'                                                                     ");
		sql.append("           AND X.CODE = A.JUNDAL_GUBUN                                                                ");
		sql.append("           AND X.LANGUAGE = :language) JUNDAL_NAME                                                    ");
		sql.append("  FROM CPL0101 A                                                                                      ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode                                                                        ");
		sql.append("   AND A.GROUP_GUBUN  IN ('01', '03')                                                                 ");
		sql.append("   AND A.SYSTEM_GUBUN = 'CPL'                                                                         ");
		if(!StringUtils.isEmpty(hangmogCode)) {
			sql.append("   AND A.HANGMOG_CODE LIKE CONCAT('%',:hangmog_code,'%')                                          ");
		}
		if(!StringUtils.isEmpty(gumsaName)) {
			sql.append("   AND A.GUMSA_NAME   LIKE CONCAT('%',:gumsa_name,'%')                                            ");
		}
		sql.append("ORDER BY CONCAT(LPAD(A.GROUP_GUBUN,2,'0'), LPAD(A.HANGMOG_CODE,10,'0'), LPAD(A.SPECIMEN_CODE,2,'0'))  ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		if(!StringUtils.isEmpty(hangmogCode)) {
			query.setParameter("hangmog_code", hangmogCode);
		}
		if(!StringUtils.isEmpty(gumsaName)) {
			query.setParameter("gumsa_name", gumsaName);
		}
		List<CPL0106U00GrdGroupListItemInfo> listGrdMaster= new JpaResultMapper().list(query, CPL0106U00GrdGroupListItemInfo.class);
		return listGrdMaster;
	}
	
	@Override
	public String getCPL3010U00InitializeYValue(String hospCode, String specimenSer){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT 'Y'                                    ");
		sql.append("  FROM CPL0101 B,                             ");
		sql.append("       CPL3020 A                              ");
		sql.append(" WHERE A.HOSP_CODE     = :f_hosp_code         ");
		sql.append("   AND B.HOSP_CODE     = A.HOSP_CODE          ");
		sql.append("   AND A.SPECIMEN_SER  = :f_specimen_ser      ");
		sql.append("   AND B.HANGMOG_CODE  = A.HANGMOG_CODE       ");
		sql.append("   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE      ");
		sql.append("   AND B.EMERGENCY     = A.EMERGENCY          ");
		sql.append("   AND B.SPCIAL_NAME   = '04'                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_specimen_ser", specimenSer);
		
		List<String> list = query.getResultList();
		if(list != null && list.size() > 0){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public String getCPL0101U00FbxHangmogCodeName(String hospCode, String code) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT GUMSA_NAME FROM CPL0101 WHERE HOSP_CODE = :hospCode AND HANGMOG_CODE = :code ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("code", code);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}
	
	@Override
	public List<ComboListItemInfo> getCPL0101U00FbxHangmogCodeComboListItem(
			String hospCode, String find1, String find2) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("  SELECT DISTINCT																		");
		sql.append("         HANGMOG_CODE	                                                                ");
		sql.append("       , GUMSA_NAME                                                                     ");
		sql.append("    FROM CPL0101                                                                        ");
		sql.append("   WHERE HOSP_CODE = :hospCode                                                          ");
		sql.append("     AND ((HANGMOG_CODE LIKE IF(:find1 = '' , '%',CONCAT('%',:find1,'%'))               ");
		sql.append("      OR  (GUMSA_NAME   LIKE IF(:find2 = '' , '%',CONCAT('%',:find2,'%')))))            ");
		sql.append("   ORDER BY HANGMOG_CODE                                                                ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("find1", find1);
		query.setParameter("find2", find2);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public String getCPL0101U00CheckHangmogCopy(String hospCode, String hangmogCode,
			String specimenCode, String emergency) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'   								");
		sql.append("	FROM CPL0101                                ");
		sql.append("	WHERE HOSP_CODE     = :hospCode             ");
		sql.append("	AND HANGMOG_CODE  = :hangmogCode            ");
		sql.append("	AND SPECIMEN_CODE = :specimenCode           ");
		sql.append("	AND EMERGENCY     = :emergency   	        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("hangmogCode", hangmogCode);
		query.setParameter("specimenCode", specimenCode);
		query.setParameter("emergency", emergency);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}
	
	@Override
	public String callPrCplCopyCpl0101(String hospCode, String hangmogCode, String specimenCode,
			String emergency, String newSpecimenCode, String newEmergency,String o_err) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_CPL_COPY_CPL0101");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_HANGMOG_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SPECIMEN_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_EMERGENCY", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_NEW_SPECIMEN_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_NEW_EMERGENCY", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_HANGMOG_CODE", hangmogCode);
		query.setParameter("I_SPECIMEN_CODE", specimenCode);
		query.setParameter("I_EMERGENCY", emergency);
		query.setParameter("I_NEW_SPECIMEN_CODE", newSpecimenCode);
		query.setParameter("I_NEW_EMERGENCY", newEmergency);
		query.setParameter("O_ERR", o_err);
		
		String result = (String)query.getOutputParameterValue("O_ERR");
		return result;
	}

	
	@Override
	public List<CPL3010U01LaySpecimenInfo> getCPL3010U01LaySpecimenInfoListItemInfo(String hospCode, String language, String specimenSer) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT DISTINCT                                                                                        ");   
		sql.append("  A.BUNHO             BUNHO,                                                                            ");   
		sql.append("  B.SUNAME                   SUNAME,                                                                    ");   
		sql.append("  ( case B.SEX when 'F' then '女'  when 'M' then '男' else '' end)  SEX,                                ");                                                 
		sql.append("  B.BIRTH             BIRTH,                                                                            ");   
		sql.append("  FN_BAS_LOAD_GWA_NAME(A.GWA,A.JUBSU_DATE,:f_hosp_code,:f_language) GWA ,                               ");                             
		sql.append("  A.DOCTOR_NAME       DOCTOR_NAME ,                                                                     ");                         
		sql.append(" FN_BAS_LOAD_BUSEO_HO_DONG_NAME(A.HO_DONG, A.JUBSU_DATE,:f_hosp_code) HO_DONG ,                         ");             
		sql.append("  ( case A.HO_CODE when NULL then '' else  CONCAT(IFNULL(A.HO_CODE,''),'号') end )  HO_CODE,            ");      
		sql.append("  A.ORDER_DATE        ORDER_DATE,                                                                       ");   
		sql.append("  DATE_FORMAT(A.JUBSU_DATE,'%Y/%m/%d')        JUBSU_DATE,                                               ");   
		sql.append("  A.PART_JUBSU_DATE   PART_JUBSU_DATE,                                                                  ");   
		sql.append("  A.JUBSU_TIME        JUBSU_TIME,                                                                       ");   
		sql.append("  A.PART_JUBSU_TIME   PART_JUBSU_TIME,                                                                  ");   
		sql.append("  A.JUBSUJA           JUBSUJA,                                                                          ");   
		sql.append("  (case A.IN_OUT_GUBUN                                                                                  ");   
		sql.append("  when 'I' then FN_ADM_MSG('3122',:f_language)                                                          ");   
		sql.append("  when 'O' then FN_ADM_MSG('4136',:f_language)                                                          ");   
		sql.append("  else '' end) IN_OUT_GUBUN,                                                                            ");   
		sql.append("  A.JUNDAL_GUBUN      JUNDAL_GUBUN,                                                                     ");   
		sql.append("  A.SPECIMEN_CODE     SPECIMEN_CODE,                                                                    ");   
		sql.append("  C.CODE_NAME         SPECIMEN_NAME,                                                                    ");   
		sql.append("  FN_CPL_TIME_LOAD(A.JUBSU_DATE, A.JUBSU_TIME, A.PART_JUBSU_DATE, A.PART_JUBSU_TIME)            TAT1,   ");   
		sql.append("  FN_CPL_TIME_LOAD_RESULT(A.PART_JUBSU_DATE, A.PART_JUBSU_TIME, A.RESULT_DATE, A.RESULT_TIME)   TAT2,   ");   
		sql.append("  FN_BAS_LOAD_AGE(A.JUBSU_DATE, B.BIRTH, NULL)   AGE                                                    ");                                        
		sql.append("  FROM ( OUT0101 B RIGHT JOIN CPL2010 A ON B.HOSP_CODE   = A.HOSP_CODE AND B.BUNHO  = A.BUNHO )         ");   
		sql.append(" LEFT JOIN CPL0109 C ON C.HOSP_CODE   = A.HOSP_CODE AND C.CODE  = A.SPECIMEN_CODE AND C.CODE_TYPE = '04' ");   
		sql.append("  WHERE A.HOSP_CODE       = :f_hosp_code                                                                ");   
		sql.append(" AND A.SPECIMEN_SER    = :f_specimen_ser																");
		 
		 
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_specimen_ser", specimenSer);
		List<CPL3010U01LaySpecimenInfo> listLaySpecimen= new JpaResultMapper().list(query, CPL3010U01LaySpecimenInfo.class);
		return listLaySpecimen;
	}
	@Override
	public List<CPL3010U01LayPrint2Info> getCplsCPL3010U01LayPrint2ListItemInfo(String hospCode, String language, String fromPartJubsuDate,
			String fromSeq, String toPartJubsuDate, String toSed) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DATE_FORMAT(B.PART_JUBSU_DATE,'%Y/%m/%d')                                                                                                                                                   ");
		sql.append(" , LPAD(SUBSTR(B.BUNHO,2),9,' ') BUNHO                                                                                                                                                              ");
		sql.append(" , C.SUNAME2                                                                                                                                                                                        ");
		sql.append(" , LPAD(D.JANGBI_OUT_CODE,5,'0')          HANGMOG_CODE                                                                                                                                              ");
		sql.append(" , FN_CPL_GUMSA_NM('1',A.HANGMOG_CODE,A.SPECIMEN_CODE,:f_hosp_code)                                                                                                                                 ");
		sql.append(" , (case B.IN_OUT_GUBUN                                                                                                                                                                             ");
		sql.append(" when 'I' then FN_BAS_LOAD_GWA_NAME(B.HO_DONG,B.ORDER_DATE,:f_hosp_code,:f_language)                                                                                                                ");
		sql.append(" else FN_BAS_LOAD_GWA_NAME(B.GWA,B.ORDER_DATE,:f_hosp_code,:f_language) end )                                                                                                                       ");
		sql.append(" , FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR,B.ORDER_DATE,:f_hosp_code)                                                                                                                                      ");
		sql.append(" , C.SEX                                                                                                                                                                                            ");
		sql.append(" , FN_BAS_LOAD_AGE(SYSDATE(),C.BIRTH,'XXXXXX')                                                                                                                             ");
		sql.append(" , B.SPECIMEN_SER                                                                                                                                                                                   ");
		sql.append(" ,( case D.SPCIAL_NAME                                                                                                                                                                              ");
		sql.append(" when '04' then FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,(case B.IN_OUT_GUBUN                                                                                                                           ");
		sql.append("   when 'I' then B.FKOCS2003 else B.FKOCS1003 end ),B.IN_OUT_GUBUN,:f_hosp_code)                                                                                                                    ");
		sql.append(" else '' end )         NYO_RYANG                                                                                                                                                                    ");
		sql.append(" ,(case D.SPCIAL_NAME                                                                                                                                                                               ");
		sql.append(" when '04' then( case FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,(case B.IN_OUT_GUBUN                                                                                                                     ");
		sql.append("           when 'I' then B.FKOCS2003                                                                                                                                                                ");
		sql.append("           else B.FKOCS1003 end),B.IN_OUT_GUBUN,:f_hosp_code)                                                                                                                                       ");
		sql.append("     when NULL then NULL                                                                                                                                                                            ");
		sql.append("         else 'ml' end )                                                                                                                                                                            ");
		sql.append(" else '' end )  NYO_DANUI                                                                                                                                                                           ");
		sql.append(" , IFNULL(B.EMERGENCY,'N') EMERGENCY                                                                                                                                                                ");
		sql.append("  FROM OUT0101 C                                                                                                                                                                                    ");
		sql.append(" , CPL0101 D                                                                                                                                                                                        ");
		sql.append(" , CPL3020 A                                                                                                                                                                                        ");
		sql.append(" , CPL2010 B                                                                                                                                                                                        ");
		sql.append(" WHERE B.HOSP_CODE = :f_hosp_code                                                                                                                                                                   ");
		sql.append("   AND                                                                                                                                                                                              ");
		sql.append("  CONCAT(IFNULl(B.PART_JUBSU_DATE,''),IFNULL(B.PART_JUBSU_TIME,''))                                                                                                                                 ");
		sql.append("   BETWEEN CONCAT(IFNULL(STR_TO_DATE(:f_from_part_jubsu_date,'%Y/%m/%d'),''),:f_from_seq)                                                                                                           ");
		sql.append("           AND CONCAT(IFNULL(STR_TO_DATE(:f_to_part_jubsu_date,'%Y/%m/%d'),''),:f_to_seq)                                                                                                           ");
		sql.append("   AND B.UITAK_CODE      = '01'                                                                                                                                                                     ");
		sql.append("   AND C.HOSP_CODE       = B.HOSP_CODE                                                                                                                                                              ");
		sql.append("   AND C.BUNHO           = B.BUNHO                                                                                                                                                                  ");
		sql.append("   AND A.HOSP_CODE       = B.HOSP_CODE                                                                                                                                                              ");
		sql.append("   AND A.FKCPL2010       = B.PKCPL2010                                                                                                                                                              ");
		sql.append("   AND A.SPECIMEN_SER    = B.SPECIMEN_SER                                                                                                                                                           ");
		sql.append("   AND D.HOSP_CODE       = A.HOSP_CODE                                                                                                                                                              ");
		sql.append("   AND D.HANGMOG_CODE    = A.HANGMOG_CODE                                                                                                                                                           ");
		sql.append("   AND D.SPECIMEN_CODE   = A.SPECIMEN_CODE                                                                                                                                                          ");
		sql.append("   AND D.EMERGENCY       = A.EMERGENCY                                                                                                                                                              ");
		sql.append("   AND D.UITAK_CODE      = '01'                                                                                                                                                                     ");
		sql.append("   AND D.JANGBI_OUT_CODE IS NOT NULL                                                                                                                                                                ");
		sql.append("   AND EXISTS (SELECT 'X' FROM CPLREQ1 X WHERE X.REQUEST_KEY = CONCAT(IFNULL(DATE_FORMAT(B.PART_JUBSU_DATE,'%Y%m%d'),''),IFNULL(B.PART_JUBSU_TIME,''),IFNULL(B.BUNHO,'')) AND X.CUR_SEND_YN = 'Y')  ");
		sql.append(" ORDER BY B.PART_JUBSU_DATE,B.PART_JUBSU_TIME,B.BUNHO,B.SPECIMEN_SER,A.PKCPL3020																													");
		  
		Query query  =entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_from_part_jubsu_date", fromPartJubsuDate);
		query.setParameter("f_from_seq", fromSeq);
		query.setParameter("f_to_part_jubsu_date", toPartJubsuDate);
		query.setParameter("f_to_seq", toSed);
		List<CPL3010U01LayPrint2Info> listLayPrint2 =new JpaResultMapper().list(query, CPL3010U01LayPrint2Info.class);
		return listLayPrint2;
	}
	@Override
	public List<CPL3010U01LayPrint2Info> getCplsCPL3010U01LayPrint2ListItemInfo2(String hospCode, String language, String fromSpecimenSer,String toSpecimenSer) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT DATE_FORMAT(B.PART_JUBSU_DATE,'%Y/%m/%d')                                                                                                                                                      " );
		sql.append(" , LPAD(SUBSTR(B.BUNHO,2),9,' ') BUNHO                                                                                                                                                                 " );
		sql.append(" , C.SUNAME2                                                                                                                                                                                           " );
		sql.append(" , LPAD(D.JANGBI_OUT_CODE,5,'0')                        HANGMOG_CODE                                                                                                                                   " );
		sql.append(" , FN_CPL_GUMSA_NM('1',A.HANGMOG_CODE,A.SPECIMEN_CODE,:f_hosp_code)                                                                                                                                    " );
		sql.append(" ,( case B.IN_OUT_GUBUN                                                                                                                                                                                " );
		sql.append(" when 'I' then FN_BAS_LOAD_GWA_NAME(B.HO_DONG,B.ORDER_DATE,:f_hosp_code,:f_language)                                                                                                                   " );
		sql.append(" else FN_BAS_LOAD_GWA_NAME(B.GWA,B.ORDER_DATE,:f_hosp_code,:f_language) end )                                                                                                                          " );
		sql.append(" , FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR,B.ORDER_DATE,:f_hosp_code)                                                                                                                                         " );
		sql.append(" , C.SEX                                                                                                                                                                                               " );
		sql.append(" , FN_BAS_LOAD_AGE(DATE_FORMAT(SYSDATE() ,'%Y-%m-%d'),C.BIRTH,'XXXXXX')                                                                                                                                " );
		sql.append(" , B.SPECIMEN_SER                                                                                                                                                                                      " );
		sql.append(" ,( case D.SPCIAL_NAME                                                                                                                                                                                 " );
		sql.append(" when '04' then FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,(case B.IN_OUT_GUBUN                                                                                                                              " );
		sql.append("      when 'I' then B.FKOCS2003 else B.FKOCS1003 end ),B.IN_OUT_GUBUN,:f_hosp_code)                                                                                                                    " );
		sql.append(" else '' end )           NYO_RYANG                                                                                                                                                                     " );
		sql.append(" ,(case D.SPCIAL_NAME                                                                                                                                                                                  " );
		sql.append(" when '04' then( case FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,(case B.IN_OUT_GUBUN                                                                                                                        " );
		sql.append("     when 'I' then B.FKOCS2003 else B.FKOCS1003 end ),B.IN_OUT_GUBUN,:f_hosp_code)                                                                                                                     " );
		sql.append("     when NULL then NULL else 'ml' end )                                                                                                                                                               " );
		sql.append(" else '' end )  NYO_DANUI                                                                                                                                                                              " );
		sql.append(" , IFNULL(B.EMERGENCY,'N') EMERGENCY                                                                                                                                                                   " );
		sql.append("   FROM OUT0101 C                                                                                                                                                                                      " );
		sql.append(" , CPL0101 D                                                                                                                                                                                           " );
		sql.append(" , CPL3020 A                                                                                                                                                                                           " );
		sql.append(" , CPL2010 B                                                                                                                                                                                           " );
		sql.append("  WHERE B.HOSP_CODE       = :f_hosp_code                                                                                                                                                               " );
		sql.append("    AND B.SPECIMEN_SER BETWEEN :f_from_specimen_ser                                                                                                                                                    " );
		sql.append("                           AND :f_to_specimen_ser                                                                                                                                                      " );
		sql.append("    AND B.UITAK_CODE      = '01'                                                                                                                                                                       " );
		sql.append("    AND C.HOSP_CODE       = B.HOSP_CODE                                                                                                                                                                " );
		sql.append("    AND C.BUNHO           = B.BUNHO                                                                                                                                                                    " );
		sql.append("    AND A.HOSP_CODE       = B.HOSP_CODE                                                                                                                                                                " );
		sql.append("    AND A.FKCPL2010       = B.PKCPL2010                                                                                                                                                                " );
		sql.append("    AND A.SPECIMEN_SER    = B.SPECIMEN_SER                                                                                                                                                             " );
		sql.append("    AND D.HOSP_CODE       = A.HOSP_CODE                                                                                                                                                                " );
		sql.append("    AND D.HANGMOG_CODE    = A.HANGMOG_CODE                                                                                                                                                             " );
		sql.append("    AND D.SPECIMEN_CODE   = A.SPECIMEN_CODE                                                                                                                                                            " );
		sql.append("    AND D.EMERGENCY       = A.EMERGENCY                                                                                                                                                                " );
		sql.append("    AND D.UITAK_CODE      = '01'                                                                                                                                                                       " );
		sql.append("    AND D.JANGBI_OUT_CODE IS NOT NULL                                                                                                                                                                  " );
		sql.append("    AND EXISTS (SELECT 'X' FROM CPLREQ1 X WHERE X.REQUEST_KEY = CONCAT(IFNULL(DATE_FORMAT(B.PART_JUBSU_DATE,'%Y%m%d'),''),IFNULL(B.PART_JUBSU_TIME,''),IFNULL(B.BUNHO,'')) AND X.CUR_SEND_YN = 'Y')    ");
		sql.append("  ORDER BY B.PART_JUBSU_DATE,B.PART_JUBSU_TIME,B.BUNHO,B.SPECIMEN_SER,A.PKCPL3020																														");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_from_specimen_ser", fromSpecimenSer);
		query.setParameter("f_to_specimen_ser", toSpecimenSer);
		List<CPL3010U01LayPrint2Info> listLayPrint2=new JpaResultMapper().list(query, CPL3010U01LayPrint2Info.class);
		return listLayPrint2;
	}
	@Override
	public List<CPL3010U01PrePrintInfo> getCPL3010U01BtnPrePrintClickCPL3010ListItemInfo(String hospCode, String language, List<String> iraiStr, String uitakCode) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT DATE_FORMAT(B.PART_JUBSU_DATE,'%Y/%m/%d')                                                                              PART_JUBSU_DATE                          ");
		sql.append(" , LPAD(SUBSTR(B.BUNHO,2),9,' ')                                                                                             BUNHO                                      ");
		sql.append(" , C.SUNAME2                                                                                                                 SUNAME2                                    ");
		sql.append(" , D.JANGBI_OUT_CODE                                                                                                         HANGMOG_CODE                               ");
		sql.append(" , FN_CPL_GUMSA_NM('1',A.HANGMOG_CODE,A.SPECIMEN_CODE,:f_hosp_code)                                                         HANGMOG_NAME                                ");
		sql.append(" , FN_CPL_CODE_NAME('04',D.SPECIMEN_CODE,:f_hosp_code,:f_language)                                                           SPECIMEN_NAME                              ");
		sql.append(" , (case B.IN_OUT_GUBUN when 'I' then FN_BAS_LOAD_GWA_NAME(B.HO_DONG,B.ORDER_DATE,:f_hosp_code,:f_language)                                                             ");
		sql.append("                        else FN_BAS_LOAD_GWA_NAME(B.GWA,B.ORDER_DATE,:f_hosp_code,:f_language) end )                         GWA_NAME                                   ");
		sql.append(" , FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR,B.ORDER_DATE,:f_hosp_code)                                                               DOCTOR_NAME                                ");
		sql.append(" , C.SEX                                                                                                                     SEX                                        ");
		sql.append(" , FN_BAS_LOAD_AGE(SYSDATE(),C.BIRTH,'XXXXXX')                                                                               AGE                                        ");
		sql.append(" , B.SPECIMEN_SER                                                                                                            SPECIMEN_SER                               ");
		sql.append(" ,(case D.SPCIAL_NAME when '04' then FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,(                                                                                             ");
		sql.append("                                              case B.IN_OUT_GUBUN                                                                                                       ");
		sql.append("                                              when 'I' then B.FKOCS2003                                                                                                 ");
		sql.append("                                              else B.FKOCS1003 end ),B.IN_OUT_GUBUN,:f_hosp_code)                                                                       ");
		sql.append("                      else '' end )                                                                                           NYO_RYANG                                 ");
		sql.append(" , (case D.SPCIAL_NAME when '04' then (                                                                                                                                 ");
		sql.append("       case FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,(case B.IN_OUT_GUBUN when 'I' then B.FKOCS2003 else B.FKOCS1003 end ),B.IN_OUT_GUBUN,:f_hosp_code)                     ");
		sql.append("         when NULL then NULL                                                                                                                                            ");
		sql.append("         else  'ml' end)                                                                                                                                                ");
		sql.append("     else '' end )                                                                                           NYO_DANUI                                                  ");
		sql.append(" , ( case FN_OCS_EMERGENCY_CHK(B.IN_OUT_GUBUN, B.FKOCS1003, B.FKOCS2003,:f_hosp_code) when 'Y' then 'o' else '' end)   EMERGENCY_YN                                     ");
		sql.append("   FROM OUT0101 C                                                                                                                                                       ");
		sql.append(" , CPL0101 D                                                                                                                                                            ");
		sql.append(" , CPL3020 A                                                                                                                                                            ");
		sql.append(" , CPL2010 B                                                                                                                                                            ");
		sql.append("  WHERE B.HOSP_CODE       = :f_hosp_code                                                                                                                                ");
		sql.append(" AND B.UITAK_CODE      = :f_uitak_code                                                                                                                                           ");

		sql.append(" AND C.HOSP_CODE       = B.HOSP_CODE                                                                                                                                    ");
		sql.append(" AND C.BUNHO           = B.BUNHO                                                                                                                                        ");
		sql.append(" AND A.HOSP_CODE       = B.HOSP_CODE                                                                                                                                    ");
		sql.append(" AND A.FKCPL2010       = B.PKCPL2010                                                                                                                                    ");
		sql.append(" AND A.SPECIMEN_SER    = B.SPECIMEN_SER                                                                                                                                 ");
		sql.append(" AND D.HOSP_CODE       = A.HOSP_CODE                                                                                                                                    ");
		sql.append(" AND D.HANGMOG_CODE    = A.HANGMOG_CODE                                                                                                                                 ");
		sql.append(" AND D.SPECIMEN_CODE   = A.SPECIMEN_CODE                                                                                                                                ");
		sql.append(" AND D.EMERGENCY       = A.EMERGENCY                                                                                                                                    ");
		sql.append(" AND D.UITAK_CODE      = :f_uitak_code                                                                                                                                  ");
		sql.append(" AND D.JANGBI_OUT_CODE IS NOT NULL                                                                                                                                      ");
		sql.append(" AND ( ( CONCAT(IFNULL(DATE_FORMAT(B.PART_JUBSU_DATE,'%y%m%d'),''),IFNULL(B.PART_JUBSU_TIME,''),IFNULL(B.BUNHO,'')) ) IN (:f_iraiStr))                                  ");
		sql.append("  ORDER BY B.PART_JUBSU_DATE,B.PART_JUBSU_TIME,B.BUNHO,B.SPECIMEN_SER,A.PKCPL3020	 																					");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_iraiStr", iraiStr);
		query.setParameter("f_uitak_code", uitakCode);
		List<CPL3010U01PrePrintInfo> listBtnPreClick= new JpaResultMapper().list(query, CPL3010U01PrePrintInfo.class);
		return listBtnPreClick;
	}
	//TODO remove comment
	@Override
	public List<CPL3010U01GrdPaInfo> getCplsCPL3010U01GrdPaCPL3010ListItemInfo(String centerCode, String uitakCode, String hospCode, String fromPartJubsuDate, String toPartJubsuDate,String fromSeq, String toSeq,String fromSpecimenSer,String toSpecimenSer, boolean isTrue) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT 'O1'                                                              RECODE_GUBUN                                                                                  ");                                                    
		sql.append("  , :f_center_code                                                        CENTER_CODE                                                                                   "); //huanlt                                                    
		sql.append("  ,CONCAT(IFNULL(DATE_FORMAT(B.PART_JUBSU_DATE,'%y%m%d'),''),IFNULL(B.PART_JUBSU_TIME,''),IFNULL(B.BUNHO,'')) REQUEST_KEY                                               ");                                                    
		sql.append("  , '        '                                                            HOSPITAL_CODE                                                                                 ");                                                    
		sql.append("  , FN_ADM_CONVERT_KATAKANA_HALF(2,FN_BAS_LOAD_GWA_NAME2(:f_hosp_code,B.GWA,B.ORDER_DATE))           GWA_NAME                                                           ");                                               
		sql.append("  , FN_BAS_LOAD_GWA_NAME2(:f_hosp_code,IFNULL(E.HO_DONG1,B.HO_DONG),SYSDATE())         HO_DONG_NAME                                                                     ");                                               
		sql.append("  , MIN( case B.IN_OUT_GUBUN when 'I' then '1' when 'O' then '2' end )         IN_OUT_GUBUN                                                                             ");                                                    
		sql.append("  , FN_ADM_CONVERT_KATAKANA_HALF(2,FN_BAS_LOAD_DOCTOR_NAME2(:f_hosp_code,B.DOCTOR,B.ORDER_DATE))     DOCTOR_NAME                                                        ");                                               
		sql.append("  , MIN(B.BUNHO)                                        BUNHO                                                                                                           ");                                                    
		sql.append("  , MIN(B.BUNHO)                                        JINRYO_CARD                                                                                                     ");                                                    
		sql.append("  , FN_ADM_CONVERT_KATAKANA_HALF(2,D.SUNAME2)      SUNAME2                                                                                                              ");                                               
		sql.append("  , MIN(D.SEX)                                          SEX                                                                                                             ");                                                    
		sql.append("  , 'Y'                                                 AGE_GUBUN                                                                                                       ");                                                    
		sql.append(" , MIN(FN_BAS_LOAD_AGE(B.JUBSU_DATE, D.BIRTH, NULL))   AGE                                                                                                              ");                                                   
		sql.append("  , MIN(dayofweek(STR_TO_DATE(D.BIRTH, '%Y/%m/%d')))     BIRTH_GUBUN                                                                                                    ");                                          
		sql.append("  , MIN(STR_TO_DATE(D.BIRTH, '%Y%m%d'))       BIRTH                                                                                                                     ");                               
		sql.append("  , case B.IN_OUT_GUBUN when 'O' then DATE_FORMAT(B.JUBSU_DATE,'%y%m%d') else DATE_FORMAT(B.PART_JUBSU_DATE,'%y%m%d') end    JUBSU_DATE                                 ");                                               
		sql.append("  , case B.IN_OUT_GUBUN when 'O' then B.JUBSU_TIME else B.PART_JUBSU_TIME end                                         JUBSU_TIME                                        ");                                              
		sql.append("   , FN_CPL_LOAD_HANGMOG_CNT(:f_hosp_code,B.BUNHO,B.PART_JUBSU_DATE)  HANGMOG_CNT                                                                                       ");                                                
		sql.append("  , FN_NUR_LOAD_HEIGHT(:f_hosp_code,B.BUNHO,SYSDATE())                 HEIGHT                                                                                           ");                                               
		sql.append("  , ' '                                                      WEIGHT                                                                                                     ");                                                    
		sql.append("  , MAX(FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER, IF(B.IN_OUT_GUBUN = 'I', B.FKOCS2003, B.FKOCS1003),B.IN_OUT_GUBUN,:f_hosp_code))   NYO_RYANG                              ");                                    
		sql.append("  , MAX(IFNULL(FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,IF(B.IN_OUT_GUBUN = 'I', B.FKOCS2003, B.FKOCS1003),B.IN_OUT_GUBUN,:f_hosp_code), 'ml')) NYO_DANUI                   ");                                                                                                                                              
		sql.append("  , ' '                                                 PREGNANCY_JUSU                                                                                                  ");                                                    
		sql.append("  , ' '                                                 DIALYSIS                                                                                                        ");                                                                                                           
		sql.append("  ,case  MAX(FN_CPL_SPECIMEN_PRN_YN(:f_hosp_code,B.IN_OUT_GUBUN, B.FKOCS1003, B.FKOCS2003)) when 'Z' then 'Y' else 'N' end EMERGENCY                                    ");                                                    
		sql.append("  , ' '                                                 COMMENTS                                                                                                        ");                                                
		sql.append("  , ' '                                                                                                                                                                 ");                                                
		sql.append("  , 'N'                                                                                                                                                                 ");                                                    
		sql.append("  , IFNULL(X.SEND_YN,'N')  SEND_YN                                                                                                                                      ");
		sql.append("  , B.SPECIMEN_SER, IFNULL(B.PART_JUBSU_DATE,'')  PART_JUBSU_DATE, IFNULL( B.PART_JUBSU_TIME,'')  PART_JUBSU_TIME "); //huanlt
		sql.append("   FROM                                                                                                                                                                 ");
		sql.append("    OUT0101 D                                                                                                                                                           ");
		sql.append("    INNER JOIN CPL2010 B                                                                                                                                                ");                                                         
		sql.append("         ON B.HOSP_CODE = :f_hosp_code                                                                                                                                  ");                                                       
		if(isTrue){
			sql.append("           AND B.PART_JUBSU_DATE BETWEEN STR_TO_DATE(:f_from_part_jubsu_date,'%Y/%m/%d') AND STR_TO_DATE(:f_to_part_jubsu_date,'%Y/%m/%d')                          ");  
		}else{
			sql.append("           AND B.PART_JUBSU_DATE IS NOT NULL                                                                                                                        ");  
		}
		sql.append("           AND IFNULL(B.DC_YN,'N')  = 'N'                                                                                                                               ");
		sql.append("           AND D.HOSP_CODE             = B.HOSP_CODE                                                                                                                    ");                                                              
		sql.append("           AND D.BUNHO                 = B.BUNHO                                                                                                                        ");
		sql.append("     INNER JOIN CPL0101 C  ON                                                                                                                                           ");
		sql.append("        C.HOSP_CODE             = B.HOSP_CODE                                                                                                                           ");                                                       
		sql.append("         AND C.HANGMOG_CODE          = B.HANGMOG_CODE                                                                                                                   ");                                                            
		sql.append("         AND C.SPECIMEN_CODE         = B.SPECIMEN_CODE                                                                                                                  ");
		sql.append("         AND C.EMERGENCY             = B.EMERGENCY                                                                                                                      ");
		sql.append("         AND C.UITAK_CODE            = :f_uitak_code                                                                                                                    ");
		sql.append(" LEFT JOIN VW_OCS_INP1001_01 E ON E.HOSP_CODE   = B.HOSP_CODE AND E.BUNHO    = B.BUNHO                                                                                  ");
		sql.append(" LEFT JOIN CPLREQ1 X ON X.REQUEST_KEY = CONCAT(IFNULL(DATE_FORMAT(B.PART_JUBSU_DATE,'%Y%m%d'),''),IFNULL(B.PART_JUBSU_TIME,''),IFNULL(B.BUNHO,''))                      ");
		if(!isTrue) {
			sql.append("  WHERE        B.SPECIMEN_SER BETWEEN :f_from_specimen_ser AND :f_to_specimen_ser                                                                                   ");
		}
		sql.append(" GROUP BY B.PART_JUBSU_DATE, B.PART_JUBSU_TIME, B.BUNHO, B.SPECIMEN_SER ,                                                                                                ");
		sql.append("  B.GWA, B.ORDER_DATE, E.HO_DONG1,B.HO_DONG,B.DOCTOR,D.SUNAME2,B.JUBSU_DATE,B.IN_OUT_GUBUN, B.JUBSU_TIME, X.SEND_YN ");
		sql.append(" ORDER BY B.PART_JUBSU_DATE, B.PART_JUBSU_TIME, B.BUNHO, B.SPECIMEN_SER 																								");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_center_code", centerCode);
		query.setParameter("f_uitak_code", uitakCode);
		if (isTrue) {
			query.setParameter("f_from_part_jubsu_date", fromPartJubsuDate);
			query.setParameter("f_to_part_jubsu_date", toPartJubsuDate);
		} else {
			query.setParameter("f_from_specimen_ser", fromSpecimenSer);
			query.setParameter("f_to_specimen_ser", toSpecimenSer);
		}
		List<CPL3010U01GrdPaInfo> listGrdPa= new JpaResultMapper().list(query, CPL3010U01GrdPaInfo.class);
		if(isTrue)
		{
			List<CPL3010U01GrdPaInfo> results = new ArrayList<>();
			for(CPL3010U01GrdPaInfo cpl3010U01GrdPaInfo : listGrdPa)
			{
				if(!StringUtils.isEmpty(cpl3010U01GrdPaInfo.getPartJubSuDate())&& !StringUtils.isEmpty(cpl3010U01GrdPaInfo.getPartJubSuTime()))
				{
					Date compareDate = DateUtil.toDate(cpl3010U01GrdPaInfo.getPartJubSuDate(), DateUtil.PATTERN_YYYMMDD_HHMMSS_FULL);
					if(compareDate != null)
					{
						compareDate = DateUtil.getDatePlusMMSS(compareDate, cpl3010U01GrdPaInfo.getPartJubSuTime());
						Date fromPartJubsu = DateUtil.getDatePlusMMSS(DateUtil.toDate(fromPartJubsuDate, DateUtil.PATTERN_YYMMDD),fromSeq);
						Date toPartJubsu = DateUtil.getDatePlusMMSS( DateUtil.toDate(toPartJubsuDate, DateUtil.PATTERN_YYMMDD),toSeq );
						if(fromPartJubsu.getTime() <= compareDate.getTime() &&
								compareDate.getTime() <= toPartJubsu.getTime())
						{
							results.add(cpl3010U01GrdPaInfo);
						}
					}
				}
			}
			return results;
		}
		return listGrdPa;
	}

	@Override
	public String callPrCplNumStandardCheck(String result, String fromStandard,
			String toStandard, String ioStandard) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_CPL_NUM_STANDARD_CHECK");
		
		query.registerStoredProcedureParameter("I_RESULT", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_FROM_STANDARD", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TO_STANDARD", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_STANDARD", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_RESULT", result);
		query.setParameter("I_FROM_STANDARD", fromStandard);
		query.setParameter("I_TO_STANDARD", toStandard);
		query.setParameter("IO_STANDARD", ioStandard);
		
		String standard = (String)query.getOutputParameterValue("IO_STANDARD");
		return standard;
	}

	@Override
	public String callPrCplPanicChk(String hospCode, String bunho,
			Date orderDate, String gumsaCode, String specimenCode, 
			String emergency,String result, String ioPanicYn) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_CPL_PANIC_CHK");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ORDER_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUMSA_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SPECIMEN_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_EMERGENCY", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_RESULT", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_PANIC_YN", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_ORDER_DATE", orderDate);
		query.setParameter("I_GUMSA_CODE", gumsaCode);
		query.setParameter("I_SPECIMEN_CODE", specimenCode);
		query.setParameter("I_EMERGENCY", emergency);
		query.setParameter("I_RESULT", result);
		query.setParameter("IO_PANIC_YN", ioPanicYn);
		
		String ioPanic = (String)query.getOutputParameterValue("IO_PANIC_YN");
		return ioPanic;

	}
	public List<CPL0000Q00LaySigeyulTempListItemInfo> getCPL0000Q00LaySigeyulTempListItemInfo(String hospCode, String groupHangmog,
			String specimenCode, String hangmogCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT                                          ");
		sql.append("       B.HANGMOG_CODE       HANGMOG_CODE                 ");
		sql.append("     , B.SPECIMEN_CODE      SPECIMEN_CODE                ");
		sql.append("     , C.CODE_NAME          SPECIMEN_NAME                ");
		sql.append("     , B.GUMSA_NAME         GUMSA_NAME                   ");
		sql.append("  FROM CPL0109 C,                                        ");
		sql.append("       CPL0101 B,                                        ");
		sql.append("       CPL0106 A                                         ");
		sql.append(" WHERE A.HOSP_CODE          = :f_hosp_code               ");
		sql.append("   AND B.HOSP_CODE          = A.HOSP_CODE                ");
		sql.append("   AND C.HOSP_CODE          = A.HOSP_CODE                ");
		sql.append("   AND A.HANGMOG_CODE       = :f_group_hangmog           ");
		sql.append("   AND A.SPECIMEN_CODE      = :f_specimen_code           ");
		sql.append("   AND B.HANGMOG_CODE       = A.SUB_HANGMOG_CODE         ");
		sql.append("   AND B.SPECIMEN_CODE      = A.SUB_SPECIMEN_CODE        ");
		sql.append("   AND B.EMERGENCY          = A.SUB_EMERGENCY            ");
		sql.append("   AND C.CODE_TYPE          = '04'                       ");
		sql.append("   AND C.CODE               = B.SPECIMEN_CODE            ");
		sql.append("   AND C.LANGUAGE           = :language                  ");
		sql.append(" UNION                                                   ");
		sql.append("SELECT DISTINCT                                          ");
		sql.append("       A.HANGMOG_CODE       HANGMOG_CODE                 ");
		sql.append("     , A.SPECIMEN_CODE      SPECIMEN_CODE                ");
		sql.append("     , B.CODE_NAME          SPECIMEN_NAME                ");
		sql.append("     , A.GUMSA_NAME         GUMSA_NAME                   ");
		sql.append("  FROM CPL0109 B,                                        ");
		sql.append("       CPL0101 A                                         ");
		sql.append(" WHERE A.HOSP_CODE          = :f_hosp_code               ");
		sql.append("   AND B.HOSP_CODE          = A.HOSP_CODE                ");
		sql.append("   AND A.HANGMOG_CODE       = :f_hangmog_code            ");
		sql.append("   AND A.SPECIMEN_CODE      = :f_specimen_code           ");
		sql.append("   AND B.CODE_TYPE          = '04'                       ");
		sql.append("   AND B.CODE               = A.SPECIMEN_CODE            ");
		sql.append("   AND B.LANGUAGE           = :language                  ");
		sql.append(" ORDER BY 1 ASC                                          ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_group_hangmog", groupHangmog);
		query.setParameter("f_specimen_code", specimenCode);
		query.setParameter("f_hangmog_code", hangmogCode);
		query.setParameter("language", language);
		List<CPL0000Q00LaySigeyulTempListItemInfo> listGrdMaster= new JpaResultMapper().list(query, CPL0000Q00LaySigeyulTempListItemInfo.class);
		return listGrdMaster;
	}

	@Override
	public String callFnCplLoadDupGrdHangmog(String hospCode, String language,
			String newHangmogCode, String newSpecimenCode,
			String oldHangmogCode, String oldSpecimenCode) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT FN_CPL_LOAD_DUP_GRD_HANGMOG(:hospCode, :language, :newHangmogCode, :newSpecimenCode, :oldHangmogCode, :oldSpecimenCode);");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		query.setParameter("newHangmogCode", newHangmogCode);
		query.setParameter("newSpecimenCode", newSpecimenCode);
		query.setParameter("oldHangmogCode", oldHangmogCode);
		query.setParameter("oldSpecimenCode", oldSpecimenCode);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)&& result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	public List<MultiResultViewGrdSigeyulInfo> getMultiResultViewGrdSigeyul2(String hospCode, String bunho, String groupHangmog){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT :f_bunho  BUNHO                   ");
		sql.append("      , HANGMOG_CODE                      ");
		sql.append("      , GUMSA_NAME                        ");
		sql.append("   FROM CPL0101                           ");
		sql.append("  WHERE HOSP_CODE    = :f_hosp_code       ");
		sql.append("    AND HANGMOG_CODE = :f_group_hangmog   ");
		sql.append("    LIMIT 0,1                             ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_group_hangmog", groupHangmog);
		query.setParameter("f_bunho", bunho);
		List<MultiResultViewGrdSigeyulInfo> listGrdMaster= new JpaResultMapper().list(query, MultiResultViewGrdSigeyulInfo.class);
		return listGrdMaster;
	}
	
	@Override
	public List<MultiResultViewGrdSigeyulInfo> getMultiResultViewGrdSigeyul1(String hospCode, String bunho, String groupHangmog){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT MIN(:f_bunho)                              ");
		sql.append("         , A.SUB_HANGMOG_CODE                     ");
		sql.append("         , MIN(B.GUMSA_NAME)                      ");
		sql.append("      FROM CPL0101 B                              ");
		sql.append("         , CPL0106 A                              ");
		sql.append("     WHERE A.HOSP_CODE      = :f_hosp_code        ");
		sql.append("       AND B.HOSP_CODE      = A.HOSP_CODE         ");
		sql.append("       AND A.HANGMOG_CODE   = :f_group_hangmog    ");
		sql.append("       AND B.HANGMOG_CODE   = A.SUB_HANGMOG_CODE  ");
		sql.append("       AND B.SPECIMEN_CODE  = A.SUB_SPECIMEN_CODE ");
		sql.append("       AND B.EMERGENCY      = A.SUB_EMERGENCY     ");
		sql.append("     GROUP BY A.SUB_HANGMOG_CODE                  ");
		sql.append("     ORDER BY A.SUB_HANGMOG_CODE                  ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_group_hangmog", groupHangmog);
		query.setParameter("f_bunho", bunho);
		List<MultiResultViewGrdSigeyulInfo> listGrdMaster= new JpaResultMapper().list(query, MultiResultViewGrdSigeyulInfo.class);
		return listGrdMaster;
	}
	
	@Override
	public String callPrCpl0101U00UpdateMasterData(String hospCode) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_CPL0101U00_UPDATE_MASTER_DATA");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERR_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		
		query.execute();
		String erFlg = (String)query.getOutputParameterValue("IO_ERR_FLAG");
		return erFlg;
	}

	@Override
	public boolean isExistedCpl0101(String hospCode, String hangmogCode, String specimenCode, String emergency) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y'                 						");
		sql.append("	   FROM CPL0101            	 					");
		sql.append("	WHERE HOSP_CODE =      :hospCode 				");
		sql.append("	   AND HANGMOG_CODE =  :hangmogCode         	");
		sql.append("	   AND SPECIMEN_CODE = :specimenCode    		");
		sql.append("	   AND EMERGENCY =     :emergency    			");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("hangmogCode", hangmogCode);
		query.setParameter("specimenCode", specimenCode);
		query.setParameter("emergency", emergency);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return true;
		}
		return false;
	}

	@Override
	public List<ComboListItemInfo> getCPL0000Q01fwkHangmogCode(String hospCode, String find1, String find2) {
StringBuilder sql = new StringBuilder();
		
		sql.append("  SELECT HANGMOG_CODE								");
		sql.append("       , MAX(GUMSA_NAME)							");
		sql.append("    FROM CPL0101									");
		sql.append("   WHERE HOSP_CODE = :f_hosp_code					");
		sql.append("     AND HANGMOG_CODE LIKE CONCAT(:f_find1,'%')		");
		sql.append("      OR GUMSA_NAME   LIKE CONCAT('%',:f_find2,'%')	");
		sql.append("   GROUP BY HANGMOG_CODE							");
		sql.append("   ORDER BY LPAD(HANGMOG_CODE,5,'0')				");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_find1", find1);
		query.setParameter("f_find2", find2);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public String callFnCplLoadDupHangmog(String hospCode, String language, String ioGubun, String bunho,
			String hangmogCode, String specimenCode, Date checkDate) {
		
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_CPL_LOAD_DUP_HANGMOG(:f_hosp_code, :f_language, :f_io_gubun, :f_bunho, :f_hangmog_code, :f_speciment_code, :f_check_date) FROM DUAL ");
		Query query = entityManager.createNativeQuery(sql.toString());
		
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_hangmog_code", hangmogCode);
		query.setParameter("f_speciment_code", specimenCode);
		query.setParameter("f_check_date", checkDate);
		
		List<String> list = query.getResultList();
		return CollectionUtils.isEmpty(list) ? "" : list.get(0);
	}
}

