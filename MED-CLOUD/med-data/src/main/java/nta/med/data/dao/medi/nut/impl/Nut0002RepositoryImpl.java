package nta.med.data.dao.medi.nut.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.nut.Nut0002RepositoryCustom;
import nta.med.data.model.ihis.nuts.Nut0001U00GrdNut0002ItemInfo;

/**
 * @author dainguyen.
 */
public class Nut0002RepositoryImpl implements Nut0002RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<Nut0001U00GrdNut0002ItemInfo> getNut0001U00GrdNut0002ItemInfo(
			String hospCode, Double pkocsKey) {
		StringBuffer sql = new StringBuffer();
		
		sql.append("	SELECT A.SYS_DATE									");
		sql.append("	    , A.USER_ID                                     ");
		sql.append("	    , A.UPD_DATE                                    ");
		sql.append("	    , A.HOSP_CODE                                   ");
		sql.append("	    , A.PKNUT0002                                   ");
		sql.append("	    , A.DATA_KUBUN                                  ");
		sql.append("	    , A.FKNUT0001                                   ");
		sql.append("	    , A.IO_KUBUN                                    ");
		sql.append("	    , B.SANG_CODE                                   ");
		sql.append("	    , CONCAT(B.PRE_MODIFIER_NAME,B.SANG_NAME,       ");
		sql.append("		B.POST_MODIFIER_NAME) DISPLAY_SYOUBYOUMEI       ");
		sql.append("	    , B.PRE_MODIFIER1                               ");
		sql.append("	    , B.PRE_MODIFIER2                               ");
		sql.append("	    , B.PRE_MODIFIER3                               ");
		sql.append("	    , B.PRE_MODIFIER4                               ");
		sql.append("	    , B.PRE_MODIFIER5                               ");
		sql.append("	    , B.PRE_MODIFIER6                               ");
		sql.append("	    , B.PRE_MODIFIER7                               ");
		sql.append("	    , B.PRE_MODIFIER8                               ");
		sql.append("	    , B.PRE_MODIFIER9                               ");
		sql.append("	    , B.PRE_MODIFIER10                              ");
		sql.append("	    , B.POST_MODIFIER1                              ");
		sql.append("	    , B.POST_MODIFIER2                              ");
		sql.append("	    , B.POST_MODIFIER3                              ");
		sql.append("	    , B.POST_MODIFIER4                              ");
		sql.append("	    , B.POST_MODIFIER5                              ");
		sql.append("	    , B.POST_MODIFIER6                              ");
		sql.append("	    , B.POST_MODIFIER7                              ");
		sql.append("	    , B.POST_MODIFIER8                              ");
		sql.append("	    , B.POST_MODIFIER9                              ");
		sql.append("	    , B.POST_MODIFIER10                             ");
		sql.append("	    , B.SANG_START_DATE                             ");
		sql.append("	    , B.SANG_JINDAN_DATE                            ");
		sql.append("	    , B.PRE_MODIFIER_NAME                           ");
		sql.append("	    , B.POST_MODIFIER_NAME                          ");
		sql.append("	    , B.SANG_NAME                                   ");
		sql.append("	    , A.FKOUTSANG                                   ");
		sql.append("	  FROM NUT0002 A,                                   ");
		sql.append("	       OUTSANG B                                    ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                   ");
		sql.append("	   AND A.FKNUT0001 = :f_fknut0001                   ");
		sql.append("	   AND B.HOSP_CODE = A.HOSP_CODE                    ");
		sql.append("	   AND B.PKOUTSANG = A.FKOUTSANG                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fknut0001", pkocsKey);
		
		List<Nut0001U00GrdNut0002ItemInfo> list = new JpaResultMapper().list(query, Nut0001U00GrdNut0002ItemInfo.class);
		return list;
	}
	
}

