package nta.med.data.dao.medi.ocs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ocs.Ocs0702RepositoryCustom;
import nta.med.data.model.ihis.ocso.OCS2016U00LoadDiscussionInfo;

public class Ocs0702RepositoryImpl implements Ocs0702RepositoryCustom {

	@PersistenceContext
	private EntityManager entityManager;

	public List<OCS2016U00LoadDiscussionInfo> getOCS2016U00LoadDiscussionInfo(Long groupQuestionId){
		StringBuilder sql = new StringBuilder();
		sql.append("	SELECT	A.DOCTOR                              			AS  doctor,			");
		sql.append("	        B.DOCTOR_NAME                         			AS  doctorName,		");
		sql.append("	        A.CONTENT                             			AS  content,		");
		sql.append("	        CASE WHEN A.UPDATED IS NULL THEN DATE_FORMAT(A.CREATED, '%Y/%m/%d')	");
		sql.append("			ELSE DATE_FORMAT(A.UPDATED, '%Y/%m/%d') END    	AS  updated,		");
		sql.append("	        CONVERT(A.EDITED_FLG, CHAR(2))    				AS  editedFlg,		");
		sql.append("	        CONVERT(A.GRP_QUESTION_ID, CHAR(20))  			AS  grpQuestionId,	");
		sql.append("	        CONVERT(A.ID, CHAR(20))				  			AS  discussionId	");
		sql.append("	FROM OCS0702 A																");
		sql.append("	JOIN BAS0271 B ON A.DOCTOR = B.DOCTOR										");
		sql.append("	              AND A.HOSP_CODE = B.HOSP_CODE									");
		sql.append("	WHERE A.GRP_QUESTION_ID = :f_group_question_id								");
		sql.append("	ORDER BY A.CREATED															");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_group_question_id", groupQuestionId);
		
		List<OCS2016U00LoadDiscussionInfo> listItem = new JpaResultMapper().list(query, OCS2016U00LoadDiscussionInfo.class);
		return listItem;
	}
	
	
}
