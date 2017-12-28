package nta.med.data.dao.emr;

import nta.med.core.domain.emr.EmrTagRelation;

import java.math.BigDecimal;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

public interface EmrTagRelationRepository extends JpaRepository<EmrTagRelation, Long>, EmrTagRelationRepositoryCustom {
	
	@Modifying
	@Query(" UPDATE EmrTagRelation                   "
		 + " SET tagParent = :tagParent,             "
		 + "     tagChild  = :tagChild,              "
		 + "     updated   = SYSDATE(),              "
		 + "     updId     = :updId	, tagType = :tagType, defaultContent = :defaultContent				 "
		 + "  WHERE emrTagRelationId = :emrTagRelationId   ")
	public Integer updateOCS2015U31TagRelation(
			@Param("tagParent") String tagParent,
			@Param("tagChild") String tagChild,
			@Param("updId") String updId,
			@Param("tagType") BigDecimal tagType,
			@Param("defaultContent") String defaultContent,
			@Param("emrTagRelationId") Integer emrTagRelationId);
	
	@Modifying
	@Query(" UPDATE EmrTagRelation                   "
		 + " SET activeFlg = 0,                      "
		 + "     updated   = SYSDATE(),              "
		 + "     updId     = :updId	,tagType = :tagType, defaultContent = :defaultContent  "
		 + " WHERE tagParent = :tagParent   		 "
		 + " AND hospCode    = :hospCode 			 ")
	public Integer deleteOCS2015U31TagRelationParent(
			@Param("updId") String updId,
			@Param("tagParent") String tagParent,
			@Param("tagType") BigDecimal tagType,
			@Param("defaultContent") String defaultContent,
			@Param("hospCode") String hospCode);
	
	@Modifying
	@Query(" UPDATE EmrTagRelation                   "
		 + " SET activeFlg = 0,                      "
		 + "     updated   = SYSDATE(),              "
		 + "     updId     = :updId	,tagType = :tagType, defaultContent = :defaultContent	 "
		 + "  WHERE emrTagRelationId = :emrTagRelationId   ")
	public Integer deleteOCS2015U31TagRelationChild(
			@Param("updId") String updId,
			@Param("tagType") BigDecimal tagType,
			@Param("defaultContent") String defaultContent,
			@Param("emrTagRelationId") Integer emrTagRelationId);
	
	
	@Query(" SELECT T FROM EmrTagRelation T WHERE T.hospCode = :hospCode AND T.emrTemplateId = :emrTemplateId ")
	public List<EmrTagRelation> findByEmrTemplateId(@Param("hospCode") String hospCode, @Param("emrTemplateId") int emrTemplateId);

}
