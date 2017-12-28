package nta.med.data.dao.medi.ocs;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.ocs.Ocs0103S;


@Repository
public interface Ocs0103SRepository extends JpaRepository<Ocs0103S, Long>, Ocs0103SRepositoryCustom {
	
	@Modifying
	@Query("DELETE FROM Ocs0103S WHERE groupCode = :f_group_code AND hangmogCode = :f_hangmog_code AND startDate   = :f_start_date ")
	public Integer deleteOcs0103SU00(@Param("f_group_code") String groupCode,@Param("f_hangmog_code") String hangmogCode,
			@Param("f_start_date") Date startDate);
	
	@Query("SELECT MAX(seq) + 1 FROM Ocs0103S  WHERE groupCode = :f_group_code  AND slipCode = :f_slip_code ")
	public Double getMaxSeqOcs0103S(@Param("f_group_code") String groupCode,@Param("f_slip_code") String slipCode);
}

