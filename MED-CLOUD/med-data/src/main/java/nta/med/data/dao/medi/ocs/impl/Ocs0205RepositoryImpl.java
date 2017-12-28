package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0205RepositoryCustom;
import nta.med.data.model.ihis.ocsa.Ocs0204Q00GrdOcs0205ListItemInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0204U00GrdOCS0205ListInfo;

/**
 * @author dainguyen.
 */
public class Ocs0205RepositoryImpl implements Ocs0205RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<OcsaOCS0204U00GrdOCS0205ListInfo> getOcsaOCS0204U00GrdOCS0205List(String hospCode, String fMemb, String sangGubun){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.PK_SEQ            ,                                                                                          ");
		sql.append("       A.MEMB              ,                                                                                          ");
		sql.append("       A.SANG_GUBUN        ,                                                                                          ");
		sql.append("       A.SANG_CODE         ,                                                                                          ");
		sql.append("       CONCAT(IFNULL(A.PRE_MODIFIER_NAME,''),IFNULL(A.SANG_NAME,''),IFNULL(A.POST_MODIFIER_NAME,'')) DIS_SANG_NAME,   ");
		sql.append("       A.SER               ,                                                                                          ");
		sql.append("       A.SANG_NAME         ,                                                                                          ");
		sql.append("       A.PRE_MODIFIER1     ,                                                                                          ");
		sql.append("       A.PRE_MODIFIER2     ,                                                                                          ");
		sql.append("       A.PRE_MODIFIER3     ,                                                                                          ");
		sql.append("       A.PRE_MODIFIER4     ,                                                                                          ");
		sql.append("       A.PRE_MODIFIER5     ,                                                                                          ");
		sql.append("       A.PRE_MODIFIER6     ,                                                                                          ");
		sql.append("       A.PRE_MODIFIER7     ,                                                                                          ");
		sql.append("       A.PRE_MODIFIER8     ,                                                                                          ");
		sql.append("       A.PRE_MODIFIER9     ,                                                                                          ");
		sql.append("       A.PRE_MODIFIER10    ,                                                                                          ");
		sql.append("       A.PRE_MODIFIER_NAME ,                                                                                          ");
		sql.append("       A.POST_MODIFIER1    ,                                                                                          ");
		sql.append("       A.POST_MODIFIER2    ,                                                                                          ");
		sql.append("       A.POST_MODIFIER3    ,                                                                                          ");
		sql.append("       A.POST_MODIFIER4    ,                                                                                          ");
		sql.append("       A.POST_MODIFIER5    ,                                                                                          ");
		sql.append("       A.POST_MODIFIER6    ,                                                                                          ");
		sql.append("       A.POST_MODIFIER7    ,                                                                                          ");
		sql.append("       A.POST_MODIFIER8    ,                                                                                          ");
		sql.append("       A.POST_MODIFIER9    ,                                                                                          ");
		sql.append("       A.POST_MODIFIER10   ,                                                                                          ");
		sql.append("       A.POST_MODIFIER_NAME                                                                                           ");
		sql.append("  FROM OCS0205 A                                                                                                      ");
		sql.append(" WHERE A.HOSP_CODE   = :f_hosp_code                                                                                   ");
		sql.append("   AND A.MEMB        = :f_memb                                                                                        ");
		sql.append("   AND A.MEMB_GUBUN  = '1'                                                                                            ");
		sql.append("   AND A.SANG_GUBUN  = :f_sang_gubun                                                                                  ");
		sql.append(" ORDER BY A.SER                                                                                                       ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_memb", fMemb);
		query.setParameter("f_sang_gubun", sangGubun);

		List<OcsaOCS0204U00GrdOCS0205ListInfo> list = new JpaResultMapper().list(query, OcsaOCS0204U00GrdOCS0205ListInfo.class);
		return list;
	}

	@Override
	public String getOcs0205Seq(String seqName){
		StringBuilder sql = new StringBuilder("SELECT SWF_NextVal(:f_seq_name)");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_seq_name", seqName);
		
		List<Object> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0).toString();
		}
		return null;
	}
	
	public List<Ocs0204Q00GrdOcs0205ListItemInfo> getOcs0204Q00GrdOcs0205ListItemInfo(String hospCode, String fMemb, String sangGubun, String sangNameInx){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT A.SANG_GUBUN        ,	                                                                                                        ");
		sql.append("	       A.PK_SEQ            ,	                                                                                                        ");
		sql.append("	       A.SANG_CODE         ,	                                                                                                        ");
		sql.append("	       CONCAT(IFNULL(A.PRE_MODIFIER_NAME,''),IFNULL(A.SANG_NAME,''),IFNULL(A.POST_MODIFIER_NAME,'')) DIS_SANG_NAME,	                    ");
		sql.append("	       A.SER               ,	                                                                                                        ");
		sql.append("	       A.SANG_NAME         ,	                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER1     ,	                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER2     ,	                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER3     ,	                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER4     ,	                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER5     ,	                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER6     ,	                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER7     ,	                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER8     ,	                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER9     ,	                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER10    ,	                                                                                                        ");
		sql.append("	       A.PRE_MODIFIER_NAME ,	                                                                                                        ");
		sql.append("	       A.POST_MODIFIER1    ,	                                                                                                        ");
		sql.append("	       A.POST_MODIFIER2    ,	                                                                                                        ");
		sql.append("	       A.POST_MODIFIER3    ,	                                                                                                        ");
		sql.append("	       A.POST_MODIFIER4    ,	                                                                                                        ");
		sql.append("	       A.POST_MODIFIER5    ,	                                                                                                        ");
		sql.append("	       A.POST_MODIFIER6    ,	                                                                                                        ");
		sql.append("	       A.POST_MODIFIER7    ,	                                                                                                        ");
		sql.append("	       A.POST_MODIFIER8    ,	                                                                                                        ");
		sql.append("	       A.POST_MODIFIER9    ,	                                                                                                        ");
		sql.append("	       A.POST_MODIFIER10   ,	                                                                                                        ");
		sql.append("	       A.POST_MODIFIER_NAME															                                                    ");
		sql.append("	  FROM OCS0205 A																	                                                    ");
		sql.append("	 WHERE A.HOSP_CODE  = :f_hosp_code													                                                    ");
		sql.append("	   AND A.MEMB       = :f_memb														                                                    ");
		sql.append("	   AND A.SANG_GUBUN LIKE :f_sang_gubun												                                                    ");
		sql.append("	   AND CONCAT(IFNULL(A.PRE_MODIFIER_NAME,''),IFNULL(RTRIM(A.SANG_NAME),''),IFNULL(A.POST_MODIFIER_NAME,'')) LIKE :f_sang_name_inx		");
		sql.append("	 ORDER BY A.SER																							                                ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_memb", fMemb);
		query.setParameter("f_sang_gubun", sangGubun);
		query.setParameter("f_sang_name_inx", "%"+sangNameInx+"%");

		List<Ocs0204Q00GrdOcs0205ListItemInfo> list = new JpaResultMapper().list(query, Ocs0204Q00GrdOcs0205ListItemInfo.class);
		return list;
	}
}

