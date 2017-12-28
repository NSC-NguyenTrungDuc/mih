package nta.med.data.dao.medi.nur.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nur.Nur0102RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01XEditGridCell89ItemInfo;
import nta.med.data.model.ihis.nuri.NUR0101U01GrdDetailInfo;
import nta.med.data.model.ihis.nuri.NUR0801U00GrdMasterInfo;
import nta.med.data.model.ihis.nuri.NUR0802U00grdDetailInfo;
import nta.med.data.model.ihis.nuri.NUR1001U00LayComboSetInfo;
import nta.med.data.model.ihis.nuri.NUR1010Q00layTimeInfo;
import nta.med.data.model.ihis.nuri.NUR1020U00grdNUR1022INInfo;
import nta.med.data.model.ihis.nuri.NUR8003R02grdDetailInfo;
import nta.med.data.model.ihis.system.TripleListItemInfo;

/**
 * @author dainguyen.
 */
public class Nur0102RepositoryImpl implements Nur0102RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<ComboListItemInfo> getNuroComboTime(String language, String hopitalCode, String codeType, boolean orderBySortKey){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT CODE, CODE_NAME                    ");
		sql.append("  FROM NUR0102                            ");
		sql.append(" WHERE HOSP_CODE = :hopitalCode           ");
		sql.append("   AND CODE_TYPE = :codeType			  ");
		sql.append("   AND LANGUAGE = :language               ");
		if(orderBySortKey){
			sql.append("  ORDER BY SORT_KEY                   ");
		}else{
			sql.append(" ORDER BY CAST(CODE AS SIGNED)         ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hopitalCode", hopitalCode);
		query.setParameter("codeType", codeType);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	@Override
	public List<ComboListItemInfo> getCboTimeList(String hospCode,String language) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT CODE,                       ");
		sql.append(" CODE_NAME                          ");
		sql.append(" FROM NUR0102                       ");
		sql.append(" WHERE HOSP_CODE = :hospCode        ");
		sql.append(" AND LANGUAGE = :language           ");
		sql.append(" AND CODE_TYPE = 'NUR2001U04_TIMER' ");
		sql.append(" ORDER BY  CAST(CODE AS SIGNED)     ");
		Query query=entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		List<ComboListItemInfo> listCombo= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listCombo;
	}
	@Override
	public List<ComboListItemInfo> getNUR1016U00xEditGridCell7(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE CODE									");	
		sql.append("	, A.CODE_NAME CODE_NAME                            " );
		sql.append("	FROM NUR0102 A                                     " );
		sql.append("	WHERE A.HOSP_CODE = :hospCode                      " );
		sql.append("	AND A.CODE_TYPE = 'NUR1016_INFE_END_SAYU'          " );
		sql.append("    AND LANGUAGE  = :language						   " );
		sql.append("	ORDER BY A.CODE                                    " );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);

		List<ComboListItemInfo> listCombo= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listCombo;
	}
	@Override
	public List<ComboListItemInfo> getNUR1016U00layComboSet(String hospCode,
			String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CODE      CODE,				");
		sql.append("	CODE_NAME CODE_NAME                 ");
		sql.append("	FROM NUR0102                        ");
		sql.append("	WHERE HOSP_CODE = :hospCode         ");
		sql.append("	AND CODE_TYPE = :codeType           ");
		sql.append("    AND LANGUAGE  = :language			 " );
		sql.append("	ORDER BY 1                          ");
		                     

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);

		List<ComboListItemInfo> listCombo= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listCombo;
	}

	@Override
	public List<ComboListItemInfo> getINJ1001U01XEditGridCell88(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE CODE, A.CODE_NAME CODE_NAME  ");
		sql.append(" FROM NUR0102 A                             ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code           ");
		sql.append(" AND A.LANGUAGE = :f_language               ");
		sql.append(" AND A.CODE_TYPE = 'NUR1017_INFE_JAERYO'    ");
		sql.append(" ORDER BY A.CODE							");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> xeditGridCell88List= new JpaResultMapper().list(query, ComboListItemInfo.class); 
		return xeditGridCell88List;
	}
	@Override
	public List<InjsINJ1001U01XEditGridCell89ItemInfo> getInjsINJ1001U01XEditGridCell89ItemInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE CODE,CODE_NAME CODE_NAME,SORT_KEY      ");
		sql.append(" FROM NUR0102                                       ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code                     ");
		sql.append(" AND LANGUAGE = :f_language                         ");
		sql.append(" AND CODE_TYPE = 'INFE_CODE' ORDER BY 1, 3          ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<InjsINJ1001U01XEditGridCell89ItemInfo> xeditGridCell89List= new JpaResultMapper().list(query, InjsINJ1001U01XEditGridCell89ItemInfo.class); 
		return xeditGridCell89List;
	}
	
	@Override
	public List<ComboListItemInfo> getNUR1017U00GetComboListItem(
			String hospCode, String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT CODE      CODE,				");
		sql.append("	CODE_NAME CODE_NAME                 ");
		sql.append("	FROM NUR0102                        ");
		sql.append("	WHERE HOSP_CODE = :hospCode         ");
		sql.append("	AND CODE_TYPE = :codeType           ");
		sql.append("	AND LANGUAGE = :language            ");
		sql.append("	ORDER BY 1                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		 
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	
	public List<ComboListItemInfo> getCodeNameComboListItem (String codeType){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CODE					   ");
		sql.append("	, CODE_NAME                    ");
		sql.append("	FROM NUR0102                   ");
		sql.append("	WHERE HOSP_CODE = 'K01'        ");
		sql.append("	AND CODE_TYPE = :f_code_type   ");
		sql.append("	ORDER BY CODE                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("codeType", codeType);
		 
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	
	@Override
	public List<NUR0101U01GrdDetailInfo> getNUR0101U01GrdDetailInfo(String hospCode, String codeType, String language){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT IFNULL(CODE_TYPE, ' ') CODE_TYPE,                                  ");
		sql.append("        IFNULL(CODE, ' ') CODE,                                            ");
		sql.append("        IFNULL(CODE_NAME, ' ') CODE_NAME,                                  ");
		sql.append("        SORT_KEY,                                                          ");
		sql.append("        CONCAT(TRIM(IFNULL(CODE_TYPE, ' ')),TRIM(IFNULL(CODE, ' '))) KEY1  ");
		sql.append("   FROM NUR0102                                                            ");
		sql.append("  WHERE HOSP_CODE = :f_hosp_code                                           ");
		sql.append("    AND LANGUAGE = :f_language                                             ");
		sql.append("    AND CODE_TYPE = :f_code_type                                           ");
		sql.append("  ORDER BY 4, 2, 3                                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		 
		List<NUR0101U01GrdDetailInfo> listResult = new JpaResultMapper().list(query, NUR0101U01GrdDetailInfo.class);
		return listResult;
	}
	
	@Override
	public List<ComboListItemInfo> getNUR0812U00XeditGridCell1(String hospCode, String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT A.NEED_GUBUN  AS NEED_GUBUN	    ");
		sql.append("	               ,B.CODE_NAME   AS CODE_NAME	    ");
		sql.append("	FROM NUR0812 A								    ");
		sql.append("	JOIN NUR0102 B ON A.HOSP_CODE   = B.HOSP_CODE   ");
		sql.append("	              AND A.NEED_GUBUN  = B.CODE		");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code				");
		sql.append("	   AND B.CODE_TYPE = :f_code_type				");
		sql.append("	   AND B.LANGUAGE  = :f_language				");
		sql.append("	ORDER BY A.NEED_GUBUN							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	@Override
	public List<ComboListItemInfo> getNUR0812U00XeditGridCell3(String hospCode, String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.NEED_TYPE        AS NEED_TYPE		");
		sql.append("	      ,B.CODE_NAME        AS CODE_NAME		");
		sql.append("	FROM NUR0801 A								");
		sql.append("	JOIN NUR0102 B ON B.HOSP_CODE = A.HOSP_CODE	");
		sql.append("	              AND B.CODE      = A.NEED_TYPE	");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code			");
		sql.append("	  AND B.CODE_TYPE = :f_code_type			");
		sql.append("	  AND B.LANGUAGE  = :f_language				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	
	@Override
	public String getNUR0102CodeName(String hospCode, String language, String codeType, String code){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.CODE_NAME                                  ");
		sql.append("     FROM NUR0102 A                                    ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                   ");
		sql.append("      AND A.LANGUAGE  = :f_language                    ");
		sql.append("      AND A.CODE_TYPE = :f_code_type                   ");
		sql.append("      AND A.CODE      = :f_code	                	   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		query.setParameter("f_code", code);
		
		List<String> list = query.getResultList();
		if(CollectionUtils.isEmpty(list) && list.size() > 0 ){
			return list.get(0);
		}
		return "";
	}
	
	@Override
	public List<String> getNUR6011U01GetNur6005(String hospCode, String language, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT CONCAT(DATE_FORMAT(A.START_DATE, '%Y/%m/%d'),                                             ");
		sql.append("          CASE(IFNULL(A.END_DATE, '')) WHEN '' THEN '' ELSE                                         ");
		sql.append("               CONCAT('~', DATE_FORMAT(A.END_DATE, '%Y/%m/%d')) END, '->', B.CODE_NAME) METRESS     ");
		sql.append("     FROM NUR6005 A, NUR0102 B                                                                      ");
		sql.append("    WHERE A.HOSP_CODE     = :f_hosp_code                                                            ");
		sql.append("      AND A.BUNHO         = :f_bunho                                                                ");
		sql.append("      AND B.HOSP_CODE     = A.HOSP_CODE                                                             ");
		sql.append("      AND B.CODE          = A.METRESS_GUBUN                                                         ");
		sql.append("      AND B.CODE_TYPE     = 'METRESS_GUBUN'                                                         ");
		sql.append("      AND B.LANGUAGE      = :f_language                                                             ");
		sql.append("    ORDER BY A.START_DATE DESC                                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		
		List<String> list = query.getResultList();
		return list;
	}
	
	@Override
	public List<NUR1020U00grdNUR1022INInfo> getNUR1020U00grdNUR1022INInfo(String hospCode, String bunho,
			Double fkInp1001, String orderDate, String gubn, String prevqryflag, String gubnType) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(A.BUNHO, :f_bunho)                              BUNHO            ");
		sql.append("	      ,IFNULL(A.FKINP1001, :f_fkinp1001)                      FKINP1001        ");
		sql.append("	      ,IFNULL(A.YMD, STR_TO_DATE(:f_order_date, '%Y/%m/%d'))  YMD              ");
		sql.append("	      ,B.CODE                                                 IO_TYPE          ");
		sql.append("	      ,B.CODE_NAME                                            IO_TYPE_NAME     ");
		sql.append("	      ,IFNULL(A.IO_GUBN, :f_gubn)                             IO_GUBN          ");
		sql.append("	      ,IF(:f_prevqryflag = 'Y', '', IFNULL(A.IO_VALUE, ''))   IO_VALUE         ");
		sql.append("	  FROM NUR0102 B                                                               ");
		sql.append("	  LEFT JOIN NUR1022 A ON B.HOSP_CODE  = A.HOSP_CODE                            ");
		sql.append("	                     AND B.CODE       = A.IO_TYPE                              ");
		sql.append("	                     AND A.FKINP1001  = :f_fkinp1001                           ");
		sql.append("	                     AND A.YMD        = STR_TO_DATE(:f_order_date, '%Y/%m/%d') ");
		sql.append("	                     AND A.BUNHO      = :f_bunho                               ");
		sql.append("	                     AND A.IO_GUBN    = :f_gubn                                ");
		sql.append("	 WHERE B.HOSP_CODE    = :f_hosp_code                                           ");
		sql.append("	   AND B.CODE_TYPE    = :f_gubn_type                                           ");
		sql.append("	 ORDER BY B.SORT_KEY, B.CODE                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkInp1001);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_gubn", gubn);
		query.setParameter("f_prevqryflag", prevqryflag);
		query.setParameter("f_gubn_type", gubnType);
		
		List<NUR1020U00grdNUR1022INInfo> listResult = new JpaResultMapper().list(query, NUR1020U00grdNUR1022INInfo.class);
		return listResult;
	}
	
	@Override
	public List<ComboListItemInfo> getCbxNUR1020U00layHangmog(String hospCode, String bunho, Double fkinp1001) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT DISTINCT B.CODE, B.CODE_NAME               ");
		sql.append("	FROM NUR1121 A                                    ");
		sql.append("	JOIN NUR0102 B ON B.HOSP_CODE = A.HOSP_CODE       ");
		sql.append("	              AND B.CODE_TYPE = 'WATCH_HANGMOG'   ");
		sql.append("	              AND B.CODE = A.WATCH_HANGMOG        ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                  ");
		sql.append("	  AND A.WATCH_GWA IN                              ");
		sql.append("	        (SELECT Z.WATCH_GWA                       ");
		sql.append("	           FROM NUR1120 Z                         ");
		sql.append("	          WHERE Z.HOSP_CODE = A.HOSP_CODE         ");
		sql.append("	                AND Z.FKINP1001 = :f_fkinp1001    ");
		sql.append("	                AND Z.BUNHO = :f_bunho            ");
		sql.append("	                AND Z.SELECT_YN = 'Y')            ");
		sql.append("	ORDER BY B.CODE, B.CODE_NAME                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_fkinp1001", fkinp1001);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	
	
	@Override
	public List<TripleListItemInfo> getNUR6011U01layComboSet(String hospCode, String language, String codeType) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.CODE      CODE,                       ");
		sql.append("          IFNULL(A.CODE_NAME,'') CODE_NAME,       ");
		sql.append("          IFNULL(A.SORT_KEY,'') SORT_KEY          ");
		sql.append("    FROM NUR0102 A                                ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code               ");
		sql.append("     AND A.LANGUAGE  = :f_language                ");
		sql.append("     AND CODE_TYPE   = :f_code_type               ");
		sql.append("   ORDER BY CODE, SORT_KEY                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		
		List<TripleListItemInfo> listResult = new JpaResultMapper().list(query, TripleListItemInfo.class);
		return listResult;
	}
	
	@Override
	public List<NUR1010Q00layTimeInfo> getNUR1010Q00layTimeInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.CODE                                                                          ");
		sql.append("        , A.CODE_NAME                                                                     ");
		sql.append("        , A.GROUP_KEY                                                                     ");
		sql.append("     FROM NUR0102 A                                                                       ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                                      ");
		sql.append("      AND A.LANGUAGE  = :f_language                                                       ");
		sql.append("      AND A.CODE_TYPE = 'NUR2001U04_TIMER'                                                ");
		sql.append("      AND SYSDATE() BETWEEN IFNULL(A.START_DATE, STR_TO_DATE('2000/01/01','%Y/%m/%d'))    ");
		sql.append("                        AND IFNULL(A.END_DATE, STR_TO_DATE('9998/12/31','%Y/%m/%d'))      ");
		sql.append("    ORDER BY A.SORT_KEY                                                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<NUR1010Q00layTimeInfo> listResult = new JpaResultMapper().list(query, NUR1010Q00layTimeInfo.class);
		return listResult;
	}
	
	@Override
	public List<NUR0801U00GrdMasterInfo> getNUR0801U00GrdMasterInfo(String hospCode, String language, String needType) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.HO_DONG        AS HO_DONG       ");
		sql.append("	     , B.BUSEO_NAME     AS BUSEO_NAME    ");
		sql.append("	     , A.NEED_TYPE      AS NEED_TYPE     ");
		sql.append("	     , C.CODE_NAME      AS CODE_NAME     ");
		sql.append("	     , A.MAKE_H_FILE_YN                  ");
		sql.append("	  FROM NUR0801 A,                        ");
		sql.append("	       VW_GWA_NAME B,                    ");
		sql.append("	       NUR0102 C                         ");
		sql.append("	 WHERE A.HOSP_CODE       =:f_hosp_code   ");
		sql.append("	       AND B.HOSP_CODE   = A.HOSP_CODE   ");
		sql.append("	       AND B.BUSEO_CODE  = A.HO_DONG     ");
		sql.append("	       AND C.HOSP_CODE   = A.HOSP_CODE   ");
		sql.append("	       AND C.CODE_TYPE   =:f_need_type   ");
		sql.append("	       AND C.CODE        = A.NEED_TYPE   ");
		sql.append("	       AND C.LANGUAGE    = :f_language   ");
		sql.append("	       AND B.LANGUAGE    = :f_language   ");
		sql.append("	 ORDER BY A.HO_DONG                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_need_type", needType);
		
		List<NUR0801U00GrdMasterInfo> listResult = new JpaResultMapper().list(query, NUR0801U00GrdMasterInfo.class);
		return listResult;
	}
	
	@Override
	public List<String> getNUR1001R09layHodongPrint(String hospCode, String language, String hoDong) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.CODE CODE                                                        ");
		sql.append("     FROM NUR0102 A                                                          ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                         ");
		sql.append("      AND A.LANGUAGE  = :f_language                                          ");
		sql.append("      AND A.CODE_TYPE = CONCAT('HO_DONG_NAME_GUBUN' ,'_' ,:f_ho_dong)        ");
		sql.append("    ORDER BY CODE                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_ho_dong", hoDong);
		
		List<String> list = query.getResultList();
		return list;
	}
	
	@Override
	public List<NUR0802U00grdDetailInfo> getNUR0802U00grdDetailInfo(String hospCode, String language, String needType,
			String codeType, Integer startNum, Integer offset) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.NEED_TYPE       AS NEED_TYPE                    ");
		sql.append("	      ,A.NEED_GUBUN      AS NEED_GUBUN                   ");
		sql.append("	      ,B.CODE_NAME       AS CODE_NAME                    ");
		sql.append("	      ,A.NEED_ASMT_CODE  AS NEED_ASMT_CODE               ");
		sql.append("	      ,C.NEED_ASMT_NAME  AS NEED_ASMT_NAME               ");
		sql.append("	     , A.MAKE_H_FILE_YN  AS MAKE_H_FILE_YN               ");
		sql.append("	FROM NUR0802 A                                           ");
		sql.append("	JOIN NUR0102 B ON B.HOSP_CODE       = A.HOSP_CODE        ");
		sql.append("	              AND B.CODE_TYPE       = :f_code_type       ");
		sql.append("	              AND B.CODE            = A.NEED_GUBUN       ");
		sql.append("	              AND B.LANGUAGE        = :f_language        ");
		sql.append("	JOIN NUR0803 C ON C.HOSP_CODE       = A.HOSP_CODE        ");
		sql.append("	              AND C.NEED_GUBUN      = A.NEED_GUBUN       ");
		sql.append("	              AND C.NEED_ASMT_CODE  = A.NEED_ASMT_CODE   ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                         ");
		sql.append("	  AND A.NEED_TYPE = :f_need_type                         ");
		sql.append("	ORDER BY A.NEED_GUBUN,B.CODE_NAME,A.NEED_ASMT_CODE       ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :startNum, :offset								 ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_need_type", needType);
		query.setParameter("f_code_type", codeType);
		if(startNum != null && offset !=null){
			query.setParameter("startNum", startNum);
			query.setParameter("offset", offset);
		}
		
		List<NUR0802U00grdDetailInfo> listResult = new JpaResultMapper().list(query, NUR0802U00grdDetailInfo.class);
		return listResult;
	}	
	
	@Override
	public List<ComboListItemInfo> getNUR1035U00layModifyLimit(String hospCode, String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.CODE_NAME LIMIT_YN, CAST(A.SORT_KEY AS CHAR) DAYS       ");
		sql.append("    FROM NUR0102 A                                   ");
		sql.append("   WHERE A.HOSP_CODE = :f_hosp_code                  ");
		sql.append("     AND A.LANGUAGE  = :f_language                   ");
		sql.append("     AND A.CODE_TYPE = :f_code_type        			 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	
	@Override
	public List<ComboListItemInfo> getNUR9001U00layComboSet(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("   SELECT A.CODE                   CODE,                    ");
		sql.append("          CONCAT(A.CODE,' : ',A.CODE_NAME) CODE_NAME        ");
		sql.append("     FROM NUR0102 A                                         ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                        ");
		sql.append("      AND A.LANGUAGE  = :f_language                         ");
		sql.append("      AND A.CODE_TYPE = 'SOAP'                              ");
		sql.append("    ORDER BY A.SORT_KEY                                     ");
		                     

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);

		List<ComboListItemInfo> listCombo= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listCombo;
	}
	
	@Override
	public List<NUR8003R02grdDetailInfo> getNUR8003R02grdDetailInfo(String hospCode, String language, String bunho,
			String needHType, String fromDate, String toDate, String writeDong) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.WRITE_DATE                                                                                               ");
		sql.append("	     , A.BUNHO                                                                                                    ");
		sql.append("	     , C.SUNAME                                                                                                   ");
		sql.append("	     , A.FIRST_GUBUN                                                                                              ");
		sql.append("	     , D.CODE_NAME                                                                                                ");
		sql.append("	     , B.PAYLOAD_NO                                                                                               ");
		sql.append("	     , E.NEED_ASMT_NAME                                                                                           ");
		sql.append("	     , A.H_FILE_STRING                                                                                            ");
		sql.append("	  FROM VW_NUR_HFILE_CODE_INFO A                                                                                   ");
		sql.append("	  JOIN NUR0812  B ON B.HOSP_CODE      = A.HOSP_CODE                                                               ");
		sql.append("	                 AND B.NEED_H_TYPE    = :f_need_h_type                                                            ");
		sql.append("	                 AND B.NEED_GUBUN     = A.FIRST_GUBUN                                                             ");
		sql.append("	                 AND B.NEED_ASMT_CODE = A.GR_CODE                                                                 ");
		sql.append("	  JOIN OUT0101  C ON C.HOSP_CODE      = A.HOSP_CODE                                                               ");
		sql.append("	                 AND C.BUNHO          = A.BUNHO                                                                   ");
		sql.append("	  JOIN NUR0102 D ON D.HOSP_CODE      = A.HOSP_CODE                                                                ");
		sql.append("	                AND D.CODE_TYPE      = 'NEED_GUBUN'                                                               ");
		sql.append("	                AND D.CODE           = A.FIRST_GUBUN                                                              ");
		sql.append("	                AND D.LANGUAGE       = :f_language                                                                ");
		sql.append("	  JOIN NUR0803 E ON E.HOSP_CODE      = A.HOSP_CODE                                                                ");
		sql.append("	                AND E.NEED_GUBUN     = A.FIRST_GUBUN                                                              ");
		sql.append("	                AND E.NEED_ASMT_CODE = A.GR_CODE                                                                  ");
		sql.append("	  ,(select @kcck_hosp_code \\:= :f_hosp_code) TMP                                                                 ");
		sql.append("	 WHERE A.HOSP_CODE      = :f_hosp_code                                                                            ");
		sql.append("	   AND A.WRITE_DATE     BETWEEN STR_TO_DATE(:f_from_date, '%Y/%m') AND LAST_DAY(STR_TO_DATE(:f_to_date, '%Y/%m')) ");
		sql.append("	   AND A.WRITE_HODONG   = :f_write_dong                                                                           ");
		sql.append("	   AND A.BUNHO          LIKE IF(:f_bunho IS NULL OR :f_bunho = '', '%', :f_bunho)                                 ");
		sql.append("	   AND A.H_FILE_STRING  IS NOT NULL                                                                               ");
		sql.append("	 ORDER BY                                                                                                         ");
		sql.append("	       A.WRITE_DATE                                                                                               ");
		sql.append("	     , A.BUNHO                                                                                                    ");
		sql.append("	     , A.FIRST_GUBUN                                                                                              ");
		sql.append("	     , E.SORT_KEY                                                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_need_h_type", needHType);
		query.setParameter("f_write_dong", writeDong);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		
		List<NUR8003R02grdDetailInfo> listCombo= new JpaResultMapper().list(query, NUR8003R02grdDetailInfo.class);
		return listCombo;
	}
	
	@Override
	public String getNUR9001U00lblBojo(String hospCode, String language, String codeType, String code){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT CONCAT(A.CODE,' : ',A.CODE_NAME) CODE_NAME   ");
		sql.append("     FROM NUR0102 A                                    ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                   ");
		sql.append("      AND A.LANGUAGE  = :f_language                    ");
		sql.append("      AND A.CODE_TYPE = :f_code_type                   ");
		sql.append("      AND A.CODE      = :f_code	                	   ");
		sql.append("      ORDER BY SORT_KEY			                	   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_language", language);
		query.setParameter("f_code", code);
		
		List<String> list = query.getResultList();
		if(CollectionUtils.isEmpty(list) && list.size() > 0 ){
			return list.get(0);
		}
		return "";
	}
	
	@Override
	public List<NUR1001U00LayComboSetInfo> getNUR1001U00LayComboSetInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.CODE,                          ");
		sql.append("          A.CODE_NAME,                     ");
		sql.append("          A.CODE_TYPE,                     ");
		sql.append("          CAST(A.SORT_KEY AS CHAR)         ");
		sql.append("     FROM NUR0102 A                        ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code       ");
		sql.append("      AND A.LANGUAGE  = :f_language        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<NUR1001U00LayComboSetInfo> listCombo= new JpaResultMapper().list(query, NUR1001U00LayComboSetInfo.class);
		return listCombo;
	}
	
	@Override
	public List<String> getNUR1001U00GrdNUR1029FindClick(String hospCode, String language, String codeType) {
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.CODE_NAME                                                        ");
		sql.append("     FROM NUR0102 A                                                          ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                                         ");
		sql.append("      AND A.LANGUAGE  = :f_language                                          ");
		sql.append("      AND A.CODE_TYPE = :f_code_type        								 ");
		sql.append("    ORDER BY CODE                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		
		List<String> list = query.getResultList();
		return list;
	}

}



