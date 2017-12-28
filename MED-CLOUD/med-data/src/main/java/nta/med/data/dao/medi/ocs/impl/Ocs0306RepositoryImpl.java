package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0306RepositoryCustom;
import nta.med.data.model.ihis.ocsa.OCS0304Q00grdOCS0306Info;

/**
 * @author dainguyen.
 */
public class Ocs0306RepositoryImpl implements Ocs0306RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;

	@Override
	public List<OCS0304Q00grdOCS0306Info> getOCS0304Q00grdOCS0306Info(String hospCode, String memb) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("SELECT A.MEMB               MEMB										");
		sql.append("     , A.YAKSOK_DIRECT_CODE YAKSOK_DIRECT_CODE							" );
		sql.append("     , A.PK_SEQ             PK_SEQ										" );
		sql.append("     , A.SEQ                SEQ											" );
		sql.append("     , A.DIRECT_GUBUN       DIRECT_GUBUN								" );
		sql.append("     , A.DIRECT_CODE        DIRECT_CODE 								" );
		sql.append("     , A.DIRECT_DETAIL      DIRECT_DETAIL								" );
		sql.append("     , A.HANGMOG_CODE       HANGMOG_CODE								" );
		sql.append("     , A.SURYANG            SURYANG										" );
		sql.append("     , A.NALSU              NALSU										" );
		sql.append("     , A.ORD_DANUI          ORD_DANUI									" );
		sql.append("     , A.BOGYONG_CODE       BOGYONG_CODE								" );
		sql.append("     , A.JUSA_CODE          JUSA_CODE									" );
		sql.append("     , A.JUSA_SPD_GUBUN     JUSA_SPD_GUBUN								" );
		sql.append("     , A.DV                 DV											" );
		sql.append("     , A.DV_TIME            DV_TIME										" );
		sql.append("     , A.INSULIN_FROM       INSULIN_FROM								" );
		sql.append("     , A.INSULIN_TO         INSULIN_TO									" );
		sql.append("     , A.TIME_GUBUN         TIME_GUBUN									" );
		sql.append("     , A.BOM_YN             BOM_YN										" );
		sql.append("     , A.BOM_SOURCE_KEY     BOM_SOURCE_KEY								" );
		sql.append("  FROM OCS0306 A														" );
		sql.append(" WHERE (   A.MEMB            LIKE   CONCAT('%', SUBSTRING(:memb , 3))	" );
		sql.append("        OR A.MEMB = 'ADMIN')											");
		sql.append("   AND A.HOSP_CODE          = :f_hosp_code								" );
//		sql.append("--   AND A.YAKSOK_DIRECT_CODE = :f_yaksok_direct_code					" );
		sql.append(" UNION																	" );
		sql.append("SELECT A.MEMB               MEMB										" );
		sql.append("     , A.YAKSOK_DIRECT_CODE YAKSOK_DIRECT_CODE							" );
		sql.append("     , A.PK_SEQ             PK_SEQ										" );
		sql.append("     , A.SEQ                SEQ											" );
		sql.append("     , A.DIRECT_GUBUN       DIRECT_GUBUN								" );
		sql.append("     , A.DIRECT_CODE        DIRECT_CODE 								" );
		sql.append("     , A.DIRECT_DETAIL      DIRECT_DETAIL								" );
		sql.append("     , A.HANGMOG_CODE       HANGMOG_CODE								" );
		sql.append("     , A.SURYANG            SURYANG										" );
		sql.append("     , A.NALSU              NALSU										" );
		sql.append("     , A.ORD_DANUI          ORD_DANUI									" );
		sql.append("     , A.BOGYONG_CODE       BOGYONG_CODE								" );
		sql.append("     , A.JUSA_CODE          JUSA_CODE									" );
		sql.append("     , A.JUSA_SPD_GUBUN     JUSA_SPD_GUBUN								" );
		sql.append("     , A.DV                 DV											" );
		sql.append("     , A.DV_TIME            DV_TIME										" );
		sql.append("     , A.INSULIN_FROM       INSULIN_FROM								" );
		sql.append("     , A.INSULIN_TO         INSULIN_TO									" );
		sql.append("     , A.TIME_GUBUN         TIME_GUBUN									" );
		sql.append("     , A.BOM_YN             BOM_YN										" );
		sql.append("     , A.BOM_SOURCE_KEY     BOM_SOURCE_KEY								" );
		sql.append("  FROM OCS0306 A														" );
		sql.append(" WHERE A.MEMB               = 'ADMIN'									" );
		sql.append("   AND A.HOSP_CODE          = :f_hosp_code								" );
		sql.append(" ORDER BY 3																" );
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("memb", memb);
		
		List<OCS0304Q00grdOCS0306Info> listResult = new JpaResultMapper().list(query,OCS0304Q00grdOCS0306Info.class);
		return listResult;
	}
}

