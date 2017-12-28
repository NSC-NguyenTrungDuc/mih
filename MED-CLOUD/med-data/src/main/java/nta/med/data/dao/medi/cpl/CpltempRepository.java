package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpltemp;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface CpltempRepository extends JpaRepository<Cpltemp, Long>, CpltempRepositoryCustom {
	@Modifying
	@Query("DELETE Cpltemp WHERE hospCode  = :f_hosp_code AND ipAddress = :q_user_id AND jundalGubun = 'XX' ")
	public Integer deleteCpltempCPL0000Q00(@Param("f_hosp_code") String hospCode,
			@Param("q_user_id") String ipAddress);
}

