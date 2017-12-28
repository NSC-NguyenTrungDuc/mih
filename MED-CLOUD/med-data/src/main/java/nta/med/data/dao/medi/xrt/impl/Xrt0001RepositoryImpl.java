package nta.med.data.dao.medi.xrt.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.domain.xrt.Xrt0001;
import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.xrt.Xrt0001Repository;
import nta.med.data.model.ihis.xrts.XRT0001U00GrdXRTInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00DsvXrayGubunInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00LayPrintOrderInfo;
import nta.med.data.model.ihis.xrts.XRT9001R01Lay9001RListItemInfo;
import nta.med.data.model.ihis.xrts.XRT9001R03Lay9003RListItemInfo;
import nta.med.data.model.ihis.xrts.XRT9001R05lay9005RInfo;
import nta.med.data.model.ihis.xrts.XRT9001R06lay9006RInfo;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.jpa.repository.support.SimpleJpaRepository;
import org.springframework.stereotype.Repository;
import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
@Repository("xrt0001Repository")
public class Xrt0001RepositoryImpl extends SimpleJpaRepository<Xrt0001, Long> implements Xrt0001Repository {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Autowired
	public Xrt0001RepositoryImpl(EntityManager entityManager) {
		super(Xrt0001.class, entityManager);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	@CacheEvict(value = "Xrt0001Repository", allEntries = true)
	public Xrt0001 save(Xrt0001 entity) {
		return super.save(entity);
	}
	
	@Override
	@CacheEvict(value = "Xrt0001Repository", allEntries = true)
	public List<Xrt0001> save(List<Xrt0001> entities) {
		return super.save(entities);
	}

	@CacheEvict(value = "Xrt0001Repository", allEntries = true)
	@Override
	public void delete(Xrt0001 entity) {
		super.delete(entity);
	}
	
	
	@Override
	@Cacheable(value="Xrt0001Repository")
	public String getXRT0000Q00GetModalityCode(String hospCode,String hangmogCode) {
		String sqlQuery = "SELECT modality FROM Xrt0001 WHERE hospCode = :f_hosp_code AND xrayCode = :f_hangmog_code";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("f_hosp_code", hospCode); 
		query.setParameter("f_hangmog_code", hangmogCode); 
		List<String> listStr = query.getResultList();
		if(!CollectionUtils.isEmpty(listStr)) {
			return listStr.get(0);
		}
		return null;
	}

	@Cacheable(value="Xrt0001Repository")
	public String getYValueLayDupXRT0001U00Initialize(String hospCode,String xrayCode) {
		String sqlQuery = "SELECT 'Y' FROM Xrt0001 WHERE hospCode = :f_hosp_code AND xrayCode = :f_xray_code ";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("f_hosp_code", hospCode); 
		query.setParameter("f_xray_code", xrayCode); 
		List<String> listStr = query.getResultList();
		if(!CollectionUtils.isEmpty(listStr)) {
			return listStr.get(0);
		}
		return null;
	}

	@CacheEvict(value = "Xrt0001Repository", allEntries = true)
	public Integer updateXRT0001U00ExecuteCase1(String hospCode,String userId,String xrayName,
			String xrayGubun,String xrayRoom,
			String xrayBuwi,String xrayBuwiKaiKei,
			String xrayGu,Double xrayGubun1) {
		String sqlQuery = " UPDATE Xrt0001                            "
				        + " SET updId           = :q_user_id          "
				        + " , updDate         = SYSDATE               "
				        + " , xrayName        = :f_xray_name          "
				        + " , xrayGubun       = :f_xray_gubun         "
				        + " , xrayRoom        = :f_xray_room          "
				        + " , xrayBuwi        = :f_xray_buwi          "
				        + " , xrayBuwiKaikei = :f_xray_buwi_kaikei    "
				        + " , xrayBuwiTong   = :f_xray_buwi_tong      "
				        + " , xrayCnt         = :f_xray_cnt           "
				        + " , namePrintYn    = :f_name_print_yn       "
				        + " , sugaCode        = :f_suga_code          "
				        + " , specialYn       = :f_special_yn         "
				        + " , xrayRealCnt    = :f_xray_real_cnt       "
				        + " , slipCode        = :f_slip_code          "
				        + " , reserType       = :f_reser_type         "
				        + " , jaeryoYn        = :f_jaeryo_yn          "
				        + " , sort             = :f_sort              "
				        + " , xrayWay         = :f_xray_way           "
				        + " , tongGubun       = :f_tong_gubun         "
				        + " , requestYn       = :f_request_yn         "
				        + " , modality         = :f_modality          "
				        + " , frequentUseYn  = :f_frequent_use_yn     "
				        + " , xrayName2       = :f_xray_name2         "
				        + " , tubeVol         = :f_tube_vol           "
				        + " , tubeCur         = :f_tube_cur           "
				        + " , xrayTime        = :f_xray_time          "
				        + " , tubeCurTime    = :f_tube_cur_time       "
				        + " , irradiationTime = :f_irradiation_time   "
				        + " , xrayDistance    = :f_xray_distance      "
				        + " WHERE hospCode        = :f_hosp_code      "
				        + " AND xrayCode        = :f_xray_code        ";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("q_user_id", userId);
		query.setParameter("f_xray_name", xrayName);
		query.setParameter("f_xray_gubun", xrayGubun);
		query.setParameter("f_xray_room", xrayRoom);
		query.setParameter("f_xray_buwi", xrayBuwi);
		query.setParameter("f_xray_buwi_kaikei", xrayBuwiKaiKei);
		query.setParameter("f_xray_buwi_tong", xrayGu);
		query.setParameter("f_xray_cnt", xrayGubun1);
		return query.executeUpdate();
	}

	@CacheEvict(value = "Xrt0001Repository", allEntries = true)
	public Integer deleteXRT0001U00ExecuteCase1(String hospCode,String xrayCode) {
		String sqlQuery = "DELETE Xrt0001 WHERE hospCode = :f_hosp_code AND xrayCode = :f_xray_code";
		Query query = entityManager.createQuery(sqlQuery);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_xray_code", xrayCode);
		return query.executeUpdate();
	}

	@Override
	@Cacheable(value="Xrt0001Repository")
	public List<Xrt0001> getObjectXrt0001ExecuteCase1(String hospCode,
			String xrayCode) {
		String sqlQuery = "SELECT xrt FROM Xrt0001 xrt WHERE hospCode = :f_hosp_code AND xrayCode = :f_xray_code";
		Query query= entityManager.createQuery(sqlQuery);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_xray_code", xrayCode);
		List<Xrt0001> listStr = query.getResultList();
		return listStr;
	}

	@Override
	public List<XRT9001R01Lay9001RListItemInfo> getXRT9001R01Lay9001RListItemInfo(String hospCode, String date) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT DATE_FORMAT(A.ACTING_DATE, '%Y/%m/%d') ACTING_DATE                                                                                      ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                                ");
		sql.append("                       (case A.JUNDAL_PART when 'CR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CR_CNT_N                                     ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                                ");
		sql.append("                       (case A.JUNDAL_PART when 'CR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CR_CNT_Y                                     ");
		sql.append("      , IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                               ");
		sql.append("                       (case A.JUNDAL_PART when 'DR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) DR_CNT_N                                     ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                                ");
		sql.append("                       (case A.JUNDAL_PART when 'DR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) DR_CNT_Y                                     ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                                ");
		sql.append("                       (case A.JUNDAL_PART when 'CT' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CT_CNT_N                                     ");
		sql.append("      , IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                               ");
		sql.append("                       (case A.JUNDAL_PART when 'CT' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CT_CNT_Y                                     ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                                ");
		sql.append("                       (case A.JUNDAL_PART when 'MRI' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) MRI_CNT_N                                   ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                                ");
		sql.append("                       (case A.JUNDAL_PART when 'MRI' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) MRI_CNT_Y                                   ");
		sql.append("      , SUM(IFNULL(B.XRAY_REAL_CNT, 1)) TOTAL_CNT                                                                                               ");
		sql.append("      , '0'                                                                                                                                     ");
		sql.append("   FROM XRT0001 B                                                                                                                               ");
		sql.append("      , OCS1003 A                                                                                                                               ");
		sql.append("  WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                           ");
		sql.append("    AND A.JUNDAL_TABLE = 'XRT'                                                                                                                  ");
		sql.append("    AND A.JUNDAL_PART  LIKE '%'                                                                                                                 ");
		sql.append("    AND A.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(IFNULL(:f_date,''),'01'),'%Y%m%d') AND LAST_DAY(STR_TO_DATE(:f_date,'%Y%m'))                  ");
		sql.append("    AND IFNULL(A.BANNAB_YN, 'N') = 'N'                                                                                                          ");
		sql.append("    AND IFNULL(A.DC_YN, 'N')     = 'N'                                                                                                          ");
		sql.append("    AND A.NALSU     > 0                                                                                                                         ");
		sql.append("    AND B.HOSP_CODE = A.HOSP_CODE                                                                                                               ");
		sql.append("    AND B.XRAY_CODE = A.HANGMOG_CODE                                                                                                            ");
		sql.append("  GROUP BY DATE_FORMAT(A.ACTING_DATE, '%Y/%m/%d')                                                                                               ");
		sql.append("  UNION ALL                                                                                                                                     ");
		sql.append(" SELECT '' ACTING_DATE                                                                                                                          ");
		sql.append("      , IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                               ");
		sql.append("                       (case A.JUNDAL_PART when 'CR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CR_CNT_N                                     ");
		sql.append("      , IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                               ");
		sql.append("                       (case A.JUNDAL_PART when 'CR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CR_CNT_Y                                     ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                                ");
		sql.append("                       (case A.JUNDAL_PART when 'DR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) DR_CNT_N                                     ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                                ");
		sql.append("                       (case A.JUNDAL_PART when 'DR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) DR_CNT_Y                                     ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                                ");
		sql.append("                       (case A.JUNDAL_PART when 'CT' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CT_CNT_N                                     ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                                ");
		sql.append("                       (case A.JUNDAL_PART when 'CT' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CT_CNT_Y                                     ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                                ");
		sql.append("                       (case A.JUNDAL_PART when 'MRI' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) MRI_CNT_N                                   ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                                ");
		sql.append("                       (case A.JUNDAL_PART when 'MRI' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) MRI_CNT_Y                                   ");
		sql.append("      , SUM(IFNULL(B.XRAY_REAL_CNT, 1)) TOTAL_CNT                                                                                               ");
		sql.append("      , '1'                                                                                                                                     ");
		sql.append("   FROM XRT0001 B                                                                                                                               ");
		sql.append("      , OCS1003 A                                                                                                                               ");
		sql.append("  WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                           ");
		sql.append("    AND A.JUNDAL_TABLE = 'XRT'                                                                                                                  ");
		sql.append("    AND A.JUNDAL_PART  LIKE '%'                                                                                                                 ");
		sql.append("    AND A.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(IFNULL(:f_date,''),'01'),'%Y%m%d') AND LAST_DAY(STR_TO_DATE(:f_date,'%Y%m'))                  ");
		sql.append("    AND IFNULL(A.BANNAB_YN, 'N') = 'N'                                                                                                          ");
		sql.append("    AND IFNULL(A.DC_YN, 'N')     = 'N'                                                                                                          ");
		sql.append("    AND A.NALSU     > 0                                                                                                                         ");
		sql.append("    AND B.HOSP_CODE = A.HOSP_CODE                                                                                                               ");
		sql.append("    AND B.XRAY_CODE = A.HANGMOG_CODE                                                                                                            ");
		sql.append("  GROUP BY DATE_FORMAT(A.ACTING_DATE, '%Y/%m')                                                                                                  ");
		sql.append("  ORDER BY 11, 1																																");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_date", date);
		List<XRT9001R01Lay9001RListItemInfo> listLay9001=new JpaResultMapper().list(query, XRT9001R01Lay9001RListItemInfo.class);
		return listLay9001;
	}
	@Override
	public List<XRT9001R03Lay9003RListItemInfo> getXRT9001R03Lay9003RListItemInfo(String hospCode, String date) {
		StringBuilder sql= new StringBuilder();
		sql.append("  SELECT DATE_FORMAT(A.ACTING_DATE, '%Y/%m') ACTING_MONTH                                                                                               ");
		sql.append("       ,IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                                       ");
		sql.append("                       (case A.JUNDAL_PART when 'CR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CR_CNT_N                                             ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                                        ");
		sql.append("                       (case A.JUNDAL_PART when 'CR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CR_CNT_Y                                             ");
		sql.append("      , IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                                       ");
		sql.append("                       (case A.JUNDAL_PART when 'DR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) DR_CNT_N                                             ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                                        ");
		sql.append("                       (case A.JUNDAL_PART when 'DR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) DR_CNT_Y                                             ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                                        ");
		sql.append("                       (case A.JUNDAL_PART when 'CT' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CT_CNT_N                                             ");
		sql.append("      , IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                                       ");
		sql.append("                       (case A.JUNDAL_PART when 'CT' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CT_CNT_Y                                             ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                                        ");
		sql.append("                       (case A.JUNDAL_PART when 'MRI' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) MRI_CNT_N                                           ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                                        ");
		sql.append("                       (case A.JUNDAL_PART when 'MRI' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) MRI_CNT_Y                                           ");
		sql.append("      , SUM(IFNULL(B.XRAY_REAL_CNT, 1)) TOTAL_CNT                                                                                                       ");
		sql.append("      , '0'                                                                                                                                             ");
		sql.append("   FROM XRT0001 B                                                                                                                                       ");
		sql.append("      , OCS1003 A                                                                                                                                       ");
		sql.append("  WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                   ");
		sql.append("    AND A.JUNDAL_TABLE = 'XRT'                                                                                                                          ");
		sql.append("    AND A.JUNDAL_PART  LIKE '%'                                                                                                                         ");
		sql.append("    AND A.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(IFNULL(:f_date,''),'0101'),'%Y%m%d') AND (STR_TO_DATE(CONCAT(IFNULL(:f_date,''),'1231'),'%Y%m%d'))    ");
		sql.append("    AND IFNULL(A.BANNAB_YN, 'N') = 'N'                                                                                                                  ");
		sql.append("    AND IFNULL(A.DC_YN, 'N') = 'N'                                                                                                                      ");
		sql.append("    AND A.NALSU > 0                                                                                                                                     ");
		sql.append("    AND B.HOSP_CODE = A.HOSP_CODE                                                                                                                       ");
		sql.append("    AND B.XRAY_CODE = A.HANGMOG_CODE                                                                                                                    ");
		sql.append("  GROUP BY DATE_FORMAT(A.ACTING_DATE, '%Y/%m')                                                                                                          ");
		sql.append("  UNION ALL                                                                                                                                             ");
		sql.append("  SELECT '' ACTING_MONTH                                                                                                                                ");
		sql.append("       , IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                                      ");
		sql.append("                       (case A.JUNDAL_PART when 'CR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CR_CNT_N                                             ");
		sql.append("      , IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                                       ");
		sql.append("                       (case A.JUNDAL_PART when 'CR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CR_CNT_Y                                             ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                                        ");
		sql.append("                       (case A.JUNDAL_PART when 'DR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) DR_CNT_N                                             ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                                        ");
		sql.append("                       (case A.JUNDAL_PART when 'DR' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) DR_CNT_Y                                             ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                                        ");
		sql.append("                       (case A.JUNDAL_PART when 'CT' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CT_CNT_N                                             ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                                        ");
		sql.append("                       (case A.JUNDAL_PART when 'CT' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) CT_CNT_Y                                             ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'N' then                                                                                                        ");
		sql.append("                       (case A.JUNDAL_PART when 'MRI' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) MRI_CNT_N                                           ");
		sql.append("      ,IFNULL(SUM(case B.JAERYO_YN when 'Y' then                                                                                                        ");
		sql.append("                       (case A.JUNDAL_PART when 'MRI' then IFNULL(B.XRAY_REAL_CNT, 1) end) end), 0) MRI_CNT_Y                                           ");
		sql.append("      , SUM(IFNULL(B.XRAY_REAL_CNT, 1)) TOTAL_CNT                                                                                                       ");
		sql.append("      , '1'                                                                                                                                             ");
		sql.append("   FROM XRT0001 B                                                                                                                                       ");
		sql.append("      , OCS1003 A                                                                                                                                       ");
		sql.append("  WHERE A.HOSP_CODE    = :f_hosp_code                                                                                                                   ");
		sql.append("    AND A.JUNDAL_TABLE = 'XRT'                                                                                                                          ");
		sql.append("    AND A.JUNDAL_PART  LIKE '%'                                                                                                                         ");
		sql.append("    AND A.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(IFNULL(:f_date,''),'0101'),'%Y%m%d') AND (STR_TO_DATE(CONCAT(IFNULL(:f_date,''),'1231'),'%Y%m%d'))    ");
		sql.append("    AND IFNULL(A.BANNAB_YN, 'N') = 'N'                                                                                                                  ");
		sql.append("    AND IFNULL(A.DC_YN, 'N') = 'N'                                                                                                                      ");
		sql.append("    AND A.NALSU > 0                                                                                                                                     ");
		sql.append("    AND B.HOSP_CODE = A.HOSP_CODE                                                                                                                       ");
		sql.append("    AND B.XRAY_CODE = A.HANGMOG_CODE                                                                                                                    ");
		sql.append("  GROUP BY DATE_FORMAT(A.ACTING_DATE, '%Y')                                                                                                             ");
		sql.append("  ORDER BY 11, 1																																		");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_date", date);
		List<XRT9001R03Lay9003RListItemInfo> listLay9003= new JpaResultMapper().list(query, XRT9001R03Lay9003RListItemInfo.class);
		return listLay9003;
	}
	@Override
	public List<XRT0001U00GrdXRTInfo> getXRT0001U00GrdXRTListItemInfo(String hospCode,String language, String txtParam, String xrayGubun, String specialYn) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT                                                                                                                                                                 ");
		sql.append(" A.XRAY_CODE, A.XRAY_NAME  , A.XRAY_GUBUN , A.XRAY_ROOM                                                                                                                 ");
		sql.append(" , A.XRAY_BUWI , A.XRAY_BUWI_KAIKEI , A.XRAY_BUWI_TONG, A.XRAY_CNT                                                                                                      ");
		sql.append(" , A.NAME_PRINT_YN , A.SUGA_CODE, A.SPECIAL_YN , A.XRAY_REAL_CNT                                                                                                        ");
		sql.append(" , A.SLIP_CODE , A.RESER_TYPE, B.CODE_NAME    GUBUN_NAME                                                                                                                ");
		sql.append(" , G.CODE_NAME    ROOM_NAME , C.BUWI_NAME    BUWI_NAME                                                                                                                  ");
		sql.append(" , I.BUWI_NAME    BUWI_KAIKEI_NAME, D.BUWI_NAME    BUWI_TONG_NAME                                                                                                       ");
		sql.append(" , H.CODE_NAME    RESER_TYPE_NAME, A.JAERYO_YN                                                                                                                          ");
		sql.append(" , A.SORT, A.XRAY_WAY, A.FREQUENT_USE_YN                                                                                                                                ");
		sql.append(" , A.MODALITY, J.CODE_NAME    MODALITY_NAME                                                                                                                             ");
		sql.append(" , LPAD(A.SORT,4,'0'), A.XRAY_NAME2, A.TONG_GUBUN, A.REQUEST_YN                                                                                                         ");
		sql.append("   FROM                                                                                                                                                                 ");
		sql.append(" 	  (((((((( XRT0001 A LEFT JOIN XRT0102 B ON B.HOSP_CODE = A.HOSP_CODE AND A.XRAY_GUBUN = B.CODE AND B.CODE_TYPE = 'X1' AND B.LANGUAGE = :f_language)                ");
		sql.append(" 		LEFT JOIN  XRT0122 C ON  C.HOSP_CODE = A.HOSP_CODE  AND C.BUWI_CODE  = A.XRAY_BUWI AND C.LANGUAGE = :f_language)                                                ");
		sql.append(" 			LEFT JOIN XRT0122 D ON D.HOSP_CODE = A.HOSP_CODE AND D.BUWI_CODE = A.XRAY_BUWI_TONG AND D.LANGUAGE = :f_language)                                           ");
		sql.append(" 				LEFT JOIN XRT0102 E ON E.HOSP_CODE = A.HOSP_CODE AND E.CODE = A.XRAY_WAY  AND E.CODE_TYPE = 'X4' AND E.LANGUAGE = :f_language)                          ");
		sql.append(" 					LEFT JOIN XRT0102 F ON F.HOSP_CODE = A.HOSP_CODE AND F.CODE =A.XRAY_RIGHT AND F.CODE_TYPE = 'X5' AND F.LANGUAGE = :f_language)                      ");
		sql.append(" 						LEFT JOIN XRT0102 G ON G.HOSP_CODE = A.HOSP_CODE AND G.CODE = A.XRAY_ROOM AND G.CODE_TYPE = 'X6' AND G.LANGUAGE = :f_language)                  ");
		sql.append(" 							LEFT JOIN XRT0102 H ON H.HOSP_CODE = A.HOSP_CODE AND H.CODE = A.RESER_TYPE AND H.CODE_TYPE = 'Y' AND H.LANGUAGE = :f_language)              ");
		sql.append(" 								LEFT JOIN XRT0122 I ON I.HOSP_CODE = A.HOSP_CODE AND I.BUWI_CODE = A.XRAY_BUWI_KAIKEI AND I.LANGUAGE = :f_language)                     ");
		sql.append(" 									LEFT JOIN XRT0102 J ON J.HOSP_CODE = A.HOSP_CODE AND J.CODE=A.MODALITY AND J.CODE_TYPE = 'MO' AND J.LANGUAGE = :f_language          ");
		sql.append(" 	                                                                                                                                                                    ");
		sql.append("  WHERE A.HOSP_CODE                = :f_hosp_code                                                                                                                       ");
		sql.append("    AND A.XRAY_GUBUN               <> 'R'                                                                                                                               ");
		sql.append("    AND (IFNULL(A.XRAY_CODE,'%')      LIKE CONCAT('%',IFNULL(:f_txtParam,'%'),'%')                                                                                      ");
		sql.append("     OR  IFNULL(A.XRAY_NAME,'%')      LIKE CONCAT('%',IFNULL(:f_txtParam,'%'),'%'))                                                                                     ");
		sql.append("    AND IFNULL(A.XRAY_GUBUN,'%')      LIKE CONCAT('%',IFNULL(:f_xray_gubun,'%'),'%')                                                                                    ");
		sql.append("    AND IFNULL(A.SPECIAL_YN,'%')      LIKE CONCAT('%',IFNULL(:f_special_yn,'%'),'%')                                                                                    ");
		sql.append("  ORDER BY A.XRAY_CODE																																					");		

		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_txtParam", txtParam);
		query.setParameter("f_xray_gubun", xrayGubun);
		query.setParameter("f_special_yn", specialYn);
		List<XRT0001U00GrdXRTInfo> listGrd= new JpaResultMapper().list(query, XRT0001U00GrdXRTInfo.class);
		return listGrd;
		
	}
	@Override
	public String getSpeciFicCommentInputYnRequest(String hospCode,String tableId, String colId, Double pkOcsKey) {
		StringBuilder sql= new StringBuilder();
		sql.append("SELECT 'Y' FROM DUAL   WHERE EXISTS (                   ");
		sql.append("               SELECT NULL FROM                         ");
		sql.append(              tableId                               	     );
		sql.append("               WHERE HOSP_CODE   = :f_hosp_code  AND    ");
		sql.append(               colId                                      );
		sql.append("               = :f_aPkocskey  )                        ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_aPkocskey", pkOcsKey);
		List<String> listResult=query.getResultList();
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
	
	@Override
	@Cacheable(value="Xrt0001Repository")
	public List<XRT1002U00DsvXrayGubunInfo> getXRT1002U00DsvXrayGubunInfo(String hospCode, String code) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.XRAY_GUBUN     , A.XRAY_NAME     , IFNULL(A.REQUEST_YN,'N') REQUEST_YN   ");
		sql.append("  FROM XRT0001 A WHERE A.XRAY_CODE = :f_code   AND A.HOSP_CODE = :f_hosp_code      ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code", code);
		List<XRT1002U00DsvXrayGubunInfo> listGrd= new JpaResultMapper().list(query, XRT1002U00DsvXrayGubunInfo.class);
		return listGrd;
	}
@Override
	public List<XRT1002U00LayPrintOrderInfo> getXRT1002U00LayPrintOrderInfo(String hospCode, String language, String orderDate, String gwa, String inOutGubun, Double pkocs) {
		StringBuilder sql= new StringBuilder();
		sql.append("SELECT E.BUNHO                                                                  BUNHO,                                                             ");
		sql.append("       F.SUNAME                                                                 SUNAME,                                                            ");
		sql.append("       CAST(' ' AS CHAR)                                                                       HO_DONG,                                                           ");
		sql.append("       CAST(' ' AS CHAR)                                                                       HOCODE,                                                            ");
		sql.append("       F.BIRTH                                                                  BIRTH,                                                             ");
		sql.append("       F.SEX                                                                    SEX,                                                               ");
		sql.append("       FN_BAS_LOAD_AGE(SYSDATE(),F.BIRTH,NULL)                                  AGE,                                                               ");
		sql.append("       :f_order_date                                                            ORDER_DATE,                                                        ");
		sql.append("       FN_BAS_LOAD_GWA_NAME(:f_gwa, :f_order_date,:f_hosp_code,:f_language)     GWA_NAME   ,                                                       ");
		sql.append("       FN_OCS_LOAD_ORDER_DOCTOR_NAME(:f_hosp_code,E.FKOCS)                      DOCTOR_NAME,                                                       ");
		sql.append("       C.XRAY_NAME                                                              XRAY_NAME,                                                         ");
		sql.append("       A.XRT_COMMENTS                                                           XRT_COMMENTS,                                                      ");
		sql.append("       E.GUMSA_MOKJUK                                                           GUMSA_MOKJUK2,                                                     ");
		sql.append("       CONCAT('9' , E.FKOCS)                                                    PKOCS,                                                             ");
		sql.append("       B.CODE_NAME                                                              XRAY_GUBUN_NAME,                                                   ");
		sql.append("       A.XRAY_RESER_DATE                                                        XRAY_RESER_DATE,                                                   ");
		sql.append("       A.XRAY_RESER_TIME                                                        XRAY_RESER_TIME,                                                   ");
		sql.append("       CAST(' ' AS CHAR)                                                                       PAT_STATUS_NAME,                                                   ");
		sql.append("       CAST(' ' AS CHAR)                                                                       PAT_STATUS_CODE_NAME,                                              ");
		sql.append("       CAST(' ' AS CHAR)                                                                       CPL_RESULT,                                                        ");
		sql.append("       CAST(' ' AS CHAR)                                                                       CPL_GUMSA_DATE,                                                    ");
		sql.append("       F.SUNAME2                                                                PACS_SUNAME2,                                                      ");
		sql.append("       E.XRAY_METHOD                                                            XRAY_METHOD,                                                       ");
		sql.append("       C.XRAY_GUBUN                                                             XRAY_GUBUN,                                                        ");
		sql.append("       FN_XRT_LOAD_ORDER_TIME(:f_hosp_code,E.IN_OUT_GUBUN, E.FKOCS)             ORDER_TIME,                                                        ");
		sql.append("       FN_BAS_TO_JAPAN_DATE_CONVERT('1', F.BIRTH,:f_hosp_code,:f_language)      BIRTH_JAPAN,                                                       ");
		sql.append("       FN_NUR_LOAD_WEIGHT_HEIGHT('W', E.BUNHO,:f_hosp_code)                     WEIGHT,                                                            ");
		sql.append("       FN_NUR_LOAD_WEIGHT_HEIGHT('H', E.BUNHO,:f_hosp_code)                     HEIGHT,                                                            ");
		sql.append("       E.HANGMOG_CODE                                                           XRAY_CODE ,                                                        ");
		sql.append("       FN_XRT_LOAD_COMMENT(:f_hosp_code,E.FKOCS, NULL)                          COMMENT,                                                           ");
		sql.append("       C.XRAY_BUWI                                                              BUWI_CODE,                                                         ");
		sql.append("       D.BUWI_NAME                                                              BUWI_CODE_NAME,                                                    ");
		sql.append("       CAST(' ' AS CHAR)                                                                       VALTAGE,                                                           ");
		sql.append("       CAST(' ' AS CHAR)                                                                       CUR_ELECTRIC,                                                      ");
		sql.append("       CAST(' ' AS CHAR)                                                                       TIME,                                                              ");
		sql.append("       CAST(' ' AS CHAR)                                                                       DISTANCE,                                                          ");
		sql.append("       CAST(' ' AS CHAR)                                                                       GRID,                                                              ");
		sql.append("       CAST(' ' AS CHAR)                                                                       NOTE,                                                              ");
		sql.append("       A.PKXRT0201                                                                                                                                 ");
		sql.append("  FROM                                                                                                                                             ");
		sql.append("       XRT1002 E RIGHT JOIN XRT0201 A ON E.FKOCS = A.FKOCS1003                                                                                     ");
		sql.append("                 JOIN OUT0101 F ON F.BUNHO = E.BUNHO,                                                                                              ");
		sql.append("       XRT0001 C RIGHT JOIN XRT0102 B ON B.CODE_TYPE = 'X1' AND B.CODE = C.XRAY_GUBUN AND B.LANGUAGE = :f_language                                 ");
		sql.append("                 RIGHT JOIN XRT0122 D ON D.BUWI_CODE = C.XRAY_BUWI AND D.LANGUAGE = :f_language                                                    ");
		sql.append(" WHERE :f_in_out_gubun  = 'O'                                                                                                                      ");
		sql.append("   AND E.FKOCS          = :f_pkocs                                                                                                                 ");
		sql.append("   AND E.IN_OUT_GUBUN  LIKE :f_in_out_gubun                                                                                                        ");
		sql.append("   AND C.XRAY_CODE      = E.HANGMOG_CODE                                                                                                           ");
		sql.append("   UNION                                                                                                                                           ");
		sql.append("   SELECT E.BUNHO                                                                   BUNHO,                                                         ");
		sql.append("       F.SUNAME                                                                     SUNAME,                                                        ");
		sql.append("       FN_BAS_LOAD_CURR_HODONG(G.FKINP1001,SYSDATE(),'H',:f_hosp_code,:f_language)  HO_DONG,                                                       ");
		sql.append("       FN_BAS_LOAD_CURR_HODONG(G.FKINP1001,SYSDATE(),'C',:f_hosp_code,:f_language)  HOCODE,                                                        ");
		sql.append("       F.BIRTH                                                                      BIRTH,                                                         ");
		sql.append("       F.SEX                                                                        SEX,                                                           ");
		sql.append("       FN_BAS_LOAD_AGE(SYSDATE(),F.BIRTH,NULL)                                      AGE,                                                           ");
		sql.append("       :f_order_date                                                                ORDER_DATE,                                                    ");
		sql.append("       FN_BAS_LOAD_GWA_NAME(:f_gwa, :f_order_date,:f_hosp_code,:f_language)         GWA_NAME   ,                                                   ");
		sql.append("       FN_OCS_LOAD_ORDER_DOCTOR_NAME(:f_hosp_code,E.FKOCS)                          DOCTOR_NAME,                                                   ");
		sql.append("       C.XRAY_NAME                                                                  XRAY_NAME,                                                     ");
		sql.append("       A.XRT_COMMENTS                                                               XRT_COMMENTS,                                                  ");
		sql.append("       E.GUMSA_MOKJUK                                                               GUMSA_MOKJUK2,                                                 ");
		sql.append("       CONCAT('9' , E.FKOCS)                                                        PKOCS,                                                         ");
		sql.append("       B.CODE_NAME                                                                  XRAY_GUBUN_NAME,                                               ");
		sql.append("       A.XRAY_RESER_DATE                                                            XRAY_RESER_DATE,                                               ");
		sql.append("       A.XRAY_RESER_TIME                                                            XRAY_RESER_TIME,                                               ");
		sql.append("       CAST(' ' AS CHAR)                                                                           PAT_STATUS_NAME,                                               ");
		sql.append("       CAST(' ' AS CHAR)                                                                           PAT_STATUS_CODE_NAME,                                          ");
		sql.append("       CAST(' ' AS CHAR)                                                                           CPL_RESULT,                                                    ");
		sql.append("       CAST(' ' AS CHAR)                                                                           CPL_GUMSA_DATE,                                                ");
		sql.append("       F.SUNAME2                                                                    PACS_SUNAME2,                                                  ");
		sql.append("       E.XRAY_METHOD                                                                XRAY_METHOD,                                                   ");
		sql.append("       C.XRAY_GUBUN                                                                 XRAY_GUBUN,                                                    ");
		sql.append("       FN_XRT_LOAD_ORDER_TIME(:f_hosp_code,E.IN_OUT_GUBUN,E.FKOCS)                  ORDER_TIME,                                                    ");
		sql.append("       FN_BAS_TO_JAPAN_DATE_CONVERT('1', F.BIRTH,:f_hosp_code,:f_language)          BIRTH_JAPAN,                                                   ");
		sql.append("       FN_NUR_LOAD_WEIGHT_HEIGHT('W', E.BUNHO,:f_hosp_code)                         WEIGHT,                                                        ");
		sql.append("       FN_NUR_LOAD_WEIGHT_HEIGHT('H', E.BUNHO,:f_hosp_code)                         HEIGHT,                                                        ");
		sql.append("       E.HANGMOG_CODE                                                               XRAY_CODE ,                                                    ");
		sql.append("       FN_XRT_LOAD_COMMENT(:f_hosp_code,NULL, E.FKOCS)                              COMMENT,                                                       ");
		sql.append("       C.XRAY_BUWI                                                                  BUWI_CODE,                                                     ");
		sql.append("       D.BUWI_NAME                                                                  BUWI_CODE_NAME,                                                ");
		sql.append("       CAST(' ' AS CHAR)                                                                           VALTAGE,                                                       ");
		sql.append("       CAST(' ' AS CHAR)                                                                           CUR_ELECTRIC,                                                  ");
		sql.append("       CAST(' ' AS CHAR)                                                                           TIME,                                                          ");
		sql.append("       CAST(' ' AS CHAR)                                                                           DISTANCE,                                                      ");
		sql.append("       CAST(' ' AS CHAR)                                                                           GRID,                                                          ");
		sql.append("       CAST(' ' AS CHAR)                                                                           NOTE,                                                          ");
		sql.append("       A.PKXRT0201                                                                                                                                 ");
		sql.append("  FROM                                                                                                                                             ");
		sql.append("                                                                                                                                                   ");
		sql.append("       XRT1002 E LEFT JOIN OCS2003 G ON E.FKOCS = G.PKOCS2003                                                                                      ");
		sql.append("                 LEFT JOIN XRT0201 A ON E.FKOCS = A.FKOCS2003                                                                                      ");
		sql.append("                 JOIN OUT0101 F ON F.BUNHO = E.BUNHO,                                                                                              ");
		sql.append("       XRT0001 C LEFT JOIN XRT0102 B ON B.HOSP_CODE = C.HOSP_CODE AND B.CODE_TYPE = 'X1' AND B.CODE = C.XRAY_GUBUN AND B.LANGUAGE = :f_language    ");
		sql.append("                 LEFT JOIN XRT0122 D ON D.BUWI_CODE = C.XRAY_BUWI AND D.LANGUAGE = :f_language                                                     ");
		sql.append(" WHERE :f_in_out_gubun  = 'I'                                                                                                                      ");
		sql.append("   AND E.FKOCS          = :f_pkocs                                                                                                                 ");
		sql.append("   AND E.IN_OUT_GUBUN   LIKE :f_in_out_gubun                                                                                                       ");
		sql.append("   AND C.XRAY_CODE      = E.HANGMOG_CODE                                                                                                           ");
		sql.append(" ORDER BY 39                                                                                                                                       ");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_order_date", orderDate);
		query.setParameter("f_gwa", gwa);
		query.setParameter("f_pkocs", pkocs);
		query.setParameter("f_in_out_gubun", inOutGubun);
		List<XRT1002U00LayPrintOrderInfo> listGrd= new JpaResultMapper().list(query, XRT1002U00LayPrintOrderInfo.class);
		return listGrd;
	}

	@Override
	public List<XRT9001R06lay9006RInfo> getXRT9001R06lay9006RInfo(String hospCode, String date) {
		StringBuilder sql= new StringBuilder();
		sql.append("	SELECT                                                                                                                                                                                                        							");
		sql.append("	DATE_FORMAT(A.ACTING_DATE,'%Y/%m')                                                                                        ACTING_MONTH,                                                                       							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) AS CHAR) O_CR_CNT_N,							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) AS CHAR) I_CR_CNT_N,							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) AS CHAR) O_CR_CNT_Y,							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) AS CHAR) I_CR_CNT_Y,							");
		sql.append("	CAST(IFNULL(SUM(CASE B.XRAY_CODE WHEN NULL THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN 1 END END),0) AS CHAR)                                                   O_BM_CNT_N,                                                      							");
		sql.append("	CAST(IFNULL(SUM(CASE B.XRAY_CODE WHEN NULL THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN 1 END END),0) AS CHAR)                                                   I_BM_CNT_N,                                                      							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) O_DR_CNT_N,                                           							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) I_DR_CNT_N,                                           							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) O_DR_CNT_Y,                                           							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) I_DR_CNT_Y,                                           							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) O_CT_CNT_N,                                           							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) I_CT_CNT_N,                                           							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) O_CT_CNT_Y,                                           							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) I_CT_CNT_Y,                                           							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) O_MRI_CNT_N,                                         							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) I_MRI_CNT_N,                                         							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) O_MRI_CNT_Y,                                         							");
		sql.append("	CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) I_MRI_CNT_Y,                                         							");
		sql.append("	CAST(SUM(CASE B.XRAY_CODE WHEN NULL THEN 1 ELSE IFNULL(B.XRAY_REAL_CNT,1) END) AS CHAR)                                                               TOTAL_CNT,                                                            							");
		sql.append("	'0'                                                                                                                                                                                                           							");
		sql.append("	FROM                                                                                                                                                                                                          							");
		sql.append("	(                                                                                                                                                                                                             							");
		sql.append("		SELECT                                                                                                                                                                                                    							");
		sql.append("			X.HOSP_CODE    AS HOSP_CODE,                                                                                                                                                                          							");
		sql.append("			X.HANGMOG_CODE AS HANGMOG_CODE,                                                                                                                                                                       							");
		sql.append("			X.ACTING_DATE  AS ACTING_DATE,                                                                                                                                                                        							");
		sql.append("			X.JUNDAL_PART  AS JUNDAL_PART,                                                                                                                                                                        							");
		sql.append("			'O'            AS IN_OUT_GUBUN                                                                                                                                                                        							");
		sql.append("		FROM                                                                                                                                                                                                      							");
		sql.append("			OCS1003 X                                                                                                                                                                                             							");
		sql.append("		WHERE                                                                                                                                                                                                     							");
		sql.append("			X.HOSP_CODE    = :f_hosp_code                                                                                                                                                                         							");
		sql.append("			AND X.JUNDAL_TABLE = 'XRT'                                                                                                                                                                            							");
		sql.append("			AND X.JUNDAL_PART  LIKE '%'                                                                                                                                                                           							");
		sql.append("			AND X.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'0101'),'%Y%m%d') AND(STR_TO_DATE(CONCAT(:f_date,'1231'),'%Y%m%d'))                                                                             							");
		sql.append("			AND IFNULL(X.BANNAB_YN,'N') = 'N'                                                                                                                                                                     							");
		sql.append("			AND IFNULL(X.DC_YN,'N')     = 'N'                                                                                                                                                                     							");
		sql.append("			AND X.NALSU     > 0                                                                                                                                                                                   							");
		sql.append("		UNION ALL                                                                                                                                                                                                 							");
		sql.append("		SELECT                                                                                                                                                                                                    							");
		sql.append("			Y.HOSP_CODE    AS HOSP_CODE,                                                                                                                                                                          							");
		sql.append("			Y.HANGMOG_CODE AS HANGMOG_CODE,                                                                                                                                                                       							");
		sql.append("			Y.ACTING_DATE  AS ACTING_DATE,                                                                                                                                                                        							");
		sql.append("			Y.JUNDAL_PART  AS JUNDAL_PART,                                                                                                                                                                        							");
		sql.append("			'I'            AS IN_OUT_GUBUN                                                                                                                                                                        							");
		sql.append("		FROM                                                                                                                                                                                                      							");
		sql.append("	 		OCS2003 Y                                                                                                                                                                                             							");
		sql.append("		WHERE                                                                                                                                                                                                     							");
		sql.append("	 		Y.HOSP_CODE    = :f_hosp_code                                                                                                                                                                         							");
		sql.append("			AND Y.JUNDAL_TABLE = 'XRT'                                                                                                                                                                            							");
		sql.append("			AND Y.JUNDAL_PART  LIKE '%'                                                                                                                                                                           							");
		sql.append("			AND Y.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'0101'),'%Y%m%d') AND(STR_TO_DATE(CONCAT(:f_date,'1231'),'%Y%m%d'))                                                                             							");
		sql.append("			AND IFNULL(Y.BANNAB_YN,'N') = 'N'                                                                                                                                                                     							");
		sql.append("			AND IFNULL(Y.DC_YN,'N')     = 'N'                                                                                                                                                                     							");
		sql.append("			AND Y.NALSU     > 0                                                                                                                                                                                   							");
		sql.append("	) A                                                                                                                                                                                                           							");
		sql.append("	LEFT OUTER JOIN XRT0001 B                                                                                                                                                                                     							");
		sql.append("	ON B.HOSP_CODE = A.HOSP_CODE                                                                                                                                                                                  							");
		sql.append("	AND B.XRAY_CODE = A.HANGMOG_CODE                                                                                                                                                                              							");
		sql.append("	WHERE                                                                                                                                                                                                         							");
		sql.append("	A.HOSP_CODE    = :f_hosp_code                                                                                                                                                                                 							");
		sql.append("	GROUP BY                                                                                                                                                                                                      							");
		sql.append("	DATE_FORMAT(A.ACTING_DATE,'%Y/%m')                                                                                                                                                                            							");
		sql.append("	UNION ALL                                                                                                                                                                                                     							");
		sql.append("	SELECT                                                                                                                                                                                                        							");
		sql.append("	'サブ合計１'                                                                                                             ACTING_DATE,                                                                              							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) O_CR_CNT_N,							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) I_CR_CNT_N,							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) O_CR_CNT_Y,							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) I_CR_CNT_Y,							");
		sql.append("	IFNULL(SUM(CASE B.XRAY_CODE WHEN NULL THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN 1 END END),0)                                                   O_BM_CNT_N,                                                      							");
		sql.append("	IFNULL(SUM(CASE B.XRAY_CODE WHEN NULL THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN 1 END END),0)                                                   I_BM_CNT_N,                                                      							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) O_DR_CNT_N,                                           							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) I_DR_CNT_N,                                           							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) O_DR_CNT_Y,                                           							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) I_DR_CNT_Y,                                           							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) O_CT_CNT_N,                                           							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) I_CT_CNT_N,                                           							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) O_CT_CNT_Y,                                           							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) I_CT_CNT_Y,                                           							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) O_MRI_CNT_N,                                         							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) I_MRI_CNT_N,                                         							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) O_MRI_CNT_Y,                                         							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) I_MRI_CNT_Y,                                         							");
		sql.append("	SUM(CASE B.XRAY_CODE WHEN NULL THEN 1 ELSE IFNULL(B.XRAY_REAL_CNT,1) END)                                                               TOTAL_CNT,                                                            							");
		sql.append("	'1'                                                                                                                                                                                                           							");
		sql.append("	FROM                                                                                                                                                                                                          							");
		sql.append("	(                                                                                                                                                                                                             							");
		sql.append("		SELECT                                                                                                                                                                                                    							");
		sql.append("			X.HOSP_CODE    AS HOSP_CODE,                                                                                                                                                                          							");
		sql.append("			X.HANGMOG_CODE AS HANGMOG_CODE,                                                                                                                                                                       							");
		sql.append("			X.ACTING_DATE  AS ACTING_DATE,                                                                                                                                                                        							");
		sql.append("			X.JUNDAL_PART  AS JUNDAL_PART,                                                                                                                                                                        							");
		sql.append("			'O'            AS IN_OUT_GUBUN                                                                                                                                                                        							");
		sql.append("		FROM                                                                                                                                                                                                      							");
		sql.append("	 		OCS1003 X                                                                                                                                                                                             							");
		sql.append("		WHERE                                                                                                                                                                                                     							");
		sql.append("			X.HOSP_CODE    = :f_hosp_code                                                                                                                                                                         							");
		sql.append("			AND X.JUNDAL_TABLE = 'XRT'                                                                                                                                                                            							");
		sql.append("			AND X.JUNDAL_PART  LIKE '%'                                                                                                                                                                           							");
		sql.append("			AND X.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'0101'),'%Y%m%d') AND(STR_TO_DATE(CONCAT(:f_date,'1231'),'%Y%m%d'))                                                                             							");
		sql.append("			AND IFNULL(X.BANNAB_YN,'N') = 'N'                                                                                                                                                                     							");
		sql.append("			AND IFNULL(X.DC_YN,'N')     = 'N'                                                                                                                                                                     							");
		sql.append("			AND X.NALSU     > 0                                                                                                                                                                                   							");
		sql.append("		UNION ALL                                                                                                                                                                                                 							");
		sql.append("		SELECT                                                                                                                                                                                                    							");
		sql.append("			Y.HOSP_CODE    AS HOSP_CODE,                                                                                                                                                                          							");
		sql.append("			Y.HANGMOG_CODE AS HANGMOG_CODE,                                                                                                                                                                       							");
		sql.append("			Y.ACTING_DATE  AS ACTING_DATE,                                                                                                                                                                        							");
		sql.append("			Y.JUNDAL_PART  AS JUNDAL_PART,                                                                                                                                                                        							");
		sql.append("			'I'            AS IN_OUT_GUBUN                                                                                                                                                                        							");
		sql.append("		FROM                                                                                                                                                                                                      							");
		sql.append("			OCS2003 Y                                                                                                                                                                                             							");
		sql.append("		WHERE                                                                                                                                                                                                     							");
		sql.append("			Y.HOSP_CODE    = :f_hosp_code                                                                                                                                                                         							");
		sql.append("			AND Y.JUNDAL_TABLE = 'XRT'                                                                                                                                                                            							");
		sql.append("			AND Y.JUNDAL_PART  LIKE '%'                                                                                                                                                                           							");
		sql.append("			AND Y.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'0101'),'%Y%m%d') AND(STR_TO_DATE(CONCAT(:f_date,'1231'),'%Y%m%d'))                                                                             							");
		sql.append("			AND IFNULL(Y.BANNAB_YN,'N') = 'N'                                                                                                                                                                     							");
		sql.append("			AND IFNULL(Y.DC_YN,'N')     = 'N'                                                                                                                                                                     							");
		sql.append("			AND Y.NALSU     > 0                                                                                                                                                                                   							");
		sql.append("	) A                                                                                                                                                                                                           							");
		sql.append("	LEFT OUTER JOIN XRT0001 B                                                                                                                                                                                     							");
		sql.append("	ON B.HOSP_CODE = A.HOSP_CODE                                                                                                                                                                                  							");
		sql.append("	AND B.XRAY_CODE = A.HANGMOG_CODE                                                                                                                                                                              							");
		sql.append("	WHERE                                                                                                                                                                                                         							");
		sql.append("	A.HOSP_CODE    = :f_hosp_code                                                                                                                                                                                 							");
		sql.append("	GROUP BY DATE_FORMAT(A.ACTING_DATE,'%Y')                                                                                                                                                                      							");
		sql.append("	UNION ALL                                                                                                                                                                                                     							");
		sql.append("	SELECT                                                                                                                                                                                                        							");
		sql.append("	'サブ合計２'                                                                                                             ACTING_DATE,                                                                              							");
		sql.append("	NULL                                                                                                                     O_CR_CNT_N,                                                                          							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END),0)                              I_CR_CNT_N,         							");
		sql.append("	NULL                                                                                                                     O_CR_CNT_Y,                                                                          							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END),0)                              I_CR_CNT_Y,         							");
		sql.append("	NULL                                                                                                                     O_BM_CNT_N,                                                                          							");
		sql.append("	IFNULL(SUM(CASE B.XRAY_CODE WHEN NULL THEN 1 END),0)                                                                                I_BM_CNT_N,                                                               							");
		sql.append("	NULL                                                                                                                     O_DR_CNT_N,                                                                          							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN IFNULL(B.XRAY_REAL_CNT,1) END END),0)                              I_DR_CNT_N,                                                    							");
		sql.append("	NULL                                                                                                                     O_DR_CNT_Y,                                                                          							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN IFNULL(B.XRAY_REAL_CNT,1) END END),0)                              I_DR_CNT_Y,                                                    							");
		sql.append("	NULL                                                                                                                     O_CT_CNT_N,                                                                          							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN IFNULL(B.XRAY_REAL_CNT,1) END END),0)                              I_CT_CNT_N,                                                    							");
		sql.append("	NULL                                                                                                                     O_CT_CNT_Y,                                                                          							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN IFNULL(B.XRAY_REAL_CNT,1) END END),0)                              I_CT_CNT_Y,                                                    							");
		sql.append("	NULL                                                                                                                     O_MRI_CNT_N,                                                                         							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN IFNULL(B.XRAY_REAL_CNT,1) END END),0)                              I_MRI_CNT_N,                                                  							");
		sql.append("	NULL                                                                                                                     O_MRI_CNT_Y,                                                                         							");
		sql.append("	IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN IFNULL(B.XRAY_REAL_CNT,1) END END),0)                              I_MRI_CNT_Y,                                                  							");
		sql.append("	SUM(CASE B.XRAY_CODE WHEN NULL THEN 1 ELSE IFNULL(B.XRAY_REAL_CNT,1) END)                                                               TOTAL_CNT,                                                            							");
		sql.append("	'2'                                                                                                                                                                                                           							");
		sql.append("	FROM                                                                                                                                                                                                          							");
		sql.append("		(                                                                                                                                                                                                         							");
		sql.append("			SELECT                                                                                                                                                                                                							");
		sql.append("				X.HOSP_CODE    AS HOSP_CODE,                                                                                                                                                                      							");
		sql.append("				X.HANGMOG_CODE AS HANGMOG_CODE,                                                                                                                                                                   							");
		sql.append("				X.ACTING_DATE  AS ACTING_DATE,                                                                                                                                                                    							");
		sql.append("				X.JUNDAL_PART  AS JUNDAL_PART,                                                                                                                                                                    							");
		sql.append("				'O'            AS IN_OUT_GUBUN                                                                                                                                                                    							");
		sql.append("			FROM                                                                                                                                                                                                  							");
		sql.append("	 			OCS1003 X                                                                                                                                                                                         							");
		sql.append("			WHERE X.HOSP_CODE    = :f_hosp_code                                                                                                                                                                   							");
		sql.append("				AND X.JUNDAL_TABLE = 'XRT'                                                                                                                                                                        							");
		sql.append("				AND X.JUNDAL_PART  LIKE '%'                                                                                                                                                                       							");
		sql.append("				AND X.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'0101'),'%Y%m%d') AND(STR_TO_DATE(CONCAT(:f_date,'1231'),'%Y%m%d'))                                                                         							");
		sql.append("				AND IFNULL(X.BANNAB_YN,'N') = 'N'                                                                                                                                                                 							");
		sql.append("				AND IFNULL(X.DC_YN,'N')     = 'N'                                                                                                                                                                 							");
		sql.append("				AND X.NALSU     > 0                                                                                                                                                                               							");
		sql.append("			UNION ALL                                                                                                                                                                                             							");
		sql.append("			SELECT                                                                                                                                                                                                							");
		sql.append("				Y.HOSP_CODE    AS HOSP_CODE,                                                                                                                                                                      							");
		sql.append("				Y.HANGMOG_CODE AS HANGMOG_CODE,                                                                                                                                                                   							");
		sql.append("				Y.ACTING_DATE  AS ACTING_DATE,                                                                                                                                                                    							");
		sql.append("				Y.JUNDAL_PART  AS JUNDAL_PART,                                                                                                                                                                    							");
		sql.append("				'I'            AS IN_OUT_GUBUN                                                                                                                                                                    							");
		sql.append("			FROM OCS2003 Y                                                                                                                                                                                        							");
		sql.append("			WHERE                                                                                                                                                                                                 							");
		sql.append("				Y.HOSP_CODE    = :f_hosp_code                                                                                                                                                                     							");
		sql.append("				AND Y.JUNDAL_TABLE = 'XRT'                                                                                                                                                                        							");
		sql.append("				AND Y.JUNDAL_PART  LIKE '%'                                                                                                                                                                       							");
		sql.append("				AND Y.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'0101'),'%Y%m%d') AND(STR_TO_DATE(CONCAT(:f_date,'1231'),'%Y%m%d'))                                                                         							");
		sql.append("				AND IFNULL(Y.BANNAB_YN,'N') = 'N'                                                                                                                                                                 							");
		sql.append("				AND IFNULL(Y.DC_YN,'N')     = 'N'                                                                                                                                                                 							");
		sql.append("				AND Y.NALSU     > 0) A                                                                                                                                                                            							");
		sql.append("			LEFT OUTER JOIN XRT0001 B                                                                                                                                                                             							");
		sql.append("			ON B.HOSP_CODE = A.HOSP_CODE                                                                                                                                                                          							");
		sql.append("			AND B.XRAY_CODE = A.HANGMOG_CODE                                                                                                                                                                      							");
		sql.append("		WHERE                                                                                                                                                                                                     							");
		sql.append("			A.HOSP_CODE    = :f_hosp_code                                                                                                                                                                         							");
		sql.append("		GROUP BY                                                                                                                                                                                                  							");
		sql.append("			DATE_FORMAT(A.ACTING_DATE,'%Y')                                                                                                                                                                       							");
		sql.append("		UNION ALL                                                                                                                                                                                                 							");
		sql.append("		SELECT                                                                                                                                                                                                    							");
		sql.append("	    '総合計'                                                                                                                 ACTING_DATE,                                                                        							");
		sql.append("	    NULL                                                                                                                     O_CR_CNT_N,                                                                      							");
		sql.append("	    NULL                                                                                                                     I_CR_CNT_N,                                                                      							");
		sql.append("	    NULL                                                                                                                     O_CR_CNT_Y,                                                                      							");
		sql.append("	    IFNULL(SUM(CASE A.JUNDAL_PART WHEN 'CR' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END),0)                           I_CR_CNT_Y,                                           							");
		sql.append("	    NULL                                                                                                                     O_BM_CNT_N,                                                                      							");
		sql.append("	    IFNULL(SUM(CASE B.XRAY_CODE WHEN NULL THEN 1 END),0)                                                                                I_BM_CNT_N,                                                           							");
		sql.append("	    NULL                                                                                                                     O_DR_CNT_N,                                                                      							");
		sql.append("	    NULL                                                                                                                     I_DR_CNT_N,                                                                      							");
		sql.append("	    NULL                                                                                                                     O_DR_CNT_Y,                                                                      							");
		sql.append("	    IFNULL(SUM(CASE A.JUNDAL_PART WHEN 'DR' THEN IFNULL(B.XRAY_REAL_CNT,1) END),0)                                                         I_DR_CNT_Y,                                                        							");
		sql.append("	    NULL                                                                                                                     O_CT_CNT_N,                                                                      							");
		sql.append("	    NULL                                                                                                                     I_CT_CNT_N,                                                                      							");
		sql.append("	    NULL                                                                                                                     O_CT_CNT_Y,                                                                      							");
		sql.append("	    IFNULL(SUM(CASE A.JUNDAL_PART WHEN 'CT' THEN IFNULL(B.XRAY_REAL_CNT,1) END),0)                                                         I_CT_CNT_Y,                                                        							");
		sql.append("	    NULL                                                                                                                     O_MRI_CNT_N,                                                                     							");
		sql.append("	    NULL                                                                                                                     I_MRI_CNT_N,                                                                     							");
		sql.append("	    NULL                                                                                                                     O_MRI_CNT_Y,                                                                     							");
		sql.append("	    IFNULL(SUM(CASE A.JUNDAL_PART WHEN 'MRI' THEN IFNULL(B.XRAY_REAL_CNT,1) END),0)                                                        I_MRI_CNT_Y,                                                       							");
		sql.append("	    SUM(CASE B.XRAY_CODE WHEN NULL THEN 1 ELSE IFNULL(B.XRAY_REAL_CNT,1) END)                                                               TOTAL_CNT,                                                        							");
		sql.append("	    '3'                                                                                                                                                                                                       							");
		sql.append("		FROM                                                                                                                                                                                                      							");
		sql.append("			(                                                                                                                                                                                                     							");
		sql.append("				SELECT                                                                                                                                                                                            							");
		sql.append("					X.HOSP_CODE    AS HOSP_CODE,                                                                                                                                                                  							");
		sql.append("					X.HANGMOG_CODE AS HANGMOG_CODE,                                                                                                                                                               							");
		sql.append("					X.ACTING_DATE  AS ACTING_DATE,                                                                                                                                                                							");
		sql.append("					X.JUNDAL_PART  AS JUNDAL_PART,                                                                                                                                                                							");
		sql.append("					'O'            AS IN_OUT_GUBUN                                                                                                                                                                							");
		sql.append("		   	FROM                                                                                                                                                                                                  							");
		sql.append("					OCS1003 X                                                                                                                                                                                     							");
		sql.append("		   	WHERE X.HOSP_CODE    = :f_hosp_code                                                                                                                                                                   							");
		sql.append("		   		AND X.JUNDAL_TABLE = 'XRT'                                                                                                                                                                        							");
		sql.append("		   		AND X.JUNDAL_PART  LIKE '%'                                                                                                                                                                       							");
		sql.append("		   		AND X.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'0101'),'%Y%m%d') AND(STR_TO_DATE(CONCAT(:f_date,'1231'),'%Y%m%d'))                                                                         							");
		sql.append("		   		AND IFNULL(X.BANNAB_YN,'N') = 'N'                                                                                                                                                                 							");
		sql.append("		   		AND IFNULL(X.DC_YN,'N')     = 'N'                                                                                                                                                                 							");
		sql.append("		   		AND X.NALSU     > 0                                                                                                                                                                               							");
		sql.append("		   	UNION ALL                                                                                                                                                                                             							");
		sql.append("		   	SELECT                                                                                                                                                                                                							");
		sql.append("					Y.HOSP_CODE    AS HOSP_CODE,                                                                                                                                                                  							");
		sql.append("					Y.HANGMOG_CODE AS HANGMOG_CODE,                                                                                                                                                               							");
		sql.append("					Y.ACTING_DATE  AS ACTING_DATE,                                                                                                                                                                							");
		sql.append("					Y.JUNDAL_PART  AS JUNDAL_PART,                                                                                                                                                                							");
		sql.append("					'I'            AS IN_OUT_GUBUN                                                                                                                                                                							");
		sql.append("		   	FROM                                                                                                                                                                                                  							");
		sql.append("					OCS2003 Y                                                                                                                                                                                     							");
		sql.append("		   	WHERE                                                                                                                                                                                                 							");
		sql.append("					Y.HOSP_CODE    = :f_hosp_code                                                                                                                                                                 							");
		sql.append("		   		AND Y.JUNDAL_TABLE = 'XRT'                                                                                                                                                                        							");
		sql.append("		   		AND Y.JUNDAL_PART  LIKE '%'                                                                                                                                                                       							");
		sql.append("		   		AND Y.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'0101'),'%Y%m%d') AND(STR_TO_DATE(CONCAT(:f_date,'1231'),'%Y%m%d'))                                                                         							");
		sql.append("		   		AND IFNULL(Y.BANNAB_YN,'N') = 'N'                                                                                                                                                                 							");
		sql.append("		   		AND IFNULL(Y.DC_YN,'N')     = 'N'                                                                                                                                                                 							");
		sql.append("		   		AND Y.NALSU     > 0) A                                                                                                                                                                            							");
		sql.append("			LEFT OUTER JOIN XRT0001 B                                                                                                                                                                             							");
		sql.append("			ON B.HOSP_CODE = A.HOSP_CODE                                                                                                                                                                          							");
		sql.append("			AND B.XRAY_CODE = A.HANGMOG_CODE                                                                                                                                                                      							");
		sql.append("		WHERE                                                                                                                                                                                                     							");
		sql.append("			A.HOSP_CODE    = :f_hosp_code                                                                                                                                                                         							");
		sql.append("		GROUP BY                                                                                                                                                                                                  							");
		sql.append("			DATE_FORMAT(A.ACTING_DATE,'%Y')                                                                                                                                                                       							");
		sql.append("		ORDER BY 21,1;                                                                                                                                                                                            							");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_date", date);
		
		List<XRT9001R06lay9006RInfo> listInfo = new JpaResultMapper().list(query, XRT9001R06lay9006RInfo.class);
		return listInfo;
	}

	@Override
	public List<XRT9001R05lay9005RInfo> getXRT9001R05lay9005RInfo(String hospCode, String date) {
		StringBuilder sql= new StringBuilder();
		sql.append("	 SELECT																																																					");
		sql.append("	    DATE_FORMAT(A.ACTING_DATE,'%Y/%m/%d')                                                                         	ACTING_DATE,																						");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) AS CHAR) O_CR_CNT_N,		");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) AS CHAR) I_CR_CNT_N,		");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) AS CHAR) O_CR_CNT_Y,		");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) AS CHAR) I_CR_CNT_Y,		");
		sql.append("	    CAST(IFNULL(SUM(CASE B.XRAY_CODE WHEN NULL THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN 1 END END),0) AS CHAR)                      O_BM_CNT_N,																							");
		sql.append("	    CAST(IFNULL(SUM(CASE B.XRAY_CODE WHEN NULL THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN 1 END END),0) AS CHAR)                      I_BM_CNT_N,																							");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) O_DR_CNT_N,													");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) I_DR_CNT_N,													");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) O_DR_CNT_Y,													");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) I_DR_CNT_Y,													");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) O_CT_CNT_N,													");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) I_CT_CNT_N,													");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) O_CT_CNT_Y,													");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) I_CT_CNT_Y,													");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) O_MRI_CNT_N,												");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) I_MRI_CNT_N,												");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) O_MRI_CNT_Y,												");
		sql.append("	    CAST(IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) AS CHAR) I_MRI_CNT_Y,												");
		sql.append("	    CAST(SUM(CASE B.XRAY_CODE WHEN NULL THEN 1 ELSE IFNULL(B.XRAY_REAL_CNT,1) END) AS CHAR) TOTAL_CNT,																																");
		sql.append("	    '0'																																																					");
		sql.append("	 FROM																																																					");
		sql.append("	    (SELECT X.HOSP_CODE    AS HOSP_CODE,																																												");
		sql.append("	 X.HANGMOG_CODE AS HANGMOG_CODE,																																														");
		sql.append("	 X.ACTING_DATE  AS ACTING_DATE,																																															");
		sql.append("	 X.JUNDAL_PART  AS JUNDAL_PART,																																															");
		sql.append("	 'O'            AS IN_OUT_GUBUN																																															");
		sql.append("	    FROM OCS1003 X																																																		");
		sql.append("	    WHERE X.HOSP_CODE    = :f_hosp_code																																													");
		sql.append("	    AND X.JUNDAL_TABLE = 'XRT'																																															");
		sql.append("	    AND X.JUNDAL_PART  LIKE '%'																																															");
		sql.append("	    AND X.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'01'),'%Y%m%d') AND LAST_DAY(STR_TO_DATE(:f_date,'%Y%m'))																										");
		sql.append("	    AND IFNULL(X.BANNAB_YN,'N') = 'N'																																													");
		sql.append("	    AND IFNULL(X.DC_YN,'N')     = 'N'																																													");
		sql.append("	    AND X.NALSU     > 0																																																	");
		sql.append("	    UNION ALL																																																			");
		sql.append("	    SELECT Y.HOSP_CODE    AS HOSP_CODE,																																													");
		sql.append("	 Y.HANGMOG_CODE AS HANGMOG_CODE,																																														");
		sql.append("	 Y.ACTING_DATE  AS ACTING_DATE,																																															");
		sql.append("	 Y.JUNDAL_PART  AS JUNDAL_PART,																																															");
		sql.append("	 'I'            AS IN_OUT_GUBUN																																															");
		sql.append("	    FROM OCS2003 Y																																																		");
		sql.append("	    WHERE Y.HOSP_CODE    = :f_hosp_code																																													");
		sql.append("	    AND Y.JUNDAL_TABLE = 'XRT'																																															");
		sql.append("	    AND Y.JUNDAL_PART  LIKE '%'																																															");
		sql.append("	    AND Y.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'01'),'%Y%m%d') AND LAST_DAY(STR_TO_DATE(:f_date,'%Y%m'))																										");
		sql.append("	    AND IFNULL(Y.BANNAB_YN,'N') = 'N'																																													");
		sql.append("	    AND IFNULL(Y.DC_YN,'N')     = 'N'																																													");
		sql.append("	    AND Y.NALSU     > 0) A LEFT OUTER JOIN XRT0001 B ON B.HOSP_CODE = A.HOSP_CODE AND B.XRAY_CODE = A.HANGMOG_CODE																										");
		sql.append("	 WHERE A.HOSP_CODE    = :f_hosp_code																																													");
		sql.append("	 GROUP BY DATE_FORMAT(A.ACTING_DATE,'%Y/%m/%d')																																											");
		sql.append("	 UNION ALL																																																				");
		sql.append("	 SELECT 'サブ合計１'                                                                                                     ACTING_DATE,																						");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) O_CR_CNT_N,			");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) I_CR_CNT_N,			");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) O_CR_CNT_Y,			");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END END),0) I_CR_CNT_Y,			");
		sql.append("	 IFNULL(SUM(CASE B.XRAY_CODE WHEN NULL THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN 1 END END),0)                         O_BM_CNT_N,																							");
		sql.append("	 IFNULL(SUM(CASE B.XRAY_CODE WHEN NULL THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN 1 END END),0)                         I_BM_CNT_N,																							");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) O_DR_CNT_N,													");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) I_DR_CNT_N,													");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) O_DR_CNT_Y,													");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) I_DR_CNT_Y,													");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) O_CT_CNT_N,													");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) I_CT_CNT_N,													");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) O_CT_CNT_Y,													");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) I_CT_CNT_Y,													");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) O_MRI_CNT_N,													");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) I_MRI_CNT_N,													");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'O' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) O_MRI_CNT_Y,													");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN CASE A.IN_OUT_GUBUN WHEN 'I' THEN IFNULL(B.XRAY_REAL_CNT,1) END END END),0) I_MRI_CNT_Y,													");
		sql.append("	 SUM(CASE B.XRAY_CODE WHEN NULL THEN 1 ELSE IFNULL(B.XRAY_REAL_CNT,1) END) TOTAL_CNT,																																	");
		sql.append("	 '1'																																																					");
		sql.append("	 FROM(SELECT X.HOSP_CODE    AS HOSP_CODE,																																												");
		sql.append("	 X.HANGMOG_CODE AS HANGMOG_CODE,																																														");
		sql.append("	 X.ACTING_DATE  AS ACTING_DATE,																																															");
		sql.append("	 X.JUNDAL_PART  AS JUNDAL_PART,																																															");
		sql.append("	 'O'            AS IN_OUT_GUBUN																																															");
		sql.append("	    FROM OCS1003 X																																																		");
		sql.append("	    WHERE X.HOSP_CODE    = :f_hosp_code																																													");
		sql.append("	    AND X.JUNDAL_TABLE = 'XRT'																																															");
		sql.append("	    AND X.JUNDAL_PART  LIKE '%'																																															");
		sql.append("	    AND X.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'01'),'%Y%m%d') AND LAST_DAY(STR_TO_DATE(:f_date,'%Y%m'))																										");
		sql.append("	    AND IFNULL(X.BANNAB_YN,'N') = 'N'																																													");
		sql.append("	    AND IFNULL(X.DC_YN,'N')     = 'N'																																													");
		sql.append("	    AND X.NALSU     > 0																																																	");
		sql.append("	    UNION ALL																																																			");
		sql.append("	    SELECT Y.HOSP_CODE    AS HOSP_CODE,																																													");
		sql.append("	 Y.HANGMOG_CODE AS HANGMOG_CODE,																																														");
		sql.append("	 Y.ACTING_DATE  AS ACTING_DATE,																																															");
		sql.append("	 Y.JUNDAL_PART  AS JUNDAL_PART,																																															");
		sql.append("	 'I'            AS IN_OUT_GUBUN																																															");
		sql.append("	    FROM OCS2003 Y																																																		");
		sql.append("	    WHERE Y.HOSP_CODE    = :f_hosp_code																																													");
		sql.append("	    AND Y.JUNDAL_TABLE = 'XRT'																																															");
		sql.append("	    AND Y.JUNDAL_PART  LIKE '%'																																															");
		sql.append("	    AND Y.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'01'),'%Y%m%d') AND LAST_DAY(STR_TO_DATE(:f_date,'%Y%m'))																										");
		sql.append("	    AND IFNULL(Y.BANNAB_YN,'N') = 'N'																																													");
		sql.append("	    AND IFNULL(Y.DC_YN,'N')     = 'N'																																													");
		sql.append("	    AND Y.NALSU     > 0) A LEFT OUTER JOIN XRT0001 B ON B.HOSP_CODE = A.HOSP_CODE AND B.XRAY_CODE = A.HANGMOG_CODE																										");
		sql.append("	 WHERE A.HOSP_CODE    = :f_hosp_code																																													");
		sql.append("	 GROUP BY DATE_FORMAT(A.ACTING_DATE,'%Y/%m')																																											");
		sql.append("	 UNION ALL																																																				");
		sql.append("	 SELECT 																																																				");
		sql.append("	 	'サブ合計２'                                                                                                             	ACTING_DATE,																				");
		sql.append("	 NULL                                                                                                                     	O_CR_CNT_N,																					");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END),0)                              I_CR_CNT_N,					");
		sql.append("	 NULL                                                                                                                     	O_CR_CNT_Y,																					");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CR' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END END),0)                              I_CR_CNT_Y,					");
		sql.append("	 NULL                                                                                                                     	O_BM_CNT_N,																					");
		sql.append("	 IFNULL(SUM(CASE B.XRAY_CODE WHEN NULL THEN 1 END),0)                                                                       I_BM_CNT_N,																					");
		sql.append("	 NULL                                                                                                                     	O_DR_CNT_N,																					");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN IFNULL(B.XRAY_REAL_CNT,1) END END),0)          I_DR_CNT_N,																					");
		sql.append("	 NULL                                                                                                                     	O_DR_CNT_Y,																					");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'DR' THEN IFNULL(B.XRAY_REAL_CNT,1) END END),0)          I_DR_CNT_Y,																					");
		sql.append("	 NULL                                                                                                                     	O_CT_CNT_N,																					");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN IFNULL(B.XRAY_REAL_CNT,1) END END),0)          I_CT_CNT_N,																					");
		sql.append("	 NULL                                                                                                                     	O_CT_CNT_Y,																					");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'CT' THEN IFNULL(B.XRAY_REAL_CNT,1) END END),0)          I_CT_CNT_Y,																					");
		sql.append("	 NULL                                                                                                                     	O_MRI_CNT_N,																				");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'N' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN IFNULL(B.XRAY_REAL_CNT,1) END END),0)         I_MRI_CNT_N,																				");
		sql.append("	 NULL                                                                                                                     	O_MRI_CNT_Y,																				");
		sql.append("	 IFNULL(SUM(CASE B.JAERYO_YN WHEN 'Y' THEN CASE A.JUNDAL_PART WHEN 'MRI' THEN IFNULL(B.XRAY_REAL_CNT,1) END END),0)         I_MRI_CNT_Y,																				");
		sql.append("	 SUM(CASE B.XRAY_CODE WHEN NULL THEN 1 ELSE IFNULL(B.XRAY_REAL_CNT,1) END)                                                  TOTAL_CNT,																					");
		sql.append("	 '2'																																																					");
		sql.append("	 FROM(SELECT X.HOSP_CODE    AS HOSP_CODE,																																												");
		sql.append("	 X.HANGMOG_CODE AS HANGMOG_CODE,																																														");
		sql.append("	 X.ACTING_DATE  AS ACTING_DATE,																																															");
		sql.append("	 X.JUNDAL_PART  AS JUNDAL_PART,																																															");
		sql.append("	 'O'            AS IN_OUT_GUBUN																																															");
		sql.append("	    FROM OCS1003 X																																																		");
		sql.append("	    WHERE X.HOSP_CODE    = :f_hosp_code																																													");
		sql.append("	    AND X.JUNDAL_TABLE = 'XRT'																																															");
		sql.append("	    AND X.JUNDAL_PART  LIKE '%'																																															");
		sql.append("	    AND X.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'01'),'%Y%m%d') AND LAST_DAY(STR_TO_DATE(:f_date,'%Y%m'))																										");
		sql.append("	    AND IFNULL(X.BANNAB_YN,'N') = 'N'																																													");
		sql.append("	    AND IFNULL(X.DC_YN,'N')     = 'N'																																													");
		sql.append("	    AND X.NALSU     > 0																																																	");
		sql.append("	    UNION ALL																																																			");
		sql.append("	    SELECT Y.HOSP_CODE    AS HOSP_CODE,																																													");
		sql.append("	 Y.HANGMOG_CODE AS HANGMOG_CODE,																																														");
		sql.append("	 Y.ACTING_DATE  AS ACTING_DATE,																																															");
		sql.append("	 Y.JUNDAL_PART  AS JUNDAL_PART,																																															");
		sql.append("	 'I'            AS IN_OUT_GUBUN																																															");
		sql.append("	    FROM OCS2003 Y																																																		");
		sql.append("	    WHERE Y.HOSP_CODE    = :f_hosp_code																																													");
		sql.append("	    AND Y.JUNDAL_TABLE = 'XRT'																																															");
		sql.append("	    AND Y.JUNDAL_PART  LIKE '%'																																															");
		sql.append("	    AND Y.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'01'),'%Y%m%d') AND LAST_DAY(STR_TO_DATE(:f_date,'%Y%m'))																										");
		sql.append("	    AND IFNULL(Y.BANNAB_YN,'N') = 'N'																																													");
		sql.append("	    AND IFNULL(Y.DC_YN,'N')     = 'N'																																													");
		sql.append("	    AND Y.NALSU     > 0) A LEFT OUTER JOIN XRT0001 B ON B.HOSP_CODE = A.HOSP_CODE AND B.XRAY_CODE = A.HANGMOG_CODE																										");
		sql.append("	 WHERE A.HOSP_CODE    = :f_hosp_code																																													");
		sql.append("	 GROUP BY DATE_FORMAT(A.ACTING_DATE,'%Y/%m')																																											");
		sql.append("	 UNION ALL																																																				");
		sql.append("	 SELECT '総合計'                                                                                                             	ACTING_DATE,																				");
		sql.append("	 NULL                                                                                                                     	O_CR_CNT_N,																					");
		sql.append("	 NULL                                                                                                                     	I_CR_CNT_N,																					");
		sql.append("	 NULL                                                                                                                     	O_CR_CNT_Y,																					");
		sql.append("	 IFNULL(SUM(CASE A.JUNDAL_PART WHEN 'CR' THEN IFNULL(B.XRAY_REAL_CNT,CASE B.XRAY_CODE WHEN NULL THEN 0 ELSE 1 END) END),0)  I_CR_CNT_Y,																					");
		sql.append("	 NULL                                                                                                                     	O_BM_CNT_N,																					");
		sql.append("	 IFNULL(SUM(CASE B.XRAY_CODE WHEN NULL THEN 1 END),0)                                                                       I_BM_CNT_N,																					");
		sql.append("	 NULL                                                                                                                     	O_DR_CNT_N,																					");
		sql.append("	 NULL                                                                                                                     	I_DR_CNT_N,																					");
		sql.append("	 NULL                                                                                                                     	O_DR_CNT_Y,																					");
		sql.append("	 IFNULL(SUM(CASE A.JUNDAL_PART WHEN 'DR' THEN IFNULL(B.XRAY_REAL_CNT,1) END),0)                                             I_DR_CNT_Y,																					");
		sql.append("	 NULL                                                                                                                     	O_CT_CNT_N,																					");
		sql.append("	 NULL                                                                                                                     	I_CT_CNT_N,																					");
		sql.append("	 NULL                                                                                                                     	O_CT_CNT_Y,																					");
		sql.append("	 IFNULL(SUM(CASE A.JUNDAL_PART WHEN 'CT' THEN IFNULL(B.XRAY_REAL_CNT,1) END),0)                                             I_CT_CNT_Y,																					");
		sql.append("	 NULL                                                                                                                     	O_MRI_CNT_N,																				");
		sql.append("	 NULL                                                                                                                     	I_MRI_CNT_N,																				");
		sql.append("	 NULL                                                                                                                     	O_MRI_CNT_Y,																				");
		sql.append("	 IFNULL(SUM(CASE A.JUNDAL_PART WHEN 'MRI' THEN IFNULL(B.XRAY_REAL_CNT,1) END),0)                                            I_MRI_CNT_Y,																				");
		sql.append("	 SUM(CASE B.XRAY_CODE WHEN NULL THEN 1 ELSE IFNULL(B.XRAY_REAL_CNT,1) END)                                                  TOTAL_CNT,																					");
		sql.append("	 '3'																																																					");
		sql.append("	 FROM(SELECT X.HOSP_CODE    AS HOSP_CODE,																																												");
		sql.append("	 X.HANGMOG_CODE AS HANGMOG_CODE,																																														");
		sql.append("	 X.ACTING_DATE  AS ACTING_DATE,																																															");
		sql.append("	 X.JUNDAL_PART  AS JUNDAL_PART,																																															");
		sql.append("	 'O'            AS IN_OUT_GUBUN																																															");
		sql.append("	    FROM OCS1003 X																																																		");
		sql.append("	    WHERE X.HOSP_CODE    = :f_hosp_code																																													");
		sql.append("	    AND X.JUNDAL_TABLE = 'XRT'																																															");
		sql.append("	    AND X.JUNDAL_PART  LIKE '%'																																															");
		sql.append("	    AND X.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'01'),'%Y%m%d') AND LAST_DAY(STR_TO_DATE(:f_date,'%Y%m'))																										");
		sql.append("	    AND IFNULL(X.BANNAB_YN,'N') = 'N'																																													");
		sql.append("	    AND IFNULL(X.DC_YN,'N')     = 'N'																																													");
		sql.append("	    AND X.NALSU     > 0																																																	");
		sql.append("	    UNION ALL																																																			");
		sql.append("	    SELECT Y.HOSP_CODE    AS HOSP_CODE,																																													");
		sql.append("	 Y.HANGMOG_CODE AS HANGMOG_CODE,																																														");
		sql.append("	 Y.ACTING_DATE  AS ACTING_DATE,																																															");
		sql.append("	 Y.JUNDAL_PART  AS JUNDAL_PART,																																															");
		sql.append("	 'I'            AS IN_OUT_GUBUN																																															");
		sql.append("	    FROM OCS2003 Y																																																		");
		sql.append("	    WHERE Y.HOSP_CODE    = :f_hosp_code																																													");
		sql.append("	    AND Y.JUNDAL_TABLE = 'XRT'																																															");
		sql.append("	    AND Y.JUNDAL_PART  LIKE '%'																																															");
		sql.append("	    AND Y.ACTING_DATE  BETWEEN STR_TO_DATE(CONCAT(:f_date,'01'),'%Y%m%d') AND LAST_DAY(STR_TO_DATE(:f_date,'%Y%m'))																										");
		sql.append("	    AND IFNULL(Y.BANNAB_YN,'N') = 'N'																																													");
		sql.append("	    AND IFNULL(Y.DC_YN,'N')     = 'N'																																													");
		sql.append("	    AND Y.NALSU     > 0) A LEFT OUTER JOIN XRT0001 B ON B.HOSP_CODE = A.HOSP_CODE AND B.XRAY_CODE = A.HANGMOG_CODE																										");
		sql.append("	 WHERE A.HOSP_CODE    = :f_hosp_code																																													");
		sql.append("	 GROUP BY DATE_FORMAT(A.ACTING_DATE,'%Y/%m')																																											");
		sql.append("	 ORDER BY 21,1																																																			");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_date", date);
		
		List<XRT9001R05lay9005RInfo> listInfo = new JpaResultMapper().list(query, XRT9001R05lay9005RInfo.class);
		return listInfo;
	}

}

