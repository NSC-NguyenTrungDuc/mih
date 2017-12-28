package nta.med.data.dao.medi.out;

import java.util.Date;

import nta.med.core.domain.out.Out0123;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out0123Repository extends JpaRepository<Out0123, Long>, Out0123RepositoryCustom {
	@Modifying
	@Query("UPDATE Out0123 "
			+ "SET updDate = :currentDate, updId = :userId, comments = :reserComment, "
			+ "reserGubun  = :reserGubun, reqDate = :currentDate "
			+ "WHERE hospCode = :hospitalCode AND bunho = :bunho "
			+ "AND fkout1001 = :pkout1001 AND commentType = '1' ")
	public Integer updateNuroRES1001U00ReservationOut0123(@Param("userId") String userId, 
			@Param("reserComment") String reserComment, @Param("reserGubun") String reserGubun, 
			@Param("currentDate") Date currentDate, @Param("hospitalCode") String hospitalCode, 
			@Param("bunho") String bunho, @Param("pkout1001") Double pkout1001 );
	
	@Modifying
	@Query("DELETE FROM Out0123 WHERE hospCode = :hospitalCode AND bunho = :patientCode AND fkout1001 = :pkout1001 AND commentType = '1'")
	public Integer deleteOut0123ByPatientCodeAndPkout1001(@Param("hospitalCode") String hospitalCode, @Param("patientCode") String patientCode, @Param("pkout1001") Long pkout1001);
	
	@Query("SELECT COUNT(a) FROM Out0123 a WHERE a.hospCode = :hospitalCode AND a.bunho = :bunho AND a.commentType = '0' "
			+ "AND (a.consultDoctor = :consultDoctor OR a.consultDoctor = '%') AND (a.answerEndYn != 'Y' OR a.answerEndYn IS NULL) ")
	public Integer getOutJinryoCommentCnt(@Param("hospitalCode") String hospitalCode,
			@Param("bunho") String bunho,
			@Param("consultDoctor") String consultDoctor); 
	
}

