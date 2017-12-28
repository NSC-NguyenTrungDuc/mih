package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0311;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0311Repository extends JpaRepository<Ocs0311, Long>, Ocs0311RepositoryCustom {
	@Modifying
	@Query(" DELETE Ocs0311 WHERE hospCode = :f_hosp_code AND setPart = :f_set_part AND hangmogCode = :f_hangmog_code")
	public Integer deleteOCS0311U00Execute(@Param("f_hosp_code") String hospCode,@Param("f_set_part") String setPart,@Param("f_hangmog_code") String hangmogCode);
	
	@Query("SELECT 'Y' FROM Ocs0311 WHERE hospCode= :f_hosp_code AND setPart = :f_set_part AND hangmogCode = :f_hangmog_code ")
	public String getOCS0311U00layDupHangmogCode(@Param("f_hosp_code") String hospCode,@Param("f_set_part") String setPart,@Param("f_hangmog_code") String hangmogCode);
}

