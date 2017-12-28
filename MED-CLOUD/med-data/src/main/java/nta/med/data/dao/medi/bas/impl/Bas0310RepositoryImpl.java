package nta.med.data.dao.medi.bas.impl;

import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.domain.bas.Bas0310;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.bas.Bas0310Repository;
import nta.med.data.model.ihis.adma.BAS0310U00GrdListInfo;
import nta.med.data.model.ihis.bass.BAS0311Q01GrdBAS0311Info;
import nta.med.data.model.ihis.bass.BAS0311U00GridListItemInfo;
import nta.med.data.model.ihis.bass.ComBizGetFindWorkerInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U00LayCommonInfo;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
@Repository("bas0310Repository")
public class Bas0310RepositoryImpl extends SimpleJpaRepository<Bas0310, Long> implements Bas0310Repository {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Bas0310RepositoryImpl(EntityManager entityManager) {
		super(Bas0310.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Bas0310Repository", allEntries = true)
	public Bas0310 save(Bas0310 entity) {
		return super.save(entity);
	}
	
	@CacheEvict(value = "Bas0310Repository", allEntries = true)
	public List<Bas0310> save(List<Bas0310> entity) {
		return super.save(entity);
	}
	
	@CacheEvict(value = "Bas0310Repository", allEntries = true)
	@Override
	public void delete(Bas0310 entity) {
		super.delete(entity);
	}
	
	@CacheEvict(value = "Bas0310Repository", allEntries = true)
	public Integer deleteBAS0310WhereHospSgCodeYmd(
			String hospCode,
			String sgCode, 
			Date sgYmd){
		String sql = "DELETE FROM Bas0310	WHERE hospCode = :f_hosp_code AND sgCode = :f_sg_code AND sgYmd = :f_sg_ymd	";
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_sg_code", sgCode); 
		query.setParameter("f_sg_ymd", sgYmd);
		return query.executeUpdate();
	}
	
	@CacheEvict(value = "Bas0310Repository", allEntries = true)
	public Integer updateBAS0310WhereHospSgCodeYmd(
			String updId,
			Date updDate,
			String sgName,
			String sgNameKana,
			Date bulyongYmd,
			String sgUnion,
			String groupGubun,
			String bunCode,
			String marumeGubun,
			String hubalDrgYn,
			String danui,
			String sunabQcodeOut,
			String sunabQcodeInp,
			String sugaChange,
			String bulyongSayu,
			String remark,
			String taxYn,
			String modifyFlg,
			String hospCode,
			String sgCode,
			Date sgYmd,
			String privateFeeYn){
		String sql = "	UPDATE Bas0310	"
				+"	SET updId = :f_user_id	"
				+"	, updDate = :f_upd_date	"
				+"	, sgName = :f_sg_name	"
				+"	, sgNameKana = :f_sg_name_kana	"
				+"	, bulyongYmd = :f_bulyong_ymd	"
				+"	, sgUnion = :f_sg_union 	"
				+"	, groupGubun = :f_group_gubun	"
				+"	, bunCode = :f_bun_code	"
				+"	, marumeGubun = :f_marume_gubun	"
				+"	, hubalDrgYn = :f_hubal_drg_yn	"
				+"	, danui = :f_danui	"
				+"	, sunabQcodeOut = :f_sunab_qcode_out 	"
				+"	, sunabQcodeInp = :f_sunab_qcode_inp	"
				+"	, sugaChange = :f_suga_change	"
				+"	, bulyongSayu = :f_bulyong_sayu	"
				+"	, remark = :f_remark	"
				+"	, taxYn = :f_tax_yn	"
				+"	, modifyFlg = :modifyFlg	"
				+"	, privateFeeYn = :privateFeeYn	"
				+"	WHERE hospCode = :f_hosp_code 	"
				+"	AND sgCode = :f_sg_code	"
				+"	AND sgYmd = :f_sg_ymd	";
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_user_id", updId);
		query.setParameter("f_upd_date", updDate);
		query.setParameter("f_sg_name", sgName);
		query.setParameter("f_sg_name_kana", sgNameKana);
		query.setParameter("f_bulyong_ymd", bulyongYmd);
		query.setParameter("f_sg_union", sgUnion);
		query.setParameter("f_group_gubun", groupGubun);
		query.setParameter("f_bun_code", bunCode);
		query.setParameter("f_marume_gubun", marumeGubun);
		query.setParameter("f_hubal_drg_yn", hubalDrgYn);
		query.setParameter("f_danui", danui);
		query.setParameter("f_sunab_qcode_out", sunabQcodeOut);
		query.setParameter("f_sunab_qcode_inp", sunabQcodeInp);
		query.setParameter("f_suga_change", sugaChange);
		query.setParameter("f_bulyong_sayu", bulyongSayu);
		query.setParameter("f_remark", remark);
		query.setParameter("f_tax_yn", taxYn);
		query.setParameter("modifyFlg", modifyFlg);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_sg_code", sgCode);
		query.setParameter("f_sg_ymd", sgYmd);
		query.setParameter("privateFeeYn", privateFeeYn);
		return query.executeUpdate();
	}
	
	@CacheEvict(value = "Bas0310Repository", allEntries = true)
	public Integer updateBAS0310WhereHospSgCodeYmdIgnoreModifyFlg(
			String updId,
			Date updDate,
			String sgName,
			String sgNameKana,
			Date bulyongYmd,
			String sgUnion,
			String groupGubun,
			String bunCode,
			String marumeGubun,
			String hubalDrgYn,
			String danui,
			String sunabQcodeOut,
			String sunabQcodeInp,
			String sugaChange,
			String bulyongSayu,
			String remark,
			String taxYn,
			String hospCode,
			String sgCode,
			Date sgYmd,
			String privateFeeYn){
		String sql = "	UPDATE Bas0310	"
				+"	SET updId = :f_user_id	"
				+"	, updDate = :f_upd_date	"
				+"	, sgName = :f_sg_name	"
				+"	, sgNameKana = :f_sg_name_kana	"
				+"	, bulyongYmd = :f_bulyong_ymd	"
				+"	, sgUnion = :f_sg_union 	"
				+"	, groupGubun = :f_group_gubun	"
				+"	, bunCode = :f_bun_code	"
				+"	, marumeGubun = :f_marume_gubun	"
				+"	, hubalDrgYn = :f_hubal_drg_yn	"
				+"	, danui = :f_danui	"
				+"	, sunabQcodeOut = :f_sunab_qcode_out 	"
				+"	, sunabQcodeInp = :f_sunab_qcode_inp	"
				+"	, sugaChange = :f_suga_change	"
				+"	, bulyongSayu = :f_bulyong_sayu	"
				+"	, remark = :f_remark	"
				+"	, taxYn = :f_tax_yn	"
				+"	, privateFeeYn = :privateFeeYn	"
				+"	WHERE hospCode = :f_hosp_code 	"
				+"	AND sgCode = :f_sg_code	"
				+"	AND sgYmd = :f_sg_ymd	";
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_user_id", updId);
		query.setParameter("f_upd_date", updDate);
		query.setParameter("f_sg_name", sgName);
		query.setParameter("f_sg_name_kana", sgNameKana);
		query.setParameter("f_bulyong_ymd", bulyongYmd);
		query.setParameter("f_sg_union", sgUnion);
		query.setParameter("f_group_gubun", groupGubun);
		query.setParameter("f_bun_code", bunCode);
		query.setParameter("f_marume_gubun", marumeGubun);
		query.setParameter("f_hubal_drg_yn", hubalDrgYn);
		query.setParameter("f_danui", danui);
		query.setParameter("f_sunab_qcode_out", sunabQcodeOut);
		query.setParameter("f_sunab_qcode_inp", sunabQcodeInp);
		query.setParameter("f_suga_change", sugaChange);
		query.setParameter("f_bulyong_sayu", bulyongSayu);
		query.setParameter("f_remark", remark);
		query.setParameter("f_tax_yn", taxYn);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_sg_code", sgCode);
		query.setParameter("f_sg_ymd", sgYmd);
		query.setParameter("privateFeeYn", privateFeeYn);
		return query.executeUpdate();
	}
	
	@CacheEvict(value = "Bas0310Repository", allEntries = true)
	public Integer updateBAS0310WhereHospSgCodeYmd2(
			Date updDate,
			String updId,
			Date bulyongYmd,
			String modifyFlg,
			String hospCode,
			String sgCode,
			Date sgYmd,
			String privateFeeYn){
		String sql = "	UPDATE Bas0310	"
				+"	SET updDate = :f_sys_date	"
				+"	, updId = :f_user_id	"
				+"	, bulyongYmd = :f_bulyong_ymd	"
				+"	, modifyFlg = :modifyFlg	"
				+"	, privateFeeYn = :privateFeeYn	"
				+"	WHERE hospCode = :f_hosp_code 	"
				+"	AND sgCode = :f_sg_code	"
				+"	AND sgYmd <= :f_sg_ymd	";
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_sys_date", updDate);
		query.setParameter("f_user_id", updId);
		query.setParameter("f_bulyong_ymd", bulyongYmd);
		query.setParameter("modifyFlg", modifyFlg);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_sg_code", sgCode);
		query.setParameter("f_sg_ymd", sgYmd);
		query.setParameter("privateFeeYn", privateFeeYn);
		return query.executeUpdate();
	}

	@Cacheable(value = "Bas0310Repository")
	public String getYFromBAS0310ItemInfo(String hospCode,
			String sgCode,
			Date sgYmd){
		String sql = "SELECT DISTINCT 'Y' FROM Bas0310 WHERE hospCode = :f_hosp_code AND sgCode = :f_sg_code AND sgYmd = :f_sg_ymd ";
		Query query = entityManager.createQuery(sql);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_sg_code", sgCode);
		query.setParameter("f_sg_ymd", sgYmd);
		List<String> list = query.getResultList();
		if(!CollectionUtils.isEmpty(list)) {
			return list.get(0);
		}
		return null;
	}

	@Override
	@Cacheable(value = "Bas0310Repository")
	public String getLoadColumnCodeNameSgCodeCase(String sgCode, String orderDate, String hospCode) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.SG_NAME																								");
		sql.append("	 FROM BAS0310 A                                                                                                 ");
		sql.append("	WHERE A.SG_CODE     = :sgCode                                                                                   ");
		sql.append("	  AND A.START_DATE <= STR_TO_DATE(IFNULL(TRIM(:orderDate) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')     ");
		sql.append("	  AND A.END_DATE   >= STR_TO_DATE(IFNULL(TRIM(:orderDate) ,DATE_FORMAT(SYSDATE(), '%Y/%m/%d')), '%Y/%m/%d')     ");
		sql.append("	  AND A.HOSP_CODE   = :hospCode                                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("sgCode", sgCode);
		query.setParameter("orderDate", orderDate);
		query.setParameter("hospCode", hospCode);
		
		List<Object> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result) && result.get(0) != null){
			return result.get(0).toString();
		}
		return null;
	}
	
	@Override 
	public List<BAS0310U00GrdListInfo> getBAS0310U00GrdList(String hospCode, String language, String sgCode, String bunCode, Integer startNum, Integer endNum){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.SG_CODE                                                                                                         ");
		sql.append("     , A.GROUP_GUBUN                                                                                                     ");
		sql.append("     , A.SG_NAME                                                                                                         ");
		sql.append("     , A.SG_NAME_KANA                                                                                                    ");
		sql.append("     , CASE A.SG_YMD WHEN '0000-00-00 00:00:00' THEN null ELSE A.SG_YMD  END AS SG_YMD                                   ");
		sql.append("     , A.SUGA_CHANGE                                                                                                     ");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('SUGA_CHANGE',A.SUGA_CHANGE,:f_hosp_code,:f_language)                SUGA_CHANGE_NM_D       ");
		sql.append("     , A.BULYONG_YMD                                                                                                     ");
		sql.append("     , A.BULYONG_SAYU                                                                                                    ");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('BULYONG_SAYU',A.BULYONG_SAYU,:f_hosp_code,:f_language)              BULYONG_SAYU_NM_D      ");
		sql.append("     , IF(A.DANUI = '000', '', A.DANUI)                               DANUI                                              ");
		sql.append("     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.DANUI,:f_hosp_code,:f_language)                       DANUI_NAME             ");
		sql.append("     , A.BUN_CODE                                                                                                        ");
		sql.append("     , FN_BAS_LOAD_BUN_NAME_NEW(:f_hosp_code, :f_language, A.BUN_CODE, A.SG_YMD)                   BUN_CODE_NAME         ");
		sql.append("     , A.MARUME_GUBUN                                                                                                    ");
		sql.append("     , A.SG_UNION                                                                                                        ");
		sql.append("     , A.REMARK                                                                                                          ");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('POGWAL_GUBUN',A.MARUME_GUBUN,:f_hosp_code,:f_language)              MARUME_NAME            ");
		sql.append("     , A.HUBAL_DRG_YN                                                                                                    ");
		sql.append("     , A.SUNAB_QCODE_OUT                                                                                                 ");
		sql.append("     , A.SUNAB_QCODE_INP                                                                                                 ");
		sql.append("     , A.TAX_YN , A.PRIVATE_FEE_YN , A.MODIFY_FLG                                                                        ");
		sql.append("  FROM BAS0310 A                                                                                                         ");
		sql.append(" WHERE A.HOSP_CODE  = :f_hosp_code                                                                                       ");
		sql.append("   AND A.SG_NAME_IND LIKE :f_sg_code                                                                                     ");
		sql.append("   AND A.BUN_CODE LIKE :f_bun_code                                                                                       ");
		sql.append("   AND A.SG_YMD   = ( SELECT MAX(Z.SG_YMD)                                                                               ");
		sql.append("                        FROM BAS0310 Z                                                                                   ");
		sql.append("                       WHERE Z.HOSP_CODE = A.HOSP_CODE                                                                   ");
		sql.append("                         AND Z.SG_CODE   = A.SG_CODE )                                                                   ");
		sql.append(" ORDER BY A.SG_CODE                                                                                                      ");
		sql.append(" LIMIT :startNum, :endNum                                                                                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_sg_code", sgCode);
		query.setParameter("f_bun_code", bunCode + "%");
		query.setParameter("startNum", startNum);
		query.setParameter("endNum", endNum);
		
		List<BAS0310U00GrdListInfo> list = new JpaResultMapper().list(query, BAS0310U00GrdListInfo.class);
		return list;
	}
	
	@Cacheable(value = "Bas0310Repository")
	public List<ComboListItemInfo> getSgCodeNameListItemInfo (String hospCode, String find1){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT SG_CODE								   ");
		sql.append("	    , SG_NAME                                  ");
		sql.append("	FROM BAS0310                                   ");
		sql.append("	WHERE HOSP_CODE = :f_hosp_code                 ");
		sql.append("	AND (  SG_CODE  LIKE CONCAT(:f_find1 , '%')    ");
		sql.append("	      OR SG_NAME  LIKE CONCAT(:f_find1 , '%')) ");
		sql.append("	ORDER BY SG_CODE                               ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_find1", find1);
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public String getOCSACTCommand(String hospCode, String hangmogCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT  count( A.INPUT_CONTROL)                                       " );
		sql.append("     FROM OCS0103 A LEFT JOIN                                          " );
		sql.append("         ( SELECT X.SG_CODE                                            " );
		sql.append("                 , X.SG_NAME                                           " );
		sql.append("                 , X.SG_YMD                                            " );
		sql.append("                 , X.BULYONG_YMD                                       " );
		sql.append("                 , X.BUN_CODE                                          " );
		sql.append("              FROM BAS0310 X                                           " );
		sql.append("             WHERE X.HOSP_CODE = :f_hosp_code                          " );
		sql.append("               AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)                   " );
		sql.append("                                  FROM BAS0310 Z                       " );
		sql.append("                                 WHERE Z.HOSP_CODE = X.HOSP_CODE       " );
		sql.append("                                   AND Z.SG_CODE   = X.SG_CODE         " );
		sql.append("                                   AND Z.SG_YMD   <= SYSDATE() )       " );
		sql.append("          ) D ON D.SG_CODE  = A.SG_CODE                                " );
		sql.append("    WHERE A.HOSP_CODE        = :f_hosp_code                            " );
		sql.append("      AND A.HANGMOG_CODE     = :f_hangmog_code                         " );
		sql.append("      AND IFNULL(A.IF_INPUT_CONTROL, 'C') <> 'P'                       " );
		sql.append("      AND SYSDATE() BETWEEN A.START_DATE  AND A.END_DATE 				");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_hangmog_code", hangmogCode);
		List<BigInteger> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0).toString();
		}
		return null;
	}

	@Override
	@Cacheable(value = "Bas0310Repository")
	public List<OCS0103U00LayCommonInfo> getOCS0103U00LayCommonInfo(String hospCode, Date sysDate,String sgCode, String startDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SG_NAME, A.BULYONG_YMD, A.HUBAL_DRG_YN                                                                                    ");
		sql.append("   FROM BAS0310 A                                                                                                                   ");
		sql.append("  WHERE A.HOSP_CODE = :f_hosp_code                                                                                                  ");
		sql.append("    AND A.SG_CODE = :f_sg_code                                                                                                      ");
		sql.append("    AND A.SG_YMD =( SELECT MAX(Z.SG_YMD)                                                                                            ");
		sql.append("                       FROM BAS0310 Z                                                                                               ");
		sql.append("                      WHERE Z.HOSP_CODE = A.HOSP_CODE                                                                               ");
		sql.append("                        AND Z.SG_YMD <= :sysDate                                                                                 ");
		sql.append("                        AND IFNULL(Z.BULYONG_YMD, STR_TO_DATE('99981231', '%Y%m%d')) > STR_TO_DATE(:f_start_date, '%Y/%m/%d')       ");
		sql.append("                        AND Z.SG_CODE = A.SG_CODE )																					");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_sg_code", sgCode);
		query.setParameter("f_start_date", startDate);
		query.setParameter("sysDate", sysDate);
		
		List<OCS0103U00LayCommonInfo> list = new JpaResultMapper().list(query, OCS0103U00LayCommonInfo.class);
		return list;
	}
	
	@Override
	//@Cacheable(value = "Bas0310Repository")
	public List<BAS0311Q01GrdBAS0311Info> getBAS0311Q01GrdBAS0311Info(String hospCode, String searchWord, String nuGroup, Integer startNum, Integer endNum){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT CASE A.SG_YMD WHEN '0000-00-00 00:00:00' THEN null ELSE A.SG_YMD END                                               ");
		sql.append("     , A.SG_CODE                                                                                                          ");
		sql.append("     , A.SG_NAME                                                                                                          ");
		sql.append("     , A.SG_NAME_KANA                                                                                                     ");
		sql.append("     , A.BUN_CODE                                                                                                         ");
		sql.append("     , A.GROUP_GUBUN                                                                                                      ");
		sql.append("     , A.DANUI                                                                                                            ");
		sql.append("     , A.BULYONG_YMD                                                                                                      ");
		sql.append("  FROM BAS0310 A                                                                                                          ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                                                                         ");
		sql.append("   AND CONCAT(A.SG_CODE , A.SG_NAME)  LIKE :f_search_word                                                                 ");
		sql.append("   AND A.SG_YMD = ( SELECT MAX(Z.SG_YMD)                                                                                  ");
		sql.append("              		FROM BAS0310 Z                                                                                        ");
		sql.append("                    WHERE Z.HOSP_CODE  =  A.HOSP_CODE                                                                     ");
		sql.append("                    AND Z.SG_CODE  =  A.SG_CODE                                                                           ");
		//sql.append("                    AND Z.SG_YMD  <=  IFNULL(STR_TO_DATE('2011/01/31','%Y/%m/%d'), SYSDATE()) )                           ");
		sql.append("                    AND Z.SG_YMD  <=  CURDATE() )                          												  ");
		sql.append("   AND IFNULL(A.BULYONG_YMD, STR_TO_DATE('99981231','%Y%m%d')) > IFNULL(STR_TO_DATE('2011/01/31','%Y/%m/%d'), SYSDATE())  ");
		sql.append("   AND A.BUN_CODE LIKE :f_nu_group                                                                                        ");
		sql.append(" ORDER BY A.SG_CODE                                                                                                       ");
		sql.append(" LIMIT :startNum, :endNum                                                                                                 ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_search_word", "%" + searchWord + "%");
		query.setParameter("f_nu_group", nuGroup+ "%");
		query.setParameter("startNum", startNum);
		query.setParameter("endNum", endNum);
		List<BAS0311Q01GrdBAS0311Info> list = new JpaResultMapper().list(query, BAS0311Q01GrdBAS0311Info.class);
		return list;
	}

	@Override
	@Cacheable(value = "Bas0310Repository")
	public List<ComBizGetFindWorkerInfo> getComBizGetFindWorkerInfoCaseSgCode(String hospCode, String sgYmd, String find) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.SG_CODE         AS CODE																	");
		sql.append("	     , A.SG_NAME         AS CODE_NAME                                                               ");
		sql.append("	     , ' '                                                                                          ");
		sql.append("	  FROM BAS0310 A                                                                                    ");
		sql.append("	 WHERE A.HOSP_CODE       = :f_hosp_code                                                             ");
		sql.append("	   AND A.SG_YMD          = (SELECT MAX(Z.SG_YMD)                                                    ");
		sql.append("	                              FROM BAS0310   Z                                                      ");
		sql.append("	                             WHERE Z.HOSP_CODE          = A.HOSP_CODE                               ");
		sql.append("	                               AND Z.SG_CODE            = A.SG_CODE                                 ");
		sql.append("	                               AND Z.SG_YMD             <= STR_TO_DATE(:f_sg_ymd, '%Y/%m/%d')       ");
		sql.append("	                               AND (   A.BULYONG_YMD    IS NULL                                     ");
		sql.append("	                                    OR A.BULYONG_YMD    >= STR_TO_DATE(:f_sg_ymd, '%Y/%m/%d')       ");
		sql.append("	                                   )                                                                ");
		sql.append("	                           )                                                                        ");
		sql.append("	   AND (   A.SG_CODE     LIKE :f_find1                                                              ");
		sql.append("	        OR A.SG_NAME     LIKE :f_find1                                                              ");
		sql.append("	       )                                                                                            ");
		sql.append("	ORDER BY A.HOSP_CODE, A.SG_CODE                                                                     ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_sg_ymd", sgYmd );
		query.setParameter("f_find1",  "%" + find + "%");
		List<ComBizGetFindWorkerInfo> list = new JpaResultMapper().list(query, ComBizGetFindWorkerInfo.class);
		return list;
	}

	@Override
	public List<BAS0311U00GridListItemInfo> getBAS0311U00GridListItemInfo(String hospCode, String language, String sgCode) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.SG_CODE                                                                                                                               ");
		sql.append("     , A.GROUP_GUBUN                                                                                                                            ");
		sql.append("     , A.SG_NAME                                                                                                                                ");
		sql.append("     , A.SG_NAME_KANA                                                                                                                           ");
		sql.append("     , A.SG_YMD                                                                                                                                 ");
		sql.append("     , A.SUGA_CHANGE                                                                                                                            ");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('SUGA_CHANGE',A.SUGA_CHANGE, :f_hosp_code, :f_language)                SUGA_CHANGE_NM_D                            ");
		sql.append("     , A.BULYONG_YMD                                                                                                                            ");
		sql.append("     , A.BULYONG_SAYU                                                                                                                           ");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('BULYONG_SAYU',A.BULYONG_SAYU, :f_hosp_code, :f_language)              BULYONG_SAYU_NM_D                           ");
		sql.append("     , A.DANUI                                                                                                                                  ");
		sql.append("     , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.DANUI, :f_hosp_code, :f_language)                       DANUI_NAME                                  ");
		sql.append("     , A.BUN_CODE                                                                                                                               ");
		sql.append("     , FN_BAS_LOAD_BUN_NAME_NEW(:f_hosp_code, :f_language A.BUN_CODE, A.SG_YMD)                BUN_CODE_NAME                                    ");
		sql.append("     , A.MARUME_GUBUN                                                                                                                           ");
		sql.append("     , A.SG_UNION                                                                                                                               ");
		sql.append("     , A.REMARK                                                                                                                                 ");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('POGWAL_GUBUN',A.MARUME_GUBUN, :f_hosp_code, :f_language)          MARUME_NAME                                     ");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('HUBAL_DRG_GUBUN',A.HUBAL_DRG_YN, :f_hosp_code, :f_language)          HUBAL_DRG_YN                                 ");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('SUNAB_CONV_CODE',A.SUNAB_QCODE_OUT, :f_hosp_code, :f_language)          SUNAB_QCODE_OUT_NAME                      ");
		sql.append("     , FN_BAS_LOAD_CODE_NAME('SUNAB_CONV_CODE',A.SUNAB_QCODE_INP, :f_hosp_code, :f_language)          SUNAB_QCODE_INP_NAME      , TAX_YN        ");
		sql.append("  FROM BAS0310 A                                                                                                                                ");
		sql.append(" WHERE A.HOSP_CODE  = :f_hosp_code                                                                                                              ");
		sql.append("   AND A.SG_CODE    = :f_sg_code                                                                                                                ");
		sql.append(" ORDER BY A.SG_CODE, SG_YMD																														");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language );
		query.setParameter("f_sg_code",  sgCode);
		List<BAS0311U00GridListItemInfo> list = new JpaResultMapper().list(query, BAS0311U00GridListItemInfo.class);
		return list;
	}

	@Override
	public String callPrAdmUpdateMasterCom(String hospCode, String userId,
			String procGubun) {
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_ADM_UPDATE_MASTER_COMS");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER_ID", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_PROC_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_ERR_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_USER_ID", userId);
		query.setParameter("I_PROC_GUBUN", procGubun);
		
		query.execute();
		String result = (String)query.getOutputParameterValue("IO_ERR_FLAG");
		return result;
	}
	public String callPrUpdateMasterData(String hospCode)
	{
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_BAS0310U00_UPDATE_MASTER_DATA");

		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.setParameter("I_HOSP_CODE", hospCode);
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.INOUT);

		query.execute();
		String erFlg = (String)query.getOutputParameterValue("O_ERR");
		return erFlg;
	}
	
}

