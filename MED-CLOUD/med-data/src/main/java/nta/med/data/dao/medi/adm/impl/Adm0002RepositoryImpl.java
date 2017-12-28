package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.adm.Adm0002RepositoryCustom;
import nta.med.data.model.ihis.adma.Adm501UListItemInfo;

/**
 * @author dainguyen.
 */
public class Adm0002RepositoryImpl implements Adm0002RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<Adm501UListItemInfo> getAdm501UListItem(String msgGubun,
			String searchMsg, String condition) {
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT ADM0002_PK, MSG_GUBUN, KOREA_MSG, ");
		sql.append("		   JAPAN_MSG, SPEAK_MSG FROM ADM0002 ");
		sql.append("	 WHERE MSG_GUBUN = :f_msg_gubun          ");
		if(condition.equals("rboKorea")){
			sql.append("	 AND KOREA_MSG LIKE :f_search_msg          ");
		}else if(condition.equals("rbxJapan")){
			sql.append("	 AND JAPAN_MSG LIKE :f_search_msg          ");
		}else if(condition.equals("else")){
			sql.append("	 AND SPEAK_MSG LIKE :f_search_msg          ");
		}else if(condition.equals("btnGetList")){
			sql.append("	 AND JAPAN_MSG IS NULL          			");
		}
		sql.append(" ORDER BY ADM0002_PK ASC							");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_msg_gubun", msgGubun);
		if(!condition.equals("btnGetList")){
			query.setParameter("f_search_msg", "%"+searchMsg+"%");
		}
		//query.setParameter("f_search_msg", "%"+searchMsg+"%");
		
		List<Adm501UListItemInfo> list = new JpaResultMapper().list(query, Adm501UListItemInfo.class);
		return list;
	}
}

