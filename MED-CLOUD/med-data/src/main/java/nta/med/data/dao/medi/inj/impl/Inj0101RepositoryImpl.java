package nta.med.data.dao.medi.inj.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.inj.Inj0101RepositoryCustom;
import nta.med.data.model.ihis.injs.INJ0101U01GrdMasterItemInfo;
import nta.med.data.model.ihis.injs.InjsComboListItemInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01FormJusaBedLayHosilItemInfo;

/**
 * @author dainguyen.
 */
public class Inj0101RepositoryImpl implements Inj0101RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<InjsComboListItemInfo> getINJ0101U00GrdMasterInfo(String hospCode, String language){
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE_TYPE       CODE_TYPE,          ");
		sql.append("        A.CODE_TYPE_NAME  CODE_TYPE_NAME      ");
		sql.append("   FROM INJ0101 A                             ");
		sql.append("  WHERE   A.ADMIN_GUBUN = 'USER'              ");
		sql.append("  	AND A.LANGUAGE = :f_language              ");
		sql.append("  ORDER BY 1                                  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_language", language);
		//query.setParameter("f_hosp_code", hospCode);
		List<InjsComboListItemInfo> list = new JpaResultMapper().list(query, InjsComboListItemInfo.class);
		return list;
	}

	@Override
	public List<InjsINJ1001U01FormJusaBedLayHosilItemInfo> getInjsINJ1001U01FormJusaBedLayHosilItemInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE_TYPE, '1' ONE , B.SU                                             ");
		sql.append(" FROM INJ0101 A                                                                 ");
		sql.append(" , (SELECT SUM(1) SU                                                            ");
		sql.append(" , CODE_TYPE CODE_TYPE                                                          ");
		sql.append(" , :f_hosp_code HOSP_CODE                                                       ");
		sql.append(" FROM INJ0102                                                                   ");
		sql.append(" WHERE CODE_TYPE LIKE 'BED%'  AND LANGUAGE = :f_language                        ");
		sql.append(" GROUP BY HOSP_CODE, CODE_TYPE ) B                                              ");
		//sql.append(" WHERE   B.HOSP_CODE       = :f_hosp_code									    ");
		sql.append(" WHERE   																	    ");
		sql.append("     A.CODE_TYPE_NAME  = 'BED' AND A.CODE_TYPE = B.CODE_TYPE 					");
		sql.append("  	AND A.LANGUAGE = :f_language              								    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_language", language);
		List<InjsINJ1001U01FormJusaBedLayHosilItemInfo> getInjsINJ1001U01FormJusaBedLayHosilItemInfo= new JpaResultMapper().list(query, InjsINJ1001U01FormJusaBedLayHosilItemInfo.class);
		return getInjsINJ1001U01FormJusaBedLayHosilItemInfo;
	}

	@Override
	public List<INJ0101U01GrdMasterItemInfo> getINJ0101U01GrdMasterItemInfo(String hospCode, String language) {
		StringBuilder sql = new StringBuilder();
		sql.append(" SELECT A.CODE_TYPE       CODE_TYPE         ");
		sql.append("      , A.CODE_TYPE_NAME  CODE_TYPE_NAME    ");
		sql.append("      , A.ADMIN_GUBUN     ADMIN_GUBUN       ");
		sql.append("      , A.REMARK          REMARK            ");
		sql.append("   FROM INJ0101 A                           ");
		sql.append(" WHERE A.LANGUAGE = :f_language             ");
		sql.append(" ORDER BY 1									");
		Query query = entityManager.createNativeQuery(sql.toString());
		
		query.setParameter("f_language", language);
		List<INJ0101U01GrdMasterItemInfo> listResult= new JpaResultMapper().list(query, INJ0101U01GrdMasterItemInfo.class);
		return listResult;
	}
}

