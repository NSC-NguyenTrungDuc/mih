package nta.med.data.dao.medi.drg.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.domain.drg.Drg0120;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01BongtuInfo;
import nta.med.data.model.ihis.drug.DRG0120U00Grd0120Item2Info;
import nta.med.data.model.ihis.drug.DRG0120U00Grd0120Item3Info;
import nta.med.data.model.ihis.drug.DRG0120U00GrdDrg0120Item1Info;
import nta.med.data.model.ihis.drug.DRG0120U00GrdDrg0120ItemInfo;
import nta.med.data.model.ihis.emr.OCS2015U00DosageInfo;
import nta.med.data.model.ihis.ocsa.OCS0208Q00LayBanghyangInfo;
import nta.med.data.model.ihis.ocsa.OCS0208Q01GrdDrg0120Info;
import nta.med.data.model.ihis.system.CFFormUnevenPrescribeLayDRG0120Info;
import nta.med.data.model.ihis.system.OBGetBogyongByDvItemInfo;

/**
 * @author dainguyen.
 */
@Repository("drg0120Repository")
public class Drg0120RepositoryImpl extends SimpleJpaRepository<Drg0120, Long> implements Drg0120Repository {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Drg0120RepositoryImpl(EntityManager entityManager) {
		super(Drg0120.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Drg0120Repository", allEntries = true)
	public Drg0120 save(Drg0120 entity) {
		return super.save(entity);
	}
	
	@Override
	@CacheEvict(value = "Drg0120Repository", allEntries = true)
	public List<Drg0120> save(List<Drg0120> entities) {
		return super.save(entities);
	}
	
	@CacheEvict(value = "Drg0120Repository", allEntries = true)
	@Override
	public void delete(Drg0120 entity) {
		super.delete(entity);
	}
	
	//@CacheEvict(value = "Drg0120Repository", allEntries = true)
	public Integer updateDrg0120(Date updDate,
			String bogyongName,
			String pattern,
			String bogyongGubun,
			String drgGrp,
			String bogyongName2,
			String bogyongGubunDefault,
			String prtGubun,
			String bunryu1,
			String bogyongCodeFull,
			String spBogyongYn,
			String blockGubun,
			String banghyang,
			String chiryoGubun,
			String donbogYn,
			String updId,
			String bogyongJoFlag,
			String bogyongJuFlag,
			String bogyongSeokFlag,
			String bogyongTime1Flag,
			String bogyongTime2Flag,
			String bogyongTime3Flag,
			String bogyongTime4Flag,
			String bogyongTime5Flag,
			String bogyongTime6Flag,
			String bogyongTime7Flag,
			String bogyongCode, 
			String hospCode,
			String language) {
		String sqlQuery = "UPDATE Drg0120 SET updDate = :f_sys_date, bogyongName = :f_bogyong_name, pattern = :f_pattern "
			+ ", bogyongGubun = :f_bogyong_gubun, drgGrp = :f_drg_grp, bogyongName2 = :f_bogyong_name_2 "
			+ ", bogyongGubunDefault = :f_bogyong_gubun_default, prtGubun = :f_prt_gubun "
			+ ", bunryu1 = :f_bunryu1, bogyongCodeFull = :f_bogyong_code_full, spBogyongYn = :f_sp_bogyong_yn "
			+ ", blockGubun = :f_block_gubun, banghyang = :f_banghyang, chiryoGubun = :f_chiryo_gubun "
			+ " ,donbogYn = :f_donbog_yn, updId = :f_user_id, bogyongJoFlag = :f_bogyong_jo_flag "
			+ " ,bogyongJuFlag = :f_bogyong_ju_flag, bogyongSeokFlag = :f_bogyong_seok_flag "
			+ ", bogyongTime1Flag = :f_bogyong_time1_flag, bogyongTime2Flag = :f_bogyong_time2_flag "
			+ ", bogyongTime3Flag = :f_bogyong_time3_flag, bogyongTime4Flag = :f_bogyong_time4_flag "
			+ ", bogyongTime5Flag = :f_bogyong_time5_flag, bogyongTime6Flag = :f_bogyong_time6_flag "
			+ ", bogyongTime7Flag = :f_bogyong_time7_flag WHERE bogyongCode = :f_bogyong_code AND language = :f_language AND hospCode = :f_hosp_code";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("f_sys_date", updDate);
		query.setParameter("f_bogyong_name", bogyongName);
		query.setParameter("f_pattern", pattern);
		query.setParameter("f_bogyong_gubun", bogyongGubun);
		query.setParameter("f_drg_grp", drgGrp);
		query.setParameter("f_bogyong_name_2", bogyongName2);
		query.setParameter("f_bogyong_gubun_default", bogyongGubunDefault);
		query.setParameter("f_prt_gubun", prtGubun);
		query.setParameter("f_bunryu1", bunryu1);
		query.setParameter("f_bogyong_code_full", bogyongCodeFull);
		query.setParameter("f_sp_bogyong_yn", spBogyongYn);
		query.setParameter("f_block_gubun", blockGubun);
		query.setParameter("f_banghyang", banghyang);
		query.setParameter("f_chiryo_gubun", chiryoGubun);
		query.setParameter("f_donbog_yn", donbogYn);
		query.setParameter("f_user_id", updId);
		query.setParameter("f_bogyong_jo_flag", bogyongJoFlag);
		query.setParameter("f_bogyong_ju_flag", bogyongJuFlag);
		query.setParameter("f_bogyong_seok_flag", bogyongSeokFlag);
		query.setParameter("f_bogyong_time1_flag", bogyongTime1Flag);
		query.setParameter("f_bogyong_time2_flag", bogyongTime2Flag);
		query.setParameter("f_bogyong_time3_flag", bogyongTime3Flag);
		query.setParameter("f_bogyong_time4_flag", bogyongTime4Flag);
		query.setParameter("f_bogyong_time5_flag", bogyongTime5Flag);
		query.setParameter("f_bogyong_time6_flag", bogyongTime6Flag);
		query.setParameter("f_bogyong_time7_flag", bogyongTime7Flag);
		query.setParameter("f_bogyong_code", bogyongCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		
		return query.executeUpdate();
	}
	
//	@CacheEvict(value = "Drg0120Repository", allEntries = true)
	public Integer deleteDrg0120( String bogyongCode,String hospCode, String language){
		String sqlQuery = "DELETE Drg0120 WHERE bogyongCode = :f_bogyong_code AND language = :f_language AND hospCode = :f_hosp_code";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("f_bogyong_code", bogyongCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		
		return query.executeUpdate();
	}
	
	//@Cacheable(value = "Drg0120Repository")
	public String getHIOcsBogyong(String hospCode, String bogyongCode, String language){
		String sqlQuery = "SELECT DISTINCT 'Y' FROM Drg0120 A WHERE A.bogyongCode = :f_bogyong_code AND A.ioGubun != 'O' AND A.language = :f_language AND A.hospCode = :f_hosp_code ";
		
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("f_bogyong_code", bogyongCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		
		List<String> listStr = query.getResultList();
		if(!CollectionUtils.isEmpty(listStr)) {
			return listStr.get(0);
		}
		return null;
	}
	
	//@Cacheable(value = "Drg0120Repository")
	public List<Drg0120> getObjectOBGetBogyongInfo(String hospCode,String bogyoungCode, String language){
		String sqlQuery = "SELECT drg FROM Drg0120 drg WHERE bogyongCode = :f_aBogyongCode AND language = :f_language AND hospCode = :f_hosp_code";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("f_aBogyongCode", bogyoungCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		
		return query.getResultList();
	}
	
	//TODO
	@Override
	public DrgsDRG5100P01BongtuInfo getDrgsDRG5100P01BongtuInfo(String hospCode, String language, String jubsuDate, 
			String actDate, String bogyongCode, String fkocs1003){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_BAS_TO_JAPAN_DATE_CONVERT('1', STR_TO_DATE(SUBSTR(:f_jubsu_date, 1, 10),'%Y-%m-%d'),:f_hosp_code,:f_language)  JUBSU_DATE_WAREKI ");
		sql.append("     , FN_BAS_TO_JAPAN_DATE_CONVERT('1', STR_TO_DATE(SUBSTR(:f_act_date, 1, 10),'%Y-%m-%d'),:f_hosp_code, :f_language)   ACT_DATE_WAREKI   ");
		sql.append("     , IFNULL(FN_DRG_LOAD_DONBOK_YN(:f_bogyong_code,:f_hosp_code), 'N')                          DONBOK_YN         						   ");
		sql.append("     , FN_DRG_LOAD_DRG0120_PATTERN('O', :f_fkocs1003, :f_hosp_code)                              PATTERN                                   ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_jubsu_date", jubsuDate);
		query.setParameter("f_act_date", actDate);
		query.setParameter("f_bogyong_code", bogyongCode);
		query.setParameter("f_fkocs1003", fkocs1003);
		
		DrgsDRG5100P01BongtuInfo result = new JpaResultMapper().uniqueResult(query, DrgsDRG5100P01BongtuInfo.class);
		return result;
	}
	
	//TODO
	@Override
	public List<String> getBogyongNameOcsaOCS0208U00CommonData(String hospCode, String bogyongCode){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_OCS_LOAD_BOGYONG_NAME(A.BOGYONG_CODE, :f_hosp_code) BOGYONG_NAME  ");
		sql.append("  FROM DRG0120 A                                                            ");
		sql.append(" WHERE A.BOGYONG_CODE = :f_code                                             ");
		sql.append("	  AND A.HOSP_CODE = :f_hosp_code								        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", bogyongCode);
		
		List<String> list = query.getResultList();
		return list;
	}
	
	@Override
	//@Cacheable(value="Drg0120Repository")
	public List<DRG0120U00GrdDrg0120ItemInfo> getDRG0120U00GrdDrg0120ItemInfo(String hospCode, String bunryu1, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT BOGYONG_CODE                                              ");
		sql.append("      ,BOGYONG_NAME                                              ");
		sql.append("      ,PATTERN                                                   ");
		sql.append("      ,BOGYONG_GUBUN                                             ");
		sql.append("      ,DRG_GRP                                                   ");
		sql.append("      ,BOGYONG_NAME_2                                            ");
		sql.append("      ,BOGYONG_GUBUN_DEFAULT                                     ");
		sql.append("      ,PRT_GUBUN                                                 ");
		sql.append("      ,BUNRYU1                                                   ");
		sql.append("      ,BOGYONG_CODE_FULL                                         ");
		sql.append("      ,SP_BOGYONG_YN                                             ");
		sql.append("      ,BLOCK_GUBUN                                               ");
		sql.append("      ,BANGHYANG                                                 ");
		sql.append("      ,CHIRYO_GUBUN                                              ");
		sql.append("      ,DONBOG_YN                                                 ");
		sql.append("      ,SUBSTR(PATTERN, 2,1)  PATTERN1                            ");
		sql.append("      ,SUBSTR(PATTERN, 3,1)  PATTERN2                            ");
		sql.append("      ,SUBSTR(PATTERN, 4,1)  PATTERN3                            ");
		sql.append("      ,SUBSTR(PATTERN, 5,1)  PATTERN4                            ");
		sql.append("      ,SUBSTR(PATTERN, 6,1)  PATTERN5                            ");
		sql.append("      ,BOGYONG_JO_FLAG                                           ");
		sql.append("      ,BOGYONG_JU_FLAG                                           ");
		sql.append("      ,BOGYONG_SEOK_FLAG                                         ");
		sql.append("      ,BOGYONG_TIME1_FLAG                                        ");
		sql.append("      ,BOGYONG_TIME2_FLAG                                        ");
		sql.append("      ,BOGYONG_TIME3_FLAG                                        ");
		sql.append("      ,BOGYONG_TIME4_FLAG                                        ");
		sql.append("      ,BOGYONG_TIME5_FLAG                                        ");
		sql.append("      ,BOGYONG_TIME6_FLAG                                        ");
		sql.append("      ,BOGYONG_TIME7_FLAG                                        ");
		sql.append("  FROM DRG0120                                                   ");
		sql.append(" WHERE BUNRYU1      = CASE :f_bunryu1 WHEN '0' THEN '1'          ");
		sql.append("                                      WHEN '1' THEN '6'          ");
		sql.append("                      END                                        ");
		sql.append("	AND LANGUAGE = :f_language									 ");
		sql.append("	AND HOSP_CODE = :f_hosp_code								 ");
		sql.append("  ORDER BY BOGYONG_CODE                                          ");
		 
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_bunryu1", bunryu1);
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		
		List<DRG0120U00GrdDrg0120ItemInfo> result = new JpaResultMapper().list(query, DRG0120U00GrdDrg0120ItemInfo.class);
		return result;
	}
	
	@Override
	public List<DRG0120U00Grd0120Item2Info> getDRG0120U00Grd0120Item2Info(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_INV_LOAD_CODE_NAME('UA', BUNRYU1, 'A', :f_hosp_code)   BUNRYU1_NAME    ");
		sql.append("      ,BOGYONG_CODE                                                              ");
		sql.append("      ,BOGYONG_NAME                                                              ");
		sql.append("      ,BOGYONG_GUBUN                               DV                            ");
		sql.append("      ,FN_INV_LOAD_CODE_NAME('35', BANGHYANG, 'A', :f_hosp_code) BOGYONG_GUBUN   ");
		sql.append("      ,IF(IFNULL(DONBOG_YN,'N')='Y','Y','N')      DONBOG_YN                      ");
		sql.append("      ,IF(SUBSTR(PATTERN, 2,1) = 1,'Y','N')      AF_WAKE                         ");
		sql.append("      ,IF(SUBSTR(PATTERN, 3,1) = 1,'Y','N')      MORNING                         ");
		sql.append("      ,IF(SUBSTR(PATTERN, 4,1) = 1,'Y','N')      AFTERNOON                       ");
		sql.append("      ,IF(SUBSTR(PATTERN, 5,1) = 1,'Y','N')      EVENING                         ");
		sql.append("      ,IF(SUBSTR(PATTERN, 6,1) = 1,'Y','N')      NIGHT                           ");
		sql.append("  FROM DRG0120                                                                   ");
		sql.append(" WHERE BUNRYU1       = '1'                                                       ");
		sql.append("   AND LANGUAGE 	 = :f_language												 ");
		sql.append("   AND HOSP_CODE 	 = :f_hosp_code												 ");
		sql.append(" ORDER BY BOGYONG_CODE                                                           ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<DRG0120U00Grd0120Item2Info> result = new JpaResultMapper().list(query, DRG0120U00Grd0120Item2Info.class);
		return result;
	}
	
	@Override
	public List<DRG0120U00Grd0120Item3Info> getDRG0120U00Grd0120Item3Info(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT FN_INV_LOAD_CODE_NAME('UA', BUNRYU1, 'A', :f_hosp_code)     BUNRYU1_NAME   ");
		sql.append("      ,BOGYONG_CODE                                                               ");
		sql.append("      ,BOGYONG_NAME                                                               ");
		sql.append("      ,BOGYONG_GUBUN                                  DV                          ");
		sql.append("      ,FN_INV_LOAD_CODE_NAME('33', BANGHYANG   , 'A', :f_hosp_code) BANGHYANG     ");
		sql.append("      ,FN_INV_LOAD_CODE_NAME('32', BLOCK_GUBUN , 'A', :f_hosp_code) BUWI          ");
		sql.append("      ,FN_INV_LOAD_CODE_NAME('34', CHIRYO_GUBUN, 'A', :f_hosp_code) CHIRYO        ");
		sql.append("  FROM DRG0120                                                                    ");
		sql.append(" WHERE BUNRYU1       = '6'                                                        ");
		sql.append("   AND LANGUAGE 	 = :f_language												  ");
		sql.append("   AND HOSP_CODE 	 = :f_hosp_code 											  ");
		sql.append(" ORDER BY BOGYONG_CODE                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<DRG0120U00Grd0120Item3Info> result = new JpaResultMapper().list(query, DRG0120U00Grd0120Item3Info.class);
		return result;
	}

	@Override
	//@Cacheable(value="Drg0120Repository")
	public List<OBGetBogyongByDvItemInfo> getOBGetBogyongByDvItemInfo(String hospCode, String bogyongCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BOGYONG_GUBUN, A.BANGHYANG        ");
		sql.append("  FROM DRG0120 A                            ");
		sql.append(" WHERE A.BOGYONG_CODE = :f_aBogyongCode     ");
		sql.append("   AND A.LANGUAGE = :f_language				");
		sql.append("   AND A.HOSP_CODE = :f_hosp_code	        ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_aBogyongCode", bogyongCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		
		List<OBGetBogyongByDvItemInfo> result = new JpaResultMapper().list(query, OBGetBogyongByDvItemInfo.class);
		return result;
	}

	@Override
	//@Cacheable(value="Drg0120Repository")
	public String getLoadColumnCodeNameBogyongCodeCase(String code, String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.BOGYONG_NAME 				");
		sql.append("	 FROM DRG0120 A                     ");
		sql.append("	WHERE A.BOGYONG_CODE  = :code      	");
		sql.append("	  AND A.LANGUAGE = :f_language		");
		sql.append("	  AND A.HOSP_CODE = :f_hosp_code	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("code", code);
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		
		List<Object> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list) && list.get(0) != null){
			return list.get(0).toString();
		}
		return null;
	}

	@Override
	//@Cacheable(value="Drg0120Repository")
	public List<ComboListItemInfo> getOcsLibBogyongInfo3(String bogyongCode, String hospCode, String bogyongGubun, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.BOGYONG_NAME, IFNULL(A.BOGYONG_GUBUN,'99')  	");
		sql.append("	 FROM DRG0120 A                                      	");
		sql.append("	WHERE A.BOGYONG_CODE = :bogyongCode                  	");
		sql.append("	  AND A.BUNRYU1      = :bogyongGubun                	");
		sql.append("	  AND A.LANGUAGE      = :f_language                		");
		sql.append("	  AND A.HOSP_CODE     = :f_hosp_code                	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("bogyongCode", bogyongCode);
		query.setParameter("bogyongGubun", bogyongGubun);
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		
		List<ComboListItemInfo> result = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return result;
	}

	@Override
	//@Cacheable(value="Drg0120Repository")
	public List<OCS0208Q00LayBanghyangInfo> getOCS0208Q00LayBanghyangInfo(String hospCode, String bogyongCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BANGHYANG, IFNULL(A.DONBOG_YN, 'N') DONBOG_YN     	");
		sql.append(" FROM DRG0120 A WHERE   A.BOGYONG_CODE = :f_bogyong_code     	");
		sql.append(" 				  AND A.LANGUAGE      = :f_language				");
		sql.append(" 				  AND A.HOSP_CODE     = :f_hosp_code			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_bogyong_code", bogyongCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		
		List<OCS0208Q00LayBanghyangInfo> result = new JpaResultMapper().list(query, OCS0208Q00LayBanghyangInfo.class);
		return result;
	}

	@Override
	public List<ComboListItemInfo> getOCS0208Q01GrdChiryoGubun(String hospCode, String language, String bogyongGubun, String jaeryoCode, String useYn) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT A.CODE                                                                    " );
		sql.append("      , A.CODE_NAME                                                                        " );
		sql.append("   FROM (                                                                                  " );
		sql.append("          SELECT DISTINCT                                                                  " );
		sql.append("                 A.CODE        CODE                                                        " );
		sql.append("                ,A.CODE_NAME   CODE_NAME                                                   " );
		sql.append("            FROM DRG0120 B,INV0102 A                                                       " );
		sql.append("           WHERE A.CODE_TYPE    = '34'  AND A.LANGUAGE = :language                         " );
		sql.append("             AND A.CODE2        = 'A'                                                      " );
		sql.append("             AND A.HOSP_CODE    = :f_hosp_code                                             " );
		sql.append("             AND B.HOSP_CODE    = :f_hosp_code                                             " );
		sql.append("             AND B.CHIRYO_GUBUN = A.CODE                                                   " );
		sql.append("             AND B.LANGUAGE = :language	                                                   " );
		sql.append("             AND IFNULL(B.BOGYONG_GUBUN,'%') LIKE :f_bogyong_gubun                         " );
		sql.append("             AND (( NOT EXISTS ( SELECT 'X'                                                " );
		sql.append("                                  FROM DRG0120 Z                                           " );
		sql.append("                                     , DRG0123 Y                                           " );
		sql.append("                                     , OCS0103 X                                           " );
		sql.append("                                 WHERE X.HANGMOG_CODE = :f_jaeryo_code                     " );
		sql.append("                                   AND X.HOSP_CODE    = :f_hosp_code                       " );
		sql.append("                                   AND Z.HOSP_CODE    = :f_hosp_code                       " );
		sql.append("                                   AND X.JAERYO_CODE  = Y.JAERYO_CODE                      " );
		sql.append("                                   AND X.HOSP_CODE    = Y.HOSP_CODE                        " );
		sql.append("                                   AND Y.CODE_TYPE    = '34'                               " );
		sql.append("                                   AND Y.CODE         = Z.CHIRYO_GUBUN                     " );
		sql.append("                                   AND Y.HOSP_CODE    = :f_hosp_code )                     " );
		sql.append("                                     )OR                                                   " );
		sql.append("                   :f_use_yn = 'N' )                                                       " );
		sql.append("      ) A                                                                                  " );
		sql.append("  UNION ALL                                                                                " );
		sql.append(" SELECT DISTINCT                                                                           " );
		sql.append("        C.CODE        CODE                                                                 " );
		sql.append("       ,C.CODE_NAME   CODE_NAME                                                            " );
		sql.append("   FROM DRG0120 D,INV0102 C ,DRG0123 B ,OCS0103 A                                          " );
		sql.append("  WHERE A.HANGMOG_CODE  = :f_jaeryo_code                                                   " );
		sql.append("    AND A.HOSP_CODE     = :f_hosp_code                                                     " );
		sql.append("    AND D.HOSP_CODE     = :f_hosp_code                                                     " );
		sql.append("    AND A.JAERYO_CODE   = B.JAERYO_CODE                                                    " );
		sql.append("    AND A.HOSP_CODE     = B.HOSP_CODE                                                      " );
		sql.append("    AND B.CODE_TYPE     = '34'                                                             " );
		sql.append("    AND B.CODE_TYPE     = C.CODE_TYPE                                                      " );
		sql.append("    AND B.CODE          = C.CODE                                                           " );
		sql.append("    AND B.HOSP_CODE     = C.HOSP_CODE                                                      " );
		sql.append("    AND D.CHIRYO_GUBUN  = B.CODE                                                           " );
		sql.append("    AND B.HOSP_CODE      = :f_hosp_code                                                    " );
		sql.append("    AND IFNULL(D.BOGYONG_GUBUN,'%') LIKE :f_bogyong_gubun                                  " );
		sql.append("    AND :f_use_yn       = 'Y'  AND C.LANGUAGE = :language                                  " );
		sql.append("	AND D.LANGUAGE = :language															   " );
		sql.append("  ORDER BY 1																			   " );
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bogyong_gubun", bogyongGubun);
		query.setParameter("f_jaeryo_code", jaeryoCode);
		query.setParameter("f_use_yn", useYn);
		query.setParameter("language", language);
		
		List<ComboListItemInfo> result = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return result;
	}

	@Override
	public List<OCS0208Q01GrdDrg0120Info> getOCS0208Q01GrdDrg0120Info(String hospCode, String language, String chiryoGubun, String banghyang,
			String fJaeryoCode, String useYn, String oJaeryoCode,String bogyongGubun) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT DISTINCT Y.BOGYONG_CODE                           BOGYONG_CODE                              ");
		sql.append("      , Y.BOGYONG_NAME                                    BOGYONG_NAME                              ");
		sql.append("      ,case Z.CODE when  '10' then Y.BOGYONG_NAME else Z.CODE_NAME end BLOCK_GUBUN                  ");
		sql.append("      , FN_DRG_LOAD_DRG0102(:f_hosp_code, :language, Y.BOGYONG_GUBUN, '31')        BOGYONG_GUBUN    ");
		sql.append("   FROM INV0102 Z                                                                                   ");
		sql.append("      , DRG0120 Y                                                                                   ");
		sql.append("  WHERE Y.CHIRYO_GUBUN       = :f_chiryo_gubun  AND Z.LANGUAGE = :language                          ");
		sql.append("    AND IFNULL(Y.BANGHYANG,'4') = IFNULL(:f_banghyang,'4')                                          ");
		sql.append("	AND Y.LANGUAGE = :language																		");
		sql.append("    AND Z.CODE_TYPE          = '32'                                                                 ");
		sql.append("    AND Z.CODE               = Y.BLOCK_GUBUN                                                        ");
		sql.append("    AND Z.HOSP_CODE          = :f_hosp_code                                                         ");
		sql.append("    AND Y.HOSP_CODE          = :f_hosp_code                                                         ");
		sql.append("    AND Z.CODE2              = 'A'                                                                  ");
		sql.append("    AND ( NOT EXISTS ( SELECT 'X'                                                                   ");
		sql.append("                         FROM DRG0120 ZZ                                                            ");
		sql.append("                            , DRG0123 YY                                                            ");
		sql.append("                            , OCS0103 XX                                                            ");
		sql.append("                        WHERE XX.HANGMOG_CODE = :f_jaeryo_code                                      ");
		sql.append("                          AND XX.HOSP_CODE    = :f_hosp_code                                        ");
		sql.append("                          AND XX.JAERYO_CODE  = YY.JAERYO_CODE                                      ");
		sql.append("                          AND XX.HOSP_CODE    = YY.HOSP_CODE                                        ");
		sql.append("                          AND YY.CODE_TYPE    = '32'                                                ");
		sql.append("                          AND YY.CODE         = ZZ.BLOCK_GUBUN                                      ");
		sql.append("						  AND ZZ.LANGUAGE	  = :language										    ");
		sql.append("                          AND ZZ.HOSP_CODE    = :f_hosp_code                                        ");
		sql.append("                          AND ZZ.CHIRYO_GUBUN = :f_chiryo_gubun ) OR                                ");
		sql.append("          :f_use_yn      = 'N' )                                                                    ");
		sql.append("  UNION ALL                                                                                         ");
		sql.append(" SELECT DISTINCT                                                                                    ");
		sql.append("        C.BOGYONG_CODE                                                                              ");
		sql.append("       ,C.BOGYONG_NAME                                                                              ");
		sql.append("       ,case B.CODE when '10' then C.BOGYONG_NAME else B.CODE_NAME end    BLOCK_GUBUN               ");
		sql.append("       ,FN_DRG_LOAD_DRG0102(:f_hosp_code, :language, C.BOGYONG_GUBUN, '31')                         ");
		sql.append("   FROM DRG0120 C,INV0102 B,DRG0123 A                                                               ");
		sql.append("  WHERE A.JAERYO_CODE  = :o_jaeryo_code                                                             ");
		sql.append("    AND A.HOSP_CODE    = :f_hosp_code                                                               ");
		sql.append("    AND C.HOSP_CODE    = :f_hosp_code                                                               ");
		sql.append("    AND A.CODE_TYPE    = '32'                                                                       ");
		sql.append("    AND B.CODE_TYPE    = A.CODE_TYPE                                                                ");
		sql.append("    AND B.CODE         = A.CODE                                                                     ");
		sql.append("    AND B.CODE2        = 'A'                                                                        ");
		sql.append("    AND B.HOSP_CODE    = A.HOSP_CODE  AND B.LANGUAGE = :language                                    ");
		sql.append("    AND C.CHIRYO_GUBUN        = :f_chiryo_gubun                                                     ");
		sql.append("    AND IFNULL(C.BANGHYANG, '4') = IFNULL(:f_banghyang,'4')                                         ");
		sql.append("    AND C.BLOCK_GUBUN  = A.CODE                                                                     ");
		sql.append("    AND C.LANGUAGE     = :language																	");
		sql.append("    AND :f_hosp_code    = A.HOSP_CODE                                                               ");
		sql.append("    AND IFNULL(C.BOGYONG_GUBUN,'%') LIKE :f_bogyong_gubun                                           ");
		sql.append("    AND :f_use_yn             = 'Y'                                                                 ");
		sql.append("    AND NOT EXISTS ( SELECT 'X'                                                                     ");
		sql.append("                       FROM DRG0122 Z                                                               ");
		sql.append("                      WHERE Z.JAERYO_CODE  = A.JAERYO_CODE                                          ");
		sql.append("                        AND Z.BOGYONG_CODE = C.BOGYONG_CODE                                         ");
		sql.append("                        AND Z.HOSP_CODE    = A.HOSP_CODE )                                          ");
		sql.append("  ORDER BY 1																						");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("f_chiryo_gubun", chiryoGubun);
		query.setParameter("f_banghyang", banghyang);
		query.setParameter("f_jaeryo_code", fJaeryoCode);
		query.setParameter("f_use_yn", useYn);
		query.setParameter("o_jaeryo_code", oJaeryoCode);
		query.setParameter("f_bogyong_gubun", bogyongGubun);
		List<OCS0208Q01GrdDrg0120Info> result = new JpaResultMapper().list(query, OCS0208Q01GrdDrg0120Info.class);
		return result;
	}
	
	@Override
	//@Cacheable(value="Drg0120Repository")
	public List<DRG0120U00GrdDrg0120Item1Info> getDRG0120U00GrdDrg0120Item1ListItem(String hospCode, String bunryu, String language) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT BOGYONG_CODE														");
		sql.append("	      ,BOGYONG_NAME                                                   "  );
		sql.append("	      ,PATTERN                                                        "  );
		sql.append("	      ,BOGYONG_GUBUN                                                  "  );
		sql.append("	      ,DRG_GRP                                                        "  );
		sql.append("	      ,BOGYONG_NAME_2                                                 "  );
		sql.append("	      ,BOGYONG_GUBUN_DEFAULT                                          "  );
		sql.append("	      ,PRT_GUBUN                                                      "  );
		sql.append("	      ,BUNRYU1                                                        "  );
		sql.append("	      ,BOGYONG_CODE_FULL                                              "  );
		sql.append("	      ,SP_BOGYONG_YN                                                  "  );
		sql.append("	      ,BLOCK_GUBUN                                                    "  );
		sql.append("	      ,BANGHYANG                                                      "  );
		sql.append("	      ,CHIRYO_GUBUN                                                   "  );
		sql.append("	      ,DONBOG_YN                                                      "  );
		sql.append("	      ,SUBSTR(PATTERN, 2,1)  PATTERN1                                 "  );
		sql.append("	      ,SUBSTR(PATTERN, 3,1)  PATTERN2                                 "  );
		sql.append("	      ,SUBSTR(PATTERN, 4,1)  PATTERN3                                 "  );
		sql.append("	      ,SUBSTR(PATTERN, 5,1)  PATTERN4                                 "  );
		sql.append("	      ,SUBSTR(PATTERN, 6,1)  PATTERN5                                 "  );
		sql.append("	  FROM DRG0120                                                        "  );
		sql.append("	 WHERE BUNRYU1      = CASE :f_bunryu1 WHEN '0' THEN '1'               "  );
		sql.append("	                                      WHEN '1' THEN '6'               "  );
		sql.append("	                      END                                             "  );
		sql.append("	   AND LANGUAGE    = :f_language	                                  "  );
		sql.append("	   AND HOSP_CODE    = :f_hosp_code	                                  "  );
		sql.append("	  ORDER BY BOGYONG_CODE                                               "  );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_bunryu1", bunryu);
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		
		List<DRG0120U00GrdDrg0120Item1Info> result = new JpaResultMapper().list(query, DRG0120U00GrdDrg0120Item1Info.class);
		return result;
	}

	@Override
	//@Cacheable(value="Drg0120Repository")
	public String getBogyongName(String hospCode, String bogyongCode,boolean isEqual6, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BOGYONG_NAME                  ");
		sql.append("  FROM DRG0120 A                        ");
		sql.append("  WHERE 1=1      						");
		if(isEqual6){
			sql.append(" AND BUNRYU1       = '6'            ");
		}else{
			sql.append("  AND BUNRYU1<> '6'                 ");
		}
		
		sql.append("   AND BOGYONG_CODE= :f_code            ");
		sql.append("   AND LANGUAGE= :f_language            ");
		sql.append("   AND A.HOSP_CODE    = :f_hosp_code    ");
		sql.append("  ORDER BY A.BOGYONG_CODE				");
		Query query = entityManager.createNativeQuery(sql.toString());

		query.setParameter("f_code", bogyongCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)){
			return list.get(0);
		}
		
		return null;
	}

	@Override
	//@Cacheable(value="Drg0120Repository")
	public List<ComboListItemInfo> getOCS0103U00ComboListItemInfo(String hospCode, boolean isEqual6, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BOGYONG_CODE, A.BOGYONG_NAME  ");
		sql.append("    FROM DRG0120 A                      ");
		sql.append("   WHERE 1=1                            ");
		if(isEqual6){
			sql.append(" AND BUNRYU1       = '6'            ");
		}else{
			sql.append("     AND BUNRYU1 <> '6'             ");
		}
		
		sql.append("	AND LANGUAGE= :f_language           ");
		sql.append("    AND A.HOSP_CODE    = :f_hosp_code   ");
		sql.append("   ORDER BY A.BOGYONG_CODE				");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		
		List<ComboListItemInfo> result = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return result;
	}

	@Override
	//@Cacheable(value="Drg0120Repository")
	public List<CFFormUnevenPrescribeLayDRG0120Info> getCFFormUnevenPrescribeLayDRG0120(String hospCode, String bogyongCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append("  SELECT A.BOGYONG_CODE                   ");
		sql.append("        ,A.BOGYONG_NAME                   ");
		sql.append("        ,A.PATTERN                        ");
		sql.append("        ,A.BOGYONG_GUBUN                  ");
		sql.append("        ,A.BOGYONG_JO_FLAG                ");
		sql.append("        ,A.BOGYONG_JU_FLAG                ");
		sql.append("        ,A.BOGYONG_SEOK_FLAG              ");
		sql.append("        ,A.BOGYONG_TIME1_FLAG             ");
		sql.append("        ,A.BOGYONG_TIME2_FLAG             ");
		sql.append("        ,A.BOGYONG_TIME3_FLAG             ");
		sql.append("        ,A.BOGYONG_TIME4_FLAG             ");
		sql.append("        ,A.BOGYONG_TIME5_FLAG             ");
		sql.append("        ,A.BOGYONG_TIME6_FLAG             ");
		sql.append("        ,A.BOGYONG_TIME7_FLAG             ");
		sql.append("   FROM DRG0120 A                         ");
		sql.append("  WHERE A.LANGUAGE     = :f_language	  ");
		sql.append("    AND A.BOGYONG_CODE = :f_bogyong_code  ");
		sql.append("    AND A.HOSP_CODE    = :f_hosp_code     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_bogyong_code", bogyongCode);
		query.setParameter("f_language", language);
		query.setParameter("f_hosp_code", hospCode);
		
		List<CFFormUnevenPrescribeLayDRG0120Info> result = new JpaResultMapper().list(query, CFFormUnevenPrescribeLayDRG0120Info.class);
		return result;
	}

	@Override
	public List<OCS2015U00DosageInfo> getOcs2015U00DosageInfo(String hospCode, String patientCode, String language) {
		StringBuilder sql = new StringBuilder();
		 sql.append("SELECT   A.FKOUT1001 as neawon_key                                             ");
		 sql.append("        ,CONCAT(A.INPUT_TAB,'-',A.GROUP_SER) as InputTabAndGroupSer            ");
		 sql.append("        ,B.BOGYONG_NAME														");
		 sql.append("FROM OCS1003 A LEFT JOIN DRG0120 B ON  A.BOGYONG_CODE = B.BOGYONG_CODE         ");
		 sql.append("WHERE  A.HOSP_CODE = :f_hosp_code                            		            ");
		 sql.append("   AND A.BUNHO = :f_patient_code                                               ");
		 sql.append("   AND B.LANGUAGE = :f_language            								    ");
		 sql.append("GROUP BY CONCAT(A.INPUT_TAB,'-',A.GROUP_SER)                            		");
		 sql.append("ORDER BY A.FKOUT1001 ASC                            		                    ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_patient_code", patientCode);
		query.setParameter("f_language", language);
		
		List<OCS2015U00DosageInfo> result = new JpaResultMapper().list(query, OCS2015U00DosageInfo.class);
		return result;
	}

	@Override
	public List<Drg0120> findByHospCodeLanguage(String hospCode, String language){
		String sqlQuery = "SELECT drg FROM Drg0120 drg WHERE hospCode = :f_hosp_code AND language = :f_language";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		return query.getResultList();
	}

	@Override
	public String callFnDrgLoadBogyongName(String hospCode, String bogyongCode) {
		String sql = "SELECT  FN_DRG_LOAD_BOGYONG_NAME (:bogyong_code, :hosp_code) ";
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("bogyong_code", bogyongCode);
		
		List<String> list = query.getResultList();
		return StringUtils.isEmpty(list) ? ""  : list.get(0);
	}

	@Override
	public String callFnDrgLoadBogyongJusaName(String hospCode, String language, String orderGubun, String code) {
		String sql = "SELECT  FN_DRG_LOAD_BOGYONG_JUSA_NAME(:order_gubun,:code, :hosp_code, :language) ";
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("order_gubun", orderGubun);
		query.setParameter("code", code);
		
		List<String> list = query.getResultList();
		return StringUtils.isEmpty(list) ? ""  : list.get(0);
	}

	@Override
	public List<ComboListItemInfo> getOCS2005U00fwkCombo(String hospCode, String find1) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	 SELECT A.BOGYONG_CODE,									");
		sql.append("	        A.BOGYONG_NAME									");
		sql.append("	   FROM DRG0120 A										");
		sql.append("	   WHERE A.HOSP_CODE = :f_hosp_code						");
		sql.append("	    AND (A.BOGYONG_CODE LIKE CONCAT('%', :f_find1, '%')	");
		sql.append("	     OR A.BOGYONG_NAME LIKE CONCAT('%', :f_find1, '%'))	");
		sql.append("	   ORDER BY 1, 2										");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_find1", find1);
		
		List<ComboListItemInfo> result = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return result;
	}

	@Override
	public List<ComboListItemInfo> getNUR0110U00SetFindWorkerCombo(String hospCode, String language, String find1, boolean bunryu1Eq6) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.BOGYONG_CODE,                                 ");
		sql.append("	       A.BOGYONG_NAME                                  ");
		sql.append("	  FROM DRG0120 A                                       ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                      ");
		sql.append("	   AND A.LANGUAGE = :f_language                        ");
		sql.append("	   AND (A.BOGYONG_CODE LIKE CONCAT('%', :f_find1, '%') ");
		sql.append("	    OR A.BOGYONG_NAME LIKE CONCAT('%', :f_find1, '%')) ");
		if(bunryu1Eq6){
			sql.append("	  AND A.BUNRYU1 = 6                                ");
		} else {
			sql.append("	  AND A.BUNRYU1 <> 6                               ");
		}
		
		sql.append("	 ORDER BY A.BOGYONG_CODE, A.BOGYONG_NAME               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_find1", find1);
		
		List<ComboListItemInfo> result = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return result;
	}
	
}

