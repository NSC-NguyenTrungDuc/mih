package nta.med.data.dao.medi.adm.impl;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.AdmsGroupRepositoryCustom;
import nta.med.data.dao.medi.out.impl.Out1001RepositoryImpl;
import nta.med.data.model.ihis.adma.ADMS2015U00GetGroupHospitalInfo;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import java.util.List;

/**
 * @author dainguyen.
 */
public class AdmsGroupRepositoryImpl implements AdmsGroupRepositoryCustom {

	private static Log LOG = LogFactory.getLog(Out1001RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;

	public List<ADMS2015U00GetGroupHospitalInfo> getADMS2015U00GetGroupHospitalInfo (String hospCode, String language){	
		StringBuffer sql = new StringBuffer();	
		sql.append("	SELECT CAST(A.ADMS_GROUP_ID AS CHAR) ADMS_GROUP_ID,				");
		sql.append("	       B.GRP_ID GRP_ID,                                         ");
		sql.append("	       B.GRP_NM GRP_NM,                                         ");
		sql.append("	       CAST(A.GRP_SEQ AS CHAR) GRP_SEQ,                         ");
		sql.append("	       A.HOSP_CODE HOSP_CODE,                                   ");
		sql.append("	       CAST(A.SELECT_FLG AS CHAR) SELECT_FLG                    ");
		sql.append("	FROM ADM0100 B LEFT JOIN ADMS_GROUP A  ON A.GRP_ID = B.GRP_ID   ");                       
		sql.append("	AND A.HOSP_CODE = :f_hosp_code                                  ");
		sql.append("	WHERE B.LANGUAGE = :f_language                                    ");

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		
		List<ADMS2015U00GetGroupHospitalInfo> list = new JpaResultMapper().list(query, ADMS2015U00GetGroupHospitalInfo.class);
		return list;
	}
	
}

