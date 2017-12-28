package nta.med.data.dao.medi.ocs.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0132RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.cpls.CPL0000Q00GetSigeyulDataSelect1ListItemInfo;
import nta.med.data.model.ihis.nuro.OUT1001P03GrdOrderInfo;
import nta.med.data.model.ihis.ocsa.OCS0103Q00CreateOrderGubunInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U12MakeSangyongTabInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U18MakeJaeryoGubunTabListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0108U00CreateComboItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0131U00GrdOCS0132Info;
import nta.med.data.model.ihis.ocsa.OCS0221Q01DloOCS0221Info;
import nta.med.data.model.ihis.ocsa.Ocs0131U01Grd0132ListItemInfo;
import nta.med.data.model.ihis.ocsa.Ocs3003Q10GrdOrderListItemInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0221U00GrdOCS0221ListInfo;
import nta.med.data.model.ihis.ocsi.OCS1024U00xEditGridCell20Info;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01GetChuciInfo;
import nta.med.data.model.ihis.phys.PHY0001U00GrdOCS0132Info;
import nta.med.data.model.ihis.phys.PHY0001U00GrdRehaSinryouryouCodeInfo;
import nta.med.data.model.ihis.system.CheckHideButtonInfo;
import nta.med.data.model.ihis.system.HILoadCodeNameInfo;
import nta.med.data.model.ihis.system.LoadOcs0132Info;
import nta.med.data.model.ihis.xrts.XRT0201U00GrdPaListItemInfo;


/**
 * @author dainguyen.
 */
public class Ocs0132RepositoryImpl implements Ocs0132RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OcsoOCS1003P01GetChuciInfo> getOcsoOCS1003P01GetChuciInfo(String hospCode, String codeType, String valuePoint){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.CODE, A.GROUP_KEY             ");
	    sql.append("  FROM OCS0132 A                       ");
	    sql.append(" WHERE A.HOSP_CODE = :hospCode         ");
	    sql.append("   AND A.CODE_TYPE = :codeType         ");
	    sql.append("   AND A.VALUE_POINT = :valuePoint     ");
	    
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("valuePoint", valuePoint);

		List<OcsoOCS1003P01GetChuciInfo> list = new JpaResultMapper().list(query, OcsoOCS1003P01GetChuciInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getOcsoOCS1003P01GetGubunInfo(String hospCode, String code, String codeType, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.CODE, A.CODE_NAME         ");
		sql.append("  FROM OCS0132 A                     ");
		sql.append(" WHERE A.CODE_TYPE  LIKE :codeType   ");
		sql.append("   AND A.CODE       LIKE :code       ");
		sql.append("   AND A.HOSP_CODE  = :hospCode      ");
		sql.append("   AND A.LANGUAGE = :language        ");
		sql.append(" ORDER BY A.SORT_KEY, A.CODE         ");
		   
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("code", code);
		query.setParameter("language", language);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<String> getOcsoOCS1003Q05CodeList(String language, String hospCode, String codeType){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.CODE                     ");
		sql.append("  FROM OCS0132 A                  ");
		sql.append(" WHERE A.HOSP_CODE = :hospCode ");
		sql.append("   AND A.CODE_TYPE = :codeType ");
		sql.append("   AND A.LANGUAGE = :language   ");
		sql.append(" ORDER BY A.CODE                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);

		List<String> list = query.getResultList();
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getOCS0132ComboList(String hospCode,String language, String codeType){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.CODE, A.CODE_NAME        						 ");
		sql.append("  FROM OCS0132 A                 						  ");
		sql.append(" WHERE A.CODE_TYPE = :codeType  AND A.HOSP_CODE = :hospCode ");
		sql.append("   AND A.LANGUAGE = :language   						  ");
		sql.append(" ORDER BY A.CODE                  						 ");

		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<String> getOCS0132CodeNameList(String hospCode,String language, String codeType, String code,boolean isOrder){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT CODE_NAME                					    ");
		sql.append("  FROM OCS0132                   					    ");
		sql.append(" WHERE CODE_TYPE =  :codeType AND HOSP_CODE = :hospCode ");
		sql.append("   AND LANGUAGE = :language    							");
		sql.append("   AND CODE = :code            							");
		if(isOrder){
			sql.append("   ORDER BY CODE_NAME             			    	");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("code", code);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		query.setParameter("hospCode", hospCode);

		List<String> list = query.getResultList();
		return list;
	}
	
	@Override
	public List<OcsaOCS0221U00GrdOCS0221ListInfo> getOcsaOCS0221U00GrdOCS0221List(String hospCode, String language, String memb){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT :f_memb      MEMB          ,                              ");
		sql.append("       A.SORT_KEY   SEQ           ,                              ");
		sql.append("       A.CODE       CATEGORY_GUBUN,                              ");
		sql.append("       A.CODE_NAME  CATEGORY_NAME ,                              ");
		sql.append("       0            COMMENT_LIMIT                                ");
		sql.append("  FROM OCS0132 A                                                 ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                ");
		sql.append("   AND A.LANGUAGE = :f_language                                  ");
		sql.append("   AND A.CODE_TYPE = 'CATEGORY_GUBUN'                            ");
		sql.append("   AND A.CODE      <> '99'                                       ");
		sql.append("   AND NOT EXISTS ( SELECT 'X'                                   ");
		sql.append("                      FROM OCS0221 B                             ");
		sql.append("                     WHERE B.HOSP_CODE      = A.HOSP_CODE        ");
		sql.append("                       AND B.CATEGORY_GUBUN = A.CODE             ");
		sql.append("                       AND B.MEMB           = :f_memb )          ");
		sql.append("UNION ALL                                                        ");
		sql.append("SELECT A.MEMB            ,                                       ");
		sql.append("       A.SEQ             ,                                       ");
		sql.append("       A.CATEGORY_GUBUN  ,                                       ");
		sql.append("       A.CATEGORY_NAME   ,                                       ");
		sql.append("       A.COMMENT_LIMIT                                           ");
		sql.append("  FROM OCS0221 A                                                 ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                ");
		sql.append("   AND A.MEMB      = :f_memb                                     ");
		sql.append(" ORDER BY 2                                                      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_memb", memb);

		List<OcsaOCS0221U00GrdOCS0221ListInfo> list = new JpaResultMapper().list(query, OcsaOCS0221U00GrdOCS0221ListInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getOcsaOCS0221U00CommonListItem(String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT CODE, CODE_NAME               ");
		sql.append("  FROM OCS0132                       ");
		sql.append(" WHERE CODE_TYPE = 'CATEGORY_GUBUN'  ");
		sql.append("   AND LANGUAGE 	 :f_language        ");
		sql.append(" ORDER BY 1                          ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getInjsComboListItemInfo(String hospCode, String language, String codeType){
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT CODE, CODE_NAME            ");
		sql.append("    FROM OCS0132                    ");
		sql.append("    WHERE HOSP_CODE = :f_hosp_code  ");
		sql.append("    AND LANGUAGE = :f_language      ");
		sql.append("    AND CODE_TYPE = :f_code_type    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public List<ComboListItemInfo> getPFE7001CboPartInfo(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT '%' CODE, FN_ADM_MSG(221,:f_language) CODE_NAME  ");
		sql.append("  UNION                                                   ");
		sql.append("  SELECT X.CODE, X.CODE_NAME                              ");
		sql.append("    FROM OCS0132 X                                        ");
		sql.append("   WHERE X.HOSP_CODE = :f_hosp_code                       ");
		sql.append("     AND X.LANGUAGE = :f_language                         ");
		sql.append("     AND X.CODE_TYPE = 'OCS_ACT_PART_02'                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getXRT7001Q01CboPart(String hospCode,String language,String codeType) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT '%' CODE, FN_ADM_MSG('221',:f_language) CODE_NAME  UNION                                                                           ");
		sql.append(" SELECT X.CODE  , X.CODE_NAME FROM OCS0132 X WHERE X.HOSP_CODE = :f_hosp_code AND X.LANGUAGE =:f_language   AND X.CODE_TYPE = :f_code_type  "); 
		 Query query= entityManager.createNativeQuery(sql.toString());
		 query.setParameter("f_hosp_code", hospCode);
		 query.setParameter("f_language", language);
		 query.setParameter("f_code_type", codeType);
		 List<ComboListItemInfo> listCboPart= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listCboPart;
	}


	@Override
	public List<ComboListItemInfo> getOCS0311U00CboPartBySetTable(String hospCode,String language,String currGroupID) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT CODE, CODE_NAME  FROM OCS0132 WHERE HOSP_CODE = :f_hosp_code  AND LANGUAGE = :f_language AND CODE_TYPE = 'SET_PART'     ");
		if(currGroupID.equals("OCS")){
			sql.append(" ORDER BY GROUP_KEY																											");
		}else if(currGroupID.equals("OPR")){
			sql.append(" AND GROUP_KEY = 'OP'																										");
		}else{
			sql.append(" AND GROUP_KEY = :currGroupId							      																");
		}
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		if(!currGroupID.equals("OCS") && !currGroupID.equals("OPR")){
			query.setParameter("currGroupId", currGroupID);
		}
		List<ComboListItemInfo> cboPartBySetTable= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return cboPartBySetTable;
	}

	@Override
	public List<ComboListItemInfo> getOCS1003Q05JusaComboBox(String hospCode,
			String codeType, String language, String code, String order) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("  SELECT A.CODE, A.CODE_NAME         ");
		sql.append("  FROM OCS0132 A                     ");
		sql.append(" WHERE A.CODE_TYPE  = :codeType   ");
		sql.append("   AND A.HOSP_CODE  = :hospCode      ");
		sql.append("   AND A.LANGUAGE = :language        ");
		if(!StringUtils.isEmpty(code)){
			sql.append("   AND A.CODE = :code        ");
		}
		if(!StringUtils.isEmpty(order)){
		sql.append(" ORDER BY A.CODE    		         ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);
		if(!StringUtils.isEmpty(code)){
			query.setParameter("code", code);
		}

		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<OCS0131U00GrdOCS0132Info> getOCS0131U00GrdOCS0132Info(String hospCode,String codeType){
		StringBuilder sql= new StringBuilder();
		sql.append("SELECT A.CODE                  CODE,                     ");
		sql.append("       A.CODE_NAME             CODE_NAME,                ");
		sql.append("       IFNULL(A.SORT_KEY,0)    SORT_KEY,                 ");
		sql.append("       A.GROUP_KEY             GROUP_KEY,                ");
		sql.append("       A.MENT                  MENT,                     ");
		sql.append("       IFNULL(A.VALUE_POINT,0) VALUE_POINT,              ");
		sql.append("       A.UPD_ID                USER_ID,                  ");
		sql.append("       A.CODE_TYPE             CODE_TYPE                 ");
		sql.append("  FROM OCS0132 A                                         ");
		sql.append(" WHERE A.CODE_TYPE = TRIM(:f_code_type)                  ");
		sql.append("   AND A.HOSP_CODE = :f_hosp_code                        ");
		sql.append(" ORDER BY A.CODE_TYPE, LPAD(A.SORT_KEY,10,'0'), A.CODE   ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);

		List<OCS0131U00GrdOCS0132Info> list = new JpaResultMapper().list(query, OCS0131U00GrdOCS0132Info.class);
		return list;
	}
	@Override
	public List<OCS0108U00CreateComboItemInfo> getOCS0108U00CreateComboItemInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT '' AS CODE, ' ' AS CODE_NAME, '00' UNION ALL                                                  ");
		sql.append(" SELECT CODE, CONCAT(CODE,':',CODE_NAME) CODE_NAME, CODE SEQ                                           ");
		sql.append(" FROM OCS0132 WHERE HOSP_CODE = :f_hosp_code AND LANGUAGE = :f_language AND CODE_TYPE = 'ORD_DANUI'    ");
		sql.append(" ORDER BY 3 																						   ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<OCS0108U00CreateComboItemInfo> list = new JpaResultMapper().list(query, OCS0108U00CreateComboItemInfo.class);
		return list;
	}

	@Override
	public String getLoadColumnCodeNameInfoCaseCode(String hospCode,String language,String arg1, String arg2) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IFNULL(A.CODE_NAME, ' ') FROM OCS0132 A WHERE A.CODE_TYPE = :f_aArgu1 AND A.CODE = :f_aArgu2 AND A.HOSP_CODE  = :f_hosp_code AND A.LANGUAGE=:f_language");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_aArgu1", arg1);
		query.setParameter("f_aArgu2", arg2);
		List<String> listResult = query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
	

	
	@Override
	public List<ComboListItemInfo> getComboDataSourceInfoByCodeType(String hospCode, String language,String codeType, boolean isAll) {
		StringBuilder sql = new StringBuilder();
		if(isAll){
			sql.append(" SELECT '0'  AS CODE , '0'  AS CODE_NAME UNION ALL                                            ");
		}
		sql.append(" SELECT A.CODE CODE, A.CODE CODE_NAME FROM OCS0132 A                                               ");
		sql.append(" WHERE A.CODE_TYPE = :f_code_type AND A.HOSP_CODE   = :f_hosp_code AND A.LANGUAGE =:f_language      ");
		if(isAll){
			sql.append(" ORDER BY 1							                    										");
		}else{
			sql.append(" ORDER BY A.SORT_KEY, A.CODE 																	    ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		List<ComboListItemInfo> listResult= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	
	@Override
	public List<ComboListItemInfo> getComboDataSourceInfoByCodeTypeOrOrderBy(String hospCode, String language, String codeType, boolean isOrder) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE, CODE_NAME           ");
		sql.append(" FROM OCS0132 a                   ");
		sql.append(" where a.HOSP_CODE = :f_hosp_code ");
		sql.append(" AND a.LANGUAGE =:f_language      ");
		sql.append(" AND a.CODE_TYPE = :f_code_type    ");
		if(isOrder){
			sql.append(" ORDER BY a.SLIP_CODE    ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		List<ComboListItemInfo> listResult= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public List<ComboListItemInfo> getComboDataSourceInfoCaseOrderGubunBas(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE CODE, CONCAT(A.CODE,'. ',A.CODE_NAME) CODE_NAME      ");
		sql.append("  FROM OCS0132 A                                                    ");
		sql.append(" WHERE A.CODE_TYPE = 'ORDER_GUBUN_BAS'                              ");
		sql.append("   AND A.HOSP_CODE = :f_hosp_code                                   ");
		sql.append("   AND A.LANGUAGE =:f_language                                      ");
		sql.append(" ORDER BY A.SORT_KEY, A.CODE 										");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> listResult= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	@Override
	public List<ComboListItemInfo> getOCS0101U00ComboListItem(String hospCode,
			String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CODE, CONCAT(CODE,': ',CODE_NAME) CODE_NAME		");
		sql.append("	  FROM OCS0132                                          ");
		sql.append("	 WHERE CODE_TYPE = :codeType		                    ");
		sql.append("	   AND HOSP_CODE = :hospCode                            ");
		sql.append("	   AND LANGUAGE = :language                             ");
		sql.append("	  ORDER BY CODE                                         ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("language", language);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOCS0103U12CboInitGubunListItem(
			String hospCode,String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE														");
		sql.append("	     , IF(A.CODE_NAME = '通常', '定期薬', A.CODE_NAME) CODE_NAME     ");
		sql.append("	  FROM OCS0132 A                                                    ");
		sql.append("	 WHERE A.CODE_TYPE LIKE 'INPUT_GUBUN'                               ");
		sql.append("	   AND (   A.CODE LIKE 'D%'                                         ");
		sql.append("	        OR A.CODE = 'CK')                                           ");
		sql.append("	   AND A.HOSP_CODE = :hospCode                                      ");
		sql.append("	   AND A.VALUE_POINT = '1'                                          ");
		sql.append("	   AND LANGUAGE = :language                             			");
		sql.append("	 ORDER BY A.SORT_KEY, A.CODE                                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOCS0103U12CboDvTimeListItemInfo(
			String hospCode, String code, String codeType, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("  SELECT A.CODE, A.CODE_NAME         ");
		sql.append("  FROM OCS0132 A                     ");
		sql.append(" WHERE A.CODE_TYPE  = :codeType   ");
		sql.append("   AND A.CODE      != :code       ");
		sql.append("   AND A.HOSP_CODE  = :hospCode      ");
		sql.append("   AND A.LANGUAGE = :language        ");
		sql.append(" ORDER BY A.SORT_KEY, A.CODE         ");
		   
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("code", code);
		query.setParameter("language", language);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<OCS0103U12MakeSangyongTabInfo> getOCS0103U12MakeSangyongTabListItem(
			String memb, String inputTab, String hospCode, String language) {
		 StringBuilder sql = new StringBuilder();
		
		 sql.append("	(SELECT DISTINCT B.CODE      ORDER_GUBUN      , 												");
		 sql.append("	       B.CODE_NAME          ORDER_GUBUN_NAME ,                                                  ");
		 sql.append("	       :memb             MEMB             ,                                                     ");
		 sql.append("	       ''                                 ,                                                     ");
		 sql.append("	       CONCAT(IF(A.MAIN_YN ='Y', '0', '9'), TRIM(LPAD(B.SORT_KEY, 3, '0')))     ORDER_BY        ");
		 sql.append("	  FROM OCS0132 B                                                                                ");
		 sql.append("	     , OCS0142 A                                                                                ");
		 sql.append("	 WHERE A.INPUT_TAB LIKE :inputTab                                                               ");
		 sql.append("	   AND  A.HOSP_CODE   = :hospCode                                                               ");
		 sql.append("	   AND A.ORDER_GUBUN = B.CODE                                                                   ");
		 sql.append("	   AND B.CODE_TYPE   = 'ORDER_GUBUN_BAS'                                                        ");
		 sql.append("	   AND B.LANGUAGE = :language                                                                   ");
		 sql.append("	   AND B.HOSP_CODE   = A.HOSP_CODE         )                                                    ");
		 sql.append("	 ORDER BY ORDER_BY                                                                              ");
		   
	     Query query = entityManager.createNativeQuery(sql.toString());
	     query.setParameter("memb", memb);
	     query.setParameter("inputTab", inputTab);
	     query.setParameter("hospCode", hospCode);
	     query.setParameter("language", language);
         
	     List<OCS0103U12MakeSangyongTabInfo> list = new JpaResultMapper().list(query, OCS0103U12MakeSangyongTabInfo.class);
	     return list;
	}

	@Override
	public List<OCS0103U12MakeSangyongTabInfo> getOCS0103U12MakeSangyongTabListItemElse(
			String memb, String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT DISTINCT                            				");   
		sql.append("	       C.XRAY_GUBUN          ORDER_GUBUN                ");
		sql.append("	     , D.CODE_NAME	         ORDER_GUBUN_NAME           ");
		sql.append("	     , :memb       			 MEMB                       ");
		sql.append("	     , 'Y'                   XRAY_YN                    ");
		sql.append("	     , cast(D.SEQ as char)                 SORT_SEQ     "); 
		sql.append("	  FROM OCS0142 A                                        ");
		sql.append("	     , OCS0103 B                                        ");
		sql.append("	     , XRT0001 C                                        ");
		sql.append("	     , XRT0102 D                                        ");
		sql.append("	 WHERE A.INPUT_TAB = '07'                               ");
		sql.append("	   AND A.HOSP_CODE = :hospCode                          ");
		sql.append("	   AND A.ORDER_GUBUN = B.ORDER_GUBUN                    ");
		sql.append("	   AND A.MAIN_YN = 'Y'                                  ");
		sql.append("	   AND A.HOSP_CODE = B.HOSP_CODE                        ");
		sql.append("	   AND B.HANGMOG_CODE = C.XRAY_CODE                     ");
		sql.append("	   AND C.HOSP_CODE = B.HOSP_CODE                        ");
		sql.append("	   AND D.HOSP_CODE = C.HOSP_CODE                        ");
		sql.append("	   AND C.XRAY_GUBUN   = D.CODE                          ");
		sql.append("	   AND D.LANGUAGE = :language                           ");
		sql.append("	   AND D.CODE_TYPE    = 'X1'                            ");
		sql.append("	 UNION                                                  ");
		sql.append("	SELECT B.CODE                ORDER_GUBUN                ");
		sql.append("	     , B.CODE_NAME           ORDER_GUBUN_NAME           ");
		sql.append("	     , :memb                 MEMB                       ");
		sql.append("	     , A.MAIN_YN             XRAY_YN                    ");
		sql.append("	     ,cast(9 as char)                     SORT_SEQ       ");
		sql.append("	  FROM OCS0142 A                                        ");
		sql.append("	     , OCS0132 B                                        ");
		sql.append("	 WHERE A.INPUT_TAB = '07'                               ");
		sql.append("	   AND A.HOSP_CODE = :hospCode                          ");
		sql.append("	   AND A.ORDER_GUBUN = B.CODE                           ");
		sql.append("	   AND B.LANGUAGE = :language                           ");
		sql.append("	   AND A.MAIN_YN != 'Y'                                 ");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE                        ");
		sql.append("	   AND B.CODE_TYPE = 'ORDER_GUBUN_BAS'                  ");
		sql.append("	   ORDER BY 4 DESC, 5, 1                                ");


		Query query = entityManager.createNativeQuery(sql.toString());
	    query.setParameter("memb", memb);
	    query.setParameter("hospCode", hospCode);
	    query.setParameter("language", language);
        
	    List<OCS0103U12MakeSangyongTabInfo> list = new JpaResultMapper().list(query, OCS0103U12MakeSangyongTabInfo.class);
	    return list;
	}
	
	@Override
	public String getSubPartDoctor(String hospCode, String doctor, String subSystemId){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_OCS_GET_SUBPART_DOCTOR(:f_hosp_code,:f_doctor,:f_sub_system_id) ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_doctor", doctor);
		query.setParameter("f_sub_system_id", subSystemId);
		
		List<String> list = query.getResultList();
		if(list!= null && list.size() > 0){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public Date getFnDrgGetCycleOrdDate(String hospCode, Date ordDate, String hoDong){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_DRG_GET_CYCLE_DATE_BASE('ORD',:f_hosp_code,:f_ord_date,:f_ho_dong) ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ord_date", ordDate);
		query.setParameter("f_ho_dong", hoDong);
		
		List<Date> list = query.getResultList();
		if(list!= null && list.size() > 0){
			return list.get(0);
		}
		return null;
	}

	@Override
	public List<ComboListItemInfo> getOCS0103U12FbxJusaComboListItemInfo(
			String hospCode, String language, String find, String agr1) {
		StringBuilder sql = new StringBuilder();
		find="%"+find+"%";
		sql.append(" SELECT A.CODE, A.CODE_NAME                                                                                 ");
		sql.append(" FROM VW_JUSA_RANK R RIGHT JOIN OCS0132 A ON R.IO_GUBUN= IFNULL(:f_aArgu1, 'O')   AND R.JUSA =  A.CODE      ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                                                           ");
		sql.append(" AND A.LANGUAGE = :f_language                                                                               ");
		sql.append(" AND A.CODE_TYPE = 'JUSA'                                                                                   ");
		sql.append(" AND A.CODE_NAME LIKE :f_find1                                                                              ");
		sql.append(" ORDER BY IFNULL(R.RANK_CNT, 0) DESC 																		");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_aArgu1", agr1);
		query.setParameter("f_find1", find);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<HILoadCodeNameInfo> getHILoadCodeNameInfo(String hospCode,String language, String orderGubun, String specimenCode,
			String jusa, String pay, String orderGubunBas, String bogyongCode,String jusaSpdGubun, String jundaPartOut, String judalPartInp,
			String ordDanui, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT IFNULL(FN_OCS_LOAD_CODE_NAME('ORDER_GUBUN_BAS', TRIM(:f_orderGubun),:f_hosp_code,:f_language), 'Etc')         ORDER_GUBUN_NAME                          ");
		sql.append("  , FN_OCS_LOAD_SPECIMEN_NAME    (:f_hosp_code,TRIM(:f_specimen_code))                                      SPECIMEN_NAME                                       ");
		sql.append("  , FN_OCS_LOAD_CODE_NAME        ('JUSA', TRIM(:f_jusa),:f_hosp_code,:f_language)                             JUSA_NAME                                         ");
		sql.append("  , FN_OCS_LOAD_CODE_NAME        ('PAY',  TRIM(:f_pay),:f_hosp_code,:f_language)                               PAY_NAME                                         ");
		sql.append("  , FN_OCS_BOGYONG_COL_NAME      (TRIM(:f_order_gubun_bas),TRIM(:f_bogyong_code),TRIM(:f_jusa_spd_gubun),:f_hosp_code,:f_language)            BOGYONG_NAME      ");
		sql.append("  , FN_BAS_LOAD_GWA_NAME(TRIM(:f_jundal_part_out), SYSDATE(),:f_hosp_code,:f_language)                       JUNDAL_PART_OUT_NAME                               ");
		sql.append("  , FN_BAS_LOAD_GWA_NAME(TRIM(:f_jundal_part_inp), SYSDATE(),:f_hosp_code,:f_language)                             JUNDAL_PART_INP_NAME                         ");
		sql.append("  , FN_OCS_LOAD_CODE_NAME        ('ORD_DANUI', TRIM(:f_ord_danui),:f_hosp_code,:f_language)                             ORD_DANUI_NAME                          ");
		sql.append("  , FN_DRG_MAYAK_YN(:f_hosp_code,:f_hangmog_code,null)                                                           MAYAK_YN								    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_orderGubun", orderGubun);
		query.setParameter("f_specimen_code", specimenCode);  
		query.setParameter("f_jusa", jusa);  
		query.setParameter("f_pay", pay);  
		query.setParameter("f_order_gubun_bas", orderGubunBas);  
		query.setParameter("f_bogyong_code", bogyongCode);  
		query.setParameter("f_jusa_spd_gubun", jusaSpdGubun);  
		query.setParameter("f_jundal_part_out", jundaPartOut);  
		query.setParameter("f_jundal_part_inp", judalPartInp);  
		query.setParameter("f_ord_danui", ordDanui);  
		query.setParameter("f_hangmog_code", hangmogCode);  

		List<HILoadCodeNameInfo> list = new JpaResultMapper().list(query, HILoadCodeNameInfo.class);
	    return list;
	}

	@Override
	public List<ComboListItemInfo> getOCS0103U10CboInputGubun(String hospCode,String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE                                                                             ");
		sql.append("      ,case A.CODE_NAME when '通常' then  '定期薬' else A.CODE_NAME end CODE_NAME           ");
		sql.append("   FROM OCS0132 A                                                                          ");
		sql.append("  WHERE A.CODE_TYPE LIKE 'INPUT_GUBUN'                                                     ");
		sql.append("    AND (   A.CODE LIKE 'D%'                                                               ");
		sql.append("         OR A.CODE = 'CK'                                                                  ");
		sql.append("        )                                                                                  ");
		sql.append("    AND A.HOSP_CODE = :f_hosp_code                                                         ");
		sql.append("    AND A.LANGUAGE =:f_language                                                            ");
		sql.append("    AND A.VALUE_POINT = '1'                                                                ");
		sql.append("  ORDER BY A.SORT_KEY, A.CODE																");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
	    return list;
	}

	@Override
	public List<ComboListItemInfo> getOcsLibComboListItemInfo(String hospCode,String language, String codeType) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE CODE, A.CODE CODE_NAME     ");
		sql.append(" FROM OCS0132 A                           ");
		sql.append(" WHERE  A.CODE_TYPE = :f_code_type        ");
		if(codeType.equalsIgnoreCase("DV_TIME")){
			sql.append(" AND A.CODE != '#'                    ");
		}
		sql.append(" AND A.HOSP_CODE   = :f_hosp_code         ");
		sql.append(" AND A.LANGUAGE =:f_language              ");
		sql.append(" ORDER BY A.SORT_KEY, A.CODE              ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
	    return list;

	}
	@Override
	public List<ComboListItemInfo> getOCS0103U10SearchConditionCbo(String hospCode,String language,String codeType)
	{
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE, CODE_NAME           ");
		sql.append(" FROM OCS0132 a                   ");
		sql.append(" where a.HOSP_CODE = :f_hosp_code ");
		sql.append(" AND a.LANGUAGE =:f_language      ");
		sql.append(" AND a.CODE_TYPE = :f_code_type   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		List<ComboListItemInfo> listResult= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	@Override
	public List<ComboListItemInfo> getOCS0103U10SearchConditionCbo(String hospCode, String language,String codeType,boolean isOrderBy) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT '%' CODE                           ");
		sql.append("	, FN_ADM_MSG('221',:f_language) CODE_NAME ");
		sql.append("	UNION                                     ");
		if(isOrderBy){
			sql.append(" (                                       ");
		}
		sql.append(" SELECT CODE, CODE_NAME           ");
		sql.append(" FROM OCS0132 a                   ");
		sql.append(" where a.HOSP_CODE = :f_hosp_code ");
		sql.append(" AND a.LANGUAGE =:f_language      ");
		sql.append(" AND a.CODE_TYPE = :f_code_type   ");
		if(isOrderBy){
			sql.append(" ORDER BY SORT_KEY )");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		List<ComboListItemInfo> listResult= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	
	@Override
	public String callFnOcsBogyongColName(String orderGubunBas,
			String bogyongCode, String jusaSpdGubun, String hospCode,
			String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT FN_OCS_BOGYONG_COL_NAME(:orderGubunBas, :bogyongCode, :jusaSpdGubun, :hospCode, :language)");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("orderGubunBas", orderGubunBas);
		query.setParameter("bogyongCode", bogyongCode);
		query.setParameter("jusaSpdGubun", jusaSpdGubun);
		query.setParameter("hospCode", hospCode);
		query.setParameter("language", language);
		
		List<Object> list = query.getResultList();
		if(list!= null && list.get(0) != null){
			return list.get(0).toString();
		}
		return null;
	}

	@Override
	public List<OCS0103U18MakeJaeryoGubunTabListItemInfo> getOCS0103U18InitializeScreenMakeJaeryoGubunTabListItem(
			String hospCode, String inputTab, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT DISTINCT A.ORDER_GUBUN ORDER_GUBUN                 	");
		sql.append("	    , B.CODE_NAME                     ORDER_GUBUN_NAME      ");
		sql.append("	    , B.SORT_KEY                      SORT_KEY              ");
		sql.append("	 FROM OCS0142 A                                             ");
		sql.append("	    , OCS0132 B                                             ");
		sql.append("	WHERE A.HOSP_CODE   = :hospCode                             ");
		sql.append("	  AND A.INPUT_TAB   = :inputTab                             ");
		sql.append("	  AND A.MAIN_YN     = 'N'                                   ");
		sql.append("	  AND B.LANGUAGE = :language                                ");
		sql.append("	  AND B.HOSP_CODE  = A.HOSP_CODE                            ");
		sql.append("	  AND B.CODE        = A.ORDER_GUBUN                         ");
		sql.append("	  AND B.CODE_TYPE   = 'ORDER_GUBUN_BAS'                     ");
		sql.append("	UNION ALL                                                   ");
		sql.append("	SELECT DISTINCT A.ORDER_GUBUN ORDER_GUBUN                    ");
		sql.append("	    , C.CODE_NAME   ORDER_GUBUN_NAME                        ");
		sql.append("	    , 0             SORT_KEY                                ");
		sql.append("	 FROM OCS0142 A                                             ");
		sql.append("	    , OCS0103 B                                             ");
		sql.append("	    , OCS0132 C                                             ");
		sql.append("	WHERE A.HOSP_CODE   = :hospCode                             ");
		sql.append("	  AND A.INPUT_TAB   = :inputTab                             ");
		sql.append("	  AND A.MAIN_YN     = 'Y'                                   ");
		sql.append("	  AND C.LANGUAGE = :language                                ");
		sql.append("	  AND B.HOSP_CODE   = A.HOSP_CODE                           ");
		sql.append("	  AND B.ORDER_GUBUN = A.ORDER_GUBUN                         ");
		sql.append("	  AND B.IF_INPUT_CONTROL != 'P'                             ");
		sql.append("	  AND C.HOSP_CODE   = B.HOSP_CODE                           ");
		sql.append("	  AND C.CODE        = B.ORDER_GUBUN                         ");
		sql.append("	  AND C.CODE_TYPE   = 'ORDER_GUBUN_BAS'                     ");
		sql.append("	ORDER BY SORT_KEY                                          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("inputTab", inputTab);
		query.setParameter("language", language);

		List<OCS0103U18MakeJaeryoGubunTabListItemInfo> list = new JpaResultMapper().list(query, OCS0103U18MakeJaeryoGubunTabListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getOCS0803U00CreateCombo(String hospCode,String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE , CODE_NAME                ");
		sql.append(" FROM OCS0132                           ");
		sql.append("  WHERE HOSP_CODE = :f_hosp_code        ");
		sql.append("  AND LANGUAGE =:f_language             ");
		sql.append("  AND CODE_TYPE = 'INDISPENSABLE_YN'    ");
		sql.append("  AND CODE <> 'Z'                       ");
		sql.append(" ORDER BY CODE							");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getComboOrdDanui(String hospCode,String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE,A.CODE_NAME FROM OCS0132 A WHERE A.HOSP_CODE = :f_hosp_code      ");
		sql.append(" AND A.LANGUAGE =:f_language AND A.CODE_TYPE = 'ORD_DANUI' ORDER BY A.CODE      ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getComboDataSourceInfoCaseDvTime(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE CODE, A.CODE CODE_NAME               ");
		sql.append("    FROM OCS0132 A                                  ");
		sql.append("   WHERE A.CODE_TYPE = 'DV_TIME' AND A.CODE != '#'  ");
		sql.append("  AND A.HOSP_CODE   = :f_hosp_code                  ");
		sql.append("  AND A.LANGUAGE =:f_language                       ");
		sql.append("  ORDER BY A.SORT_KEY, A.CODE 						");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getComboJusaSpdGubun(String hospCode,String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE, A.CODE_NAME             ");
		sql.append("     FROM OCS0132 A                     ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code    ");
		sql.append("    AND A.LANGUAGE =:f_language         ");
		sql.append("    AND A.CODE_TYPE = 'JUSA_SPD_GUBUN'  ");
		sql.append(" ORDER BY A.CODE						");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	
	
	
	
	@Override
	public List<OCS0103Q00CreateOrderGubunInfo> getOCS0103Q00CreateOrderGubun(String hospCode, String inputTab){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DISTINCT A.CODE, A.CODE_NAME, A.SORT_KEY  ");
		sql.append("           FROM OCS0132 A                        ");
		sql.append("              , OCS0142 B                        ");
		sql.append("          WHERE A.CODE_TYPE = 'ORDER_GUBUN_BAS'  ");
		sql.append("            AND A.HOSP_CODE = :f_hosp_code       ");
		sql.append("            AND A.CODE      = B.ORDER_GUBUN      ");
		sql.append("            AND B.INPUT_TAB LIKE :f_input_tab    ");
		sql.append("          ORDER BY A.SORT_KEY                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_input_tab", inputTab);
		
		List<OCS0103Q00CreateOrderGubunInfo> list = new JpaResultMapper().list(query, OCS0103Q00CreateOrderGubunInfo.class);
		return list;
	}

	@Override
	public List<Ocs0131U01Grd0132ListItemInfo> getOcs0131U01Grd0132ListItemInfo(
			String codeType, String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE               CODE,							");
		sql.append("	       A.CODE_NAME          CODE_NAME,                      ");
		sql.append("	       IFNULL(A.SORT_KEY,0)    SORT_KEY,                    ");
		sql.append("	       A.GROUP_KEY          GROUP_KEY,                      ");
		sql.append("	       A.MENT               MENT,                           ");
		sql.append("	       IFNULL(A.VALUE_POINT,0) VALUE_POINT,                 ");
		sql.append("	       A.UPD_ID             USER_ID,                        ");
		sql.append("	       A.CODE_TYPE          CODE_TYPE                       ");
		sql.append("	  FROM OCS0132 A                                            ");
		sql.append("	 WHERE A.CODE_TYPE = TRIM(:f_code_type)                     ");
		sql.append("	   AND A.HOSP_CODE = :f_hosp_code                           ");
		sql.append("   AND A.LANGUAGE = :language        							");
		sql.append("	 ORDER BY A.CODE_TYPE, LPAD(A.SORT_KEY,12,'0'), A.CODE      ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_code_type", codeType);
		
		List<Ocs0131U01Grd0132ListItemInfo> list = new JpaResultMapper().list(query, Ocs0131U01Grd0132ListItemInfo.class);
		return list;
		
	}
	
	public List<ComboListItemInfo> getCodeCodeNameListItemInfo(String hospCode, String find1, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT CODE								   ");
		sql.append("	, CODE_NAME                                ");
		sql.append("	FROM OCS0132                               ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code             ");
		sql.append("	AND CODE_TYPE = 'ORD_DANUI'                ");
		sql.append("   AND LANGUAGE = :language        			   ");
		sql.append("	AND(CODE LIKE :f_find1                     ");
		sql.append("	OR CODE_NAME LIKE :f_find1 )               ");
		sql.append("	ORDER BY CODE                              ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_find1", find1+"%");
		query.setParameter("language", language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public List<String> getGroupKeyFromVwOcsDummyOrderMaster(String code) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT GROUP_KEY FROM VW_OCS_DUMMY_ORDER_MASTER WHERE CODE = :f_hangmog_code ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hangmog_code", code);
		List<String> list = query.getResultList();
		return list;
	}
	
	public List<ComboListItemInfo> getCodeCodeNameWhereNURItemInfo (String hospCode,String language, String codeType, String groupKey,boolean isAll){
		StringBuilder sql = new StringBuilder();
		if(isAll){
			sql.append("	SELECT '%' CODE                           ");
			sql.append("	, FN_ADM_MSG('221',:f_language) CODE_NAME ");
			sql.append("	UNION                                     ");
		}
		sql.append("	(SELECT CODE                               ");
		sql.append("	, CODE_NAME                               ");
		sql.append("	FROM OCS0132                              ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code             ");
		sql.append("	AND LANGUAGE = :f_language                ");
		sql.append("	AND CODE_TYPE = :f_code_type              ");
		sql.append("	AND GROUP_KEY = :f_group_key               ");
		if(isAll){
			sql.append("	ORDER BY SORT_KEY)                         ");
		}else{ 
			sql.append("	)                                    ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_group_key", groupKey);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public List<XRT0201U00GrdPaListItemInfo> getXRT0201U00GrdPaListItem(
			String hospCode, String language, String ioGubun, String actGubun,
			String jundalTableCode, String jundalPart, String bunho,
			Date fromDate, Date toDate) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 																																");
		sql.append("	      DISTINCT                                                                                                                      ");
		sql.append("	       'O'  IN_OUT_GUBUN                                                                                                            ");
		sql.append("	       , A.ORDER_DATE                                                               ORDER_DATE                                      ");
		sql.append("	     , FN_OCS_LOAD_MIN_TIME('O', A.FKOUT1001, A.ORDER_DATE, A.JUNDAL_TABLE, :f_hosp_code)         ORDER_TIME                        ");
		sql.append("	     , A.BUNHO                                                                      BUNHO                                           ");
		sql.append("	     , B.SUNAME                                                                                                                     ");
		sql.append("	     , B.SUNAME2                                                                                                                    ");
		sql.append("	     , A.GWA                                                                                                                        ");
		sql.append("	     , FN_BAS_LOAD_GWA_NAME(A.GWA, A.SYS_DATE, :f_hosp_code, :language)                                                             ");
		sql.append("	     , A.DOCTOR                                                                                                                     ");
		sql.append("	     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE,:f_hosp_code)                                                                   ");
		sql.append("	     , IF(A.RESER_DATE IS NULL,'N','Y') RESER_YN                                                                                    ");
		sql.append("	     , A.EMERGENCY             EMERGENCY                                                                                            ");
		sql.append("	     , A.FKOUT1001 NAEWON_KEY                                                                                                       ");
		sql.append("	     , C.MENT JUNDAL_TABLE                                                                                                          ");
		sql.append("	     , IF( E.NUM_PROTOCOL IS NULL , 'N' , 'Y' )                                TRIAL_PATIENT                            	        ");
		sql.append("	  FROM OCS0132 C                                                                                                                    ");
		sql.append("	     , OUT0101 B                                                                                                                    ");
		sql.append("	     , OCS1003 A                                                                                                                    ");
		sql.append("	      LEFT JOIN (SELECT	A.CLIS_PROTOCOL_ID	 AS	NUM_PROTOCOL	, A.HOSP_CODE HOSP_CODE, A.BUNHO BUNHO                              ");
		sql.append("	      FROM	CLIS_PROTOCOL_PATIENT A	 LEFT JOIN CLIS_PROTOCOL B ON A.CLIS_PROTOCOL_ID = B.CLIS_PROTOCOL_ID	                        ");
		sql.append("	      WHERE	A.HOSP_CODE = :f_hosp_code	                                                                                            ");
		sql.append("	      AND	A.BUNHO LIKE :f_bunho	                                                                                                ");
		sql.append("	      AND	A.ACTIVE_FLG = 1	                                                                                                    ");
		sql.append("	      AND	B.ACTIVE_FLG = 1	                                                                                                    ");
		sql.append("	      AND	B.STATUS_FLG <> 1	                                                                                                    ");
		sql.append("	      AND	B.END_DATE >= SYSDATE()	) E ON A.HOSP_CODE = E.HOSP_CODE AND A.BUNHO = E.BUNHO                                          ");
		sql.append("	 WHERE :f_io_gubun IN ('1','2','4')                                                                                                 ");
		sql.append("	   AND ( ( :f_act_gubun = '1' )                                                                                                     ");
		sql.append("	      OR ( :f_act_gubun = '2' AND A.JUBSU_DATE IS NULL AND A.ACTING_DATE IS NULL AND A.RESULT_DATE IS NULL)                         ");
		sql.append("	      OR ( :f_act_gubun = '3' AND A.JUBSU_DATE IS NOT NULL AND A.ACTING_DATE IS NULL AND A.RESULT_DATE IS NULL )                    ");
		sql.append("	      OR ( :f_act_gubun = '4' AND A.JUBSU_DATE IS NOT NULL AND A.ACTING_DATE IS NOT NULL AND A.RESULT_DATE IS NOT NULL) )           ");
		sql.append("	   AND C.CODE_TYPE      = 'OCS_ACT_SYSTEM'                                                                                          ");
		sql.append("	   AND C.HOSP_CODE      = :f_hosp_code                                                                                              ");
		sql.append("	   AND C.CODE           = :f_jundal_table_code                                                                                      ");
		sql.append("	   AND C.LANGUAGE       = :language                                                                                                 ");
		sql.append("	   AND A.JUNDAL_TABLE   = C.MENT                                                                                                    ");
		sql.append("	   AND A.JUNDAL_PART    LIKE :f_jundal_part                                                                                         ");
		sql.append("	   AND A.BUNHO          LIKE :f_bunho                                                                                               ");
		sql.append("	   AND IFNULL(A.RESER_DATE, A.ORDER_DATE) BETWEEN :f_from_date AND :f_to_date                                                       ");
		sql.append("	   AND A.HOSP_CODE      = C.HOSP_CODE                                                                                               ");
		sql.append("	   AND B.BUNHO          = A.BUNHO                                                                                                   ");
		sql.append("	   AND B.HOSP_CODE      = A.HOSP_CODE                                                                                               ");
		sql.append("	   AND EXISTS (SELECT 'X'                                                                                                           ");
		sql.append("	                 FROM OUT1001 X                                                                                                     ");
		sql.append("	                WHERE X.HOSP_CODE   = A.HOSP_CODE                                                                                   ");
		sql.append("	                  AND X.NAEWON_DATE = IFNULL(A.RESER_DATE, A.ORDER_DATE)                                                            ");
		sql.append("	                  AND IFNULL(X.NAEWON_YN, 'N') != 'N'                                                                               ");
		sql.append("	                  AND X.BUNHO       = A.BUNHO                                                                                       ");
		sql.append("	                              AND X.GWA        != '03')                                                                             ");
		sql.append("	   AND A.DC_YN = 'N'                                                                                                                ");
		sql.append("	   AND A.NALSU > 0                                                                                                                  ");
		sql.append("	 UNION                                                                                                                              ");
		sql.append("	SELECT DISTINCT                                                                                                                     ");
		sql.append("	       'I'  IN_OUT_GUBUN                                                                                                            ");
		sql.append("	       , A.ORDER_DATE                                                                ORDER_DATE                                     ");
		sql.append("	     ,''                                                                             ORDER_TIME                                     ");
		sql.append("	     , A.BUNHO                                                                       BUNHO                                          ");
		sql.append("	     , C.SUNAME                                                                                                                     ");
		sql.append("	     , C.SUNAME2                                                                                                                    ");
		sql.append("	     , B.GWA                                                                                                                        ");
		sql.append("	     , FN_BAS_LOAD_GWA_NAME(B.GWA, A.SYS_DATE,:f_hosp_code ,:language)                                                              ");
		sql.append("	     , A.DOCTOR                                                                                                                     ");
		sql.append("	     , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE,:f_hosp_code)                                                                   ");
		sql.append("	       , IF(A.RESER_DATE IS NULL,'N','Y') RESER_YN                                                                                  ");
		sql.append("	     , A.EMERGENCY             EMERGENCY                                                                                            ");
		sql.append("	     , NULL NAEWON_KEY                                                                                                              ");
		sql.append("	     , D.MENT JUNDAL_TABLE                                                                                                          ");
		sql.append("	     , IF( E.NUM_PROTOCOL IS NULL , 'N' , 'Y' )                                TRIAL_PATIENT      						            ");
		sql.append("	  FROM OCS0132 D                                                                                                                    ");
		sql.append("	     , OUT0101 C                                                                                                                    ");
		sql.append("	     , INP1001 B                                                                                                                    ");
		sql.append("	     , OCS2003 A                                                                                                                    ");
		sql.append("	     LEFT JOIN (SELECT	A.CLIS_PROTOCOL_ID  AS	NUM_PROTOCOL	, A.HOSP_CODE HOSP_CODE, A.BUNHO BUNHO                      		");
		sql.append("	      FROM	CLIS_PROTOCOL_PATIENT A	 LEFT JOIN CLIS_PROTOCOL B ON A.CLIS_PROTOCOL_ID = B.CLIS_PROTOCOL_ID	                        ");
		sql.append("	      WHERE	A.HOSP_CODE = :f_hosp_code	                                                                                            ");
		sql.append("	      AND	A.BUNHO LIKE :f_bunho	                                                                                                ");
		sql.append("	      AND	A.ACTIVE_FLG = 1	                                                                                                    ");
		sql.append("	      AND	B.ACTIVE_FLG = 1	                                                                                                    ");
		sql.append("	      AND	B.STATUS_FLG <> 1	                                                                                                    ");
		sql.append("	      AND	B.END_DATE >= SYSDATE()	) E ON A.HOSP_CODE = E.HOSP_CODE AND A.BUNHO = E.BUNHO                                          ");
		sql.append("	 WHERE :f_io_gubun      IN ('1','3')                                                                                                ");
		sql.append("	   AND ( ( :f_act_gubun = '1' )                                                                                                     ");
		sql.append("	      OR ( :f_act_gubun = '2' AND A.JUBSU_DATE IS NULL AND A.ACTING_DATE IS NULL AND A.RESULT_DATE IS NULL)                         ");
		sql.append("	      OR ( :f_act_gubun = '3' AND A.JUBSU_DATE IS NOT NULL AND A.ACTING_DATE IS NULL AND A.RESULT_DATE IS NULL )                    ");
		sql.append("	      OR ( :f_act_gubun = '4' AND A.JUBSU_DATE IS NOT NULL AND A.ACTING_DATE IS NOT NULL AND A.RESULT_DATE IS NOT NULL) )           ");
		sql.append("	   AND D.CODE_TYPE      = 'OCS_ACT_SYSTEM'                                                                                          ");
		sql.append("	   AND D.HOSP_CODE      = :f_hosp_code                                                                                              ");
		sql.append("	   AND D.CODE           = :f_jundal_table_code                                                                                      ");
		sql.append("	   AND D.LANGUAGE       = :language                                                                                                 ");
		sql.append("	   AND A.JUNDAL_TABLE   = D.MENT                                                                                                    ");
		sql.append("	   AND A.JUNDAL_PART    LIKE :f_jundal_part                                                                                         ");
		sql.append("	   AND A.BUNHO          LIKE :f_bunho                                                                                               ");
		sql.append("	   AND IFNULL(A.RESER_DATE, A.ORDER_DATE) BETWEEN :f_from_date AND :f_to_date                                                       ");
		sql.append("	   AND A.HOSP_CODE      = D.HOSP_CODE                                                                                               ");
		sql.append("	   AND B.PKINP1001      = A.FKINP1001                                                                                               ");
		sql.append("	   AND B.HOSP_CODE      = A.HOSP_CODE                                                                                               ");
		sql.append("	   AND C.BUNHO          = A.BUNHO                                                                                                   ");
		sql.append("	   AND C.HOSP_CODE      = A.HOSP_CODE                                                                                               ");
		sql.append("	   AND A.DC_YN = 'N'                                                                                                                ");
		sql.append("	   AND A.NALSU > 0                                                                                                                  ");
		sql.append("	 ORDER BY IN_OUT_GUBUN DESC, ORDER_DATE , ORDER_TIME , BUNHO  ;                                                                     ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_act_gubun", actGubun);
		query.setParameter("f_jundal_table_code", jundalTableCode);
		query.setParameter("f_jundal_part", jundalPart);
		query.setParameter("f_bunho", "%"+bunho);
		query.setParameter("f_from_date", fromDate);
		query.setParameter("f_to_date", toDate);
		
		List<XRT0201U00GrdPaListItemInfo> listResult = new JpaResultMapper().list(query, XRT0201U00GrdPaListItemInfo.class);
		return listResult;
	}
	
	@Override
	public List<LoadOcs0132Info> getLoadOcs0132Info(String hospCode,String language, String codeType, String code){
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT A.CODE_TYPE, A.CODE, A.CODE_NAME,  ");
		sql.append("        IFNULL(A.VALUE_POINT,0),           ");
		sql.append("        A.SORT_KEY, A.GROUP_KEY, A.MENT,   ");
		sql.append("        A.SYS_DATE, A.UPD_ID, A.UPD_DATE   ");
		sql.append("   FROM OCS0132 A                          ");
		sql.append("  WHERE A.CODE_TYPE = :f_code_type         ");
		sql.append("    AND A.CODE      = :f_code              ");
		sql.append("    AND A.HOSP_CODE = :f_hosp_code         ");
		sql.append("    AND A.LANGUAGE  = :f_language          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);
		
		List<LoadOcs0132Info> listResult = new JpaResultMapper().list(query, LoadOcs0132Info.class);
		return listResult;
	}

	@Override
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, String language, String codeType,boolean isConcat) {
		StringBuilder sql = new StringBuilder();
		if(isConcat){
			sql.append(" SELECT '%' CODE, FN_ADM_MSG('221',:f_language) CODE_NAME  UNION  				");       
			sql.append(" SELECT CODE, CONCAT('[', CODE , ']' , CODE_NAME)    FROM OCS0132 				");
		}else{
			sql.append(" SELECT CODE CODE, CODE CODE_NAME  FROM OCS0132                   				");
		}
		sql.append(" WHERE HOSP_CODE = :f_hosp_code                                     			 	");
		sql.append(" AND LANGUAGE  = :f_language                                         				");
		sql.append(" AND CODE_TYPE = :f_code_type ORDER BY 1                             				");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public List<PHY0001U00GrdOCS0132Info> getPHY0001U00GrdOCS0132Info(String hospCode, String language, String codeType){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE,                      ");
		sql.append("        A.CODE_NAME,                 ");
		sql.append("        A.CODE_TYPE,                 ");
		sql.append("        A.MENT                       ");
		sql.append("   FROM OCS0132 A                    ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code   ");
		sql.append("    AND A.CODE_TYPE = :f_code_type   ");
		sql.append("    AND A.LANGUAGE = :f_language     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		List<PHY0001U00GrdOCS0132Info> listResult = new JpaResultMapper().list(query, PHY0001U00GrdOCS0132Info.class);
		return listResult;
	}
	
	@Override
	public List<PHY0001U00GrdRehaSinryouryouCodeInfo> getPHY0001U00GrdRehaSinryouryouCodeInfo(String hospCode, String language, String codeType){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.CODE         CODE             ");
		sql.append("     , A.CODE_NAME    HANGMOG_CODE     ");
		sql.append("     , B.HANGMOG_NAME HANGMOG_NAME     ");
		sql.append("  FROM OCS0132 A                       ");
		sql.append("     , OCS0103 B                       ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code   ");
		sql.append("   AND A.LANGUAGE     = :f_language    ");
		sql.append("   AND A.CODE_TYPE    = :f_code_type   ");
		sql.append("   AND B.HOSP_CODE    = A.HOSP_CODE    ");
		sql.append("   AND B.HANGMOG_CODE = A.CODE_NAME    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		List<PHY0001U00GrdRehaSinryouryouCodeInfo> listResult = new JpaResultMapper().list(query, PHY0001U00GrdRehaSinryouryouCodeInfo.class);
		return listResult;
	}
	

	@Override
	public List<ComboListItemInfo> getPhy8002U01GrdOTListItemInfo(
			String hospCode, String codeType, String groupKey, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE,							");
		sql.append("	       A.CODE_NAME                      ");
		sql.append("	  FROM OCS0132 A                        ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code       ");
		sql.append("  	   AND A.LANGUAGE     = :f_language    ");
		sql.append("	   AND A.CODE_TYPE = :f_code_type       ");
		sql.append("	   AND A.GROUP_KEY = :f_group_key       ");
		sql.append("	 ORDER BY A.SORT_KEY                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_group_key", groupKey);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
	
	public List<OCS0221Q01DloOCS0221Info> getOCS0221Q01DloOCS0221Info (String hospCode, String categoryGubun, String memb, String language){
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT :f_memb      MEMB          ,											");
		sql.append("	       A.SORT_KEY   SEQ           ,                                         ");
		sql.append("	       A.CODE       CATEGORY_GUBUN,                                         ");
		sql.append("	       A.CODE_NAME  CATEGORY_NAME ,                                         ");
		sql.append("	       0            COMMENT_LIMIT                                           ");
		sql.append("	  FROM OCS0132 A                                                            ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                                           ");
		sql.append("	   AND A.CODE_TYPE = 'CATEGORY_GUBUN'                                       ");
		sql.append("	   AND A.LANGUAGE = :f_language		                                       ");
		sql.append("	   AND A.CODE      LIKE :f_category_gubun                                   ");
		sql.append("	   AND A.CODE      <> '99'                                                  ");
		sql.append("	   AND NOT EXISTS ( SELECT 'X'                                              ");
		sql.append("	                      FROM OCS0221 B                                        ");
		sql.append("	                     WHERE B.HOSP_CODE      = A.HOSP_CODE                   ");
		sql.append("	                       and B.MEMB           = :f_memb                       ");
		sql.append("	                       AND B.CATEGORY_GUBUN = A.CODE )                      ");
		sql.append("	UNION ALL                                                                   ");
		sql.append("	SELECT A.MEMB            ,                                                  ");
		sql.append("	       A.SEQ             ,                                                  ");
		sql.append("	       A.CATEGORY_GUBUN  ,                                                  ");
		sql.append("	       A.CATEGORY_NAME   ,                                                  ");
		sql.append("	       A.COMMENT_LIMIT                                                      ");
		sql.append("	  FROM OCS0221 A                                                            ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                                           ");
		sql.append("	   AND A.MEMB      = :f_memb                                                ");
		sql.append("	   AND (A.CATEGORY_GUBUN LIKE :f_category_gubun OR A.CATEGORY_GUBUN = '99') ");
		sql.append("	 ORDER BY 2																	");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_category_gubun", categoryGubun);
		query.setParameter("f_memb", memb);
		
		List<OCS0221Q01DloOCS0221Info> listResult = new JpaResultMapper().list(query, OCS0221Q01DloOCS0221Info.class);
		return listResult;
	}

	@Override
	public List<Ocs3003Q10GrdOrderListItemInfo> getOcs3003Q10GrdOrderListItem(
			String hospCode, String language, Date naewonDate, String ioGubun,
			String orderGubun, String bunho, Double pkocskey, String jubsuNo,
			 String gwa, String doctor) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT 																																														      ");
		sql.append("	       CAST(' ' AS CHAR)                                          INPUT_GUBUN_NAME        ,                                                                                           ");
		sql.append("	       A.GROUP_SER                                                GROUP_SER               ,                                                                                           ");
		sql.append("	       IFNULL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,                                                                                        ");
		sql.append("	       A.HANGMOG_CODE                                             HANGMOG_CODE            ,                                                                                           ");
		sql.append("	       ( CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')                                                                                                                              ");
		sql.append("	              THEN CONCAT(IFNULL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE, :f_hosp_code), ''),B.HANGMOG_NAME)                                                                                  ");
		sql.append("	              ELSE B.HANGMOG_NAME  END )                          HANGMOG_NAME            ,                                                                                           ");
		sql.append("	       A.SURYANG                                                  SURYANG                 ,                                                                                           ");
		sql.append("	       A.ORD_DANUI                                                ORD_DANUI               ,                                                                                           ");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, :f_hosp_code, :language)            ORD_DANUI_NAME          ,                                                                  ");
		sql.append("	       A.DV_TIME                                                  DV_TIME                 ,                                                                                           ");
		sql.append("	       A.DV                                                       DV                      ,                                                                                           ");
		sql.append("	       A.NALSU                                                    NALSU                   ,                                                                                           ");
		sql.append("	       A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,                                                                                           ");
		sql.append("	       IFNULL(A.EMERGENCY , 'N')                                  EMERGENCY               ,                                                                                           ");
		sql.append("	       A.PAY                                                      PAY                     ,                                                                                           ");
		sql.append("	       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,                                                                                           ");
		sql.append("	       A.MUHYO                                                    MUHYO                   ,                                                                                           ");
		sql.append("	       A.PORTABLE_YN                                              PORTABLE_YN             ,                                                                                           ");
		sql.append("	       A.OCS_FLAG                                                 OCS_FLAG                ,                                                                                           ");
		sql.append("	       A.ORDER_GUBUN                                              ORDER_GUBUN             ,                                                                                           ");
		sql.append("	       A.INPUT_TAB                                                INPUT_TAB               ,                                                                                           ");
		sql.append("	       A.INPUT_GUBUN                                              INPUT_GUBUN             ,                                                                                           ");
		sql.append("	       A.AFTER_ACT_YN                                             AFTER_ACT_YN            ,                                                                                           ");
		sql.append("	       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,                                                                                           ");
		sql.append("	       A.JUNDAL_PART                                              JUNDAL_PART             ,                                                                                           ");
		sql.append("	       A.MOVE_PART                                                MOVE_PART               ,                                                                                           ");
		sql.append("	       A.BUNHO                                                    BUNHO                   ,                                                                                           ");
		sql.append("	       A.ORDER_DATE                                               NAEWON_DATE             ,                                                                                           ");
		sql.append("	       A.GWA                                                      GWA                     ,                                                                                           ");
		sql.append("	       A.DOCTOR                                                   DOCTOR                  ,                                                                                           ");
		sql.append("	       A.NAEWON_TYPE                                              NAEWON_TYPE             ,                                                                                           ");
		sql.append("	       A.FKOUT1001                                                PK_ORDER                ,                                                                                           ");
		sql.append("	       A.SEQ                                                      SEQ                     ,                                                                                           ");
		sql.append("	       A.PKOCS1003                                                PKOCS1003               ,                                                                                           ");
		sql.append("	       A.SUB_SUSUL                                                SUB_SUSUL               ,                                                                                           ");
		sql.append("	       A.SUTAK_YN                                                 SUTAK_YN                ,                                                                                           ");
		sql.append("	       A.AMT                                                      AMT                     ,                                                                                           ");
		sql.append("	       A.DV_1                                                     DV_1                    ,                                                                                           ");
		sql.append("	       A.DV_2                                                     DV_2                    ,                                                                                           ");
		sql.append("	       A.DV_3                                                     DV_3                    ,                                                                                           ");
		sql.append("	       A.DV_4                                                     DV_4                    ,                                                                                           ");
		sql.append("	       A.ORDER_REMARK                                             ORDER_REMARK            ,                                                                                           ");
		sql.append("	       A.MIX_GROUP                                                MIX_GROUP               ,                                                                                           ");
		sql.append("	       A.JUBSU_DATE                                               JUBSU_DATE              ,                                                                                           ");
		sql.append("	       A.ACTING_DATE                                              ACTING_DATE             ,                                                                                           ");
		sql.append("	       A.RESULT_DATE                                              RESULT_DATE             ,                                                                                           ");
		sql.append("	       A.DC_GUBUN                                                 DC_GUBUN                ,                                                                                           ");
		sql.append("	       A.DC_YN                                                    DC_YN                   ,                                                                                           ");
		sql.append("	       A.BANNAB_YN                                                BANNAB_YN               ,                                                                                           ");
		sql.append("	       IF( B.ORDER_GUBUN = 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, :f_hosp_code), 'N' )                                                                                            ");
		sql.append("	                                                                  DONBOK_YN               ,                                                                                           ");
		sql.append("	       FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4, A.DV_5, A.DV_6, A.DV_7, A.DV_8)  DV_NAME                 ,                                                           ");
		sql.append("	       IF(A.NURSE_CONFIRM_DATE IS NULL, 'N','Y')                CONFIRM_CHECK           ,                                                                                             ");
		sql.append("	       IF(A.SUNAB_DATE IS NULL, 'N','Y')                        SUNAB_CHECK             ,                                                                                             ");
		sql.append("	       CASE SIGN(A.NALSU) WHEN 1 THEN 'N'                                                                                                                                             ");
		sql.append("	        WHEN 0 THEN 'N' ELSE 'Y' END                              DC_CHECK                ,                                                                                           ");
		sql.append("	       B.SLIP_CODE                                                SLIP_CODE               ,                                                                                           ");
		sql.append("	       B.GROUP_YN                                                 GROUP_YN                ,                                                                                           ");
		sql.append("	       B.SG_CODE                                                  SG_CODE                 ,                                                                                           ");
		sql.append("	       B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,                                                                                           ");
		sql.append("	       B.INPUT_CONTROL                                            INPUT_CONTROL           ,                                                                                           ");
		sql.append("	       IFNULL(B.SUGA_YN,'N')                                         SUGA_YN                 ,                                                                                        ");
		sql.append("	       CASE IFNULL(B.EMERGENCY,'Z') WHEN 'Y' THEN 'N'                                                                                                                                 ");
		sql.append("	        WHEN 'N' THEN 'N' ELSE 'Y' END                            EMERGENCY_CHECK         ,                                                                                           ");
		sql.append("	       B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,                                                                                           ");
		sql.append("	       IFNULL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,                                                                                        ");
		sql.append("	       IFNULL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,                                                                                        ");
		sql.append("	       IF(B.ORD_DANUI IS NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,                                                                                             ");
		sql.append("	       B.ORD_DANUI                                                ORD_DANUI_BAS           ,                                                                                           ");
		sql.append("	       B.JUNDAL_TABLE_OUT                                         JUNDAL_TABLE_OUT        ,                                                                                           ");
		sql.append("	       B.JUNDAL_PART_OUT                                          JUNDAL_PART_OUT         ,                                                                                           ");
		sql.append("	       IFNULL(DATE_FORMAT(Z.BULYONG_YMD, '%Y/%m/%d'), '9998/12/31')          BULYONG_CHECK           ,                                                                           	 ");
		sql.append("	       FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE, :f_hosp_code)         WONYOI_ORDER_CR_YN      ,                                                                                       ");
		sql.append("	       B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,                                                                                           ");
		sql.append("	       IFNULL(B.NDAY_YN,'N')                                         NDAY_YN                 ,                                                                                        ");
		sql.append("	       IFNULL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,                                                                                        ");
		sql.append("	       IFNULL(A.TEL_YN, 'N')                                         TEL_YN                  ,                                                                                        ");
		sql.append("	       FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.ORDER_DATE, :f_hosp_code, :language)          JUNDAL_PART_NAME        ,                                                                  ");
		sql.append("	       E.BUN_CODE                                                 BUN_CODE                ,                                                                                           ");
		sql.append("	       FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE, :f_hosp_code)             DRG_INFO                ,                                                                                        ");
		sql.append("	       CAST(' ' AS CHAR)                                                          DRG_BUNRYU              ,                                                                           ");
		sql.append("	       IF(A.BOM_SOURCE_KEY IS NULL,FN_OCS_LOAD_CHILD_GUBUN(:f_hosp_code,'O',A.PKOCS1003),'3')      CHILD_GUBUN,                                                                       ");
		sql.append("	       A.BOM_SOURCE_KEY                                           BOM_SOURCE_KEY,                                                                                                     ");
		sql.append("	       A.BOM_OCCUR_YN                                             BOM_OCCUR_YN,                                                                                                       ");
		sql.append("	       A.ACTING_TIME                                                  ACTING_TIME,                                                                                                    ");
		sql.append("	       CONCAT(LPAD(A.GROUP_SER, 10,'0')                                                                                                                                               ");
		sql.append("	       ,CASE WHEN A.SOURCE_FKOCS1003 IS NOT NULL THEN A.SOURCE_FKOCS1003                                                                                                              ");
		sql.append("	                    WHEN A.BOM_SOURCE_KEY IS NULL THEN A.PKOCS1003                                                                                                                    ");
		sql.append("	                    ELSE A.BOM_SOURCE_KEY END , A.PKOCS1003)           CONT_KEY                                                                                                       ");
		sql.append("	FROM  OCS0103 B																		                                                                                               	");
		sql.append("	      LEFT JOIN  ( SELECT A.SG_CODE                                                                                                                                                   ");                                                                                                      
		sql.append("		                , A.SG_NAME                                                                                                                                                       ");                                                                                                  
		sql.append("		                , A.BUN_CODE                                                                                                                                                      ");                                                                                                  
		sql.append("		                , A.HOSP_CODE                                                                                                                                                     ");                                                                                                  
		sql.append("		             FROM BAS0310 A                                                                                                                                                       ");                                                                                                  
		sql.append("		            WHERE A.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                                                                                               ");                                                                                                  
		sql.append("		                                 FROM BAS0310 Z                                                                                                                                   ");                                                                                                  
		sql.append("		                                WHERE Z.SG_CODE = A.SG_CODE                                                                                                                       ");                                                                                                  
		sql.append("		                                  AND Z.SG_YMD <= :f_naewon_date )                                                                                                                ");                                                                                                  
		sql.append("		         ) E  ON E.HOSP_CODE = B.HOSP_CODE  AND E.SG_CODE = B.SG_CODE                                                                                                             ");                                                                             
		sql.append("	       LEFT JOIN( SELECT X.SG_CODE                                                                                                                                                     ");
		sql.append("	                  , X.HOSP_CODE                                                                                                                                                       ");
		sql.append("	                  , X.BULYONG_YMD                                                                                                                                                     ");
		sql.append("	      			  FROM BAS0310 X                                                                                                                                                      ");
		sql.append("	      			  WHERE X.SG_YMD =(SELECT MAX(Y.SG_YMD)                                                                                                                                   ");
		sql.append("	                  FROM BAS0310 Y                                                                                                                                                       ");
		sql.append("	                  WHERE Y.SG_CODE = X.SG_CODE                                                                                                                                          ");
		sql.append("	                  AND Y.SG_YMD <= SYSDATE())) Z ON Z.HOSP_CODE = B.HOSP_CODE AND Z.SG_CODE = B.SG_CODE                                                                                 ");
		sql.append("	                  AND B.START_DATE =                                                                                                                                                   ");
		sql.append("	                   (SELECT MAX(Z.START_DATE)  FROM OCS0103 Z WHERE Z.HANGMOG_CODE = B.HANGMOG_CODE AND Z.START_DATE <= SYSDATE() ),                                                     ");
		sql.append("	       OCS0132 C RIGHT JOIN OCS1003 A ON C.HOSP_CODE = A.HOSP_CODE  AND C.CODE = SUBSTR(A.ORDER_GUBUN, 2, 1)  AND C.CODE_TYPE = 'ORDER_GUBUN_BAS'  AND C.LANGUAGE = :language         ");
		sql.append("	       LEFT JOIN OCS0116 D  ON D.HOSP_CODE = A.HOSP_CODE AND  D.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                       ");
		sql.append("	 WHERE A.HOSP_CODE        = :f_hosp_code																																			  ");	
		sql.append("		   AND :f_io_gubun = 'O'                                                                                                                                                          ");
		sql.append("	   AND (                                                                                                                                                                              ");
		sql.append("	         ( :f_order_gubun = '4'                                                                                                                                                       ");
		sql.append("	          AND A.BUNHO = :f_bunho                                                                                                                                                      ");
		sql.append("	           AND A.DC_YN = 'N'                                                                                                                                                          ");
		sql.append("	           AND A.NALSU > 0                                                                                                                                                            ");
		sql.append("	         )                                                                                                                                                                            ");
		sql.append("	       )                                                                                                                                                                              ");
		sql.append("	   AND B.HANGMOG_CODE     = A.HANGMOG_CODE                                                                                                                                            ");
		sql.append("	   AND B.HOSP_CODE        = A.HOSP_CODE                                                                                                                                               ");
		sql.append("	   AND A.ACTING_DATE BETWEEN B.START_DATE AND B.END_DATE                                                                                                                              ");
		sql.append("	  AND A.SORT_FKOCSKEY = :f_pkocskey                                                                                                                                                   ");
		sql.append("	   ORDER BY 44, 81, 82                                                                                                                                                                   ");
			                                                                                                                                                                                                              
		Query query = entityManager.createNativeQuery(sql.toString());                                                                                                                                                
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_order_gubun", orderGubun);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_pkocskey", pkocskey);
		
		List<Ocs3003Q10GrdOrderListItemInfo> listResult = new JpaResultMapper().list(query, Ocs3003Q10GrdOrderListItemInfo.class);
		return listResult;
	}
		
		
		@Override
	public List<Ocs3003Q10GrdOrderListItemInfo> getOcs3003Q10GrdOrderListItemUnion(
			String hospCode, String language, Date naewonDate, String ioGubun,
			String orderGubun, String bunho, Double pkocskey, String jubsuNo,
			 String gwa, String doctor) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT                                                                                                                                                                                ");
		sql.append("	       F.CODE_NAME                                                INPUT_GUBUN_NAME        ,                                                                                           ");
		sql.append("	       A.GROUP_SER                                                GROUP_SER               ,                                                                                           ");
		sql.append("	       IFNULL(C.CODE_NAME, 'Etc')                                    ORDER_GUBUN_NAME        ,                                                                                        ");
		sql.append("	       A.HANGMOG_CODE                                             HANGMOG_CODE            ,                                                                                           ");
		sql.append("	       CASE WHEN B.ORDER_GUBUN IN ('A', 'B', 'C', 'D')                                                                                                                                ");
		sql.append("	              THEN CONCAT(IFNULL(FN_DRG_SPEC_NAME(B.HANGMOG_CODE, :f_hosp_code), ''),B.HANGMOG_NAME)                                                                                  ");
		sql.append("	              ELSE B.HANGMOG_NAME  END                           HANGMOG_NAME             ,                                                                                           ");
		sql.append("	       A.SURYANG                                                  SURYANG                 ,                                                                                           ");
		sql.append("	       A.ORD_DANUI                                                ORD_DANUI               ,                                                                                           ");
		sql.append("	       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI, :f_hosp_code, :language)              ,                                                                                        ");
		sql.append("	       A.DV_TIME                                                  DV_TIME                 ,                                                                                           ");
		sql.append("	       A.DV                                                       DV                      ,                                                                                           ");
		sql.append("	       A.NALSU                                                    NALSU                   ,                                                                                           ");
		sql.append("	       A.WONYOI_ORDER_YN                                          WONYOI_ORDER_YN         ,                                                                                           ");
		sql.append("	       IFNULL(A.EMERGENCY, 'N')                                   EMERGENCY               ,                                                                                           ");
		sql.append("	       A.PAY                                                      PAY                     ,                                                                                           ");
		sql.append("	       A.ANTI_CANCER_YN                                           ANTI_CANCER_YN          ,                                                                                           ");
		sql.append("	       A.MUHYO                                                    MUHYO                   ,                                                                                           ");
		sql.append("	       A.PORTABLE_YN                                              PORTABLE_YN             ,                                                                                           ");
		sql.append("	       A.OCS_FLAG                                                 OCS_FLAG                ,                                                                                           ");
		sql.append("	       A.ORDER_GUBUN                                              ORDER_GUBUN             ,                                                                                           ");
		sql.append("	       A.INPUT_TAB                                                INPUT_TAB               ,                                                                                           ");
		sql.append("	       A.INPUT_GUBUN                                              INPUT_GUBUN             ,                                                                                           ");
		sql.append("	       'N'                                                        AFTER_ACT_YN            ,                                                                                           ");
		sql.append("	       A.JUNDAL_TABLE                                             JUNDAL_TABLE            ,                                                                                           ");
		sql.append("	       A.JUNDAL_PART                                              JUNDAL_PART             ,                                                                                           ");
		sql.append("	       'NULL'                                                       MOVE_PART               ,                                                                                           ");
		sql.append("	       A.BUNHO                                                    BUNHO                   ,                                                                                           ");
		sql.append("	       A.ORDER_DATE                                               NAEWON_DATE             ,                                                                                           ");
		sql.append("	       A.INPUT_PART                                               GWA                     ,                                                                                           ");
		sql.append("	       A.INPUT_ID                                                 DOCTOR                  ,                                                                                           ");
		sql.append("	       CAST('0' AS CHAR )                                                        NAEWON_TYPE             ,                                                                                           ");
		sql.append("	       A.FKINP1001                                                PK_ORDER                ,                                                                                           ");
		sql.append("	       A.SEQ                                                      SEQ                     ,                                                                                           ");
		sql.append("	       A.PKOCS2003                                                PKOCS1003               ,                                                                                           ");
		sql.append("	       A.SUB_SUSUL                                                SUB_SUSUL               ,                                                                                           ");
		sql.append("	       'NULL'                                                       SUTAK_YN                ,                                                                                           ");
		sql.append("	       A.AMT                                                      AMT                     ,                                                                                           ");
		sql.append("	       A.DV_1                                                     DV_1                    ,                                                                                           ");
		sql.append("	       A.DV_2                                                     DV_2                    ,                                                                                           ");
		sql.append("	       A.DV_3                                                     DV_3                    ,                                                                                           ");
		sql.append("	       A.DV_4                                                     DV_4                    ,                                                                                           ");
		sql.append("	       A.ORDER_REMARK                                             ORDER_REMARK            ,                                                                                           ");
		sql.append("	       A.MIX_GROUP                                                MIX_GROUP               ,                                                                                           ");
		sql.append("	       A.JUBSU_DATE                                               JUBSU_DATE              ,                                                                                           ");
		sql.append("	       A.ACTING_DATE                                              ACTING_DATE             ,                                                                                           ");
		sql.append("	       A.RESULT_DATE                                              RESULT_DATE             ,                                                                                           ");
		sql.append("	       A.DC_GUBUN                                                 DC_GUBUN                ,                                                                                           ");
		sql.append("	       A.DC_YN                                                    DC_YN                   ,                                                                                           ");
		sql.append("	       A.BANNAB_YN                                                BANNAB_YN               ,                                                                                           ");
		sql.append("	       IF( B.ORDER_GUBUN = 'C', FN_DRG_LOAD_DONBOK_YN(A.BOGYONG_CODE, :f_hosp_code), 'N' )                                                                                            ");
		sql.append("	                                                                  DONBOK_YN               ,                                                                                           ");
		sql.append("	       FN_OCS_LOAD_DV_NAME(A.DV, A.DV_1, A.DV_2, A.DV_3, A.DV_4, A.DV_5, A.DV_6, A.DV_7, A.DV_8)  DV_NAME                 ,                                                           ");
		sql.append("	       IF(A.NURSE_CONFIRM_DATE IS NULL, 'N','Y')                  CONFIRM_CHECK            ,                                                                                          ");
		sql.append("	       IF(A.SUNAB_DATE IS NULL, 'N','Y')                          SUNAB_CHECK             ,                                                                                           ");
		sql.append("	       CASE SIGN(A.NALSU) WHEN 1 THEN 'N'                                                                                                                                             ");
		sql.append("	       WHEN 0 THEN 'N' ELSE 'Y' END                               DC_CHECK                ,                                                                                           ");
		sql.append("	       B.SLIP_CODE                                                SLIP_CODE               ,                                                                                           ");
		sql.append("	       B.GROUP_YN                                                 GROUP_YN                ,                                                                                           ");
		sql.append("	       B.SG_CODE                                                  SG_CODE                 ,                                                                                           ");
		sql.append("	       B.ORDER_GUBUN                                              ORDER_GUBUN_BAS         ,                                                                                           ");
		sql.append("	       B.INPUT_CONTROL                                            INPUT_CONTROL           ,                                                                                           ");
		sql.append("	       IFNULL(B.SUGA_YN,'N')                                         SUGA_YN                 ,                                                                                        ");
		sql.append("	       CASE IFNULL(B.EMERGENCY,'Z') WHEN 'Y' THEN 'N'                                                                                                                                 ");
		sql.append("	       WHEN 'N' THEN 'N' ELSE 'Y' END           EMERGENCY_CHECK         ,                                                                                                             ");
		sql.append("	       B.LIMIT_SURYANG                                            LIMIT_SURYANG           ,                                                                                           ");
		sql.append("	       IFNULL(B.SPECIMEN_YN,'N')                                     SPECIMEN_YN             ,                                                                                        ");
		sql.append("	       IFNULL(B.JAERYO_YN,'N')                                       JAERYO_YN               ,                                                                                        ");
		sql.append("	       IF(B.ORD_DANUI IS NULL, 'N', 'Y')                        ORD_DANUI_CHECK         ,                                                                                             ");
		sql.append("	       B.ORD_DANUI                                                ORD_DANUI_BAS           ,                                                                                           ");
		sql.append("	       B.JUNDAL_TABLE_OUT                                         JUNDAL_TABLE_OUT        ,                                                                                           ");
		sql.append("	       B.JUNDAL_PART_OUT                                          JUNDAL_PART_OUT         ,                                                                                           ");
		sql.append("	       IFNULL(DATE_FORMAT(Z.BULYONG_YMD, '%Y/%m/%d'), '9998/12/31')            BULYONG_CHECK           ,                                                                          ");
		sql.append("	       FN_OCS_LOAD_WONYOI_CHECK(B.HANGMOG_CODE, :f_hosp_code)                   WONYOI_ORDER_CR_YN      ,                                                                             ");
		sql.append("	       B.WONYOI_ORDER_YN                                          DEFAULT_WONYOI_ORDER_YN ,                                                                                           ");
		sql.append("	       IFNULL(B.NDAY_YN,'N')                                         NDAY_YN                 ,                                                                                        ");
		sql.append("	       IFNULL(B.MUHYO_YN,'N')                                        MUHYO_YN                ,                                                                                        ");
		sql.append("	       IFNULL(A.TEL_YN, 'N')                                         TEL_YN                  ,                                                                                        ");
		sql.append("	       FN_BAS_LOAD_GWA_NAME(A.JUNDAL_PART, A.ORDER_DATE, :f_hosp_code, :language)          JUNDAL_PART_NAME        ,                                                                  ");
		sql.append("	       E.BUN_CODE                                                 BUN_CODE                ,                                                                                           ");
		sql.append("	       FN_DRG_LOAD_COMMENT(A.HANGMOG_CODE, :f_hosp_code)                         DRG_INFO                ,                                                                            ");
		sql.append("	       ''                                                         DRG_BUNRYU              ,                                                                            ");
		sql.append("	       IF(A.BOM_SOURCE_KEY IS NULL,FN_OCS_LOAD_CHILD_GUBUN(:f_hosp_code,'I',A.PKOCS2003),'3')      CHILD_GUBUN,                                                                       ");
		sql.append("	       A.BOM_SOURCE_KEY                                           BOM_SOURCE_KEY,                                                                                                     ");
		sql.append("	       A.BOM_OCCUR_YN                                             BOM_OCCUR_YN,                                                                                                       ");
		sql.append("	       A.ACTING_TIME                                                  ACTING_TIME,                                                                                                    ");
		sql.append("	       CONCAT( LPAD(A.GROUP_SER,10, '0')                                                                                                                                              ");
		sql.append("	       , CASE WHEN A.SOURCE_FKOCS2003 IS NOT NULL THEN A.SOURCE_FKOCS2003                                                                                                             ");
		sql.append("	                    WHEN A.BOM_SOURCE_KEY IS NULL THEN A.PKOCS2003                                                                                                                    ");
		sql.append("	                    ELSE A.BOM_SOURCE_KEY END                                                                                                                                         ");
		sql.append("	       , A.PKOCS2003)                                                CONT_KEY                                                                                                         ");
		sql.append("	FROM OCS0103 B               										 						                                                                                          ");                                                              
		sql.append("	     LEFT JOIN( SELECT A.SG_CODE                                                                                                                                                      ");
		sql.append("	            , A.SG_NAME                                                                                                                                                               ");
		sql.append("	            , A.BUN_CODE                                                                                                                                                              ");
		sql.append("	            , A.HOSP_CODE                                                                                                                                                             ");
		sql.append("	         FROM BAS0310 A                                                                                                                                                               ");
		sql.append("	        WHERE A.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                                                                                                       ");
		sql.append("	                             FROM BAS0310 Z                                                                                                                                           ");
		sql.append("	                            WHERE Z.SG_CODE = A.SG_CODE                                                                                                                               ");
		sql.append("	                              AND Z.SG_YMD <= :f_naewon_date )                                                                                                                        ");
		sql.append("	     ) E ON E.HOSP_CODE = B.HOSP_CODE AND E.SG_CODE = B.SG_CODE                                                                                                                       ");
		sql.append("		  LEFT JOIN( SELECT X.SG_CODE                                                                                                                                                     ");
		sql.append("	          , X.HOSP_CODE                                                                                                                                                               ");
		sql.append("	          , X.BULYONG_YMD                                                                                                                                                             ");
		sql.append("			  FROM BAS0310 X                                                                                                                                                              ");
		sql.append("			  WHERE X.SG_YMD =(SELECT MAX(Y.SG_YMD)                                                                                                                                       ");
		sql.append("	          FROM BAS0310 Y                                                                                                                                                              ");
		sql.append("	          WHERE Y.SG_CODE = X.SG_CODE                                                                                                                                                 ");
		sql.append("	          AND Y.SG_YMD <= SYSDATE())) Z ON Z.HOSP_CODE = B.HOSP_CODE AND Z.SG_CODE = B.SG_CODE                                                                                        ");
		sql.append("	          AND B.START_DATE =                                                                                                                                                          ");
		sql.append("	           (SELECT MAX(Z.START_DATE)  FROM OCS0103 Z WHERE Z.HANGMOG_CODE = B.HANGMOG_CODE AND Z.START_DATE <= SYSDATE()),                                                            ");
		sql.append("	     OCS0132 C RIGHT JOIN OCS2003 A ON C.HOSP_CODE = A.HOSP_CODE AND  C.CODE = SUBSTR(A.ORDER_GUBUN, 2, 1) AND  C.CODE_TYPE = 'ORDER_GUBUN_BAS' AND C.LANGUAGE = :language            ");
		sql.append("	     LEFT JOIN OCS0132 F ON F.HOSP_CODE = A.HOSP_CODE AND F.CODE = A.INPUT_GUBUN AND  F.CODE_TYPE = 'INPUT_GUBUN' AND F.LANGUAGE = :language                                          ");
		sql.append("	     LEFT JOIN OCS0116 D ON D.HOSP_CODE = A.HOSP_CODE AND  D.SPECIMEN_CODE = A.SPECIMEN_CODE                                                                                          ");
		sql.append("	     LEFT JOIN ADM3200 G ON G.HOSP_CODE = A.HOSP_CODE AND G.USER_ID = A.INPUT_ID                                                                                                      ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                                                                                                                                                     ");
		sql.append("	   AND :f_io_gubun = 'I'                                                                                                                                                              ");
		sql.append("	   AND A.BUNHO            = :f_bunho                                                                                                                                                  ");
		sql.append("	   AND A.FKINP1001        = :f_jubsu_no                                                                                                                                               ");
		sql.append("	   AND A.ORDER_DATE       = :f_naewon_date                                                                                                                                            ");                                                                                                                                       
		sql.append("	   AND A.SORT_FKOCSKEY    = :f_pkocskey                                                                                                                                               ");
		sql.append("	   AND (                                                                                                                                                                              ");
		sql.append("	         ( :f_order_gubun = '4'                                                                                                                                                       ");
		sql.append("	           AND A.BUNHO = :f_bunho                                                                                                                                                     ");
		sql.append("	           AND A.FKINP1001        = :f_jubsu_no                                                                                                                                       ");
		sql.append("	           AND IFNULL(A.ACTING_DATE, IFNULL(A.RESER_DATE, A.ORDER_DATE) ) >= :f_naewon_date                                                                                           ");
		sql.append("	           AND A.DC_YN = 'N'                                                                                                                                                          ");
		sql.append("	           AND A.NALSU > 0                                                                                                                                                            ");
		sql.append("	         )                                                                                                                                                                            ");
		sql.append("	       )                                                                                                                                                                              ");
		sql.append("	   AND B.HANGMOG_CODE     = A.HANGMOG_CODE                                                                                                                                            ");
		sql.append("	   AND B.HOSP_CODE        = A.HOSP_CODE                                                                                                                                               ");
		sql.append("	   AND A.ACTING_DATE BETWEEN B.START_DATE AND B.END_DATE                                                                                                                              ");
		sql.append("	   AND FN_BAS_LOAD_DOCTOR_GWA(:f_hosp_code, A.INPUT_DOCTOR, A.ORDER_DATE) = :f_gwa                                                                                                     ");
		sql.append("	   AND A.INPUT_DOCTOR                                       = :f_doctor                                                                                                               ");
		sql.append("	   AND EXISTS ( SELECT 'X' FROM VW_OCS_INP1001_RES_02 Z WHERE Z.PKINP1001 = A.FKINP1001 )                                                                                             ");
		sql.append("	 ORDER BY 44, 81, 82                                                                                                                                                                  ");
		                                                                                                                                                                                                              
		Query query = entityManager.createNativeQuery(sql.toString());                                                                                                                                                
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_naewon_date", naewonDate);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_order_gubun", orderGubun);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_pkocskey", pkocskey);
		query.setParameter("f_jubsu_no", jubsuNo);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_doctor", doctor);
		
		List<Ocs3003Q10GrdOrderListItemInfo> listResult = new JpaResultMapper().list(query, Ocs3003Q10GrdOrderListItemInfo.class);
		return listResult;
	}

		@Override
		public List<String> getOCS2015U06OrderTypeComboInfo(String hospCode,
				String codeType, String code, String language) {
			StringBuilder sql = new StringBuilder();
			
			sql.append("	SELECT CONCAT('[',CODE,']',CODE_NAME) 		");
			sql.append("	FROM OCS0132 WHERE                          ");
			sql.append("	CODE_TYPE = :codeType                      ");                                    
			sql.append("	AND CODE LIKE :code                         ");                             
			sql.append("	AND HOSP_CODE = :hospCode              	    ");
			sql.append("	AND LANGUAGE = :language              	    ");
			
			Query query = entityManager.createNativeQuery(sql.toString());                                                                                                                                                
			query.setParameter("hospCode", hospCode);
			query.setParameter("codeType", codeType);
			query.setParameter("code", code);
			query.setParameter("language", language);
			
			List<String> list = query.getResultList();
			return list;
		}
		
	@Override
	public List<OUT1001P03GrdOrderInfo> getOUT1001P03GrdOrderInfo(String hospCode, String language, String ioGubun, String bunho, Double naewonKey, boolean isBefore){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.PKOCS1003       PKOCSKEY                                                                                                                                          ");
		sql.append("     , A.ORDER_GUBUN     ORDER_GUBUN                                                                                                                                       ");
		sql.append("     , B.CODE_NAME       ORDER_GUBUN_NAME                                                                                                                                  ");
		sql.append("     , A.HANGMOG_CODE    HANGMOG_CODE                                                                                                                                      ");
		sql.append("     , C.HANGMOG_NAME    HANGMOG_NAME                                                                                                                                      ");
		sql.append("     , A.SURYANG         SURYANG                                                                                                                                           ");
		sql.append("     , D.CODE_NAME       ORD_DANUI                                                                                                                                         ");
		sql.append("     , A.NALSU           NALSU                                                                                                                                             ");
		sql.append("  FROM OCS1003 A LEFT JOIN OCS0132 D ON D.HOSP_CODE = A.HOSP_CODE AND D.CODE_TYPE = 'ORD_DANUI' AND D.CODE = A.ORD_DANUI  AND D.LANGUAGE = :f_language                     ");
		sql.append("                 JOIN OCS0132 B ON B.HOSP_CODE = A.HOSP_CODE AND B.CODE_TYPE = 'ORDER_GUBUN_BAS' AND B.CODE = SUBSTR(A.ORDER_GUBUN, 2, 1)  AND B.LANGUAGE = :f_language    ");
		sql.append("                 JOIN OCS0103 C ON C.HOSP_CODE = A.HOSP_CODE AND C.HANGMOG_CODE = A.HANGMOG_CODE                                                                           ");
		sql.append(" WHERE :f_io_gubun = 'O'                                                                                                                                                   ");
		sql.append("   AND A.HOSP_CODE = :f_hosp_code                                                                                                                                          ");
		if(isBefore){
			sql.append("   AND A.BUNHO     = :f_bunho                                                                                                                 ");
		}
		sql.append("   AND A.FKOUT1001 = :f_naewon_key                                                                                                            ");
		sql.append("UNION ALL                                                                                                                                     ");
		sql.append("SELECT A.PKOCS2003       PKOCSKEY                                                                                                             ");
		sql.append("     , A.ORDER_GUBUN     ORDER_GUBUN                                                                                                          ");
		sql.append("     , B.CODE_NAME       ORDER_GUBUN_NAME                                                                                                     ");
		sql.append("     , A.HANGMOG_CODE    HANGMOG_CODE                                                                                                         ");
		sql.append("     , C.HANGMOG_NAME    HANGMOG_NAME                                                                                                         ");
		sql.append("     , A.SURYANG         SURYANG                                                                                                              ");
		sql.append("     , D.CODE_NAME       ORD_DANUI                                                                                                            ");
		sql.append("     , A.NALSU           NALSU                                                                                                                ");
		sql.append("  FROM OCS2003 A JOIN OCS0132 B ON B.HOSP_CODE = A.HOSP_CODE AND B.CODE_TYPE = 'ORDER_GUBUN_BAS' AND B.CODE = SUBSTR(A.ORDER_GUBUN, 2, 1)  AND B.LANGUAGE = :f_language   ");
		sql.append("                 JOIN OCS0103 C ON C.HOSP_CODE = A.HOSP_CODE AND C.HANGMOG_CODE = A.HANGMOG_CODE                                              ");
		sql.append("                 LEFT JOIN OCS0132 D ON D.HOSP_CODE = A.HOSP_CODE AND D.CODE_TYPE = 'ORD_DANUI' AND D.CODE = A.ORD_DANUI  AND D.LANGUAGE = :f_language                     ");
		sql.append(" WHERE :f_io_gubun = 'I'                                                                                                                      ");
		sql.append("   AND A.HOSP_CODE = :f_hosp_code                                                                                                             ");
		sql.append("   AND A.BUNHO     = :f_bunho                                                                                                                 ");
		sql.append("   AND A.FKINP1001 = :f_naewon_key                                                                                                            ");
		sql.append(" ORDER BY 2, 1, 3                                                                                                                             ");
		
        
		Query query = entityManager.createNativeQuery(sql.toString());                                                                                                                                                
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_io_gubun", ioGubun);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_naewon_key", naewonKey);
		
		List<OUT1001P03GrdOrderInfo> listResult = new JpaResultMapper().list(query, OUT1001P03GrdOrderInfo.class);
		return listResult;
	}

	@Override
	public List<CheckHideButtonInfo> getCheckHideButtonInfo(String hospCode, String codeType) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT  CODE, CODE_NAME, SORT_KEY	");
		sql.append("	FROM    OCS0132						");
		sql.append("	WHERE   HOSP_CODE = :f_hosp_code 	");
		sql.append("		AND CODE_TYPE = :f_code_type	");
		sql.append("	ORDER BY SORT_KEY ASC				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		
		List<CheckHideButtonInfo> listResult = new JpaResultMapper().list(query, CheckHideButtonInfo.class);
		return listResult;
	}

	@Override
	public List<ComboListItemInfo> getCodeAndCodeNameByCodeType(String hospCode, String language, String codeType) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT '%' CODE, FN_ADM_MSG('221',:f_language) CODE_NAME  UNION  		    		");       
		sql.append(" SELECT CODE CODE, CODE_NAME   CODE_NAME FROM OCS0132 			                   	");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code                                     			 	");
		sql.append(" AND LANGUAGE  = :f_language                                         				");
		sql.append(" AND CODE_TYPE = :f_code_type ORDER BY CODE                             			");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public List<ComboListItemInfo> getComboListJusa(String hospCode, String argu1) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.CODE, A.CODE_NAME													");
		sql.append("	FROM OCS0132 A																");
		sql.append("	LEFT JOIN (																	");
		sql.append("	  SELECT 'O'        AS IO_GUBUN												");
		sql.append("	        , A.JUSA    AS JUSA													");
		sql.append("	        , COUNT(*)  AS RANK_CNT												");
		sql.append("	  FROM OCS1003 A															");
		sql.append("	  JOIN OCS0132 B ON A.HOSP_CODE = B.HOSP_CODE								");
		sql.append("	                AND A.JUSA = B.CODE          								");
		sql.append("	  WHERE A.HOSP_CODE = :f_hosp_code											");
		sql.append("	    AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'B'								");
		sql.append("	    AND B.CODE_TYPE = 'JUSA'												");
		sql.append("	  GROUP BY 'O', A.JUSA														");
		sql.append("	  UNION																		");
		sql.append("	  SELECT 'I'        AS IO_GUBUN												");
		sql.append("	        , A.JUSA    AS JUSA													");
		sql.append("	        , COUNT(*)  AS RANK_CNT												");
		sql.append("	  FROM OCS2003 A															");
		sql.append("	  JOIN OCS0132 B ON A.HOSP_CODE = B.HOSP_CODE								");
		sql.append("	                AND A.JUSA = B.CODE											");
		sql.append("	  WHERE A.HOSP_CODE = :f_hosp_code											");
		sql.append("	    AND SUBSTRING(A.ORDER_GUBUN, 2, 1) = 'B'								");
		sql.append("	    AND B.CODE_TYPE = 'JUSA'												");
		sql.append("	  GROUP BY 'I', A.JUSA														");
		sql.append("	  ORDER BY IO_GUBUN, RANK_CNT DESC											");
		sql.append("	) R ON A.CODE = R.JUSA														");
		sql.append("	   AND R.IO_GUBUN = :f_argu1												");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code											");
		sql.append("	  AND A.CODE_TYPE = 'JUSA'													");
		sql.append("	ORDER BY IFNULL(R.RANK_CNT, 0) DESC											");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_argu1", argu1);
		
		List<ComboListItemInfo> lstResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return lstResult;
	}

	@Override
	public String callFnOcsLoadCodeName(String hospCode, String language, String codeType, String code) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT FN_OCS_LOAD_CODE_NAME(:code_type, :code , :f_hosp_code,:f_language)   ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("code_type", codeType);
		query.setParameter("code", code);
		
		List<String> list = query.getResultList();
		return StringUtils.isEmpty(list) ? ""  : list.get(0);
	}

	@Override
	public List<OCS1024U00xEditGridCell20Info> getOCS1024U00xEditGridCell20Info(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.CODE                              ");
		sql.append("     , B.CODE_NAME, B.CODE_TYPE             ");
		sql.append("  FROM OCS0131 A                            ");
		sql.append("     , OCS0132 B                            ");
		sql.append(" WHERE B.HOSP_CODE = :hosp_code             ");
		sql.append("   AND B.LANGUAGE = :language               ");
		sql.append("   AND A.CODE_TYPE = 'DV_TIME'              ");
		sql.append("   AND B.LANGUAGE = A.LANGUAGE              ");
		sql.append("   AND B.CODE_TYPE = A.CODE_TYPE            ");
		sql.append("   AND B.MENT      IN ('Divide', 'Count')   ");
		sql.append(" ORDER BY  B.SORT_KEY						");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		
		List<OCS1024U00xEditGridCell20Info> lstResult = new JpaResultMapper().list(query, OCS1024U00xEditGridCell20Info.class);
		return lstResult;
	}

	@Override
	public List<ComboListItemInfo> getOCS2003P01MakeInputGubunTabRequest(String hospCode, String language, String code,
			String codeType, boolean isAll) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT CODE, CODE_NAME							");
		sql.append("    FROM    									");
		sql.append("    (			   								");
		if (isAll) {
			sql.append(" SELECT 'DA' CODE 			   				");
			sql.append(" 	, '全体' CODE_NAME      					");
			sql.append("  	, 0   	 SORT_KEY		   				");
			sql.append(" FROM DUAL     								");
			sql.append(" UNION     									");
			sql.append(" SELECT A.CODE 		CODE 				 	");
			sql.append(" 	  , A.CODE_NAME CODE_NAME   			");
			sql.append(" 	  , A.SORT_KEY  SORT_KEY				");
		}
		else {
			sql.append(" SELECT A.CODE   	 CODE					");
			sql.append(" 	  , A.CODE_NAME  CODE_NAME 				");
		}
		
		sql.append("    FROM OCS0132 A   							");
		sql.append("   WHERE A.CODE_TYPE LIKE :f_code_type    		");
		sql.append("     AND A.CODE LIKE :f_code    				");
		sql.append("     AND A.HOSP_CODE = :f_hosp_code   			");
		sql.append("     AND A.LANGUAGE = :f_language   			");
		sql.append("     AND A.VALUE_POINT = '1'   					");		
		sql.append(" ) AA											");
		if (isAll) {
			sql.append(" ORDER BY SORT_KEY							");
		}
		else {
			sql.append(" ORDER BY CODE, CODE_NAME					");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
	    return list;
	}

	@Override
	public List<ComboListItemInfo> getOCS2005U00fwkCombo(String hospCode, String language, String codeType,
			String codeName) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.CODE, A.CODE_NAME 							");
		sql.append("	  FROM OCS0132 A 									");
		sql.append("	 WHERE A.CODE_TYPE = :f_code_type 					");
		sql.append("	   AND A.HOSP_CODE = :f_hosp_code 					");
		sql.append("	   AND A.CODE_NAME LIKE CONCAT('%', :f_find1, '%') 	");
		sql.append("     ORDER BY A.SORT_KEY, A.CODE 						");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_find1", codeName);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> listResult = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public List<CPL0000Q00GetSigeyulDataSelect1ListItemInfo> getCPL0000Q00GetSigeyulDataSelect1ListItemInfo(
			String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("	 SELECT FN_OCS_LOAD_CODE_NAME('BML_URL_INFO','SERVER_IP',:f_hosp_code,:f_language)  SERVER_IP	");
		sql.append("	      , FN_OCS_LOAD_CODE_NAME('BML_URL_INFO','USER_ID',:f_hosp_code,:f_language)    USER_ID		");
		sql.append("	      , FN_OCS_LOAD_CODE_NAME('BML_URL_INFO','PASSWORD',:f_hosp_code,:f_language)   PASSWORD	");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<CPL0000Q00GetSigeyulDataSelect1ListItemInfo> listResult = new JpaResultMapper().list(query, CPL0000Q00GetSigeyulDataSelect1ListItemInfo.class);
		return listResult;
	}
	
	@Override
	public List<ComboListItemInfo> getgetComboDataSourceInfoCaseOrderCaseHodong(String hospCode, String agr1, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.GWA CODE, A.GWA_NAME CODE_NAME											");
		sql.append(" FROM VW_BAS_GWA A																	");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code													");
		sql.append("   AND A.BUSEO_GUBUN = '2'															");
		sql.append("   AND A.START_DATE <= IFNULL(STR_TO_DATE(:f_argu1, '%Y/%m/%d'), CURRENT_DATE())	");
		sql.append("   AND A.END_DATE >= IFNULL(STR_TO_DATE(:f_argu1, '%Y/%m/%d'), CURRENT_DATE())		");
		sql.append("   AND A.LANGUAGE = :f_language														");
		sql.append("   AND A.USE_YN = 'Y'																");
		sql.append(" ORDER BY A.GWA																		");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_argu1", StringUtils.isEmpty(agr1) ? null : agr1);
		query.setParameter("f_language", language);
		
		List<ComboListItemInfo> listResult= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}

	@Override
	public List<ComboListItemInfo> findCbxByCodeTypeTextSearch(String hospCode, String language, String codeType,
			String find1) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.CODE, A.CODE_NAME                         ");
		sql.append("	 FROM OCS0132 A                                    ");
		sql.append("	WHERE A.HOSP_CODE = :f_hosp_code                   ");
		sql.append("	  AND A.LANGUAGE  = :f_language					   ");
		sql.append("	  AND (A.CODE     LIKE CONCAT('%', :f_find1, '%')  ");
		sql.append("	   OR A.CODE_NAME LIKE CONCAT('%', :f_find1, '%')) ");
		sql.append("	  AND A.CODE_TYPE = :f_code_type                   ");
		sql.append("	ORDER BY A.SORT_KEY, A.CODE                        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_find1", find1);
		
		List<ComboListItemInfo> listResult= new JpaResultMapper().list(query, ComboListItemInfo.class);
		return listResult;
	}
}


