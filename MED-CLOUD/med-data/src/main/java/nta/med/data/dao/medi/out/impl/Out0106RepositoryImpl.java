
package nta.med.data.dao.medi.out.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.out.Out0106RepositoryCustom;
import nta.med.data.model.ihis.endo.END1001U02GrdComment3Info;
import nta.med.data.model.ihis.nuri.NUR1001U00GrdOUT0106Info;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdCommentsInfo;
import nta.med.data.model.ihis.nuro.OUT0106U00GridItemInfo;
import nta.med.data.model.ihis.ocso.FwPaCommentGrdCmmtFwkInfo;
import nta.med.data.model.ihis.system.DetailPaInfoFormGridCommentInfo;
import nta.med.data.model.ihis.xrts.XRT1002U00GrdCommentInfo;

/**
 * @author dainguyen.
 */
public class Out0106RepositoryImpl implements Out0106RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<DetailPaInfoFormGridCommentInfo> getDetailPaInfoFormGridComment(String hospCode, String patientCode){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.COMMENTS                  ");
		sql.append("FROM OUT0106 A                     ");
		sql.append("WHERE A.HOSP_CODE  = :f_hosp_code  ");
		//sql.append("WHERE A.HOSP_CODE  = 'XXX'       ");
		sql.append("  AND A.BUNHO = :patientCode       ");
		sql.append("ORDER BY A.SER DESC                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("patientCode", patientCode);
		query.setParameter("f_hosp_code", hospCode);

		List<DetailPaInfoFormGridCommentInfo> list = new JpaResultMapper().list(query, DetailPaInfoFormGridCommentInfo.class);
		return list;
	}
	
	@Override
	public List<OUT0106U00GridItemInfo> getOUT0106U00GridItemInfo(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.COMMENTS       COMMENTS               ");
		sql.append("     , A.SER            SER                    ");
		sql.append("     , A.BUNHO          BUNHO                  ");
		sql.append("     , A.DISPLAY_YN     DISPLAY_YN             ");
		sql.append("  FROM OUT0106 A                               ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code              ");
		sql.append("   AND A.BUNHO     = :f_bunho                  ");
		sql.append("   AND A.CMMT_GUBUN = 'B'                      ");
		sql.append(" ORDER BY CONCAT(A.BUNHO ,LPAD(A.SER,10,'0'))  ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);

		List<OUT0106U00GridItemInfo> list = new JpaResultMapper().list(query, OUT0106U00GridItemInfo.class);
		return list;
	}
	
	@Override
	public Double getSerOUT0106U00SaveComments(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT IFNULL(MAX(SER), 0) + 1 SER ");
		sql.append("    FROM OUT0106                   ");
		sql.append("   WHERE HOSP_CODE = :f_hosp_code  ");
		sql.append("     AND BUNHO = :f_bunho          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<Double> list = query.getResultList();
		if( list != null && list.size() > 0){
			return list.get(0);
		}
		
		return null;
	}
	
	@Override
	public List<String> getPatientSpecificComment(String hospCode, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT COMMENTS FROM  VW_OUT_OUT0106_OCS ");
		sql.append(" WHERE HOSP_CODE = :f_hosp_code          ");
		sql.append("   AND BUNHO     = :f_bunho              ");
		sql.append(" ORDER BY SER DESC                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		
		List<String> list = query.getResultList();
		return list;
	}

	@Override
	public List<FwPaCommentGrdCmmtFwkInfo> getFwBizObjectXPaCommentLayCmmtGubunfwkInfo(
			String hospCode, String bunho, String commtGubun,
			String jundalTable, String jundalPart, Double fkocs) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.COMMENTS       COMMENTS                                                                                                               ");
		sql.append("      , A.DISPLAY_YN     DISPLAY_YN                                                                                                             ");
		sql.append("      , A.BUNHO          BUNHO                                                                                                                  ");
		sql.append("      , A.CMMT_GUBUN     CMMT_GUBUN                                                                                                             ");
		sql.append("      , A.JUNDAL_TABLE   JUNDAL_TABLE                                                                                                           ");
		sql.append("      , A.JUNDAL_PART    JUNDAL_PART                                                                                                            ");
		sql.append("      , A.IN_OUT_GUBUN   IN_OUT_GUBUN                                                                                                           ");
		sql.append("      , A.FKOCS          FKOCS                                                                                                                  ");
		sql.append("      , A.HANGMOG_CODE   HANGMOG_CODE                                                                                                           ");
		sql.append("      , A.SER            SER                                                                                                                    ");
		sql.append("   FROM OUT0106 A                                                                                                                               ");
		sql.append("  WHERE A.HOSP_CODE       = :f_hosp_code                                                                                                        ");
		sql.append("    AND A.BUNHO           = :f_bunho                                                                                                            ");
		sql.append("    AND (    A.CMMT_GUBUN = :f_cmmt_gubun                                                                                                       ");
		sql.append("        OR ( A.CMMT_GUBUN = :f_cmmt_gubun AND A.JUNDAL_TABLE = :f_jundal_table AND A.JUNDAL_PART = :f_jundal_part )                             ");
		sql.append("        OR ( A.CMMT_GUBUN = :f_cmmt_gubun AND A.JUNDAL_TABLE = :f_jundal_table AND A.JUNDAL_PART = :f_jundal_part AND A.FKOCS = :f_fkocs ))     ");
		sql.append("  ORDER BY A.SER																																");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_cmmt_gubun", commtGubun);
		query.setParameter("f_jundal_table", jundalTable);
		query.setParameter("f_jundal_part", jundalPart);
		query.setParameter("f_fkocs", fkocs);
		List<FwPaCommentGrdCmmtFwkInfo> list = new JpaResultMapper().list(query, FwPaCommentGrdCmmtFwkInfo.class);
		return list;
	}

	@Override
	public List<XRT1002U00GrdCommentInfo> getXRT1002U00GrdComment(String hospCode, String bunho, String cmmtGubun, String jundalTable) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT COMMENTS  FROM OUT0106 WHERE HOSP_CODE  = :f_hosp_code            ");
		sql.append(" AND BUNHO     = :f_bunho   AND CMMT_GUBUN = :f_cmmtGubun                 ");
		if(!StringUtils.isEmpty(jundalTable)){
			sql.append(" AND JUNDAL_TABLE = :f_jundalTable                                    ");
		}
		sql.append(" ORDER BY SER                                                             ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_cmmtGubun", cmmtGubun);
		if(!StringUtils.isEmpty(jundalTable)){
			query.setParameter("f_jundalTable", jundalTable);
		}
		List<XRT1002U00GrdCommentInfo> list = new JpaResultMapper().list(query, XRT1002U00GrdCommentInfo.class);
		return list;
	}
	
	@Override
	public List<String> getXRT1002U00LayOrderDate(String hospCode, String jundalTable, String bunho){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT DATE_FORMAT(B.ORDER_DATE, '%Y/%m/%d')   ");
		sql.append("  FROM OUT0106 A                               ");
		sql.append("     , OCS1003 B                               ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code           ");
		sql.append("   AND B.HOSP_CODE    = A.HOSP_CODE            ");
		sql.append("   AND A.BUNHO        = :f_bunho               ");
		sql.append("   AND A.CMMT_GUBUN   = 'O'                    ");
		sql.append("   AND A.JUNDAL_TABLE = :f_jundal_table        ");
		sql.append("   AND A.IN_OUT_GUBUN = 'O'                    ");
		sql.append("   AND A.FKOCS        = B.PKOCS1003            ");
		sql.append(" UNION                                         ");
		sql.append("SELECT DATE_FORMAT(B.ORDER_DATE, '%Y/%m/%d')   ");
		sql.append("  FROM OUT0106 A                               ");
		sql.append("     , OCS2003 B                               ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code           ");
		sql.append("   AND B.HOSP_CODE    = A.HOSP_CODE            ");
		sql.append("   AND A.BUNHO        = :f_bunho               ");
		sql.append("   AND A.CMMT_GUBUN   = 'O'                    ");
		sql.append("   AND A.JUNDAL_TABLE = :f_jundal_table        ");
		sql.append("   AND A.IN_OUT_GUBUN = 'I'                    ");
		sql.append("   AND A.FKOCS        = B.PKOCS2003            ");
		sql.append(" ORDER BY 1                                    ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_jundal_table", bunho);
		query.setParameter("f_bunho", bunho);
		
		List<String> list = query.getResultList();
		return list;
	}

	@Override
	public List<ORDERTRANSGrdCommentsInfo> getORDERTRANSGrdCommentsInfo(
			String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.BUNHO, A.SER, A.COMMENTS  FROM OUT0106 A WHERE A.HOSP_CODE = :f_hosp_code   AND A.BUNHO     = :f_bunho ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		List<ORDERTRANSGrdCommentsInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdCommentsInfo.class);
		return list;
	}

	@Override
	public List<END1001U02GrdComment3Info> getEND1001U02GrdComment3Info(
			String hospCode, String bunho, Date orderDate) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.COMMENTS                          ");
		sql.append("     , '1'                                  ");
		sql.append("     , A.SER                                ");
		sql.append("  FROM OUT0106 A                            ");
		sql.append("     , OCS1003 B                            ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code        ");
		sql.append("   AND B.HOSP_CODE    = A.HOSP_CODE         ");
		sql.append("   AND A.BUNHO        = :f_bunho            ");
		sql.append("   AND A.CMMT_GUBUN   = 'O'                 ");
		sql.append("   AND A.JUNDAL_TABLE = 'PFE'               ");
		sql.append("   AND A.IN_OUT_GUBUN = 'O'                 ");
		sql.append("   AND A.FKOCS        = B.PKOCS1003         ");
		sql.append("   AND B.ORDER_DATE   = :f_order_date       ");
		sql.append(" UNION                                      ");
		sql.append("SELECT A.COMMENTS                           ");
		sql.append("     , '2'                                  ");
		sql.append("     , A.SER                                ");
		sql.append("  FROM OUT0106 A                            ");
		sql.append("     , OCS2003 B                            ");
		sql.append(" WHERE A.HOSP_CODE    = :f_hosp_code        ");
		sql.append("   AND B.HOSP_CODE    = A.HOSP_CODE         ");
		sql.append("   AND A.BUNHO        = :f_bunho            ");
		sql.append("   AND A.CMMT_GUBUN   = 'O'                 ");
		sql.append("   AND A.JUNDAL_TABLE = 'PFE'               ");
		sql.append("   AND A.IN_OUT_GUBUN = 'I'                 ");
		sql.append("   AND A.FKOCS        = B.PKOCS2003         ");
		sql.append("   AND B.ORDER_DATE   = :f_order_date       ");
		sql.append(" ORDER BY 2, 3								");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_order_date", orderDate);
		List<END1001U02GrdComment3Info> list = new JpaResultMapper().list(query, END1001U02GrdComment3Info.class);
		return list;
	}
	
	@Override
	public List<NUR1001U00GrdOUT0106Info> getNUR1001U00GrdOUT0106Info(String hospCode, String bunho, Integer startNum, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("   SELECT A.COMMENTS       COMMENTS                            ");
		sql.append("        , CAST(A.SER AS CHAR) SER                              ");
		sql.append("        , A.DISPLAY_YN     DISPLAY_YN                          ");
		sql.append("        , ''               DATA_ROW_STATE                      ");
		sql.append("     FROM OUT0106 A                                            ");
		sql.append("    WHERE A.HOSP_CODE = :f_hosp_code                           ");
		sql.append("      AND A.BUNHO     = :f_bunho                               ");
		sql.append("      AND A.CMMT_GUBUN = 'B'                                   ");
		sql.append("    ORDER BY CONCAT(A.BUNHO, LTRIM(LPAD(A.SER, 10, '0')))      ");
		if(startNum != null && offset !=null){
			sql.append(" LIMIT :f_startNum, :f_offset							   ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		if(startNum != null && offset !=null){
			query.setParameter("f_startNum", startNum);
			query.setParameter("f_offset", offset);
		}

		List<NUR1001U00GrdOUT0106Info> list = new JpaResultMapper().list(query, NUR1001U00GrdOUT0106Info.class);
		return list;
	}
}

