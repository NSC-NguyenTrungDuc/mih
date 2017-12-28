package nta.med.data.dao.medi.impl;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.common.SequenceInfo;
import nta.med.data.model.ihis.cpls.CPL3020U02GetSpecimenInfoSelectListItemInfo;
import nta.med.data.model.ihis.nuro.NuroChkGetWonyoiYnInfo;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import javax.persistence.*;
import java.math.BigInteger;
import java.sql.Date;
import java.util.Calendar;
import java.util.List;

public class CommonRepositoryImpl implements CommonRepository{
	private static final Log LOG = LogFactory.getLog(CommonRepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getNextVal(String seqName){
//		StringBuilder sql = new StringBuilder("SELECT SWF_NextVal(:f_seq_name)");
//		Query query = entityManager.createNativeQuery(sql.toString());
//		query.setParameter("f_seq_name", seqName);
//		
//		List<Object> result = query.getResultList();
//		if(!result.isEmpty() && result.get(0) != null){
//			 String val = result.get(0).toString();
//			 LOG.info("Next val of " + seqName + ": " + val);
//			 return val;
//		}
//		return null;
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_SWF_NextVal");
		query.registerStoredProcedureParameter("SeqN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("ValNext", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("SeqVal", String.class, ParameterMode.OUT);
		
		query.setParameter("SeqN", seqName);
		query.setParameter("ValNext", 1D);
		
		query.execute();
		Object result = (Object)query.getOutputParameterValue("SeqVal");
		if(result != null){
			return result.toString();
		}
		return null;
	}
	
	@Override
	public String getNextValByHospCode(String hospCode, String seqName){
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_SWF_NextValByHospCode");
		query.registerStoredProcedureParameter("I_HospCode", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("SeqN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("ValNext", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("SeqVal", String.class, ParameterMode.OUT);
		
		query.setParameter("I_HospCode", hospCode);
		query.setParameter("SeqN", seqName);
		query.setParameter("ValNext", 1D);
		
		query.execute();
		Object result = (Object)query.getOutputParameterValue("SeqVal");
		if(result != null){
			return result.toString();
		}
		return null;
	}
	
	@Override
	public List<CPL3020U02GetSpecimenInfoSelectListItemInfo> getCPL3020U02GetSpecimenInfoSelectListItemInfo(String hospCode, String language,String gwa, String hoDong, String orderDate){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_BAS_LOAD_GWA_NAME(TRIM(:o_gwa),STR_TO_DATE(:o_order_date,'%Y/%m/%d'),:f_hosp_code,:f_language)       GWA_NAME     ");
		sql.append("     , FN_BAS_LOAD_GWA_NAME(TRIM(:o_ho_dong),STR_TO_DATE(:o_order_date,'%Y/%m/%d'),:f_hosp_code,:f_language)   HO_DONG_NAME ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("o_gwa", gwa);
		query.setParameter("o_ho_dong", hoDong);
		query.setParameter("o_order_date", orderDate);
		List<CPL3020U02GetSpecimenInfoSelectListItemInfo> list = new JpaResultMapper().list(query, CPL3020U02GetSpecimenInfoSelectListItemInfo.class);
		return list;
	}
	
	@Override
	public String getGubunName(String hospCode, String date, String gubun){
		StringBuilder sql = new StringBuilder("SELECT FN_BAS_LOAD_GUBUN_NAME(:gubun, STR_TO_DATE(:date, '%Y/%m/%d'),:hospCode)");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("gubun", gubun);
		query.setParameter("date", date);
		query.setParameter("hospCode", hospCode);
		
		List<String> result = query.getResultList();
		if(!result.isEmpty() && result.get(0) != null){
			 String val = result.get(0);
			 return val;
		}
		return null;
	}
	
	@Override
	public String getGwaNameBAS0260(String hospCode, String language, String gwa, String date){
		StringBuilder sql = new StringBuilder("SELECT FN_BAS_LOAD_GWA_NAME(:gwa, STR_TO_DATE(:date, '%Y/%m/%d'), :hospCode, :language)");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("language", language);
		query.setParameter("gwa", gwa);
		query.setParameter("date", date);
		query.setParameter("hospCode", hospCode);
		
		List<String> result = query.getResultList();
		if(!result.isEmpty() && result.get(0) != null){
			 String val = result.get(0);
			 return val;
		}
		return null;
	}
	
	public NuroChkGetWonyoiYnInfo getNuroChkGetWonyoiYnInfo(String hospCode, String language, String gubun,
			String gongbiCode1, String gongbiCode2, String gongbiCode3, String gongbiCode4){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_OUT_CHECK_WONYOI_YN (:f_gubun, :f_gongbi_code1,:f_hosp_code, :f_language) WONYOI_YN1 ");
		sql.append("     , FN_OUT_CHECK_WONYOI_YN (:f_gubun, :f_gongbi_code2,:f_hosp_code, :f_language) WONYOI_YN2 ");
		sql.append("     , FN_OUT_CHECK_WONYOI_YN (:f_gubun, :f_gongbi_code3,:f_hosp_code, :f_language) WONYOI_YN3 ");
		sql.append("     , FN_OUT_CHECK_WONYOI_YN (:f_gubun, :f_gongbi_code4,:f_hosp_code, :f_language) WONYOI_YN4 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_gubun", gubun);
		query.setParameter("f_gongbi_code1", gongbiCode1);
		query.setParameter("f_gongbi_code2", gongbiCode2);
		query.setParameter("f_gongbi_code3", gongbiCode3);
		query.setParameter("f_gongbi_code4", gongbiCode4);
		List<NuroChkGetWonyoiYnInfo> list = new JpaResultMapper().list(query, NuroChkGetWonyoiYnInfo.class);
		if(list != null && list.size() > 0){
			return list.get(0);
		}
		return null;
	}
	
	@Override
	public String getFormEnvironInfoSysDate(Integer offset, String format){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT SYSDATE()");
		Query query = entityManager.createNativeQuery(sql.toString());
		List<Date> result = query.getResultList();
		if(!result.isEmpty() && result.get(0) != null){

			Calendar calendar = Calendar.getInstance();
			calendar.setTime(result.get(0));
			if(offset != null && offset != 0 )
			{
				calendar.add(Calendar.HOUR, -offset); // adds one hour
			}

			return DateUtil.toString(calendar.getTime(), format);

		}
		return null;
	}
	
//	@Override
//	public String getFormEnvironInfoSysDateTime(Integer offset){
//		StringBuilder sql = new StringBuilder();
//		sql.append(" SELECT SYSDATE()");
//		Query query = entityManager.createNativeQuery(sql.toString());
//
//		List<Date> result = query.getResultList();
//		if(!result.isEmpty() && result.get(0) != null){
//
//			Calendar calendar = Calendar.getInstance();
//			calendar.setTime(result.get(0));
//			if(offset != null && offset != 0 )
//			{
//				calendar.add(Calendar.HOUR, -offset); // adds one hour
//			}
//
//			return DateUtil.toString(calendar.getTime(), DateUtil.PATTERN_DDMMYYYYHHMMSS);
//
//		}
//		return null;
//	}

	@Override
	public BigInteger getXMstGridDeleteRowInfo(String tableName, String whereCmd, String hospCode, String columnName) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT COUNT(1) FROM " + tableName +" WHERE 1 = 1 " + whereCmd );
		if(!StringUtils.isEmpty(columnName)){
			sql.append("AND  HOSP_CODE = :hospCode                   ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		if(!StringUtils.isEmpty(columnName)){
			query.setParameter("hospCode", hospCode);
		}
		List<BigInteger> result = query.getResultList();
		if(!result.isEmpty() && result.get(0) != null){
			BigInteger val = result.get(0);
			 return val;
		}
		return null;
	}

	@Override
	public String callFnLoadOcsCodeName(String hospCode, String mapGubun,
										String code, String language) {

		StringBuilder sql = new StringBuilder();

		sql.append("SELECT CODE_NAME  FROM VW_IFS_" + mapGubun + " WHERE HOSP_CODE = :hospCode AND CODE = :code");
		List<String> listColumn = getColumnInformation("VW_IFS_" + mapGubun);
		if (listColumn.contains("LANGUAGE")) {
			sql.append("	AND LANGUAGE = :language         ");
		}
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("code", code);
		if (listColumn.contains("LANGUAGE")) {
			query.setParameter("language", language);
		}
		List<String> result = query.getResultList();
		if (!result.isEmpty() && result.get(0) != null) {
			return result.get(0);
		}
		return null;


	}
	
	@Override
	public List<ComboListItemInfo> getIfs003U03GridFindClickListItem(
			String mapGubun, String hospCode, String find, String language, Integer startNum, Integer endNum) {
		List<String> listColumn = getColumnInformation("VW_IFS_"+mapGubun);
		
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.CODE         AS CODE    		    	"); 
		sql.append("	    , A.CODE_NAME    AS NAME                    ");
		sql.append("	 FROM  VW_IFS_"+mapGubun+" A                    ");
		sql.append("	WHERE A.HOSP_CODE    = :f_hosp_code             ");
		sql.append("	AND (   A.CODE      LIKE :f_find1               ");
		sql.append("	     OR A.CODE_NAME LIKE :f_find1               ");
		sql.append("	    )                                           ");
		if(listColumn.contains("LANGUAGE")){
			sql.append("	AND A.LANGUAGE = :language         ");
		}
		if(startNum != null && endNum != null){
			sql.append("	LIMIT :startNum, :endNum	    			");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_find1", "%"+find+"%");
		if(startNum != null && endNum != null){
			query.setParameter("startNum", startNum);
			query.setParameter("endNum", endNum);
		}
		if(listColumn.contains("LANGUAGE")){
			query.setParameter("language", language);
		}
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public List<String> getColumnInformation(String table) {
		StringBuilder sql = new StringBuilder();
		                                                
		sql.append("SELECT COLUMN_NAME                  ");
		sql.append("  FROM INFORMATION_SCHEMA.COLUMNS   ");
		sql.append(" WHERE TABLE_SCHEMA = 'ihis'        ");
		sql.append("   AND TABLE_NAME IN (:table)         ");
		
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("table", table);
		
		List<String> list = query.getResultList();
		return list;
	}

	@Override
	public String getMessageByCodeAndLanguage(String code, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_ADM_MSG(:f_code, :f_language)    ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code", code);
		query.setParameter("f_language", language);
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			 return result.get(0);
		}
		return null;
	}

	@Override
	public SequenceInfo getSeqInfo(String seqName, String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT IFNULL(SeqValue,0) + 1                                NEXT_SEQ, ");
		sql.append("		   SeqMax                                				 LIMIT_SEQ,");
		sql.append("		   CASE WHEN SeqValue + 1 > SeqMax THEN '1' ELSE '0' END OVERLOAD  ");
		sql.append("	FROM SWT_Sequence                                                      ");                                          
		sql.append("	WHERE SeqName = :seqName                                                ");
		sql.append("	AND HOSP_CODE = :hospCode                                              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("seqName", seqName);
		query.setParameter("hospCode", hospCode);
		List<SequenceInfo> result = new JpaResultMapper().list(query, SequenceInfo.class);
		if(!CollectionUtils.isEmpty(result)){
			 return result.get(0);
		}
		return null;
	}

	@Override
	public String getFormEnvironSysDateTimePATTERNHHMM() {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DATE_FORMAT(SYSDATE(),'%H%i')");
		Query query = entityManager.createNativeQuery(sql.toString());
		List<String> result = query.getResultList();
		if(!StringUtils.isEmpty(result)){
			 return result.get(0);
		}
		return null;
	}

	@Override
	public void truncateTable(String tableName) {
		StringBuilder sql = new StringBuilder();
		sql.append("TRUNCATE TABLE ");
		sql.append(tableName);
		Query query = entityManager.createNativeQuery(sql.toString());
		query.executeUpdate();
		
	}

	@Override
	public void deleteTable(String tableName) {
		StringBuilder sql = new StringBuilder();
		sql.append("Delete from ");
		sql.append(tableName);
		Query query = entityManager.createNativeQuery(sql.toString());
		query.executeUpdate();
	}

	@Override
	public String checkColumnExistOnTable(String tableName, String tableSchema) {
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT COLUMN_NAME                       ");
		sql.append("  FROM INFORMATION_SCHEMA.COLUMNS        ");
		sql.append(" WHERE TABLE_SCHEMA = :tableSchema       ");
		sql.append("   AND TABLE_NAME = :tableName           ");
		sql.append("  AND COLUMN_NAME = 'HOSP_CODE'          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("tableName", tableName);
		query.setParameter("tableSchema", tableSchema);
		List<String> columnName = query.getResultList();
		if(!CollectionUtils.isEmpty(columnName)){
			return columnName.get(0);
		}
		return null;
	}
	
	//[Start] Med-1.5.2 Basic Design: MED-8065
	@Override
	public String getNextBunho(String seqName, String seqInc, String hospCode) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_SWF_NextValByHospCode");
		query.registerStoredProcedureParameter("I_HospCode", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("SeqN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("ValNext", Double.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("SeqVal", String.class, ParameterMode.OUT);
		
		query.setParameter("I_HospCode", hospCode);
		query.setParameter("SeqN", seqName);
		query.setParameter("ValNext", CommonUtils.parseDouble(seqInc));
		
		query.execute();
		Object result = (Object)query.getOutputParameterValue("SeqVal");
		if(result != null){
			return result.toString();
		}
		return null;
	}

	@Override
	public String getSeqInc(String seqName, String hospCode) {
		StringBuilder sql = new StringBuilder();		
		sql.append(" SELECT CAST(SeqInc AS CHAR) FROM SWT_Sequence WHERE  SeqName = :seqName AND HOSP_CODE = :hospCode ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("seqName", seqName);
		query.setParameter("hospCode", hospCode);
		List<String> result = query.getResultList();
		if(!result.isEmpty() && result.get(0) != null){
			String val = result.get(0);
			 return val;
		}
		return null;
	}
	
	@Override
	public String getCurrentSeq(String seqName, String hospCode) {
		StringBuilder sql = new StringBuilder();		
		sql.append(" SELECT CAST(SeqValue AS CHAR) FROM SWT_Sequence WHERE  SeqName = :seqName AND HOSP_CODE = :hospCode ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("seqName", seqName);
		query.setParameter("hospCode", hospCode);
		List<String> result = query.getResultList();
		if(!result.isEmpty() && result.get(0) != null){
			String val = result.get(0);
			 return val;
		}
		return null;
	}
	
	@Override
	public Integer updateSequence(String seqName, String hospCode, Integer maxBunho) {
		StringBuilder sql = new StringBuilder();
		sql.append("UPDATE SWT_Sequence                			");
		sql.append("  SET SeqValue = :maxBunho        			");
		sql.append(" WHERE HOSP_CODE = :hospCode       			");
		sql.append(" AND   SeqName = :seqName       			");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("seqName", seqName);
		query.setParameter("hospCode", hospCode);
		query.setParameter("maxBunho", maxBunho);
		return query.executeUpdate();
	}

	@Override
	public Double callFnDrgWonyoiTotSurang(Double nalsu, Double suryang, Double dv, String dvTime) {
		StringBuilder sql = new StringBuilder();		
		sql.append(" SELECT FN_DRG_WONYOI_TOT_SURYANG(:nalsu, :suryang, :dv, :dvTime) ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("nalsu", nalsu);
		query.setParameter("suryang", suryang);
		query.setParameter("dv", dv);
		query.setParameter("dvTime", dvTime);
		List<Double> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			 return result.get(0);
		}
		return null;
	}

	@Override
	public String getSystemDateTime() {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DATE_FORMAT(SYSDATE(), '%Y/%m/%d %H:%i:%s')	");
		Query query = entityManager.createNativeQuery(sql.toString());
		List<String> result = query.getResultList();
		return CollectionUtils.isEmpty(result) ? "" : result.get(0);
	}
}
