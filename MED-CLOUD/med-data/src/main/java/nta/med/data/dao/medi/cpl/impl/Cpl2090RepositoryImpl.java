package nta.med.data.dao.medi.cpl.impl;



import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.cpl.Cpl2090RepositoryCustom;
import nta.med.data.model.ihis.cpls.CPL3020U00DsvNoteListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U02DsvNoteListItemInfo;

/**
 * @author dainguyen.
 */
public class Cpl2090RepositoryImpl implements Cpl2090RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<CPL3020U00DsvNoteListItemInfo> getCPL3020U00DsvNoteListItem(
			String hospCode, String specimentSer, String jundalPart) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.JUNDAL_PART,   							");
		sql.append("	       A.SPECIMEN_SER,                              ");
		sql.append("	       A.NOTE,                                      ");
		sql.append("	       A.CODE,                                      ");
		sql.append("	       A.ETC_COMMENT                                ");
		sql.append("	  FROM CPL2090 A                                    ");
		sql.append("	 WHERE A.HOSP_CODE    = :hospCode                ");
		sql.append("	   AND A.SPECIMEN_SER = :specimentSer             ");
		sql.append("	   AND A.JUNDAL_PART  = :jundalPart             ");
		sql.append("	 ORDER BY 2 DESC                                    ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("specimentSer", specimentSer);
		query.setParameter("jundalPart",jundalPart);
		
		List<CPL3020U00DsvNoteListItemInfo> listResult = new JpaResultMapper().list(query, CPL3020U00DsvNoteListItemInfo.class);
		return listResult;
	}
	@Override
	public List<CPL3020U02DsvNoteListItemInfo> getCPL3020U02DsvNoteListItemInfo(String hospCode, String specimenSer, String jundalGubun){
		StringBuilder sql= new StringBuilder();
		sql.append("SELECT A.JUNDAL_PART,                      ");
		 sql.append("      A.SPECIMEN_SER,                      ");
		 sql.append("      A.NOTE,                              ");
		 sql.append("      A.CODE,                              ");
		 sql.append("      A.ETC_COMMENT                        ");
		 sql.append(" FROM CPL2090 A                            ");
		 sql.append("WHERE A.HOSP_CODE    = :f_hosp_code        ");
		 sql.append("  AND A.SPECIMEN_SER = :f_specimen_ser     ");
		 sql.append("  AND A.JUNDAL_PART  = :f_jundal_gubun     ");
		 sql.append("ORDER BY 2 DESC                            ");
		 
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_specimen_ser", specimenSer);
		query.setParameter("f_jundal_gubun", jundalGubun);
		List<CPL3020U02DsvNoteListItemInfo> list = new JpaResultMapper().list(query, CPL3020U02DsvNoteListItemInfo.class);
		return list;
	}

	@Override
	public String getCPL3020U00ExecuteGetYValue(String hospCode,
			String jundalGubun, String specimenSer) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT 'Y' 										");
		sql.append("	FROM CPL2090                                    ");
		sql.append("	WHERE HOSP_CODE    = :hospCode                  ");
		sql.append("	  AND JUNDAL_PART  = :jundalGubun               ");
		sql.append("	  AND SPECIMEN_SER = :specimenSer               ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("jundalGubun", jundalGubun);
		query.setParameter("specimenSer",specimenSer);
		
		List<String> result = query.getResultList();
		if(result != null && !result.isEmpty()){
			return result.get(0);
		}
		return null;
	}
	
}

