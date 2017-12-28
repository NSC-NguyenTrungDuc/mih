package nta.med.data.dao.medi.bas;

import java.util.Date;

import nta.med.core.domain.bas.Bas0272;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0272Repository extends JpaRepository<Bas0272, Long>, Bas0272RepositoryCustom {
	@Query("SELECT DISTINCT 'X' FROM Bas0272 WHERE hospCode = :hospCode AND sabun = :sabun")
	public String checkExistBySabun(@Param("hospCode") String hospCode, @Param("sabun") String sabun);
	
	@Query("SELECT DISTINCT 'X' FROM Bas0272 WHERE hospCode = :hospCode AND sabun = :sabun AND doctorGwa = :doctorGwa")
	public String checkExistBySabunAndDoctorGwa(@Param("hospCode") String hospCode, @Param("sabun") String sabun, @Param("doctorGwa") String doctorGwa);
	
	@Modifying
	@Query("UPDATE Bas0272                           " +
			"  SET updId          = :updId            " +
			"    , updDate        = :updDate          " +
			"    , endDate        = :endDate          " +
			"    , mainGwaYn   	  = :mainGwaYn        " +
			"    , outDiscussYn  = :outDiscussYn	  " +
			"    , reserOutYn     = :reserOutYn    	  " +
			"WHERE hospCode       = :hospCode         " +
			"  AND sabun          = :sabun            " +
			"  AND doctorGwa      = :doctorGwa           " +
			"  AND DATE_FORMAT(startDate, '%Y/%m/%d') = :startDate  ")
	public Integer updateBas0272(
			@Param("hospCode") String hospCode,
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("endDate") Date endDate,
			@Param("mainGwaYn") String mainGwaYn,
			@Param("sabun") String sabun,
			@Param("doctorGwa") String doctorGwa,
			@Param("startDate") String startDate,
			@Param("outDiscussYn") String outDiscussYn,
			@Param("reserOutYn") String reserOutYn
			);
	
	@Modifying
	@Query("DELETE FROM Bas0272                       " +
			"WHERE hospCode       = :hospCode         " +
			"  AND sabun          = :sabun            " +
			"  AND doctorGwa      = :doctorGwa           " +
			"  AND DATE_FORMAT(startDate, '%Y/%m/%d') = :startDate  ")
	public Integer deleteBas0272(
			@Param("hospCode") String hospCode,
			@Param("sabun") String sabun,
			@Param("doctorGwa") String doctorGwa,
			@Param("startDate") String startDate
			);
	
	@Query("SELECT DISTINCT outDiscussYn FROM Bas0272 WHERE hospCode = :hospCode AND doctor = :doctor AND doctorGwa = :doctorGwa")
	public String getOutDiscussYn(@Param("hospCode") String hospCode, @Param("doctor") String doctor, @Param("doctorGwa") String doctorGwa);
}

