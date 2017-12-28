package nta.med.data.dao.emr;

import nta.med.core.domain.emr.EmrRecordHistory;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

public interface EmrRecordHistoryRepository extends JpaRepository<EmrRecordHistory, Long>, EmrRecordHistoryRepositoryCustom { 
	
	@Modifying
	@Query("	DELETE EmrRecordHistory			    "																			
			+"	WHERE version = :oldest_version		"																				
			+"	AND emrRecordId = :record_id		")
	public Integer deleteOcs2015U44Emr(
			@Param("record_id") Integer recordId,
			@Param("oldest_version") Integer oldestVersion);

}
