package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.core.domain.ocs.Ocs0133;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0133Repository extends JpaRepository<Ocs0133, Long>, Ocs0133RepositoryCustom {
	@Modifying
	@Query(" DELETE Ocs0133  WHERE hospCode = :f_hosp_code  AND inputControl = :f_input_control AND language = :f_language ")
	public Integer deleteOCS0133U00Execute(@Param("f_hosp_code") String hospCode,@Param("f_input_control") String inputControl,@Param("f_language") String language);
	
	@Query("Select ocs FROM Ocs0133 ocs WHERE ocs.hospCode = :f_hosp_code AND ocs.inputControl = :f_input_control AND language = :f_language ")
	public List<Ocs0133> getListOcs0133CaseUpdateOCS0133U00Execute(@Param("f_hosp_code") String hospCode,@Param("f_input_control") String inputControl,@Param("f_language") String language);
}

