package nta.med.data.dao.medi.out.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import org.springframework.util.CollectionUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.out.Out1003RepositoryCustom;
import nta.med.data.model.ihis.nuro.NuroORDERTRANSUpdateOCS1003SelectToInsert;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListSendYnInfo;

/**
 * @author dainguyen.
 */
public class Out1003RepositoryImpl implements Out1003RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;
	@Override
	public List<ORDERTRANSGrdListSendYnInfo> getORDERTRANSGrdListSendYnInfo(
			String hospCode, String language, String bunho) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT A.PKOUT1003                                                 FKOUT1001                              ");
		sql.append("            , A.BUNHO                                                       BUNHO                          ");
		sql.append("            , C.SUNAME                                                      SUNAME                         ");
		sql.append("            , A.ACTING_DATE                                                 ACTING_DATE                    ");
		sql.append("            , A.GWA                                                         GWA                            ");
		sql.append("            , FN_BAS_LOAD_GWA_NAME ( A.GWA, A.ACTING_DATE ,:f_hosp_code, :f_language)        GWA_NAME      ");
		sql.append("            , A.DOCTOR                                                      DOCTOR                         ");
		sql.append("            , FN_BAS_LOAD_DOCTOR_NAME ( A.DOCTOR, A.ACTING_DATE, :f_hosp_code)            DOCTOR_NAME      ");                       
		sql.append("            , A.GUBUN                                                       GUBUN                          ");
		sql.append("            , FN_BAS_LOAD_GUBUN_NAME(IFNULL(MAX(B.GUBUN), '##') , SYSDATE(), :f_hosp_code) GUBUN_NAME      ");
		sql.append("            ,CONCAT( DATE_FORMAT(A.ACTING_DATE, '%Y%m%d')                                                  ");
		sql.append("          , A.GWA                                                                                          ");
		sql.append("          , A.DOCTOR                                                                                       ");
		sql.append("          , A.GUBUN )                                               ORDER_BY_KEY                           ");
		sql.append("		  , A.FKOUT1001 as 	PKOUT1001																	   ");
		sql.append("    FROM OUT1003 A LEFT JOIN OUT1001 B ON  B.HOSP_CODE = A.HOSP_CODE                                       ");
		sql.append("                         AND B.BUNHO  = A.BUNHO AND B.PKOUT1001= A.FKOUT1001                               ");
		sql.append("       , OUT0101 C                                                                                         ");
		sql.append("     WHERE A.HOSP_CODE = :f_hosp_code                                                                      ");
		sql.append("       AND A.BUNHO     = :f_bunho                                                                          ");
		sql.append("       AND C.HOSP_CODE = A.HOSP_CODE                                                                       ");
		sql.append("       AND C.BUNHO     = A.BUNHO                                                                           ");
		sql.append("                                                                                                           ");
		sql.append("       AND EXISTS (SELECT 'Y' FROM OCS1003 Z WHERE Z.HOSP_CODE = A.HOSP_CODE                               ");
		sql.append("                                               AND Z.BUNHO     = A.BUNHO                                   ");
		sql.append("                                               AND Z.FKOUT1003 = A.PKOUT1003                               ");
		sql.append("                                               AND Z.IF_DATA_SEND_YN = 'Y')                                ");
		sql.append("      GROUP BY A.PKOUT1003                                                                                 ");
		sql.append("            ,  A.BUNHO                                                                                     ");
		sql.append("            , C.SUNAME                                                                                     ");
		sql.append("            , A.ACTING_DATE                                                                                ");
		sql.append("            , A.GWA                                                                                        ");
		sql.append("            , FN_BAS_LOAD_GWA_NAME ( A.GWA, A.ACTING_DATE ,:f_hosp_code, :f_language)                      ");
		sql.append("            , A.DOCTOR                                                                                     ");
		sql.append("            , FN_BAS_LOAD_DOCTOR_NAME ( A.DOCTOR, A.ACTING_DATE, :f_hosp_code)                             ");
		sql.append("            , A.GUBUN                                                                                      ");
		sql.append("            ,CONCAT( DATE_FORMAT(A.ACTING_DATE, '%Y%m%d')                                                  ");
		sql.append("              , A.GWA                                                                                      ");
		sql.append("              , A.DOCTOR )                                                                                 ");
		sql.append("    ORDER BY ORDER_BY_KEY DESC															                   ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		query.setParameter("f_bunho", bunho);
		
		List<ORDERTRANSGrdListSendYnInfo> list = new JpaResultMapper().list(query, ORDERTRANSGrdListSendYnInfo.class);
		return list;
	}
	
	@Override
	public Integer callPrIfsOutOrderMasterInsert(String hospCode, String bunho, Date actingDate, String gubun,
			String gwa, String doctor, String chojae) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_IFS_OUT_ORDER_MASTER_INSERT");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_ACTING_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GWA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DOCTOR", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CHOJAE", String.class, ParameterMode.IN);
		
		query.registerStoredProcedureParameter("O_PK", Integer.class, ParameterMode.OUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_ACTING_DATE", actingDate);
		query.setParameter("I_GUBUN", gubun);
		query.setParameter("I_GWA", gwa);
		query.setParameter("I_DOCTOR", doctor);
		query.setParameter("I_CHOJAE", chojae);
		
		query.execute();
		Integer opk = (Integer)query.getOutputParameterValue("O_PK");
		return opk;
	}

	@Override
	public List<NuroORDERTRANSUpdateOCS1003SelectToInsert> getNuroORDERTRANSUpdateOCS1003SelectToInsert(String hospCode, String bunho, 
			Double pkout1001, boolean orderTrans, boolean isMisa) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT                                                                                ");
		if(!orderTrans){                                                                                   
			sql.append(" OCS1003.ACTING_DATE,                                                              ");
		}else{                                                                                             
			sql.append(" OCS1003.SYS_DATE,                                                                 ");
		}                                                                                                  
		sql.append(" OCS1003.BUNHO,                                                                        ");
		sql.append(" OUT1001.GUBUN,                                                                        ");
		sql.append(" OCS1003.GWA,                                                                          ");
		sql.append(" OCS1003.DOCTOR,                                                                       ");
		sql.append(" OUT1001.CHOJAE,                                                                       ");
		sql.append(" OCS1003.SEQ                                                                           ");
		sql.append(" FROM OCS1003                                                                          ");
		sql.append("  INNER JOIN OUT1001 ON OCS1003.FKOUT1001 = OUT1001.PKOUT1001                          ");
		sql.append("  WHERE                                                                                ");
		sql.append("  OCS1003.BUNHO = :f_bunho                                                             ");
		sql.append("  AND OCS1003.HOSP_CODE = :f_hosp_code                                                 ");
		sql.append("  AND OCS1003.FKOUT1001 = :f_pkout1001												   ");
		if(!orderTrans){                                                                                   
			sql.append("  AND OCS1003.ACTING_DATE IS NOT NULL											   ");
		}else{
			if(!isMisa){
				sql.append("  AND OCS1003.ACTING_DATE IS NULL												");
			}
			sql.append("  AND ( OCS1003.IF_DATA_SEND_YN <> 'Y' OR OCS1003.IF_DATA_SEND_YN IS NULL)   	   ");
			sql.append("  GROUP BY OCS1003.BUNHO, OUT1001.GUBUN, OCS1003.GWA,OCS1003.DOCTOR,OUT1001.CHOJAE ");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
		query.setParameter("f_pkout1001", pkout1001);
		
		List<NuroORDERTRANSUpdateOCS1003SelectToInsert> list = new JpaResultMapper().list(query, NuroORDERTRANSUpdateOCS1003SelectToInsert.class);
		return list;
	}

	@Override
	public Double getNuroORDERTRANSUpdateOCS1003Pkocs1003IfExists(String hospCode, Double pkout1001,
			NuroORDERTRANSUpdateOCS1003SelectToInsert nuroORDERTRANSUpdateOCS1003) {
		StringBuilder sql= new StringBuilder();
		
		sql.append("	SELECT PKOUT1003                        ");
		sql.append("	FROM OUT1003                            ");
		sql.append("	WHERE HOSP_CODE = :hospCode             ");
		sql.append("	AND BUNHO = :bunho                      ");
		sql.append("	AND GUBUN = :gubun                      ");
		sql.append("	AND GWA = :gwa                          ");
		sql.append("	AND DOCTOR = :doctor                    ");
		sql.append("	AND CHOJAE = :chojae                    ");
		sql.append("	AND FKOUT1001 = :pkout1001              ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", nuroORDERTRANSUpdateOCS1003.getBunho());
		query.setParameter("gubun", nuroORDERTRANSUpdateOCS1003.getGubun());
		query.setParameter("gwa", nuroORDERTRANSUpdateOCS1003.getGwa());
		query.setParameter("doctor", nuroORDERTRANSUpdateOCS1003.getDoctor());
		query.setParameter("chojae", nuroORDERTRANSUpdateOCS1003.getChojae());
		query.setParameter("pkout1001", pkout1001);
		
		List<Double> listResult = query.getResultList();
		
		if(!CollectionUtils.isEmpty(listResult)){
			return listResult.get(0);
		}
		return null;
	}
	
	@Override
	public String callPrInpUpdateOut0103(String hospCode, String userId, Date naewonDate, String bunho, String gwa,
			String gubun, String doctor, String inOut, String jubsuGwa, int tuyakIlsu, String specialYn, Date toiwonDate) {
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_INP_UPDATE_OUT0103");
		
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_NAEWON_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GWA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DOCTOR", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IN_OUT", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_JUBSU_GWA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TUYAK_ILSU", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SPECIAL_YN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TOIWON_DATE", Date.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE", hospCode);
		query.setParameter("I_USER", userId);
		query.setParameter("I_NAEWON_DATE", naewonDate);
		query.setParameter("I_BUNHO", bunho);
		query.setParameter("I_GWA", gwa);
		query.setParameter("I_GUBUN", gubun);
		query.setParameter("I_DOCTOR", doctor);
		
		query.setParameter("I_IN_OUT", inOut);
		query.setParameter("I_JUBSU_GWA", jubsuGwa);
		query.setParameter("I_TUYAK_ILSU", tuyakIlsu);
		query.setParameter("I_SPECIAL_YN", specialYn);
		query.setParameter("I_TOIWON_DATE", toiwonDate);
		
		query.execute();
		String ioFlag = (String)query.getOutputParameterValue("IO_FLAG");
		return ioFlag;
	}
}

