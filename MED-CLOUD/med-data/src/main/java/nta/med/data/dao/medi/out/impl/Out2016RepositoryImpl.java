package nta.med.data.dao.medi.out.impl;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.out.Out2016RepositoryCustom;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.emr.OCS2015U03AllLinkClinicInfo;
import nta.med.data.model.ihis.nuro.LinkEMRPatientInfo;
import nta.med.data.model.ihis.nuro.NUR2016U02GrdListInfo;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.List;

public class Out2016RepositoryImpl implements Out2016RepositoryCustom{

	private static Log LOG = LogFactory.getLog(Out2016RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OCS2015U03AllLinkClinicInfo> getOCS2015U03AllLinkClinicInfo(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT HOSP_CODE_LINK,         ");
		sql.append("        BUNHO_LINK,             ");
		sql.append("        LINK_TYPE               ");
		sql.append(" FROM OUT2016                   ");
		sql.append(" WHERE HOSP_CODE = :hosp_code   ");
		sql.append(" AND BUNHO       = :bunho       ");
		sql.append(" AND EMR_LINK_FLG = 1			");
		sql.append(" AND ACTIVE_FLG = 1				");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("bunho", bunho);

		List<OCS2015U03AllLinkClinicInfo> list = new JpaResultMapper().list(query,OCS2015U03AllLinkClinicInfo.class);
		return list;
	}

	@Override
	public String getEmrLinkFlg(String hospCode, String bunho, String hospCodeLink, String bunhoLink){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT EMR_LINK_FLG         			");
		sql.append(" FROM OUT2016                   		");
		sql.append(" WHERE HOSP_CODE       = :hospCode   	");
		sql.append(" AND BUNHO             = :bunho       	");
		sql.append(" AND HOSP_CODE_LINK    = :hospCodeLink  ");
		sql.append(" AND BUNHO_LINK        = :bunhoLink     ");
		sql.append(" AND ACTIVE_FLG        = 1			    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("hospCodeLink", hospCodeLink);
		query.setParameter("bunhoLink", bunhoLink);
		
		List<Object> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	public String getOut2016Id(String hospCode, String bunho, String hospCodeLink, String bunhoLink){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT ID			         			");
		sql.append(" FROM OUT2016                   		");
		sql.append(" WHERE HOSP_CODE       = :hospCode   	");
		sql.append(" AND BUNHO             = :bunho       	");
		sql.append(" AND HOSP_CODE_LINK    = :hospCodeLink  ");
		sql.append(" AND BUNHO_LINK        = :bunhoLink     ");
		sql.append(" AND ACTIVE_FLG        = 1			    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("hospCodeLink", hospCodeLink);
		query.setParameter("bunhoLink", bunhoLink);
		
		List<Object> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0).toString();
		}
		return null;
	}
	
	@Override
	public boolean verifyKcckAccount(String hospCodeLink, String bunhoLink, String password){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 'Y' FROM OUT0101			         			");
		sql.append(" WHERE HOSP_CODE       = :hospCode   					");
		sql.append(" AND BUNHO             = :bunho       					");
		sql.append(" AND PWD    		   = :password  					");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCodeLink);
		query.setParameter("bunho", bunhoLink);
		query.setParameter("password", password);
		
		List<Object> result = query.getResultList();
		if(!result.isEmpty()){
			 return true;
		}
		return false;
	}
	
	@Override
	public List<NUR2016U02GrdListInfo> getNUR2016U02GrdListInfo(String hospCode, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 'N' SELECTN                                                                          ");
		sql.append("    ,A.HOSP_CODE_LINK                                                                        ");
		sql.append("    ,B.YOYANG_NAME                                                                           ");
		sql.append("    ,A.BUNHO_LINK                                                                            ");
		sql.append("    ,C.SUNAME                                                                                ");
		sql.append("    ,C.ADDRESS1                                                                              ");
		sql.append("    ,C.BIRTH                                                                                 ");
		sql.append(" FROM OUT2016 A LEFT OUTER JOIN BAS0001 B ON A.HOSP_CODE_LINK = B.HOSP_CODE                  ");
		sql.append(" AND B.START_DATE = (SELECT MAX(START_DATE) FROM BAS0001 C WHERE C.HOSP_CODE = B.HOSP_CODE ) ");
		sql.append(" LEFT OUTER JOIN OUT0101 C ON C.BUNHO = A.BUNHO_LINK                                         ");
		sql.append("  AND C.HOSP_CODE = A.HOSP_CODE_LINK                                                         ");
		sql.append(" WHERE A.HOSP_CODE = :hosp_code                                                              ");
		sql.append(" AND A.ACTIVE_FLG = 1                                                                        ");
		sql.append(" AND A.BUNHO = :f_bunho 														             ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("f_bunho", bunho);
	
		List<NUR2016U02GrdListInfo> list = new JpaResultMapper().list(query,NUR2016U02GrdListInfo.class);
		return list;
	}

	@Override
	public List<ComboListItemInfo> getRES1001U00FbxHospCodeLinkDataValidating(String hospCode, String language, String bunho) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT B.YOYANG_NAME,                  ");
		sql.append("        A.BUNHO_LINK                    ");
		sql.append(" FROM OUT2016 A, BAS0001 B              ");
		sql.append(" WHERE A.HOSP_CODE_LINK = B.HOSP_CODE   ");
		sql.append(" AND B.HOSP_CODE = :hosp_code           ");
		sql.append(" AND A.BUNHO     = :bunho               ");
		sql.append(" AND B.LANGUAGE  = :language			");
		sql.append(" AND B.START_DATE = (SELECT MAX(START_DATE) FROM BAS0001 C WHERE A.HOSP_CODE_LINK = C.HOSP_CODE ) ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("language", language);
		query.setParameter("bunho", bunho);

		List<ComboListItemInfo> list = new JpaResultMapper().list(query,ComboListItemInfo.class);
		return list;
	}
	
	@Override
	public boolean verifyPatientLinkYn(String hospCode, String bunho, String hospCodeLink, String bunhoLink){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT 'Y' FROM OUT2016                      			");
		sql.append(" WHERE                                   				");
		sql.append("     HOSP_CODE = :hospCode               				");
		sql.append("     AND BUNHO = :bunho                  				");
		sql.append("     AND HOSP_CODE_LINK = :hospCodeLink  				");
		sql.append("     AND BUNHO_LINK = :bunhoLink         				");		
		//BA confirm 
		sql.append("     AND ACTIVE_FLG <> '0'         						");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("hospCodeLink", hospCodeLink);
		query.setParameter("bunhoLink", bunhoLink);
		
		List<Object> result = query.getResultList();
		if(!result.isEmpty()){
			 return true;
		}
		return false;
	}
	
	
	@Override
	public List<LinkEMRPatientInfo> getLinkEMRPatientInfo(String hospCode, String bunho, String hospCodeLink, String bunhoLink) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT  ID  PATIENT_ID                  ");
		sql.append("       , BUNHO_LINK                      ");
		sql.append(" FROM OUT2016                            ");
		sql.append(" WHERE HOSP_CODE = :hosp_code            ");
		sql.append(" AND BUNHO = :bunho                      ");
		sql.append(" AND HOSP_CODE_LINK = :hosp_code_link    ");
		sql.append(" AND ACTIVE_FLG = 1 					 ");
			
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hosp_code", hospCode);
		query.setParameter("bunho", bunho);
		query.setParameter("hosp_code_link", hospCodeLink);
		//query.setParameter("bunho_link", bunhoLink);

		List<LinkEMRPatientInfo> list = new JpaResultMapper().list(query,LinkEMRPatientInfo.class);
		return list;
	}

}
