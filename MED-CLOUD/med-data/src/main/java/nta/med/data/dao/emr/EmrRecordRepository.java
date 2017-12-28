package nta.med.data.dao.emr;

import java.math.BigDecimal;
import java.util.List;

import nta.med.core.domain.emr.EmrRecord;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

public interface EmrRecordRepository extends JpaRepository<EmrRecord, Long>, EmrRecordRepositoryCustom { 
	@Modifying						    
	@Query("	UPDATE EmrRecord       "
			+ "	SET metadata = :f_meta          "
			+ "	WHERE emrRecordId = :f_record_id  "
			+ "	AND activeFlg = '1'            ")
	public Integer updateOCS2015U04FieldMetadata (
			@Param("f_meta") String metadata,
			@Param("f_record_id") Integer emrRecordId
			);

	//[5] Set lock for user
	@Modifying	
	@Query("	UPDATE EmrRecord 				"
			+ "	SET updId = :f_upd_id			"
			+ "	  , lockFlg = '1'				"
			+ "	  , updated = CURRENT_TIMESTAMP		"
			+ "	WHERE emrRecordId = :f_record_id	")
	public Integer setLockForUser (
			@Param("f_upd_id") String updId,
			@Param("f_record_id") Integer emrRecordId
			);

	@Modifying						    
	@Query("	UPDATE EmrRecord 					"
			+"	SET updId  = :updId ,               "
			+"	    content = :content,              "
			+"	    metadata  = :metadata           "
			+"	WHERE emrRecordId = :emrRecordId      ")
	public Integer updateOCS2015U44EmrHistoricRecord(
			@Param("updId") String updId,
			@Param("content") String content,
			@Param("metadata") String metadata,
			@Param("emrRecordId") Integer emrRecordId);
	
	@Modifying						    
	@Query("	UPDATE EmrRecord				"							
			+"	SET	content = :content ,		"				
			+"		metadata = :metadata ,		"    
			+"		lockFlg = :lockFlg ,		"	 
			+"		sysId = :updId ,			"	 
			+"		updId = :updId ,			"	
			+"		version = :version ,		"			
			+"		recordLog = :record_log,		"			
			+"		updated = CURRENT_TIMESTAMP		"	
			+"	WHERE emrRecordId = :record_id	")	
	public Integer updateOCS2015U44EmrNewContentOfMedicalRecord(
			@Param("content") String content,
			@Param("metadata") String metadata,
			@Param("lockFlg") BigDecimal lockFlg,
			@Param("updId") String updId,
			@Param("version") Integer version,
			@Param("record_log") String recordLog,
			@Param("record_id") Integer recordId);
	
	@Modifying	
	@Query("		UPDATE EmrRecord 					"
			+ "		SET lockFlg = '0'					"
			+ "		WHERE emrRecordId = :f_record_id	"
			+ "		AND updId = :updId					")
	public Integer updateOCS2015U44ReleaseLock (
			@Param("f_record_id") Integer recordId,
			@Param("updId") String updId);
	
	@Query("SELECT emr FROM  EmrRecord emr WHERE bunho = :bunho AND hospCode = :hospCode AND activeFlg = 1") 
	List<EmrRecord> getByActiveBunho(
			@Param("bunho") String bunho,
			@Param("hospCode") String hospCode);
	
	@Modifying						    
	@Query("	UPDATE EmrRecord				"							
			+"	SET	content = :content ,		"				
			+"		metadata = :metadata ,		"    
			+"		lockFlg = :lockFlg ,		"	 
			+"		sysId = :updId ,			"	 
			+"		updId = :updId ,			"			
			+"		recordLog = :record_log,		"			
			+"		updated = CURRENT_TIMESTAMP		"	
			+"	WHERE emrRecordId = :record_id	")	
	public Integer updateNUR2015U01EmrNewContentOfMedicalRecord(
			@Param("content") String content,
			@Param("metadata") String metadata,
			@Param("lockFlg") BigDecimal lockFlg,
			@Param("updId") String updId,
			@Param("record_log") String recordLog,
			@Param("record_id") Integer recordId);
}
