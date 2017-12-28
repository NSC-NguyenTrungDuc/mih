package nta.med.data.dao.medi.pfe;

import nta.med.core.domain.pfe.Pfe0201;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Pfe0201Repository extends JpaRepository<Pfe0201, Long>, Pfe0201RepositoryCustom {
	@Modifying	
	@Query("	UPDATE Pfe0201 A			 "
			+ "	  SET A.fkpfe5010    = :f_pkpfe5010  "
			+ "	WHERE A.hospCode    = :f_hosp_code  "
			+ "	  AND A.fkocs1003    = :f_pkocs      ")
	public Integer updateOCSACTWhereHospCodeFkocs1003 (
			@Param("f_pkpfe5010") Double fkpfe5010,
			@Param("f_hosp_code") String hospCode,
			@Param("f_pkocs") Double fkocs1003
			);
}

